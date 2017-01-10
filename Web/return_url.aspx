<%@ Page Language="C#" AutoEventWireup="true" CodeFile="return_url.aspx.cs" Inherits="return_url" %>


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
</head>
<body class='logins'>
<MPuc:mobilenav ID="Mobilenav1" runat="server"/>
<form id="Form1" runat="server">
<div class='wrapper' data-behavior='Navigation'>
<MPuc:desktopnav ID="Desktopnav1" runat="server"/>

<div class='container' style="margin-bottom:100px;">
<div class='row'>
<div class='twelvecol last'>
<div class='tile'>
<div id='errors'></div>
<h3><asp:Label ID="Label4" runat="server" Text='<%$ Resources:GResource,payresult %>' ></asp:Label></h3>
<div class='fields'>
<div  class="simple_form new_login_context" id="new_login_context">
    <asp:Panel ID="Panel1" runat="server"  meta:resourcekey="Panel1Resource1">
<P>
<asp:Label ID="Label1" runat="server" Text="Label" meta:resourcekey="Label1Resource1"></asp:Label>
</P>
<asp:HyperLink ID="HyperLink1" class="action blue_button button session_button" runat="server" Text='<%$ Resources:GResource,backtohome %>' NavigateUrl="index.aspx"></asp:HyperLink>
    </asp:Panel>

    
</div>
</div>

</div>
</div>
</div>
</div>

</div>
</form>
<MPuc:footer ID="ucfooter" runat="server"/>

</body>
</html>
