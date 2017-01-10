<%@ Page Language="C#" AutoEventWireup="true" CodeFile="powerUpdate.aspx.cs" Theme="Default" Inherits="Admin_powerAdmin_powerUpdate" %>

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
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5">
                    权限修改</td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="1" class="Tab" style="width: 100%">
            <tr class="tr" style="height: 40px">
                <td align="left" colspan="5">
                    <table border="0" cellpadding="0" cellspacing="0">
                       <tr>
                            <td align="center" style="width: 100px">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                            Text="更　新" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td colspan="2">
                                <input id="Button2" class="button" onclick="location='powerInfo.aspx'" type="button" value="返　回" />
                                </td>
                            <td colspan="1">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="Button1" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td colspan="1">
                                <asp:RequiredFieldValidator
                ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox1" ErrorMessage="权限名不能为空"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox4"
            ErrorMessage="权限描述不能为空"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="tr">
                <td style="width: 100px; height: 78px;">
                    权限名：</td>
                <td style="width: 100px; height: 78px;">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="Input"></asp:TextBox></td>
                <td style="width: 100px; height: 78px;">
                    上一级权限：</td>
                <td align="left" colspan="2" style="width: 350px; height: 78px;">
                    &nbsp;
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="Input">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Button1" />
                        </Triggers>
                    </asp:UpdatePanel>
                    &nbsp;
                </td>
            </tr>
            <tr class="tr">
                <td style="width: 100px; height: 62px" valign="top">
                    描 述：</td>
                <td align="left" colspan="4" style="height: 62px">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="Input" Height="76px" TextMode="MultiLine"
                        Width="90%"></asp:TextBox></td>
            </tr>
            <tr class="tr">
                <td rowspan="2" style="width: 100px" valign="top">
                    所在页面：<br />
                    （主要功能所在的页面）</td>
                <td align="left" colspan="4" style="height: 40px" valign="top">
                    &nbsp; &nbsp;
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="Input" Width="90%" OnTextChanged="TextBox2_TextChanged" ReadOnly="True"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr class="tr">
                <td align="left" colspan="4" style="height: 62px" valign="top">
                    <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged1">
                    </asp:TreeView>
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
