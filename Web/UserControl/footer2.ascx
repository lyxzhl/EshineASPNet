<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer2.ascx.cs" Inherits="footer2" %>
<footer>
<div class='footer_wrapper'>
<DIV>
<SCRIPT>
    function sendemail(email) {
        window.location.href = "mailto:" + escape(email);
    }
		</SCRIPT>

<DIV><IMG alt="sidebar contact us icon" src="Images/icon_sidebar_contact_us.png" /> 
<P><asp:Label ID="Label1" runat="server" Text="联系我们" meta:resourcekey="Label1Resource1" Font-Bold="True"></asp:Label></P></DIV>
<DIV>
<P>
    <asp:Label ID="Label2" runat="server" Text="热线电话"  meta:resourcekey="Label2Resource1"></asp:Label>：<STRONG>+86&nbsp;88888888 </STRONG></P>
<P>
    <asp:Label ID="Label3" runat="server" Text="服务时间" meta:resourcekey="Label3Resource1"></asp:Label>：9:00-18:00<br />
    <asp:Label ID="Label5" runat="server" Text="周一到周五（节假日除外）" meta:resourcekey="Label5Resource1"></asp:Label> </P>
<DIV class=fields>
<P class=formlabel>
    <asp:Label ID="Label4" runat="server" Text="邮箱地址" meta:resourcekey="Label4Resource1"></asp:Label>:&nbsp;
        <A href="javascript:sendemail('service@eshinelee.com');">service@eshinelee.com</A></P></DIV></DIV></DIV>


<ul id='footer_list'>
<li>
<a href='../index.aspx'><asp:Localize ID="Localize1" runat="server" Text="关于" meta:resourcekey="Localize1Resource1"></asp:Localize></a>
</li>
<li>
<a href='../TermsOfService.aspx'><asp:Localize ID="Localize2" runat="server" Text="服务条款" meta:resourcekey="Localize2Resource1"></asp:Localize></a>
</li>
<li>
<a href='../CopyrightPolicy.aspx'><asp:Localize ID="Localize3" runat="server" Text="版权政策" meta:resourcekey="Localize3Resource1"></asp:Localize></a>
</li>
<li>
<a href='../PrivacyPolicy.aspx'><asp:Localize ID="Localize4" runat="server" Text="隐私权保护政策" meta:resourcekey="Localize4Resource1"></asp:Localize></a>
</li>

</ul>
</div>
</footer>