/* Modal Content Close Event Handler */
function setheights() {
	var featurecontainerheight = null;
	var featurecontainerheight_max = 0;
	var fcheights = [];
	$(".featurecontainerwrapper").each(function(){
		fcheights.push($(this).height()); 
	});
	fcheights.sort();
	fcheights.reverse();
	featurecontainerheight_max = fcheights[0];
	featurecontainerheight_max = featurecontainerheight_max-2;
	$(".featurecontainer").height(featurecontainerheight_max);
}

$(document).ready(function() {

    $(".welcomemsg").css({ "RIGHT": (713 - $(".welcomemsg").width()-30) / 2 });
    $(".welcomemsg_text").css({ "RIGHT": (713 - $(".welcomemsg_text").width()-30) / 2 });

    /* add pipe dividers to commonlinks used in header and footer */
    $(".commonlinks > ul > li:not('.commonlinks ul li:last-child')").append("<span class='separator'>|</span>");

    /* add pipe divider to primary navigation items */
    $(".nav ul li").append("<span class=\"separator\">|</span>");
    $(".nav ul li.current").find(".separator").remove();
    $(".nav ul li.current").prev().find(".separator").remove();
    $(".nav ul li:last-child").find(".separator").remove();

    addSeparatorForSubNav();

    /* remove bottom padding from last element in main content to maintain uniform spacing*/
    $(".content .main_content:last-child").css({ "paddingBottom": "0" });

    /* remove bottom padding from last element in sidebar content to maintain uniform spacing*/
    $(".content .sidebar_content_body:last-child").css({ "paddingBottom": "0" });

    /* set left padding on sidebar header text when an icon is present */
    $(".sidebar_header > img").siblings().css({ "paddingLeft": "25px" });

    /* set top padding on sidebar header text when an icon is present */
    $(".sidebar_header > img").parent().css({ "paddingTop": "7px" }).css({ "paddingBottom": "7px" });

    /* take current nav item out of tabindex sequence so it is skipped over during keyboard tabbing */
    $(".nav .current a").attr("tabindex", "-1");

    /* remove pipe dividers from primary navigation during mouse hover */
    $(".nav ul li a").hover(function() {
        $(this).next().css({ "visibility": "hidden" });
        $(this).parent().prev().find(".separator").css({ "visibility": "hidden" });
    }, function() {
        $(this).next().css({ "visibility": "visible" });
        $(this).parent().prev().find(".separator").css({ "visibility": "visible" });
    });

    /* remove pipe dividers from primary navigation during keyboard tabbed focus */
    $(".nav ul li a").focus(function() {
        $(this).next().css({ "visibility": "hidden" });
        $(this).parent().prev().find(".separator").css({ "visibility": "hidden" });
    });

    /* restore pipe dividers from primary navigation during keyboard tabbed blur */
    $(".nav ul li a").blur(function() {
        $(this).next().css({ "visibility": "visible" });
        $(this).parent().prev().find(".separator").css({ "visibility": "visible" });
    });


    /* function to remove any main nav items which do not fit onto a single line and removes last pipe if it exists in the last visible nav item */
    var navloc = new Array();
    $(".nav li").each(function(index) {
        navloc[index] = $(this).offset().top;
    });
    var normloc = navloc[0];
    $.each(navloc, function(index, value) {
        if (value > normloc) {
            var targetindex = (index - 1) + "";
            var navtarget = ".nav li:gt(" + targetindex + ")";
            $(navtarget).remove();
            var pipetarget = ".nav li:eq(" + targetindex + ") span.separator";
            $(pipetarget).remove();
        };
    });

    /* feature container logic */
    var featurewrapperwidth = $(".featurecontainers").width();
    featurewrapperwidth = featurewrapperwidth - 1;

    /* visual styling of Feature Containers */
    if ($(".featurecontainers").length > 0) {
        var featurecount = $(".featurecontainerwrapper").length;
        var galleycount = featurecount - 1;
        var galleywidth = $(".featurecontainerwrapper").css("marginRight");
        var galleywidth = parseFloat(galleywidth.replace(/\D/g, ''));
        var galleywidth = galleywidth * galleycount;
        var availwidth = featurewrapperwidth - galleywidth;
        var featurecontainerwidth = availwidth / featurecount;
        $(".featurecontainerwrapper").width(featurecontainerwidth - 1);
        $(".featurecontainerwrapper").last().css({ "margin-right": "0px" });
        var wait = setTimeout("setheights()", 500);
        $(".picholder img").each(function() {
            var imgwidth = $(this).width();
            if (imgwidth < featurecontainerwidth) {
                $(this).width(featurecontainerwidth - 1);
            }
        });
    }


});


function addSeparatorForSubNav() {
    /* add pipe divider to sub navigation items */
    if ($(".subnav ul li:first-child").find(".separator").length == 1)
        return;
        
    $(".subnav ul li").append("<span class=\"separator\">|</span>");
    $(".subnav ul li:last-child").find(".separator").remove();
}
