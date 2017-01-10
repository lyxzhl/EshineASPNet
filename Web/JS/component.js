// 动态读CGI专用域名
G.DOMAIN.R_EVENT_ICSON_COM = G.DOMAIN.R_EVENT_ICSON_COM || "event.api." + document.domain;

G.app.Component = {
	// 优惠券接口
	getCoupon : function(id, data, onSuccess, onError, special) {
		var host = special ? 'fajiang.' + document.domain : 'event.' + document.domain;
		G.app.Component.sendRequest2(id, 'get', host, data, onSuccess, onError);
	},
	
	// 发送短信
	sendMessage : function(id, data, onSuccess, onError) {
		G.util.post('http://event.' + document.domain + '/component-' + id + '/send.html', $.extend({}, data), function(ret) {
			if(!ret.errno) {
				if(onSuccess && $.isFunction(onSuccess))
					onSuccess();
			} else {
				if(onError && $.isFunction(onError)) {
					onError(ret.errno, G.app.Component.getErrMsg(ret.errno, ret.errmsg));
				}
			}
		});
	},
	
	// 投票
	toVote : function(id, data, onSuccess, onError) {
		G.util.post('http://event.' + document.domain + '/component-' + id + '/vote.html', $.extend({}, data), function(ret) {
			if(!ret.errno) {
				if(onSuccess && $.isFunction(onSuccess))
					onSuccess(ret.data);
			} else {
				if(onError && $.isFunction(onError)) {
					onError(ret.errno, G.app.Component.getErrMsg(ret.errno, ret.errmsg));
				}
			}
		});
	},

	// 签到
	sign : function(id, data, onSuccess, onError) {
		G.app.Component.sendRequest(id, 'sign', 'set', data, onSuccess, onError);
	},

	// 获取签到信息
	getSign : function(id, data, onSuccess, onError) {
		G.app.Component.sendRequest(id, 'getsign', 'get', data, onSuccess, onError);
	},

	//分享
	share : function(id, data, onSuccess, onError,special){
		var host = special ? 'fenxiang.' + document.domain : 'event.' + document.domain;
		G.app.Component.sendRequest2(id, 'share', host, data, onSuccess, onError);
	},
	//分享上报
	report : function(id, data, onSuccess, onError,special){
		var host = special ? 'fenxiang.' + document.domain : 'event.' + document.domain;
		G.app.Component.sendRequest2(id, 'report', host, data, onSuccess, onError);
	},
	
	// 获取CDKey记录
	getCDKey : function(id, data, onSuccess, onError) {
		G.app.Component.sendRequest(id, 'getCDKey', 'get', data, onSuccess, onError);
	},

	// 通用组件请求接口
	sendRequest : function(id, act, type, data, onSuccess, onError) {
		domain = (type == "get") ? G.DOMAIN.R_EVENT_ICSON_COM : G.DOMAIN.EVENT_ICSON_COM;
		d = new Date();
		G.util.post('http://' + domain + '/component-' + id + '/' + act + '.html?ts=' + d.getTime(), $.extend({}, data), function(ret) {
			if(!ret.errno) {
				if(onSuccess && $.isFunction(onSuccess))
					onSuccess(ret.data);
			} else {
				if(onError && $.isFunction(onError)) {
					onError(ret.errno, G.app.Component.getErrMsg(ret.errno, ret.errmsg));
				}
			}
		});		
	},

	sendRequest2 : function(id, cmd, host, data, onSuccess, onError) {
		host = host || 'event.' + document.domain;
		data = $.extend({}, data);
		G.util.post('http://' + host + '/component-' + id + '/' + cmd + '.html', data, function(ret) {
			if(!ret.errno) {
				if(onSuccess && $.isFunction(onSuccess))
					onSuccess(ret.data);
			} else {
				if(onError && $.isFunction(onError)) {
					onError(ret.errno, G.app.Component.getErrMsg(ret.errno, ret.errmsg));
				}
			}
		});
	},

	// functions for appoint
	appoint : function(id, data, onSuccess, onError, special){
		var host = special ? 'yuyue.' + document.domain : 'event.' + document.domain;
		G.app.Component.sendRequest2(id, 'appoint', host, data, onSuccess, onError);
		//G.app.Component.sendRequest(id, 'appoint', 'set', data, onSuccess, onError);
	},

	getAppointConfig : function(id, onSuccess){
		$.ajax({
			url : 'http://event.' + document.domain + '/event/appoint_' + id + '.js',
			type : 'get',
			crossDomain : true,
			dataType : 'script',
			scriptCharset : 'gb2312',
			success : function() {
				if($.isFunction(onSuccess))
					onSuccess(window['APPOINT_DATA_' + id]);
			}
		});
	},

	getAppointVerifyCode : function(id, data, onSuccess, onError, special){
		var host = special ? 'yuyue.' + document.domain : 'event.' + document.domain;
		G.app.Component.sendRequest2(id, 'getVerifyCode', host, data, onSuccess, onError);
		//G.app.Component.sendRequest(id, 'getVerifyCode', 'set', {}, onSuccess, onError);
	},

	getUserAppointStatus : function(id, onSuccess, onError){
		G.app.Component.sendRequest(id, 'getUserStatus', 'get', {}, onSuccess, onError);
	},

	getAppointCount : function(id, onSuccess, onError){
		G.app.Component.sendRequest(id, 'getCount', 'get', {}, onSuccess, onError);
	},

	// End functions for appoint 

	getVerifyCodeUrl : function() {
		return 'http://ecclogin.' + document.domain + '/login/authcode?th=' + document.domain + '&t=' + Math.random();
	},


	// 错误码与消息
	_errors : {
		1001 : "无效的请求，请确认信息正确后再试！",
		1002 : "用户信息获取失败，请稍后再试！",
		1003 : "组件不在有效期",
		1004 : "访问频率过快，请稍后再试！",
		1005 : "未找到相应验证配置",
		1006 : "服务器繁忙",
		1007 : "您需要登录后进行下一步操作。",
		1008 : "未知错误",
		1100 : "不是有效的领券来源",
		1101 : "超过领券次数",
		1102 : "领过关联优惠券",
		1103 : "优惠券已发完",
		1104 : "优惠券获取失败",
		5001 : "只有新用户可以使用",
		5002 : "只有老用户可以使用",
		5003 : "您的等级无法满足要求",
		5004 : "您需要绑定手机后进行下一步操作",
		5005 : "您需要绑定邮箱吼进行下一步操作",
		5006 : "只有预约用户可以使用",
		5041 : "只有QQ用户可以使用",
		5042 : "只有QQ会员可以使用",
		5043 : "只有QQ年费会员可以使用",
		5044 : "只有黄钻会员可以使用",
		5045 : "只有黄钻年费会员可以使用",
		5046 : "只有蓝钻会员可以使用",
		5047 : "只有蓝钻年费会员可以使用",
		5048 : "只有绿钻会员可以使用",
		5080 : "您的订单金额无法满足要求",
		5081 : "您的订单时间无法满足要求",
		5082 : "您的支付方式无法满足要求",
		5083 : "您的订单商品无法满足要求",
		5084 : "只限当日订单可以使用"
	},
	// 自定义错误消息
	setErrMsg : function(errors) {
		G.app.Component._diyErrors = errors;
	},
	// 获取错误消息
	getErrMsg : function(errno, default_msg) {
		if(G.app.Component._diyErrors && G.app.Component._diyErrors[errno])
			return G.app.Component._diyErrors[errno];
		else if(G.app.Component._errors && G.app.Component._errors[errno])
			return G.app.Component._errors[errno];
		else
			return default_msg || '';
	}
};

