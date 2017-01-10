<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testtijiajiashu.aspx.cs" Inherits="testtijiajiashu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        添加家属<br />
        <br />
        <br />
        id<asp:TextBox ID="TextBox1" runat="server" Text="100000376"></asp:TextBox>
        <br />
        <br />
        姓名<asp:TextBox ID="TextBox2" runat="server" Text="张三"></asp:TextBox>
        <br />
        <br />
        身份证号<asp:TextBox ID="TextBox3" runat="server" Text="230103197404240326"></asp:TextBox>
        <br />
        <br />
        联系电话<asp:TextBox ID="TextBox4" runat="server" Text="13681586733"></asp:TextBox>
        <br />
        <br />
        关系<asp:TextBox ID="TextBox9" runat="server" Text="子女"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 配偶/子女/父母/其他<br />
        <br />
        出生日期<br />
        <asp:TextBox ID="TextBox5" runat="server" Text="2008-8-8"></asp:TextBox>
&nbsp;&nbsp;&nbsp; 格式&nbsp;&nbsp; 2008-8-8&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        性别<asp:TextBox ID="TextBox6" runat="server" Text="女"></asp:TextBox>
&nbsp;&nbsp; 男/女<br />
        <br />
        婚姻<asp:TextBox ID="TextBox7" runat="server" Text="已婚"></asp:TextBox>
&nbsp;&nbsp; 已婚/未婚<br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <a href="tijiajiashu.aspx">tijiajiashu.aspx</a><br />
        <br />
        <br />
        输入<br />
        <br />
        <br />
        <br />
        string&nbsp; relativeCustomer&nbsp; 家属id<br />
        string&nbsp;&nbsp; relativeName&nbsp;&nbsp; 家属名字<br />
        string&nbsp;&nbsp; relativeIDcard&nbsp; 身份证号<br />
        string&nbsp;&nbsp; relativeMobile&nbsp; 手机号&nbsp;&nbsp; 11位<br />
        datetime&nbsp;&nbsp; relativeDOB&nbsp;&nbsp;&nbsp; 出生日期&nbsp;&nbsp; 
        <br />
        string&nbsp;&nbsp; relativeGender&nbsp;&nbsp;&nbsp; 性别<br />
        string&nbsp;&nbsp; MarriageStatus&nbsp;&nbsp;&nbsp; 婚姻<br />
        string&nbsp;&nbsp; Relationship&nbsp;&nbsp;&nbsp;&nbsp; 跟登录者的关系<br />
        <br />
        <br />
        <br />
        输出<br />
        <br />
    </form>
</body>
</html>
