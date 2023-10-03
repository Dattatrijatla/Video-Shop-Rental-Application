/*
 * This file launches the application by asking Ext JS to create
 * and launch() the Application class.
 */
Ext.application({
    extend: 'MovieAPP.Application',

    name: 'MovieAPP',

    requires: [
        // This will automatically load all classes in the MovieAPP namespace
        // so that application classes do not need to require each other.
        'MovieAPP.*'
    ],

    // The name of the initial view to create.
    mainView: 'MovieAPP.view.main.Main'
});
