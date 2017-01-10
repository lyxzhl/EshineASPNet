<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalDetails.aspx.cs" Inherits="PersonalDetails" %>
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
<body class='member_profiles'>
<MPuc:mobilenav runat="server" ID="Unnamed2"/>
<div class='wrapper' data-behavior='Navigation'>

    <form runat='server' class='container'>
<MPuc:desktopnav runat="server" ID="Unnamed3"/>



<h2><asp:Localize ID="Localize28" runat="server" Text='<%$ Resources:GResource,personaldetail %>'></asp:Localize></h2>
<div class='edit_profile row' data-behavior='Tabs'>
<div class='twocol'>
<div id='errors'></div>
<div id='tabs'>
<ul class='tabs'>
<li class='active'>
<a href="PersonalDetails.aspx"><asp:Localize ID="Localize27" runat="server" Text='<%$ Resources:GResource,personaldetail %>'></asp:Localize></a>
</li>
<li class=''>
<a href="RelativesDetails.aspx">
    <asp:Label ID="Label1" runat="server" Text='<%$ Resources:GResource,relativedetail %>'></asp:Label></a>
</li>
<li class=''>
<a href="addressmanaging.aspx">
    <asp:Label ID="Label2" runat="server" Text='<%$ Resources:GResource,addressmanagement %>'></asp:Label></a>
</li>
</ul>

</div>
</div>
<div class='tencol last tile' id='forms'>

<div class='tab' id='addresses'>
<div class='row'>
<div class='left sixcol' id='add_new_address'>
<h3><asp:Localize ID="Localize29" runat="server" Text='<%$ Resources:GResource,personaldetail %>'></asp:Localize></h3>
<div class="simple_form new_address_context">
<div class="input string required">
<label class="string required" for="address_context_recipient_name">
<asp:Localize ID="Localize11" runat="server" Text="全名" meta:resourcekey="Localize11Resource1"></asp:Localize></label>
<asp:TextBox class="string required" ID="TextBox1" runat="server" placeholder="证件姓名" Enabled="False"></asp:TextBox>
</div>
<DIV class="input string required">
<LABEL class="string required" for="signup_context_first_name">
<asp:Localize runat="server" Text="身份证号" meta:resourcekey="Localize16Resource1"></asp:Localize></LABEL>
    <asp:TextBox class="string required" ID="TextBox3" runat="server" placeholder="身份证" onblur="javascript:cidInfo(this.value);" MaxLength="18" Enabled="False"></asp:TextBox>
    <asp:TextBox ID="TextBox6" runat="server" Visible="false"></asp:TextBox>
</DIV>
<DIV class="input string required">
<LABEL class="string required" for="signup_context_first_name">
<asp:Localize ID="Localize3" runat="server" Text='<%$ Resources:GResource,passportnum %>'></asp:Localize></LABEL>
    <asp:TextBox class="string required" ID="TextBox5" runat="server" placeholder='<%$ Resources:GResource,foreignpassnum %>' MaxLength="18" ></asp:TextBox>
</DIV>
<DIV class="input email required">
<LABEL class="email required" for="signup_context_first_name">
<asp:Localize ID="Localize21" runat="server" Text="私人邮箱" meta:resourcekey="Localize21Resource1"></asp:Localize></LABEL>
    <asp:TextBox class="string email required" ID="TextBox2" runat="server" type="email" placeholder="私人邮箱"></asp:TextBox>
</DIV>
<DIV id="email_warning"></DIV>
<DIV class="three_input_grouping">
<DIV class="input month_select required">
<LABEL class="month_select required" for="signup_context_birth_month">
<asp:Localize ID="Localize14" runat="server" Text="出生日期" meta:resourcekey="Localize14Resource1"></asp:Localize></LABEL>
    <asp:DropDownList ID="DropDownListYear" class="select required customSelect" runat="server" Enabled="False">
        <asp:ListItem Text='<%$ Resources:GResource,year %>'></asp:ListItem>
