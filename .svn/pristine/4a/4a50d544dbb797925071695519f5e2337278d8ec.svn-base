/*
 * name: page.detail.code_report.js
 * author: leoqqlv
 * usage:
**/
define("page.detail.code_report.10", function(require, exports, module) {
    var _domLoaded = false; // 在页面装载完毕后再行上报
    var reportPool = {}; // 延后上报集合
    // 执行延后上报
    var delayReport = function(){
        for(var n in reportPool){
            var currReport = reportPool[n];
            var currReportUrl = "http://c.isdspeed.qq.com/code.cgi?domain="+n+(currReport.uin?"&uin="+currReport.uin:"")+"&key=cgi,type,code,time,rate";
            var currReportParams = currReport.params;
            for(var i = 0; i < currReportParams.length;i++){
                var currParam = currReportParams[i];
                currReportUrl += "&"+(i+1)+"_1="+currParam.cgi;
                currReportUrl += "&"+(i+1)+"_2="+currParam.type;
                currReportUrl += "&"+(i+1)+"_3="+currParam.code;
                currReportUrl += "&"+(i+1)+"_4="+currParam.time;
                currReportUrl += "&"+(i+1)+"_5="+currParam.rate;
            }
           (new Image()).src = currReportUrl;
        }
        reportPool = {};
        /*
        $("script").each(function(){
            var sname = $(this).attr("name");
            var timeList = window[sname+".time"];
            if(timeList){
                var url = $(this).attr("src");
                var oReport = returnCode({
                    url: sname,
                    sTime: timeList[0]
                });
                switch(timeList.length){
                    case 1:
                        oReport.report(false, 1);//错误码1为加载失败 
                        break;
                    case 2:
                        oReport.report(false, 2);//错误码1为js执行失败
                        break;
                    case 3:
                        oReport.report(true);//成功
                        break;
                }
            }
        });*/
    };
    
    $(window).bind("load", function(){
        _domLoaded = true;
        delayReport();
    });
    /*
    $(window).bind("unload", function(){
        delayReport();
    });*/
    
    var returnCode = function (opt){
        //返回码上报组件
        var option = {
            url : "", //需要上报的接口url，用于上报异步请求的返回码
            //action : "", //需要上报的功能名称，用于拼装伪地址，与url互斥，用于上报跨业务
            sTime : "", //请求开始时间
            eTime : "", //响应结束时间
            retCode : "", //请求返回是否成功，成功1，失败2
            errCode : "", //请求返回错误码：=errcode
            frequence : 1, //采样频率，1/n，这个数值为分母，数字越小采样频率越高
            //refer : location.href, //异步请求的refer是当前页面
            uin : "", //用户QQ(uin) 只做详细记录查询，不做统计； 如果没有上报，cgi会从cookie中去解析uin字段
            domain : "", //设置上报的域名
            //report : report, //进行上报的方法
            isReport:false, //是否已经上报过
            timeout: 5000, //超过这个时间后，将会上报cgi请求失败，会上报errCode=timeoutCode，（404或是没有执行$returnCode.report方法的时候都会上报）
            timeoutCode:444,//超时码
            formatUrl: true//, //是否删除上报url的query参数，默认为true删除
            //reg : reg//跨页面上报的方法，用reg方法启动
        };
        for(var i in opt) {
            option[i] = opt[i];
        }
        if(!option.sTime) {
            //开始计时
            option.sTime = (new Date()).getTime();
        }
        if(option.timeout){
            setTimeout(function(){
                if(!option.isReport){ //没有执行过上报时  就上报
                    option.report(false, option.timeoutCode);
                }
            }, option.timeout);
        }
        
        //返回码上报方法,参数：是否成功请求（true,false），返回码（如果无返回码则直接上报错误码）
        option.report = function(ret, errid) {
            this.isReport = true;
            if(!this.url) {
                return;
            }
            //计时
            if(!this.eTime){
                this.eTime = (new Date()).getTime();
            }
            //是否成功，成功1，失败2
            this.retCode = ret ? 1 : 2;
            this.errCode = isNaN(parseInt(errid)) ? "0" : parseInt(errid);
            var domain = this.url.replace(/^.*\/\//, '').replace(/\/.*/, '');
            this.domain = domain?domain:location.host;
            var timer = this.eTime - this.sTime,
            cgi = encodeURIComponent(this.formatUrl ? this.url.match(/^[\w|\/|.|:|-]*/)[0] : this.url),
            reportUrl = "http://c.isdspeed.qq.com/code.cgi?domain="+this.domain+"&cgi="+cgi+"&type="+this.retCode+"&code="+this.errCode+"&time="+timer+"&rate="+this.frequence+(this.uin ? ("&uin=" + this.uin) : "");
            //采样判断
            if(Math.random() < (1 / this.frequence)) {
                if(_domLoaded){ // 页面资源未加载完成之前不做上报
                    (new Image()).src = reportUrl;
                }else{
                    var self = this;
                    var currParam = {
                        cgi: cgi,
                        type: self.retCode,
                        code: self.errCode,
                        time: timer,
                        rate: self.frequence
                    };
                    if(reportPool[self.domain]){
                        reportPool[self.domain].params.push(currParam);
                    }else{
                        reportPool[self.domain] = {
                            uin: self.uin?self.uin:"",
                            params: [currParam]
                        };
                    }
                    
                }
                if(this.itil){ // itil 逻辑不方便一起处理 暂定方案实时上报
                    (new Image()).src = "http://d.item.yixun.com/n/itil/"+this.itil;
                }
            }
        }
        
        return option;
    };
    
    /**
     * 上报使用方法: ajax参数中增加report字段: 
     * 若为string类型 则返回json的对象下的以该参数为key的值做为返回码 
     * 若为object 参照returnCode的option 其中key为必填字段 指明返回码所取的字段
     */
    jQuery.ajaxPrefilter( "json jsonp", function( s ) {
        if (  s.report ) {
            var $success = s.success || function(){},$error = s.error||function(){};
            var reportOption = typeof(s.report) == "string"?{url: s.url,key:s.report}:s.report;
            var oReport = returnCode(reportOption);
            s.success = function(o){
                oReport.eTime = (new Date()).getTime();
                oReport.isReport = true;
                setTimeout(function(){
                    var rcode = o[reportOption.key];
                    oReport.report(rcode==0?true:false,rcode);
                    oReport = null;
                }, 0);
                
                $success(o);
            };
            s.error = function(xhr, textStates, errorThrown){
                oReport.eTime = (new Date()).getTime();
                oReport.isReport = true;
                setTimeout(function(){
                    var ec = 2000000;
                    switch(textStates){
                        case "timeout":
                            ec = 2010000;
                            break;
                        case "parsererror":
                            ec = 2020000;
                            break;
                        case "notmodified":
                            ec = 2030000;
                            break;
                        case "error":
                            ec = 2040000;
                            break;
                             
                    }
                    if(xhr && xhr.status && !isNaN(xhr.status)){
                        ec += parseInt(xhr.status, 10);
                    }
                    oReport.report(false, ec);
                    oReport = null;
                }, 0);
                
                $error(xhr, textStates, errorThrown);
            };
        }
    });
});/*  |xGv00|278c19ad5f7fc6aa1bd16375cfa60965 */