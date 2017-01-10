$(document).ready(function () {

    $("input[type=radio][name=paytype]").click(function () {
        $("#paybuttondiv").fadeIn();
    });

    $("label").click(function (e) {
        e.preventDefault();
        $("#" + $(this).attr("for")).click().change();
    });

    $("#hamburger").click(function () {
        if ($("nav#mobile").hasClass("show_nav")) {
            $("nav#mobile,.wrapper,header,footer").removeClass("show_nav");
            $("nav#mobile,.wrapper,header,footer").addClass("hide_nav");
        }
        else {
            $("nav#mobile,.wrapper,header,footer").removeClass("hide_nav");
            $("nav#mobile,.wrapper,header,footer").addClass("show_nav");
        }
    });

    $(".close_nav").click(function () {
        $("nav#mobile,.wrapper,header,footer").removeClass("show_nav");
        $("nav#mobile,.wrapper,header,footer").addClass("hide_nav");
    });

    $(".cb-enable").click(function () {
        var parent = $(this).parents('.switch');
        $('.cb-disable', parent).removeClass('selected');
        $(this).addClass('selected');
        $('.checkbox', parent).attr('checked', true);
    });
    $(".cb-disable").click(function () {
        var parent = $(this).parents('.switch');
        $('.cb-enable', parent).removeClass('selected');
        $(this).addClass('selected');
        $('.checkbox', parent).attr('checked', false);
    });

    var oribranch;
    $("input[type=radio][name=checkboxstores]").click(function () {
        $(".checked").fadeOut();
        $(oribranch).fadeTo("fast", 1);
        var s = '#' + $(this).attr("id");
        if ($(this).attr("checked")) {
            $(s + 'i').fadeTo("slow", 0.4);
            $(s + 't').fadeIn();
            $(s + 't').animate({ marginTop: "10px", marginBottom: "-40px" });
            oribranch = s + 'i';
            $("#continue2").fadeIn();
        }
    });



});
