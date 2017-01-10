<%@ Control Language="C#" AutoEventWireup="true" CodeFile="desktopnav.ascx.cs" Inherits="UserControl_desktopnav" %>
<nav class='mobile_hidden' id='desktop'>
<SCRIPT>
    function sendemail(email) {
        window.location.href = "mailto:" + escape(email);
    }
		</SCRIPT>
<div class='container' runat="server">
<a class='logo' href='index.aspx'>
<img src='Images/logo2.png'>
<asp:Image ID="Image1" runat="server" style="margin-left:10px;" Visible="false"></asp:Image>
</a>
<asp:HyperLink class='button gray_button' ID="HyperLink3" runat="server" href='<%$ Resources:GResource,languagecode %>' Text='<%$ Resources:GResource,language %>'></asp:HyperLink>
<asp:Panel ID="Panel1" runat="server">
<div class='button blue_button' id='account'>
<asp:Label ID="Label1" runat="server" Text="陈奕迅"></asp:Label>

<ul id='account_links'>
<li>
<asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/PersonalDetails.aspx" Text='<%$ Resources:GResource,PersonalDetails %>'>我的资料</asp:HyperLink>

</li>
    <li>
<asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/viewshoporder.aspx">我的订单(222)</asp:HyperLink>
</li>
<li> 
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/messages.aspx" Visible="false">消息(555)</asp:HyperLink>
</li>
    <li>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%$ Resources:GResource,myshopcart %>'></asp:LinkButton>

        
        <%--<asp:HyperLink ID="HyperLink14" runat="server"><asp:Localize ID="Localize14" runat="server" Text='<%$ Resources:GResource,myshopcart %>'></asp:Localize></asp:HyperLink>--%>
    </li>
<li>
<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/safecenter.aspx" meta:resourcekey="LinkButton5Resource1">安全中心</asp:HyperLink>
</li>
<li>
<asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/helpcenter.aspx" meta:resourcekey="LinkButton6Resource1" Visible="False">帮助中心</asp:HyperLink>
</li>
<li>
<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/login.aspx" meta:resourcekey="LinkButton1Resource1">退出</asp:HyperLink>
</li>
</ul>
</div>

<ul class='desktop_navigation'>
<li class="bluedark1_button" style=" margin:0; vertical-align:middle; height:36px;" >
<asp:HyperLink Font-Bold="True" Font-Size="13px" ForeColor="White" ID="HyperLink7" runat="server" NavigateUrl="~/benefitplan.aspx" Text='<%$ Resources:GResource,scrumdev %>'>敏捷开发</asp:HyperLink>
</li>
<li class="bluedark1_button" style=" margin:0; vertical-align:middle; height:36px;">
<asp:HyperLink Font-Bold="True" Font-Size="13px" ForeColor="White" ID="HyperLink8" runat="server"  NavigateUrl="~/mapinti.aspx"    Text='<%$ Resources:GResource,mapinti %>'>地图嵌入</asp:HyperLink>
</li>
<li class="bluedark1_button" style=" margin:0; vertical-align:middle; height:36px;" >
<asp:HyperLink Font-Bold="True" Font-Size="13px" ForeColor="White" ID="HyperLink9" runat="server" NavigateUrl="~/mpwechat.aspx" Text='<%$ Resources:GResource,mpwechat %>'>微信公众号</asp:HyperLink>
</li>
    <li class="bluedark1_button" style=' margin:0; vertical-align:middle; height:36px'>
<asp:HyperLink Font-Bold="True" Font-Size="13px" ForeColor="White" ID="HyperLink10" runat="server" NavigateUrl="~/healthshop.aspx" Text='<%$ Resources:GResource,onlineshop %>'>在线商城</asp:HyperLink>
</li>
</ul>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" Visible="false" style="padding-top:8px;">

<ul class='desktop_navigation' >
<li style="color:#6c98cf; font-size:18px;">
400-888-8888
</li>
<li>
<A href="javascript:sendemail('lyx_zhl@hotmail.com');" style="padding-top:0; font-size:14px">lyx_zhl@hotmail.com</A>
</li>


</ul>
</asp:Panel>
</div>
</nav>