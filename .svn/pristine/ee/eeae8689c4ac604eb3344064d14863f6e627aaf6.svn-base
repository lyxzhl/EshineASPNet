/*
 * name: page.detail.2dcode.js
 * author: xeonluo
 * usage:
 **/
define("page.detail.2dcode.32", function(require, exports, module) {
    var CFG, // 默认配置文件, 大写表示为静态变量，不可变
    _fn; // 下划线代表私有方法
    // 全局配置文件，将一些钩子抽取配置出来
    CFG = {
        WRAP_ID: '#sea_code_wrap',
        CODE_ID: '#sea_code',
        BIGCODE_ID: '#sea_bigcode',
        COOKIE: require('common.cookie.2')
    }

    // private collection 
    // 私有方法集，可以任意命名
    _fn = {
        init: function(event, item) {
            if(itemInfo.bt_state != 0){
                return;
            }
            var _wrap = $(CFG.WRAP_ID);

            if(location.search.indexOf('wxsg=0') == 1){
                CFG.COOKIE.del('wxsg');
                return false;
            }
            if(location.search.indexOf('wxsg=1') == 1){
                CFG.COOKIE.set('wxsg', 1);                
            }

            if (_wrap.size() > 0 && item.is_wxsg > 0 && (config.lv & level.WEIXIN_CODE || CFG.COOKIE.get('wxsg'))) {
                var _bigcode = $(CFG.BIGCODE_ID).find('img'),
                _code = $(CFG.CODE_ID).find('img');
                if(item.mult_price && item.mult_price.wxsg_price){
                    $('#wxsg_price').html('<span class="mod_price"><i>&yen;</i>'+item.mult_price.wxsg_price+'</span><span class="xscan_price_label">微信专属</span>');
                }
                _fn.loadImage(_code.attr('_src'), function(){
                    _code.attr('src', this.src);
                    _bigcode.attr('src', _bigcode.attr('_src'));                
                    _wrap.show();
                    //_fn.addEventDelegate(_wrap);
                });
            }

        },
        loadImage: function(url, callback) {
            var img = new Image(); //创建一个Image对象，实现图片的预下载
            img.src = url;
         
            if (img.complete) { // 如果图片已经存在于浏览器缓存，直接调用回调函数
                callback.call(img);
                return; // 直接返回，不用再处理onload事件
            }
         
            img.onload = function () { //图片下载完毕时异步调用callback函数。
                callback.call(img);//将回调函数的this替换为Image对象
            };
        },
        addEventDelegate: function(_wrap) {
            var _bigcode = $(CFG.BIGCODE_ID),
                _code = $(CFG.CODE_ID),
                _col1 = _wrap.find('.xscan_col1'),
                _col2 = _wrap.find('.xscan_col2');
            _wrap.t = null;
            _wrap.ts1 = null;
            _wrap.ts2 = null;
            
            _col1.mouseenter(function() {
                _wrap.ts1 = setTimeout(function() {
                    _wrap.addClass('xscan_on');
                    _bigcode.show();
                }, 300);
            });
            _col2.mouseenter(function() {
                _wrap.ts2 = setTimeout(function() {
                    _wrap.addClass('xscan_on');
                    _bigcode.show();
                }, 300);
            });
            _col1.mouseleave(function() {
                clearTimeout(_wrap.ts1);
                _wrap.ts = null;
            });
            _col2.mouseleave(function() {
                clearTimeout(_wrap.ts2);
                _wrap.ts = null;
            });
            _wrap.delegate(CFG.BIGCODE_ID, 'mouseleave', function() {                
                _wrap.ts1 = null;
                clearTimeout(_wrap.ts2);
                _wrap.ts2 = null;
                _wrap.t = setTimeout(function() {
                    _bigcode.hide();
                    _wrap.removeClass('xscan_on');
                }, 200);
            });
            _wrap.delegate(CFG.BIGCODE_ID, 'mousemove', function() {
                clearTimeout(_wrap.ts1);
                _wrap.ts1 = null;
                clearTimeout(_wrap.ts2);
                _wrap.ts2 = null;
                clearTimeout(_wrap.t);
                _wrap.t = null;
            });
        }
    }

    $(document).bind('init', _fn.init);
});/*  |xGv00|3d50187882eb32679a189cd0b8241add */