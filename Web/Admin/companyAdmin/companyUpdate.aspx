<%@ Page Language="C#" AutoEventWireup="true" CodeFile="companyUpdate.aspx.cs" Inherits="Admin_companyAdmin_companyUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <script type="text/javascript">
        function showpic() {
            var filesrc = document.getElementById("File1").value;
            var Imgsrc = document.getElementById("Image1");
            Imgsrc.src = filesrc;


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div>
      <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5">
                    <asp:Label ID="Label1" runat="server" Text="公司信息更新"></asp:Label> </td>
            </tr>
<tr>
                            <td align="center" style="width: 100px">
                               
                                        <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                            Text="更　新" />
                                <asp:Button ID="Button4" runat="server"  CssClass="button" Text="提  交" onclick="Button4_Click" Visible="False" />
                            </td>
          &nbsp;&nbsp;
                            <td colspan="2">
                                <input id="Button2" class="button" onclick="location='companyInfo.aspx'" type="button" value="返　回" />
                                <asp:HyperLink ID="HyperLink1" runat="server">编辑公司地址</asp:HyperLink>
                            </td>
         
                            <td colspan="1">
                                
                            </td>
                            <td colspan="1">
                            </td>
                        </tr>

        </table>
    </div><br>
      
            <table border="1" cellpadding="0" cellspacing="0" >
                <tr>
                    <td align="center" style="width: 100px; height: 23px;" width="132">
                        公司名称：</td>
                    <td style="width: 22px; height: 23px;" width="144">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBox" Width="175px"></asp:TextBox></td>
                        <td align="center" style="width: 100px; height: 23px;" width="132">
                        公司简称：</td>
                    <td style="width: 22px; height: 23px;" width="144">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="TextBox" Width="175px"></asp:TextBox></td>
                    
                </tr>


                <tr>
                    <td align="center" style="width: 100px; height: 23px;" width="266">
                        英文缩写：</td>
                    <td style="width: 100px; height: 23px;" width="243">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="TextBox" Width="175px"></asp:TextBox></td>
                    <td align="center" style="width: 100px">
                        公司代码：</td>
                    <td style="width: 22px">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="TextBox" Width="175px"></asp:TextBox></td>
                </tr>



                <tr>
                    <td align="center" style="width: 100px; height: 23px;" width="266">
                        省份：</td>
                    <td style="width: 100px; height: 23px;" width="243">
                        <asp:DropDownList ID="com_Province" runat="server" AutoPostBack="True" 
             onselectedindexchanged="com_Province_SelectedIndexChanged" Width="105px">
            <asp:ListItem>请选择省</asp:ListItem>
        </asp:DropDownList></td>
                    <td align="center" style="width: 100px">
                        城市：</td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="com_City" runat="server" AutoPostBack="True" 
         onselectedindexchanged="com_City_SelectedIndexChanged"  Width="105px" >
            <asp:ListItem>请选择市</asp:ListItem>
        </asp:DropDownList></td>
                </tr>
                
                <tr>
                    <td align="center" style="width: 100px">
                        区：</td>
                    <td style="width: 22px">
                       <asp:DropDownList ID="com_Area" runat="server"  Width="105px" Visible="False" >
            <asp:ListItem>请选择区</asp:ListItem>
        </asp:DropDownList>
                    </td>
                    <td align="center" style="width: 100px">
                    地址：</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="TextBox" Width="175px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td align="center" style="width: 100px">
                        体检类型：</td>
                    <td style="width: 22px">
                        <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                    </td>
                    <td align="center" style="width: 100px">
                    当前体检年度：</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td align="center" style="width: 100px">
                        允许前台付：</td>
                    <td style="width: 22px">
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="允许前台付" Checked="True" />
                    </td>
                    <td align="center" style="width: 100px">
                    允许双语：</td>
                    <td style="width: 100px">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="允许双语" Checked="True" />
                    </td>
                </tr>

               <tr>
                    <td align="center" valign="top" style="width: 100px">
                        允许报告寄送到公司：</td>
                    <td valign="top" style="width: 22px">
                        <asp:CheckBox ID="CheckBox3" runat="server" Text="允许寄到公司" Checked="True" />
                    </td>
                    <td align="center" valign="top" style="width: 100px">
                    允许平台支付:</td>
                    <td valign="top" style="width: 100px">
                        <asp:CheckBox ID="CheckBox4" runat="server" Text="允许平台支付" Checked="True" />
                    </td>
                </tr>

                <tr>
                    <td align="center" valign="top" style="width: 100px">
                        允许显示首页图片切换：</td>
                    <td valign="top" style="width: 22px">
                        <asp:CheckBox ID="CheckBox7" runat="server" Text="允许显示首页图片切换" Checked="True" />
                    </td>
                    <td align="center" valign="top" style="width: 100px">
                    允许上传报告:</td>
                    <td valign="top" style="width: 100px">
                        <asp:CheckBox ID="CheckBox8" runat="server" Text="允许上传报告" Checked="True" />
                    </td>
                </tr>

                <tr>
                    <td align="center" valign="top" style="width: 100px">
                        允许洗牙：
                    </td>
                    <td valign="top" style="width: 22px">
                        <asp:CheckBox ID="CheckBox6" runat="server" Text="允许洗牙" Checked="false" />
                    </td>
                    <td align="center" valign="top" style="width: 100px">
                    可选洗牙供应商序号:</td>
                    <td valign="top" >
                        <asp:TextBox ID="TextBox17" runat="server" CssClass="TextBox" Width="175px" TextMode="MultiLine" Height="200px"></asp:TextBox></td>
                </tr>

                <tr>
                    <td align="center" valign="top" style="width: 100px">
                        可选省份：</td>
                    <td valign="top" >
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="TextBox" Width="175px" TextMode="MultiLine" Height="200px"></asp:TextBox></td>
                    <td align="center" valign="top" style="width: 100px">
                    可选城市:</td>
                    <td valign="top" style="width: 100px">
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="TextBox" Width="175px" TextMode="MultiLine" Height="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" style="width: 100px">
                        可选供应商序号：</td>
                    <td valign="top" >
                        <asp:TextBox ID="TextBox9" runat="server" CssClass="TextBox" Width="175px" TextMode="MultiLine" Height="200px"></asp:TextBox></td>
                    <td align="center" valign="top" style="width: 100px">
                    起始预约日期：</td>
                    <td valign="top" style="width: 100px">
                        <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox15"></asp:CalendarExtender>
                        </td>
                </tr>

                <tr>
                    <td align="center" valign="top" style="width: 100px">
                        家属可选省份：</td>
                    <td valign="top" >
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="TextBox" Width="175px" TextMode="MultiLine" Height="200px"></asp:TextBox></td>
                    <td align="center" valign="top" style="width: 100px">
                    家属可选城市:</td>
                    <td valign="top" style="width: 100px">
                        <asp:TextBox ID="TextBox12" runat="server" CssClass="TextBox" Width="175px" TextMode="MultiLine" Height="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" style="width: 100px">
                        家属可选供应商序号：</td>
                    <td valign="top" >
                        <asp:TextBox ID="TextBox14" runat="server" CssClass="TextBox" Width="175px" TextMode="MultiLine" Height="200px"></asp:TextBox></td>
                    <td align="center" valign="top" style="width: 100px">
                    密码初始化：</td>
                    <td valign="top" style="width: 100px">
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="pwset" Text="工号" /><br />
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="pwset" Text="证件号后6位" Checked="True" /><br />
                        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="pwset" Text="统一密码" /><br />
                        <asp:TextBox ID="TextBox10" runat="server" placeholder="输入统一密码"></asp:TextBox><br /><br />
                        <asp:Button ID="Button3" runat="server" Text="初始化密码"   OnClientClick='return confirm("此步骤将重置本公司所有员工密码，包括员工自己设置的密码，确定要初始化密码吗？");' OnClick="Button3_Click" style="height: 21px" />
                    </td>
                </tr>
                <tr>
                    <td>套餐备注</td>
                    <td>
                        <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox></td>
                    <td>妇科项目付费</td>
                    <td>
                        <asp:CheckBox ID="CheckBox5" runat="server" /></td>
                </tr>
                 <tr>
                      <td style="width: 200px">
                        <asp:CheckBox ID="CheckBox9" runat="server" Text="允许下载pdf" />
                    </td>
                     <td style="width: 200px">
                        <asp:CheckBox ID="CheckBox10" runat="server" Text="显示电子报告" />
                    </td>
                      <td style="width: 200px">
                          <asp:TextBox ID="TextBox18" runat="server" Text="导航栏显示"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
   
            
    <br /><br />
    </form>
</body>
</html>
