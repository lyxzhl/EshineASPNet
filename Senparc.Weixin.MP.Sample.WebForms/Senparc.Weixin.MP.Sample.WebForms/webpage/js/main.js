$.fn.strFormat = function(args) {
	var result = this.html();
	if (arguments.length > 0) {
		if (arguments.length == 1 && typeof(args) == "object") {
			for (var key in args) {
				if (args[key] != undefined) {
					var reg = new RegExp("({" + key + "})", "g");
					result = result.replace(reg, args[key]);
				}
			}
		} else {
			for (var i = 0; i < arguments.length; i++) {
				if (arguments[i] != undefined) {
					var reg = new RegExp("({[" + i + "]})", "g");
					result = result.replace(reg, arguments[i]);
				}
			}
		}
	}
	return result;
}

function callAjaxJson(url, data, callback) {
	var msg = "";
	$.ajax({
		type: "post",
		async: true,
		data: data,
		url: url,
		success: function(json) {
			callback(json);
		},
		error: function() {
			//myApp.alert($.fn.showErrorCode("3001"));
		}
	});
	return msg;
}

function strJsonFormat(str, json) {
	if (str.length > 0 && typeof(json) == "object") {
		for (var key in json) {
			if (json[key] != undefined) {
				str = str.replace("{" + key + "}", json[key]);
			}
		}
	}
	return str;
}

function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return decodeURIComponent(r[2]); return null;
}

//var jsonList = [{
//    "memberid": "115", "nickname": "索菲亚", "gender": "女", "age": "22", "signature": "美丑不定 土洋有时", "introduction": "高级品酒师", "grade": "0", "photo": "http://www.imxinshui.com/images/headphoto/2015112316390454.jpeg", "province": "上海",
//    "city": "徐汇", "height": "", "weight": "", "waist": "", "style": "萌妹子", "vocation": "", "education": "硕士", "oversea": "", "interest": "", "usid_ronglianyun_voipAccount": "85535900000101", "usid_ronglianyun_voipPwd": "b6PDwAc4", "type": "2", "o2oswitch": "1",
//    "services": "葡萄酒品鉴，吃饭，ktv，打球，看电影，逛街服饰搭配建议", "servicetime": "协商", "Column1": "0", "distance": "10km"
//}, {
//    "memberid": "132", "nickname": "Leesin", "gender": "男", "age": "25", "signature": "等待我的天使", "introduction": "运动狂",
//    "grade": "3", "photo": "http://wx.qlogo.cn/mmopen/jhvWfTVEIdnbZ5BvqZbl9ibmxVHJ5w4yhQJbEibFUHMPyX5Q7B0gOvuCKEFWHUCibxic6lqAKKuPQeoOlC2hQsBiakJic8w4t7iap4d/0", "province": "上海", "city": "上海", "height": "171cm", "weight": "56kg", "waist": "41", "style": "",
//    "vocation": "", "education": "", "oversea": "", "interest": "篮球 健身", "usid_ronglianyun_voipAccount": "85535900000116", "usid_ronglianyun_voipPwd": "WSn8lcL6", "type": "2", "o2oswitch": "1", "services": "💻🏀⚽️🏐️🏓️🎮👊约人旅行", "servicetime": "随时",
//    "Column1": "0", "distance": "10km"
//}, {
//    "memberid": "146", "nickname": "Sophia QIAN ❁҉҉҉҉҉҉҉҉", "gender": "女", "age": "", "signature": "", "introduction": "", "grade": "0",
//    "photo": "http://wx.qlogo.cn/mmopen/Elga8gcEyAHm0dQUXVuSTKsqibnSzCQtdaSFzibbG7PbrqKu2El7xibHdfiaM1hhLQiadJByQYqv7lRAMGTxWZ7tFnKmjTAfw8kwT/0", "province": "上海", "city": "长宁", "height": "", "weight": "", "waist": "", "style": "", "vocation": "",
//    "education": "", "oversea": "", "interest": "", "usid_ronglianyun_voipAccount": "", "usid_ronglianyun_voipPwd": "", "type": "2", "o2oswitch": "0", "services": "", "servicetime": "", "Column1": "0", "distance": "1km"
//}, {
//    "memberid": "97", "nickname": "Leesin",
//    "gender": "男", "age": "30", "signature": "", "introduction": "运动狂", "grade": "0", "photo": "http://www.imxinshui.com/images/headphoto/20151019165727611.jpeg", "province": "上海", "city": "徐汇", "height": "", "weight": "", "waist": "在于u", "style": "",
//    "vocation": "刚好哈哈", "education": "", "oversea": "", "interest": "篮球 健身", "usid_ronglianyun_voipAccount": "85535900000084", "usid_ronglianyun_voipPwd": "HBLRQuJ3", "type": "2", "o2oswitch": "0", "services": "", "servicetime": "", "Column1": "20",
//    "distance": "42km"
//}, {
//    "memberid": "40", "nickname": "海洋", "gender": "女", "age": "30", "signature": "爱像大海", "introduction": "国家二级心理咨询师", "grade": "2", "photo": "http://www.imxinshui.com/images/headphoto/20151026152423125.jpeg",
//    "province": "上海", "city": "徐汇", "height": "", "weight": "", "waist": "", "style": "", "vocation": "", "education": "", "oversea": "", "interest": "", "usid_ronglianyun_voipAccount": "85535900000036", "usid_ronglianyun_voipPwd": "Y29tKbtG", "type": "2",
//    "o2oswitch": "1", "services": "约下午茶", "servicetime": "工作日5点后 周末随时", "Column1": "20", "distance": "8291km"
//}, {
//    "memberid": "41", "nickname": "芹菜", "gender": "女", "age": "32", "signature": "走出自己的世界，才能认识真实的世界",
//    "introduction": "国家二级心理咨询师", "grade": "2", "photo": "http://www.imxinshui.com/images/headphoto/20151026152539334.jpeg", "province": "上海", "city": "徐汇", "height": "", "weight": "", "waist": "", "style": "", "vocation": "", "education": "",
//    "oversea": "", "interest": "", "usid_ronglianyun_voipAccount": "85535900000037", "usid_ronglianyun_voipPwd": "wjOZmF4d", "type": "2", "o2oswitch": "1", "services": "约拍创意照片", "servicetime": "工作日5点后 周末随时", "Column1": "20", "distance": "10044km"
//},
//{
//    "memberid": "43", "nickname": "刘远", "gender": "女", "age": "30", "signature": "岁月总有生生不息的望", "introduction": "三级心理咨询师 心理学硕士", "grade": "1", "photo": "http://www.imxinshui.com/images/headphoto/20151026152837719.jpeg", "province": "上海",
//    "city": "徐汇", "height": "162cm", "weight": "", "waist": "", "style": "", "vocation": "", "education": "硕士", "oversea": "", "interest": "阅读 旅行", "usid_ronglianyun_voipAccount": "85535900000039", "usid_ronglianyun_voipPwd": "uLcxUObg", "type": "2", "o2oswitch": "1",
//    "services": "约吃饭💻🏀⚽️🏐️🏓️🎮👊", "servicetime": "随时", "Column1": "20", "distance": "10km"
//}, {
//    "memberid": "42", "nickname": "安津瑶", "gender": "女", "age": "28", "signature": " 心灵是未知的宇宙", "introduction": "国家二级心理咨询师 驻校心理辅导老师", "grade": "2",
//    "photo": "http://www.imxinshui.com/images/headphoto/20151026162527324.jpeg", "province": "上海", "city": "徐汇", "height": "162cm", "weight": "70kg", "waist": "70", "style": "", "vocation": "CMO", "education": "大学", "oversea": "", "interest": "",
//    "usid_ronglianyun_voipAccount": "85535900000038", "usid_ronglianyun_voipPwd": "Qm353T9U", "type": "2", "o2oswitch": "1", "services": "💻🏀⚽️🏐️🏓️🎮👊约人旅行", "servicetime": "随时", "Column1": "20", "distance": "22km"
//}, {
//    "memberid": "39", "nickname": "欣欣",
//    "gender": "女", "age": "30", "signature": "每天开心的像个向日葵", "introduction": "国家二级心理咨询师", "grade": "2", "photo": "http://www.imxinshui.com/images/headphoto/20151026151921387.jpeg", "province": "上海", "city": "徐汇", "height": "", "weight": "",
//    "waist": "", "style": "", "vocation": "", "education": "", "oversea": "", "interest": "吃，还是吃，吃，还是吃，吃，还是吃，", "usid_ronglianyun_voipAccount": "85535900000035", "usid_ronglianyun_voipPwd": "O1wnbDtj", "type": "2", "o2oswitch": "1",
//    "services": "约周边度假", "servicetime": "工作日5点后 周末随时", "Column1": "20", "distance": "81m"
//}, {
//    "memberid": "90", "nickname": "kiki", "gender": "女", "age": "30", "signature": "等待我的天使", "introduction": "正能量传播者", "grade": "0",
//    "photo": "http://www.imxinshui.com/images/headphoto/20151123163358152.jpeg", "province": "上海", "city": "徐汇", "height": "身高", "weight": "体重", "waist": "腰围", "style": "", "vocation": "", "education": "", "oversea": "", "interest": "旅行",
//    "usid_ronglianyun_voipAccount": "85535900000079", "usid_ronglianyun_voipPwd": "3vbeuy9W", "type": "2", "o2oswitch": "1", "services": "聊聊理想", "servicetime": "工作日5点后 周末随时", "Column1": "20", "distance": "10km"
//}, {
//    "memberid": "47", "nickname": "斌",
//    "gender": "男", "age": "30", "signature": "呵呵哒", "introduction": "呵呵哒", "grade": "2", "photo": "http://www.imxinshui.com/images/headphoto/201510911312750.jpeg", "province": "上海", "city": "徐汇", "height": "150cm", "weight": "60kg", "waist": "", "style": "",
//    "vocation": "", "education": "", "oversea": "", "interest": "", "usid_ronglianyun_voipAccount": "85535900000043", "usid_ronglianyun_voipPwd": "AaTQl0Tf", "type": "2", "o2oswitch": "0", "services": "运动健身", "servicetime": "工作日5点后 周末随时", "Column1": "20",
//    "distance": "10km"
//}, {
//    "memberid": "100", "nickname": "设计师Eshine", "gender": "男", "age": "30", "signature": "哈哈", "introduction": "创业家", "grade": "0", "photo": "http://www.imxinshui.com/images/headphoto/20151123121134951.jpeg", "province": "上海",
//    "city": "徐汇", "height": "171cm", "weight": "55kg", "waist": "28", "style": "暖男", "vocation": "创业", "education": "硕士", "oversea": "英国", "interest": "旅游", "usid_ronglianyun_voipAccount": "85535900000087", "usid_ronglianyun_voipPwd": "nOLfO7Yo",
//    "type": "2", "o2oswitch": "1", "services": "参加聚会", "servicetime": "随时", "Column1": "0", "distance": "10km"
//}];

