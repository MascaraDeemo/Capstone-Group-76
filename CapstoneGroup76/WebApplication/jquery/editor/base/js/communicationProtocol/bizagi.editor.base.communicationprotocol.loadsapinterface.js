﻿/*
*   Name: BizAgi FormModeler Editor Communication Protocol Load Interface
*   Author: Alexander Mejia
*   Comments:
*   -   This script will define basic stuff for load interface protocol
*/

bizagi.editor.base.protocol.base.extend("bizagi.editor.base.protocol.loadsapinterface", {}, {

    /*
    *   Constructor
    */
    init: function (data) {
        var self = this;

        self._super(data);
        self.interface = self.args.data.interface || self.args.data;
        self.actiontype = "LoadSapInterface";
    },

    /*
    *   Builds the request info for the protocol
    */
    buildRequest: function () {
        var self = this;

        self.parameters = [];

        if (!self.isNewExpression()) {
            self.parameters.push(self.createParameterItem("id", self.interface.baref.ref));
        }

        if (self.args.idcontextentity) {
            self.parameters.push(self.createParameterItem("idcontextentity", self.args.idcontextentity));
        }

        if (self.args.idscopedefinition) {
            self.parameters.push(self.createParameterItem("idscopedefinition", self.args.idscopedefinition));
        }
    },

    /*
    *   Check if actually exists an empty expression or not
    */
    isNewExpression: function () {
        var self = this;

        return (self.interface.baref.ref === "expression");
    },

    /*
    *   Process BAs answer to use in the modeler
    */
    processBasAnswer: function (basAnswer) {
        var self = this,
            itemParameter,
            result = basAnswer.result;

        if (result.success) {
            self.answerParameters = result.parameters;
            itemParameter = self.findKeyInParameters("id");

            if (bizagi.util.isEmpty(itemParameter.value)) { return { isEmpty: true }; }

            // Prepare result
            var displayName = (self.findKeyInParameters("displayname") && self.findKeyInParameters("displayname").value) || null;
            var property = self.args.type;
            var ruleDefinition = (property.indexOf("rule") >= 0) ? bizagi.editor.utilities.buildComplexReference(itemParameter.value, displayName) : self.buildRuleDefinition(itemParameter.value, displayName);
            return ruleDefinition;
        }
    },

    /*
    *   Builds interface complex format
    */
    buildInterfaceDefinition: function (interfaceExpression, displayName) {
        var expression = { baref: { ref: interfaceExpression} };
        if (displayName) { expression.displayName = displayName; }
        return expression;
    }

})