<%@ Page Language="C#" AutoEventWireup="true" CodeFile="powerInfo.aspx.cs" Theme="Default" Inherits="Admin_powerAdmin_powerInfo" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>页面管理</title>
    <script type="text/javascript" src="../../JS/xmlHttpRequest.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        </div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5">
                    权限信息</td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" class="Tab" style="width: 100%">
            <tr class="tr" style="height: 40px">
                <td align="left" colspan="5" style="height: 40px">
                    <table border="0" cellpadding="0" cellspacing="0">
                       <tr>
                            <td align="center" style="width: 100px">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                            Text="搜　索" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td colspan="2">
                                &nbsp;<input id="Button2" class="button" onclick="ClearAll()" type="button" value="清　空" /></td>
                            <td colspan="1">
                            </td>
                        </tr>
                        
                    </table>
                </td>
            </tr>
           
            <tr class="tr">
                <td style="width: 100px">
                    权限名：</td>
                <td style="width: 100px">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="Input"></asp:TextBox></td>
                <td style="width: 100px">
                    上一级类别：</td>
                <td align="left" colspan="2" style="width: 814px">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="Input">
                    </asp:DropDownList></td>
            
            </tr>
            <tr class="tr">
            </tr>
            <tr class="title">
                <td align="center" colspan="5">
                    权限信息列表</td>
            </tr>
            <tr class="tr">
                <td colspan="2">
                    <input id="Button3" onclick="location='powerAdd.aspx'" class="button" type="button" value="新 建" />
                    
                </td>
                <td colspan="3" align="left">
                    <asp:Button ID="Button4" runat="server" CssClass="button" OnClick="Button4_Click"
                        Text="导出EXCEL" /></td>
            </tr>
            <tr class="tr">
                <td align="left" colspan="5">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                           <asp:GridView ID="GridView1" CssClass="GridViewStyle" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="powerID" DataSourceID="powDataSource" Width="100%" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowDeleted="GridView1_RowDeleted" > 
                            <FooterStyle CssClass="GridViewFooterStyle" /> 
                            <RowStyle CssClass="GridViewRowStyle" />    
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" /> 
                            <PagerStyle CssClass="GridViewPagerStyle" /> 
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" /> 
                             <HeaderStyle CssClass="GridViewHeaderStyle" /> 
                                <Columns>
                                    <asp:HyperLinkField DataNavigateUrlFields="powerID" DataNavigateUrlFormatString="powerUpdate.aspx?pid={0}"
                                        DataTextField="powerName" HeaderText="权限名" />
                                    <asp:BoundField DataField="powerFaName" HeaderText="上一级权限" SortExpression="powerFaName" />
                                    <asp:BoundField DataField="powerContent" HeaderText="权限描述" SortExpression="powerContent" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="delete" ImageUrl="~/Images/houtai/pic22.gif" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
</asp:GridView>
                            <asp:SqlDataSource ID="powDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:db_ConnectionString %>"
                                SelectCommand="SELECT [powerFaName], [powerID], [powerName], [powerContent] FROM [v_power]">
                            </asp:SqlDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr class="tr">
            </tr>
            <tr class="tr">
            </tr>
            <tr class="tr">
            </tr>
        </table>
    </form>
</body>
</html>