<asp:ListItem>2012</asp:ListItem>
<asp:ListItem>2011</asp:ListItem>
<asp:ListItem>2010</asp:ListItem>
<asp:ListItem>2009</asp:ListItem>
<asp:ListItem>2008</asp:ListItem>
<asp:ListItem>2007</asp:ListItem>
<asp:ListItem>2006</asp:ListItem>
<asp:ListItem>2005</asp:ListItem>
<asp:ListItem>2004</asp:ListItem>
<asp:ListItem>2003</asp:ListItem>
<asp:ListItem>2002</asp:ListItem>
<asp:ListItem>2001</asp:ListItem>
<asp:ListItem>2000</asp:ListItem>
<asp:ListItem>1999</asp:ListItem>
<asp:ListItem>1998</asp:ListItem>
<asp:ListItem>1997</asp:ListItem>
<asp:ListItem>1996</asp:ListItem>
<asp:ListItem>1995</asp:ListItem>
<asp:ListItem>1994</asp:ListItem>
<asp:ListItem>1993</asp:ListItem>
<asp:ListItem>1992</asp:ListItem>
<asp:ListItem>1991</asp:ListItem>
<asp:ListItem>1990</asp:ListItem>
<asp:ListItem>1989</asp:ListItem>
<asp:ListItem>1988</asp:ListItem>
<asp:ListItem>1987</asp:ListItem>
<asp:ListItem>1986</asp:ListItem>
<asp:ListItem>1985</asp:ListItem>
<asp:ListItem>1984</asp:ListItem>
<asp:ListItem>1983</asp:ListItem>
<asp:ListItem>1982</asp:ListItem>
<asp:ListItem>1981</asp:ListItem>
<asp:ListItem>1980</asp:ListItem>
<asp:ListItem>1979</asp:ListItem>
<asp:ListItem>1978</asp:ListItem>
<asp:ListItem>1977</asp:ListItem>
<asp:ListItem>1976</asp:ListItem>
<asp:ListItem>1975</asp:ListItem>
<asp:ListItem>1974</asp:ListItem>
<asp:ListItem>1973</asp:ListItem>
<asp:ListItem>1972</asp:ListItem>
<asp:ListItem>1971</asp:ListItem>
<asp:ListItem>1970</asp:ListItem>
<asp:ListItem>1969</asp:ListItem>
<asp:ListItem>1968</asp:ListItem>
<asp:ListItem>1967</asp:ListItem>
<asp:ListItem>1966</asp:ListItem>
<asp:ListItem>1965</asp:ListItem>
<asp:ListItem>1964</asp:ListItem>
<asp:ListItem>1963</asp:ListItem>
<asp:ListItem>1962</asp:ListItem>
<asp:ListItem>1961</asp:ListItem>
<asp:ListItem>1960</asp:ListItem>
<asp:ListItem>1959</asp:ListItem>
<asp:ListItem>1958</asp:ListItem>
<asp:ListItem>1957</asp:ListItem>
<asp:ListItem>1956</asp:ListItem>
<asp:ListItem>1955</asp:ListItem>
<asp:ListItem>1954</asp:ListItem>
<asp:ListItem>1953</asp:ListItem>
<asp:ListItem>1952</asp:ListItem>
<asp:ListItem>1951</asp:ListItem>
<asp:ListItem>1950</asp:ListItem>
<asp:ListItem>1949</asp:ListItem>
<asp:ListItem>1948</asp:ListItem>
<asp:ListItem>1947</asp:ListItem>
<asp:ListItem>1946</asp:ListItem>
<asp:ListItem>1945</asp:ListItem>
<asp:ListItem>1944</asp:ListItem>
<asp:ListItem>1943</asp:ListItem>
<asp:ListItem>1942</asp:ListItem>
<asp:ListItem>1941</asp:ListItem>
<asp:ListItem>1940</asp:ListItem>
<asp:ListItem>1939</asp:ListItem>
<asp:ListItem>1938</asp:ListItem>
<asp:ListItem>1937</asp:ListItem>
<asp:ListItem>1936</asp:ListItem>
<asp:ListItem>1935</asp:ListItem>
<asp:ListItem>1934</asp:ListItem>
<asp:ListItem>1933</asp:ListItem>

    </asp:DropDownList>
    
</DIV>
<DIV class="input select required">
<LABEL class="select required" for="signup_context_birth_date"> &nbsp;</LABEL>
<asp:DropDownList ID="DropDownListMonth" class="month_select required customSelect" runat="server" Enabled="False">
    <asp:ListItem Text='<%$ Resources:GResource,month %>'></asp:ListItem>
<asp:ListItem>1</asp:ListItem>
<asp:ListItem>2</asp:ListItem>
<asp:ListItem>3</asp:ListItem>
<asp:ListItem>4</asp:ListItem>
<asp:ListItem>5</asp:ListItem>
<asp:ListItem>6</asp:ListItem>
<asp:ListItem>7</asp:ListItem>
<asp:ListItem>8</asp:ListItem>
<asp:ListItem>9</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
<asp:ListItem>11</asp:ListItem>
<asp:ListItem>12</asp:ListItem>

    </asp:DropDownList>
</DIV>
<DIV class="input select required">
<LABEL class="select required" for="signup_context_birth_year"> &nbsp;</LABEL>
    <asp:DropDownList ID="DropDownListDay" class="select required customSelect" runat="server" Enabled="False">
    <asp:ListItem Text='<%$ Resources:GResource,day %>'></asp:ListItem>
