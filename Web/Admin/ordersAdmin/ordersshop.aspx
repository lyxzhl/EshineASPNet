<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ordersshop.aspx.cs" Inherits="Admin_ordersAdmin_ordersshop" %>


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
                             <asp:CheckBox ID="CheckBox1" runat="server" Text="快递实物订单" AutoPostBack="True" OnCheckedChanged="Button1_Click" />
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
            AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView1_RowDataBound"
            DataKeyNames="orderID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:TemplateField  ItemStyle-Wrap="False" HeaderText="订单号">
                    <ItemTemplate>
                        <a href='ordersshopupdate.aspx?ordersshopid=<%#Eval("orderID") %>'><%#Eval("orderID") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                
         <asp:BoundField DataField="orderDate" HeaderText="下单日期" HeaderStyle-Wrap="false" 
                    SortExpression="orderDate"  ItemStyle-Wrap="False" >
                </asp:BoundField>
                <asp:BoundField DataField="customerName" HeaderText="姓名" HeaderStyle-Wrap="false"
                    SortExpression="customerName"  ItemStyle-Wrap="False" >
                </asp:BoundField>
                <asp:BoundField DataField="customerCompany" HeaderText="公司" HeaderStyle-Wrap="false"
                    SortExpression="customerCompany"  ItemStyle-Wrap="False" >
                </asp:BoundField>
         <asp:BoundField DataField="examBill" HeaderText="金额" ItemStyle-Wrap="False" HeaderStyle-Wrap="false"
                    SortExpression="examBill" >
                </asp:BoundField>
         <asp:BoundField DataField="ReportContent" HeaderText="订单内容" ItemStyle-Wrap="False" HeaderStyle-Wrap="false"
                    SortExpression="ReportContent" >
                </asp:BoundField>
<asp:BoundField DataField="orderStatus" HeaderText="订单状态" ItemStyle-Wrap="False"  HeaderStyle-Wrap="false"
                    SortExpression="orderStatus" >
                </asp:BoundField>
<asp:BoundField DataField="personAddress" HeaderText="邮寄地址" ItemStyle-Wrap="False"  HeaderStyle-Wrap="false"
                    SortExpression="personAddress" >
                </asp:BoundField>
<asp:BoundField DataField="Msg" HeaderText="备注" ItemStyle-Wrap="False"  HeaderStyle-Wrap="false"
                    SortExpression="Msg" >
                </asp:BoundField>
                
<asp:BoundField DataField="orderID" HeaderText="订单号" ItemStyle-Wrap="False"  Visible="false"
                    SortExpression="orderID" InsertVisible="False" ReadOnly="True" >
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:db_ConnectionString %>" 
            DeleteCommand="DELETE FROM [tab_orders] WHERE [orderID] = @orderID" 
            InsertCommand="INSERT INTO [tab_orders] ([orderDate], [customerName], [examBill], [ReportContent], [orderStatus], [personAddress], [Msg]) VALUES (@orderDate, @customerName, @examBill, @ReportContent, @orderStatus, @personAddress, @Msg)" 
            SelectCommand="SELECT [orderDate], [customerName],(select a.customerCompany from tab_customers a where a.customerID=tab_orders.customerID) customerCompany, [examBill], [ReportContent], [orderStatus], [personAddress], [Msg], [orderID] FROM [tab_orders] WHERE ([ReportType] = @ReportType) ORDER BY [orderID] DESC" 
            
            UpdateCommand="UPDATE [tab_orders] SET [orderDate] = @orderDate, [customerName] = @customerName, [examBill] = @examBill, [ReportContent] = @ReportContent, [orderStatus] = @orderStatus, [personAddress] = @personAddress, [Msg] = @Msg WHERE [orderID] = @orderID" 
            ProviderName="System.Data.SqlClient">
            <DeleteParameters>
                <asp:Parameter Name="orderID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="orderDate" Type="DateTime" />
                <asp:Parameter Name="customerName" Type="String" />
                <asp:Parameter Name="examBill" Type="Double" />
                <asp:Parameter Name="ReportContent" Type="String" />
                <asp:Parameter Name="orderStatus" Type="String" />
                <asp:Parameter Name="personAddress" Type="String" />
                <asp:Parameter Name="Msg" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="商城" Name="ReportType" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="orderDate" Type="DateTime" />
                <asp:Parameter Name="customerName" Type="String" />
                <asp:Parameter Name="examBill" Type="Double" />
                <asp:Parameter Name="ReportContent" Type="String" />
                <asp:Parameter Name="orderStatus" Type="String" />
                <asp:Parameter Name="personAddress" Type="String" />
                <asp:Parameter Name="Msg" Type="String" />
                <asp:Parameter Name="orderID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </td>
    
    </tr>
    </table>
    </div>
    </form>
</body>
</html>

