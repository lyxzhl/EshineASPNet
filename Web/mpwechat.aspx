<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mpwechat.aspx.cs" Inherits="mpwechat" %>

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
<body class='terms_of_service'>
<MPuc:mobilenav ID="Mobilenav1" runat="server"/>
     <form id="Form1" runat="server">
<div class='wrapper' data-behavior='Navigation'>
<MPuc:desktopnav ID="Desktopnav1" runat="server"/>

<div class='container' id='terms_of_service'>
<div class='row'>
<div class='onecol'></div>
<div class='tencol'>
<div class='tile'>
<h1 style="font-size:26px; color:#606060"><asp:Localize ID="Localize2" runat="server" Text='<%$ Resources:GResource,aboutus %>'></asp:Localize></h1>
待完善！


</div>
<div class='onecol last'></div>
</div>
</div>
</div>
<link href="assets/_static_content.css" media="screen" rel="stylesheet" type="text/css" />

</div>
         </form>
<MPuc:footer ID="ucfooter" runat="server"/>
</body>
</html>