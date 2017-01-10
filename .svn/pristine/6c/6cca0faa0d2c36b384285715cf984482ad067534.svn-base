<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testcustomergetstart.aspx.cs" Inherits="testcustomergetstart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
        <br />
        注册接口<br />
        <br />
        <br />
        姓名
        <asp:TextBox ID="TextBox1" runat="server" Text="张三"></asp:TextBox>
        <br />
        身份证号<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 0px" Text="420117123412194567"></asp:TextBox>
        <br />
        手机号<asp:TextBox ID="TextBox6" runat="server" Text="12309876894"></asp:TextBox>
        <br />
        性别<asp:TextBox ID="TextBox7" runat="server" Text="男"></asp:TextBox>
        <br />
        婚姻<asp:TextBox ID="TextBox8" runat="server" Text="未婚"></asp:TextBox>
        <br />
        出生日期<asp:TextBox ID="TextBox9" runat="server" Text="2015-1-1"></asp:TextBox>
        <br />
        密码<asp:TextBox ID="TextBox10" runat="server" Text="a123456"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        样例<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; customergetstart.aspx<br />
        <br />
        输入<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string nickname 姓名<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string gender&nbsp; 性别<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string mobile&nbsp; 手机号<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string password 密码<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string iDcard&nbsp; 身份证号<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string DOB&nbsp;&nbsp;&nbsp; 生日<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string hunyin&nbsp;&nbsp; 婚姻<br />
        <p class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: justify; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span style="font-family: 宋体;">
            <br class="Apple-interchange-newline" />
            输出<span lang="EN-US">:<o:p></o:p></span></span></p>
        <p class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: justify; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span lang="EN-US" style="font-family: 宋体; background: white;">string code;</span><span lang="EN-US" style="font-family: 宋体;"><o:p></o:p></span></p>
        <p class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: justify; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span lang="EN-US" style="font-family: 宋体; background: white;">string message;</span><span lang="EN-US" style="font-family: 宋体;"><o:p></o:p></span></p>
        <p class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: justify; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span lang="EN-US" style="font-family: 宋体;"><o:p>&nbsp;</o:p></span></p>
        <p class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: justify; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span style="font-family: 宋体;">成功：<span lang="EN-US">code=1</span>返回登录信息<span lang="EN-US"><o:p></o:p></span></span></p>
        <p class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: justify; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span style="font-family: 宋体;">失败<span lang="EN-US">: code</span>为下列值</span></p>
        <p class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: justify; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            &nbsp;</p>
    </div>
    </form>
</body>
</html>
