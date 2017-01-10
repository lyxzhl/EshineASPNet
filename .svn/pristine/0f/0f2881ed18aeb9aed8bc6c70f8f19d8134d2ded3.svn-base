<%@ Page Language="C#" AutoEventWireup="true" CodeFile="right.aspx.cs" Inherits="Admin_login_right" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="content">
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF">
  <tr bgcolor="#799ae1">
    <td height="30" colspan="2" align="center" style="color:#FFFFFF;font-size:13px;">服务器数据库统计</td>
    </tr>
  <tr bgcolor="#d6dff7">
    <td width="50%" height="30" bgcolor="#d6dff7">&nbsp;登陆用户: <%=Session["empName"]%></td>
    <td height="30">&nbsp;登陆身份:<span class="red"><%=Session["roleName"]%></span></td>
  </tr>
  <tr bgcolor="#d6dff7">
    <td width="50%" height="30" bgcolor="#d6dff7">&nbsp;服务器IP：<%=Request.ServerVariables["LOCAL_ADDR"]%></td>
    <td height="30">&nbsp;服务器名：<%=Request.ServerVariables["SERVER_NAME"]%></td>
  </tr>
  <tr bgcolor="#d6dff7">
    <td width="50%" height="30" bgcolor="#d6dff7">&nbsp;本机ip: <%=Request.UserHostAddress%></td>
    <td height="30">&nbsp;允许文件：<%=Request.ServerVariables["HTTP_ACCEPT"]%></td>
  </tr>
  <tr bgcolor="#d6dff7">
    <td height="30">&nbsp;服务器端口：<%=Request.ServerVariables["SERVER_PORT"]%></td>
    <td height="30">&nbsp;服务器时间：<%=DateTime .Now%></td>
  </tr>
  <tr bgcolor="#d6dff7">
    <td height="30">&nbsp;IIS版本: <%=Request.ServerVariables["SERVER_SOFTWARE"]%></td>
    <td height="30">&nbsp;脚本超时时间：<%=Server.ScriptTimeout%>（秒)</td>
  </tr>
  <tr bgcolor="#d6dff7">
    <td height="30">&nbsp;虚拟目录：<%=HttpContext.Current.Request.ApplicationPath%></td>
    <td height="30">&nbsp;物理路径：<%=HttpRuntime.AppDomainAppPath%></td>
  </tr>
  <tr bgcolor="#d6dff7">
    <td height="30">&nbsp;探针文件路径：<%=Context.Server.MapPath(Request.ServerVariables["SCRIPT_NAME"])%></td>
    <td height="30">&nbsp;服务器CPU数量: <%=Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS")%></td>
  </tr>
  <tr bgcolor="#d6dff7">
    <td height="30">&nbsp;服务器解译引擎: <%=".NET CLR" + Environment.Version.Major + "." + Environment.Version.Minor + "." + Environment.Version.Build + "." + Environment.Version.Revision%></td>
    <td height="30">&nbsp;服务器操作系统：<%=Request.ServerVariables["HTTP_USER_AGENT"]%></td>
  </tr>
  <tr bgcolor="#799ae1">
    <td height="30" colspan="2">&nbsp;</td>
    </tr>
</table>
</div>
    </form>
</body>
</html>