G.app.old = G.app.old || {};

G.app.old.Lottery = {

	lottery : function(act_id, data, clbkFunc, special) {
		var host = special ? 'choujiang.' + document.domain : 'event.' + document.domain;
		G.util.post('http://' + host + '/json.php?mod=lotteryge&act=order&sn=' + act_id, $.extend({}, data), function(ret) {
			if($.isFunction(clbkFunc))
				clbkFunc(ret);
		});
	},

	getRecentAwardList : function(act_id, clbkFunc) {
		$.ajax({
			url : 'http://event.' + document.domain + '/event/awards_' + act_id + '.js',
			type : 'get',
			crossDomain : true,
			dataType : 'script',
			scriptCharset : 'gb2312',
			success : function() {
				if(typeof(window['award' + act_id]) != "undefined" && !window['award' + act_id]['errno'] && clbkFunc && $.isFunction(clbkFunc))
					clbkFunc(window['award' + act_id]['reward_info']);
			}
		});
	},

	getUserAwardList : function(act_id, onSuccess, onError) {
		G.util.post('http://event.api.' + document.domain + '/json.php?mod=lotteryge&act=getAwardNum', { act_id : act_id }, function(ret) {
			if(!ret.errno) {
				if($.isFunction(onSuccess))
					onSuccess(ret.data);
			} else {
				if($.isFunction(onError))
					onError(ret.errno, ret.message);
			}
		});
	},

	getUserRemainCount : function(act_id, onSuccess, onError) {
		G.util.post('http://event.api.' + document.domain + '/json.php?mod=lotteryge&act=remainCnt', { act_id : act_id }, function(ret) {
			if(!ret.errno) {
				if($.isFunction(onSuccess))
					onSuccess(ret.remain_cnt, ret.remain_all_cnt);
			} else {
				if($.isFunction(onError))
					onError(ret.errno);
			}
		});
	},

	share : function(act_id, onSuccess, onError, special) {
		var host = special ? 'choujiang.' + document.domain : 'event.' + document.domain;
		G.util.post('http://' + host + '/json.php?mod=lotteryge&act=share', { act_id : act_id }, function(ret) {
			if(!ret.errno) {
				if($.isFunction(onSuccess))
					onSuccess();
			} else {
				if($.isFunction(onError))
					onError(ret.errno);
			}
		});
	}
}/*  |xGv00|e60092366e66da2ad8387e6d0d02744b */