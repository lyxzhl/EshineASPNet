/*
 * name: page.detail.pic_view.js
 * author: xeonluo
 * usage:
 **/
define("page.detail.pic_view.13", function(require, exports, module) {
    var image = require('common.image.7');
    /*
     * oxzoom is an optimized version of jQzoom Evolution Library v2.3 (http://www.mind-projects.it)
     * @version 1.0.5
     * @author levinhuang
     * @class jQuery.oxzoom
     * @static
     */
    (function($) {
        //GLOBAL VARIABLES
        var isIE6 = (typeof document.body.style.maxHeight === "undefined"),
            //($.browser.msie && $.browser.version < 7);
            $win = $(window);
        /**
         * Internal core class for oxzoom
         * @class model
         * @constructor
         * @param {Object} $d jquery dom object for the oxzoom
         * @param {Object} opts0 configuration options
         */
        var model = function($d, opts0) {
                this.opts = opts0;
                this.$d = $d.addClass('oxzoom_' + (opts0.zoomType || $.fn.oxzoom.defaults.zoomType));
                this.$loader = model.isIDSelector(opts0.cssZoomLoader) ? $(opts0.cssZoomLoader) : $d.find(opts0.cssZoomLoader);
                this.$lens = model.isIDSelector(opts0.cssZoomLens) ? $(opts0.cssZoomLens) : $d.find(opts0.cssZoomLens);
                this.$thumbImg = $d.find('img').eq(0);
                this.$zoomBox = model.isIDSelector(opts0.cssZoomBox) ? $(opts0.cssZoomBox) : $d.find(opts0.cssZoomBox);
                this._init();
            };

        model.isIDSelector = function(cssSelector) {
            return (cssSelector.charAt(0) === '#');
        };

        model.prototype = {
            _init: function() {
                if (this.$thumbImg.length === 0) {
                    return;
                }
                this.zoomActive = false;
                this.zoomDisabled = false;
                this.thumbImage = new model.thumbImage(this);
                this.largeImage = new model.largeImage(this);
                this.lens = new model.lens(this);

                if (this.opts.preloadImage) {
                    this.largeImage.load(this.thumbImage.src1, true);
                }

                this._initEvt();
            },
            _initEvt: function() {
                var me = this;
                this.$d.bind('mouseenter.oxzoom', function(e) {
                    me.active();
                }).bind('mouseleave.oxzoom', function(e) {
                    me.deactive();
                }).bind('mousemove.oxzoom', function(e) {
                    //prevent fast mouse mevements not to fire the mouseout event
                    if (e.pageX > me.thumbImage.pos.r || e.pageX < me.thumbImage.pos.l || e.pageY < me.thumbImage.pos.t || e.pageY > me.thumbImage.pos.b) {
                        me.lens.center();
                        return false;
                    }
                    me.zoomActive = true;
                    if (!me.largeImage.isLoading && !me.largeImage.isVisible) {
                        me.active();
                    }
                    if (!me.largeImage.isLoading) {
                        me.lens.setPositionByMousemove(e);
                    }
                });
                $win.bind('resize.oxzoom', function(e) {
                    me._onResized();
                });
            },
            _dispose: function() {
                return this;
            },
            _onResized: function() {
                this.thumbImage.onResized();
                this.largeImage.onResized();
            },
            //update the options
            _update: function(opts, reInit) {
                this.opts = opts;
                if (reInit) {
                    this._dispose()._init();
                }
            },
            active: function() {
                this.$d.addClass(this.opts.clZooming);
                this.zoomActive = true;
                this.lens.show();
                this.largeImage.show();
            },
            deactive: function() {
                this.$d.removeClass(this.opts.clZooming);
                this.zoomActive = false;
                this.lens.hide();
                this.largeImage.hide();
            },
            swipeImage: function(thumbUrl, largeUrl) {
                this.thumbImageUrl = thumbUrl;
                this.largeImageUrl = largeUrl;
            }
        };

        model.loader = function($dom, opts0) {
            this.opts = opts0;
            this.$dom = $dom;
        };
        model.loader.prototype = {
            show: function() {
                this.$dom.addClass(this.opts.clZoomLoaderOn);
            },
            hide: function() {
                this.$dom.removeClass(this.opts.clZoomLoaderOn);
            }
        };

        model.thumbImage = function(boss) {
            this.$dom = boss.$thumbImg;
            this.opts = boss.opts;
            this.boss = boss;
            this._init();
        };
        model.thumbImage.prototype = {
            _init: function() {
                this.updateData();
                var me = this;
                this.$dom.load(function() {
                    me._onLoaded();
                });
                //sometimes image is already loaded and onload will not fire
                if (this.$dom[0].complete) {
                    me._onLoaded();
                };
            },
            _onLoaded: function() {
                this.updateImageData();
                this.boss.swipeImage(this.src0, this.src1);
            },
            onResized: function() {
                this.pos = this.$dom.offset();
                this.pos.l = this.pos.left + this.borderLeftWidth;
                this.pos.t = this.pos.top + this.borderTopWidth;
                this.pos.r = this.ow + this.pos.l;
                this.pos.b = this.oh + this.pos.t;
            },
            updateImageData: function() {
                this.src0 = this.$dom[0].src;
                this.src1 = this.$dom[0].getAttribute('data-oxzsrc');
            },
            updateData: function() {
                var d = {
                    borderTopWidth: parseInt(this.$dom.css('border-top-width').toUpperCase().replace('PX', '')) || 0,
                    borderLeftWidth: parseInt(this.$dom.css('border-left-width').toUpperCase().replace('PX', '')) || 0,
                    w: this.$dom.width(),
                    h: this.$dom.height(),
                    ow: this.$dom.outerWidth(),
                    oh: this.$dom.outerHeight(),
                    pos: this.$dom.offset()
                };
                d.pos.l = d.pos.left + d.borderLeftWidth;
                d.pos.t = d.pos.top + d.borderTopWidth;
                d.pos.r = d.ow + d.pos.l;
                d.pos.b = d.oh + d.pos.t;
                $.extend(this, d);
            }
        };

        model.largeImage = function(boss) {
            this.boss = boss;
            this.opts = boss.opts;
            this.$wrap = boss.$zoomBox;
            this.$dom = this.$wrap.find('img');
            this.$parent = this.$dom.parent();
            if (isIE6) {
                this.$ieframe = $('<iframe class="oxzoom_frame" src="javascript:void(0)" marginwidth="0" marginheight="0" align="bottom" scrolling="no" frameborder="0" ></iframe>');
                this.$parent.after(this.$ieframe);
            }
            this.isLoading = false;
            this.isVisible = false;
            this.loader = null;
            this._init();
        };
        model.largeImage.prototype = {
            _init: function() {
                this.pos = this.$dom.offset();
                this.pos.l = this.pos.left;
                this.pos.t = this.pos.top;
                var $loader = this.$wrap.find(this.opts.cssZoomLoader);
                if ($loader.length > 0) {
                    this.loader = new model.loader($loader, this.opts);
                };
                //if the large image has a fixed size,we parse the image data once only
                if (this.opts.isLargeImageFixedSize) {
                    this.updateData();
                };
                this._initEvt();
            },
            _initEvt: function() {
                var me = this;
                this.$dom.load(function() {
                    me._onLoaded();
                });
            },
            load: function(url, isPreload) {
                if (isPreload !== true) {
                    this.loader && this.loader.show();
                }
                url && (this.$dom[0].src = url);
                //sometimes image is already loaded and onload will not fire
                if (this.$dom[0].complete) {
                    this._onLoaded();
                };
            },
            _onLoaded: function() {
                this.isLoading = false;
                //update the image data when necessary
                if (!this.opts.isLargeImageFixedSize) {
                    this.updateData();
                }
                this.loader && this.loader.hide();
            },
            onResized: function() {
                this.pos = this.$dom.offset();
                this.pos.l = this.pos.left;
                this.pos.t = this.pos.top;
                this.pos.r = this.w + this.pos.l;
                this.pos.b = this.h + this.pos.t;
            },
            updateData: function() {
                this.w = this.$dom.width();
                this.h = this.$dom.height();
                this.pos.r = this.w + this.pos.l;
                this.pos.b = this.h + this.pos.t;
                this.scale = {
                    x: this.w / this.boss.thumbImage.ow,
                    y: this.h / this.boss.thumbImage.oh
                };
            },
            hide: function() {
                this.$wrap.removeClass(this.opts.clZoomBoxOn);
                this.isVisible = false;
                this.$dom[0].removeAttribute('src');
            },
            show: function() {
                this.$wrap.addClass(this.opts.clZoomBoxOn);
                this.isVisible = true;
                this.load(this.boss.largeImageUrl);
            },
            updatePosition: function() {
                var left = -this.scale.x * (this.boss.lens.pos.left - this.boss.thumbImage.borderLeftWidth + 1);
                var top = -this.scale.y * (this.boss.lens.pos.top - this.boss.thumbImage.borderTopWidth + 1);
                this.$dom.css({
                    'margin-left': left,
                    'margin-top': top
                });
            }
        };
        model.lens = function(boss) {
            this.opts = boss.opts;
            this.$dom = boss.$lens;
            this.boss = boss;
            this._init();
        };
        model.lens.prototype = {
            _init: function() {
                this.w = this.$dom.width();
                this.h = this.$dom.height();
                this.ow = this.$dom.outerWidth();
                this.oh = this.$dom.outerHeight();
                this.mousePos = {};

                if (this.opts.zoomType === 'reverse') {
                    if (!this.$img) {
                        this.$img = $('<img class="oxzoom_lens_img"/>');
                        this.$dom.append(this.$img);
                    }
                }
            },
            center: function() {
                this.pos = {
                    top: (this.boss.thumbImage.oh - this.oh) / 2,
                    left: (this.boss.thumbImage.ow - this.ow) / 2
                };
                this.updatePosition();
            },
            updatePosition: function() {
                this.$dom.css(this.pos);
                this.updateImgPosition();
                this.boss.largeImage.updatePosition();
            },
            updateImgPosition: function() {
                if (this.opts.zoomType === 'reverse') {
                    this.$img.css({
                        left: -(this.pos.left + 1 - this.boss.thumbImage.borderLeftWidth) + 'px',
                        top: -(this.pos.top + 1 - this.boss.thumbImage.borderTopWidth) + 'px'
                    });
                };
            },
            isOverLeft: function() {
                return (this.mousePos.x - this.ow / 2 < this.boss.thumbImage.pos.l);
            },
            isOverRight: function() {
                return (this.mousePos.x + this.ow / 2 > this.boss.thumbImage.pos.r);
            },
            isOverTop: function() {
                return (this.mousePos.y - this.oh / 2 < this.boss.thumbImage.pos.t);
            },
            isOverBottom: function() {
                return (this.mousePos.y + this.oh / 2 > this.boss.thumbImage.pos.b);
            },
            getPositionByMouse: function(e) {
                this.mousePos.x = e.pageX;
                this.mousePos.y = e.pageY;
                var pos = {
                    left: 0,
                    top: 0
                };

                pos.left = this.mousePos.x + this.boss.thumbImage.borderLeftWidth - this.boss.thumbImage.pos.l - this.ow / 2;
                pos.top = this.mousePos.y + this.boss.thumbImage.borderTopWidth - this.boss.thumbImage.pos.t - this.oh / 2;

                if (this.isOverLeft()) {
                    pos.left = this.boss.thumbImage.borderLeftWidth;
                } else if (this.isOverRight()) {
                    pos.left = this.boss.thumbImage.ow + this.boss.thumbImage.borderLeftWidth - this.ow;
                }
                if (this.isOverTop()) {
                    pos.top = this.boss.thumbImage.borderTopWidth;
                } else if (this.isOverBottom()) {
                    pos.top = this.boss.thumbImage.oh + this.boss.thumbImage.borderTopWidth - this.oh;
                }
                pos.left = pos.left < 0 ? 0 : pos.left;
                pos.top = pos.top < 0 ? 0 : pos.top;
                return pos;
            },
            setPositionByMousemove: function(e) {
                this.pos = this.getPositionByMouse(e);
                this.updatePosition();
            },
            hide: function() {
                this.$dom.removeClass(this.opts.clZoomLensOn);
            },
            show: function() {
                this.$dom.addClass(this.opts.clZoomLensOn);
                if (this.$img) {
                    this.$img[0].src = this.boss.thumbImageUrl;
                };
            }
        };
/**
     * oxzoom
     * @method jQuery.fn.oxzoom
     * @param {Object} opts 配置对象，具体各个配置属性请参考jQuery.fn.oxzoom.defaults
     * @example
            $('#test').oxzoom();
     */
        $.fn.oxzoom = function(opts) {
            // Set the options.
            var optsType = typeof(opts),
                opts1 = optsType !== 'string' ? $.extend(true, {}, $.fn.oxzoom.defaults, opts || {}) : $.fn.oxzoom.defaults,
                args = arguments;

            return this.each(function() {

                var $me = $(this),
                    instance = $me.data("oxzoom");
                if (instance) {

                    if (instance[opts]) {

                        instance[opts].apply(instance, Array.prototype.slice.call(args, 1));

                    } else if (typeof(opts) === 'object' || !opts) {

                        instance._update.apply(instance, args);

                    }

                } else {
                    $me.data("oxzoom", new model($me, opts1));
                }

            });
        };
        /**
         * jQuery.oxzoom's default configuration
         * @class jQuery.fn.oxzoom.defaults
         * @static
         */
        $.fn.oxzoom.defaults = {
            cssZoomLens: '.oxzoom_lens',
            clZoomLensOn: 'oxzoom_lens_active',
            cssZoomLoader: '.oxzoom_loader',
            clZoomLoaderOn: 'oxzoom_loader_active',
            cssZoomBox: '.oxzoom_box',
            clZoomBoxOn: 'oxzoom_box_active',
            clZooming: 'oxzoom_active',
            zoomType: 'standard',
            //standard|reverse
            isLargeImageFixedSize: false,
            preloadImage: true
        };
    })(jQuery);
    var init = function(event, opt) {
            var _opt = opt || {};
            if (!_opt.p_char_id || _opt.pic_num <= 0) return;

            _opt.pic_num = _opt.pic_num || 1;

            function loadImage(url, callback) {
                var img = new Image(); //创建一个Image对象，实现图片的预下载
                img.src = url;

                if (img.complete) { // 如果图片已经存在于浏览器缓存，直接调用回调函数
                    callback.call(img);
                    return; // 直接返回，不用再处理onload事件
                }

                img.onload = function() { //图片下载完毕时异步调用callback函数。
                    callback.call(img); //将回调函数的this替换为Image对象
                };
            };
            var html = [];
            for (var i = 0; i < _opt.pic_num; i++) {
                loadImage(G.logic.constants.getPic60Url(_opt.p_char_id, i), function() {});
                html.push('<li><a href="javascript:" hidefocus="true"><img char_id="' + _opt.p_char_id + '" src="' + G.logic.constants.getPic60Url(_opt.p_char_id, i) + '" alt="' + opt.name + '" onerror="this.src=\'http://static.gtimg.com/icson/images/detail/v2/60.jpg\'" /></a></li>');
            }

            var avgWidth = 53;
            var oSmallpic = $('#list_smallpic ul');
            oSmallpic.html(html.join(''));
            oSmallpic.width(avgWidth * _opt.pic_num + 1);

            function setBtnEnable(jqObj, enable, classname) {
                jqObj.removeClass(classname);
                if (!enable) jqObj.addClass(classname);
            }


            var nowIdx = 0;
            var moving = false;

            function moveFn(direction) {
                if (moving) return;
                moving = true;
                if (direction > 0) {
                    if (nowIdx >= _opt.pic_num - 5) return;
                    nowIdx++;
                } else {
                    if (nowIdx <= 0) return;
                    nowIdx--;
                }
                $('#list_smallpic li').eq(nowIdx).mouseenter();
                setBtnEnable($('#pic_small_wrapper .xgallery_next'), nowIdx < _opt.pic_num - 5, 'xgallery_next_disabled');
                setBtnEnable($('#pic_small_wrapper .xgallery_prev'), nowIdx > 0, 'xgallery_prev_disabled');

                $('#list_smallpic').animate({
                    scrollLeft: nowIdx * avgWidth
                }, 100, '', function() {
                    moving = false;
                });
            }

            setBtnEnable($('#pic_small_wrapper .xgallery_next'), 0 < _opt.pic_num - 5, 'xgallery_next_disabled');
            setBtnEnable($('#pic_small_wrapper .xgallery_prev'), false, 'xgallery_prev_disabled');

            $('#pic_small_wrapper .xgallery_prev').click(function() {
                if ($(this).hasClass('xgallery_prev_disabled')) {
                    return;
                }
                moveFn(-1);
            });

            $('#pic_small_wrapper .xgallery_next').click(function() {
                if ($(this).hasClass('xgallery_next_disabled')) {
                    return;
                }
                moveFn(1);
            });

            /**
             * 鼠标滑过小图显示中图
             */
            $('#list_smallpic li').each(function(idx) {
                $(this).attr("idx", idx);
                $(this).mouseenter(function() {
                    $('#list_smallpic .current').removeClass('current');
                    $(this).addClass('current');

                    var char_id = $(this).find('img').attr('char_id'),
                        iidx = $(this).attr("idx"),
                        small_image = $('#xgalleryImg');
                    small_image.attr('char_id', char_id);
                    small_image.attr('idx', iidx);
                    small_image.attr('src', G.logic.constants.getMMUrl(char_id, iidx));
                    small_image.error(function() {
                        $(this).attr('src', 'http://static.gtimg.com/icson/images/detail/v2/300.jpg');
                    });
                    small_image.attr('data-oxzsrc', G.logic.constants.getBigUrl(char_id, iidx));
                    $('#sea_zoom_wrap li').eq(iidx).click();
                });
            });


            $('#sea_zoom_wrap ul').html(html.join(''));
            $('#xgalleryShow_noshow').click(function() {
                var w = $('#sea_window'),
                    z = $('#sea_zoom_wrap'),
                    win = $(window),
                    doc = $(document);
                z.css({
                    top: (win.height() - z.height()) / 2
                });
                z.show();
                w.width(doc.width());
                w.height(doc.height());
                w.show();
            });

            $(window).resize(function() {
                var z = $('#sea_zoom_wrap'),
                    win = $(window);
                z.css({
                    top: (win.height() - z.height()) / 2
                });
            });

            $('#sea_zoom_close').click(function() {
                $('#sea_zoom_wrap').hide();
                $('#sea_window').hide();
            });
            /**
             * 鼠标点击小图显示大图
             */
            $('#sea_zoom_wrap li').each(function(idx) {
                $(this).attr("idx", idx);
                $(this).click(function() {
                    $('#sea_zoom_wrap .current').removeClass('current');
                    $(this).addClass('current');

                    var char_id = $(this).find('img').attr('char_id'),
                        iidx = $(this).attr("idx"),
                        small_image = $('#sea_zoom_pic');
                    small_image.attr('char_id', char_id);
                    small_image.attr('idx', iidx);
                    setBtEnable(iidx);
                    small_image.attr('src', G.logic.constants.getBigUrl(char_id, iidx));
                });
            });

            function setBtEnable(cur) {
                if (cur < 1) {
                    $('.xzoom_prev').addClass('xzoom_prev_disabled');
                } else {
                    $('.xzoom_prev').removeClass('xzoom_prev_disabled');
                }
                if (cur > _opt.pic_num - 2) {
                    $('.xzoom_next').addClass('xzoom_next_disabled');
                } else {
                    $('.xzoom_next').removeClass('xzoom_next_disabled');
                }
            }
            $('.xzoom_prev').click(function() {
                var cur = ~~$('#sea_zoom_wrap .current').attr("idx");
                if (cur > 0) {
                    cur = cur - 1;
                    setBtEnable(cur);
                    $('#sea_zoom_wrap li').eq(cur).click();
                }
            });
            $('.xzoom_next').click(function() {
                var cur = ~~$('#sea_zoom_wrap .current').attr("idx");
                if (cur < _opt.pic_num - 1) {
                    cur = cur + 1;
                    setBtEnable(cur);
                    $('#sea_zoom_wrap li').eq(cur).click();
                }
            });
            //初始化第一个
            $('#list_smallpic li:first').mouseenter();
            //大图预览插件
            $('#xgalleryShow').oxzoom({
                cssZoomBox: '#xgalleryZoom',
                zoomType: 'standard',
                isLargeImageFixedSize: true
            });

        };
    var newInit = function(data, opt) {
            var _opt = opt || {};
            if (!data || data.length == 0) return;

            _opt.pic_num = data.length;

            function loadImage(url, callback) {
                var img = new Image(); //创建一个Image对象，实现图片的预下载
                img.src = url;

                if (img.complete) { // 如果图片已经存在于浏览器缓存，直接调用回调函数
                    callback.call(img);
                    return; // 直接返回，不用再处理onload事件
                }

                img.onload = function() { //图片下载完毕时异步调用callback函数。
                    callback.call(img); //将回调函数的this替换为Image对象
                };
            };
            var html = [];
            for (var i = 0; i < _opt.pic_num; i++) {
                var temp_url = image.getPicBySize(data[i].url, 60);
                loadImage(temp_url, function() {});
                html.push('<li><a href="javascript:" hidefocus="true"><img src="' + temp_url + '" alt="' + opt.name + '" onerror="this.src=\'http://static.gtimg.com/icson/images/detail/v2/60.jpg\'" /></a></li>');
            }

            var avgWidth = 53;
            var oSmallpic = $('#list_smallpic ul');
            oSmallpic.html(html.join(''));
            oSmallpic.width(avgWidth * _opt.pic_num + 1);

            function setBtnEnable(jqObj, enable, classname) {
                jqObj.removeClass(classname);
                if (!enable) jqObj.addClass(classname);
            }


            var nowIdx = 0;
            var moving = false;

            function moveFn(direction) {
                if (moving) return;
                moving = true;
                if (direction > 0) {
                    if (nowIdx >= _opt.pic_num - 5) return;
                    nowIdx++;
                } else {
                    if (nowIdx <= 0) return;
                    nowIdx--;
                }
                $('#list_smallpic li').eq(nowIdx).mouseenter();
                setBtnEnable($('#pic_small_wrapper .xgallery_next'), nowIdx < _opt.pic_num - 5, 'xgallery_next_disabled');
                setBtnEnable($('#pic_small_wrapper .xgallery_prev'), nowIdx > 0, 'xgallery_prev_disabled');

                $('#list_smallpic').animate({
                    scrollLeft: nowIdx * avgWidth
                }, 100, '', function() {
                    moving = false;
                });
            }

            setBtnEnable($('#pic_small_wrapper .xgallery_next'), 0 < _opt.pic_num - 5, 'xgallery_next_disabled');
            setBtnEnable($('#pic_small_wrapper .xgallery_prev'), false, 'xgallery_prev_disabled');

            $('#pic_small_wrapper .xgallery_prev').click(function() {
                if ($(this).hasClass('xgallery_prev_disabled')) {
                    return;
                }
                moveFn(-1);
            });

            $('#pic_small_wrapper .xgallery_next').click(function() {
                if ($(this).hasClass('xgallery_next_disabled')) {
                    return;
                }
                moveFn(1);
            });

            /**
             * 鼠标滑过小图显示中图
             */
            $('#list_smallpic li').each(function(idx) {
                $(this).attr("idx", idx);
                $(this).mouseenter(function() {
                    $('#list_smallpic .current').removeClass('current');
                    $(this).addClass('current');

                    var img = $(this).find('img').attr('src'),
                        iidx = $(this).attr("idx"),
                        small_image = $('#xgalleryImg');
                    small_image.attr('idx', iidx);
                    small_image.attr('src', image.getPicBySize(img, 300));
                    small_image.error(function() {
                        $(this).attr('src', 'http://static.gtimg.com/icson/images/detail/v2/300.jpg');
                    });
                    small_image.attr('data-oxzsrc', image.getPicBySize(img, 800));
                    $('#sea_zoom_wrap li').eq(iidx).click();
                });
            });


            $('#sea_zoom_wrap ul').html(html.join(''));
            $('#xgalleryShow_noshow').click(function() {
                var w = $('#sea_window'),
                    z = $('#sea_zoom_wrap'),
                    win = $(window),
                    doc = $(document);
                z.css({
                    top: (win.height() - z.height()) / 2
                });
                z.show();
                w.width(doc.width());
                w.height(doc.height());
                w.show();
            });

            $(window).resize(function() {
                var z = $('#sea_zoom_wrap'),
                    win = $(window);
                z.css({
                    top: (win.height() - z.height()) / 2
                });
            });

            $('#sea_zoom_close').click(function() {
                $('#sea_zoom_wrap').hide();
                $('#sea_window').hide();
            });
            /**
             * 鼠标点击小图显示大图
             */
            $('#sea_zoom_wrap li').each(function(idx) {
                $(this).attr("idx", idx);
                $(this).click(function() {
                    $('#sea_zoom_wrap .current').removeClass('current');
                    $(this).addClass('current');

                    var img = $(this).find('img').attr('src'),
                        iidx = $(this).attr("idx"),
                        small_image = $('#sea_zoom_pic');
                    small_image.attr('idx', iidx);
                    setBtEnable(iidx);
                    small_image.attr('src', image.getPicBySize(img, 600));
                });
            });

            function setBtEnable(cur) {
                if (cur < 1) {
                    $('.xzoom_prev').addClass('xzoom_prev_disabled');
                } else {
                    $('.xzoom_prev').removeClass('xzoom_prev_disabled');
                }
                if (cur > _opt.pic_num - 2) {
                    $('.xzoom_next').addClass('xzoom_next_disabled');
                } else {
                    $('.xzoom_next').removeClass('xzoom_next_disabled');
                }
            }
            $('.xzoom_prev').click(function() {
                var cur = ~~$('#sea_zoom_wrap .current').attr("idx");
                if (cur > 0) {
                    cur = cur - 1;
                    setBtEnable(cur);
                    $('#sea_zoom_wrap li').eq(cur).click();
                }
            });
            $('.xzoom_next').click(function() {
                var cur = ~~$('#sea_zoom_wrap .current').attr("idx");
                if (cur < _opt.pic_num - 1) {
                    cur = cur + 1;
                    setBtEnable(cur);
                    $('#sea_zoom_wrap li').eq(cur).click();
                }
            });
            //初始化第一个
            $('#list_smallpic li:first').mouseenter();
            //大图预览插件
            $('#xgalleryShow').oxzoom({
                cssZoomBox: '#xgalleryZoom',
                zoomType: 'standard',
                isLargeImageFixedSize: true
            });

        };
    $(document).bind('init', function(event, item) {
        var cookie = require('common.cookie.2');
        if(location.search.indexOf('cdn=0') == 1){
            cookie.del('cdn');
        }
        if(location.search.indexOf('cdn=1') == 1){
            cookie.set('cdn', 1);                
        }
        if (cookie.get('cdn') || config.lv & level.QQ_CDN) {
            window['CallBackPic_' + itemInfo.open_item_id] = window['CallBackPic_' + itemInfo.skuID] = function(_data) {
                newInit(_data, item);
                window['CallBackPic_' + itemInfo.open_item_id] = window['CallBackPic_' + itemInfo.skuID] = null;
                if(window.pic){
                    pic = null;
                }
            };
            var pic_url = "";
            if ((config.lv & level.OPEN_PIC_DET) && item.pic_cdn_name) {
                pic_url = 'http://item.wgimg.com/' + item.pic_cdn_name;
            }else if(config.detailUrl){
                var param = config.detailUrl.split('det_');
                if (param && param[1]) {
                    pic_url = 'http://item.wgimg.com/pic_' + param[1];
                }
            }
            if(pic_url){
                $.getScript(pic_url);
            }
        } else {
            init(event, item);
        }
    });
});/*  |xGv00|2f9bd7e167969b6a4eb0c943fa139aab */