<asp:ListItem>1</asp:ListItem>
<asp:ListItem>2</asp:ListItem>
<asp:ListItem>3</asp:ListItem>
<asp:ListItem>4</asp:ListItem>
<asp:ListItem>5</asp:ListItem>
<asp:ListItem>6</asp:ListItem>
<asp:ListItem>7</asp:ListItem>
<asp:ListItem>8</asp:ListItem>
<asp:ListItem>9</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
<asp:ListItem>11</asp:ListItem>
<asp:ListItem>12</asp:ListItem>
<asp:ListItem>13</asp:ListItem>
<asp:ListItem>14</asp:ListItem>
<asp:ListItem>15</asp:ListItem>
<asp:ListItem>16</asp:ListItem>
<asp:ListItem>17</asp:ListItem>
<asp:ListItem>18</asp:ListItem>
<asp:ListItem>19</asp:ListItem>
<asp:ListItem>20</asp:ListItem>
<asp:ListItem>21</asp:ListItem>
<asp:ListItem>22</asp:ListItem>
<asp:ListItem>23</asp:ListItem>
<asp:ListItem>24</asp:ListItem>
<asp:ListItem>25</asp:ListItem>
<asp:ListItem>26</asp:ListItem>
<asp:ListItem>27</asp:ListItem>
<asp:ListItem>28</asp:ListItem>
<asp:ListItem>29</asp:ListItem>
<asp:ListItem>30</asp:ListItem>
<asp:ListItem>31</asp:ListItem>
    </asp:DropDownList>
</DIV></DIV>
<div class="two_input_grouping">
<div class="input string required">
<p class="field switch">
        <asp:RadioButton ID="RadioButton1" runat="server" Text="男"  class="hidden" GroupName="sex" />
        <asp:RadioButton ID="RadioButton2" runat="server" Text="女" class="hidden" GroupName="sex" />
		<label id="malelabel" for="<%=RadioButton1.ClientID%>" class="cb-enable <%=classmale %>"><span>
        <asp:Localize ID="Localize4" runat="server" Text='<%$ Resources:GResource,male %>'></asp:Localize></span></label>
		<label id="femalelabel" for="<%=RadioButton2.ClientID%>" class="cb-disable <%=classfemale %>"><span>
        <asp:Localize ID="Localize5" runat="server" Text='<%$ Resources:GResource,female %>'></asp:Localize></span></label>
	</p>
</div>
<DIV class="input string required">
    <p class="field switch">
        <asp:RadioButton ID="RadioButton3" runat="server" Text="未婚" class="hidden" GroupName="Marriage" />
        <asp:RadioButton ID="RadioButton4" runat="server" Text="已婚" class="hidden" GroupName="Marriage" />
		<label for="<%=RadioButton3.ClientID%>" class="cb-enable <%=classunmarried %>"><span>
        <asp:Localize ID="Localize7" runat="server" Text='<%$ Resources:GResource,unmarried %>'></asp:Localize></span></label>
		<label for="<%=RadioButton4.ClientID%>" class="cb-disable <%=classmarried %>"><span>
        <asp:Localize ID="Localize6" runat="server" Text='<%$ Resources:GResource,married %>'></asp:Localize></span></label>
	</p>

</DIV>
</div>

<DIV class="input string required">
<LABEL class="string required" for="signup_context_first_name">
<asp:Localize ID="Localize17" runat="server" Text="手机号码" meta:resourcekey="Localize17Resource1"></asp:Localize></LABEL>
    <asp:TextBox class="string tel required numeric" ID="TextBox4" runat="server" type="tel" maxlength="11" minlength="11" placeholder="手机号"></asp:TextBox>
</DIV>

<div class="input string optional hidden">
<label class="string optional" for="address_context_street2">
<asp:Localize ID="Localize15" runat="server" Text="国籍" meta:resourcekey="Localize15Resource1"></asp:Localize></label>
<asp:TextBox class="string required" ID="TextBox13" runat="server" placeholder="国籍"></asp:TextBox>
</div>


</div>

