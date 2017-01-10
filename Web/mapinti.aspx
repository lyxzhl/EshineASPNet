<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mapinti.aspx.cs" Inherits="mapinti" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register TagPrefix="MPuc" TagName="headcontent" Src="UserControl/headcontent.ascx" %>
<%@ Register TagPrefix="MPuc" TagName="mobilenav" Src="UserControl/mobilenav.ascx" %>
<%@ Register TagPrefix="MPuc" TagName="desktopnav" Src="UserControl/desktopnav.ascx" %>
<%@ Register TagPrefix="MPuc" TagName="footer" Src="UserControl/footer1.ascx" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head>
    <title>EshineAspNet -
        <asp:Localize ID="Localize1" runat="server" Text='<%$ Resources:GResource,titletext %>'></asp:Localize></title>
    <MPuc:headcontent runat="server" ID="Unnamed1" />
    <link rel="stylesheet" type="text/css" href="CSS/safecenter.css">
    <script src="JS/mp.js" type="text/javascript"></script>
    <!--script type="text/javascript" src="http://api.map.baidu.com/api?ak=YG2iv0eCzo1z6YTsau5pgd24&v=2.0"></!--script-->
    <script type="text/javascript" src="http://api.map.baidu.com/api?ak=YG2iv0eCzo1z6YTsau5pgd24&v=1.5"></script>
    <script src="JS/baidumap.js" type="text/javascript"></script>



</head>
<body class='signups'>
    <MPuc:mobilenav runat="server" ID="Unnamed2" />
    <form id="Form1" runat="server">
        <div class='wrapper' data-behavior='Navigation'>
            <MPuc:desktopnav runat="server" ID="Unnamed3" />


            <div class="container signup">
                <div class="simple_form new_signup_context" id="new_signup_context">

                    <div id="main" runat="server">
                        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </asp:ToolkitScriptManager>
                    </div>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <div style="filter: alpha(opacity=80); background-color: #f0f0f0; width: 150px; height: 150px; text-align: center;">
                                <asp:Label ID="Labelwait1" runat="server" Text="正在联系体检中心..."
                                    meta:resourcekey="LabelwaitResource1"></asp:Label><br />
                                <asp:Label ID="Labelwait2" runat="server" Text="可能持续约几秒钟" meta:resourcekey="Labelwait2Resource1"></asp:Label><br />
                                <img src="Images/loading.gif" align="middle" width="100px" height="100px" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButPop"
                        PopupControlID="UpdateProgress1" DynamicServicePath="" Enabled="True">
                    </asp:ModalPopupExtender>
                    <asp:LinkButton ID="LinkButPop" runat="server" class="hidden"></asp:LinkButton>

                    



                    

                    <div class='choose_stores tile'>
                        <div class="row">
                            <div class="twelvecol">
                                <h1>
                                    <asp:Localize ID="Localize18" runat="server" Text='<%$ Resources:GResource,choosebranch %>'></asp:Localize></h1>
                                <br />
                            </div>
                        </div>
                        <div class="row stores">
                            <div class="eightcol">
                                <div class="three_input_grouping">
                                    <div class="input month_select required">
                                        <asp:DropDownList ID="com_Province" runat="server" AutoPostBack="True" class="select required customSelect"
                                            OnSelectedIndexChanged="com_Province_SelectedIndexChanged"
                                            meta:resourcekey="com_ProvinceResource1">
                                            <asp:ListItem Text='<%$ Resources:GResource,selectProvince %>'></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div class="input select required">
                                        <asp:DropDownList ID="com_City" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="com_City_SelectedIndexChanged" class="select required customSelect"
                                            meta:resourcekey="com_CityResource1">
                                            <asp:ListItem Text='<%$ Resources:GResource,selectCity %>'></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="input select hidden">
                                        <asp:DropDownList ID="com_Area" runat="server" class="select required customSelect"
                                            meta:resourcekey="com_AreaResource1">
                                            <asp:ListItem Text='<%$ Resources:GResource,selectZone %>'></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="input select hidden">
                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" class="select required customSelect"
                                            meta:resourcekey="DropDownList1Resource1">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="hidden">
                                        <a class="button blue_button" onclick='document.getElementById("mapdiv").className = "row";'>地图显示</a>
                                    </div>
                                </div>

                            </div>
                            <div class="fourcol last hidden">
                                <h4>
                                    <asp:Localize ID="Localize19" runat="server" Text='<%$ Resources:GResource,rightselectbranch %>'></asp:Localize></h4>



                            </div>
                        </div>

                        <div class="row stores">
                            <div class="fourcol <%=hideik %>">
                                <h3 style='color: #f15a22; display: none'>
                                    <asp:Localize ID="Localize20" runat="server" Text='<%$ Resources:GResource,ikang %>'></asp:Localize></h3>
                                <asp:Panel ID="Panel14" runat="server" Width="100%" Height="360" ScrollBars="auto">
                                    <div class=" password_management">
                                        <div class="pm_index" style="width: 288px;">
                                            <ul style="filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src='', sizingMethod='scale')">

                                                <%=supplierlistcontentikang%>
                                            </ul>



                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="fourcol <%= hidemn %>">
                                <h3 style='color: #ed1266; display: none'>
                                    <asp:Localize ID="Localize22" runat="server" Text='<%$ Resources:GResource,meinian %>'></asp:Localize></h3>
                                <asp:Panel ID="Panel16" runat="server" Width="100%" Height="460" ScrollBars="auto">
                                    <div class=" password_management">
                                        <div class="pm_index" style="width: 288px;">
                                            <ul style="filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src='', sizingMethod='scale')">
                                                <%=supplierlistcontentmeinian%>
                                            </ul>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="fourcol last">
                                <h3 style='color: #0e8e35; display: none'>
                                    <asp:Localize ID="Localize21" runat="server" Text='<%$ Resources:GResource,ciming %>'></asp:Localize></h3>
                                <asp:Panel ID="Panel15" runat="server" Width="100%" Height="460" ScrollBars="auto">
                                    <div class=" password_management">
                                        <div class="pm_index" style="width: 288px;">
                                            <ul style="filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src='', sizingMethod='scale')">
                                                <%=supplierlistcontentciming%>
                                            </ul>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>

                        </div>

                        <div class="row stores" id="mapdiv">
                            <div class="twelvecol ">
                                <br />
                                <cc1:GMap ID="GMap1_bk" runat="server" Width="100%" Height="480" GZoom="12" Visible="false" />
                                <div style="width: 100%; height: 480px; border: #ccc solid 1px;" id="dituContent"></div>
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>

                            </div>
                        </div>

                        <div class="fixed_button <%=continue2class %>" id="continue2">
                            <div class="spinner"></div>

                            <asp:Button class="button blue_button continue continue_form" ID="Button4" runat="server" Text='<%$ Resources:GResource,continuego %>' OnClick="Button4_Click" OnClientClick="showpop();" />

                            <p class="terms"></p>
                        </div>
                    </div>




                    


                    


                    

                    

                    

                    

                </div>
            </div>
        </div>
    </form>


    
</body>
</html>
