/*eslint-env node*/
/*eslint no-console:0*/
'use strict';

const path = require('path');
const _ = require('lodash');
const glob = require('glob');
const Project = require('./Project');
const gitignoreFilter = require('./gitignore-filter');
const configOptions = require('../gulpfile.config');

function makeProjectName(folder, projectType) {
    const folderName = path.basename(folder);
    return `${folderName}-${projectType}`;
}

function makeOtherProjectName(folder) {
    const folderName = path.basename(folder);

        let name;
        if (folderName === 'Templates') {
            name = path.basename(path.dirname(folder));
        } else {
            name = folderName;
        }

        return `${name}-templates`;
}

function makeProjectGroup(folders, projectType, makeName = makeProjectName) {
    return folders.map((folder) => new Project(makeName(folder, projectType), folder, { projectType, }));
}

module.exports = function processProjects() {
    const projectFolders = glob.sync('**/*.dnn', { nocase: true, })
        .filter(gitignoreFilter.filter)
        .map((dnnFile) => path.dirname(dnnFile));
    const folderGroups = _.groupBy(
        projectFolders,
        (folder) => (folder.includes('/DesktopModules/') && path.basename(folder) !== 'Templates'
                    ? 'modules'
                    : folder.includes('/Portals/_default/Skins/')
                        ? 'themes'
                        : 'others'));

    const moduleProjects = makeProjectGroup(folderGroups.modules || [], Project.projectTypes.module);
    const themeProjects = makeProjectGroup(folderGroups.themes || [], Project.projectTypes.theme);
    const otherProjects = makeProjectGroup(folderGroups.others || [], Project.projectTypes.other, makeOtherProjectName);

    return require('../gulpfile.user').customizeProjects(
        configOptions.customizeProjects({
            moduleProjects,
            themeProjects,
            otherProjects,
        }));
};
