/**
 * Unit Testing bizagi.workportal.desktop.widgets.project.dashboard.menu.activity
 *
 * @author Elkin Fernando Siabato Cruz
 */

describe("Widget bizagi.workportal.desktop.widgets.project.dashboard.menu.activity", function () {
   var widget,
      workportalFacade,
      dataService;

   it("Environment has been defined", function(){
      workportalFacade = bizagi.injector.get("workportalFacade");
      dataService = bizagi.injector.get("dataService");
   });
   it("Render Widget", function (done) {
      var params = {};
      widget = new bizagi.workportal.widgets.project.dashboard.menu.activity(workportalFacade, dataService, params);

      widget.params.contextsLeftSidebarCaseDashboard = ["ACTIVITY", "OVERVIEW", "COMMENTS", "FILES", "PROCESSMAP", "LOG", "PLANCREATE"];

      $.when(widget.areTemplatedLoaded()).done(function(){
         $.when(widget.renderContent()).done(function () {
            widget.postRender();
            done();
         });
      });
   });

   describe("functions", function(){
      describe("updateView", function(){
         beforeEach(function(){
            event = {type: "ACTIVITY"};
            params = JSON.parse('{"context":"ACTIVITY","data":{"widgets":{"leftSidebar":{"layout":"leftsidebar","name":"bizagi.workportal.widgets.left.sidebar"},"menu":{"layout":"leftSidebar","name":"bizagi.workportal.widgets.project.dashboard.menu.activity","canvas":"contentsidebar"},"navigator":{"layout":"navigator","name":"bizagi.workportal.widgets.navigator","refresh":false},"contentDashboard":{"layout":"content","name":"bizagi.workportal.widgets.project.content.dashboard"},"activity":{"layout":"contentDashboard","name":"bizagi.workportal.widgets.project.activity","canvas":"contentprincipal"},"rightSidebar":{"layout":"contentrightsidebar","name":"bizagi.workportal.widgets.right.sidebar"},"caseState":{"layout":"rightSidebar","name":"bizagi.workportal.widgets.project.caseState","canvas":"sidebarcontent1"},"activityState":"[Unknown]","processState":"[Unknown]","users":"[Unknown]","events":"[Unknown]","subprocesses":"[Unknown]"},"nav":"[Unknown]","belongs":"[Unknown]","level":"[Unknown]"},"args":"[Unknown]"}');
            params.args = JSON.parse('{"idCase":6451,"idWorkflow":3,"idWorkitem":11352,"idTask":5,"eventAsTasks":false,"onlyUserWorkItems":"true","formsRenderVersion":2,"referrer":"inboxGrid","isComplex":false,"onClose":"","isOfflineForm":false,"hasWorkItems":true,"hasGlobalForm":"false","widgetName":"projectDashboard","radNumber":"6451","menu":{"workportalFacade":{"templates":{"menu.modal.widgets":"[Unknown]","menu.modal.user":"[Unknown]","menu.modal.about":"[Unknown]","info-message":"[Unknown]","bizagi.workportal.desktop.upload.dialog":"[Unknown]","bizagi.workportal.desktop.fileupload.form":"[Unknown]","inbox-common-pagination-grid":"[Unknown]","inbox-common-pagination-inbox":"[Unknown]","inbox-common-header":"[Unknown]","inbox-common-header-folders":"[Unknown]","inbox-common-case-summary-oldrender":"[Unknown]","loadForm":"[Unknown]","print-frame":"[Unknown]","print-frame-header":"[Unknown]","render":"[Unknown]","search":"[Unknown]"},"workportal":"[Unknown]","dataService":"[Unknown]"},"dataService":"[Unknown]","resources":"[Unknown]","componentContainers":"[Unknown]","subscribers":"[Unknown]","disposed":"[Unknown]","tmpl":"[Unknown]","templatesDeferred":"[Unknown]","renderingDeferred":"[Unknown]","content":"[Unknown]","security":"[Unknown]"},"supportNav":"[Unknown]","contextsSidebarActivity":"[Unknown]","contextsWithoutLeftSidebarCaseDashboard":"[Unknown]","contextsLeftSidebarCaseDashboard":"[Unknown]","contextsWithoutRightSidebarCaseDashboard":"[Unknown]","contextsRightSidebarCaseDashboard":"[Unknown]","caseNumber":"[Unknown]","process":"[Unknown]","processPath":"[Unknown]","creationDate":"[Unknown]","estimatedSolutionDate":"[Unknown]","solutionDate":"[Unknown]","isOpen":"[Unknown]","idParentCase":"[Unknown]","radNumberParentCase":"[Unknown]","isFavorite":"[Unknown]","guidFavorite":"[Unknown]","parentDisplayName":"[Unknown]","canAccesToParentProcess":"[Unknown]","isDelegatedCase":"[Unknown]","isAborted":"[Unknown]","hasComments":"[Unknown]","countEvents":"[Unknown]","countSubProcesses":"[Unknown]","countAssigness":"[Unknown]","helpUrl":"[Unknown]","currentState":"[Unknown]","caseDescription":"[Unknown]","createdBy":"[Unknown]","contextualized":"[Unknown]","createdByName":"[Unknown]","createdByUserName":"[Unknown]","showWorkOnIt":"[Unknown]","showEvents":"[Unknown]","showParentProcess":"[Unknown]","parentProcess":"[Unknown]","isClosed":"[Unknown]","showAssignees":"[Unknown]","showSubProcess":"[Unknown]","showForm":"[Unknown]","allowsReassign":"[Unknown]","currentStateTypes":"[Unknown]","showActivities":"[Unknown]","differenceMillisecondsServer":"[Unknown]","plan":"[Unknown]","guidWorkItem":"[Unknown]","planChild":"[Unknown]","menuDashboard":{"showFormActivity": true},"histName":"[Unknown]","level":"[Unknown]","showContextByMenuDashboard":"[Unknown]"}');
            widget.params = params;

         });

         it("Should be any html on widget", function(){
            spyOn(widget, "clean");
            widget.updateView(event, params);
            $(".ui-bizagi-refresh-form", widget.getContent()).click();
         });


      });
      describe("updateView", function(){
         beforeEach(function(){
            spyOn(widget, "pub").and.callFake(function(params){
               return 1;
            });
         });
         it("Should be pub notify change context", function(){
            $(".ui-bizagi-wp-project-tab-links a:eq(2)", widget.getContent()).click();
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
