/*
 * name: page.detail.information.js
 * author: xeonluo
 * usage:
**/
define("page.detail.information.3", function(require, exports, module) {
    var CFG, // 默认配置文件, 大写表示为静态变量，不可变
    _fn; // 下划线代表私有方法
    // 全局配置文件，将一些钩子抽取配置出来
    CFG = {
        WRAP_ID: '#c_information',
        WRAP_HTML_BEGIN: '<iframe frameborder="0" border="0" frameborder="no" width="100%" height="950" scrolling="no" allowtransparency="true" src="',
        WRAP_HTML_END: '"></iframe>'
    }

    // private collection 
    // 私有方法集，可以任意命名
    _fn = {
        init: function(event, url){
            var wrap = $(CFG.WRAP_ID);
            if(wrap.data('contentLoaded') != 1){
                wrap.html(CFG.WRAP_HTML_BEGIN + url + CFG.WRAP_HTML_END);
                wrap.data('contentLoaded', 1);
            }
        }
    }
    $(document).bind('tab_information', _fn.init);
});/*  |xGv00|142e75180d735603099ffeff4019bdbf */