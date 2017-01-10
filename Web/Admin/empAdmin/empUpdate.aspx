<%@ Page Language="C#" AutoEventWireup="true" CodeFile="empUpdate.aspx.cs" Theme="Default" Inherits="Admin_empAdmin_empUpdate" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>跟新员工</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5">
                    更新员工信息</td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="1" class="Tab" style="width: 100%">
            <tr class="tr" style="height: 40px">
                <td align="left" colspan="6">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" style="width: 100px">
                                <asp:UpdatePanel id="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <contenttemplate>
&nbsp;<asp:Button id="Button1" onclick="Button1_Click" runat="server" Text="更　新" CssClass="button"></asp:Button> 
</contenttemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td colspan="2">
                                <input id="Button2" class="button" onclick="location='empInfo.aspx'" type="button" value="返　回" /></td>
                            <td colspan="1">
                                <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <contenttemplate>
<asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary> <asp:Label id="Label2" runat="server"></asp:Label> 
</contenttemplate>
                                    <triggers>
<asp:AsyncPostBackTrigger ControlID="Button1"></asp:AsyncPostBackTrigger>
</triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td colspan="1" style="width: 1px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            <tr class="tr">
                <td colspan="1" style="width: 100px; height: 15px">
                    用户名：</td>
                <td align="left" colspan="5" rowspan="1" style="width: 686px">
                    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Red"></asp:Label></td>
            </tr>
            
            <tr class="tr">
                <td style="width: 100px; height: 25px;">
                    新密码：</td>
                <td style="width: 686px; height: 25px;" colspan="5" align="left">
                    <asp:TextBox  ID="TextBox2" runat="server" CssClass="Input" TextMode="Password" Width="150px"></asp:TextBox></td>
            </tr>
            <tr class="tr">
                <td style="width: 100px">
                    角 色：</td>
                <td align="left"  colspan="5" rowspan="1">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="4" Width="60%">
                    </asp:RadioButtonList></td>
            </tr>
        </table>
        </div>
        <asp:RequiredFieldValidator
                ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="密码不能为空" Display="None" Width="73px"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadioButtonList1"
                    Display="None" ErrorMessage="请选择角色"></asp:RequiredFieldValidator>
    </form>
</body>
</html>
