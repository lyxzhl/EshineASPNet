G.util.post = function(url, data, okfn) {
	G.util.post.pIndex = (G.util.post.pIndex || 0) + 1;

	var iframe = $('<iframe name="pIframe_' + G.util.post.pIndex + '" src="about:blank" style="display:none" width="0" height="0" scrolling="no" allowtransparency="true" frameborder="0"></iframe>').appendTo($(document.body));
	var ipts = [];

	$.each(data, function(k, v) {
		ipts.push('<input type="hidden" name="' + k + '" value="" />');
	});

	if (!/(\?|&(amp;)?)fmt=[^0 &]+/.test(url)) {
		url += (url.indexOf('?') > 0 ? '&' : '?') + 'fmt=1';
	}

	var form = $('<form action="' + url + '" method="post" target="pIframe_' + G.util.post.pIndex + '">' + ipts.join('') + '</form>').appendTo( $(document.body)) ;

	$.each(data, function(k, v) {
		form.children('[name=' + k + ']').val(v);
	});

	iframe[0].callback = function(o) {
		if (typeof okfn == 'function') okfn(o);
		$(this).src = 'about:blank';
		$(this).remove();
		form.remove();
		iframe = form = null;
	};

	if ($.browser.msie && $.browser.version == 6.0) {
		iframe[0].pIndex = G.util.post.pIndex;
		iframe[0].ie6callback = function() {
			form.target = 'pIframe_' + this.pIndex;
			form.submit();
		};
		iframe[0].src = location.protocol + '//st.' + G.domain + '/static_v1/htm/ie6post.htm';
	}
	else {
		form.submit();
	}
};

/**
 * icson的模板处理
 * @author myforchen
 */
G.ui.template = {
	/**
	 * 使用id为tpl的元素内容作为模板，o作为数据，来填充id为bed的元素
	 * 模板内容格式：
	 * &lt;!--something&lt;@list@&gt;listcontent&lt;@_list@&gt;somethingelse--&gt;
	 * @param {String} bedId 模板填充的元素ID, false则直接返回值
	 * @param {Object} o 用来填充的数据
	 * @param {String} tplId 承载模板的元素ID，如果是false模板内容就直接使用TPL参数，如果没有指定tplId就是bedId + '_tpl'
	 * @param {String} TPL 模板内容
	 * @param {Boolean} isReturn 是否作为字符串返回
	 */
	fillWithTPL: function(bedId, o, tplId, TPL, isReturn) {
		if (!o) return;
		if (!tplId && tplId !== false) tplId = bedId + '_tpl';
		TPL = (tplId === false) ? (TPL || '') : $('#' + tplId).html().replace(/^\s*<!--/, "").replace(/-->\s*$/, "");

		var BLOCKS = {};
		TPL = TPL.replace(/<@([0-9a-zA-Z_-]+)@>((.|\s)*?)<@_\1@>/g, function(a0, a1, a2) {
			BLOCKS[a1] = a2;
			return '[#' + a1 + '#]';
		});
		$.each(BLOCKS, function(key, tpl) {
			var ot = [],
				p = o[key];
			if (p) {
				$.each(p, function(pp, tt) {
					ot.push(G.ui.template.fillWithTPL(false, tt, false, tpl.replace(/<_index_>/g, pp - 0 + 1)));
				});
			}

			BLOCKS[key] = ot.join('');
		});

		var htm = TPL.replace(/\{([0-9a-zA-Z_-]+)\}/g, function(a0, a1) {
			return o[a1] !== undefined ? o[a1] : '';
		}).replace(/\[#([0-9a-zA-Z_-]+)#\]/g, function(a0, a1) {
			return BLOCKS[a1] !== undefined ? BLOCKS[a1] : a1;
		}).replace(/^\s+/, '');

		if (isReturn || bedId === false) {
			return htm;
		} else {
			$('#' + bedId).html(htm);
		}
	}
};

/**
 * 弹出层等
 * 规定，普通元素的最大zIndex为1099，全屏模态框的iframe的zIndex为1100、div为1101，弹出层的均大于1101
 * @param {Object} o 传递的参数
 */
G.ui.modal = (function(){
	var fullModal = null;
	return {
		create	: function(obj, fixed){
			var ifr = null;
			if(!obj){
				ifr = fullModal && fullModal.length > 0 ? fullModal : $('<iframe src="javascript:void(0)"></iframe>').css({
					opacity	: 0,
					background	: '#000',
					left	: '0',
					display	: 'none',
					zIndex	: 1100,
					top	: '0',
					position	: 'absolute'
				});

				ifr.css({
					width	: $(window).width() + 'px',
					height	: $(window).height() + 'px'
				});

				ifr.appendTo($('body')).show();
				if(fixed){
					ifr.fixedPosition({
						fixedTo		: 'top',
						fixedTop	: 0,
						fixedLeft	: 0
					});
				} else {
					ifr.css({
						left	: $(window).scrollLeft(),
						top	: $(window).scrollTop()
					});
				}
			} else {
				ifr = $('<iframe style="z-index:-1;width:'+$(obj).innerWidth()+'px;height:'+$(obj).innerHeight()+'px" src="javascript:void(0)" frameborder="0" scrolling="no" width="100%" height="100%"></iframe>').css({
					opacity	: 0,
					background	: '#FFF',
					left	: '0',
					top	: '0',
					position	: 'absolute'
				});
				ifr.appendTo(obj);
			}

			return ifr;
		}
	};
})();

