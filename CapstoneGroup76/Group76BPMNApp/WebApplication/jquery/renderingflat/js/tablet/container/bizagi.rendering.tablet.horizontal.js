﻿/*
*   Name: BizAgi Tablet Horizontal Container Extension
*   Author: Diego Parra
*   Comments:
*   -   This script will redefine the horizontal container class to adjust to tablet devices
*/

// Auto extend
bizagi.rendering.horizontal.extend("bizagi.rendering.horizontal", {}, {
    // TODO: Review Scenario
    /*
    postRenderContainer: function(container) {
        var self = this;
        var children = self.children;
        var iCount = children.length;

        // Call base
        self._super(container);

        //console.log("bizagi.rendering.horizontal: " + iCount);

        // Process each child
        $.each(children, function(i, child) {
            // Process width
            var renderWidth = child.properties.width;
            if (renderWidth == null || renderWidth.length == 0) {
                // Set default size
                renderWidth = 100;
                // renderWidth = 100 / iCount;
            } else {
                // Set custom size
                renderWidth = bizagi.util.percent2Number(renderWidth);
            }

            // Set width
            if (i != (iCount - 1)) {
                child.getRenderedElement().css({ width: renderWidth + "%" });
            } else {
                // Set class for last render
                child.getRenderedElement().addClass("ui-bizagi-render-last");
                child.getRenderedElement().css({ width: (renderWidth - 3.3) + "%" });
            }
        });
    }
    */
});
