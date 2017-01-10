<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderseticket.aspx.cs" Inherits="Admin_ordersAdmin_orderseticket" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>健康咨询管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5" style="height: 30px">
                    商城订单信息
                    </td>
            </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                       
                        <td align="center" style="width: 150px; height: 24px;" >
                            <asp:TextBox ID="TextBox1" runat="server" placeholder="关键字" Width="145"> </asp:TextBox>
                            </td>
                        <td style="width: 150px; height: 24px;" >
                            <asp:Button ID="Button1" runat="server" Text="搜索"  OnClick="Button1_Click"   />
                            </td>
                  
                        <td style="width: 150px; height: 24px;" >
                            <asp:Button ID="ButtonEE" runat="server" Text="导出excel" 
                                onclick="ButtonEE_Click"  />
                            </td>
                    </tr>
                    
                </table>

    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
    <td align="center" style="height: 100%; width: 100%;">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="25" AllowSorting="True"
            AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView1_RowDataBound" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="orderID" HeaderText="订单号" />
                <asp:BoundField DataField="customerName" HeaderText="客户姓名" />
                <asp:BoundField DataField="productName" HeaderText="商品名" />
                <asp:BoundField DataField="productID" HeaderText="商品ID" />
                <asp:BoundField DataField="itemnum" HeaderText="数量" />
                <asp:BoundField DataField="eticket" HeaderText="电子码" />
                <asp:BoundField DataField="time" HeaderText="时间" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:db_ConnectionString %>" 
            SelectCommand="SELECT [orderID], [customerName], [productName], [productID], [itemnum], [eticket], [time], [id] FROM [tab_eticket]">
        </asp:SqlDataSource>
    </td>
    
    </tr>
    </table>
    </div>
    </form>
</body>
</html>