function showDetail(list) {
    //alert("asdfs");
	var template = $("<div />").append($("<div />").addClass("panel panel-default uiItem").append($("<div />").addClass("panel-body")
			.append($("<div />").addClass("container-fluid")
				.append($("<div />").addClass("row").append($("<div />").addClass("col-md-10 text-center").append($("<img />").attr({
					"src": "{photo}",
					"class": "photo big"
				}))))
				.append($("<div />").addClass("row rowName").append($("<div />").addClass("col-md-10 text-left")
					.append($("<span />").addClass("nkName").html("{nickname}")).append("|").append($("<span />").addClass("age").html("{age}")
						.append($("<i />").addClass("icon icon-airplane"))).append($("<span />").addClass("constellation").html("{constellation}"))))
				.append($("<div />").addClass("row rowLocal").append($("<div />").addClass("col-md-10 text-left")
					.append($("<span />").html("{province}")).append("|").append($("<span />").html("{city}")).append("|").append($("<span />").html("{distance}"))))
				.append($("<div />").addClass("row rowLocal").append($("<div />").addClass("col-md-10 text-left")
					.append($("<span />").html("身高:{height}cm")).append("|").append($("<span />").html("体重:{weight}kg")).append("|").append($("<span />").html("职业:{vocation}"))))
				//.append($("<div />").addClass("row rowDes").html("<ul><li>Ta自诩为<span>{style}</span>；</li><li>目前从事<span>{vocation}</span></li></ul><br />")
                //.append($("<div class='divgoodat'>线上范围：<span>{goodat}</span></div><div class='divgoodat'>定价：<span>30元/天</span></div><br />"))
					.append($("<div class='divService'>线下范围：<span>{services},{specials}</span></div><div class='divService'>定价：<span>{servicerate}</span></div>"))//)
			))
		.append($("<img />").attr({
			"src": "img/button_cancel.png",
			"onclick": "delDetail(this);",
			"class": "btnImg"
		}))
		.append($("<img />").attr({
			"src": "img/button_ok.png",
			"onclick": "chooseDetail(this,1);",
			"class": "btnImg btnImglast",
			"id": "{memberid}",
			"openid": "{payaccount_wxpay}",

		})));
	var bodylist = $("body");
	bodylist.append($("<input />").attr({
		"type": "hidden",
		"value": "{memberid}"
	}));
	$.each(list, function(i, v) {
	    //alert("asdfs");
		if (v.gender == "男")
			template.find("i").first().attr("class", "icon icon-man");
		else
		    template.find("i").first().attr("class", "icon icon-woman");
		bodylist.append(template.strFormat(v));
		bodylist.find(".panel.panel-default.uiItem").last().find(".row.rowDes").find("span").each(function() {
			if ($(this).html() == "") {
				$(this).parent("li").first().hide();
			}
		});
		if (v.o2oswitch != "1") {
		    //bodylist.find(".panel.panel-default.uiItem").last().find(".row.rowDes").find("div").hide();
		    $(".divService").hide();
		}
	});
}

function showCPList(list) {
    var memberid = $("#memberid").val();
    var cusopenid = $("#cusopenid").val();

    var template = $("<div />").append($("<div />").addClass("row-item form-group")
        .append($("<a>").attr({
            "href": "personalinfo.aspx?memberid=" + memberid + "&cusopenid=" + cusopenid + "&contactid={memberid}&contactopenid={payaccount_wxpay}"
        })
			.append($("<div />").addClass("col-xs-3 col-sm-3")
				.append($("<img />").attr({
				    "src": "{photo}",
				    "class": "photo default"
				}))))
	    .append($("<a>").attr({
	        "href": "arrangementlist.aspx?memberid=" + memberid + "&cusopenid=" + cusopenid + "&contactid={memberid}&contactopenid={payaccount_wxpay}"
	    })
			.append($("<div />").addClass("col-xs-9 col-sm-9")
				.append($("<div />").addClass("row")
        .append($("<div />").addClass("col-xs-9 col-sm-9")
        .append($("<div />").addClass("row cplistname").append("{nickname}"))
        .append($("<div />").addClass("row littleinfo")
        .append($("<img />").attr({ "class": "gendericon" }))
        .append($("<span />").attr({ "class": "slabel" }).append("{age}"))
        .append($("<span />").attr({ "class": "slabel constellation" }).append("{constellation}"))
        ))
        .append($("<div />").addClass("col-xs-3 col-sm-3 distancelist text-right").append("{distance}"))
        )
                .append($("<div />").addClass("row")
        .append($("<div />").addClass("col-xs-12 col-sm-12 littleinfo signiturelist").append("身高:{height}cm 体重:{weight}kg 家乡:{hometowncity}")))
        ))
		);
    
    var bodyList = $(".group-item").first();
    $.each(list, function (i, v) {
        if (v.gender == "男")
            template.find(".gendericon").first().attr("src", "img/male.png");
        else
            template.find(".gendericon").first().attr("src", "img/female.png");
        bodyList.append(template.strFormat(v));
    });
    if (list.length <= 0) bodyList.append("没有可展示结果");
}

