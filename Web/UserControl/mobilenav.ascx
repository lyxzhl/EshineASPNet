<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mobilenav.ascx.cs" Inherits="UserControl_mobilenav" %>
<div data-behavior='MobileNavigation'>
<nav class='mobile_show' id='mobile'>
<div class='close_nav'>x</div>
<asp:Panel ID="Panel1" runat="server">
<ul class='mobile_navigation'>
<li style=" margin:0; vertical-align:middle; height:36px;" >
<asp:HyperLink Font-Bold="True" Font-Size="13px" ForeColor="White" ID="HyperLink7" runat="server" NavigateUrl="~/benefitplan.aspx" Text='<%$ Resources:GResource,scrumdev %>'>敏捷开发</asp:HyperLink>
</li>
<li style=" margin:0; vertical-align:middle; height:36px;">
<asp:HyperLink Font-Bold="True" Font-Size="13px" ForeColor="White" ID="HyperLink8" runat="server" NavigateUrl="~/reserveexam.aspx" Text='<%$ Resources:GResource,mapinti %>'>地图嵌入</asp:HyperLink>
</li>
<li style=" margin:0; vertical-align:middle; height:36px;">
<asp:HyperLink Font-Bold="True" Font-Size="13px" ForeColor="White" ID="HyperLink11" runat="server" NavigateUrl="~/healthconsult.aspx" Text='<%$ Resources:GResource,mpwechat %>'>微信公众号</asp:HyperLink>
</li>
<li>
<asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/healthshop.aspx" Text='<%$ Resources:GResource,onlineshop %>'>在线商城</asp:HyperLink>
</li>
<li>
<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/login.aspx" meta:resourcekey="LinkButton1Resource1">退出</asp:HyperLink>
</li>
</ul>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server">
<ul class='mobile_navigation' >
<li style="color:#6c98cf; font-size:18px;">
400-888-8888
</li>
<li>
<A href="javascript:sendemail('lyx_zhl@hotmail.com');" style="padding-top:0; font-size:14px">lyx_zhl@hotmail.com</A>
</li>


</ul>
</asp:Panel>
</nav>
<header>
<a href='/home'>
<img alt='' class='mobile_logo mobile_show' src='Images/logo2.png'>
</a>
<div id='hamburger'></div>
</header>

</div>



<div class="box_os_back" style="z-index:999999; display:none">
	<div class="os_x"></div>
    <div class="osqq">
    <p><em>(工作日：9:00-18:00)</em></p>
    	<p><strong>在线QQ</strong></p>
        <a target="_blank" href='<%=onlineqq1 %>'><p id="ico_onlineqq" class="qq"></p></a>
        <p><strong>客服电话</strong><span>400-888-8888</span></p>
    </div>
    <div class="acbox">
    	
        <a class="ico_gt" href="javascript:" target="_self" title=""></a>
    </div>
</div>