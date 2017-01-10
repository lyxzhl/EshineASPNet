<%@ Page Language="C#" AutoEventWireup="true" CodeFile="messages.aspx.cs" Inherits="messages" %>
<%@ Register TagPrefix="MPuc" TagName="headcontent" Src="UserControl/headcontent.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="mobilenav" Src="UserControl/mobilenav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="desktopnav" Src="UserControl/desktopnav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="footer" Src="UserControl/footer1.ascx"%>
<!DOCTYPE html>
<html>
<head>
<title>EshineAspNet - <asp:Localize ID="Localize1" runat="server" Text='<%$ Resources:GResource,titletext %>'></asp:Localize></title>
<MPuc:headcontent runat="server" ID="Unnamed1"/>
<SCRIPT src="JS/mp.js" type="text/javascript"></SCRIPT>
</head>
<body class='signups'>
<MPuc:mobilenav runat="server" ID="Unnamed2"/>
<form id="Form1" runat="server">
<div class='wrapper' data-behavior='Navigation'>
<MPuc:desktopnav runat="server" ID="Unnamed3"/>

<div class='container signup'>
<div class="simple_form new_signup_context">

    <asp:Panel ID="Panel2" runat="server" class='signup_form tile'>
<div class='row sizes'>
<div class='twelvecol'>

