<%@ Page Language="C#" AutoEventWireup="true" CodeFile="empAdd.aspx.cs" Theme="Default" Inherits="Admin_empAdmin_empAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5">
                    员工添加</td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="1" class="Tab" style="width: 100%">
            <tr class="tr" style="height: 40px">
                <td align="left" colspan="6">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" style="width: 100px">
                                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                            Text="添　加" /></td>
                            <td colspan="2">
                                <input id="Button2" class="button" onclick="location='empInfo.aspx'" type="button" value="返　回" /></td>
                            <td colspan="1" style="width: 1px">
                            </td>
                        </tr>
                    </table>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
            </tr>
            <tr class="tr">
                <td colspan="1" style="width: 100px; height: 15px;">
                    用户名：</td>
                <td colspan="1" style="width: 52px; height: 15px;">
                    <asp:TextBox AutoComplete="off" ID="TextBox1" runat="server" CssClass="Input" Width="150px"></asp:TextBox></td>
                <td id="sta"  align="left" colspan="4" rowspan="2">
                </td>
            </tr>
            <tr class="tr">
                <td style="width: 100px">
                    密 码：</td>
                <td style="width: 150px">
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
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
            ErrorMessage="用户名不能为空" Display="None" Width="85px"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="密码不能为空" Display="None" Width="73px"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadioButtonList1"
                    Display="None" ErrorMessage="请选择角色"></asp:RequiredFieldValidator>
    </form>
</body>
</html>
