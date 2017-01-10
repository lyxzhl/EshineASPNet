<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_left.aspx.cs" Inherits="Admin_login_admin_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <TITLE>新闻管理目录</TITLE>
<META http-equiv=Content-Type content="text/html; charset=gb2312">
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<script language="javascript">
document.write('<style type="text/css">\n')
document.write('.submenu{display: none;}\n')
document.write('</style>\n')

function SwitchMenu(obj){
	if(document.getElementById){
	var el = document.getElementById(obj);
	var ar = document.getElementsByTagName("table"); //DynamicDrive.com change
		if(el.style.display != "block"){ //DynamicDrive.com change
			for (var i=0; i<ar.length; i++){
				if (ar[i].className=="submenu") //DynamicDrive.com change
				ar[i].style.display = "none";
			}
			el.style.display = "block";
		}else{
			el.style.display = "none";
		}
	}
}
</script>
<META content="MSHTML 6.00.6000.16525" name=GENERATOR>
</HEAD>
<BODY bgColor=#799ae1 leftMargin=0 topMargin=0>
<DIV align=center>
<TABLE cellSpacing=0 cellPadding=0 width=158 border=0>
  <TBODY>
  <TR>
    <TD vAlign=top>
      <TABLE cellSpacing=0 cellPadding=0 width=158>
        <TBODY>
        <TR>
          <TD vAlign=bottom height=42><IMG height=38 
            src="Img/title.gif" width=158 /> </TD></TR></TBODY></TABLE>
      <TABLE cellSpacing=0 cellPadding=0 width=158 align=center>
        <TBODY>
        <TR>
          <TD class=menu_title onMouseOver="this.className='menu_title2';" 
          onmouseout="this.className='menu_title';" 
          background=Img/title_bg_quit.gif height=25>
            <DIV align=left>&nbsp;&nbsp;<A 
            href="right.htm" target="right"><B>管理首页</B></A> | <A 
            href="../login.aspx" 
            target=_top><B>退出</B></A> </DIV></TD></TR></TBODY></TABLE><br>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <TABLE cellSpacing=0 cellPadding=0 width=158>
        <TR>
         <TD id="TD2"  onclick="SwitchMenu('sub<%# f %>')"
            background="Img/admin_left_3.gif" height=25> <span style="color: #000000"> <%# Eval("powerName")%></span>
        
           </TD>
           </TR>
        </TABLE>
        <DIV id="sub<%# f++ %>" style="WIDTH: 157px" class="sec_menu">
             <asp:Repeater DataSource='<%# Eval("pc") %>' ID="Repeater2" runat="server">
               <ItemTemplate>
               <TABLE  cellSpacing=0 cellPadding=0 width=158>
             <TR>
             <TD>
           
              <TABLE id=Table1 cellSpacing=0 cellPadding=0 width=135 
              align=center>
              <tr> <td height="20"><A href='<%# "../"+Eval("powerUrl") %>' target="right"> <span style="color: #000000"> <%# Eval("powerName") %> </span></A>
         
			  </td>
			  </tr>
			  </TABLE>
			  </DIV>
			  </TD></TR></TABLE>
               </ItemTemplate>
             </asp:Repeater>
             </DIV><br>
             
        </ItemTemplate>
        </asp:Repeater>

</DIV></BODY></HTML>