function fillstat(list,monthnum) {
    //alert("asdfs");
    var template = $("<div />").append($("<div />").addClass("row-item form-group")
        .append($("<div />").addClass("col-xs-6 col-sm-6 text-center control-label")
			.append("{nickname}"))
        .append($("<div />").addClass("col-xs-2 col-sm-2 text-center control-label hidden")
			.append("{num}"))
        .append($("<div />").addClass("col-xs-3 col-sm-3 text-center control-label")
			.append("{cpamount}"))
        .append($("<div />").addClass("col-xs-3 col-sm-3 text-center control-label")
			.append("{mmamout}"))
        .append($("<div />").addClass("col-xs-4 col-sm-4 text-center control-label hidden")
			.append("{mobile}"))
		);
    var monthpanel = $("body");
    if (monthnum == 1) monthpanel = $(".monthpanel1");
    else if (monthnum == 2) monthpanel = $(".monthpanel2");
    else if (monthnum == 3) monthpanel = $(".monthpanel3");

    var count = 0;
    var incomethismonth = 0;
    var incomelastmonth = 0;
    $.each(list, function (i, v) {
        monthpanel.append(template.strFormat(v));
        if (monthnum == 1) {
            count++;
            if(v.mmamout!="") incomethismonth += parseInt( v.mmamout);
        }
        else if (monthnum == 2 && v.mmamout != "") incomelastmonth += parseInt(v.mmamout);
    });
    if (monthnum == 1) {
        $("#cpnum").html(count + "个");
        $("#incomethismonth").html(incomethismonth + "元");
    }
    else if (monthnum == 2) $("#incomelastmonth").html(incomelastmonth + "元");
    
    
}

function monthpanelshowhid(obj,i)
{
    $(".monthpanel1").hide();
    $(".monthpanel2").hide();
    $(".monthpanel3").hide();
    if (i == 1) $(".monthpanel1").show();
    else if (i == 2) $(".monthpanel2").show();
    else if (i == 3) $(".monthpanel3").show();

    $(".btn-primary").attr("class", "btn btn-default");
    $(obj).attr("class", "btn btn-primary");
}

function showOneDetail(item) {
	var template = $("<div />").append($("<div />").addClass("panel panel-default uiItem").append($("<div />").addClass("panel-body")
			.append($("<div />").addClass("container-fluid")
				.append($("<div />").addClass("row").append($("<div />").addClass("col-md-10 text-center").append($("<img />").attr({
					"src": "{photo}",
					"class": "photo big"
				}))))
				.append($("<div />").addClass("row rowName").append($("<div />").addClass("col-md-10 text-left")
					.append($("<span />").addClass("nkName").html("{nickname}")).append("|").append($("<span />").addClass("age").html("{age}")
						.append($("<i />").addClass("icon icon-airplane")))))
				.append($("<div />").addClass("row rowLocal").append($("<div />").addClass("col-md-10 text-left")
					.append($("<span />").html("{province}")).append("|").append($("<span />").html("{city}")).append("|").append($("<span id='distancespan' />").html("{distance}"))))
				.append($("<div />").addClass("row rowLocal").append($("<div />").addClass("col-md-10 text-left")
					.append($("<span />").html("身高:{height}cm")).append("|").append($("<span />").html("体重:{weight}kg"))))
				.append($("<div />").addClass("row rowDes").html("<ul><li>Ta自诩为<span>{style}</span>；</li><li>目前从事<span>{vocation}</span></li></ul><br /><br />")
                .append($("<div class='divService'>线下范围：<span>{services},{specials}</span></div><div class='divService'>时间：<span>{servicetime}</span></div><div class='divService'>定价：<span>{servicerate}元 一次约会自行商议大约3小时</span></div>")))
			))
		.append($("<img />").attr({
			"src": "img/edit.png",
			"onclick": "goToUrl('personaledit.aspx', this);",
			"class": "btnImg"
		})).append($("<input />").attr({
			"type": "hidden",
			"value": "{memberid}",
			"id": "memberid"
		})));


	if (item.gender == "男")
		template.find("i").first().attr("class", "icon icon-man");
	else
		template.find("i").first().attr("class", "icon icon-woman");

	$("body").append(template.strFormat(item));
	$("body").find(".panel.panel-default.uiItem").last().find(".row.rowDes").find("span").each(function() {
		if ($(this).html() == "") {
			$(this).parent("li").first().hide();
		}
	});
	if (item.o2oswitch != "1") {
	    //$("body").find(".panel.panel-default.uiItem").last().find(".row.rowDes").find("div").hide();
	    $(".divService").hide();
	}
	if (state == "2") {
	    $(".btnImg").hide();

	    if (item.isqualified == 1) {
	        //$(".row.rowDes").append("<br /><div class='divService'><a href='#' onclick='window.location.href=\"" + urlcp + "\";'><img src='img/chat.png' class='chatImg'/></a><a href='#' class='alast' onclick='checkgoO2O(" + isvip + ");'><img src='img/date.png' class='dateImg'/></a></div>");
	        $(".row.rowDes").append("<br /><div class='divService'><button type='button' class='btn btn-primary' onclick=\"window.location.href='" + urlcp + "';\">线上恋人</button><button type='button' class='btn btn-primary alast' onclick='checkgoO2O(" + isvip + ");'>线下约会</button></div>");
	        if (item.o2oswitch != "1") {
	            $(".dateImg").hide();
	        }
	    }
	    else {
	        $(".row.rowDes").append("<br />").append($("<img />").attr({
	            "src": "img/button_ok.png",
	            "onclick": "chooseDetail(this,2);",
	            "class": "btnImg btnImglast",
	            "id": fromid
	        }));
	    }
	}
	else { $("#distancespan").hide(); }
}

function checkgoO2O(isvip)
{
    if (isvip == 1) {
        window.location.href = urlo2o;
    }
    else {
        msg = "只有VIP会员才能享受线下邀约服务!";
        BootstrapDialog.confirm(msg, "成为VIP","暂时不了","马上成为VIP", function (torf) {
            if (torf)
                window.location.href = urlmembership;
        });
    }
}

function showUIDetail(item) {
	var template = $("<div />").append($("<div />").addClass("row-item form-group")
		.append($("<label />").addClass("col-xs-2 col-sm-2 control-label").html("{name}:"))
		.append($("<div />").addClass("col-xs-8 col-sm-8").append($("<input />").attr({
			"type": "text",
			"id": "txt{name}",
			"class": "form-control",
			"placeholder": "{name}",
			"value": "{value}"
		}))));
	$.each(item, function(i, v) {
		var temp = {
			"name": i,
			"value": v
		};
		if (i == "memberid")
			return true;

		$("body .group-item").append(template.strFormat(temp));
	});
}

function GetDateStr(AddDayCount) {
    var dd = new Date();
    dd.setDate(dd.getDate() + AddDayCount);//获取AddDayCount天后的日期 
    var y = dd.getFullYear();
    var m = dd.getMonth() + 1;//获取当前月份的日期 
    var d = dd.getDate();
    return y + "-" + m + "-" + d;
}
function GetWeekDay(AddDayCount) {
    //起始日期的星期，星期取值有（1,2,3,4,5,6,0）
    var dd = new Date();
    dd.setDate(dd.getDate() + AddDayCount);//获取AddDayCount天后的日期 
    return dd.getDay();
}

//给下拉框添加选项
function initeditdropdownlists() {

	//for (i = 150; i < 199; i++) $("#height").append(("<option value='" + i + "'>" + i + "cm</option>"));
	//for (i = 35; i < 119; i++) $("#weight").append(("<option value='" + i + "'>" + i + "kg</option>"));
	//for (i = 25; i < 44; i++) $("#waist").append(("<option value='" + i + "'>" + i + "</option>"));




	var weekday = GetWeekDay(21);
	for (i = 21; i <= 92; i++) {
        //跳过周末
	    if (weekday != 6 && weekday != 0)
	    {
	        var datestring = GetDateStr(i);
	        $("#duedate").append(("<option value='" + datestring + "'>" + datestring + "</option>"));
	    }
	    if (++weekday == 7)
	    {
	        weekday = 0;
	    }
	}

	

	//var interest = ["唱歌", "听歌", "舞蹈", "乐器", "下棋", "球类运动", "游泳", "逛街", "聚会", "看演出", "阅读", "武术", "画画|书法", "写作", "美食", "旅游", "花木|手工", "喝茶"];
	//$.each(interest, function (i, val) {
	//    if (interestval.indexOf(',' + val + ',') != -1)
	//        $("#interest").append(("<option value='" + val + "' selected='selected'>" + val + "</option>"));
	//    else
	//        $("#interest").append(("<option value='" + val + "'>" + val + "</option>"));
	//});
}

