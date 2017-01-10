<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ Register TagPrefix="MPuc" TagName="mobilenav" Src="UserControl/mobilenav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="desktopnav" Src="UserControl/desktopnav.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<META content="IE=10.000" http-equiv="X-UA-Compatible">
<META http-equiv="Content-Type" content="text/html; charset=UTF-8">     
<title>EshineAspNet | <asp:Localize ID="Localize1" runat="server" Text='<%$ Resources:GResource,titletext %>'></asp:Localize></TITLE>     
<META name="description" content="EshineASPNet"> 
<META name="viewport" content="width=device-width, initial-scale=1">         

      



        	

<link rel='stylesheet' id='camera-css'  href='css/camera.css' type='text/css' media='all'>  
 <LINK id="colorbox-css" href="css/colorbox.css" rel="stylesheet" type="text/css" media="all">   
 <link rel="stylesheet" href="CSS/onlineqqservice.css" />
 <link href="assets/trunkclub-d1b693260400bfdc2a0f7777f2fc64fc.css" media="screen" rel="stylesheet" type="text/css" />
 <link href="assets/tablet-bbeffdf3d4330828df91742e83e0d425.css" media="screen" rel="stylesheet" type="text/css" />
<link href="assets/mobile-b4dfb4e2266dfdf07b574db85a06993c.css" media="screen" rel="stylesheet" type="text/css" />
<link href="assets/print-c8a015c86e416d5901f0fb479d296674.css" media="print" rel="stylesheet" type="text/css" />

            <style>
		html,body {
			height: 100%;
			margin: 0;
			padding: 0;
		}

		#back_to_camera {

			clear: both;
			display: block;
			height: 220px;
			line-height: 40px;
			padding: 0;

			width:400px;
			margin: auto;
  position: absolute;
  top: 0; left: 0; bottom: 0; right: 0;

			z-index: 1;
		}
		.fluid_container {
			bottom: 0;
		
			left: 0;
			position: fixed;
			right: 0;
			top: 50px;
			z-index: 0;
		}
		#camera_wrap_4 {
			bottom: 0;
			height: 100%;
			left: 0;
			margin-bottom: 0px;
			margin-top:50px;
			
			position: fixed;
			right: 0;
			top: 0;
		}
		.camera_bar {
			z-index: 2;

		}
		.camera_thumbs {
			margin-top: -142px;
			position: relative;
			z-index: 1;
		}
		.camera_thumbs_cont 
		{
		    background:rgba(255,255,255,0.1);
			border-radius: 0;
			-moz-border-radius: 0;
			-webkit-border-radius: 0;
		}
		.camera_overlayer {
			opacity: .1;
		}
		
		nav#desktop{height:25px;}
		
		nav#desktop .logo{margin-top:0px}
		
		.logo {
			margin-top:0px;
		}
	</style>

    <script type='text/javascript' src='JS/jquery.min.js'></script>
    <script type='text/javascript' src='JS/jquery.mobile.customized.min.js'></script>
    <script type='text/javascript' src='JS/jquery.easing.1.3.js'></script> 
    <script type='text/javascript' src='JS/camera.min.js'></script> 
  <script src="js/service.js"></script>
    <script>

        jQuery(function () {

            jQuery('#camera_wrap_4').each(function () {

                var t = jQuery(this);

                var s = 0;

                t.camera({

                    height: 'auto',
                    loader: 'bar',
                    pagination: false,
                    thumbnails: true,
                    hover: false,
                    opacityOnGrid: false,
                    barPosition: 'top',

                    onEndTransition: function () {


                        var ind = t.find('.camera_target .cameraSlide.cameracurrent').index();
                        t.parents().find('.MM').removeClass("active");
                        t.parents().find('#M'+ind).addClass("active");


                    }

                });

            });

        });


        jQuery(function () {

            jQuery('#camera_wrap_4_lyx').camera({
                height: 'auto',
                loader: 'bar',
                pagination: false,
                thumbnails: true,
                hover: false,
                opacityOnGrid: false,
                barPosition: 'top',
                onEndTransition: function () {
                    var ind = $('.camera_target .cameraSlide.cameracurrent').index();
                        $(".M1").addClass("active");
                }
            });

            });

       jQuery(document).ready(function () {



                jQuery("#hamburger").click(function () {
                    if (jQuery("nav#mobile").hasClass("show_nav")) {
                        jQuery("nav#mobile,.wrapper,header,footer").removeClass("show_nav");
                        jQuery("nav#mobile,.wrapper,header,footer").addClass("hide_nav");
                    }
                    else {
                        jQuery("nav#mobile,.wrapper,header,footer").removeClass("hide_nav");
                        jQuery("nav#mobile,.wrapper,header,footer").addClass("show_nav");
                    }
                });

                jQuery(".close_nav").click(function () {
                    jQuery("nav#mobile,.wrapper,header,footer").removeClass("show_nav");
                    jQuery("nav#mobile,.wrapper,header,footer").addClass("hide_nav");
                });
            });

	</script>
    <SCRIPT>
        function sendemail(email) {
            window.location.href = "mailto:" + escape(email);
        }
		</SCRIPT>
        <SCRIPT src="JS/mp.js" type="text/javascript"></SCRIPT>

