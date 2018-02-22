/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    //ckfinder
    config.filebrowserBrowseUrl =       '/Plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl =  '/Plugins/ckfinder/ckfinder.html?Type=Images';
    //config.filebrowserFlashBrowseUrl =  '/Plugins/ckfinder/ckfinder.html?Type=Flash';
    //config.filebrowserUploadUrl =       '/Plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl =  '/Plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';

    //// Define changes to default configuration here.
    //// For complete reference see:
    //// http://docs.ckeditor.com/#!/api/CKEDITOR.config

    //// The toolbar groups arrangement, optimized for two toolbar rows.
    //config.toolbarGroups = [
    //    { name: 'clipboard', groups: ['clipboard', 'undo'] },
    //    { name: 'editing', groups: ['find', 'selection', 'spellchecker'] },
    //    { name: 'links' },
    //    { name: 'insert' },
    //    { name: 'forms' },
    //    { name: 'tools' },
    //    { name: 'document', groups: ['mode', 'document', 'doctools'] },
    //    { name: 'others' },
    //    '/',
    //    { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
    //    { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] },
    //    { name: 'styles' },
    //    { name: 'colors' },
    //    { name: 'about' }
    //];

    //// Remove some buttons provided by the standard plugins, which are
    //// not needed in the Standard(s) toolbar.
    //config.removeButtons = 'Underline,Subscript,Superscript';

    //// Set the most common block elements.
    //config.format_tags = 'p;h1;h2;h3;pre';

    //// Simplify the dialog windows.
    //config.removeDialogTabs = 'image:advanced;link:advanced';

    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.allowedContent = true; //disable CKEditor XSS prevention, we will filter on backend
    config.removeButtons = 'About,Scayt,Language,Font,Format'; //remove About button
    config.removePlugins = 'autoembed,embed'; //use comma sperator between plugins need disable
    config.fontSize_sizes = '8/8px;9/9px;10/10px;11/11px;12/12px;14/14px;16/16px;18/18px;20/20px;22/22px;';
    config.youtube_width = '640';
    config.youtube_height = '360';

    //autosave
    config.autosave = {
        // Auto save Key - The Default autosavekey can be overridden from the config ...
        Savekey: "sodizAutoSaveKey",

        // Ignore Content older then X
        //The Default Minutes (Default is 1440 which is one day) after the auto saved content is ignored can be overidden from the config ...
        NotOlderThen: 1440,

        // Save Content on Destroy - Setting to Save content on editor destroy (Default is false) ...
        saveOnDestroy: true,

        // Setting to set the Save button to inform the plugin when the content is saved by the user and doesn't need to be stored temporary ...
        //saveDetectionSelectors : "a[href^='javascript:__doPostBack'][id*='Save'],a[id*='Cancel']",

        // Notification Type - Setting to set the if you want to show the "Auto Saved" message, and if yes you can show as Notification or as Message in the Status bar (Default is "notification")
        //messageType : "notification",

        // Show in the Status Bar
        messageType: "statusbar",

        // Show no Message
        //messageType : "no",

        // Delay
        delay: 10,

        // The Default Diff Type for the Compare Dialog, you can choose between "sideBySide" or "inline". Default is "sideBySide"
        //diffType : "sideBySide"     
        diffType: "inline"
    };

};
