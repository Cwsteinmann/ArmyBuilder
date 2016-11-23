/*eslint-env node*/
/*eslint no-console:0*/
'use strict';

module.exports = {
    /** Customize any arguments for this projects
     * @param {Array} args - The default arguments
     * @return {Array} The modified arguments
     */
    customizeArgs: (args) => {
        args.browserSync = args.browserSync || {};
        args.browserSync.proxy = args.browserSync.proxy || {};
        args.browserSync.proxy.target = 'https://testing.local';

        // args.browserSync.ui = false; // don't start the Browser Sync management UI
        // args.browserSync.proxy = false; // don't start the Browser Sync proxy (don't do anything)
        // args.browserSync.open = false; // don't open browser when starting Browser Sync
        // args.browserSync.browser = [ "google chrome", "firefox", ]; // open the site in multiple browsers
        // args.browserSync.startPath = "/About-Us"; // open Browser Sync to a specific page
        // args.browserSync.logLevel = "debug"; // show more Browser Sync info in the console
        // args.browserSync.logLevel = "warn"; // show less Browser Sync info in the console
        // args.browserSync.logLevel = "silent"; // show no Browser Sync info in the console
        // args.browserSync.logConnections = true; // show when browsers connect to Browser Sync
        // args.browserSync.logFileChanges = false; // don't show when Browser Sync notices file changes
        // args.browserSync.notify = false; // don't show Browser Sync notification in browser when files change
        // args.browserSync.files = [
        //     'Website/**/*.{js,ascx,dll}', // reload the page in the browser when files change
        //     'Website/**/*.{jpg,jpeg,png,gif,svg,webp}', // images get injected, they won't reload the page in the browser
        // ];
        /*
        args.browserSync.ghostMode = {
            clicks: false, // do not mirror clicks between different windows connected to Browser Sync
            scroll: false, // do not mirror scrolling between different windows connected to Browser Sync
            forms: false, // do not mirror form input between different windows connected to Browser Sync
        }
        */

        args.jscs = args.jscs || {};

        // args.jscs.fix = true; // automatically fix some style issues

        args.eslint = args.eslint || {};

        // args.eslint.fix = true; // automatically fix some code issues
        // args.eslint.warnFileIgnored = true; // show a warning when a JS file is ignored (for debugging gulp)

        return args;
    },

    /** Customize the projects
     * @param {Object} projects - An object with four array properties, moduleProjects, themeProjects, containerProjects, and otherProjects
     * @return {Object} The modified projects object
     */
    customizeProjects: (projects) => projects,
};
