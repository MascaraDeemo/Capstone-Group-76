/**
 * Unit Testing bizagi.workportal.desktop.widgets.project.dashboard.menu.activity.plan
 *
 * @author Elkin Fernando Siabato Cruz
 */

describe("Widget bizagi.workportal.desktop.widgets.project.dashboard.menu.activity.plan", function () {
   var widget,
      workportalFacade,
      dataService;

   it("Environment has been defined", function(){
      workportalFacade = bizagi.injector.get("workportalFacade");
      dataService = bizagi.injector.get("dataService");
   });
   it("Render Widget", function (done) {
      var params = {};
      widget = new bizagi.workportal.widgets.project.dashboard.menu.activity.plan(workportalFacade, dataService, params);
      widget.params = {};
      widget.params.contextsLeftSidebarCaseDashboard = ["ACTIVITY", "OVERVIEW", "COMMENTS", "FILES", "PROCESSMAP", "LOG", "PLANCREATE"];

      $.when(widget.areTemplatedLoaded()).done(function(){
         $.when(widget.renderContent()).done(function () {
            spyOn(widget, "sub");
            widget.postRender();

            expect(widget.sub).toHaveBeenCalled();

            done();
         });
      });
   });

   describe("functions", function(){
      describe("updateView", function(){
         beforeEach(function(){
            event = {type: "ACTIVITY"};
            params = JSON.parse('{"idCase":6452,"idWorkflow":0,"idWorkitem":11354,"idTask":9999999,"eventAsTasks":false,"onlyUserWorkItems":"true","formsRenderVersion":2,"referrer":"inboxGrid","isComplex":false,"onClose":"","isOfflineForm":false,"hasWorkItems":true,"hasGlobalForm":"false","widgetName":"projectDashboard","radNumber":"6451","menu":{"workportalFacade":{"templates":{"menu.modal.widgets":"[Unknown]","menu.modal.user":"[Unknown]","menu.modal.about":"[Unknown]","info-message":"[Unknown]","bizagi.workportal.desktop.upload.dialog":"[Unknown]","bizagi.workportal.desktop.fileupload.form":"[Unknown]","inbox-common-pagination-grid":"[Unknown]","inbox-common-pagination-inbox":"[Unknown]","inbox-common-header":"[Unknown]","inbox-common-header-folders":"[Unknown]","inbox-common-case-summary-oldrender":"[Unknown]","loadForm":"[Unknown]","print-frame":"[Unknown]","print-frame-header":"[Unknown]","render":"[Unknown]","search":"[Unknown]"},"workportal":"[Unknown]","dataService":"[Unknown]"},"dataService":"[Unknown]","resources":"[Unknown]","componentContainers":"[Unknown]","subscribers":"[Unknown]","disposed":"[Unknown]","tmpl":"[Unknown]","templatesDeferred":"[Unknown]","renderingDeferred":"[Unknown]","content":"[Unknown]","security":"[Unknown]"},"supportNav":"[Unknown]","contextsSidebarActivity":"[Unknown]","contextsWithoutLeftSidebarCaseDashboard":"[Unknown]","contextsLeftSidebarCaseDashboard":"[Unknown]","contextsWithoutRightSidebarCaseDashboard":"[Unknown]","contextsRightSidebarCaseDashboard":"[Unknown]","caseNumber":"[Unknown]","processPath":"[Unknown]","creationDate":"[Unknown]","estimatedSolutionDate":"[Unknown]","solutionDate":"[Unknown]","isOpen":"[Unknown]","idParentCase":"[Unknown]","radNumberParentCase":"[Unknown]","isFavorite":"[Unknown]","guidFavorite":"[Unknown]","parentDisplayName":"[Unknown]","canAccesToParentProcess":"[Unknown]","isDelegatedCase":"[Unknown]","isAborted":"[Unknown]","hasComments":"[Unknown]","countEvents":"[Unknown]","countSubProcesses":"[Unknown]","countAssigness":"[Unknown]","currentState":"[Unknown]","caseDescription":"[Unknown]","createdBy":"[Unknown]","idPlan":"[Unknown]","contextualized":"[Unknown]","createdByName":"[Unknown]","createdByUserName":"[Unknown]","showWorkOnIt":"[Unknown]","showEvents":"[Unknown]","showParentProcess":"[Unknown]","parentProcess":"[Unknown]","isClosed":"[Unknown]","showAssignees":"[Unknown]","showSubProcess":"[Unknown]","showForm":"[Unknown]","allowsReassign":"[Unknown]","currentStateTypes":"[Unknown]","showActivities":"[Unknown]","differenceMillisecondsServer":"[Unknown]","guidWorkItem":"[Unknown]","plan":"[Unknown]","menuDashboard":"[Unknown]","histName":"[Unknown]","level":"[Unknown]","showContextByMenuDashboard":"[Unknown]","refreshLastItemBreadcrumb":"[Unknown]","statePlan":"[Unknown]","statePendingPlan":"[Unknown]","stateExecutingPlan":"[Unknown]","contextPlanActivities":"[Unknown]","showFormAddActivityByNotFinishedAllActivities":"[Unknown]"}');
            widget.params = params;
            spyOn(widget.dataService, "getPlan").and.callFake(function(){
               var defer = $.Deferred();
               defer.resolve({"status": 201,"id":"ae980fee-ffec-4f3a-b293-80d9fd6cb2db","idPlan":"a29463c5-7e66-45a2-8b01-0b7002478a09","idActivityFrom":"757d7005-e696-4a67-bb76-c303ce8a6476","idActivityTo":"c9edc59f-79b8-4be5-994e-c7328b35281a"},{"id":"1d7370b4-61a7-4129-862d-70c428e8f51f","idPlan":"a29463c5-7e66-45a2-8b01-0b7002478a09","idActivityFrom":"c9edc59f-79b8-4be5-994e-c7328b35281a","idActivityTo":"1b801877-91df-4db8-ab2a-38a4ade3c792"});
               return defer.promise();
            });
            spyOn(widget, "pub");
         });

         it("Should be any html on widget", function(){
            spyOn(widget, "clean");
            widget.updateView(event, params);
            expect(widget.pub).toHaveBeenCalled();
         });
      });

      describe("loadContentById", function(){
         beforeEach(function(){
            spyOn(widget, "pub").and.callFake(function(params){
               return 1;
            });
         });
         it("Should be pub notify change context", function(){
            widget.params.plan = {};
            widget.params.plan.id = "ABC-2345";
            $(".ui-bizagi-wp-project-tab-links a:eq(3)", widget.getContent()).closest("li").data("context", "PLANACTIVITIES");
            $(".ui-bizagi-wp-project-tab-links a:eq(3)", widget.getContent()).click();
            expect(widget.pub).toHaveBeenCalled();
         });
      });

      describe("clean", function(){
         beforeEach(function(){
            spyOn(widget, "unsub");
         });
         it("Should be unsub events", function(){
            widget.params.contextsLeftSidebarCaseDashboard = ["ACTIVITY", "OVERVIEW", "COMMENTS", "FILES", "PROCESSMAP", "LOG", "PLANCREATE"];
            widget.clean();
            expect(widget.unsub.calls.count()).toBe(7);
         });
      });
   });
});
