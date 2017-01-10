<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TermsOfService.aspx.cs" Inherits="TermsOfService" %>
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
<body class='terms_of_service'>
<MPuc:mobilenav ID="Mobilenav1" runat="server"/>
<form runat="server">
<div class='wrapper' data-behavior='Navigation'>
<MPuc:desktopnav runat="server"/>

<div class='container' id='terms_of_service'>
<div class='row'>
<div class='onecol'></div>
<div class='tencol'>
<div class='tile'>
<h1 style="font-size:12pt; color:#606060"><asp:Localize ID="Localize2" runat="server" Text='<%$ Resources:GResource,termservice %>'></asp:Localize></h1>
<%=maincontent%>


</div>

    <asp:Panel ID="Panel1" runat="server" style="text-align:center; margin-top:15px;" Visible="False">
        <asp:Button class="gray_button button" ID="Button1" runat="server" Text='<%$ Resources:GResource,termservice %>' 
            OnClientClick='<%$ Resources:GResource,dontagreemsg %>' 
            onclick="Button1_Click"  />&nbsp;&nbsp;
    <asp:Button class=' blue_button button' ID="Button2" runat="server" Text='<%$ Resources:GResource,iagree %>' 
            onclick="Button2_Click" />
    </asp:Panel>


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
