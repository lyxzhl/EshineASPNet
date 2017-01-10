<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fetchpassword2.aspx.cs" Inherits="fetchpassword2" %>

<%@ Register TagPrefix="MPuc" TagName="headcontent" Src="UserControl/headcontent.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="mobilenav" Src="UserControl/mobilenav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="desktopnav" Src="UserControl/desktopnav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="footer" Src="UserControl/footer1.ascx"%>
<!DOCTYPE html>
<html>
<head>
<title>EshineAspNet - 微软专家</title>
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
    <asp:Panel ID="Panel1" runat="server" class=' tile' Visible="False">
    <div class='row'>
<div class='twelvecol'>
<h1>通过手机+身份证号找回</h1>
<div class='row sizes'>
<P>
<asp:Label ID="Label1" runat="server" Text="密码已发送至您的手机，请注意查收！"></asp:Label></P>
<asp:HyperLink ID="HyperLink2" class="action blue_button button session_button" runat="server" Text="返回" NavigateUrl="login.aspx"></asp:HyperLink>
</div>
</div>
</div>
    </asp:Panel>
    <asp:Panel ID="Panel5" runat="server" class='signup_form tile'>
<div class='row'>
<div class='twelvecol'>
<h1>通过手机+身份证号找回</h1>
<h4></h4>
</div>
</div>
<div class='row sizes'>
<div class='threecol'></div>
<div class='fivecol'>

<div class="input string required">
    <asp:Label class="string required" ID="Label3" runat="server" Text="手机号：" ></asp:Label>
    <asp:TextBox class="string tel required numeric" ID="TextBox2"  runat="server" type="tel" maxlength="11" minlength="11" placeholder="手机号" ></asp:TextBox>
</div>
<div class="input string required">
    <asp:Label class="string required" ID="Label11" runat="server" Text="身份证号：" ></asp:Label>
    <asp:TextBox class="string required" ID="TextBox3" runat="server"  onblur="javascript:cidInfo(this.value);" MaxLength="18" placeholder="身份证号码"></asp:TextBox>
    
</div>
<div class="input string required">
    <asp:HyperLink ID="HyperLink1" runat="server" class="button gray_button" NavigateUrl="~/login2.aspx">取消</asp:HyperLink>
    <asp:Button ID="Button6" runat="server" Text="确认"  
        class="button blue_button"
        OnClientClick="return check3();" onclick="Button6_Click"/>
</div>

</div>
<div class='fourcol last'>
<ul class='selling_points mobile_hidden'>
<li>

</li>
</ul>
</div>
</div>

    </asp:Panel>

</div>
</div>

</div>
</form>
<MPuc:footer ID="ucfooter" runat="server"/>


<script>
    var aCity = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江 ", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北 ", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏 ", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外 " }
    var t3 = document.getElementById("<%=TextBox3.ClientID%>");
    function cidInfo(sId) {
        var iSum = 0
        var info = ""
        if (!/^\d{17}(\d|X|x)$/.test(sId)) {
            alert('"请输入完整身份证号码！');
            TextBox3.focus();
            return;
        }
        sId = sId.replace(/x$/i, "a");
        if (aCity[parseInt(sId.substr(0, 2))] == null) { alert('Error:<asp:Localize ID="Localize14" runat="server" Text="非法地区" meta:resourcekey="Localize14Resource1"></asp:Localize>'); TextBox3.focus(); return; }
        sBirthday = sId.substr(6, 4) + "-" + Number(sId.substr(10, 2)) + "-" + Number(sId.substr(12, 2));
        var d = new Date(sBirthday.replace(/-/g, "/"))
        if (sBirthday != (d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate())) { alert('Error:<asp:Localize ID="Localize15" runat="server" Text="非法生日" meta:resourcekey="Localize15Resource1"></asp:Localize>'); TextBox3.focus(); return; }
        for (var i = 17; i >= 0; i--) iSum += (Math.pow(2, i) % 11) * parseInt(sId.charAt(17 - i), 11)
        if (iSum % 11 != 1) { alert('Error:<asp:Localize ID="Localize16" runat="server" Text="非法证号" meta:resourcekey="Localize16Resource1"></asp:Localize>'); TextBox3.focus(); return; }
    }

    function check3() {
        var t2 = document.getElementById("<%=TextBox2.ClientID%>").value;
        var t3 = document.getElementById("<%=TextBox3.ClientID%>").value;
        if (t2 == "" || t3 == "") {
            alert("请输入手机号与身份证号！");
            return false;
        }
        else if (t2.length < 11) {
            alert("手机号必须为11位数！");
            return false;
        }
        else if (t3.length < 18) {
            alert("身份证号必须为18位数！");
            return false;
        }
        else
            return true;
    }
</script>
</body>
</html>

