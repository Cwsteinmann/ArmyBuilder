/*eslint-env node*/
/*eslint no-console:0*/
'use strict';

module.exports = {

    /** Customize any arguments for this projects
     * @param {Array} args - The default arguments
     * @return {Array} The modified arguments
     */
    customizeArgs: (args) => args,

    /** Customize the projects
     * @param {Object} projects - An object with three array properties, moduleProjects, themeProjects, and otherProjects
     * @return {Object} The modified projects object
     */
    customizeProjects: (projects) => projects,
};
