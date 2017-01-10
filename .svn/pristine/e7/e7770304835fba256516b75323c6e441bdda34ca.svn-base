<%@ Page Language="C#" AutoEventWireup="true" CodeFile="roleUpdate.aspx.cs" Theme="Default" Inherits="Admin_roleAdmin_roleUpdate" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>角色更新</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5">
                    角色更新</td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="1" class="Tab" style="width: 100%">
            <tr class="tr" style="height: 40px">
                <td align="left" colspan="5">
                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
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
                                <input id="Button2" class="button" onclick="location='roleInfo.aspx'" type="button" value="返　回" />
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
                ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="角色描述不能为空"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
            ErrorMessage="角色名不能为空"></asp:RequiredFieldValidator>
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
                <td style="width: 100px; height: 62px" valign="top">
                    描 述：</td>
                <td align="left" colspan="4" style="height: 62px">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="Input" Height="76px" TextMode="MultiLine"
                        Width="90%"></asp:TextBox></td>
            </tr>
            <tr class="tr">
                <td style="width: 100px; height: 62px" valign="top">
                    所拥有的权利：</td>
                <td align="left" colspan="4" style="height: 62px">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0"  class="Tab" style="width:90%;">
                                <tr>
                                <td><table border="0" cellpadding="0" cellspacing="0"  class="Tab" style="width:100%;">
                                <tr class="title">
                                    <td align="left" style="width: 10px">
                                        <img src="../../Images/houtai/zxyh.png" />
                                    </td>
                                    <td align="left">
                                        <%# Eval("powerName") %>
                                    </td>
                                </tr>
                                </table>
                                </td>
                                </tr>
                                <tr >
                                    <td align="left" colspan="2">
                                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSource='<%# Eval("pc") %>'
                                            DataTextField="powerName" DataValueField="powerID" RepeatColumns="3">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 90%">
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
