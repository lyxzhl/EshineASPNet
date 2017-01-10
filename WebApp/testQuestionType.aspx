<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testQuestionType.aspx.cs" Inherits="texttijiandaoh" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        体检问卷类别<br />
        <br />
        类别<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <a href="tijiandaod.aspx">QuestionType</a><br />
        <br />
        <br />
        <br />
        输入&nbsp;Tijian<br />
        <br />
        <br />
        <br />
        <br />
        输出<br />
        <br />
    </form>
</body>
</html>