G.ui.popup = {
	_cssLoaded: false,
	_loadCss: function() {
		if (this._cssLoaded) return;
		this._cssLoaded = true;
		var cssFile = G.prefix.st + "static_v1/css/package/package_v1.css";
		if (G.prefix.ssl) {
			cssFile = G.prefix.st_ssl + "static_v1/css/package/package_v1.css";
		}
		var cssExists = false;
		$('link').each(function() {
			if ($(this).attr('href') == cssFile) {
				cssExists = true;
				return false;
			}
		});

		if (!cssExists) $('<link href="' + cssFile + '" rel="stylesheet" type="text/css" charset="utf-8" />').appendTo($('head'));
	},
	_zIndex: 1101,

	/**
	 * 创建一个弹出层
	 * @param {Object} opt 参数设置
	 * @return {
	 * 	close	: function(){}, //关闭
	 * 	show	: function(){}, // 显示
	 * }
	 */
	create: function(opt) {
		this._loadCss();
		var _header = null,
			_content = null,
			_opt = opt || {},
			fixH = _opt.height > 50;

		_opt.width = _opt.width || 500;
		//_opt.fixed = false;
		_opt.fixed = _opt.fixed === false ? false : true;

		var o = $('<div style="box-shadow:2px 2px 4px rgba(0, 0, 0, 0.5);z-index:' + (++this._zIndex) + ';' + (fixH ? ('height:' + _opt.height + 'px') : '') + ';width:' + _opt.width + 'px;" class="layer_global">\
		<div class="layer_global_main">\
			<div class="layer_global_title">\
				<h3><span class="jian">&gt;</span>' + (_opt.title || '温馨提示') + '<span></span></h3>\
				<button title="关闭" ytag="84777"><span class="none">╳</span></button>\
			</div>\
			<div class="layer_global_cont layer_cont_15"></div>\
		</div>\
	</div>');

		o.appendTo($('body'));

		// 定位
		if (_opt.fixed) {
			o.fixedPosition({
				fixedTo: 'top'
			});
		}

		_header = o.find('.layer_global_main .layer_global_title')[0];
		_content = o.find('.layer_global_main .layer_global_cont')[0];

		if (opt.contWidth == '30') $(_content).removeClass('layer_cont_15').addClass('layer_cont_30');

		function _createModal(obj) {
			o.mIframe = G.ui.modal.create(obj, o.ifFixedPosition());
		}

		function _setAtCenter(w, h) {
			if (null == w) w = o.width();
			if (null == h) h = o.height();
			var ww = $(window).width(),
				wh = $(window).height();

			var xw = (_opt.fullscreen && ww < w ? 0 : (ww / 2 - w / 2)),
				xh = (_opt.fullscreen && wh < h ? 0 : (wh / 2 - h / 2));
			if (o.ifFixedPosition()) {
				o.fixedPosition({
					fixedTo: 'top',
					fixedLeft: xw,
					fixedTop: xh
				});
			} else {
				o.css("left", $(window).scrollLeft() + xw + "px");
				o.css("top", $(window).scrollTop() + xh + "px");
			}

			if (_opt.fullscreen && !o.mDiv) {
				var div = $('<div></div>').css({
					opacity: 0.05,
					background: '#000',
					display: 'none',
					zIndex: 1101,
					width: $(window).width() + 'px',
					height: $(window).height() + 'px'
				}).appendTo('body');

				if (o.ifFixedPosition()) {
					div.fixedPosition({
						fixedTo: 'top',
						fixedLeft: 0,
						fixedTop: 0
					});
				} else {
					div.css({
						left: $(window).scrollLeft(),
						top: $(window).scrollTop(),
						position: 'absolute'
					});
				}

				div.show();

				if (!o.ifFixedPosition()) {
					if ($.browser.msie) {
						$("html").css({
							'overflow': "hidden"
						});
					} else {
						$("body").css({
							'overflow': "hidden"
						});
					}
				}
				o.mDiv = div;
			}

			if ($.browser.msie && $.browser.version >= 6.0 && !o.mIframe) {
				_createModal(_opt.fullscreen ? null : o);
			}
		}

		function _close(triggerDefaultAction) {
			if (_opt.fullscreen && o.mDiv) { // 全屏模式销毁模态框
				o.mDiv.remove();
				o.mDiv = null;
				if (o.mIframe) {
					o.mIframe.remove();
					o.mIframe = null;
				}

				if (!o.ifFixedPosition()) {
					if ($.browser.msie) {
						$('html').css({
							'overflow': 'scroll',
							'overflow-x': 'hidden'
						});
					} else {
						$('body').css({
							'overflow': 'scroll',
							'overflow-x': 'hidden'
						});
					}
				}
			}

			if (triggerDefaultAction !== false && $.isFunction(_opt.closeFn)) _opt.closeFn.apply(null);

			o.hide();
		}

		$(_header).children('button').click(_close);

		!_opt.disableDrag && G.ui.drag.enable(o.get(0), _header, {
			fixed: o.ifFixedPosition()
		});
		if (fixH) _setAtCenter(_opt.width, fixH ? _opt.height : 300);
		else _close(); // 默认隐藏

		return {
			onclose: function(closeFn) {
				_opt.closeFn = closeFn;
			},
			close: _close,
			hide: _close,
			show: function() {
				//o.fadeIn(100);
				o.show();
				_setAtCenter();
			},
			paint: function(uFunc) {
				if (!$.isFunction(uFunc)) return;

				var cbObj = {
					header: _header,
					content: _content
				};

				return uFunc.apply(o, [cbObj]);
			},
			setAtCenter: _setAtCenter,
			resize: function(newSize) {
				if (!$.isPlainObject(newSize)) return;
				if (newSize.width) o.css('width', newSize.width + 'px');
				if (newSize.height > 50) {
					o.css('height', newSize.height + 'px');
					$(_content).height(newSize.height - 50);
				}

				_setAtCenter();
			},
			resizeNoCenter: function(newSize) {
				if (!$.isPlainObject(newSize)) return;
				if (newSize.width) o.css('width', newSize.width + 'px');
				if (newSize.height > 50) {
					o.css('height', newSize.height + 'px');
					$(_content).height(newSize.height - 50);
				}

			}
		};
	},
	_msgPopup: null,
	showMsg: function(msg) {
		var args = arguments,
			opt = args[1] || {};
		if ($.type(opt) != 'object') {
			// 兼容map
			opt = {};
			$.each({
				1: 'type',
				2: 'okFn',
				3: 'closeFn',
				4: 'cancelFn',
				5: 'okText',
				6: 'cancelText'
			}, function(k, v) {
				if (args[k] != null) opt[v] = args[k];
			});

			if (opt.okText && opt.cancelText) opt.btns = 3;
		}

		if (!this._msgPopup) {
			this._msgPopup = G.ui.popup.create({
				title: '提示',
				width: 500,
				height: 170,
				fullscreen: 1
			});
		}

		var levels = {
			//0	: 'info',
			1: 'warn',
			2: 'error',
			3: 'right' //,

			//4	: 'help'
		};
		if (!(opt.type in levels)) opt.type = 1;

		if (!$.isArray(msg)) {
			msg = [msg];
		}

		opt.btns = opt.btns || 1;
		this._msgPopup.paint((function(_) {
			return function(uObj) {
				$(uObj.content).empty().html(' <div class="layer_global_mod">\
	<b class="icon icon_msg4 icon_msg4_' + levels[opt.type] + '"></b>' + (msg.length >= 1 ? ('<h4 class="layer_global_tit">' + msg[0] + '</h4>') : '') + '\
	' + (msg.length >= 2 ? ('<p>' + msg[1] + '</p>') : '') + (msg.slice(2, msg.length).join('')) + '\
	<div class="wrap_btn"><a class="btn_strong" href="#" onclick="return false">' + (opt.okText || '确定') + '</a> <a class="btn_common" href="#" onclick="return false">' + (opt.cancelText || '取消') + '</a></div>\
	</div>');

				$(".wrap_btn .btn_strong", uObj.content).click(function() {
					var kill = true;
					if ($.isFunction(opt.okFn)) {
						kill = opt.okFn() !== false;
					}
					if (kill) _.hide(false);
				})[(opt.btns & 1) ? 'show' : 'hide']();

				$(".wrap_btn .btn_common", uObj.content).click(function() {
					var kill = true;
					if ($.isFunction(opt.cancelFn)) {
						kill = opt.cancelFn() !== false;
					}
					if (kill) _.hide(false);
				})[(opt.btns & 2) ? 'show' : 'hide']();

				_.show();
			};
		})(this._msgPopup));

		// setting pop close callback function
		this._msgPopup.onclose($.isFunction(opt.closeFn) ? opt.closeFn : $.noop);
		return this._msgPopup;
	}
};