function initeditdropdownlistscp() {
    //=============下面为多选
    var goodat = ["早起闹钟", "睡前晚安", "异性恋爱心理分析", "失恋精神鼓励", "情感聆听", "说唱逗笑", "嘘寒问暖日常关心", "当你出气筒"];
    $.each(goodat, function (i, val) {
        if (goodatval.indexOf(',' + val + ',') != -1)
            $("#goodat").append(("<option value='" + val + "' selected='selected'>" + val + "</option>"));
        else
            $("#goodat").append(("<option value='" + val + "'>" + val + "</option>"));
    });

    var services = ["吃饭", "看电影", "压马路", "陪逛街", "参加聚会", "聊天", "陪你加班", "假装男女朋友", "拜见父母", "旅游",  "挑衣服", "麻将扑克", "看演出比赛", "运动健身", "代驾", "教你煮饭"];
    $.each(services, function (i, val) {
        if (servicesval.indexOf(',' + val + ',') != -1)
            $("#services").append(("<option value='" + val + "' selected='selected'>" + val + "</option>"));
        else
            $("#services").append(("<option value='" + val + "'>" + val + "</option>"));
    });


    var servicetime = ["工作日6点后", "周末", "周一", "周二", "周三", "周四", "周五", "均可", "协商"];
    $.each(servicetime, function (i, val) {
        if (servicetimeval.indexOf(',' + val + ',') != -1)
            $("#servicetime").append(("<option value='" + val + "' selected='selected'>" + val + "</option>"));
        else
            $("#servicetime").append(("<option value='" + val + "'>" + val + "</option>"));
    });

    var servicerate = [100, 200, 300, 500, 1000, 2000];
    $.each(servicerate, function (i, val) {
        $("#servicerate").append(("<option value='" + val*100 + "'>" + val + "</option>"));
    });
}

function setspecialfields() {
	//给下拉框复制
	$.each(dropnames, function(i, val) {
		$("#" + val).val(dropvals[i]);
	});

	//更新性别,vip icon
	if (paravals[0] != '1') $("#iconvip").attr('class', 'hidden');

	
}

function setspecialfieldscp() {
    //给不允许修改的项加readonly
    if ($("#name").val() != '') $("#name").attr('readonly', 'readonly');
    if ($("#IDcard").val() != '') $("#IDcard").attr('readonly', 'readonly');
}

function renderpage(list) {
    var template1 = $("<div />").append($("<OPTGROUP />").attr({ "LABEL": "{product_code}" }));
    var template2 = $("<div />").append($("<OPTION />").html("{link_contract}"));
    var targetList = $("#target");
    var current_product_code;
    var s;
    if (list == "[]") return;
    $.each(list, function (i, v) {
        if (current_product_code != v.product_code)
        {
            current_product_code = v.product_code;
            targetList.append(template1.strFormat(v));
        }
        var targetListGroup = $("#target").find("[LABEL='" + v.product_code + "']");
        targetListGroup.append(template2.strFormat(v));
       
    });
}

function showMyDateList(list, type) {
    var memberid = $("#memberid").val();
    var cusopenid = $("#cusopenid").val();


    var template = $("<div />").append($("<div />").addClass("row-item form-group")
        .append($("<div />").addClass("row")
        .append($("<div />").addClass("col-xs-8 col-sm-8")
        .append($("<div />").addClass("row cplistname servicetime")))
        .append($("<div />").addClass("col-xs-4 col-sm-4 text-right empha").append($("<span />").addClass("servicebox").append("{services}")))
        )
        .append($("<div />").addClass("row")
        .append($("<div />").addClass("col-xs-8 col-sm-8")
        .append($("<div />").addClass("row cplistname").append("{nickname}")))
        .append($("<div />").addClass("col-xs-4 col-sm-4 text-right").append("订单号：{id}"))
        )

        .append($("<a>").attr({
            "href": "personalinfo.aspx?memberid=" + memberid + "&cusopenid=" + cusopenid + "&contactid={memberid}&contactopenid={payaccount_wxpay}"
        })
			.append($("<div />").addClass("col-xs-3 col-sm-3")
				.append($("<img />").attr({
				    "src": "{photo}",
				    "class": "photo default"
				}))))
	    .append($("<div />").addClass("col-xs-9 col-sm-9")
                .append($("<div />").addClass("row cplistname").append("{nickname}"))
				.append($("<div />").addClass("row")
        .append($("<div />").addClass("col-xs-10 col-sm-10 storename"))
        .append($("<div />").addClass("col-xs-2 col-sm-2 littleinfo stroeprice text-right"))
        )
                .append($("<div />").addClass("row")
        .append($("<div />").addClass("col-xs-12 col-sm-12 littleinfo storeaddress"))
        .append($("<div />").addClass("col-xs-12 col-sm-12 littleinfo storephone")))
                .append($("<div />").addClass("row cpmobile")
        .append($("<div />").addClass("col-xs-12 col-sm-12").append("联系电话：{mobile}")))
        )
        .append($("<div />").addClass("row")
        .append($("<div />").addClass("col-xs-4 col-sm-4")
        .append($("<div />").addClass("row empha amount")))
        .append($("<div />").addClass("col-xs-8 col-sm-8 text-right littleinfo orderbtns"))
        )
		);

    var bodyList = $(".group-item").first();
	
	$.each(list, function (i, v) {
	    var ss;
	    var locationdetail = JSON.parse(v.location);
	    var showcpmobile = false;
	    switch (v.status) {
	        case "0"://等待付款
	            if (type == 1) {
	                var cusopenid = $("#openid").val();
	                var data = "orderid={id}&memberid=" + memberid + "&cusopenid=" + cusopenid + "&photo={photo}&nickname={nickname}&services={services}&servicedate={servicetime}&servicetime=&location={location}";
	                var pays = "window.location=\"dateconfirm.aspx?" + data + "\"";
	                ss = "<div class='btn btn-primary' onclick='" + pays + "'>&nbsp;付款&nbsp;</div>";
	            }
	            else return true; //美女不显示等待付款的订单
	            break;
	        case "1"://付款完成
	            if (type == 1) ss = "付款完成&nbsp;<sapn class='littleinfo'>请等待美女确认</span>";
	            else ss = "<div class='btn btn-primary' onclick='o2oresponse({id},{status},2,\",接受\",0,0,0,0);'>&nbsp;接受&nbsp;</div> <div class='btn btn-default' onclick='o2oresponse({id},{status},-11,\",拒绝\",0,0,0,0);'>拒绝</div>";
	            break;
	        case "2"://美女接受
	            var expiretime = new Date(Date.parse(v.servicetime) + 15 * 60000);//服务时间+15分钟为最长等待时间
	            if (type == 1) {
	                ss = "<div class='btn btn-primary' onclick='showQRImg({note},2);'>订单二维码</div>";
	                
	                if (expiretime < new Date()) {
	                    ss = "<div class='btn btn-primary' onclick='showQRImg({note},2);'>订单二维码</div> <div class='btn btn-primary' onclick='o2oresponse({id},{status},-2,\",美女缺席\",0,0,0,0);'>美女缺席</div>";
	                }
	                else if (new Date()>=Date.parse(v.servicetime)) {
	                    //当前时间在开始后的15分钟内显示cp的电话号码
	                    showcpmobile = true;
	                }

	                
	            }
	            else {
	                ss = "<sapn class='littleinfo'>扫一扫客户端本次约会订单的二维码<br />系统即确认约会成功并于次日打款</span><br /><div class='btn btn-primary' onclick='openwxscan();'>扫一扫</div>";
	                if (expiretime < new Date()) {
	                    ss = "<div class='btn btn-primary' onclick='o2oresponse({id},{status},-3,\",客户缺席\",0,0,0,0);'>客户缺席</div>";
	                }
	            }
	            break;
	        case "3"://约会成功
	            if (type == 1) ss = "约会成功&nbsp;<div class='btn btn-primary' onclick='evalbox({id},{status});'>评价</div>";
	            else ss = "约会成功&nbsp;<sapn class='littleinfo'>客户好评将提升贡献值</span>";
	            break;
	        case "4":
	            ss = "资料相符:{rate1}星<br />美女态度:{rate2}星<br />总体感受{rate3}星";
	            break;
	        case "5":
	            ss = "订单完成";
	            break;
	        case "6":
	            ss = "订单过期";
	            break;
	        case "-2"://美女NoShow
	            if (type == 1) ss = "美女缺席正在审核&nbsp;<div class='btn btn-primary' onclick='showQRImg({note},2);'>展示二维码</div>";
	            else ss = "<div class='btn btn-primary' onclick='appealbox({id},{status},1);'>&nbsp;申诉&nbsp;</div> <div class='btn btn-default' onclick='o2oresponse({id},{status},-11,\",美女确认缺席\",0,0,0,0);'>我缺席</div>";
	            break;
	        case "-3"://客户NoShow
	            if (type == 1) ss = "<div class='btn btn-primary' onclick='showQRImg({note},2);'>二维码</div> <div class='btn btn-primary' onclick='appealbox({id},{status},2);'>申诉</div> <div class='btn btn-default' onclick='o2oresponse({id},{status},5,\",客户确认缺席\",4,4,4,0);'>我缺席</div>";
	            else ss = "客户缺席正在审核";
	            break;
	        case "-4":
	            ss = "缺席核实";
	            break;
	        case "-5":
	            ss = "核实结束";
	            break;
	        case "-11":
	            ss = "订单取消";
	            break;
	    }
	    if (!showcpmobile) template.find(".cpmobile").attr("class", "hidden");
	    template.find(".orderbtns").html(ss);

	    var et = new Date(Date.parse(v.servicetime) + 2 * 3600000);//endtime
	    template.find(".servicetime").html(v.servicetime + "-" + (et.getHours() > 9 ? et.getHours() : '0' + et.getHours()) + ":" + (et.getMinutes() > 9 ? et.getMinutes() : '0' + et.getMinutes()));
	    template.find(".storename").html(locationdetail.title);
	    template.find(".stroeprice").html("人均" + locationdetail.price);
	    template.find(".storeaddress").html(locationdetail.address);
	    template.find(".storephone").html("商家电话:" + locationdetail.phone);
	    template.find(".amount").html(parseInt(v.amount) / 100 + "元");

		bodyList.append(template.strFormat(v));
	});
}

