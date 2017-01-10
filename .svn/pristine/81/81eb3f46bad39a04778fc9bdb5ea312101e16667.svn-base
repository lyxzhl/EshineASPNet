<%@ Page Language="C#" AutoEventWireup="true" CodeFile="companyDeliveryaddress.aspx.cs" Inherits="Admin_companyAdmin_companyDeliveryaddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>上海市</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" placeholder="详细地址.." Width="300"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
            </td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/companyAdmin/companyInfo.aspx">返回公司列表</asp:HyperLink>
            </td>
        </tr>
    </table>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="id">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="" SortExpression="id"  ItemStyle-Wrap="False" />
                <asp:BoundField DataField="company" HeaderText="公司" SortExpression="company"  ItemStyle-Wrap="False" />
                <asp:BoundField DataField="provence" HeaderText="地区" SortExpression="provence"  ItemStyle-Wrap="False" />
                <asp:BoundField DataField="address" HeaderText="地址" SortExpression="address"  ItemStyle-Wrap="False" />
                <asp:CommandField ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
