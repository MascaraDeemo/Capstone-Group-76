/*
 *   Name: Bizagi Workportal Desktop Project Plan Activity Subprocesses Controller
 *   Author: Elkin Fernando Siabato Cruz
 */

bizagi.workportal.widgets.widget.extend("bizagi.workportal.widgets.project.plan.activity.subprocesses", {}, {
      /*
       *   Constructor
       */
      init: function (workportalFacade, dataService, params) {
         var self = this;

         // Call base
         self._super(workportalFacade, dataService, params);

         //Load templates
         self.loadTemplates({
            "project-subprocesses": bizagi.getTemplate("bizagi.workportal.desktop.project.plan.activity.subprocesses").concat("#project-plan-activity-plan-subprocesses-wrapper"),
            "project-subprocesses-tootip-custom-properties": bizagi.getTemplate("bizagi.workportal.desktop.project.plan.activity.subprocesses").concat("#project-activity-plan-subprocesses-tooltip-custom-properties-wrapper")
         });
      },

      /*
       * Renders the template defined in the widget
       */
      renderContent: function () {
         var self = this;
         self.content = $("<div></div>");
         return self.content;
      },

      /*
       * links events with handlers
       */
      postRender: function () {
         var self = this;
      }
   }
);

bizagi.injector.register("bizagi.workportal.widgets.project.plan.activity.subprocesses", ["workportalFacade", "dataService", bizagi.workportal.widgets.project.plan.activity.subprocesses]);