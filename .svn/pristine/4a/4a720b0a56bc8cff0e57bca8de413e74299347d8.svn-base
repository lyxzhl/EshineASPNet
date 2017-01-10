<%@ Page Language="C#" AutoEventWireup="true" CodeFile="empInfo.aspx.cs" Theme="Default" Inherits="Admin_empAdmin_empInfo" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8"/>
    <title>员工信息</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager></div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5">
                    员工信息</td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" class="Tab" style="width: 100%">
            <tr class="tr" style="height: 40px">
                <td align="left" colspan="7">
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
                    员工名：</td>
                <td style="width: 100px">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="Input"></asp:TextBox></td>
                <td style="width: 100px">
                    职 位：</td>
                <td align="left" colspan="4">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList></td>
            
            </tr>
            <tr class="tr">
            </tr>
            <tr class="title">
              <td align="center" colspan="10">
                    员工列表</td>
            </tr>
            <tr class="tr">
                <td colspan="4">
                    <input id="Button3" onclick="location='empAdd.aspx'" class="button" type="button" value="新 建" />
                    
                </td>
                <td colspan="3" align="left">
                    <asp:Button ID="Button4" runat="server" CssClass="button" OnClick="Button4_Click"
                        Text="导出EXCEL" /></td>
            </tr>
            <tr class="tr">
                <td align="left" colspan="7">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                      <ContentTemplate>
                            <asp:GridView ID="GridView1" CssClass="GridViewStyle" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="empID" DataSourceID="empDataSource" Width="100%" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" > 
    <FooterStyle CssClass="GridViewFooterStyle" /> 
    <RowStyle CssClass="GridViewRowStyle" />    
    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" /> 
    <PagerStyle CssClass="GridViewPagerStyle" /> 
    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" /> 
    <HeaderStyle CssClass="GridViewHeaderStyle" /> 
                                <Columns>
                                    <asp:HyperLinkField DataNavigateUrlFields="empID" DataNavigateUrlFormatString="empUpdate.aspx?eid={0}"
                                        DataTextField="empName" HeaderText="员工名" />
                                    <asp:BoundField DataField="roleName" HeaderText="角色名" SortExpression="roleName" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="delete" ImageUrl="~/Images/houtai/pic22.gif" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
</asp:GridView>
                            <asp:SqlDataSource ID="empDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:db_ConnectionString %>"
                                SelectCommand="SELECT tab_roles.roleName, tab_emps.empID, tab_emps.empName FROM tab_emps INNER JOIN tab_roles ON tab_emps.roleID = tab_roles.roleID">
                            </asp:SqlDataSource>
                            &nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
