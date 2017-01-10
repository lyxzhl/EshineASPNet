<%@ Page Language="C#" AutoEventWireup="true" CodeFile="roleInfo.aspx.cs" Theme="Default" Inherits="Admin_roleAdmin_roleInfo" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>角色管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        </div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5">
                    角色信息</td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" class="Tab" style="width: 100%">
            <tr class="tr" style="height: 40px">
                <td align="left" colspan="5">
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
                    角色名：</td>
                <td align="left" colspan="4">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="Input"></asp:TextBox></td>
            
            </tr>
            <tr class="tr">
            </tr>
            <tr class="title">
                <td align="center" colspan="5">
                    角色列表</td>
            </tr>
            <tr class="tr">
                <td colspan="2">
                    <input id="Button3" onclick="location='roleAdd.as
                    
                </td>
                <td colspan="3" align="left">
                    <asp:Button ID="Button4" runat="server" CssClass="button" OnClick="Button4_Click"
                        Text="导出EXCEL" /></td>
            </tr>
            <tr class="tr">
                <td align="left" colspan="5">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" CssClass="GridViewStyle" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="roleID" DataSourceID="roleDataSource" Width="100%" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" > 
    <FooterStyle CssClass="GridViewFooterStyle" /> 
    <RowStyle CssClass="GridViewRowStyle" />    
    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" /> 
    <PagerStyle CssClass="GridViewPagerStyle" /> 
    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" /> 
    <HeaderStyle CssClass="GridViewHeaderStyle" /> 
                                <Columns>
                                    <asp:HyperLinkField DataTextField="roleName" HeaderText="角色名" DataNavigateUrlFields="roleID" DataNavigateUrlFormatString="roleUpdate.aspx?rid={0}" />
                                    <asp:BoundField DataField="roleContent" HeaderText="角色描述" SortExpression="roleContent" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="delete" ImageUrl="~/Images/houtai/trash.gif" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
</asp:GridView>
                            <asp:SqlDataSource ID="roleDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:db_ConnectionString %>"
                                SelectCommand="SELECT [roleID], [roleName], [roleContent] FROM [tab_roles]"></asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Button1" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            </table>
    </form>
</body>
</html>
