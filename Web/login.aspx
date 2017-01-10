<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<%@ Register TagPrefix="MPuc" TagName="headcontent" Src="UserControl/headcontent.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="mobilenav" Src="UserControl/mobilenav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="desktopnav" Src="UserControl/desktopnav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="footer" Src="UserControl/footer1.ascx"%>
<!DOCTYPE html>
<html>
<head>
<title>EshineAspNet - <asp:Localize ID="Localize1" runat="server" Text='<%$ Resources:GResource,titletext %>'></asp:Localize></title>

<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
		<link rel="stylesheet" media="screen" href="css/sequencejs-theme.modern-slide-in.css" />
		
		
<MPuc:headcontent ID="Headcontent1" runat="server"/>
<script src="JS/jquery.sequence-min.js"></script>
		<script src="JS/sequencejs-options.modern-slide-in.js"></script>
        <SCRIPT src="JS/mp.js" type="text/javascript"></SCRIPT>
</head>
<body class='logins'>
<MPuc:mobilenav ID="Mobilenav1" runat="server"/>
<form runat="server" class="simple_form new_login_context">
<div class='wrapper' data-behavior='Navigation' style=" padding-top:60px; padding-bottom:0px;">
<MPuc:desktopnav runat="server"/>



<div class="sequence-theme"  id='hero'>
			<div id="sequence">

            

<div style="margin-top:100px;">
            <div class=' twelvecol last '>
<div class=' tile' style="background:#FFFFFF;background:rgba(255,255,255,0.7);position:relative;z-index:999;">
<div id='Div1'></div>
<h3 style="color:Black">
<asp:Label ID="Label1" runat="server" Text="登录" meta:resourcekey="Label1Resource1"></asp:Label></h3>
<div class='fields'>
<div  class="simple_form new_login_context">
<div class="input email required">
<asp:TextBox  autofocus="autofocus" class="string email required" ID="TextBox1" runat="server" placeholder='<%$ Resources:Label2Resource1.Text%>' size="50" ></asp:TextBox>
</div>
<div class="input password required">
<asp:TextBox class="password required" ID="TextBox2" runat="server" TextMode="Password" minlength="6"  size="50"  placeholder='<%$ Resources:Label4Resource1.Text%>'></asp:TextBox>
</div>
<div class='submit_button'>
<div class='spinner'></div>
<asp:Button ID="Button1" runat="server" Text="登录"  class="action blue_button button session_button" onclick="Button1_Click" meta:resourcekey="Button1Resource1"/>
<asp:HyperLink ID="HyperLink2" runat="server" Visible="false" class="action bluedark_button button session_button" meta:resourcekey="Button2Resource1" NavigateUrl="~/forgotpassword.aspx?f=fp">首次登录</asp:HyperLink>

<asp:HyperLink class='forgot_password ml10' style="font-size:12px;" runat="server" NavigateUrl="forgotpassword.aspx"  meta:resourcekey="HyperLink1Resource1">忘记密码?</asp:HyperLink>
</div>
</div>
</div>

</div>
</div></div>


				<img class="sequence-prev" src="images/bt-prev.png" alt="Previous Frame" />
				<img class="sequence-next" src="images/bt-next.png" alt="Next Frame" />

				<ul class="sequence-canvas" style="z-index:-10;">
					<li class="animate-in">
						<h2 class="title" style=" top:650px;"><asp:Label ID="Label2" runat="server" Text="敏捷式开发" meta:resourcekey="flash1"></asp:Label></h2>
						<h3 class="subtitle" style=" top:710px;"><asp:Label ID="Label3" runat="server" Text="诸多开箱即用的功能模块" meta:resourcekey="flash2"></asp:Label></h3>
						<img class="model" src="images/model1.png" />
					</li>
					<li>
						<h2 class="title" style=" top:650px;"><asp:Label ID="Label4" runat="server" Text="微信公众号支持" meta:resourcekey="flash3"></asp:Label></h2>
						<h3 class="subtitle" style=" top:710px;"><asp:Label ID="Label5" runat="server" Text="涵盖智能聊天机器人，智能客服" meta:resourcekey="flash4"></asp:Label></h3>
						<img class="model" src="images/model2.png"  />
					</li>
					<li>
						<h2 class="title" style=" top:650px;"><asp:Label ID="Label7" runat="server" Text="永久开源" meta:resourcekey="flash5"></asp:Label></h2>
						<h3 class="subtitle" style=" top:710px;"><asp:Label ID="Label6" runat="server" Text="开源是永远的王道" meta:resourcekey="flash6"></asp:Label></h3>
						<img class="model" src="images/model3.png"  />
					</li>
				</ul>

				<ul class="sequence-pagination">
					<li><img src="images/tn1.png" alt="Model 1" /></li>
					<li><img src="images/tn2.png" alt="Model 2" /></li>
					<li><img src="images/tn3.png" alt="Model 3" /></li>
				</ul>
			</div>
		</div>

</div>

</form>

<MPuc:footer ID="ucfooter" runat="server"/>

</body>
</html>