function o2oresponse(id, oldstatus, status,note, rate1, rate2, rate3, rate4) {
    
    var data;
    data = "id=" + id + "&oldstatus=" + oldstatus + "&status=" + status + "&note=" + note + new Date().toLocaleString() + "&rate1=" + rate1 + "&rate2=" + rate2 + "&rate3=" + rate3 + "&rate4=" + rate4;
    
    callAjaxJson("xswxinterface/o2oresponse.aspx", data, function (obj) {
        var jObj = JSON.parse(obj);
        if (jObj.code != "1")
            alertMsg(jObj.message);
        else {
            alertMsg("操作成功");
            //window.location.reload();//刷新当前页面，这个不行，当前页面是微信的跳转回来的链接，https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx8d22166cc1bfa227&redirect_uri=http%3a%2f%2fweixin.imxinshui.com%2fwebpage%2fmydatesent.aspx&response_type=code&scope=snsapi_base&state=Xinshui&connect_redirect=1#wechat_redirect
            window.location.href = "mydatesent.aspx?openid="+$("#openid").val();
        }

    });
}

function showarrangementList(list, type) {
    var template = $("<div />").append($("<div />").addClass("row-item form-group")
        .append($("<div />").addClass("row")
        .append($("<div />").addClass("col-xs-8 col-sm-8")
        .append($("<div />").addClass("row cplistname servicetime")))
        .append($("<div />").addClass("col-xs-4 col-sm-4 text-right empha").append($("<span />").addClass("servicebox").append("{services}")))
        )
        .append($("<div />").addClass("col-xs-3 col-sm-3")
				.append($("<img />").attr({
				    "src": "{location}",
				    "class": "photo default"
				})))
	    .append($("<div />").addClass("col-xs-9 col-sm-9")
				.append($("<div />").addClass("row")
        .append($("<div />").addClass("col-xs-10 col-sm-10 storename"))
        .append($("<div />").addClass("col-xs-2 col-sm-2 littleinfo stroeprice text-right"))
        )
                .append($("<div />").addClass("row")
        .append($("<div />").addClass("col-xs-12 col-sm-12 littleinfo storeaddress"))
        .append($("<div />").addClass("col-xs-12 col-sm-12 littleinfo storephone"))
        .append($("<div />").addClass("col-xs-12 col-sm-12 littleinfo storehour")))
        )
        .append($("<div />").addClass("row")
        .append($("<div />").addClass("col-xs-4 col-sm-4")
        .append($("<div />").addClass("row empha amount"))
        .append($("<div />").addClass("row littleinfo agentcharge")))
        .append($("<div />").addClass("col-xs-8 col-sm-8 text-right orderbtns"))
        )
		);

    var memberid = $("#memberid").val();
    var contactid = $("#contactid").val();
    var bodyList = $(".group-item").first();

    $.each(list, function (i, v) {
        var ss;
        var locationdetail = JSON.parse(v.location);
        switch (v.status) {
            case "0"://等待付款
                if (type == 1) {
                    var cusopenid = $("#cusopenid").val();
                    var balance = $("#balance").val();
                    var data = "orderid={id}&memberid=" + memberid + "&contactid=" + contactid + "&cusopenid=" + cusopenid + "&balance=" + balance + "&amount={amount}&photo=" + photo + "&nickname=" + nickname + "&services={services}&servicedate={servicetime}&servicetime=&loc=" + locationdetail.title + "|" + locationdetail.address;
                    var pays = "window.location=\"dateconfirm.aspx?" + data + "\"";
                    ss = "<div class='btn btn-primary' onclick='" + pays + "'>&nbsp;邀约&nbsp;</div>";
                }
                else {
                    var links = "mkarrangement.aspx?contactid={targetid}&orderid={id}";
                    var urljs = "window.location=\"" + links + "\"";
                    ss = "<div class='btn btn-primary' onclick='" + urljs + "'>&nbsp;修改&nbsp;</div> <div class='btn btn-default' onclick='cancelo2oorder({id});'>取消</div>";
                }
                break;
            case "1"://付款完成
                ss = "付款完成,请至【我的订单】处理";
                break;
            case "2"://美女接受
                ss = "已接受,请至【我的订单】处理";
                break;
        }

        template.find(".orderbtns").html(ss);
        
        var et = new Date(Date.parse(v.servicetime) + 2 * 3600000);//endtime
        template.find(".servicetime").html(v.servicetime+"-" + (et.getHours() > 9 ? et.getHours() : '0' + et.getHours()) + ":" + (et.getMinutes() > 9 ? et.getMinutes() : '0' + et.getMinutes()));
        template.find(".photo").attr("src", locationdetail.image);
        template.find(".storename").html(locationdetail.title);
        template.find(".stroeprice").html("人均"+locationdetail.price);
        template.find(".storeaddress").html(locationdetail.address);
        template.find(".storephone").html("电话:" + locationdetail.phone);
        template.find(".storehour").html("营业时间:" + locationdetail.shop_hours);
        template.find(".amount").html(parseInt(v.amount) / 100 + "元");
        template.find(".agentcharge").html("管理费" + parseInt(parseInt(v.amount) * 3 / 700) + "元");
        bodyList.append(template.strFormat(v));
    });
}

