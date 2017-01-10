/*
 * name: common.lazyloader.js
 * author: aronhuang
 * usage:
 new oxLazyloader({
    container: 'document',// 容器 默认为document
	imgLazyAttr: 'data-oxlazy-img', //img lazyload属性名，值为图片真实地址 默认为 data-oxlazy-img
	moduleLazyAttr: 'data-oxlazy-module', //module lazyload属性名，值为module ID, ID作为回调事件的参数 默认为 data-oxlazy-module
	autoDestroy: true, // lazyload内容都加载完成时，是否自动停止监听 默认true
	dynamic: false, //是否有动态的内容插入 默认 false
	threshold: 30, //预加载的距离 默认 100 也可以为每个模块单独设置 例子参看模块1结构
	moduleLoadCallback: moduleLoadCallback // 带 moduleLazyAttr值 和 module容器为参数
});
**/
define("common.lazyloader.5", function(require, exports, module) {
    var oxLazyloader = function(options){
		this.options = $.extend({}, oxLazyloader.defaults, options);
		this._init();
	}


	oxLazyloader.prototype = {
		constructor: 'oxLazyloader',

		_init: function(){
			var opts = this.options;
			this.container = opts.container && $(opts.container).length !== 0 ? $(opts.container) : $(document);
			//若无动态插入的内容,缓存待加载的内容
			if (!opts.dynamic) {
				this._filterItems();
				if (this.imgLazyItems.length === 0 && this.moduleLazyItems.length === 0) {
					return ; //无加载内容 return
				}
			}
			this._bindEvent();
			this._loadItems();//初始化时，load一次
		},

		/*
		 * 获取需lazyload的图片 和模块
		*/
		_filterItems: function(){
			var opts = this.options;
			this.imgLazyItems = this.container.find('[' + opts.imgLazyAttr + ']');
			this.moduleLazyItems = this.container.find('[' + opts.moduleLazyAttr + ']');
		},

		_bindEvent: function(){
			var self = this;
			this._loadFn = function(){
				self._loadItems();
			}
			$(window).bind('resize.' + this.constructor + ' scroll.'+ this.constructor, this._loadFn);
		},

		/*
		 * 加载lazy内容
		*/
		_loadItems: function(){
			//dynamic为true(存在动态内容)时，每次都取一次待加载内容
			var opts = this.options, self = this;
			if (opts.dynamic) {
				this._filterItems();
			}
			this._loadImgItems();
			this._loadModuleItems();
			//无动态插入时，更新待加载内容
			if (!opts.dynamic) {
				this._filterItems();
				//完全加载时，若autoDestroy为true，执行destroy
				if (this.imgLazyItems.length === 0 && this.moduleLazyItems.length === 0 && opts.autoDestroy) {
					self.destroy();
				}
			}
		},


		/*
		 * 加载图片
		*/
		_loadImgItems: function(){
			var opts = this.options, self = this, attr = opts.imgLazyAttr, items = this.imgLazyItems;
			$.each(items, function(){
				var item = $(this);
				if (self._isInViewport(item)) {
					var src = item.attr(attr);
					item.attr('src', src).removeAttr(attr);
				}
			});
		},

		/*
		 * 加载模块
		*/
		_loadModuleItems: function(){
			var opts = this.options, self = this, attr = opts.moduleLazyAttr, callback = opts.moduleLoadCallback, items = this.moduleLazyItems;
			$.each(items, function(){
				var item = $(this);
				if (self._isInViewport(item)) {
					var id = item.attr(attr);
					item.removeAttr(attr);
					if (typeof callback == 'function') {
						callback(id, item);
					}
				}
			});
		},
		

		/*
		 * 是否在视窗中 暂只考虑垂直方向
		*/
		_isInViewport: function(item){
			var win = $(window),
				scrollTop = win.scrollTop(),
				threshold = !isNaN(item.data('threshold')) ? item.data('threshold') : this.options.threshold,
				maxTop = scrollTop + win.height() + threshold,
				minTop = scrollTop - threshold,
				itemTop = item.offset().top,
				itemBottom = itemTop + item.outerHeight();
			if (itemTop > maxTop || itemBottom < minTop) {
				return false;
			}
			return true;
		},

		/*
		 * 停止监听
		*/
		destroy: function(){
			$(window).unbind('resize.' + this.constructor + ' scroll.'+ this.constructor, this._loadFn);
		}
	}

	

	/*
	 * static function
	 * 替换Html代码中src
	*/
	oxLazyloader.toLazyloadHtml = function(html, imgLazyAttr, placeholder){
		var reg;
		imgLazyAttr = imgLazyAttr || this.defaults.imgLazyAttr;
		placeholder = placeholder || this.defaults.placeholder;
		reg = /(<img.*?)src=["']([^"']+)["'](.*?>)/gi;
		return html.replace(reg, '$1src=\"'+placeholder+'\" '+imgLazyAttr+'=\"$2\" $3');
	}	

	/*
	 * 默认配置
	*/
	oxLazyloader.defaults = {
		container: 'document',
		placeholder: 'http://static.gtimg.com/icson/img/common/blank.png', //占位图地址
		imgLazyAttr: 'data-oxlazy-img', //img lazyload属性名，值为图片真实地址
		moduleLazyAttr: 'data-oxlazy-module', //module lazyload属性名，值为module ID, ID作为回调事件的参数
		autoDestroy: true, //容器内的图片都加载完成时，是否自动停止监听
		dynamic: false, //是否有动态的内容插入
		threshold: 100, //预加载的距离
		moduleLoadCallback: null
	}

	return oxLazyloader;
});/*  |xGv00|4798facdb33ed540c57b24d438a7fce0 */