</HEAD> 
<BODY class='homes'>

<MPuc:mobilenav ID="Mobilenav1" runat="server"/>
<div class="simple_form new_login_context">
<div class='wrapper' style=" padding-top:60px; padding-bottom:0px;">
    <form runat="server">
<MPuc:desktopnav ID="Desktopnav1" runat="server"/>
        </form>
</div>
</div>





<div id="back_to_camera">

    </div><!-- #back_to_camera -->
    

	<div class="fluid_container">
        <div class="camera_wrap camera_azure_skin" id="camera_wrap_4">
            <div data-thumb="Images/slides/thumbs/index1.jpg" data-src="Images/slides/index1.jpg">
            <div style="position:absolute; z-index:99999; top:20%; left:25%; background:rgba(255, 255, 255, 0.3); color:#fff; padding:50px 0 0 20px; width:400px; height:200px;" class="fadeIn">
             <p style="color:#000000; font-size:30px;"><asp:Label ID="Label9" runat="server"  Text='<%$ Resources:GResource,scrumdev %>' ></asp:Label></p>
<p style="color:#333333; font-size:20px;">
    <asp:Label ID="Label10" runat="server" meta:resourcekey="Label10Resource1"></asp:Label></p><br />
<asp:HyperLink ID="HyperLink4" runat="server" 
        class='button blue_button' href='benefitplan.aspx' style="width:120px;height:40px; line-height:40px; text-decoration:none; font-weight:bold;"
         Text='<%$ Resources:GResource,view %>'  ></asp:HyperLink>
             </div>
            </div>
            <div data-thumb="Images/slides/thumbs/index2.jpg" data-src="Images/slides/index2.jpg">
             <div style="position: absolute; z-index:99999; top:20%; left:20%; background:rgba(255, 255, 255, 0); color:#fff; padding:15px; width:400px; height:200px;" class="fadeIn">
             <p style="color:#000000; font-size:30px;"><asp:Label ID="Label2" runat="server" Text='<%$ Resources:GResource,mapinti %>'></asp:Label></p>
<p style="color:#333333; font-size:20px;">
    <asp:Label ID="Label3" runat="server"   meta:resourcekey="Label2Resource1"></asp:Label></p>
<asp:HyperLink ID="HyperLink3" runat="server" 
        class='button blue_button' href='mapinti.aspx' style="width:90px;height:40px; line-height:40px; text-decoration:none; font-weight:bold;"
         Text='<%$ Resources:GResource,view %>'></asp:HyperLink>
             </div>
            </div>
            <div data-thumb="Images/slides/thumbs/index3.jpg" data-src="Images/slides/index3.jpg">
            <div style="position:absolute; z-index:99999; top:25%; left:15%; background:rgba(108, 152, 207, 0.8); color:#fff; padding:50px 0 0 40px; width:400px; height:200px;" class="fadeIn">
             <p style="color:#ffffff; font-size:30px;"><asp:Label ID="Label6" runat="server" Text='<%$ Resources:GResource,mpwechat %>'></asp:Label></p>
<p style="color:#ffffff; font-size:20px;">
    <asp:Label ID="Label7" runat="server" meta:resourcekey="Label14Resource1"></asp:Label></p><br />
<asp:HyperLink ID="HyperLink5" runat="server" 
        class='button blue_button' href='report.aspx' style="width:120px;height:40px; line-height:40px; text-decoration:none; font-weight:bold;"
         Text='<%$ Resources:GResource,view %>'></asp:HyperLink>
             </div>
            </div>
            <div data-thumb="Images/slides/thumbs/index4.jpg" data-src="Images/slides/index4.jpg">
             <div style="position: absolute; z-index:99999; top:23%; left:25%; background:rgba(255, 255, 255, 0.3); color:#fff; padding:50px 0 0 30px; width:400px; height:200px;" class="fadeIn">
             <p style="color:#000000; font-size:30px;"><asp:Label ID="Label8" runat="server" Text='<%$ Resources:GResource,onlineshop %>'></asp:Label></p>
<p style="color:#333333; font-size:20px;"><asp:Label ID="Label11" runat="server" meta:resourcekey="Label11Resource1"></asp:Label></p>
<asp:HyperLink ID="HyperLink10" runat="server" 
        class='button blue_button' href='healthconsult.aspx' style="width:90px;height:40px; line-height:40px; text-decoration:none; font-weight:bold;"
         Text='<%$ Resources:GResource,view %>' ></asp:HyperLink>
             </div>
            </div>
            

        </div><!-- #camera_wrap_3 -->

    </div>
    
    <!-- .fluid_container -->

      </BODY></HTML>

