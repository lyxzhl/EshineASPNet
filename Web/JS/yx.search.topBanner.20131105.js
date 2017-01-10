window['YX.search.topBanner.time'] && window['YX.search.topBanner.time'].push(new Date());
YXsearchTopBanner=function(){var startTime=new Date("December 09, 2013 00:00:00").getTime();var endTime=new Date("December 12, 2013 23:59:59").getTime();var nowServerTime=new Date(window["serverTime"]).getTime();var isClosed=G.header.common.getCookie("topbannerclosed")?G.header.common.getCookie("topbannerclosed"):"0";if(isClosed=="1"){return;}
var bannerContent='<div class="db12" id="topBanner12">\
  <div class="db12_inner">\
   <a rg="2022_1" target="_blank" href="http://u.yixun.com/1212" title="易马当先" class="db12_lk1">易马当先</a>\
   <a rg="2022_2" target="_blank" href="http://u.yixun.com/it12" title="IT数码主会场" class="db12_lk2">IT数码主会场</a>\
   <a rg="2022_3" target="_blank" href="http://u.yixun.com/13657" title="电脑整机" class="db12_lk3">电脑整机</a>\
   <a rg="2022_4" target="_blank" href="http://u.yixun.com/13641" title="摄影摄像" class="db12_lk4">摄影摄像</a>\
   <a rg="2022_5" target="_blank" href="http://u.yixun.com/jiadianquanpinlei" title="家用电器主会场" class="db12_lk5">家用电器主会场</a>\
   <a rg="2022_6" target="_blank" href="http://u.51buy.com/xiaodian" title="生活小电" class="db12_lk6">生活小电</a>\
   <a rg="2022_7" target="_blank" href="http://u.yixun.com/dajiadian" title="家装大电" class="db12_lk7">家装大电</a>\
   <a rg="2022_8" target="_blank" href="http://u.yixun.com/phone" title="手机通讯主会场" class="db12_lk8">手机通讯主会场</a>\
   <a rg="2022_9" target="_blank" href="http://u.yixun.com/phonesx" title="三星专场" class="db12_lk9">三星专场</a>\
   <a rg="2022_10" target="_blank" href="http://u.yixun.com/sjpjmj" title="手机配件" class="db12_lk10">手机配件</a>\
   <a rg="2022_11" target="_blank" href="http://u.yixun.com/baihuo" title="食品百货主会场" class="db12_lk11">食品百货主会场</a>\
   <a rg="2022_12" target="_blank" href="http://u.yixun.com/jqgh" title="个护家清" class="db12_lk12">个护家清</a>\
   <a rg="2022_13" target="_blank" href="http://u.yixun.com/food" title="美食年货" class="db12_lk13">美食年货</a>\
   <a rg="2022_14" target="_blank" href="http://tuan.yixun.com" title="团购" class="db12_lk14">团购</a>\
   <a rg="2022_15" target="_blank" href="http://u.yixun.com/weiya" title="年会礼品" class="db12_lk15">年会礼品</a>\
   <a rg="2022_1001" href="#" title="关闭" class="db12_close">关闭</a>\
  </div>\
 </div>';if(nowServerTime>=startTime&&nowServerTime<=endTime){$("body").prepend(bannerContent);$("#topBanner12 .db12_close").click(function(){$("#topBanner12").hide();G.header.common.addCookie("topbannerclosed","1","/",0,"yixun.com");});}};YXsearchTopBanner();
window['YX.search.topBanner']='21775:20131105:20131205101049';
window['YX.search.topBanner.time'] && window['YX.search.topBanner.time'].push(new Date());/*  |xGv00|b0e2fa5eea68d5ae0a22850b7acb459a */