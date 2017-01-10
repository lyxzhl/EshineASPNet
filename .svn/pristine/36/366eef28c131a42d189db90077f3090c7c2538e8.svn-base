<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_admin.aspx.cs" Theme="Default" Inherits="Admin_product_product_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <table border="0" cellpadding="0" cellspacing="0" class="title" style="width: 100%">
                    <tr>
                        <td class="title" colspan="5" style="height: 16px">产品信息</td>
                    </tr>
                </table>
                <br />
                <table border="0" cellpadding="0" cellspacing="0" class="adminContent" style="width: 100%">
                    <tr>
                        <td align="left" style="width: 100px" width="132">产品名：</td>
                        <td style="width: 22px" width="144">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBox" Width="175px"></asp:TextBox></td>
                        <td align="center" style="width: 100px; display: none" width="266">产品类别：</td>
                        <td style="width: 100px; display: none" width="243">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="TextBox">
                            </asp:DropDownList></td>
                        <td style="width: 100px" width="243">&nbsp;<asp:Button ID="Button2" runat="server" CssClass="button" Text="搜　索" OnClick="Button2_Click" /></td>
                        <td style="width: 100px" width="243">
                            <asp:Button ID="Button1" runat="server" CssClass="button" Text="清　空" /></td>
                    </tr>
                </table>
            </div>

        </div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 100px">
                    <asp:Button ID="Button3" runat="server" CssClass="button" Text="添加" OnClick="Button3_Click" />
                    &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="Button4" runat="server" CssClass="button" Text="删除" OnClick="Button4_Click" /></td>
            </tr>
            <tr>
                <td style="height: 122px">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <HeaderTemplate>
                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td
                                        style="width: 40px"></td>
                                    <td
                                        style="font-weight: bold; font-size: 16px; width: 100px">产品名</td>
                                    
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td
                                    style="width: 40px">
                                    <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox></td>
                                <td
                                    style="width: 200px">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="con"><%# Eval("productName") %></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("px") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="LinkButton2" CommandName="down" CommandArgument='<%# Eval("productID") %>' runat="server">DOWN</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" CommandName="up" CommandArgument='<%# Eval("productID") %>' runat="server">UP</asp:LinkButton></td>
                                <%--<td style="width: 100px"><%# Eval("type")%></td>
                                <td style="width: 100px"><%# Eval("productUnitPrice")%>元</td>
                                <td style="width: 100px"><%# Eval("productDate")%></td>--%>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Visible="false" Text='<%# Eval("productID") %>'></asp:Label></td>
                            </tr>
                        </ItemTemplate>
                        <%--<HeaderTemplate>
                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                <tbody>
                                    <tr>
                                        <td
                                            style="width: 40px"></td>
                                        <td
                                            style="font-weight: bold; font-size: 16px; width: 100px">产品名</td>
                                        <td
                                            style="font-weight: bold; font-size: 16px; width: 100px">产品类别</td>
                                        <td
                                            style="font-weight: bold; font-size: 16px; width: 100px">产品单价</td>
                                        <td
                                            style="font-weight: bold; font-size: 16px; width: 100px">产品日期</td>
                                    </tr>
                                </tbody>
                            </table>
                        </HeaderTemplate>--%>
                        <FooterTemplate></table></FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td style="height: 10px" align="left">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnOne" runat="server" OnClick="lnkbtnOne_Click">首页</asp:LinkButton>&nbsp; 
        <asp:LinkButton
            ID="lnkbtnUp" runat="server" OnClick="lnkbtnUp_Click">上页</asp:LinkButton>&nbsp; 
        <asp:LinkButton ID="lnkbtnNext"
            runat="server" OnClick="lnkbtnBack_Click">下页</asp:LinkButton>&nbsp;
        <asp:LinkButton ID="lnkbtnBack" runat="server" OnClick="LinkButton4_Click">尾页</asp:LinkButton>
                    第<asp:Label ID="labPage" runat="server" Text="1"></asp:Label>页&nbsp;
        共<asp:Label ID="labBackPage" runat="server" Text="1"></asp:Label>页&nbsp;
        共<asp:Label ID="CountProLab" runat="server" Text="18"></asp:Label>件商品&nbsp;
        每页<asp:Label ID="PageProLab" runat="server" Text="10" Width="18px"></asp:Label>件商品&nbsp;
        转到:<asp:TextBox ID="TextBox2" runat="server" CssClass="input_sr" Height="15px" Width="28px"></asp:TextBox>
                    页
        &nbsp;
        <asp:Button ID="Button5" runat="server" CssClass="input_bot" Text="跳转" OnClick="Button1_Click" /></td>
            </tr>
        </table>

    </form>
</body>
</html>
