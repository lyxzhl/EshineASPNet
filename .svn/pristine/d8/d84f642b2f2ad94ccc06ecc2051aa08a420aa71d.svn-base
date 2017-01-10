
$(function () {

    var _userAgent = window.navigator.userAgent.toLowerCase();
    var onlineSP = "0";
    if (_userAgent.indexOf('android') < 0 && _userAgent.indexOf('iphone') < 0 && _userAgent.indexOf('ipad') < 0) {

        if (onlineSP == "0") {
            $('.onlineService').show();
            $('.box_os').hide();
        }
        else if (onlineSP == "1") {
            $('.onlineService').hide();
            $('.box_os').show();
        }

    }
    else {
        $('.onlineService').show();
        $('.box_os').hide();

    }

    $('.onlineService .ico_os').click(function () {
        $('.onlineService').hide();
        $('.box_os').show();
        onlineSP = "0";
    });
    $('.os_x').click(function () {
        $('.box_os').hide();
        $('.onlineService').show();
        onlineSP = "1";
    });
    $boxOsFun = function () { var st = $(document).scrollTop(); if (!window.XMLHttpRequest) { $('.box_os').css('top', st + 44); $('.onlineService').css('top', st + 44); } };
    $(window).bind('scroll', $boxOsFun);
    $boxOsFun();

    var feedback_url = 'http://www.lanrenzhijia.com';

    $('.acbox .ico_pp').hover(function () {
        $(this).stop().animate({ height: '52px' }, 'fast');
    }, function () {
        $(this).stop().animate({ height: '33px' }, 'fast');
    }
	);
    $('.acbox .ico_gt').hover(function () {
        $(this).stop().animate({ height: '52px' }, 'fast');
    }, function () {
        $(this).stop().animate({ height: '33px' }, 'fast');
    }
	);

    $('.onlineService .ico_pp').hover(function () {
        $(this).stop().animate({ width: '87px' }, 'fast');
    }, function () {
        $(this).stop().animate({ width: '39px' }, 'fast');
    }
	);
    $('.onlineService .ico_gt').hover(function () {
        $(this).stop().animate({ width: '97px' }, 'fast');
    }, function () {
        $(this).stop().animate({ width: '39px' }, 'fast');
    }
	);

    $('.ico_gt').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 1);
    })


    //分辨率
    if ($(window).width() < 1200 || screen.width < 1200) {
        $('.hydp950,.w_950,.sdmain,.main').css('overflow', 'hidden');
        $('.top_bg').css({ 'overflow': 'hidden', 'width': '950px', 'margin': '0 auto' });
        $('.db_bg2').addClass('db_bg2_s');
        $('.jstd_c .bg_l,.jstd_c .bg_r').css('display', 'none');
        $('#js_play .prev').css('left', '0');
        $('#js_play .next').css('right', '0');
        $('#videoplay .prev, #videoplay2 .prev').addClass('prev_s');
        $('#videoplay .next, #videoplay2 .next').addClass('next_s');
    } else {
        $('.hydp950,.w_950,.sdmain,.main').removeAttr('style');
        $('.top_bg').removeAttr('style');
        $('.db_bg2').removeClass('db_bg2_s');
        $('.jstd_c .bg_l,.jstd_c .bg_r').removeAttr('style');
        $('#js_play .prev').removeAttr('style');
        $('#js_play .next').removeAttr('style');
        $('#videoplay .prev, #videoplay2 .prev').removeClass('prev_s');
        $('#videoplay .next, #videoplay2 .next').removeClass('next_s');
    }

});