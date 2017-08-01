/**
 * Unit Testing bizagi.workportal.widgets.project.plan.activity.subprocesses
 *
 * @author Elkin Fernando Siabato Cruz
 */

describe("Widget bizagi.workportal.widgets.project.plan.activity.subprocesses", function () {
   var widget,
      workportalFacade,
      dataService;

   it("Environment has been defined", function(){
      workportalFacade = bizagi.injector.get("workportalFacade");
      dataService = bizagi.injector.get("dataService");
   });

   it("Render Widget", function (done) {
      var params = {};
      widget = bizagi.injector.get("bizagi.workportal.widgets.project.plan.activity.subprocesses");
      widget.init(dependencies.workportalFacade, dependencies.dataService, params);

      $.when(widget.areTemplatedLoaded()).done(function(){
         $.when(widget.renderContent()).done(function () {
            widget.postRender();
            done();
         });
      });
   });

   describe("Functions:", function () {

   });
});
