<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="product_update.aspx.cs" Theme="Default" Inherits="admin_product_product_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>产品添加</title>
     <meta charset="utf-8" />
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
<body>
    <form id="form1" runat="server">
    <div>
        <table class="title" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5" style="height: 16px">
                    <asp:Label ID="Label1" runat="server" Text="商品更新"></asp:Label> </td>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="English" OnClick="Button5_Click" /></td>
            </tr>
        </table>
        &nbsp;
        <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
        <asp:Button ID="Button2" runat="server" CssClass="button" Text="保存" OnClick="Button2_Click" />
        &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Button1" runat="server" CssClass="button" Text="返回" OnClick="Button1_Click" /><br />
        <table border="0" class="adminContent" cellpadding="0" cellspacing="0" width="768">
            <tr>
                <td width="132" align="left" style="width: 100px">
                    产品名：</td>
                <td width="144" style="width: 22px">
                    <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem>选择已有商品名</asp:ListItem>
                    </asp:DropDownList>
              <asp:TextBox ID="TextBox1" runat="server" Width="175px" CssClass="TextBox"></asp:TextBox></td>

                 <td width="132" align="left" style="width: 100px">
                    品类：</td>
                <td width="144" style="width: 22px">
              <asp:TextBox ID="TextBox5" runat="server" Width="175px" CssClass="TextBox"></asp:TextBox></td>

                <td width="266" align="left" style="width: 100px;display:none">
                    产品类别：</td>
                <td style="width: 92px;display:none">
                    <asp:DropDownList ID="DropDownList1"  CssClass="Input" runat="server">
              </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="left" style="width: 100px">
                    特惠价：</td>
                <td style="width: 22px">
                    <asp:TextBox ID="TextBox2" runat="server" Width="175px" CssClass="TextBox"></asp:TextBox></td>
                <td align="left" style="width: 100px">
                    库存：</td>
                <td style="width: 92px">
                    <asp:TextBox ID="TextBox3" runat="server" Width="175px" CssClass="TextBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left" style="width: 100px">
                    市场价：</td>
                <td>
                    <asp:TextBox ID="TextBox6" Width="175px" CssClass="TextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left" valign="top" style="width: 100px">
                    描述：</td>
                <td colspan="3">
                    <asp:TextBox ID="TextBox4" runat="server" Height="88px" TextMode="MultiLine" Width="491px" CssClass="TextBox"></asp:TextBox></td>
            </tr>
            <tr style="display:none">
                <td align="left" style="width: 100px; height: 24px;">
                    图片：</td>
                <td colspan="3" style="height: 24px; display:none">
                    <input id="File1" onchange="showPic()" runat="server" style="width: 493px" type="file" class="TextBox" /></td>
            </tr>
              <tr>
                <td align="left" style="width: 100px; height: 24px;">
                    发布：</td>
                <td  style="height: 24px;">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="发布" Checked="True" /></td>
                  <td align="left" style="width: 100px; height: 24px;">
                    形式：</td>
                <td  style="height: 24px;">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="prodform" Checked="True" Text="快递实物" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="prodform" Text="电子码" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    商品图：
                
                    <asp:Image ID="Image6" runat="server" Width="180" Height="180" />
                    <asp:TextBox ID="TextBox26" runat="server" ></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td colspan="4">
                    门面图：
                
                    <asp:Image ID="Image1" runat="server" Width="180" Height="180" />
                    <asp:TextBox ID="TextBox21" runat="server" ></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td  colspan="4">
                    <table>
                        <tr>
                            <td>
                                 <asp:Image ID="Image2" runat="server" Width="180" Height="180" ImageUrl="~/Images/houtai/点我换图.jpg" /><br />
                                <asp:TextBox ID="TextBox22" runat="server" ></asp:TextBox>
                            </td>
                             <td>
                                 <asp:Image ID="Image3" runat="server" Width="180" Height="180" ImageUrl="~/Images/houtai/点我换图.jpg" /><br />
                                <asp:TextBox ID="TextBox23" runat="server" ></asp:TextBox>
                            </td>
                             <td>
                                 <asp:Image ID="Image4" runat="server" Width="180" Height="180" ImageUrl="~/Images/houtai/点我换图.jpg" /><br />
                                <asp:TextBox ID="TextBox24" runat="server" ></asp:TextBox>
                            </td>
                             <td>
                                 <asp:Image ID="Image5" runat="server" Width="180" Height="180" ImageUrl="~/Images/houtai/点我换图.jpg" /><br />
                                <asp:TextBox ID="TextBox25" runat="server" ></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
        
          
            </tr>
   
    
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" >
<table border="0" cellpadding="0" cellspacing="0" class="adminContent" style="width: 100%">
                    <tr>
                        <td align="center" style="width: 100px; height: 24px; text-align:right;">
                            <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="选择.xls文件" Width="200px" /></td>
                        <td style="width: 22px; height: 24px; text-align:left;">
                            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="上传Excel文件" ToolTip="" /></td>
                        <td align="center" style="width: 50px; height: 24px;">
                            <asp:Button ID="Button4" runat="server" Text="删除所有门店" OnClick="Button4_Click" />
                            </td>
                        <td  >
                            <asp:Button ID="ButtonEE" runat="server" Text="导出excel" 
                                onclick="ButtonEE_Click"  />
                            </td>
                    </tr>
                    <tr>
                        <td >
                            </td>
                    </tr>
                </table>

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  AllowPaging="True"  PageSize="10" 
          AllowSorting="True"   DataKeyNames="id" DataSourceID="SqlDataSource1"  PagerSettings-Mode="NumericFirstLast" PagerSettings-PageButtonCount="50">
            <Columns>
                <asp:BoundField DataField="supplier" HeaderText="供应商" 
                    SortExpression="supplier"  />
                <asp:HyperLinkField DataTextField="branch" HeaderText="分店"  SortExpression="branch" 
                            DataNavigateUrlFields="id" DataNavigateUrlFormatString="supplierUpdate.aspx?Cid={0}"  ItemStyle-Wrap="False" />
          
                <asp:BoundField DataField="province" HeaderText="省" 
                    SortExpression="province" />
                <asp:BoundField DataField="city" HeaderText="市" 
                    SortExpression="city" />
                <asp:BoundField DataField="zone" HeaderText="区" SortExpression="zone" />
                <asp:BoundField DataField="address" HeaderText="地址" 
                    SortExpression="address" />
                <asp:BoundField DataField="phone" HeaderText="电话" SortExpression="phone" />
                <asp:BoundField DataField="note" HeaderText="备注" SortExpression="note" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id" />
                
            </Columns>
        </asp:GridView>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:db_ConnectionString %>" 
            DeleteCommand="DELETE FROM [tab_shopsuppliers] WHERE [id] = @original_id" 
            OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT * FROM [tab_shopsuppliers] where 1=2" 
            UpdateCommand="UPDATE [tab_shopsuppliers] SET [supplier] = @supplier, [branch] = @branch, [hospid] = @hospid, [province] = @province, [city] = @city, [zone] = @zone, [address] = @address, [type] = @type, [lat] = @lat, [lng] = @lng, [phone] = @phone, [note] = @note WHERE [id] = @original_id" 
            ProviderName="System.Data.SqlClient">
            <DeleteParameters>
                <asp:Parameter Name="original_id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="supplier" Type="String" />
                <asp:Parameter Name="branch" Type="String" />
                <asp:Parameter Name="hospid" Type="String" />
                <asp:Parameter Name="province" Type="String" />
                <asp:Parameter Name="city" Type="String" />
                <asp:Parameter Name="zone" Type="String" />
                <asp:Parameter Name="address" Type="String" />
                <asp:Parameter Name="type" Type="String" />
                <asp:Parameter Name="lat" Type="String" />
                <asp:Parameter Name="lng" Type="String" />
                <asp:Parameter Name="phone" Type="String" />
                <asp:Parameter Name="note" Type="String" />
                <asp:Parameter Name="original_id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

                    </asp:Panel>

                    


                </td>
            </tr>




            <tr>
                <td colspan="4">
                    产品介绍:
                    <textarea id="content1" cols="100" rows="8" style="width:700px;height:400px;visibility:hidden;" runat="server"></textarea>
                    
                    </td>
            </tr>
            <tr>
                <td colspan="4">
                    使用说明:
                    <textarea id="content2" cols="100" rows="8" style="width:700px;height:400px;visibility:hidden;" runat="server"></textarea>
                    </td>
            </tr>
            <tr>
                <td colspan="4">
                    基本参数:
                    <textarea id="content3" cols="100" rows="8" style="width:700px;height:400px;visibility:hidden;" runat="server"></textarea>
                    </td>
            </tr>
            <tr>
                <td colspan="4">
                    品牌介绍:
                    <textarea id="content4" cols="100" rows="8" style="width:700px;height:400px;visibility:hidden;" runat="server"></textarea>
                    </td>
            </tr>
      </table>
    </div>

        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
            ErrorMessage="单价不能为空"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
            ErrorMessage="数量不能为空"></asp:RequiredFieldValidator>&nbsp;
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox2"
            ErrorMessage="单价不符合要求" MaximumValue="9999" MinimumValue="0" Type="Double"></asp:RangeValidator>
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TextBox3"
            ErrorMessage="数量不符合要求" MaximumValue="9999" MinimumValue="0" Type="Integer"></asp:RangeValidator>--%>
        
    </form>

    <script>

        KindEditor.ready(function (K) {
            var editor = K.editor({
                allowFileManager: true
            });
            K('#<%=Image1.ClientID %>').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        clickFn: function (url, title, width, height, border, align) {
                            K('#<%=Image1.ClientID %>').attr('src', url);
                            K('#<%=TextBox21.ClientID %>').val(url);
                            editor.hideDialog();
                        }
                    });
                });
            });
            K('#<%=Image2.ClientID %>').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        clickFn: function (url, title, width, height, border, align) {
                            K('#<%=Image2.ClientID %>').attr('src', url);
                            K('#<%=TextBox22.ClientID %>').val(url);
                            editor.hideDialog();
                        }
                    });
                });
            });
            K('#<%=Image3.ClientID %>').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        clickFn: function (url, title, width, height, border, align) {
                            K('#<%=Image3.ClientID %>').attr('src', url);
                            K('#<%=TextBox23.ClientID %>').val(url);
                            editor.hideDialog();
                        }
                    });
                });
            });
            K('#<%=Image4.ClientID %>').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        clickFn: function (url, title, width, height, border, align) {
                            K('#<%=Image4.ClientID %>').attr('src', url);
                            K('#<%=TextBox24.ClientID %>').val(url);
                            editor.hideDialog();
                        }
                    });
                });
            });
            K('#<%=Image5.ClientID %>').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        clickFn: function (url, title, width, height, border, align) {
                            K('#<%=Image5.ClientID %>').attr('src', url);
                            K('#<%=TextBox25.ClientID %>').val(url);
                            editor.hideDialog();
                        }
                    });
                });
            });
            K('#<%=Image6.ClientID %>').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        clickFn: function (url, title, width, height, border, align) {
                            K('#<%=Image6.ClientID %>').attr('src', url);
                            K('#<%=TextBox26.ClientID %>').val(url);
                            editor.hideDialog();
                        }
                    });
                });
            });





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
            var editor2 = K.create('#content2', {
                cssPath: '../../kindeditor/plugins/code/prettify.css',
                uploadJson: '../../kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '../../kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true
            });
            var editor3 = K.create('#content3', {
                cssPath: '../../kindeditor/plugins/code/prettify.css',
                uploadJson: '../../kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '../../kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true
            });
            var editor4 = K.create('#content4', {
                cssPath: '../../kindeditor/plugins/code/prettify.css',
                uploadJson: '../../kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '../../kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true
            });
            prettyPrint();
        });
	</script>
</body>
</html>
