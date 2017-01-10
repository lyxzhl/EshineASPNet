<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chooseImg.aspx.cs" Inherits="Admin_chooseImg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" class="file optional" />
    <asp:Button ID="Button1" runat="server" Text="上传照片" onclick="Button1_Click" />
    <asp:Label ID="lb_info" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <asp:GridView ID="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="id">
            <Columns>
                <asp:CommandField DeleteText="D" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        
    </form>
</body>
</html>
