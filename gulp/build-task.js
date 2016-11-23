/*eslint-env node*/
/*eslint no-console:0*/
'use strict';

const fs = require('fs');
const glob = require('glob');
const through2 = require('through2');
const gulp = require('gulp');
const debug = require('gulp-debug');
const gulpif = require('gulp-if');
const shell = require('gulp-shell');
const msbuild = require('gulp-msbuild');
const gitignoreFilter = require('./gitignore-filter');
const errorHandler = require('./errorHandler');

/**
 * A promise which resolves when the logs directory has been created (if it didn't already exist)
 */
const ensureLogDirectoryExists = new Promise((resolve, reject) => {
    fs.mkdir('logs/', (err) => {
        if (err && err.code !== 'EEXIST') {
            reject(err);
        } else {
            resolve();
        }
    });
});

/**
 * A promise which resolves to the assembly in which is defined MSBuild loggers for VSO, or null
 *
 * @description this searches for the VSO logger, based on https://github.com/Microsoft/vsts-tasks/blob/ce2f6325b83f69ba81f1fabe4951cb0064128cbe/Tasks/Common/MSBuildHelpers/InvokeFunctions.ps1#L221
 *              the base path is also based on https://github.com/Microsoft/vsts-tasks/issues/665
 */
const loggerAssemblyPromise = new Promise((resolve) => {
    glob('../../../agent/worker/Microsoft.TeamFoundation.DistributedTask.MSBuild.Logger.dll', { silent: true, realpath: true, }, (err, paths) => {
        if (err || paths.length === 0) {
            resolve(null);
        } else {
            resolve(paths[0]);
        }
    });
});

/**
 * Creates MSBuild arguments to create file loggers for each verbosity and to log to VSO if available
 *
 * @param {string[]} verbosities - An array of MSBuild verbosity values
 * @param {string} projectName - The name of the project
 * @param {string} loggerAssembly - The path to the assembly which defines the VSO loggers
 * @returns {string[]} An array of logger parameters
 */
function createLoggerArguments(verbosities, projectName, loggerAssembly) {
    const fileLoggerArguments = verbosities.map((verbosity, i) => {
        const [ timestampSeconds, timestampNanoseconds, ] = process.hrtime();
        return `/fileLoggerParameters${i+1}:LogFile=logs/msbuild-${projectName}-${verbosity}-${timestampSeconds}${timestampNanoseconds}.log;Verbosity=${verbosity}`;
    });

    if (!loggerAssembly) {
        return fileLoggerArguments;
    }

    return fileLoggerArguments.concat(`/dl:CentralLogger,${loggerAssembly}*ForwardingLogger,${loggerAssembly}`)
}

/**
 * Creates a stream to pipe to which calls the given resolve function after the stream has ended
 *
 * @param {function} resolve - The resolve function to call
 * @returns {Stream} The stream which will resolve the promise at the end
 */
function resolvePromise(resolve) {
    return through2.obj(
        (chunk, enc, cb) => {
            // passthrough
            cb(null, chunk);
        },
        (cb) => {
            resolve();
            cb();
        });
}

module.exports = function buildTask(project, args) {
    const developmentBuild = args.developmentBuild;
    const nugetVerbosity = args.verbose ? 'detailed' : 'normal';

    return Promise.all([ loggerAssemblyPromise, ensureLogDirectoryExists, ]).then(([ loggerAssembly, ]) =>
        new Promise((resolve, reject) =>
            gulp.src(project.solutionFilesGlobs)
                .pipe(errorHandler(args))
                .pipe(gitignoreFilter.filterStream())
                .pipe(gulpif(args.debug, debug({ title: `${project.name}-build:`, })))
                .pipe(shell([ `nuget.exe restore "<%= file.path %>" -NonInteractive -Verbosity ${nugetVerbosity}`, ]))
                .pipe(msbuild({
                    errorOnFail: true,
                    stdout: true,
                    verbosity: 'minimal',
                    logCommand: args.debug,
                    customArgs: developmentBuild ? undefined : createLoggerArguments([ 'diagnostic', 'detailed', 'normal', ], project.name, loggerAssembly),
                    targets: [ 'Build', ],
                    toolsVersion: 14.0,
                    configuration: developmentBuild ? 'Debug' : 'Release',
                }))
                .pipe(resolvePromise(resolve))
                .on('error', reject)
    ));
};