</div>
<div class='right sixcol last' id='stored_addresses'>
<h3><asp:Localize ID="Localize19" runat="server" Text="工作信息" meta:resourcekey="Localize19Resource1"></asp:Localize></h3>
<div class="simple_form new_address_context">
<div class="input string required">
<label class="string required" for="address_context_recipient_name">
<asp:Localize ID="Localize20" runat="server" Text="公司名称" meta:resourcekey="Localize20Resource1"></asp:Localize></label>
<asp:TextBox class="string required" ID="TextBox7" runat="server" Enabled="False"></asp:TextBox>
</div>
<div class="input string required">
<label class="string required" for="address_context_recipient_name">
BU</label>
<asp:TextBox class="string required" ID="TextBox12" runat="server" Enabled="False"></asp:TextBox>
</div>
<div class="input string required">
<label class="string required" for="address_context_recipient_name">
<asp:Localize ID="Localize10" runat="server" Text="员工号" meta:resourcekey="Localize10Resource1"></asp:Localize></label>
<asp:TextBox class="string required" ID="TextBox8" runat="server" Enabled="False"></asp:TextBox>
</div>
<div class="input string required">
<label class="string required" for="address_context_recipient_name">
<asp:Localize ID="Localize8" runat="server" Text='<%$ Resources:GResource,workemail %>'></asp:Localize></label>
<asp:TextBox class="string required" ID="TextBox9" runat="server" Enabled="False"></asp:TextBox>
</div>
<div class="input string required">
<label class="string required" for="address_context_recipient_name">
<asp:Localize ID="Localize24" runat="server" Text="公司电话" meta:resourcekey="Localize24Resource1"></asp:Localize></label>
<asp:TextBox class="string required" ID="TextBox10" runat="server"></asp:TextBox>
</div>
<div class="input string required">
<label class="string required" for="address_context_recipient_name">
<asp:Localize ID="Localize22" runat="server" Text="公司地址" meta:resourcekey="Localize22Resource1"></asp:Localize></label>
<asp:TextBox class="string required" ID="TextBox11" runat="server"></asp:TextBox>
</div>

<div class='input'>
<label class="string required" for="address_context_recipient_name">&nbsp;</label>
</div>

<div class='buttons'>
<div class='spinner'></div>
<asp:Button ID="Button1" class="button blue_button" runat="server" Text="更新个人信息" onclick="Button1_Click" 
        meta:resourcekey="Button1Resource1" />
</div>

</div>

</div>
</div>

</div>


</div>
</div>

</form>
</div>
<MPuc:footer ID="ucfooter" runat="server"/>

<script type="text/javascript">


    var TextBox3 = document.getElementById("<%=TextBox3.ClientID%>");
    var TextBox6 = document.getElementById("<%=TextBox6.ClientID%>");
    var RadioButton1 = document.getElementById("<%=RadioButton1.ClientID%>");
    var RadioButton2 = document.getElementById("<%=RadioButton2.ClientID%>");
    var aCity = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江 ", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北 ", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏 ", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外 " }

    function cidInfo(sId) {
        var iSum = 0
        var info = ""
        if (!/^\d{17}(\d|X|x)$/.test(sId)) {
            alert('<asp:Localize runat="server" Text="<%$ Resources:GResource,alertneedfullid %>"></asp:Localize>');
            TextBox3.focus();
            return;
        }
        sId = sId.replace(/x$/i, "a");
        if (aCity[parseInt(sId.substr(0, 2))] == null) { alert('Error:<asp:Localize runat="server" Text="<%$ Resources:GResource,alertwrongzone %>"></asp:Localize>'); TextBox3.focus(); return; }
        sBirthday = sId.substr(6, 4) + "-" + Number(sId.substr(10, 2)) + "-" + Number(sId.substr(12, 2));
        var d = new Date(sBirthday.replace(/-/g, "/"))
        if (sBirthday != (d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate())) { alert('Error:<asp:Localize runat="server" Text="<%$ Resources:GResource,alertwrongDOB %>"></asp:Localize>'); TextBox3.focus(); return; }
        for (var i = 17; i >= 0; i--) iSum += (Math.pow(2, i) % 11) * parseInt(sId.charAt(17 - i), 11)
        if (iSum % 11 != 1) { alert('Error:<asp:Localize runat="server" Text="<%$ Resources:GResource,alertwrongIDnum %>"></asp:Localize>'); TextBox3.focus(); return; }

        var d = new Date();
        age = d.getYear() - sId.substr(6, 4);

        var dy = document.getElementById("<%=DropDownListYear.ClientID%>");
        var dm = document.getElementById("<%=DropDownListMonth.ClientID%>")
        var dd = document.getElementById("<%=DropDownListDay.ClientID%>")
        var index;
        for (var j = 0; j < dy.options.length; j++) {
            if (dy.options[j].text == sId.substr(6, 4)) {
                index = j;
                break;
            }
        }
        if (index > 0) {
            dy.options[index].selected = true;
            dm.options[Number(sId.substr(10, 2))].selected = true;
            dd.options[Number(sId.substr(12, 2))].selected = true;
        }
        var ml = document.getElementById("malelabel");
        var fl = document.getElementById("femalelabel");
        if (sId.substr(16, 1) % 2) {
            RadioButton1.checked = true;
            ml.className = "cb-enable  selected";
            fl.className = "cb-disable ";
        }
        else {
            RadioButton2.checked = true;
            ml.className = "cb-enable";
            fl.className = "cb-disable selected";
        }
    }


</script>
</body>
</html>