function showPaybtnList(paytype) {
    var listCPbtn = [{
        "payamount": "3000",
        "giftid": "1",
        "text": "1天<br />30元"
    }, {
        "payamount": "15000",
        "giftid": "2",
        "text": "7天<br />150元"
    }, {
        "payamount": "50000",
        "giftid": "3",
        "text": "30天<br />500元"
    }];
    var listO2Obtn = [{
        "payamount": "10000",
        "giftid": "4",
        "text": "100元"
    }, {
        "payamount": "20000",
        "giftid": "5",
        "text": "200元"
    }, {
        "payamount": "30000",
        "giftid": "6",
        "text": "300元"
    }, {
        "payamount": "50000",
        "giftid": "7",
        "text": "500元"
    }, {
        "payamount": "100000",
        "giftid": "8",
        "text": "1000元"
    }, {
        "payamount": "200000",
        "giftid": "9",
        "text": "2000元"
    }];
    var listvipbtn = [{
        "payamount": "1000000",
        "giftid": "20",
        "text": "年费VIP 12个月<br />10000元"
    }, {
        "payamount": "100000",
        "giftid": "21",
        "text": "VIP1个月<br />1000元"
    }];
    var listtopupbtn = [];
    var template = $("<div />").append($("<button />").attr({
        "type": "button",
        "class": "btn btn-primary form-control getBrandWCPayRequest",
        "payamount": "{payamount}",
        "giftid": "{giftid}"
    }).html("{text}"));

    var list;
    if (paytype == "cp") {
        $(".row-item").addClass("paycpbtngroup");
        list = listCPbtn;
    }
    else if (paytype == "o2o") {
        $(".row-item").addClass("payo2obtngroup");
        list = listO2Obtn;
    }
    else if (paytype == "membership") {
        $(".row-item").addClass("payvipbtngroup");
        list = listvipbtn;
    }
    $.each(list, function (i, v) {
        $(".row-item").append(template.strFormat(v));
    });
    
}

function delDetail(obj) {
	$(obj).parent(".uiItem").first().fadeOut(300);
}

function chooseDetail(obj,direction) {

    var id = $("#memberid").val();
    var cusopenid = $("#cusopenid").val();
    var data;
    data = "direction=" + direction + "&memberid=" + id + "&contactid=" + obj.id + "&cusopenid=" + cusopenid + "&contactopenid=" + obj.openid;
    window.location = "datepage.aspx?" + data;

    return;
	callAjaxJson("xswxinterface/stylistselect.aspx", data, function (obj) {
	    if (obj == undefined) {
	        alertMsg("返回出错");
	        return;
	    }
	    //alertMsg(obj);
	    var jObj = JSON.parse(obj);
	    if (jObj.code == undefined)
	    {
	        alertMsg("选择出错");
	        return;
	    }
	    if (jObj.code != "1")
	        alertMsg(jObj.message);
        else
	        alertWarning(jObj.message, false);
	});

}

function dateconfirm() {
    var data = "";
    data = BuildUInfo(data);
    window.location = "dateconfirm.aspx?" + data;
}

function submitcomplain(obj) {
	var openid = $("#openid").val();
	var complain = $("#complain").val();
	var data = "openid=" + encodeURIComponent(openid) + "&complain=" + encodeURIComponent(complain);

	callAjaxJson("xswxinterface/complain.aspx", data, function(obj) {
		if (obj != null) {
			var jObj = JSON.parse(obj);
			$("#msg").html(jObj.message);
		} else {
			$("#msg").html("反馈失败。请返回公众号。");
		}
		$("#complain").attr('readonly', 'readonly');
		$("#btnsubmit").attr('disabled', 'disabled');
	});
}

function goToUrl(url, obj) {
	var id = $("#memberid").val();
	window.location = url + "?memberid=" + id;
}

function saveUInfo() {
	var data = "";
	data = BuildUInfo(data);
	if ($("#selYear").val() != undefined && $("#selMonth").val() != undefined && $("#selDay").val() != undefined && $("#selYear").val() != "" && $("#selMonth").val() != "" && $("#selDay").val() != "")
	    data += "&DOB=" + encodeURIComponent($("#selYear").val() + "-" + $("#selMonth").val() + "-" + $("#selDay").val());
	if (ckForm()) {
		callAjaxJson("xswxinterface/personalinfoupdate.aspx", data, function(obj) {
			if (obj != null) {
				var jObj = JSON.parse(obj);
				alertMsg(jObj.message);
			} else {
				alertMsg("解析异常，请稍后再试！");
			}
		});
	} else {}
	//alertMsg("操作失败", true);
}

function saveCPUInfo() {
    var data = "";
    data = BuildUInfo(data);
    if ($("#selYear").val() != undefined && $("#selMonth").val() != undefined && $("#selDay").val() != undefined && $("#selYear").val() != "" && $("#selMonth").val() != "" && $("#selDay").val() != "")
        data += "&DOB=" + encodeURIComponent($("#selYear").val() + "-" + $("#selMonth").val() + "-" + $("#selDay").val());
    if ($("#btnCP").html() != "更新")
        data += "&wantCP=1";
    if (ckCPForm()) {
        callAjaxJson("xswxinterface/personalinfoupdate.aspx", data, function (obj) {
            if (obj != null) {
                var jObj = JSON.parse(obj);
                alertMsg(jObj.message);
            } else {
                alertMsg("解析异常，请稍后再试！");
            }
        });
    } else { }
    //alertMsg("操作失败", true);
}

function BuildUInfo(data) {
    var formList = $(".form-control");
    formList.each(function () {
        if ($(this).attr("id") == undefined)
            return true;
        if ($(this).val() == null) data += $(this).attr("id").replace("txt", "").replace("sel", "") + "=&";
        else data += $(this).attr("id").replace("txt", "").replace("sel", "").replace("hi_", "") + "=" + encodeURIComponent($(this).val()) + "&";
    });
    if (data != "")
        data = data.substring(0, data.length - 1);
    return data;
}


//验证表单
function ckForm() {
	try {
		var phone = $("#mobile");
		var verifycode = $("#verifycode");
		var email = $("#email");
		if ( !ckPhone(phone.val()))
			return false;
		if (!ckVerifyCode(verifycode.val()))
			return false;
		if (email.val() != "" && !ckEMail(email.val()))
			return false;

		return true;
	} catch (err) {
		return false;
	}
}

function ckCPForm() {
    try {
        var phone = $("#mobile");
        //var verifycode = $("#verifycode");
        var email = $("#email");
        if (phone.val() != undefined && !ckPhone(phone.val()))
            return false;
        //if (verifycode.val() != undefined && !ckVerifyCode(verifycode.val()))
        //    return false;
        if (email.val() != undefined && email.val() != "" && !ckEMail(email.val()))
            return false;

        var name = $("#name");
        var idcard = $("#IDcard");

        if (name.val() != undefined && name.val() == "") {
            alertMsg("姓名必填");
            return false;
        }
           
        if (idcard.val() != undefined && idcard.val() != "" && !ckIDCard(idcard.val()))
            return false;
        return true;
    } catch (err) {
        return false;
    }
}

//aCity在验证身份证里面用
var aCity = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江 ", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北 ", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏 ", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外 " };
//验证身份证
function ckIDCard(obj) {
	var iSum = 0;
	var info = "";
	if (!/^\d{17}(\d|X|x)$/.test(obj)) {
		alertMsg("请输入18位身份证号码");
		return false;
	}
	obj = obj.replace(/x$/i, "a");
	if (aCity[parseInt(obj.substr(0, 2))] == null) {
		alertMsg("请输入正确的身份证号码，城市错误");
		return false;
	}


	var sBirthday = obj.substr(6, 4) + "-" + Number(obj.substr(10, 2)) + "-" + Number(obj.substr(12, 2));
	var d = new Date(sBirthday.replace(/-/g, "/"))
	if (sBirthday != (d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate())) {
		alertMsg("请输入正确的身份证号码，出生日期错误");
		return false;
	}
	for (var i = 17; i >= 0; i--)
		iSum += (Math.pow(2, i) % 11) * parseInt(obj.charAt(17 - i), 11);
	if (iSum % 11 != 1) {
		alertMsg("请输入正确的身份证号码");
		return false;
	}
	return true;
}

//验证邮箱
function ckEMail(obj) {
	if (false && obj.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) == -1) {
		alertMsg("请输入正确的邮箱");
		return false;
	}
	return true;
}

//验证手机号
function ckPhone(obj) {
	var reg = /^1[3|4|5|7|8][0-9]\d{4,8}$/;
	if (obj == "") {
		alertMsg("请输入手机号码");
		return false;
	} else if (obj.length < 11) {
		alertMsg("手机号码不正确");
		return false;
	} else if (!(reg.test(obj))) {
		alertMsg("手机号码不正确");
		return false;
	}
	return true;
}

function ckVerifyCode(obj) {
	var reg = /^\d{4}$/;
	if (!(reg.test(obj))) {
		alertMsg("验证码为4位数");
		return false;
	}
	return true;
}

