<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shopordersubmitted.aspx.cs" Inherits="shopordersubmitted" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register TagPrefix="MPuc" TagName="headcontent" Src="UserControl/headcontent.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="mobilenav" Src="UserControl/mobilenav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="desktopnav" Src="UserControl/desktopnav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="footer" Src="UserControl/footer1.ascx"%>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head>
<title>EshineAspNet - <asp:Localize ID="Localize1" runat="server" Text='<%$ Resources:GResource,titletext %>'></asp:Localize></title>
<MPuc:headcontent runat="server" ID="Unnamed1"/>
<LINK rel=stylesheet type=text/css href="CSS/safecenter.css">
<style>
    .page-wrapper{padding:20px 0 25px;margin:0 auto}
        .page-order-list .order-status-wrapper{position:relative;top:1px;z-index:2;overflow:hidden;width:1060px;height:140px;margin:30px auto 0}.page-order-list .order-status-process{position:relative;width:930px;height:38px;margin:33px auto 0;background:url(img/status-bg.png) repeat-x 0 -129px}.page-order-list .order-status-process .status-process{display:block;height:38px;background:url(img/status-bg.png) repeat-x 0 -29px}.page-order-list .order-status-text{position:absolute;left:0;top:-33px;width:200px;height:140px;line-height:16px;text-align:center;font-size:12px;color:#666}.page-order-list .order-status-text h5{font-size:16px;color:#999}.page-order-list .order-status-text .point{display:block;width:38px;height:38px;margin:18px auto 5px;background:url(img/status-off.png) no-repeat}.page-order-list .order-status-process .status-first span.point{background:url(img/status-on-first.png) no-repeat}.page-order-list .order-status-process .status-last .point{background:url(img/status-off-last.png) no-repeat}.page-order-list .order-status-process .status-on span.point{background:url(img/status-on.png) no-repeat}.page-order-list .order-status-process .status-on{background:url(img/order-status-bottom-arrow.png) center bottom no-repeat}.page-order-list .order-status-process .status-done .point{background:url(img/status-done.png) no-repeat}.page-order-list .order-status-process .status-done h5,.page-order-list .order-status-process .status-on h5{color:#333}.page-order-list .order-status-now{width:998px;background:#F6F6F6;border:#dadada solid 1px;border-radius:5px;padding:20px 30px;margin:0 auto;line-height:38px}.page-order-list .order-status-now h3{color:#666;font-size:24px;line-height:40px}
    </style>
<SCRIPT src="JS/mp.js" type="text/javascript"></SCRIPT>
</head>
<body class='signups'>
<MPuc:mobilenav runat="server" ID="Unnamed2"/>
<form id="Form1" runat="server">
<div class='wrapper' data-behavior='Navigation'>
<MPuc:desktopnav runat="server" ID="Unnamed3"/>


<DIV class="container signup">
<div class="simple_form new_signup_context" id="new_signup_context">



     <asp:Panel class="signup_form tile" ID="Panel12" runat="server">
         <div class="page-wrapper page-order-list">
        <div class="order-status-process" style="width: 372px">
            <div class="order-status-process" style="width: 372px">
            <span class="status-process" style="width: 372px;"></span>
            <div class="order-status-text status-first status-done" style="width: 186px; height: 90px; left: -93px;">
                <h5><asp:Localize ID="Localize7" runat="server" Text='<%$ Resources:GResource,xuanze %>'></asp:Localize></h5>
                <span class="point"></span>
            </div>
            <div class="order-status-text status-done" style="width: 186px; height: 90px; left: 93px;">
                <h5><asp:Localize ID="Localize2" runat="server" Text='<%$ Resources:GResource,tianxie %>'></asp:Localize></h5>
                <span class="point"></span>
            </div>
            <div class="order-status-text status-last status-on" style="width: 186px; height: 90px; left: 279px;">
                <h5><asp:Localize ID="Localize3" runat="server" Text='<%$ Resources:GResource,queren %>'></asp:Localize></h5>
                <span class="point"></span>
            </div>
        </div>
        </div>
    </div>
<DIV class="row">
    
<DIV class="twelvecol" style="height:100px;margin-top:10px">
    
        
     <%--<h1 style="text-align:center"><img src="Images/shopstep3.jpg" /></h1>--%>
<H3 style="text-align:left;height:60px;margin-left:10px" ><asp:Localize ID="Localize17" runat="server" Text='<%$ Resources:GResource,payway %>'></asp:Localize>
    <br /><span style="text-align:left;"><asp:Localize ID="Localize4" runat="server" Text='<%$ Resources:GResource,money %>'></asp:Localize>： <asp:Label ID="Label2" runat="server" Text=""></asp:Label><asp:Label ID="Label6" runat="server" Text=""></asp:Label></span></H3>
<H3 style="text-align:center"></H3></DIV></DIV>
<DIV class="row sizes">
<DIV class="fourcol">
    <asp:Panel ID="Panel1" runat="server">
    <DIV class="input string required" style="text-align:center;">
        <img alt="" src="Images/payme_a.png" />
        <asp:Label ID="Label1" runat="server" Text='<%$ Resources:GResource,qrnofee %>'></asp:Label>
        <br /><br />
      </DIV>
    </asp:Panel>

</DIV>
<DIV class="fourcol">
    


    <asp:Panel ID="Panel13" runat="server">
      <DIV class="input string required" style="text-align:center;">
        <img alt="" src="Images/payme_w.png" />
        <asp:Label ID="Label3" runat="server" Text='<%$ Resources:GResource,qrnofee %>'></asp:Label>
        <br /><br />
      </DIV>

    </asp:Panel>

  
    </div>
    <DIV class="fourcol last">
        <br /> <br />
          <DIV class="input string required">

        <asp:HyperLink ID="HyperLink3" class="button blue_button " runat="server" style="width:100%" Text='在线支付' Target="_blank" NavigateUrl="~/payment.aspx?oid="></asp:HyperLink>
      </DIV>
<DIV style="text-align:center">
<h3>支持网银、支付宝</h3>
</DIV>

    </DIV>
    </DIV>
    </asp:Panel>

   


</div>
</DIV></div>
</form>


<MPuc:footer ID="ucfooter" runat="server"/>
 </body>
</html>
