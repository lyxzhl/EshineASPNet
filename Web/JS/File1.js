

       var handle, _fn;

       // private collection 
       _fn = {
           getPicUrl: function (pCharId, type, picIdx) {
               var parts = pCharId.split("R", 2);
               pCharId = parts[0];
               parts = pCharId.split("-", 3);
               var part1 = parts[0],
                 part2 = parts[1],
                 part3 = parts[2];
               return 'http://img' + (parseInt(part3) % 2 ? '1' : '2') + '.icson.com/product/' + type + '/' + part1 + '/' + part2 + '/' + pCharId + (picIdx == 0 ? '' : ('-' + (picIdx < 10 ? ('0' + picIdx) : picIdx))) + '.jpg';
           },
           getPicByPic: function (pic, size) {
               if (size == 0) {
                   var _pic = (pic + '').replace(/(jpg|gif|png|bmp)\/\d+(\?\w+)?$/, '$1/' + size + '$2');
                   return _pic.replace(/qqbuy/, '51buypic');
               } else {
                   return (pic + '').replace(/(jpg|gif|png|bmp)\/\d+(\?\w+)?$/, '$1/' + size + '$2');
               }
           },
           getYXPicBySize: function (pic, size) {
               return pic;
               var existSize = [0, 30, 60, 80, 120, 160, 200, 300, 400, 600, 800];
               if (pic.indexOf("icson.com") > -1) {
                   existSize = [50, 60, 80, 120, 160, 200, 300, 600, 800];
               }
               var flag = false;
               for (var i = 0; i < existSize.length; i++) {
                   if (size == existSize[i]) {
                       flag = true;
                       break;
                   }
               }
               if (flag) {
                   var url = "";
                   if (pic.indexOf("wgimg.com") > -1) {
                       url = this.getPicByPic(pic, size == 800 ? 0 : size);
                   } else if (pic.indexOf("paipaiimg.com") > -1) {
                       //网购的匹配 .120x120.jpg这样结尾的
                       if (size == 0) {
                           url = pic.replace(/\.\d+x\d+(\.jpg|gif|png|bmp)?$/, "$1");
                       } else {
                           // 当为0时没有 /\d+x\d+/ 所有这里多替换1次
                           url = pic.replace(/(\.)\d+x\d+(\.jpg|gif|png|bmp)?$/, "$1" + (size + "x" + size) + "$2").replace(/(\.\d+)(\.jpg|gif|png|bmp)?$/, "$1." + (size + "x" + size) + "$2");
                       }
                   } else if (pic.indexOf("icson.com") > -1) {
                       url = pic.replace(/\/product\/\w+\//, "/product/" + this.icsonExistMap["" + size] + "/");
                   }
                   return url;
               } else {
                   return existSize.join(",");
               }

           },
           getIcsonPicBySize: function (pCharId, picIdx, size) {
               var existMap = this.icsonExistMap;
               if (("" + size) in existMap) {
                   return this.getPicUrl(pCharId, existMap["" + size], picIdx);
               } else {
                   // 不存在返回存在的列表
                   var str = [];
                   for (var n in existMap) {
                       str.push(n);
                   }
                   return str.join(",");
               }
           },
           icsonExistMap: {
               "50": "ss",
               "60": "pic60",
               "80": "small",
               "120": "middle",
               "160": "pic160",
               "200": "pic200",
               "300": "mm",
               "800": "mpic"
           }
       };

       // public collection
       handle = {
           getPicBySize: function () {
               if (arguments.length == 2) {// 只带链接地址和尺寸
                   return _fn.getYXPicBySize.apply(_fn, arguments);
               } else if (arguments.length == 3) {// pCharId计算需要pCharId, picIdx和尺寸
                   return _fn.getIcsonPicBySize.apply(_fn, arguments);
               }
           }
       };

       function getPicBySize(pic, size) {
           return pic;

           var existSize = [0, 30, 60, 80, 120, 160, 200, 300, 400, 600, 800];
           if (true) {
               existSize = [50, 60, 80, 120, 160, 200, 300, 600, 800];
           }
           var flag = false;
           for (var i = 0; i < existSize.length; i++) {
               if (size == existSize[i]) {
                   flag = true;
                   break;
               }
           }
           if (flag) {
               var url = "";
               if (pic.indexOf("wgimg.com") > -1) {
                   url = this.getPicByPic(pic, size == 800 ? 0 : size);
               } else if (pic.indexOf("paipaiimg.com") > -1) {
                   //网购的匹配 .120x120.jpg这样结尾的
                   if (size == 0) {
                       url = pic.replace(/\.\d+x\d+(\.jpg|gif|png|bmp)?$/, "$1");
                   } else {
                       // 当为0时没有 /\d+x\d+/ 所有这里多替换1次
                       url = pic.replace(/(\.)\d+x\d+(\.jpg|gif|png|bmp)?$/, "$1" + (size + "x" + size) + "$2").replace(/(\.\d+)(\.jpg|gif|png|bmp)?$/, "$1." + (size + "x" + size) + "$2");
                   }
               } else if (pic.indexOf("icson.com") > -1) {
                   url = pic.replace(/\/product\/\w+\//, "/product/" + this.icsonExistMap["" + size] + "/");
               }
               return url;
           } else {
               return existSize.join(",");
           }
       }




       //===================





       (function ($) {
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
           var model = function ($d, opts0) {
               this.opts = opts0;
               this.$d = $d.addClass('oxzoom_' + (opts0.zoomType || $.fn.oxzoom.defaults.zoomType));
               this.$loader = model.isIDSelector(opts0.cssZoomLoader) ? $(opts0.cssZoomLoader) : $d.find(opts0.cssZoomLoader);
               this.$lens = model.isIDSelector(opts0.cssZoomLens) ? $(opts0.cssZoomLens) : $d.find(opts0.cssZoomLens);
               this.$thumbImg = $d.find('img').eq(0);
               this.$zoomBox = model.isIDSelector(opts0.cssZoomBox) ? $(opts0.cssZoomBox) : $d.find(opts0.cssZoomBox);
               this._init();
           };

           model.isIDSelector = function (cssSelector) {
               return (cssSelector.charAt(0) === '#');
           };

           model.prototype = {
               _init: function () {
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
               _initEvt: function () {
                   var me = this;
                   this.$d.bind('mouseenter.oxzoom', function (e) {
                       me.active();
                   }).bind('mouseleave.oxzoom', function (e) {
                       me.deactive();
                   }).bind('mousemove.oxzoom', function (e) {
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
                   $win.bind('resize.oxzoom', function (e) {
                       me._onResized();
                   });
               },
               _dispose: function () {
                   return this;
               },
               _onResized: function () {
                   this.thumbImage.onResized();
                   this.largeImage.onResized();
               },
               //update the options
               _update: function (opts, reInit) {
                   this.opts = opts;
                   if (reInit) {
                       this._dispose()._init();
                   }
               },
               active: function () {
                   this.$d.addClass(this.opts.clZooming);
                   this.zoomActive = true;
                   this.lens.show();
                   this.largeImage.show();
               },
               deactive: function () {
                   this.$d.removeClass(this.opts.clZooming);
                   this.zoomActive = false;
                   this.lens.hide();
                   this.largeImage.hide();
               },
               swipeImage: function (thumbUrl, largeUrl) {
                   this.thumbImageUrl = thumbUrl;
                   this.largeImageUrl = largeUrl;
               }
           };

           model.loader = function ($dom, opts0) {
               this.opts = opts0;
               this.$dom = $dom;
           };
           model.loader.prototype = {
               show: function () {
                   this.$dom.addClass(this.opts.clZoomLoaderOn);
               },
               hide: function () {
                   this.$dom.removeClass(this.opts.clZoomLoaderOn);
               }
           };

           model.thumbImage = function (boss) {
               this.$dom = boss.$thumbImg;
               this.opts = boss.opts;
               this.boss = boss;
               this._init();
           };
           model.thumbImage.prototype = {
               _init: function () {
                   this.updateData();
                   var me = this;
                   this.$dom.load(function () {
                       me._onLoaded();
                   });
                   //sometimes image is already loaded and onload will not fire
                   if (this.$dom[0].complete) {
                       me._onLoaded();
                   };
               },
               _onLoaded: function () {
                   this.updateImageData();
                   this.boss.swipeImage(this.src0, this.src1);
               },
               onResized: function () {
                   this.pos = this.$dom.offset();
                   this.pos.l = this.pos.left + this.borderLeftWidth;
                   this.pos.t = this.pos.top + this.borderTopWidth;
                   this.pos.r = this.ow + this.pos.l;
                   this.pos.b = this.oh + this.pos.t;
               },
               updateImageData: function () {
                   this.src0 = this.$dom[0].src;
                   this.src1 = this.$dom[0].getAttribute('data-oxzsrc');
               },
               updateData: function () {
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

           model.largeImage = function (boss) {
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
               _init: function () {
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
               _initEvt: function () {
                   var me = this;
                   this.$dom.load(function () {
                       me._onLoaded();
                   });
               },
               load: function (url, isPreload) {
                   if (isPreload !== true) {
                       this.loader && this.loader.show();
                   }
                   url && (this.$dom[0].src = url);
                   //sometimes image is already loaded and onload will not fire
                   if (this.$dom[0].complete) {
                       this._onLoaded();
                   };
               },
               _onLoaded: function () {
                   this.isLoading = false;
                   //update the image data when necessary
                   if (!this.opts.isLargeImageFixedSize) {
                       this.updateData();
                   }
                   this.loader && this.loader.hide();
               },
               onResized: function () {
                   this.pos = this.$dom.offset();
                   this.pos.l = this.pos.left;
                   this.pos.t = this.pos.top;
                   this.pos.r = this.w + this.pos.l;
                   this.pos.b = this.h + this.pos.t;
               },
               updateData: function () {
                   this.w = this.$dom.width();
                   this.h = this.$dom.height();
                   this.pos.r = this.w + this.pos.l;
                   this.pos.b = this.h + this.pos.t;
                   this.scale = {
                       x: this.w / this.boss.thumbImage.ow,
                       y: this.h / this.boss.thumbImage.oh
                   };
               },
               hide: function () {
                   this.$wrap.removeClass(this.opts.clZoomBoxOn);
                   this.isVisible = false;
                   this.$dom[0].removeAttribute('src');
               },
               show: function () {
                   this.$wrap.addClass(this.opts.clZoomBoxOn);
                   this.isVisible = true;
                   this.load(this.boss.largeImageUrl);
               },
               updatePosition: function () {
                   var left = -this.scale.x * (this.boss.lens.pos.left - this.boss.thumbImage.borderLeftWidth + 1);
                   var top = -this.scale.y * (this.boss.lens.pos.top - this.boss.thumbImage.borderTopWidth + 1);
                   this.$dom.css({
                       'margin-left': left,
                       'margin-top': top
                   });
               }
           };
           model.lens = function (boss) {
               this.opts = boss.opts;
               this.$dom = boss.$lens;
               this.boss = boss;
               this._init();
           };
           model.lens.prototype = {
               _init: function () {
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
               center: function () {
                   this.pos = {
                       top: (this.boss.thumbImage.oh - this.oh) / 2,
                       left: (this.boss.thumbImage.ow - this.ow) / 2
                   };
                   this.updatePosition();
               },
               updatePosition: function () {
                   this.$dom.css(this.pos);
                   this.updateImgPosition();
                   this.boss.largeImage.updatePosition();
               },
               updateImgPosition: function () {
                   if (this.opts.zoomType === 'reverse') {
                       this.$img.css({
                           left: -(this.pos.left + 1 - this.boss.thumbImage.borderLeftWidth) + 'px',
                           top: -(this.pos.top + 1 - this.boss.thumbImage.borderTopWidth) + 'px'
                       });
                   };
               },
               isOverLeft: function () {
                   return (this.mousePos.x - this.ow / 2 < this.boss.thumbImage.pos.l);
               },
               isOverRight: function () {
                   return (this.mousePos.x + this.ow / 2 > this.boss.thumbImage.pos.r);
               },
               isOverTop: function () {
                   return (this.mousePos.y - this.oh / 2 < this.boss.thumbImage.pos.t);
               },
               isOverBottom: function () {
                   return (this.mousePos.y + this.oh / 2 > this.boss.thumbImage.pos.b);
               },
               getPositionByMouse: function (e) {
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
               setPositionByMousemove: function (e) {
                   this.pos = this.getPositionByMouse(e);
                   this.updatePosition();
               },
               hide: function () {
                   this.$dom.removeClass(this.opts.clZoomLensOn);
               },
               show: function () {
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
           $.fn.oxzoom = function (opts) {
               // Set the options.
               var optsType = typeof (opts),
                   opts1 = optsType !== 'string' ? $.extend(true, {}, $.fn.oxzoom.defaults, opts || {}) : $.fn.oxzoom.defaults,
                   args = arguments;

               return this.each(function () {

                   var $me = $(this),
                       instance = $me.data("oxzoom");
                   if (instance) {

                       if (instance[opts]) {

                           instance[opts].apply(instance, Array.prototype.slice.call(args, 1));

                       } else if (typeof (opts) === 'object' || !opts) {

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
     
       var newInit = function (data, opt) {

           var pic_num = 3;

           function loadImage(url, callback) {
               var img = new Image(); //创建一个Image对象，实现图片的预下载
               img.src = url;

               if (img.complete) { // 如果图片已经存在于浏览器缓存，直接调用回调函数
                   callback.call(img);
                   return; // 直接返回，不用再处理onload事件
               }

               img.onload = function () { //图片下载完毕时异步调用callback函数。
                   callback.call(img); //将回调函数的this替换为Image对象
               };
           };
           var html = [];


           var avgWidth = 53;
           var oSmallpic = $('#list_smallpic ul');
           //oSmallpic.html(html.join(''));
           oSmallpic.width(avgWidth * pic_num + 1);

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
                   if (nowIdx >= pic_num - 5) return;
                   nowIdx++;
               } else {
                   if (nowIdx <= 0) return;
                   nowIdx--;
               }
               $('#list_smallpic li').eq(nowIdx).mouseenter();
               setBtnEnable($('#pic_small_wrapper .xgallery_next'), nowIdx < pic_num - 5, 'xgallery_next_disabled');
               setBtnEnable($('#pic_small_wrapper .xgallery_prev'), nowIdx > 0, 'xgallery_prev_disabled');

               $('#list_smallpic').animate({
                   scrollLeft: nowIdx * avgWidth
               }, 100, '', function () {
                   moving = false;
               });
           }

           setBtnEnable($('#pic_small_wrapper .xgallery_next'), 0 < pic_num - 5, 'xgallery_next_disabled');
           setBtnEnable($('#pic_small_wrapper .xgallery_prev'), false, 'xgallery_prev_disabled');

           $('#pic_small_wrapper .xgallery_prev').click(function () {
               if ($(this).hasClass('xgallery_prev_disabled')) {
                   return;
               }
               moveFn(-1);
           });

           $('#pic_small_wrapper .xgallery_next').click(function () {
               if ($(this).hasClass('xgallery_next_disabled')) {
                   return;
               }
               moveFn(1);
           });

           /**
            * 鼠标滑过小图显示中图
            */
           $('#list_smallpic li').each(function (idx) {
               $(this).attr("idx", idx);
               $(this).mouseenter(function () {
                   $('#list_smallpic .current').removeClass('current');
                   $(this).addClass('current');

                   var img = $(this).find('img').attr('src'),
                       iidx = $(this).attr("idx"),
                       small_image = $('#xgalleryImg');
                   small_image.attr('idx', iidx);
                   small_image.attr('src', getPicBySize(img, 300));
                   small_image.error(function () {
                       $(this).attr('src', 'http://static.gtimg.com/icson/images/detail/v2/300.jpg');
                   });
                   small_image.attr('data-oxzsrc', getPicBySize(img, 800));
                   $('#sea_zoom_wrap li').eq(iidx).click();
               });
           });


           //$('#sea_zoom_wrap ul').html(html.join(''));
           $('#xgalleryShow_noshow').click(function () {
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

           $(window).resize(function () {
               var z = $('#sea_zoom_wrap'),
                   win = $(window);
               z.css({
                   top: (win.height() - z.height()) / 2
               });
           });

           $('#sea_zoom_close').click(function () {
               $('#sea_zoom_wrap').hide();
               $('#sea_window').hide();
           });
           /**
            * 鼠标点击小图显示大图
            */
           $('#sea_zoom_wrap li').each(function (idx) {
               $(this).attr("idx", idx);
               $(this).click(function () {
                   $('#sea_zoom_wrap .current').removeClass('current');
                   $(this).addClass('current');

                   var img = $(this).find('img').attr('src'),
                       iidx = $(this).attr("idx"),
                       small_image = $('#sea_zoom_pic');
                   small_image.attr('idx', iidx);
                   setBtEnable(iidx);
                   small_image.attr('src', getPicBySize(img, 600));
               });
           });

           function setBtEnable(cur) {
               if (cur < 1) {
                   $('.xzoom_prev').addClass('xzoom_prev_disabled');
               } else {
                   $('.xzoom_prev').removeClass('xzoom_prev_disabled');
               }
               if (cur > pic_num - 2) {
                   $('.xzoom_next').addClass('xzoom_next_disabled');
               } else {
                   $('.xzoom_next').removeClass('xzoom_next_disabled');
               }
           }
           $('.xzoom_prev').click(function () {
               var cur = ~~$('#sea_zoom_wrap .current').attr("idx");
               if (cur > 0) {
                   cur = cur - 1;
                   setBtEnable(cur);
                   $('#sea_zoom_wrap li').eq(cur).click();
               }
           });
           $('.xzoom_next').click(function () {
               var cur = ~~$('#sea_zoom_wrap .current').attr("idx");
               if (cur < pic_num - 1) {
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