function alertMsgConfirm(msg) {
	BootstrapDialog.confirm(msg, "提示", function(torf) {
		if (torf)
			alert("选择是");
		else
			alert("选择否");
	});
}

//弹出编辑信息
//msg 内容
//title 标题
//callback 执行返回方法
function alertMsgConfirm(msg, title, callback) {
    BootstrapDialog.confirm(msg, title, callback);
}

//弹出提示信息
//msg 内容
function alertMsg(msg) {
	BootstrapDialog.alert({
		title: "提示",
		message: msg,
		closable: false,
		buttonLabel: '确认'
	});
}

//弹出提示信息
//msg 内容
//isOut 自动消失
function alertMsg(msg,cb, isOut) {
	var dialogModel = BootstrapDialog.alert({
		title: "提示",
		message: msg,
		closable: false,
		buttonLable: "确认",
        callback:cb
	});

	if (isOut) {
		setTimeout(function() {
			dialogModel.close();
		}, 3000);
	}
}

//弹出提示信息
//msg 内容
//isOut 自动消失
function alertMsgOut(msg, isOut, min) {
	var dialogModel = BootstrapDialog.alert({
		title: "提示",
		message: msg,
		closable: false,
		buttonLable: "确认"
	});

	if (isOut) {
		setTimeout(function() {
			dialogModel.close();
		}, min);
	}
}

//弹出提示信息
//msg 内容
//title 标题
function alertMsgTitle(msg, title) {
	BootstrapDialog.alert({
		title: title,
		message: msg,
		closable: false,
		buttonLable: "确认"
	});
}

//弹出警告信息
//msg 内容
//是否可关闭
function alertWarning(msg, torf) {
    BootstrapDialog.warning(msg, torf);
}




//type 1，文本框；2，日期下拉框（年月日）；3，纯粹下拉框；4，多选下拉框；5，多行文本框；6，省份下拉框；7，开关按钮；8，验证码;9分割线
//isShow 0，页面无需显示；1，页面显示；-1，页面隐藏；
//isRead 0，页面不控制；1，页面只读；
var switchlist = new Array(); //开关数组
var switchindex = 0;
function getInputType(obj) {
    
    if (typeof (obj.key) != "undefined") {
        var t = obj.type;
        var reObj = null;
        if (obj.isShow == 0)
            return null;
        switch (t) {
            case "1":
                reObj = $("<div />").attr("class", "row-item form-group")
                    .append($("<label />").addClass("col-xs-2 col-sm-2 control-label").html(obj.des + ":"))
                    .append($("<div />").addClass("col-xs-9 col-sm-9")
                    .append($("<input />").attr({
                        "id": "txt" + obj.key,
                        "name": "txt" + obj.key,
                        "type": "text",
                        "value": obj.value,
                        "placeholder": obj.des,
                        "class": "form-control"
                    })));
                break;
            case "2":
                var date = new Date(obj.value);
                reObj = $("<div />").attr("class", "row-item form-group")
                    .append($("<label />").addClass("col-xs-2 col-sm-2 control-label").html(obj.des + ":"))
                    .append($("<div />").addClass("col-xs-3 col-sm-3 control-label")
                    .append($("<select />").attr({
                        "id": "selYear",
                        "name": "selYear",
                        "class": "form-control slyear",
                        "data": date.getFullYear()
                    })))
                    .append($("<div />").addClass("col-xs-3 col-sm-3 control-label dob")
                    .append($("<select />").attr({
                        "id": "selMonth",
                        "name": "selMonth",
                        "class": "form-control slmonth",
                        "data": date.getMonth() + 1
                    })))
                    .append($("<div />").addClass("col-xs-3 col-sm-3 control-label dob")
                    .append($("<select />").attr({
                        "id": "selDay",
                        "name": "selDay",
                        "class": "form-control slday",
                        "data": date.getDate()
                    })));
                break;
            case "3":
                var discription;
                if (obj.key == "style") discription = "风格";
                else discription = obj.des;
                reObj = $("<div />").attr("class", "row-item form-group")
                    .append($("<label />").addClass("col-xs-2 col-sm-2 control-label").html(discription + ":"))
                    .append($("<div />").addClass("col-xs-9 col-sm-9")
                    .append($("<select />").attr({
                        "id": "sel" + obj.key,
                        "name": "sel" + obj.key,
                        "style-type": obj.des,
                        "data": obj.value,
                        "class": "form-control"
                    })));
                break;
            case "4":
                reObj = $("<div />").attr("class", "row-item form-group")
                    .append($("<label />").addClass("col-xs-2 col-sm-2 control-label").html(obj.des + ":"))
                    .append($("<div />").addClass("col-xs-9 col-sm-9")
                    .append($("<select />").attr({
                        "id": "sel" + obj.key,
                        "name": "sel" + obj.key,
                        "data-live-search": "true",
                        "multiple": "multiple",
                        "data": obj.value,
                        //"class": "selectpicker show-tick form-control"
                        "class": "multisel show-tick form-control"
                    })));
                break;
            case "5":
                reObj = $("<div />").attr("class", "row-item form-group")
                    .append($("<label />").addClass("col-xs-2 col-sm-2 control-label").html(obj.des + ":"))
                    .append($("<div />").addClass("col-xs-9 col-sm-9")
                    .append($("<textarea />").attr({
                        "id": "txt" + obj.key,
                        "name": "txt" + obj.key,
                        "type": "text",
                        "value": obj.value,
                        "placeholder": obj.des,
                        "class": "form-control",
                        "style": "height: 60px;"
                    }).html(obj.value)));
                break;
            case "6":
                reObj = $("<div />").attr("class", "row-item form-group")
                    .append($("<label />").addClass("col-xs-2 col-sm-2 control-label").html(obj.des + ":"))
                    .append($("<div />").addClass("col-xs-9 col-sm-9")
                    .append($("<select />").attr({
                        "id": obj.key,
                        "name": obj.key,
                        "data": obj.value,
                        "class": "form-control geo-group"
                    })));
                break;
            case "7":
                reObj = $("<div />").attr("class", "row-item form-group")
                    .append($("<label />").addClass("col-xs-2 col-sm-2 control-label").html(obj.des + ":"))
                    .append($("<div />").addClass("col-xs-9 col-sm-9")
                    .append($("<div />").attr({ "id": "div" + obj.key + "_p", "class": "open1 rec rec" + obj.key })
                    .append($("<div />").attr({ "id": "div" + obj.key + "_c", "class": "open2 cir cir" + obj.key })))
                    .append($("<input />").attr({ "type": "hidden", "class": "form-control", "id": "hi_" + obj.key, "name": "hi_" + obj.key }).val(obj.value)));

                switchlist[switchindex++] = obj.key;
                break;
            case "8":
                reObj = $("<div />").attr("class", "row-item form-group verifycodediv")
                    .append($("<label />").addClass("col-xs-2 col-sm-2 control-label").html("验证码:"))
                    .append($("<div />").addClass("col-xs-4 col-sm-4")
                    .append($("<input />").attr({
                        "id": "verifycode",
                        "name": "verifycode",
                        "type": "text",
                        "placeholder": "验证码",
                        "class": "form-control"
                    })))
                    .append($("<div />").addClass("col-xs-4 col-sm-4")
                    .append($("<button />").attr({
                        "id": "btnverifycode",
                        "type": "button",
                        "class": "btn btn-primary",
                        "onclick":"return formRegisterVaildCode(this);"
                    }).html("获取验证码")));
                break;
            case "9":
                reObj = $("<div />").attr("class", "row-item form-group")
                    .append($("<ul />").addClass("nav nav-list")
                    .append($("<li />").addClass("divider")));
                break;
            default:
                reObj = null;
                break;
        }
        if (reObj != null) {
            if (obj.isShow == -1)
                reObj.hide();

            if (obj.isRead == 1 && obj.value!='')
                reObj.find(".form-control").attr("readonly", "readonly");
        }
        return reObj;
    }
}

