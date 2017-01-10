<%@ Page Language="C#" AutoEventWireup="true" CodeFile="safecenter.aspx.cs" Inherits="safecenter" %>
<%@ Register TagPrefix="MPuc" TagName="headcontent" Src="UserControl/headcontent.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="mobilenav" Src="UserControl/mobilenav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="desktopnav" Src="UserControl/desktopnav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="footer" Src="UserControl/footer1.ascx"%>
<!DOCTYPE html>
<html>
<head>
<title>EshineAspNet - <asp:Localize ID="Localize1" runat="server" Text='<%$ Resources:GResource,titletext %>'></asp:Localize></title>
<MPuc:headcontent ID="Headcontent1" runat="server"/>
<SCRIPT src="JS/mp.js" type="text/javascript"></SCRIPT>
<LINK rel=stylesheet type=text/css href="CSS/safecenter.css">
</head>
<body class='terms_of_service'>
<MPuc:mobilenav ID="Mobilenav1" runat="server"/>
<form id="Form1" runat="server">
<div class='wrapper' data-behavior='Navigation'>
<MPuc:desktopnav ID="Desktopnav1" runat="server"/>

<div class='container' id='terms_of_service'>
<div class='row'>
<div class='threecol'></div>
<div class='sixcol'>
<div class='tile'>
<h1 style="text-align:center"><asp:Label ID="Label5" runat="server" Text="安全中心"  meta:resourcekey="Label5Resource1"></asp:Label></h1>
<DIV class=" password_management">
<DIV class="pm_index">
<UL style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='', sizingMethod='scale')" >
  <LI><A href="changepassword.aspx"><I class="icon11"></I>
  		 
  <H3><asp:Label ID="Label6" runat="server" Text="修改密码" 
          meta:resourcekey="Label6Resource1"></asp:Label></H3>
      <asp:Label ID="Label7" runat="server" Text="		登录后修改您的登录密码		 " 
          meta:resourcekey="Label7Resource1"></asp:Label></A></LI>
  <LI class="hidden"><A><I class="icon7"></I>		 
  <H3><asp:Label ID="Label8" runat="server" Text="绑定身份证号" 
          meta:resourcekey="Label8Resource1"></asp:Label></H3>		
      <asp:Label ID="Label1" runat="server" meta:resourcekey="Label1Resource1"></asp:Label><asp:Label
          ID="Label9" runat="server" Text="如需修改请联系客服！		 " 
          meta:resourcekey="Label9Resource1"></asp:Label></A></LI>
  <LI><A href="safequestions.aspx"><I class="icon1"></I>
  		 
  <H3><asp:Label ID="Label10" runat="server" Text="安全提问" 
          meta:resourcekey="Label10Resource1"></asp:Label></H3>		
      <asp:Label ID="Label2" runat="server" Text="已设置安全提问" 
          meta:resourcekey="Label2Resource1"></asp:Label>		 </A></LI>
  <LI><A href="safeemail.aspx"><I class="icon9"></I>		 
  <H3><asp:Label ID="Label11" runat="server" Text="绑定邮箱号" 
          meta:resourcekey="Label11Resource1"></asp:Label></H3>		
      <asp:Label ID="Label3" runat="server" Text="Label" 
          meta:resourcekey="Label3Resource1"></asp:Label>		 </A></LI>
  <LI><A href="safemobile.aspx"><I 
  class="icon2"></I>		 
  <H3><asp:Label ID="Label12" runat="server" Text="绑定手机号" 
          meta:resourcekey="Label12Resource1"></asp:Label></H3>		
      <asp:Label ID="Label4" runat="server" Text="Label" 
          meta:resourcekey="Label4Resource1"></asp:Label>		 </A></LI></UL>
</DIV>
</DIV>

</div>



<div class='onecol last'></div>
</div>
<div class='threecol last'></div>
</div>
</div>
<link href="assets/_static_content.css" media="screen" rel="stylesheet" type="text/css" />

</div>
</form>
<MPuc:footer ID="ucfooter" runat="server"/>
</body>
</html>
