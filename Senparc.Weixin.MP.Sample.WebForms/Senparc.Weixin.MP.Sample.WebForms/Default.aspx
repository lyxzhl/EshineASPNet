<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Senparc.Weixin.MP.Sample.WebForms._Default" %>
<% var domainName = "http://weixin.senparc.com"; %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>Senparc.Weixin.MP - 微信公众平台SDK</title>
    <meta name="keywords" content="微信SDK,微信公众账号,SDK,微信公众平台,Senparc.Weixin,开发者,第三方工具,AppStore,微微嗨,盛派网络,Senparc" />
    <meta name="description" content="Senparc.Weixin，使用率最高的微信公众账号/企业号 C# SDK，帮助第三方开发者轻松实现微信公众账号和企业号开发。" />
    <link href="<%= domainName %>/Content/css?v=vtgTjlCxGfgXkawcGk68h72BbTEmgKiuVRyGhvjniqo1" rel="stylesheet"/>
    	<link rel="stylesheet" href="webpage/css/bootstrap.min.css" />
    <link href="<%= domainName %>/Content/darktooltip.min.css" rel="stylesheet" />
    <script src="<%= domainName %>/bundles/modernizr?v=jmdBhqkI3eMaPZJduAyIYBj7MpXrGd2ZqmHAOSNeYcg1"></script>

    <script src="<%= domainName %>/bundles/jquery?v=VW9pyEu5wNXvHqV5Z1MO5o_3VH7F3gpXdoWotCkzj9k1"></script>

    <script src="<%= domainName %>/Content/danktooltip/js/jquery.darktooltip.min.js"></script>
    
</head>
<body>
    <div class="content">
        <div class="senparc-header">
            <div class="wrapper">
                <div class="header-title"><a href="/">微信公众平台管理</a></div>
                <div class="navbar-collapse">
                    <ul class="nav-catalog">
                        <li><a href="/">首页</a></li>
                        <li><a href="http://sdk.weixin.senparc.com/Menu">自定义菜单设置工具</a></li>
                        <li><a href="http://mp.weixin.qq.com/wiki/index.php?title=%E6%B6%88%E6%81%AF%E6%8E%A5%E5%8F%A3%E6%8C%87%E5%8D%97">查看微信6.x官方API</a></li>
                    </ul>
                    <div class="clear"></div>
                </div>
                <div class="clear"></div>
            </div>
        </div>
            
    <br />
 <form runat="server">
     <asp:TextBox ID="TextBox1" Width="500" runat="server" CssClass="control-input" place-holder="Access Token"></asp:TextBox><asp:Button ID="Button1" runat="server" CssClass="control-btn" Text="获取access_token" OnClick="Button1_Click" />



     <br />
        </form>


<div class="wrapper">

  


   

    <div class="line"></div>

    
</div>

        
        
        
    <script>
        $(function () {
            $(".test table td:not(:empty)").hover(function () {
                $(this).addClass('currentTestItem');
            }, function () {
                $(this).removeClass('currentTestItem');
            });
        });
    </script>

        
    </div>
</body>
</html>
