<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_add.aspx.cs" Theme="Default" Inherits="Admin_product_product_add" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>产品添加</title>
    <script type="text/javascript" src="../../JS/xmlHttpRequest.js"></script>
   <link rel="stylesheet" href="../../kindeditor/themes/default/default.css" />
	<link rel="stylesheet" href="../../kindeditor/plugins/code/prettify.css" />
	<script charset="utf-8" src="../../kindeditor/kindeditor.js"></script>
	<script charset="utf-8" src="../../kindeditor/lang/zh_CN.js"></script>
	<script charset="utf-8" src="../../kindeditor/plugins/code/prettify.js"></script>
	
    <script type="text/javascript">
        function showPic() {
            var filesrc = document.getElementById("File1").value;
            var Imgsrc = document.getElementById("Image1");
            Imgsrc.src = filesrc;
        }
    </script>
</head>
<body >
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0" >
            <tr>
                <td class="title" colspan="5">
                    产品添加</td>
            </tr>
            
        </table>
        <table class="Tab" border="0" cellpadding="0" cellspacing="1" style="width: 100%">
            <tr class="tr" style="height:40px">
                <td align="left" colspan="5" style="height: 40px">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 100px; height: 24px;" align="center">
                                <asp:Button ID="Button1" runat="server" CssClass="button" Text="添　加" OnClick="Button1_Click" />&nbsp;</td>
                            <td colspan="2" style="height: 24px; width: 66px;">
                                &nbsp;<input id="Button2" class="button" onclick="location='product_admin.aspx'" type="button" value="返　回" /></td>
                            <td colspan="1" style="height: 24px">
                            </td>
                        </tr>
                    </table>
                    
                </td>
            </tr>
        <tr class="tr">
                <td style="width: 100px; height: 24px;">
                    产品名：</td>
                <td style="width: 100px; height: 24px;">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="Input"></asp:TextBox></td>
            <td style="width: 100px; height: 24px;">
                    品类：</td>
                <td style="width: 100px; height: 24px;">
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="Input"></asp:TextBox></td>

                <td style="width: 100px; height: 24px; display:none">
                    产品类别：</td>
                <td colspan="2" align="left" style="width: 341px; height: 24px;display:none">
                    <asp:DropDownList  ID="DropDownList1" runat="server" CssClass="Input">
                    </asp:DropDownList></td>
            </tr>
            <tr class="tr">
                <td  style="width: 100px; height: 24px;">
                    单 价：</td>
                <td style="width: 100px; height: 24px;">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="Input">0</asp:TextBox></td>
                <td style="width: 100px; height: 24px;">
                    数 量：</td>
                <td colspan="2" align="left" style="height: 24px; width: 341px;">
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="Input">0</asp:TextBox></td>
            </tr>
            <tr class="tr">
                <td style="width: 100px; height: 40px;">
                    描 述：</td>
                <td colspan="4" align="left" style="height: 40px">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="Input" TextMode="MultiLine" Width="90%"></asp:TextBox></td>
            </tr>
            <tr class="tr">
                <td style="width: 100px">
                    图 片：</td>
                <td colspan="4" align="left">
                    <input class="Input" onchange="showpic()" style="width:90%" id="File1" runat="server" type="file" /></td>
            </tr>
            <tr class="tr">
                <td style="width: 100px; height: 16px;">
                </td>
                <td align="left" colspan="4" style="height: 16px">
                    <asp:Image ID="Image1" runat="server" /></td>
            </tr>
             <tr>
                <td style="width: 100px">
                </td>
                <td colspan="3">
                    <textarea id="content1" cols="100" rows="8" style="width:700px;height:400px;visibility:hidden;" runat="server"></textarea>
                    
                    </td>
            </tr>
        </table>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="产品名不能为空"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                        ErrorMessage="单价不能为空"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                        ErrorMessage="数量不能为空"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4"
                        ErrorMessage="产品描述不能为空"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox2"
                        ErrorMessage="单价不符合要求" MaximumValue="999999" MinimumValue="0" Type="Double"></asp:RangeValidator><asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TextBox3"
                        ErrorMessage="数量不符合要求" MaximumValue="999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="File1"
            ErrorMessage="图图片不能为空"></asp:RequiredFieldValidator>&nbsp;
        
        
    </form>
</body>
</html>
