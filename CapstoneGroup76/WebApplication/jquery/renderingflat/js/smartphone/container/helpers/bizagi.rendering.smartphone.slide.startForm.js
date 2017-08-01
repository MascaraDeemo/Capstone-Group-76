/*
 *   Name: BizAgi Tablet slide form implementation
 *   Author: Andres Valencia
 *   Comments:
 *   -   Serves as an slide form that can render a inner form
 */

// Extends itself
$.Class.extend("bizagi.rendering.smartphone.startForm", {}, {

    /* CONSTRUCTOR
     =====================================================*/
    init: function (dataService, renderFactory, slideFormParams) {
        var self = this;

        // Define instance variables
        self.dataService = dataService;
        self.renderFactory = renderFactory;
        self.slideFormParams = slideFormParams || {};

        // Create container    	
      /*  self.slideForm = $($.fasttmpl(self.renderFactory.getTemplate('render-slide-view'), self.slideFormParams ));
        $('#paneRender').append(self.slideForm);
        self.view = new kendo.mobile.ui.View(self.slideForm);
        self.pane = $("#paneRender").data("kendoMobilePane");
        self.scrollContent = $("#render-content", self.view.contentElement());*/
        self.slideContainer = self.slideFormParams.navigation.createRenderContainer({title : self.slideFormParams.title});
        self.configureViewHandlers();
    },

    /**
     * Handlers de la vista de kendo
     */
    configureViewHandlers: function(){
        var self = this;
        /*  $(".bz-render-back", self.slideForm).bind("click", function(){
            self.goBack();
         });*/
    },

    /**
     * go back and destroy
     */
    goBack: function(){
        var self = this;
        self.slideContainer.destroy();
        /*self.pane.navigate("#:back");
        self.view.destroy();
         self.view.element.remove();*/
    },

    /*
     *   Render the form
     *   The params are the same that will be send to the ajax service
     *   Returns a deferred
     */
    render: function (params) {
        var self = this;
        // Fill content
        self.renderSlideForm(params);
    },

    /* RENDERS slideForm
     =====================================================*/
    renderSlideForm: function (params) {

        var self = this;
        var defer = new $.Deferred();

        // Load template and data
        $.when(self.dataService.getStartForm(params)).then(function (data) {
                /*** SUCCESS FILTER **/
                // Apply editable param
            if (params.editable === false) {
                data.form.properties.editable = false;
            }

                // Render dialog template
                var formClass = bizagi.rendering.form.extend({
                submitForm: function () {
                        if(self.form) {
                            this.endLoading();
                            // Perform validations
                            if(self.form.validateForm()) {
                                // Collect data
                                var data = {};
                                self.form.collectRenderValues(data);
                                // Add page cache for this form
                                data.idPageCache = self.form.getPageCache();
                                // Call user callback
                                if(self.slideFormParams.onSave) {
                                    $.when(self.slideFormParams.onSave(data))
                                        .done(function(result) {
                                            if(result == null || result == true || result.type == "success") {
                                                defer.resolve();
                                                self.goBack();
                                            }
                                            else if(result.type == "validationMessages") {
                                                // Add validation messages
                                                self.form.addValidationMessage(result.messages);
                                                // Update original value to use as reference to other futures changes in the dialogBox
                                                $.each(data, function(key, value) {
                                                    var renders = self.form.getRenders(key);
                                                    $.each(renders, function(i, render) {
                                                        render.updateOriginalValue();
                                                    });
                                                });
                                            }
                                            else if(result.type == "error") {
                                                // Add error messages
                                                self.form.addErrorMessage(result.message);
                                            }
                                        });

                                }
                                else {
                                    defer.resolve();
                                    self.goBack();
                                }
                            }
                        }
                    }
                });

            var containerParams = $.extend({ type: "form", data: data.form, navigation: self.slideFormParams.navigation  }, {
                    renderFactory: self.renderFactory,
                    dataService: self.renderFactory.dataService
                });
                self.form = new formClass(containerParams);
                // Attach a refresh handler to recreate all the form
                self.form.bind("refresh", function(_, refreshParams) {
                    refreshParams = $.extend({
                        selectedTabs: self.form.getSelectedTabs(),
                        isRefresh: true
                    }, params, refreshParams, {idStartScope : self.form.properties.idStartScope});

                self.renderSlideForm(refreshParams);
                });
                // Return rendering promise
                return self.form.render();
        }).done(function (element) {
            var saveButtonLabel = (self.slideFormParams.saveButtonLabel ? self.slideFormParams.saveButtonLabel : bizagi.localization.getResource("render-form-dialog-box-save"));
            var cancelButtonLabel = bizagi.localization.getResource("render-form-dialog-box-cancel");
            // Append form  in the view
            self.slideContainer.element.html(element);

            if (!params.isRefresh){
                self.slideFormParams.navigation.navigate(self.slideContainer.id);
            }

            $(".ui-bizagi-button-container div", self.form.container).remove();

            $(".ui-bizagi-button-container", self.form.container).append("<div ordinal='0' id='formButton0' class='action-button ui-bizagi-form-button'>" + saveButtonLabel + "</div>").delegate("div[ordinal='0']", "click", function(){
                self.form.submitForm();
            });

            $(".ui-bizagi-button-container", self.form.container).append("<div ordinal='1' id='formButton1' class='action-button ui-bizagi-form-button'>" + cancelButtonLabel + "</div>").delegate("div[ordinal='1']", "click", function(){
                self.slideFormParams.onCancel && self.slideFormParams.onCancel();
                self.goBack();
            });
            //self.view.scroller.reset();
            // Publish an event to check if the form has been set in the DOM
            self.form.triggerHandler("ondomincluded");
        }).fail(function (xhr, errorType, message) {
            /*** FAIL FILTER **/
            var errorTemplate = self.renderFactory.getCommonTemplate("form-error");
            var error_message = message.message || "Error";

            $.tmpl(errorTemplate, {message: error_message}).appendTo(self.slideContainer.element);
            // Navigate on view
            self.slideFormParams.navigation.navigate(self.slideContainer.id);
            });

        return defer.promise();
    }
});