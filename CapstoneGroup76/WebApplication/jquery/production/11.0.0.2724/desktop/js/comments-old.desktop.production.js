bizagi.workportal.comments={renderComments:function(n){var t=this,s={},i="",h=new $.Deferred,u={},f=-1,e=bizagi.currentUser.idUser,c=n.canvas,r=n.readOnly||!1,o;return t.setStorage("bufferLocalNewComments_"+n.caseNumber,0),t.setStorage("idCase",n.caseNumber),t.comments=t.workportalFacade.getTemplate("comments"),t.commentsList=t.workportalFacade.getTemplate("comments-list"),t.commentsReplies=t.workportalFacade.getTemplate("comments-replies"),t.commentsDropdown=t.workportalFacade.getTemplate("comments-dropdown"),t.commentsConfirm=t.workportalFacade.getTemplate("comments-confirm"),n.showComments=!0,o=function(i){u=i.comments;t.setStorage("maxIdComment_"+n.caseNumber,i.maxIdComment);t.setStorage("bufferLocalNewComments_"+n.caseNumber,0)},$.when(t.getComments({idCase:n.caseNumber},o)).done(function(l){function y(){$(".categories-dropdownmenu").empty();$(".categories-dropdownmenu").data("visible",!1)}var a=l.users||[],v=function(n){var t="";switch(n){case 0:t="orange";break;case 1:t="red";break;case 2:t="yellow";break;case 3:t="blue";break;case 4:t="purple";break;case 5:t="green";break;default:t="disable"}return t},ot=function(n){$(n).children("li:not(:last)").slideDown("fast")},it=function(n){$(n).children("li:not(:last)").slideUp("fast");$("span.reply-toggler > span",n.parent()).removeClass("expanded")},rt=function(n){var i=$(".reply-list li",n)||[],t=$(".reply-toggler",n);i.length>1?t.removeClass("hidden"):t.addClass("hidden")},k=function(n){return $.timeago(new Date(n))},d=function(n){var t="";return $.each(a,function(i,r){a[i].Id==n&&(t=r.Picture)}),t},g=function(n){var t="";return $.each(a,function(i,r){a[i].Id==n&&(t=r.DisplayName)}),t},nt=function(){$(".comments-text-box").removeClass("comments-reply-box");$(".comments-text-box li:first-child").data("reply-mode","");$(".comments-text-box li:first-child").data("id","")},vt=function(n){var t=0;$.each(n.comments,function(n,i){t+=i.Replies.length})},st=function(i,f){return u.totalRecords=i.totalRecords,a=f,$.tmpl(t.comments,{comments:i.comments,readOnly:r,User:a,idCase:n.caseNumber,CurrentUser:e,RelatedElementId:null,getCategoryColor:v,replaceTextToSmiles:t.replaceTextToSmiles,timeAgo:k,getUserPicture:d,getUserName:g,getCategoryName:function(n){return t.resources.getResource("workportal-widget-comments-"+n)}})},tt=function(n,i){return u.totalRecords=l.totalRecords,a=i,ut({totalPages:n.totalPages,actualPage:n.actualPage}),$.tmpl(t.commentsList,{comments:n.comments,User:a,CurrentUser:e,RelatedElementId:null,getCategoryColor:v,replaceTextToSmiles:t.replaceTextToSmiles,timeAgo:k,getUserPicture:d,getUserName:g,readOnly:r})},ht=function(n,i){return u.totalRecords=l.totalRecords,a=i,$.tmpl(t.commentsReplies,{Replies:n.Replies,User:a,CurrentUser:e,RelatedElementId:null,getCategoryColor:v,replaceTextToSmiles:t.replaceTextToSmiles,timeAgo:k,getUserPicture:d,getUserName:g,readOnly:r})},ct=function(n){return $.tmpl(t.commentsDropdown,{categories:n.categories,css:n.css,idComment:n.idComment,getCategoryColor:v,readOnly:r})},ut=function(i,r){var o=i.totalPages||1,h=o>1?!0:!1,c=5,v=i.actualPage||1,e=$(".comments-pagination")||r,u={},l,s,a;for(u.pagination=h,u.totalPages=o,u.pages=[],u.page=v,e.empty(),h?e.show():e.hide(),l=c>o?o:c,s=1;s<=l;s++)u.pages.push({pageNumber:s});a=$.tmpl(t.paginationTemplate,u).html();$(e).append(a);$("ul").bizagiPagination({totalPages:u.totalPages,actualPage:u.page,listElement:$("ul",e),clickCallBack:function(i){$.when(t.getComments({idCase:n.caseNumber,idColorCategory:f,pag:i.page})).done(function(n){ft(n,n.users,!0)})}})},ft=function(n,t){return u.totalRecords=n.totalRecords,$("#comment-list").empty(),i=tt(n,t),i.appendTo($("#comment-list")),s.subprocess=$("#comment-list"),p(),i},et,w,p;r||bizagi.util.setInterval({name:"comments",params:{idCase:bizagi.context.idCase},singleton:!0,timeout:3e4,killWhenExitContext:!1,context:'(bizagi.context.widget=="'+t.getWidgetName()+'" && bizagi.context.idCase == "'+n.caseNumber+'" && bizagi.context.commentsFocus)',call:function(n){n=n||{};var i=t.getStorage("maxIdComment_"+n.idCase);$.when(t.dataService.getNewComments({idCase:n.idCase,idLastComment:i})).done(function(i){if(i.newComments>0||i.newReplies>0){var r=i.newComments+i.newReplies,u=t.getStorage("bufferLocalNewComments_"+n.idCase)||r,f=$(".comments-update").data("message").replace(/{totalNewComments}/,r-u);r>u&&($(".comments-update").text(f),$(".comments-update").show().click(function(n){n.isPropagationStopped()||(n.stopPropagation(),$("#filterClear").click())}))}})}});i=st(l,a);$(".comment-frame .button-category",i).tooltip();$(i).find("*").off("click");$(".button-refresh",i).click(function(){$(".comments-update").hide();$.when(t.getComments({idCase:n.caseNumber,idColorCategory:f},o)).done(function(n){var t=n.users||[];$("#comment-list").empty();i=ft(n,t);i.appendTo($("#comment-list"));s.subprocess=$("#comment-list");p()})});$(".make-new-comments",i).click(function(){nt();$(".comments-text-box li:first-child").slideDown("fast");$(".comment-box",i).focus().fadeIn();$(this).hide();$(".action-buttons").show().slideDown("fast");$(".text-to-reply").hide()});$(".comment-box",i).blur(function(){var n=$(".comments-text-box textarea").val();n.length==0&&($(".comments-text-box textarea").val(""),$(".comments-text-box li:first-child").slideUp("fast"),$(".make-new-comments").fadeIn(),$(".action-buttons").hide(),nt())});$(".send-new-comments",i).click(function(){var r=$(".comments-text-box textarea").val(),u,i;r.length!=0&&($(".comments-text-box li:first-child").data("reply-mode")=="true"?(u=$(".comments-text-box li:first-child").data("id"),i=$("li[data-id='"+u+"']"),$.when(t.dataService.makeNewReply({idCase:n.caseNumber,idComment:u,comment:r})).done(function(r){t.incrementStorage("bufferLocalNewComments_"+n.caseNumber,1);var u=ht(r,r.users);$(".reply-list",i).append(u);$(".reply-list li:last",i).show("highlight","slow");it($(".reply-list",i));rt($(i))})):$.when(t.dataService.makeNewComment({idCase:n.caseNumber,comment:r})).done(function(i){t.incrementStorage("bufferLocalNewComments_"+n.caseNumber,1);var r=tt(i,i.users);$(".reply-toggler",r).addClass("hidden");$("#comment-list").prepend(r);$("#comment-list li:first").show("highlight","fast")}),$(".comments-text-box li:first-child").slideUp("fast"),$(".make-new-comments").show(),$(".action-buttons").hide(),$(".comments-text-box textarea").val(""),$(".time-ago").timeago(),nt())});et=function(){var t=$(this),n=t.parent(),i=n.text().replace(/^\s+|\s+$/g,""),r=t.siblings("a").children("span").attr("class").split(" ")[1],u=n.html(),f='<input type="text" class="editBox" value="'+i+'" /> <span class="filter-icon-ctrl btnSave"><\/span> <span class="filter-icon-ctrl btnDiscard"><\/span>';n.attr("data-old-icon",r);n.html(f).attr("data-old-text",u).addClass("no-pad");$(".editBox").select()};$(i).delegate(".editBox","keypress",function(n){n.keyCode==13&&$(this).parent().find(".btnSave").click()});$(i).delegate(".btnSave","click",function(){var n=$(this).parent(),f=n.attr("data-old-icon"),u=n.attr("data-old-text"),r=$(this).siblings(".editBox").val(),e=n.html(u).find("a span.filter-icon"),o=$("#filterText").attr("class"),s=$("#filterText").hasClass("disable");s||f!==o||($("#filterText",i).text(r),$(".filter-dropdown").removeClass("is-visible").addClass("is-hidden"));n.removeAttr("data-old-text").html(u).find("a").empty().append(e,r).removeClass("no-pad");t.dataService.renameCommentCategory({idColorCategory:n.data("category-id"),colorName:r})});$(i).delegate(".btnDiscard","click",function(){for(var i=$(this).parent(),u=i.length,n=0,t,r;n<u;n++)t=i[n],r=$(t).attr("data-old-text"),$(t).removeAttr("data-old-text").html(r).removeClass("no-pad")});w=function(n){var i=$(".categories-dropdownmenu"),r=n.referer||$(),u=n.css||"",f=n.idComment||"",e=n.position||{my:"right top",at:"right top",collision:"fit",of:r.selector||r};i.data("name")!=n.name?(y(),i.data("name",n.name||""),w(n)):i.data("visible")?y():$.when(t.dataService.getCommentsCategories()).done(function(t){i.empty();i.position(e);ct({categories:t.categories,css:u,idComment:f,referer:r}).appendTo(i);i.data("visible",!0);i.data("name",n.name||"")})};$("#buttonFilter",i).bind("click",function(){var t=this,n={referer:$("#buttonFilter",i),name:"editCategories",css:"editCategories"};r&&(n.position={my:"left bottom",at:"left bottom",collision:"fit",of:t});w(n)});var b=function(){return $(".comment-controls").data("idcase")},lt=function(n){var r;if(!n.isPropagationStopped()){var i=$(this).parent().data("category-id"),u=$(".categories-dropdownmenu").data("name"),e=bizagi.util.trim($(this).text());u=="setCategories"?(r=$(this).data("idcomment"),$.when(t.dataService.setCommentCategory({idCase:b,idColorCategory:i,idComment:r})).done(function(){$("#"+r).removeClass();$("#"+r).addClass("button-category");$("#"+r).addClass(v(i));y()})):$.when(t.dataService.getComments({idCase:b,idColorCategory:i})).done(function(n){var t=$(".comment-filter > #buttonFilter");i>=0?(f=i,$(".button-refresh").data("category-id",i),$("#filterName").removeClass("is-hidden"),$("#filterText").text(e)):($("#filterName").addClass("is-hidden"),$("#filterText").text(""),f=-1);$("#comment-list").empty();$("#comment-list").append(tt(n,n.users));t.removeClass();t.addClass("button-category "+v(i));y();$(".button-refresh").data("category-id",i);p();$(".button-refresh").click()});n.stopPropagation()}},at=function(){$("#filterClear").bind("click",function(n){n.isPropagationStopped()||(n.stopPropagation(),f=-1,$(".comment-filter > #buttonFilter").removeClass(),$(".comment-filter > #buttonFilter").addClass("button-category "+v()),$(".button-refresh").data("category-id",""),$("#filterName").addClass("is-hidden"),$("#filterText").text(""),$(".button-refresh").click())})};if($(i).delegate(".close","click",y),$(i).delegate(".btnEdit","click",et),$(i).delegate(".filter-category","click",lt),$(i).delegate("#filterClear","click",at),!r){$(i).on("click",".button-category[data-own='true']",function(n){if(!r&&!n.isPropagationStopped()){n.stopPropagation();var t=this;w({referer:t,name:"setCategories",css:"setCategories",idComment:$(t).data("id"),position:{my:"right top",at:"left bottom",collision:"fit",of:t}})}});$(i).on("click",".button-reply",function(n){if(!n.isPropagationStopped()){var t=$(this).data("id"),i=$("li[data-id='"+t+"'] .comment-text").first().text();$(".comments-text-box li:first-child").data("reply-mode","true");$(".comments-text-box li:first-child").data("id",t);$(".text-to-reply").text(i);$(".text-to-reply").show();$(".comments-text-box textarea").focus();$(".comments-text-box").addClass("comments-reply-box");$(".comments-text-box li:first-child").show().slideDown("fast");$(".make-new-comments").hide();$(".action-buttons").show().slideDown("fast");n.stopPropagation()}});$(i).on("click",".button-delete",function(){var i=$(this).parents("li:first"),r=$(this).data("id"),n=i.parent();$.tmpl(t.commentsConfirm).dialog({resizable:!0,modal:!0,title:t.getResource("workportal-widget-comments-title"),buttons:[{text:t.getResource("workportal-widget-comments-delete"),click:function(){var f,u;n.hasClass("reply-list")?(f=i.parents("li:first").data("id"),$.when(t.dataService.removeReply({idCase:b,idComment:f,idReply:r}).done(function(n){u(n)}))):$.when(t.dataService.removeComment({idCase:b,idComment:r}).done(function(n){u(n)}));u=function(t){t.action?$.when(i.hide("highlight","fast")).done(function(){i.remove();n.hasClass("reply-list")&&(n.find("li").hide(),n.find("li:last").show(),rt(n.parents("li:first")))}):alert(t.message)};$(this).dialog("close");bizagi.workportal.desktop.popup.closePopupInstance()}},{text:t.getResource("workportal-widget-comments-cancel"),click:function(){$(this).dialog("close")}}]})})}p=function(){$.each($(".reply-list",i),function(){var n=$(".reply-toggler",$(this).parents("li:first"));$("li",this).length>1?($(this).children("li:not(:last)").hide(),n.removeClass("hidden")):n.addClass("hidden")})};$(i).on("click",".reply-toggler",function(n){n.isPropagationStopped()||(n.stopPropagation(),$(this).data("toggle-action")!="hide"?(ot($(this).parent().find("ul")),$("span",this).addClass("expanded"),$(this).data("toggle-action","hide")):(it($(this).parent().find("ul")),$("span",this).removeClass("expanded"),$(this).data("toggle-action","show")))});p();i.appendTo(c);ut({totalPages:l.totalPages,actualPage:l.actualPage},$(".comments-pagination"));h.resolve(c)}),h.promise()},getComments:function(n,t){var r=this,i=new $.Deferred;return n=n||{},t=t||function(){},$.when(r.dataService.getComments(n)).done(function(n){t(n);i.resolve(n)}),i.promise()},replaceTextToSmiles:function(n){for(var t=n,i="",r={"<br>":"\n","[<]":"&lt;","[>]":"&gt;"};i!=t;)$.each(r,function(n,r){var u=new RegExp(n,"gm");i=t;t=t.replace(u,r,"gm")});return $.each({":)":"smiley",":!":"sarcastic",":$":"embarrassed",":(":"sad",":'(":"cry",";)":"wink",":|":"disappointed",":D":"happy",":o":"surprise",":p":"tongue",":s":"confused"," Y ":"yes"," N ":"no"},function(n,i){var r=n.replace(/[\-\[\]\/\{\}\(\)\*\+\?\.\\\^\$\|]/g,"\\$&"),u=new RegExp(r),f="<div class='smiles "+i+"'><\/div>";t=t.replace(u,f,"g")}),t},setStorage:function(n,t){var i="";return n=n||"",sessionStorage&&(i=sessionStorage.setItem(n,t)),i},incrementStorage:function(n,t){var i=!0,r=this,u;return sessionStorage?(u=parseInt(r.getStorage(n))+parseInt(t),r.setStorage(n,u)):i=!1,i},getStorage:function(n){var t=undefined;return n=n||"",sessionStorage&&(t=sessionStorage.getItem(n)),t}};
