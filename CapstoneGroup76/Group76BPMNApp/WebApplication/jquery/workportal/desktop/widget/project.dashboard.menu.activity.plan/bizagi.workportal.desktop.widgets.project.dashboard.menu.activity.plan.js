/*
 *   Name: Bizagi Workportal project Dashboard Menu Activity Plan
 *   Author: Elkin Fernando Siabato Cruz
 */

bizagi.workportal.widgets.widget.extend("bizagi.workportal.widgets.project.dashboard.menu.activity.plan", {}, {

   /**
    *   Constructor
    */
   init: function (workportalFacade, dataService, params) {
      var self = this;
      self.params = params || {};

      // Call base
      self._super(workportalFacade, dataService, params);

      //Load templates
      self.loadTemplates({
         "project-dashboard-menu": bizagi.getTemplate("bizagi.workportal.desktop.widgets.project.dashboard.menu.activity.plan").concat("#project-dashboard-menu2")
      });
   },

   /**
    * Renders the template defined in the widget
    */
   renderContent: function () {
      var self = this;
      self.content = $("<div></div>");
      return self.content;
   },

   /**
    * links events with handlers
    */
   postRender: function () {
      var self = this;
      //Handlers
      self.params.contextsLeftSidebarCaseDashboard.forEach(function(context){
         self.sub(context, $.proxy(self.updateView, self));
      });

   },

   /**
    * Update view
    * @param event
    * @param params
    */
   updateView: function (event, params) {
      var self = this;
      self.params = $.extend(self.params, params.args);
      self.clean();
      var $content = self.getContent().empty();

      var argsTemplate = {
         showFormOverview: self.params.menuDashboard.showFormOverview,
         showFormActivity: self.params.menuDashboard.showFormActivity,
         showCommentsOptionMenu: self.params.menuDashboard.showCommentsOptionMenu,
         showFilesOptionMenu: self.params.menuDashboard.showFilesOptionMenu,
         showTimeLineOptionMenu: self.params.menuDashboard.showTimeLineOptionMenu,
         showPlanOptionMenu: self.params.menuDashboard.showPlanOptionMenu,
         contextPlanOptionMenu: self.params.menuDashboard.contextPlanOptionMenu,
         contextFormActivityOptionMenu: self.params.menuDashboard.contextFormActivityOptionMenu,
         contextualized: self.params.plan.contextualized
      };

      //Update widget
      var template = self.getTemplate("project-dashboard-menu");
      template.render(argsTemplate).appendTo($content);

      if(self.params.showContextByMenuDashboard){
         $("li[data-context='" + event.type.toUpperCase() + "']", self.content).addClass("active").siblings().removeClass("active");
      }

      self.handlerEvents();

      var paramsGetPlan = {idPlan: self.params.plan.id};
      $.when(self.callGetPlan(paramsGetPlan)).then(function(responsePlan){
         $.extend(self.params.plan, responsePlan);
         self.pub("notify", {
            type: "LOAD_INFO_PLAN",
            args: self.params
         });
      });
   },   

   /**
    *   Load Content By Id
    */
   loadContentById: function (event) {
      var self = this;
      event.preventDefault();
      var $item = $(event.target).closest("li");

      if (!$item.hasClass("active")) {
         $.when(bizagi.util.autoSave()).done(function () {
            $(document).data('auto-save', '');

            var showContextByMenuDashboard = $item.data("context");
            if (showContextByMenuDashboard) {
               var getLevelNavigator = self.pub("notify", { type: "NAVIGATOR_GETLEVEL"});
               var currentLevelNavigator = parseInt(getLevelNavigator[0]);
               var nameItemNavigator = "";
               var newLevelNavigator = currentLevelNavigator;

               if(showContextByMenuDashboard ==="PLANACTIVITIES"){
                  newLevelNavigator = currentLevelNavigator + 1;
                  nameItemNavigator = bizagi.localization.getResource("workportal-project-casedashboard-plan");
                  self.params.planParent = {};
                  self.params.planParent.id = bizagi.clone(self.params.plan.id);
                  self.params.planParent.idActivitySelected = self.params.plan.idActivitySelected;
               }

               self.params.refreshLastItemBreadcrumb = false;
               self.pub("notify", {
                  type: showContextByMenuDashboard.toUpperCase(),
                  args: $.extend(self.params,{showContextByMenuDashboard: showContextByMenuDashboard,
                     histName: nameItemNavigator,
                     level: newLevelNavigator})
               });
               $("li[data-context='" + self.params.showContextByMenuDashboard.toUpperCase() + "']", self.content).addClass("active").siblings().removeClass("active");
            }
         });
      }
   },

   /**
    * Call services
    */

   callGetPlan: function(params){
      var self = this;
      var defer = $.Deferred();
      self.dataService.getPlan(params).always(function (response) {
         if (response.status === 200 || response.status === 201 || response.status === undefined) {
            defer.resolve(response);
         }
         else {
            defer.reject();
         }
      });

      return defer.promise();
   },

   subMenuHandler: function () {
       var self = this;
       var content = self.getContent();
       var $comments = $("[data-context='ACTIVITYPLANCOMMENTS']", content);
       var $files = $("[data-context='ACTIVITYPLANFILES']", content);
       var $timeline = $("[data-context='ACTIVITYPLANTIMELINE']", content);

       $(".ui-bizagi-wp-project-tab-submenu a", content).on("click", function () {
           $comments.toggle();
           $files.toggle();
           $timeline.toggle();
       });
   },

   /**
    * Handler events
    */
   handlerEvents: function(){
      var self = this;
      var content = self.getContent();
      self.subMenuHandler();
      $(".ui-bizagi-wp-project-tab-links a", content).on("click",  $.proxy(self.loadContentById, self));
   },

   /**
    * Clean widgets and events
    */
   clean: function(){
      var self = this;
      var content = self.getContent();

      if(self.params && self.params.contextsLeftSidebarCaseDashboard){
         self.params.contextsLeftSidebarCaseDashboard.forEach(function(context){
            self.unsub(context, $.proxy(self.updateView, self));
         });
      }

      $(".ui-bizagi-wp-project-tab-links a", content).off();
   }

});

bizagi.injector.register("bizagi.workportal.widgets.project.dashboard.menu.activity.plan", ["workportalFacade", "dataService", bizagi.workportal.widgets.project.dashboard.menu.activity.plan], true);