(function($) {
	var __fixed = {},
		__fixedId = 0,
		__supportsPositionFixed = null,
		supportsPositionFixed = function() {
			if (__supportsPositionFixed === null) {
				var dom = $('<span id="supportsPositionFixed" style="position:fixed;width:1px;height:1px;top:25px;"></span>').appendTo($('body'));
				var offset = dom.offset();
				dom.remove();
				__supportsPositionFixed = (offset.top - $(window).scrollTop()) === 25;
			}
			return Boolean(__supportsPositionFixed);
		},
		__fixCss = false,
		fixCss = function() {
			if (__fixCss !== false) return;
			var _body = $("body");
			var url = "http://st.icson.com/static_v1/img/blank.gif";
			if (G.prefix.ssl) {
				url = G.prefix.st_ssl + "/static_v1/img/blank.gif";
			}
			if ((_body.css("background-image")) == "none") {
				_body.css({
					"background-image": "url(" + url + ")",
					"background-attachment": "fixed"
				});
			} else {
				_body.css("background-attachment", "fixed");
			}
			__fixCss = true;
		};

	$.fn.ifFixedPosition = function() {
		if (!this.attr("id") || this.attr("id").length == 0) return false;
		return !!__fixed[this.attr("id")];
	};
	$.fn.fixedPosition = function(options) {
		var defaults = {
			fixedTo: "bottom",
			fixedTop: 0,
			fixedBottom: 0,
			fixedLeft: false,
			effect: false,
			effectSpeed: 1000
		};

		//var _body = $("body");
		var options = $.extend(defaults, options);

		return this.each(function() {
			var fb = $(this);
			if (!fb.attr("id") || fb.attr("id").length == 0) fb.attr("id", "positionFixedID" + (__fixedId++));
			if (!supportsPositionFixed()) {
				fixCss();
				var expr = "";
				if (options.fixedTo == "top") {
					expr = '$(document).scrollTop()';
					if (options.fixedTop > 0) {
						expr += '+' + options.fixedTop;
					}
				} else {
					expr = '$(document).scrollTop() - $("#' + fb.attr("id") + '").outerHeight() + (document.documentElement.clientHeight || document.body.clientHeight)';
					if (options.fixedBottom > 0) {
						expr += '-' + options.fixedBottom;
					}
				}

				fb.css('position', 'absolute');
				if (fb.length > 0 && fb[0].style && fb[0].style.setExpression) fb[0].style.setExpression('top', 'eval(' + expr + ')');
				else fb.css('top', (options.fixedTop || 0) + 'px');
				if (options.fixedLeft !== false) {
					fb.css('left', $(document).scrollLeft() + (options.fixedLeft - 0) + 'px');
				}
			} else {
				fb.css('position', 'fixed');
				if (options.fixedTo == "top") {
					fb.css('top', (options.fixedTop || 0) + 'px');
				} else {
					fb.css('bottom', (options.fixedBottom || 0) + 'px');
				}
				if (options.fixedLeft !== false) {
					fb.css('left', options.fixedLeft + 'px');
				}
			}

			__fixed[$(this).attr("id")] = 1;
			if (options.effect) {
				switch (options.effect) {
				case "fadeIn":
					fb.hide().fadeIn(options.effectSpeed);
					break;
				case "slideDown":
					fb.hide().slideDown(options.effectSpeed);
					break;
				}
			}
		});
	};
})(jQuery);

/**
 *
 */
