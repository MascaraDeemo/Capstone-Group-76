


/* Plugin BizRep_Count_Summary_Single. 
 * Draws the Counter Summary report for the selected counter only.
 
 * - The PluginTemplateFileName and ReportName params are modified, then BizRep_Count_Summary_Single plugin is applied

 * Use:
   ----
 * 1- Create an options object to customize behavior: ReportResult, ReportTemplatesDir, FlashChartsDir, HoursDay 
 * 2- Apply plugin passing the options object      e.g: $(selector).BizRep_Count_Summary_Single(myOptions);
 
 */

(function($){   
  
    /* File name to get report html template */        
    var PLUGIN_TEMPLATE_FILE = "Rep_Tpt_CounterSummary.aspx?single=1";

    /* Report name to be shown in error messages" */
    var PLUGIN_NAME = "Count_Summary_Single";


    $.fn.extend({    
           
        
        BizRep_Count_Summary_Single: function(options) {   
            
            //Set default values
            var defaults = { 
                    ReportResult : null,
                    ReportTemplatesDir : './ReportTemplates',
                    FlashChartDir : './Charts',
                    HoursDay : 8,
                    PluginTemplateFileName: PLUGIN_TEMPLATE_FILE,
                    PluginName: PLUGIN_NAME
                };   
            

            var options =  $.extend(defaults, options);   

            return $(this).BizRep_Count_Summary(options);
        }   
    });   
       
})(jQuery);  

