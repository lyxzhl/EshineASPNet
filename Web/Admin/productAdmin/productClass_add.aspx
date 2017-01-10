<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productClass_add.aspx.cs" Theme="Default" Inherits="Admin_product_productClass_add" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5">
                    产品类别添加</td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="1" class="Tab" style="width: 100%">
            <tr class="tr" style="height: 40px">
                <td align="left" colspan="5" style="height: 40px">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" style="width: 100px">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                            Text="添加" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td colspan="2">
                                &nbsp;<input id="Button2" class="button"  onclick="location='productClass_admin.aspx'" type="button" value="返回" /></td>
                            <td colspan="1">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="tr">
                <td style="width: 100px">
                    产品类别名：</td>
                <td style="width: 100px">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="Input"></asp:TextBox></td>
                <td style="width: 100px">
                    上一级类别：</td>
                <td align="left" colspan="2">
                   <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr class="tr">
                <td style="width: 100px; height: 62px" valign="top">
                    描 述：</td>
                <td align="left" colspan="4" style="height: 62px">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="Input" Height="76px" TextMode="MultiLine"
                        Width="90%"></asp:TextBox></td>
            </tr>
        </table>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
            ErrorMessage="产品类别名不能为空"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="产品类别描述不能为空"></asp:RequiredFieldValidator></div>
    </form>
</body>
</html>
