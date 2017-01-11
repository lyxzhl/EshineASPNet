<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testuploadpic.aspx.cs" Inherits="Senparc.Weixin.MP.Sample.WebForms.webpage.testuploadpic" %>

<!DOCTYPE html>

<html>

	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no">
		<meta name="apple-mobile-web-app-capable" content="yes">
		<meta name="apple-mobile-web-app-status-bar-style" content="black">
		<title>心水</title>
		<link rel="stylesheet" href="css/bootstrap.min.css" />
		<link rel="stylesheet" href="css/bootstrap-dialog.min.css" />
		<link rel="stylesheet" href="css/icon.css" />
		<link rel="stylesheet" href="css/main.css" />
        <script type="text/javascript" src="js/jquery.js"></script>
	<script type="text/javascript" src="js/bootstrap.min.js"></script>
	<script type="text/javascript" src="js/bootstrap-dialog.js" charset="gbk"></script>
	<script type="text/javascript" src="js/main.js"></script>

        <style type="text/css">

.level .level_solid,.level .level_hollow{float:left;background-image:url("img/icon2.png");background-repeat:no-repeat;display:inline-block;width:16px;height:16px;}
.level .level_solid{background-position:0px 0px;}
.level .level_hollow{background-position:-21px 0px;}
.revgrade{margin-left:20px;}
</style>

        <script type="text/javascript">
var degree = ['','很差','差','中','良','优','未评分'];

$(function(){
	//点星星
	$(document).on('mouseover','i[cjmark]',function(){
		var num = $(this).index();
		var list = $(this).parent().find('i');
		for(var i=0;i<=num;i++){
			list.eq(i).attr('class','level_solid');
		}
		for(var i=num+1,len=list.length-1;i<=len;i++){
			list.eq(i).attr('class','level_hollow');
		}
		$(this).parent().next().html(degree[num+1]);

	})
	//点击星星
	$(document).on('click','i[cjmark]',function(){
		var num = $(this).index();
		var pmark = $(this).parents('.revinp');
		var mark = pmark.prevAll('input');
		
		mark.val(num+1);
	})

})
</script>
	</head>

	<body>

	<div class="">
		<div class="row row-item">
            <div class="col-xs-5 col-sm-5">经历真实性</div>
			<input type="hidden" id="rate1" value="4">
			<div class="col-xs-7 col-sm-7 revinp">
				<span class="level">
					<i class="level_solid" cjmark=""></i>
					<i class="level_solid" cjmark=""></i>
					<i class="level_solid" cjmark=""></i>
					<i class="level_solid" cjmark=""></i>
					<i class="level_hollow" cjmark=""></i>
				</span>
				<span class="revgrade">良</span>
			</div>
		</div>
		<div  class="row row-item">
            <div class="col-xs-5 col-sm-5">技能真实性</div>
			<input type="hidden" id="rate2" value="4">
			<div class="col-xs-7 col-sm-7 revinp">
				<span class="level">
					<i class="level_solid" cjmark=""></i>
					<i class="level_solid" cjmark=""></i>
					<i class="level_solid" cjmark=""></i>
					<i class="level_solid" cjmark=""></i>
					<i class="level_hollow" cjmark=""></i>
				</span>
				<span class="revgrade">良</span>
			</div>
		</div>
		<div  class="row row-item">
            <div class="col-xs-5 col-sm-5">遵时守信</div>
			<input type="hidden" id="rate3" value="4">
			<div class="col-xs-7 col-sm-7 revinp">
				<span class="level">
					<i class="level_solid" cjmark=""></i>
					<i class="level_solid" cjmark=""></i>
					<i class="level_solid" cjmark=""></i>
					<i class="level_solid" cjmark=""></i>
					<i class="level_hollow" cjmark=""></i>
				</span>
				<span class="revgrade">良</span>
			</div>
		</div>

        <button type="button" class="btn btn-default" onclick="evalbox();">评价</button>
	</div>


         <script type="text/javascript">
     jQuery(document).ready(function(){
        $.ajax({
             type: "get",
             async: false,
            //url: "http://api.map.baidu.com/place/v2/detail?uid=923ffd004daf7faed92f28cb&ak=96af9ae4cc22abe993d600cedc193fc2&output=json&scope=2",
             url: "http://map.baidu.com/detail?qt=ninf&uid=923ffd004daf7faed92f28cb",
             dataType: "jsonp",
             jsonp: "callback",//传递给请求处理程序或页面的，用以获得jsonp回调函数名的参数名(一般默认为:callback)
             jsonpCallback:"flightHandler",//自定义的jsonp回调函数名称，默认为jQuery自动生成的随机函数名，也可以写"?"，jQuery会自动为你处理数据
             success: function(json){
                 alert('您查询到信息：票价： ' + json.status + ' 元，余票： ' + json.detail_info + ' 张。');
             },
             error: function(){
                 alert('fail');
             }
         });
     });
     </script>

	</body>
  
</html>