<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testproductClass.aspx.cs" Inherits="testproductClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        商城接口<br />
        <br />
        <br />
        全部商品<asp:TextBox ID="TextBox1" runat="server" Text="0"></asp:TextBox>
        &nbsp;&nbsp; 传0&nbsp; 取全部&nbsp;&nbsp;&nbsp; 传id 取&nbsp; 个别&nbsp;&nbsp; （71）<br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" style="height: 21px" />
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        productClass.aspx<br />
        <br />
        <br />
        <br />
        输入<br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp; int&nbsp; <br />
        <br />
        <br />
        <br />
        输出<br />
    
    </div>
    </form>
</body>
</html>
