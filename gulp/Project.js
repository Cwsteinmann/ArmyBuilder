/*eslint-env node*/
/*eslint no-console:0*/
'use strict';

const path = require('path');

const projectTypes = {
    module: 'module',
    theme: 'theme',
    other: 'other',
};

const Project = class Project {
    constructor(name, projectPath, options = {}) {
        this.name = name;
        this.path = projectPath;

        const isModuleTemplate = options.projectType === Project.projectTypes.module;

        this.imageExtensions = options.imageExtensions || [ 'jpg', 'gif', 'png', 'svg', ];
        this.imageFileGlobs = this.imageExtensions.map((ext) => path.join(projectPath, `**/*.${ext}`));

        const defaultStylesDirPath = isModuleTemplate ? projectPath : path.join(projectPath, 'styles/');
        this.stylesDirPath = options.stylesDirPath || defaultStylesDirPath;
        this.stylesOutputDirPath = options.stylesOutputDirPath || projectPath;
        this.lessFilesGlobs = [ path.join(this.stylesDirPath, '**/*.less'), ];
        this.lessEntryFilesGlobs = isModuleTemplate
            ? [ path.join(this.stylesDirPath, '**/module.less'), ]
            : [ path.join(this.stylesDirPath, 'skin.less'), path.join(this.stylesDirPath, 'standalone/*.less'), ];

        this.viewFilesGlobs = [ path.join(projectPath, '**/*.ascx'), ];
        this.buildFilesGlobs = [ path.join(projectPath, '**/*.build'), path.join(projectPath, '**/*.Build'), ];
        this.solutionFilesGlobs = [ path.join(projectPath, '**/*.sln'), ];

        const minifiedScriptsGlob = path.join(projectPath, '**/*.min.js');
        this.javaScriptFilesGlobs = [ path.join(projectPath, '**/*.js'), `!${minifiedScriptsGlob}`, ];
        if (options.projectType === Project.projectTypes.module) {
            const testScriptsGlob = path.join(projectPath, '*.Tests/Scripts/**/*.js');
            this.javaScriptFilesGlobs.push(`!${testScriptsGlob}`);
            const nugetScriptsGlob = path.join(projectPath, 'packages/**/*.js');
            this.javaScriptFilesGlobs.push(`!${nugetScriptsGlob}`);
        }

        this.elmEntryFilesGlobs = [ path.join(projectPath, '**/Main.elm'), ];
        this.elmFilesGlobs = [ path.join(projectPath, '**/*.elm'), ];
        this.elmTestFilesGlobs = [ path.join(projectPath, '**/NodeTestRunner.elm'), ];
    }
};

Project.projectTypes = projectTypes;

module.exports = Project;