G.ui.drag = (function() {
	// 当前拖拽元素
	var _curEle = null;
	// 响应拖拽的元素
	var _curEleLauncher = null;
	// 初始横坐标
	var _x = 0;
	// 初始纵坐标
	var _y = 0;
	// 当前横坐标
	var _cx = false;
	// 当前纵坐标
	var _cy = false;
	// 其他参数
	var _opt = {};

	/**
	 * 移动中的事件
	 * @param {Event} e 产生的事件
	 */
	function _moving(e) {
		e.stopPropagation();
		e.preventDefault();
		if (!_curEle || !_curEleLauncher) return;
		var sl = $(window).scrollLeft();
		var st = $(window).scrollTop();
		var x = _x + e.clientX + sl;
		var y = _y + e.clientY + st;
		// 限制在可见区域内
		x = Math.min(Math.max(x, sl), $(window).width() - $(_curEle).outerWidth() + sl);
		y = Math.min(Math.max(y, st), $(window).height() - $(_curEle).outerHeight() + st);

		if (x < 0) x = 0;
		if (y < 0) y = 0;

		if ($(_curEle).css('position') == 'fixed') {
			$(_curEle).offset({
				left: x,
				top: y
			});
		} else {
			$(_curEle).offset({
				left: x,
				top: y
			});
		}
		_cx = x;
		_cy = y;
	}

	function _start(e) {
		e.stopPropagation();
		e.preventDefault();
		if (!_curEle || !_curEleLauncher) return;
		var sl = $(window).scrollLeft();
		var st = $(window).scrollTop();
		_x = _curEle.offsetLeft - e.clientX - sl;
		_y = _curEle.offsetTop - e.clientY - st;
		if ($(_curEle).css('position') == 'fixed') {
			_x += sl;
			_y += st;
		}

		_cx = false;
		_cy = false;

		var d = _curEleLauncher && _curEleLauncher.setCapture ? _curEleLauncher : document;
		$(d).bind('mousemove.moving', _moving).bind('mouseup.stop', _stop);
		setEventCapture(d);
	}

	function _stop(e) {
		if (!_curEleLauncher) return;

		var d = _curEleLauncher && _curEleLauncher.setCapture ? _curEleLauncher : document;
		$(d).unbind('mousemove.moving');
		$(d).unbind('mouseup.stop');

		if (typeof _opt.onstop == 'function') _opt.onstop.apply(_curEleLauncher);
		if (_opt.fixed && _cx !== false && _cy !== false) {
			var sl = $(window).scrollLeft();
			var st = $(window).scrollTop();
			$(_curEle).fixedPosition({
				fixedTo: 'top',
				fixedTop: _cy < st ? 0 : (_cy - st),
				fixedLeft: _cx < sl ? 0 : (_cx - sl)
			});
		}
		_curEle = null;
		_curEleLauncher = null;
		_x = 0;
		_y = 0;
		releaseEventCapture(d);
	}

	// 设置事件捕获
	function setEventCapture(target) {
		if (target.setCapture) target.setCapture();
		else if (window.captureEvents || document.captureEvents)(window.captureEvents || document.captureEvents)(Event.MouseMove | Event.MouseUp);
	}

	// 释放事件捕获
	function releaseEventCapture(target) {
		if (target.releaseCapture) target.releaseCapture();
		else if (window.releaseEvents || document.releaseEvents)(window.releaseEvents || document.releaseEvents)(Event.MouseMove | Event.MouseUp);
	}

	return {
		enable: function(e, el, opt) {
			if (typeof el == 'string') el = $('#' + el).get(0);
			if (typeof e == 'string') {
				if (!el) el = $('#' + e + '_head').get(0);
				e = $('#' + e).get(0);
			}
			if (!e || !el) return;
			_opt = opt || {};
			$(el).mousedown(function(ee) {
				_curEle = e;
				_curEleLauncher = el;
				_start(ee);
			});
		}
	};
})();

G.ui.droplist = {
	attach: function() {
		// ...
	}
};