<div style="margin-top: 15px; margin-left: 50px">  
             <div>
    <table  style="font-size: 15px; color: #777777;">
    <tr>
    <td><img src="Images/email.png" />&nbsp;</td>
    <td height="30" style="vertical-align:middle"><asp:Label ID="Label1" runat="server" 
            Text="消息" Font-Size="27px" 
            ForeColor="#30408A" style="line-height:30px" 
            meta:resourcekey="Label1Resource1"></asp:Label>&nbsp;&nbsp;&nbsp;</td>
    <td style="vertical-align:middle"><span>(</span>
    <asp:Label id="lblMessage" runat="server" meta:resourcekey="lblMessageResource1" />
         <asp:Label ID="lblunread" runat="server" Text="1条未读消息"
            ForeColor="#DF4F3A" meta:resourcekey="lblunreadResource1"></asp:Label><span>&nbsp;)</span>
    </td>
    </tr>
    </table>
    
    </div>    
    <br />
    <table>  
                 <tr>  
                     <td id="tdAll" runat="server" colspan="2"><asp:CheckBox ID="chkAll" runat="server" 
                             Text="全选" meta:resourcekey="chkAllResource1" />
                     </td>  
                     
                     <td id="tdProductID" runat="server" colspan="2">
                         <asp:Button ID="btnRead" runat="server" Text="标记已读"  onclick="btnRead_Click" class="button blue_button"
                             meta:resourcekey="btnReadResource1"/>
                     <asp:Button ID="btnDelete" runat="server" Text="删除" onclick="btnDelete_Click"  class="button gray_button"
                             meta:resourcekey="btnDeleteResource1" />  

                         </td>
                         <td colspan="2">
       <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"  class="select required  custom_dropdown customSelect"
                             onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                             meta:resourcekey="DropDownList1Resource1" Width="70">
        <asp:ListItem meta:resourcekey="ListItemResource1">全部站内信</asp:ListItem>
        <asp:ListItem meta:resourcekey="ListItemResource2">未读站内信</asp:ListItem>
        <asp:ListItem meta:resourcekey="ListItemResource3">已读站内信</asp:ListItem>
                         </asp:DropDownList>                  
                         </td>
                 </tr>  
                 <tr><td colspan="6" height="10"></td></tr>
         <asp:Repeater ID="rptMessage" runat="server"   
             onitemcreated="rptMessage_ItemCreated"  
             onitemdatabound="rptMessage_ItemDataBound" >
             <HeaderTemplate>  
                 
             </HeaderTemplate>  
             <ItemTemplate>  
             <tr><td colspan="6" height="2" bgcolor="#F2F2F2"></td></tr>
                 <tr>  
                     <td id="tdSelect" runat="server" height="65" style="vertical-align:middle">
                         <asp:CheckBox ID="chkSelect" runat="server" 
                             meta:resourcekey="chkSelectResource1" />
                     </td>  
                     <td width="35" style="vertical-align:middle">
                         <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/mailunread.png" 
                             meta:resourcekey="Image1Resource1" /></td>
                     <td width="60" style="vertical-align:middle">
                         <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/mpmailhead.jpg" 
                             meta:resourcekey="Image2Resource1" /></td>  
                     <td width="130" style="vertical-align:middle">
                         <asp:Label ID="Label2" runat="server" Text="来自:Eshine" Width="130px" 
                             meta:resourcekey="Label2Resource1"></asp:Label>
                     <asp:Label ID="lbltime" runat="server" Text='1天前' ForeColor="#777777" 
                             meta:resourcekey="lbltimeResource1"></asp:Label></td>  
                     <td width="405" style="vertical-align:middle">
                         <asp:LinkButton ID="lbltitle" runat="server" Width="400px" 
                             CommandArgument='<%# Container.ItemIndex + "|"+Eval("Messageid") %>' 
                             OnClick="lbltitle_Click" meta:resourcekey="lbltitleResource1">通知</asp:LinkButton>
                         <asp:Panel ID="Panel1" runat="server" Width="400px" Height="30px" 
                             ForeColor="#777777" meta:resourcekey="Panel1Resource1">
                         <asp:Label ID="lblcontent" runat="server" Text="内容" Width="400px" 
                                 ForeColor="#777777" meta:resourcekey="lblcontentResource1"></asp:Label>
                             <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                         </asp:Panel>
                         
                     </td>  
                     <td style="vertical-align:middle">
                         <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/cross.png" 
                             CommandArgument='<%# Eval("Messageid") %>' OnClick="BtnDelete_Click" 
                             meta:resourcekey="BtnDeleteResource2"/>
                     </td>
                 </tr>  
             </ItemTemplate>  
             <FooterTemplate>  
             <tr><td colspan="6" height="2" bgcolor="#F2F2F2"></td></tr>
                 </table>  
             </FooterTemplate>  


         </asp:Repeater>
         <table>
         <tr>
         <td style="vertical-align:middle">
         <asp:ImageButton ID="lbtnFirst" runat="server" CommandName="First"  class="button"
                 OnCommand="lbtnPage_Command" ImageUrl="~/Images/aup.jpg" 
                 meta:resourcekey="lbtnFirstResource1" />
       <asp:ImageButton ID="lbtnPrevious" runat="server" CommandName="Previous"  class="button"
                 OnCommand="lbtnPage_Command" ImageUrl="~/Images/aleft.jpg" 
                 meta:resourcekey="lbtnPreviousResource1" />
       <asp:ImageButton ID="lbtnNext" runat="server" CommandName="Next"  class="button"
                 OnCommand="lbtnPage_Command" ImageUrl="~/Images/aright.jpg" 
                 meta:resourcekey="lbtnNextResource1" />
       <asp:ImageButton ID="lbtnLast" runat="server" CommandName="Last"  class="button"
                 OnCommand="lbtnPage_Command" ImageUrl="~/Images/adown.jpg" 
                 meta:resourcekey="lbtnLastResource1" /> 
         &nbsp;&nbsp;&nbsp;
         </td>
         <td style="vertical-align:middle">
         <asp:DropDownList ID="dropPage" runat="server" AutoPostBack="True" 
                 OnSelectedIndexChanged="dropPage_SelectedIndexChanged" Width="70px" 
                 meta:resourcekey="dropPageResource1"></asp:DropDownList>
             <asp:Label ID="Label3" runat="server" Text="页" 
                 meta:resourcekey="Label3Resource1"></asp:Label>
         </td>
         </tr>
         </table>
        
             
          
     </div>



</div>
</div>
    </asp:Panel>


    
    

</div>
</div>

</div>
</form>
<MPuc:footer ID="ucfooter" runat="server"/>

<script language="javascript" type="text/javascript">
    function chooseAll(sender) {
        var inputs = document.all.tags("INPUT");
        // 遍历页面上所有的 input   
        for (var i = 0; i < inputs.length; i++) {
            //如果此input元素的类型为checkbox，并且其id中包含chkSelect  
            if (inputs[i].type == "checkbox" && inputs[i].id.indexOf("chkSelect") >= 0) {
                //设置此复选框的checked与全选复选框相同  
                inputs[i].checked = document.getElementById(sender).checked;
                inputs[i].onclick();
            }
        }
    }

    function highLightSelected(chkSelect) {
        if (chkSelect.checked)
            chkSelect.parentElement.parentElement.style.backgroundColor = '#6c98cf';
        else
            chkSelect.parentElement.parentElement.style.backgroundColor = 'white';
    }  
     </script>
</body>
</html>
