<%@ Control Language="C#" AutoEventWireup="true" CodeFile="commonnav.ascx.cs" Inherits="UserControl_commonnav" %>

 <DIV class=nav>
 <ul><li> <a href="Default.aspx">&nbsp;<asp:Localize ID="Localize1" runat="server" Text='<%$ Resources:GResource,Default %>'></asp:Localize></a></li>
<li > <a href="benefitplan.aspx">&nbsp;<asp:Localize ID="Localize2" runat="server" Text='<%$ Resources:GResource,scrumdev %>'></asp:Localize></a></li>
<li > <a href="mapinti.aspx">&nbsp;<asp:Localize ID="Localize3" runat="server" Text='<%$ Resources:GResource,mapinti %>'></asp:Localize></a></li>
<li > <a href="mpwechat.aspx">&nbsp;<asp:Localize ID="Localize5" runat="server" Text='<%$ Resources:GResource,mpwechat %>'></asp:Localize></a></li>
<li > <a href="healthshop.aspx">&nbsp;<asp:Localize ID="Localize6" runat="server" Text='<%$ Resources:GResource,onlineshop %>'></asp:Localize></a></li>
      </ul>
 </DIV>