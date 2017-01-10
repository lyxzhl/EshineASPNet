<%@ Page Language="C#" AutoEventWireup="true" CodeFile="benefitplan.aspx.cs" Inherits="benefitplan" %>

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
<body class='blogs'>

<MPuc:mobilenav runat="server" ID="Unnamed2"/>
<div class='wrapper' data-behavior='Navigation'>

<form id="Form1" runat="server">
<MPuc:desktopnav runat="server" ID="Unnamed3"/>


<div class='container' data-behavior='Blog'>
<div class='row'>
<div class='twocol'></div>
<div class='eightcol'>
<div class='blog'>
<div class='tile'>
<div class='date hidden'>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
<hr>
<h2>
    <asp:HyperLink ID="HyperLink1" runat="server"  Target="_blank">福利计划</asp:HyperLink>
</h2>
<article>
<%=content %>

<div class='continue'>
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://www.eshinelee.com/" Target="_blank" Text='<%$ Resources:GResource,downloadpdfdoc %>' Font-Bold="True" Font-Size="X-Large"></asp:HyperLink>
</div>
</article>
<asp:HyperLink ID="HyperLink3" runat="server" class='button blue_button'  NavigateUrl="~/abc.aspx" style="float:right; margin-top:-40px; width:100px;height:40px; font-size:18px; line-height:38px;"  Text='' Visible="false"></asp:HyperLink>
<div class='bottom mobile_hidden hidden'>

</div>
</div>



</div>
</div>
<div class='twocol last'></div>
</div>
</div>
</form>
</div>
<MPuc:footer ID="ucfooter" runat="server"/>
</body>
</html>


