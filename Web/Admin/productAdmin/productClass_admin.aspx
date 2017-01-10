<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productClass_admin.aspx.cs"  Theme="Default" Inherits="admin_product_productClass_admin" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>类别管理</title>
    <link href="../../css/shopTop.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button5_onclick() {
window.open("showProductClass.aspx","产品类别","400px","500px");
}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5" style="height: 30px">
                    产品类别信息</td>
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
           
                <td style="width: 100px; height: 25px;">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="Input"></asp:TextBox></td>
                <td style="width: 100px; height: 25px;">
                    上一级类别：</td>
                <td align="left" colspan="2" style="width: 853px; height: 25px;">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="Input">
                    </asp:DropDownList></td>
            
            </tr>
            <tr class="title">
                <td align="center" colspan="5">
                    产品类别列表</td>
            </tr>
            <tr class="tr">
                <td colspan="2">
                    <input id="Button3" onclick="location='productClass_add.aspx'" class="button" type="button" value="新 建" />
                    
                </td>
                <td colspan="3" align="left">
                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="选择.xls文件" Width="200px" />
                    <asp:Button ID="Button5" runat="server"  CssClass="button"
                        Text="导入EXCEL" onclick="Button5_Click1" />
                    <asp:Button ID="Button4" runat="server" CssClass="button" OnClick="Button4_Click"
                        Text="导出EXCEL" /></td>
            </tr>
            <tr class="tr">
                <td align="left" colspan="5">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" CssClass="GridViewStyle" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="productClassID" DataSourceID="proClassDataSource" Width="100%" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" > 
    <FooterStyle CssClass="GridViewFooterStyle" /> 
    <RowStyle CssClass="GridViewRowStyle" />    
    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" /> 
    <PagerStyle CssClass="GridViewPagerStyle" /> 
    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" /> 
    <HeaderStyle CssClass="GridViewHeaderStyle" /> 
                                <Columns>
                                    <asp:HyperLinkField
                                        DataTextField="productClassName" HeaderText="产品类别名" />
                                    <asp:BoundField DataField="faName" HeaderText="上一级类别" SortExpression="faName" />
                                    <asp:BoundField DataField="productClassContent" HeaderText="描述" SortExpression="productClassContent" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton alt="点击删除" ID="ImageButton1" runat="server" CommandName="delete" ImageUrl="~/Images/houtai/pic22.gif" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
</asp:GridView>
                            <asp:SqlDataSource ID="proClassDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:db_ConnectionString %>"
                                SelectCommand="SELECT [productClassID], [productClassName], [faName], [productClassContent] FROM [v_productClass]">
                            </asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Button1" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            </table>
    </form>
      <script src="../../JS/xmlHttpRequest.js"></script>
</body>
</html>
