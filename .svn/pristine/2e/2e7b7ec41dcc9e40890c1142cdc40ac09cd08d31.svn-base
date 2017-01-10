<%@ Page Language="C#" AutoEventWireup="true" CodeFile="companyInfo.aspx.cs" Inherits="Admin_companyAdmin_companyInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5">
                    公司信息</td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="0" cellspacing="0" class="adminContent" style="width: 100%">
                    <tr>
                        <td align="center" style="width: 50px; height: 24px;">
                            <asp:Button ID="Button1" CssClass="TextBox" runat="server" Text="新 增" 
                                onclick="Button1_Click" />
                            </td>
                        <td style="width: 100px; height: 24px; text-align:right;">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBox" Width="175px"></asp:TextBox></td>
                        <td style="width: 100px; height: 24px; text-align:left;">
                            &nbsp;<asp:Button ID="Button2" runat="server" CssClass="button" Text="搜　索" OnClick="Button2_Click" /></td>
                        <td  >
                            <asp:Button ID="ButtonEE" runat="server" Text="导出excel" 
                                onclick="ButtonEE_Click"  />
                            </td>
                    </tr>
                    <tr>
                        <td >
                            </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" class="adminContent" style="width: 100%">
                <tr>
                <td align="center">
                    &nbsp;<asp:SqlDataSource 
                        ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_ConnectionString %>"
                        
                        SelectCommand="SELECT [CompanyName], [CompanyShortName], [CompanyAbbreviation], [Companycode], [currentperiod], [CompanyTel], [CompanyProvince], [CompanyCity], [CompanyZone], [CompanyAddress], [id] FROM [tab_company]" 
                        DeleteCommand="DELETE FROM [tab_company] WHERE [id] = @original_id" 
                        InsertCommand="INSERT INTO [tab_company] ([CompanyName], [CompanyShortName], [CompanyAbbreviation], [Companycode], [currentperiod], [CompanyTel], [CompanyProvince], [CompanyCity], [CompanyZone], [CompanyAddress]) VALUES (@CompanyName, @CompanyShortName, @CompanyAbbreviation, @Companycode, @currentperiod, @CompanyTel, @CompanyProvince, @CompanyCity, @CompanyZone, @CompanyAddress)" 
                        OldValuesParameterFormatString="original_{0}" 
                        
                        
                        
                        UpdateCommand="UPDATE [tab_company] SET [CompanyName] = @CompanyName, [CompanyShortName] = @CompanyShortName, [CompanyAbbreviation] = @CompanyAbbreviation, [Companycode] = @Companycode, [currentperiod] = @currentperiod, [CompanyTel] = @CompanyTel, [CompanyProvince] = @CompanyProvince, [CompanyCity] = @CompanyCity, [CompanyZone] = @CompanyZone, [CompanyAddress] = @CompanyAddress WHERE [id] = @original_id">
                        <DeleteParameters>
                            <asp:Parameter Name="original_id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="CompanyName" Type="String" />
                            <asp:Parameter Name="CompanyShortName" Type="String" />
                            <asp:Parameter Name="CompanyAbbreviation" Type="String" />
                            <asp:Parameter Name="Companycode" Type="String" />
                            <asp:Parameter Name="currentperiod" Type="String" />
                            <asp:Parameter Name="CompanyTel" Type="String" />
                            <asp:Parameter Name="CompanyProvince" Type="String" />
                            <asp:Parameter Name="CompanyCity" Type="String" />
                            <asp:Parameter Name="CompanyZone" Type="String" />
                            <asp:Parameter Name="CompanyAddress" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="CompanyName" Type="String" />
                            <asp:Parameter Name="CompanyShortName" Type="String" />
                            <asp:Parameter Name="CompanyAbbreviation" Type="String" />
                            <asp:Parameter Name="Companycode" Type="String" />
                            <asp:Parameter Name="currentperiod" Type="String" />
                            <asp:Parameter Name="CompanyTel" Type="String" />
                            <asp:Parameter Name="CompanyProvince" Type="String" />
                            <asp:Parameter Name="CompanyCity" Type="String" />
                            <asp:Parameter Name="CompanyZone" Type="String" />
                            <asp:Parameter Name="CompanyAddress" Type="String" />
                            <asp:Parameter Name="original_id" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                
                </td>
                </tr>
                </table>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"  PageSize="20" 
            AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="100%" 
            AllowSorting="True" DataKeyNames="id" >
                        <Columns>
                        <asp:HyperLinkField DataTextField="CompanyName" HeaderText="公司名称"  SortExpression="CompanyName" 
                            DataNavigateUrlFields="id" DataNavigateUrlFormatString="companyUpdate.aspx?Cid={0}"  ItemStyle-Wrap="False" />
                            <asp:BoundField DataField="CompanyShortName" HeaderText="CompanyShortName" Visible="false"
                                SortExpression="CompanyShortName"  ItemStyle-Wrap="False" />
                            <asp:BoundField DataField="CompanyAbbreviation" HeaderText="CompanyAbbreviation"  Visible="false"
                                SortExpression="CompanyAbbreviation"  ItemStyle-Wrap="False" />
                            <asp:BoundField DataField="Companycode" HeaderText="公司代码" 
                                SortExpression="Companycode"  ItemStyle-Wrap="False" />
                            <asp:BoundField DataField="currentperiod" HeaderText="体检周期" 
                                SortExpression="currentperiod"  ItemStyle-Wrap="False" />
                            <asp:BoundField DataField="CompanyTel" HeaderText="电话" 
                                SortExpression="CompanyTel" />
                            <asp:BoundField DataField="CompanyProvince" HeaderText="省" 
                                SortExpression="CompanyProvince" />
                            <asp:BoundField DataField="CompanyCity" HeaderText="市" 
                                SortExpression="CompanyCity" />
                                <asp:BoundField DataField="CompanyZone" HeaderText="区" 
                                SortExpression="CompanyZone" />
                            <asp:BoundField DataField="CompanyAddress" HeaderText="地址" 
                                SortExpression="CompanyAddress" />
                    
                    
                        </Columns>
                        <HeaderStyle Wrap="False"  />
                    </asp:GridView>

    </div>
    
    
    </form>
</body>
</html>