G.app.faxian_detail = {
	like: 0, //是否点击过 我喜欢
	likepid: [],
	appointid: 0, // 报名组件id
	appointinitcount: 0,

	loadscript: function(url, callback) {
		url = url + '&t=' + Math.random();
		var script = document.createElement('script');
		script.type = 'text/javascript';
		if (callback) script.onload = script.onreadystatechange = function() {
			if (script.readyState && script.readyState != 'loaded' && script.readyState != 'complete') return;
			script.onreadystatechange = script.onload = null;
			callback();
		};
		script.src = url;
		document.getElementsByTagName('head')[0].appendChild(script);
	},

	centershow: function(j_centerdiv) {
		var _scrollHeight = $(document).scrollTop(),
			//获取当前窗口距离页面顶部高度
			_windowHeight = $(window).height(),
			//获取当前窗口高度
			_windowWidth = $(window).width(),
			//获取当前窗口宽度
			_popupHeight = j_centerdiv.height(),
			//获取弹出层高度
			_popupWeight = j_centerdiv.width(); //获取弹出层宽度
		_posiTop = (_windowHeight - _popupHeight) / 2 + _scrollHeight;
		_posiLeft = (_windowWidth - _popupWeight) / 2;

		j_centerdiv.css("left", _posiLeft + "px").css("top", _posiTop + "px");
		j_centerdiv.css("display", "");
	},

	init: function() {
		var self = this;
		self.pid = pid;
		self.review.getReviewsPage(); //获取总页数，并拉取第一页讨论

		//把赞的代码移上来
		var $ding_html = $('#ding_html');
		$('.new_mod_action').each(function() {
			$(this).find('.new_mod_action_item').eq(0).html( $ding_html.html() ).show();
		});
		$ding_html.html("");

		//分享功能
		var _ptimer = 0,
			$popshare = $('div.new_mod_popshare');
		$('a.new_mod_action_share').mouseover(function() {
			$popshare.addClass('show');
		});
		$popshare.mouseout(function() {
			$(this).removeClass('show');
			clearTimeout(_ptimer);
		});
		$('li.share_leave').bind({
			mouseover: function() {
				clearTimeout(_ptimer);
				$popshare.show().addClass('show');
			},
			mouseout: function() {
				_ptimer = setTimeout(function() {
					$popshare.hide().removeClass('show');
				}, 100)
			}
		});
		
		// 处理设置提醒
		G.app.Component.getAppointCount(self.appointid, function(data){
			$('.fx_mod_goods_setting .fx_tx1').html(G.app.faxian_detail.appointinitcount + parseInt(data));
			$('.fx_mod_goods_setting').show();
		});
		$('.set_remind').click(function(){
			if (!G.logic.login.getLoginUid()) {
				G.ui.popup.showMsg("对不起，您还未登录，请登录后再设置提醒！", 1, function(){location.href = 'https://base.yixun.com/login.html?url='+encodeURIComponent(location.href);},function(){},null,'马上登录','取消');
				return false;
			}
			var html = '<div class="layer_global_mod appoint_dialog_content mod_pop_ico">\
				<b class="icon icon_msg4 icon_msg4_right"></b>\
				<div class="appoint_form">\
					<div class="appoint_form_row mod_pop_con">\
						<h4 style="width:300px;">请留下您的手机号，我们会在开售前第一时间短信提醒您！</h4>\
						<div class="fx_pop_cont" style="margin-bottom:0;">\
							<span>*</span>\
							<label class="appoint_form_label">手机号码：<input type="text" name="tel_num" class="appoint_form_input fx_pop_input"></label>\
							<br><strong class="appoint_form_error">请输入正确的手机号(11位数字)</strong>\
						</div>\
					</div>\
				</div>\
				<div class="wrap_btn appoint_btn_pannel">\
					<a href="#" onclick="return false;" class="btn_strong appoint_btn appoint_btn_ok">确定</a>\
					<a href="#" onclick="return false;" class="btn_common appoint_btn appoint_btn_cancel">关闭</a>\
				</div>\
			</div>';
			var _dialog = G.ui.popup.create({title: "提示", width: 500, height: 220, fullscreen: 1});
			_dialog.paint((function (i) {
		        return function (p) {
		            var n = $(p.content);
		            n.empty().html(html);
		            _dialogId = n.parents(".layer_global").attr("id");
		            
		            G.logic.login.getLoginUser(function(o){
		            	if (o.data && o.data.mobile) {
		            		$("#" + _dialogId + " .appoint_form_input").val(o.data.mobile);
		            	}
					});
		            
		            $("#" + _dialogId + " .appoint_btn_ok").click(function () {
		                $("#" + _dialogId + " .appoint_form_error").html("");
		                var s = $("#" + _dialogId + " .appoint_form input[name=tel_num]").val();
						if (/^[0-9]+$/.test(s) && s.length == 11) {
							_dialog.close();
						    G.app.Component.appoint(G.app.faxian_detail.appointid, {phone: s}, function(){
						    	G.ui.popup._msgPopup = G.ui.popup.create({
									title: '提示',
									width: 530,
									height: 170,
									fullscreen: 1
								});
						        G.ui.popup.showMsg("恭喜您，您已成功设置提醒！感谢您对易迅网的支持！", 3, null,function(){},null,null,'确定');
						        $('.wrap_btn').append('<a href="http://faxian.yixun.com" target="_blank" class="btn_strong" onclick="G.ui.popup._msgPopup.close();">去发现首页</a>');
						        G.app.Component.getAppointCount(G.app.faxian_detail.appointid, function(data){
						        	$('.fx_mod_goods_setting .fx_tx1').html(G.app.faxian_detail.appointinitcount + parseInt(data));
								});
						    }, function(errno, errmsg){
								if (errno == 3 || errno == 1007) {//未登录
									G.ui.popup.showMsg("对不起，您还未登录，请登录后再设置提醒！", 1, function(){location.href = 'https://base.yixun.com/login.html?url='+encodeURIComponent(location.href);},function(){},null,'马上登录','取消');
						        } else if (errno == 1503) {
						        	G.ui.popup.showMsg("对不起，您已经设置过提醒，欢迎关注更多商品！", 1, null,function(){},null,'确定');
						        	$('.wrap_btn').append('<a href="http://faxian.yixun.com" target="_blank" class="btn_strong" onclick="G.ui.popup._msgPopup.close();">去发现首页</a>');
						        } else {
									G.ui.popup.showMsg(errmsg, 1, null,function(){},null,null,'确定');
									$('.wrap_btn').append('<a href="http://faxian.yixun.com" target="_blank" class="btn_strong" onclick="G.ui.popup._msgPopup.close();">去发现首页</a>');
								}
						    }, 1);
		                } else {
		                	$("#" + _dialogId + " .appoint_form_error").text("请输入正确的手机号(11位数字)");
		                	return;
		                }
		            });
		            $("#" + _dialogId + " .appoint_btn_cancel").click(function () {
		                _dialog.close();
		            });
		            i.close();
		        };
		    })(_dialog));
		    $("#" + _dialogId + " .appoint_form_error").html("");
		    _dialog.show();
		});
		
		//PM 要底部也有一个节点
		$('div.fx_content .ewm').before( $('div.fx_mod_goods').clone().addClass('art_goods') );

		$('a.new_ico_wb').click(function() { //#share_weibo
			var title = $('.fx_mod_goods_info h3 a ').eq(0).html(); //商品标题
			var url = location.href;
			self.shareweibo(title, url);
			return false;
		});
		$('a.new_ico_qzone').click(function() { //#share_qzone
			var title = $('.fx_mod_goods_info h3 a ').eq(0).html(); //商品标题
			var url = location.href;
			self.shareqzone(title, url);
			return false;
		});

		$('a[pid]').each(function(k, v) {
			var pid = $(v).attr("pid");

			if (pid && (0 != pid)) {
				self.loadscript("http://faxian.yixun.com/json.php?mod=deservebuy&act=get&pid=" + pid + "&jsonstr=str&callback=G.app.faxian_detail.cbget");
			}
		});

		//赞
		$('.new_mod_action_ding').click(function() {
			var pid = $(this).attr("pid");
			if ($.inArray((pid + "-1"), self.likepid) < 0) {
				$(this).addClass('new_mod_action_ding_on');
				self.loadscript("http://faxian.yixun.com/json.php?mod=deservebuy&act=addone&pid=" + pid + "&type=like&callback=G.app.faxian_detail.cbaddone");
			}
			return false;
		});

		//更新验证码
		$('#vcode >img').click(function(e) {
			self.review.toChangeReviewReplyVCode(e);
			return false;
		});

		$('textarea[name=content]').keyup(function() {
			var c = $.trim( $(this).val() ),
				$num = $('.num >span');

			$num.html(c.length);
			if (c.length > 80) {
				$num.addClass('strong');
			}
			else {
				$num.removeClass('strong');
			}
		});

		$('#dis_submit').hide(); //没有登录先隐藏
		G.logic.login.getLoginUser(function(o) {
			if ((o === false) || (!o.data)) {
				//G.ui.popup.showMsg('您还没有登录');
				$('.fx_talk_link').attr('href', 'https://base.yixun.com/login.html?url=' + location.href);
				return;
			}
			else if (o && o.data && (o.data.bindMobile == 0)) { //未验证手机
				var _msg = '<h4 class="layer_global_tit">您必须手机验证才可以发表回复！</h4><p class="todo_link"><a class="tit" href="http://base.yixun.com/myprofile.html" target="_blank">现在进入验证页面&gt;&gt;</a></p><br/>';

				$('.fx_talk_link').html('请先绑定手机').attr({
					target: "_blank",
					href: 'https://base.yixun.com/myprofile.html'
				}).click(function() {
					var dialog = G.ui.popup.showMsg(_msg, 1, function() {
						G.logic.login.getLoginUser(function(a) {
							if (a && a.data && (a.data.bindMobile == 1)) {
								dialog.close();
								$('.fx_talk_link').css("display", "none");
								$('#dis_submit').show(); //显示发表框
							}
							else {
								dialog.close();
								//a.data.uid='';//清掉它才会拉最新的
								G.logic.login._loginUser.data.uid = '';
								setTimeout(function() {
									dialog.show();
								}, 200);
							}
						}, false, true);

						return false;
					}, null, null, '已完成验证', '关闭');

					return false;
				});
			}
			else {
				G.app.icsonid = o.data.icsonid;
				$('.fx_talk_link').css("display", "none");
				$('#dis_submit').show(); //显示发表框
			}
		}, false, true);

		$('#dis_submit').click(function() { //如果没有登陆就点击了 发表按钮
			if (G.logic.login.ifLogin(this, arguments) === false) return false;

			var uid = G.logic.login.getLoginUid(),
				vCodeInput = $('#vcode_input'),
				codeNum = vCodeInput.val(), /* 检查验证码 */
				content = $.trim($('textarea[name=content]').val());
			if (content.length <= 0) {
				G.ui.popup.showMsg('请填写讨论内容！');
				return false;
			}
			if (content.length < 5 || content.length > 80) {
				G.ui.popup.showMsg('字数长度请在5~80个字之间！');
				return false;
			}
			if (codeNum.length <= 0) {
				G.ui.popup.showMsg('请填写验证码！');
				return false;
			}

			var data = {
				pid: pid,
				content: content,
				codeNum: codeNum
			};

			var nc = '';
			if (nc.length > 0) {
				data['nick'] = nc.val();
			} //if

			var plUrl = G.util.token.addToken('http://pinglun.yixun.com/json.php?mod=review&act=adddiscussion&uid=' + uid,'jq');
			G.util.post(plUrl, data, function(o) {
				//G.app.review.loading.close();
				if (o && o.errno == 0) {
					self.review.clear();
					self.review.getReviewsPage(); //获取总页数，并拉取第一页讨论
					$('textarea[name=content]').val(''); //清空内容
					G.ui.popup.showMsg('您已发表成功!'); //提交发表后，有浮层提示：“您已发表成功”
				}
				else if (o && o.errno == 14) {
					G.ui.popup.showMsg('验证码错误!');
					return false;
				}
				else {
					var em = {
						12: '内容过长，请删减部分内容后继续',
						14: '请填写昵称',
						777: '您所发表的内容可能包含敏感信息，我们会尽快审核，当管理员审核通过后，讨论将显示在页面中。',
						600: '您的发言频率过快，请稍候再发！',
						602: '您的经验值不足，无法发表讨论，如有任何疑问请您发表咨询',
						776: '您所发表的讨论中含有不恰当的信息，请您检查无误后再发表。'
					};
					if (o && (o.errno - 0) in em) {
						return G.ui.popup.showMsg(em[o.errno]);
					}
					G.ui.popup.showMsg('抱歉，发表讨论失败！');
				}
			});
			$('#vcode_input').val(''); //发表后，输入的验证码清空

			//更新验证码
			plUrl = G.util.token.addToken('http://pinglun.yixun.com/json.php?jsontype=str&mod=review&act=vcode&_=' + Math.random(),'jq');
			$('.code_num img').attr('src', plUrl);

			return false;
		});

		//处理 scroll 绑定
		var fx_top = $('div.fx_top');
		var $container = $('div.fx_container_inner'),
			win_height = $(window).height();
		var fx_header_pos = $('div.fx_header').offset();
		var $fix_btn = $('div.fx_fix');
		var scroll_top;
		$(window).scroll(function() {
			scroll_top = self.scrolltop();
			if (scroll_top > fx_top.offset().top && scroll_top < ($container.offset().top + $container.height() - win_height)) {
				$fix_btn.show();
			}
			else {
				$fix_btn.hide();
			}
		});

		//商品图 160x160 换 120x120
		//$('.fx_mod_goods_img >img').attr('src', $('.fx_mod_goods_img >img').attr('src').replace(/pic160/, 'small'));
		$('.fx_mod_goods_img >img').each(function(k, v) {
			$(this).attr('src', $(this).attr('src').replace(/pic160/, 'small'));
		});

		//去掉面包屑
		$('.fx_crumbs').hide();
		$('.fx_nav_inner li').eq(3).find('a').addClass('selected'); //导航选中态

		//公共组件初始化
		G.footer.initBakTop();
	}, //init

	scrolltop: function() {
		var scrollTop = 0;
		if (document.documentElement && document.documentElement.scrollTop) {
			scrollTop = document.documentElement.scrollTop;
		}
		else if (document.body) {
			scrollTop = document.body.scrollTop;
		}
		return scrollTop;
	},

	cbget: function(data) {
		if (data.data && data.data.like) {
			$('a[pid]').find('.c_tx2').html(data.data.like);
		}
	},

	cbaddone: function(data) {
		if (0 == data.errcode) {
			var $nodes = $('a[pid]'),
				$bros = $nodes.next();
			$nodes.hide();
			$bros.find('.c_tx2').html(parseInt( $nodes.find('.c_tx2').html() ) + 1);
			$bros.show();

			if ($.inArray((data.pid + "-1"), G.app.faxian_detail.likepid) < 0) {
				G.app.faxian_detail.likepid.push(data.pid + "-1");
			}
		} //if
	},

	//评论
	review: {
		data: {},
		currentpage: 1, //当前评论页
		discussiontotal: 0, //评论总页数
		_jhistory: {}, //前端保存的投票过的id

		//更换验证码
		toChangeReviewReplyVCode: function(e) {
			var srcElement = $(e.srcElement || e.target);
			var plUrl = G.util.token.addToken('http://pinglun.yixun.com/json.php?jsontype=str&mod=review&act=vcode&_=' + Math.random(),'jq');
			srcElement.attr('src', plUrl);
			srcElement.parent().prevAll('#vcode_input').focus();
		},

		//生成 paginator 部分HTML
		paginator: function() {
			var self = this;
			if (self.discussiontotal == 0) {
				$('div.paginator').hide().html('').show();
				return false;
			}

			//else
			var const_num = 5;
			var html_ary = [],
				html_str='',
				dot_str = '<span>...</span>';
			var js_tpl = ' onclick="G.app.faxian_detail.review.getReviews(null, {page_holder}); return false;"',
				js_pre = js_tpl.replace(/{page_holder}/, 'G.app.faxian_detail.review.currentpage-1'),
				js_next = js_tpl.replace(/{page_holder}/, 'G.app.faxian_detail.review.currentpage+1');

			var js_page='';
			if (const_num >= self.discussiontotal) { //直接呈现
				for(var _page=1; _page<=self.discussiontotal; _page++) {
					if (_page == self.currentpage) {
						html_ary.push('<span class="page-this">'+_page+'</span>'); //disable
					}
					else {
						js_page = js_tpl.replace(/{page_holder}/, _page);
						html_ary.push('<a href="javascript:;" '+ js_page +'>'+_page+'</a>');
					}
				}
			}
			else { //计算点的位置
				var dash_1 = false, dash_2 = false;
				for(var _page=1; _page<=self.discussiontotal; _page++) {
					if (_page == self.currentpage) {
						html_ary.push('<span class="page-this">'+_page+'</span>'); //disable
					}
					else { // <a>, '...', or nothing.
						if (self.currentpage <= 3) { //最左
							if (_page < self.currentpage || _page <= 3 || _page == self.discussiontotal) {
								js_page = js_tpl.replace(/{page_holder}/, _page);
								html_ary.push('<a href="javascript:;" '+ js_page +'>'+_page+'</a>');
							}
							else {
								if (! dash_1) {
									html_ary.push( dot_str );
									dash_1 = true;
								}
							}
						}
						else if (self.currentpage >= (self.discussiontotal-2)) { //最右
							if (_page == 1 || _page >= (self.discussiontotal-2) ) {
								js_page = js_tpl.replace(/{page_holder}/, _page);
								html_ary.push('<a href="javascript:;" '+ js_page +'>'+_page+'</a>');
							}
							else {
								if (! dash_1) {
									html_ary.push( dot_str );
									dash_1 = true;
								}
							}
						}
						else { //中间
							if (_page == 1 || _page == self.discussiontotal || (_page >= (self.currentpage-1) && _page <= (self.currentpage+1))) {
								js_page = js_tpl.replace(/{page_holder}/, _page);
								html_ary.push('<a href="javascript:;" '+ js_page +'>'+_page+'</a>');
							}
							else {
								if (_page < self.currentpage) { //dash_1
									if (! dash_1) {
										html_ary.push( dot_str );
										dash_1 = true;
									}
								}
								else { //dash_2
									if (! dash_2) {
										html_ary.push( dot_str );
										dash_2 = true;
									}
								}
							}
						}
					}
				}
			}

			if (self.currentpage == 1) {
				html_ary.push('<span class="page-start">上一页</span>'); //disable
			}
			else {
				html_ary.push('<a href="javascript:;" class="page-pre" ' + js_pre + '>上一页</a>');
			}
			if (self.discussiontotal <= self.currentpage) {
				html_ary.push('<span class="page-end">下一页</span>'); //disable
			}
			else {
				html_ary.push('<a href="javascript:;" class="page-next" ' + js_next + '>下一页</a>');
			}

			html_str = html_ary.join('');
			$('div.paginator').hide().html(html_str).show();
		},

		//获取总页数
		getReviewsPage: function() {
			var self = this;
			var plUrl = G.util.token.addToken('http://pinglun.yixun.com/json1.php?mod=reviews&act=getproperty&jsontype=str&pid=' + G.app.faxian_detail.pid,'jq');
			$.get(plUrl, function(o) {
				//self._updateReviewStatus(o);
				if (o.discussion <= 0 || o.errno || o.errCode) {
					/* empty */
				}
				else {
					self.discussiontotal = Math.ceil(o.discussion / 5);
					self.getReviews('', 1); //拉取第一页讨论
				}
			}, 'jsonp');
		},

		//获取讨论
		getReviews: function(type, curpage) {
			curpage = parseInt(curpage);
			if (isNaN(curpage) || curpage == 0) {
				curpage = 1;
			}

			var self = this;
			if (curpage in self.data) { //缓存里有？
				self._printReviews(self.data[ curpage ]);
				self.currentpage = curpage;
				self.paginator(); //paginator flush
				return;
			}

			//因为cgi接口写死了每次只能拉10个，这里每页展示五个，就需要这样了。
			svr_page = parseInt((curpage + 1) / 2);
			if (!svr_page || svr_page < 1) {
				svr_page = 1;
			}

			var plUrl = G.util.token.addToken('http://pinglun.yixun.com/json1.php?mod=reviews&act=getreviews&jsontype=str&pid=' + G.app.faxian_detail.pid + '&type=discussion' + '&page=' + svr_page,'jq');
			$.get(plUrl, function(o) {
				if (o && !o.errno && !o.errCode) {
					//self._c.reviews = type;
					var page_1 = (svr_page * 2 - 1).toString(),
						page_2 = (svr_page * 2).toString();

					$.each(o, function(k, v) {
						if (k < 5) {
							if (! (page_1 in self.data)) {
								self.data[ page_1 ] = [];
							}
							self.data[ page_1 ].push(v);
						}
						else {
							if (! (page_2 in self.data)) {
								self.data[ page_2 ] = [];
							}
							self.data[ page_2 ].push(v);
						}
					});

					self._printReviews( self.data[ curpage ] );
					self.currentpage = curpage;
					self.paginator(); //paginator flush
				}
				else {
					$('#review_content').empty().html('加载讨论内容失败');
				}
			}, 'jsonp');

			$('#review_content').empty().html('<span class="loading_58_58">正在加载中</span>');
		},

		//顶
		setLike: function() {
			var self = G.app.faxian_detail.review,
				rid = $(this).attr('rup');

			if (self._jhistory[rid] == 1) {
				G.ui.popup.showMsg('您已经投过票了。');
				return false;
			}
			self._judgeReview(rid, 4 /* 讨论是4 rtype*/ , 1, $(this));
		},

		//给它投票
		_judgeReview: function(rid, rtype, option, btnTarget) {
			var self = G.app.faxian_detail.review;
			if (G.logic.login.ifLogin(this, arguments) === false) return;

			var uid = G.logic.login.getLoginUid();
			var plUrl = G.util.token.addToken('http://pinglun.yixun.com/json1.php?mod=reviews&act=judge&fmt=1&uid=' + uid,'jq');
			G.util.post(plUrl, {
				review_id: rid,
				type: rtype,
				option: option,
				pid: G.app.faxian_detail.pid
			}, function(o) {
				if (o && o.errno == 0) {
					self._jhistory[rid] = 1;
					var num = parseInt( btnTarget.find('strong.c_tx2').html() ) || 0;
					num += 1;
					btnTarget.html('已顶（<strong class="c_tx2">' + num + '</strong>）');
				}
				else {
					return G.ui.popup.showMsg('对不起，操作失败');
				}
			});
		},

		//显示讨论列表
		_printReviews: function(list) {
			var self = G.app.faxian_detail.review,
				$review_content = $('#review_content');
			var replies_tpl = '<div class="fx_discuss_rep"><h4><i></i>易迅网回复</h4><div class="fx_discuss_repcont">{cnt}</div><b>◆</b></div>';
			var replies_cnt;
			$.each(list, function(k, v) {
				v = self._encode(v);
				v.content_displayed = v.content.replace(/\n/g, " ").replace(/\s{4,}/g, ' ');
				v.datetime = self.timeFormat(v.create_time, 'y-m-d h:i:s');
				if (('replies' in v) && (v['replies'].length > 0) && ('content' in v['replies'][0])) {
					v.replies_content = G.ui.template.fillWithTPL(false, { cnt: v['replies'][0]['content'] }, false, replies_tpl, true);
				}

				list[k] = v;
			});

			//unbind event
			$('a[rup]', $review_content).unbind('click', self.setLike);
			if (list.length < 1) {
				$review_content.empty().html('当前还没有该商品的讨论哦');
			}
			else {
				$review_content.hide().empty();
				$review_content.html( G.ui.template.fillWithTPL(false, { list: list }, 'review_content_tpl'));
				$review_content.show();

				//bind event
				$('a[rup]', $review_content).bind('click', self.setLike);
			}
		},

		clear: function() {
			var self = this;
			self.data = {};
			self.currentpage = 1;
			self.discussiontotal = 0;
			//_jhistory 保留
		},

		_encode: function(arr) {
			var self = this,
				newArr = {};
			$.each(arr, function(_k, _v) {
				newArr[_k] = typeof _v == 'string' ? self._encodeHtml(_v) : _v;
			});
			return newArr;
		},

		_encodeHtml: function(str) {
			return str.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/'/g, "&#039;").replace(/"/g, "&quot;");
		},

		/**
		 * 格式化时间戳
		 * @param {Integer} ts 待转换时间戳
		 * @param {String} fstr 格式串如y-m-d h:i:s 不区分大小写
		 */
		timeFormat: function(ts, fstr) {
			var d = G.app.faxian_detail.review.getTimeInfo(ts);
			var r = {
				y: d.year,
				m: d.month,
				d: d.date,
				h: d.hour,
				i: d.minute,
				s: d.sec,
				w: d.week
			};
			$.each(r, function(k, v) {
				if (k != 'y' && v < 10) r[k] = '0' + v;
			});
			return fstr.replace(/(?!\\)(y|m|d|h|i|s|w)/gi, function(a0, a1) {
				return r[a1.toLowerCase()];
			});
		},

		/**
		 * 时间戳转换成时间对象
		 */
		getTimeInfo: function(t) {
			var week = ["星期天", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"];
			var d = new Date(t * 1000);
			return {
				year: d.getFullYear(),
				month: d.getMonth() + 1,
				date: d.getDate(),
				hour: d.getHours(),
				minute: d.getMinutes(),
				sec: d.getSeconds(),
				week: week[d.getDay()]
			};
		}
	},

	shareweibo: function(name, page) {
		var url = "http://v.t.qq.com/share/share.php?title=";
		var s = '我在#易迅发现#发现了一个好东西,“' + name + '”：';
		page = page + '?YTAG=0.190500001300000';
		url += encodeURIComponent(s);
		url += "&url=" + encodeURIComponent(page) + "&size=http://faxian.yixun.com";

		window.open(url);
		return false;
	},

	shareqzone: function(name, page) {
		var summary = '我在#易迅发现#发现了一个好东西,“' + name + '”：' + page;
		page = page + '?YTAG=0.190500002300000';
		var p = {
			url: page,
			showcount: '1',
			/*是否显示分享总数,显示：'1'，不显示：'0' */
			desc: '易迅发现',
			/*默认分享理由(可选)*/
			summary: summary,
			/*分享摘要(可选)*/
			title: '易迅发现，为您精心挑选 发现生活惊喜！',
			/*分享标题(可选)*/
			site: 'http://faxian.yixun.com/',
			/*分享来源 如：腾讯网(可选)*/
			pics: '',
			/*分享图片的路径(可选)*/
			style: '203',
			width: 98,
			height: 22
		};
		var s = [];
		for (var i in p) {
			s.push(i + '=' + encodeURIComponent(p[i] || ''));
		}
		var url = "http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?" + s.join('&');
		window.open(url);
		return false;
	}
};

$(function() {
	G.app.faxian_detail.init()
});

/*  |xGv00|97c833d58c1d7c0b4d251225579b5517 */