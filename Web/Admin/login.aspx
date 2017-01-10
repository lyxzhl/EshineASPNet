<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EshineAspNet后台管理</title>
    <LINK href="../CSS/adminlogin.css" rel="stylesheet" type="text/css">     
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <TABLE width="100%" border="0" cellspacing="0" cellpadding="0">
  <TBODY>
  <TR>
    <TD height="99" bgcolor="#0099d8">
      <DIV class="logo_time">
      <DIV class="logo l"><IMG src="../Images/Medi-plus_02.png" height="99px" /></DIV>
      <DIV class="time r"><SPAN>咨询热线 <B style="font-family: Arial, Helvetica, sans-serif; font-size: 14px;">400-888-8888</B></SPAN><SPAN>EshineASPNet</SPAN></DIV></DIV></TD></TR>
  <TR>
    <TD height="90">&nbsp;</TD></TR>
  <TR>
    <TD height="400">
      <DIV class="login_password">
      <DIV class="login_img l"><IMG 
      src="../Images/houtai/login_img.jpg" /></DIV>
      <DIV class="login r">
      <H3 class="img"><IMG src="../Images/houtai/logintext.jpg" /></H3>
      <SPAN>工　号：</SPAN>
      <asp:TextBox ID="TextBox1" runat="server" class="w330"></asp:TextBox>
      <BR>
      <SPAN>密　码：</SPAN>
      <asp:TextBox ID="TextBox2" runat="server"  class="w330" TextMode="Password"></asp:TextBox>   
      <BR>
      <SPAN>验证码：</SPAN> 
      <asp:TextBox ID="TextBox3" runat="server" class="w330"></asp:TextBox>
      <div style=" padding-left: 51px;">
          <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Admin/login/CheckCode.aspx" onclick="ImageButton1_Click" /></div>                  
          <asp:Button  class="w84" id="butLogin" style="border: currentColor;" 
              runat="server" Text="登录" onclick="butLogin_Click" />
      			 
      <DIV style="color: rgb(170, 0, 0); line-height: 24px; padding-top: 10px; padding-left: 40px; font-size: 14px;"></DIV></DIV></DIV></TD></TR>
  <TR>
    <TD height="68">&nbsp;</TD></TR>
  <TR>
    <TD height="86" style="border-top-color: rgb(247, 247, 247); border-top-width: 3px; border-top-style: solid;">
      <DIV class="footer">
      <P class="l">Eshine版权所有 © 2017</P>
      <P class="r">技术支持：明之育</P></DIV></TD></TR></TBODY></TABLE>
    </div>
    </form>
</body>
</html>
