<%@ Page Language="C#" AutoEventWireup="true" CodeFile="safeemail.aspx.cs" Inherits="safeemail" %>

<%@ Register TagPrefix="MPuc" TagName="headcontent" Src="UserControl/headcontent.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="mobilenav" Src="UserControl/mobilenav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="desktopnav" Src="UserControl/desktopnav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="footer" Src="UserControl/footer1.ascx"%>
<!DOCTYPE html>
<html>
<head>
<title>EshineAspNet - <asp:Localize ID="Localize1" runat="server" Text='<%$ Resources:GResource,titletext %>'></asp:Localize></title>
<MPuc:headcontent runat="server" ID="Unnamed1"/>
<SCRIPT src="JS/mp.js" type="text/javascript"></SCRIPT>
</head>
<body class='signups'>
<MPuc:mobilenav runat="server" ID="Unnamed2"/>
<form id="Form1" runat="server">
<div class='wrapper' data-behavior='Navigation'>
<MPuc:desktopnav runat="server" ID="Unnamed3"/>

<div class='container signup'>
<div class="simple_form new_signup_context">
    <asp:Panel ID="Panel1" runat="server" class='choose_level tile'>
<div class='row'>
<div class='twelvecol'>
<h2><asp:Label ID="Label2" runat="server" Text="您设置的绑定邮箱" meta:resourcekey="Label2Resource1"></asp:Label></h2>
<h4 class='mobile_hidden'></h4>
</div>
</div>
<div class='row'>
<div class='fourcol'></div>
<div class='fourcol'>
<br /><br />
<div class="input string required">
    <asp:Label ID="Label3" runat="server" Text="邮箱：" meta:resourcekey="Label3Resource1"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="Label" meta:resourcekey="Label4Resource1"></asp:Label>
</div>
<br />
<div class="input string required">
<asp:Button ID="Button4" runat="server" Text="返回"  class="button bluedark_button" onclick="Button4_Click"  meta:resourcekey="Button4Resource1"/>
<asp:Button ID="Button0" runat="server" Text="修改"  class="button blue_button" onclick="Button0_Click"  meta:resourcekey="Button0Resource1" />
</div>

</div>
<div class='fourcol last'>
</div>
</div>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" class='choose_level tile' Visible="False">
<div class='row'>
<div class='twelvecol'>
<h2><asp:Label ID="Label5" runat="server" Text="修改绑定邮箱" meta:resourcekey="Label5Resource1"></asp:Label></h2>
<h4></h4>
</div>
</div>
<div class='row sizes'>
<div class='fourcol'></div>
<div class='fourcol'>
<br /><br />
<div class="input string required">
    <asp:Label ID="Label7" runat="server" Text="新邮箱：" meta:resourcekey="Label6Resource1"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server" class="string email required" meta:resourcekey="TextBox4Resource1" type="email"></asp:TextBox>
</div>
<br />
<div class="input string required">
<asp:Button ID="Button1" runat="server" Text="返回"  class="button bluedark_button" onclick="Button4_Click"  meta:resourcekey="Button4Resource1"/>
<asp:Button ID="Button3" runat="server" Text="确认提交" class="button blue_button" onclick="Button3_Click" meta:resourcekey="Button3Resource1"/>
</div>
</div>
<div class='fourcol last'>
</div>
</div>
    </asp:Panel>

<asp:Panel ID="Panel3" runat="server" class='choose_level tile' Visible="False">
<div class='row'>
<div class='twelvecol'>
<h1><asp:Label ID="Label10" runat="server" Text="修改成功" meta:resourcekey="Label7Resource1"></asp:Label></h1>
<h4></h4>
</div>
</div>
<div class='row sizes'>
<div class='fourcol'></div>
<div class='fourcol'>

<div class="input string required">
<br /><br />
    <asp:Label ID="Label8" runat="server" Text="已经向您的新邮箱" meta:resourcekey="Label8Resource1"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="False" Font-Underline="True" ForeColor="Blue" meta:resourcekey="Label1Resource1"></asp:Label>
    <asp:Label ID="Label9" runat="server" Text="发送激活邮件，请前往激活!" meta:resourcekey="Label9Resource1"></asp:Label>
</div>
<div class="input string required">
<br />
<asp:Button ID="Button6" runat="server" Text="返回"  class="button bluedark_button" onclick="Button4_Click"  meta:resourcekey="Button4Resource1"/>
<asp:HyperLink ID="HyperLink1" runat="server" class="button blue_button" NavigateUrl="~/reserveexam.aspx" Text="预约体检"></asp:HyperLink>
</div>

</div>
<div class='fourcol last'>
<ul class='selling_points mobile_hidden'>
<li>

</li>
</ul>
</div>
</div>

    </asp:Panel>

    

    

</div>
</div>

</div>
</form>
<MPuc:footer ID="ucfooter" runat="server"/>

</body>
</html>

