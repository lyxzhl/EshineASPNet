<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="benefitinfo.aspx.cs" Inherits="Admin_discriptionAdmin_benefitinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <meta charset="utf-8" />
    <link rel="stylesheet" href="../../kindeditor/themes/default/default.css" />
	<link rel="stylesheet" href="../../kindeditor/plugins/code/prettify.css" />
	<script charset="utf-8" src="../../kindeditor/kindeditor.js"></script>
	<script charset="utf-8" src="../../kindeditor/lang/zh_CN.js"></script>
	<script charset="utf-8" src="../../kindeditor/plugins/code/prettify.js"></script>
	<script>
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content1', {
	            cssPath: '../../kindeditor/plugins/code/prettify.css',
	            uploadJson: '../../kindeditor/asp.net/upload_json.ashx',
	            fileManagerJson: '../../kindeditor/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5">
                    体检福利计划</td>
            </tr>
        </table>
        <br>
        <table border="0" cellpadding="0" cellspacing="0" class="adminContent" style="width: 100%">
                    <tr>
                        <td align="right"  style="width: 80px; height: 24px;">
                            <asp:Label ID="Label1" runat="server" Text="计划名称：" Width="120px"></asp:Label></td>
                        <td align="left" style="width: 130px; height: 24px;">
                            <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="300"></asp:TextBox>
                            <asp:TextBox ID="TextBox3" runat="server" Visible="False" Width="80" placeholder="公司代码"></asp:TextBox>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                                Width="304px" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList>
                            
                            </td>
                        <td width="150" >&nbsp;&nbsp;
                            <asp:Button ID="Button3" runat="server" Text="删除" onclick="Button3_Click" />&nbsp;&nbsp;
                            <asp:Button ID="Button2" runat="server" Text="新增" onclick="Button2_Click" />
                            </td>
                            <td  >
                            </td>
                    </tr>
                    <tr>
                        <td align="right" >
                        <asp:Label ID="Label2" runat="server" Text="编辑链接：" Width="120px"></asp:Label></td>
                        <td align="left" style="width: 130px; height: 24px;">
                            <asp:TextBox ID="TextBox2" runat="server" Width="300"></asp:TextBox>
                            </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="Button4" runat="server" Text="上传" OnClick="Button4_Click" /></td>
                    </tr>
                    <tr><td></td><td>
                        <asp:Label ID="lb_info" runat="server" ></asp:Label></td></tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" class="adminContent" style="width: 100%">
                <tr>
                <td align="left">
                    <textarea id="content1" cols="100" rows="8" style="width:700px;height:400px;visibility:hidden;" runat="server"></textarea>
        <br />
        <asp:Button ID="Button1" runat="server" Text="提交内容" onclick="Button1_Click" /> (提交快捷键: Ctrl + Enter)
                
                </td>
                </tr>
                </table>
                    

    </div>
    </form>
</body>
</html>

