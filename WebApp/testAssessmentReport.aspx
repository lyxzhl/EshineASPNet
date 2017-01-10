<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testAssessmentReport.aspx.cs" Inherits="testAssessmentReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        问卷api<br />
        <br />
        <span style="font-size:11.0pt;font-family:宋体;
mso-bidi-font-family:宋体;color:black;mso-ansi-language:EN-US;mso-fareast-language:
ZH-CN;mso-bidi-language:AR-SA">用户<span lang="EN-US">ID</span><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        用户类型</span><asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
        <br />
        <span style="font-size:11.0pt;font-family:宋体;
mso-bidi-font-family:宋体;color:black;mso-ansi-language:EN-US;mso-fareast-language:
ZH-CN;mso-bidi-language:AR-SA">用户编号</span><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <span style="font-size:11.0pt;font-family:宋体;
mso-bidi-font-family:宋体;color:black;mso-ansi-language:EN-US;mso-fareast-language:
ZH-CN;mso-bidi-language:AR-SA">用户性别</span><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <span style="font-size:11.0pt;font-family:宋体;
mso-bidi-font-family:宋体;color:black;mso-ansi-language:EN-US;mso-fareast-language:
ZH-CN;mso-bidi-language:AR-SA">用户生日</span><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        婚否<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        <br />
        <span style="font-size:11.0pt;font-family:宋体;
mso-bidi-font-family:宋体;color:black;mso-ansi-language:EN-US;mso-fareast-language:
ZH-CN;mso-bidi-language:AR-SA">简称</span><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <span style="font-size:11.0pt;font-family:宋体;
mso-bidi-font-family:宋体;color:black;mso-ansi-language:EN-US;mso-fareast-language:
ZH-CN;mso-bidi-language:AR-SA">评估问题及答案分值集合</span><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
