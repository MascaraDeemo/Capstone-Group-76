/**
*   Name: BizAgi Workportal Desktop Async Widget Controller
*   Author: Edward Morales
*   Comments:
*   -   This script will define a asyncronous activities
*/

// Auto extend
bizagi.workportal.widgets.async.extend("bizagi.workportal.widgets.async", {}, {
    init: function(workportalFacade, dataService, params) {
        var self = this;

        // Call base
        self._super(workportalFacade, dataService, params);

        //Load templates
        self.loadTemplates({
            "async": bizagi.getTemplate("bizagi.workportal.desktop.widget.async"),
            useNewEngine: false
        });
    },

    /**
    *   To be overriden in each device to apply layouts
    */
    postRender: function() {
        var self = this;
        var content = self.getContent();

        // Bind inbox click link
        $(".ui-bizagi-wp-async-goToInbox a", content).click(function() {
            self.publish("changeWidget", {
                widgetName: bizagi.workportal.currentInboxView
            });
        });
    }
});