function showQRImg(sceneid,type) {
    function na() { }

    //加载此页面的时候就生成二维码不好，浪费次数，点击按钮的时候再生成
    var data = "sceneid=" + sceneid;
    callAjaxJson("xswxinterface/getQRcode.aspx", data, function (obj) {
        //alertMsg("a112231");
        if (obj != null) {
            //alertMsg("a1231");
            var jObj = JSON.parse(obj);
            if (jObj.code == 1) {
                var form = $("<div />").attr("class", "row text-center").append($("<img />").attr({
                    "src": jObj.message,
                    "width": "100%"
                }));
                //alertMsgConfirm(form, "我的二维码", na);
                //美女扫一扫即确认约会成功
                if (type == 2) BootstrapDialog.confirm(form, "美女扫一扫即确认约会成功", "确定", "取消", na);
                else BootstrapDialog.confirm(form, "我的二维码", "确定", "取消", na);
            }
            else {
                alertMsg(jObj.message);
            }
        } else {
            alertMsg("解析异常，请稍后再试！");
        }
    });


}

function evalbox(id,oldstatus) {
    var list = [{ "name": "资料相符", "index": 1 }, { "name": "美女态度", "index": 2 }, { "name": "总体感受", "index": 3 }];
    var form = $("<div />").append($("<div />").attr("class", "row row-item starname")
                .append($("<div />").addClass("col-xs-3 col-sm-3").html("{name}"))
                .append($("<input />").attr({
                    "id": "rate{index}",
                    "type": "hidden",
                    "value": "4"
                }))
                .append($("<div />").addClass("col-xs-9 col-sm-9 revinp")
                .append($("<span />").addClass("level")
                    .append("<i class='level_solid' cjmark=''></i><i class='level_solid' cjmark=''></i><i class='level_solid' cjmark=''></i><i class='level_solid' cjmark=''></i><i class='level_hollow' cjmark=''></i>"))
                .append($("<span />").addClass("revgrade").html("好"))
                ));
    var form1 = $("<div />");
    $.each(list, function (i, v) {
        form1.append(form.strFormat(v));
    })
    form1.append($("<input />").attr({
        "id": "orderid",
        "type": "hidden",
        "value": id
    })).append($("<input />").attr({
        "id": "oldstatus",
        "type": "hidden",
        "value": oldstatus
    }));
    //alertMsgConfirm(form1, "评价美女", submiteval());
    BootstrapDialog.confirm(form1, "评价美女", "提交", "取消", function (torf) {
        if (torf) {
            var id = $("#orderid").val();
            var oldstatus = $("#oldstatus").val();
            var r1 = $("#rate1").val();
            var r2 = $("#rate2").val();
            var r3 = $("#rate3").val();
            o2oresponse(id, oldstatus, 4, ",评价", r1, r2, r3, 0);
        } else {
            //alertMsg("sdfs1111");
        }
    });
}

function appealbox(id,oldstatus,type) {
    var list1 = [{ "name": "我在路上马上到", "index": 1 }, { "name": "我到了没看到美女", "index": 2 }];
    var list2 = [{ "name": "我在路上马上到", "index": 1 }, { "name": "我到了没看到客户", "index": 2 }, { "name": "客户不让我扫码", "index": 3 }];

    var form=$("<div />").append( $("<label />").addClass("btn btn-primary form-control")
                .append($("<input />").attr({
                    "type": "radio",
                    "name": "appeal",
                    "value":"{name}"
                })).append("{name}"));

    var form1 = $("<div />").append($("<div />").attr("class", "row")
                .append($("<div />").addClass("col-xs-2 col-sm-2"))
                .append($("<div />").addClass("col-xs-8 col-sm-8 btn-group-vertical").attr("data-toggle", "buttons"))
                .append($("<div />").addClass("col-xs-2 col-sm-2"))
                );
    var list=(type==1?list1:list2);
    $.each(list, function (i, v) {
        form1.find('.btn-group-vertical').append(form.strFormat(v));
    })

    form1.append($("<input />").attr({
        "id": "orderid",
        "type": "hidden",
        "value": id
    })).append($("<input />").attr({
        "id": "oldstatus",
        "type": "hidden",
        "value": oldstatus
    }));
    //alertMsgConfirm(form1, "评价美女", submiteval());
    BootstrapDialog.confirm(form1, "申诉", "确定", "取消", function (torf) {
        if (torf) {
            var appeal = $("input[name='appeal']:checked").val(); 
            if(appeal==undefined||appeal=="")
            {
                alertMsg("请先选择一项");
                return;
            }

            var id = $("#orderid").val();
            var oldstatus = $("#oldstatus").val();
            o2oresponse(id, oldstatus, -4, ","+(type==1?"客户申诉":"美女申诉")+appeal, 0, 0, 0, 0);
        } else {
            //alertMsg("sdfs1111");
        }
    });
}

function changegoodImg(btn,stnum) //鼠标移入，更换图片
{
    btn.src = "goodstar.png";
    nbtn = btn.previousSibling;
    for (j = 0; j < stnum; j++) {
        nbtn.src = "goodstar.png";
        nbtn = nbtn.previousSibling;
    }
}
function changeback(btn, stnum)  //鼠标移出，换回原来的图片
{
    btn.src = "emptystar.jpg";
    nbtn = btn.previousSibling;
    for (j = 0; j < stnum; j++) {
        nbtn.src = "emptystar.jpg";
        nbtn = nbtn.previousSibling;
    }
}

function follow(thisbtn,memberid, contactid) {
    var data;
    data = "memberid=" + memberid + "&contactid=" + contactid + "&way=1";
    callAjaxJson("xswxinterface/mkrelation.aspx", data, function (obj) {
        var jObj = JSON.parse(obj);
        if (jObj.code != "1")
            alertMsg(jObj.message);
        else {
            $(thisbtn).html("取消关注");
            $(thisbtn).attr("onclick", "unfollow(this," + memberid + "," + contactid + ")");
        }
    });
}

function unfollow(thisbtn, memberid, contactid) {
    var data;
    data = "memberid=" + memberid + "&contactid=" + contactid + "&way=0";
    callAjaxJson("xswxinterface/mkrelation.aspx", data, function (obj) {
        var jObj = JSON.parse(obj);
        if (jObj.code != "1")
            alertMsg(jObj.message);
        else {
            $(thisbtn).html("&nbsp;&nbsp;关 注&nbsp;&nbsp;");
            $(thisbtn).attr("onclick", "follow(this," + memberid + "," + contactid + ")");
        }
    });
}

function initrelationbtn(relation,memberid,contactid)
{
    var btn = $("#btnrelation");
    if (relation == 0) {
        btn.html("&nbsp;&nbsp;关 注&nbsp;&nbsp;");
        btn.attr("onclick", "follow(this," + memberid + "," + contactid + ")");
    }
    else if (relation == 1)
    {
        btn.html("取消关注");
        btn.attr("onclick", "unfollow(this," + memberid + "," + contactid + ")");
    }
}

function getExchangData(thisSel)
{
    var targetList = $("#target");
    targetList.html("");

    var data = "excode=" + $(thisSel).val();
    callAjaxJson("webinterface/ExchangeData.aspx", data, function (obj) {
        if (obj != null) {
            var jObj = JSON.parse(obj);
            if (jObj.code == 1) {
                //这里jObj.message是订单号
                jsonList = JSON.parse( jObj.data);
                renderpage(jsonList);
            }
        } else {
            alertMsg("解析异常，请稍后再试！");
        }
    });
}

function submitarrangement(thisbtn,contactid)
{
    if ($("#location").val() == "")
    {
        alertMsg("请选择地点");
        return;
    }
    var data = "";
    data = BuildUInfo(data);
    callAjaxJson("xswxinterface/mko2oorder.aspx", data, function (obj) {
        if (obj != null) {
            var jObj = JSON.parse(obj);
            if (jObj.code == 1){
                //这里jObj.message是订单号
                var snote;
                if ($(thisbtn).html() == "更新") snote = "更新成功";
                else snote = "添加成功";
                alertMsg(snote, function () { window.location.href = "arrangementlist.aspx?fromwhere=me&contactid=" + contactid; });
            }
            else
                alertMsg(jObj.message);
        } else {
            alertMsg("解析异常，请稍后再试！");
        }
    });
}

function cancelo2oorder(orderid)
{
    BootstrapDialog.confirm("确定要取消订单吗？", "取消订单", "确定取消", "点错了", function (torf) {
        if (torf)
            o2oresponse(orderid,0,-11,",自行取消",0,0,0,0);
    });
}