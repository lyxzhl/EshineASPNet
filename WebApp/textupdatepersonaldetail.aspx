<%@ Page Language="C#" AutoEventWireup="true" CodeFile="textupdatepersonaldetail.aspx.cs" Inherits="textupdatepersonaldetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        更改个人资料<br />
        <br />
        <br />
        <br />
    
        自己的id<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        姓名<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        邮箱<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        手机号<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        性别<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        婚姻<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        出生日期<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <br />
        身份证号<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <br />
        <span style="color: rgb(0, 0, 0); font-family: Simsun; font-size: medium; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">所在地省份</span><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        <br />
        <span style="color: rgb(0, 0, 0); font-family: Simsun; font-size: medium; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">所在地城市</span><asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
    
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp; updatepersonaldetail.aspx<br />
        <p class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: justify; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span style="font-family: 宋体;">输入：</span><span lang="EN-US"><o:p></o:p></span></p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span lang="EN-US" style="font-size: 10pt; color: black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int<span>&nbsp;&nbsp;<span class="Apple-converted-space">&nbsp;</span></span>id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span lang="EN-US" style="font-size: 10pt; font-family: 宋体; color: black">&nbsp;<span class="Apple-converted-space">&nbsp;</span></span><span style="font-size: 10pt; font-family: 宋体; color: black;">自己的<span lang="EN-US">id<o:p></o:p></span></span></p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span lang="EN-US" style="font-size: 10pt; font-family: 宋体; color: black;"><span>&nbsp;&nbsp;&nbsp;<span class="Apple-converted-space">&nbsp;</span>&nbsp;<span class="Apple-converted-space">&nbsp;</span></span>int type<span>&nbsp;&nbsp;&nbsp;<span class="Apple-converted-space">&nbsp;</span></span>//1</span><span style="font-size: 10pt; font-family: 宋体; color: black;">更新基本信息</span></p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; string&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 姓名</p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 邮箱</p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;customerMobile&nbsp; 手机号</p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;string&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; customerGender&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 性别</p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; customerMarriageStatus&nbsp;&nbsp;&nbsp; 婚姻</p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DOB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 生日</p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IDcard&nbsp;&nbsp; &nbsp;身份证号</p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; customerCompanyProvince&nbsp; <span style="color: rgb(0, 0, 0); font-family: Simsun; font-size: medium; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">所在地省份</span></p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; customerCompanyCity&nbsp;&nbsp;&nbsp; <span style="color: rgb(0, 0, 0); font-family: Simsun; font-size: medium; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">所在地城市</span></p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            &nbsp;</p>
        <p class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: justify; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span style="font-family: 宋体;">输出：</span><span lang="EN-US"><o:p></o:p></span></p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span lang="EN-US" style="font-size: 10pt; font-family: 'Courier New'; color: black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;String code 1</span><span style="font-size: 10pt; font-family: 宋体; color: black;">为正确，其它值为错误，错误内容见</span><span lang="EN-US" style="font-size: 10pt; font-family: 'Courier New'; color: black;">message</span><span style="font-size: 10pt; font-family: 宋体; color: black;">节点</span><span lang="EN-US" style="font-size: 10pt; font-family: 'Courier New'; color: black;"><o:p></o:p></span></p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span lang="EN-US" style="font-size: 10pt; font-family: 'Courier New'; color: black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;String message<o:p></o:p></span></p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt 21pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-indent: 20pt;">
            <span lang="EN-US" style="font-size: 10pt; font-family: 宋体; color: black;"><o:p>&nbsp;</o:p></span></p>
        <p class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: justify; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <b><span lang="EN-US" style="font-size: 18pt; color: rgb(0, 112, 192);"><o:p>&nbsp;</o:p></span></b></p>
        <p class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: justify; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            <span style="font-size: 11pt; font-family: 宋体;">成功</span></p>
        <p align="left" class="MsoNormal" style="margin: 0cm 0cm 0.0001pt; text-align: left; font-size: 10.5pt; font-family: Calibri, sans-serif; color: rgb(0, 0, 0); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
            &nbsp;</p>
    
    </div>
    </form>
</body>
</html>
