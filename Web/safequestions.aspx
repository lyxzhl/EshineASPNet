<%@ Page Language="C#" AutoEventWireup="true" CodeFile="safequestions.aspx.cs" Inherits="safequestions" %>


<%@ Register TagPrefix="MPuc" TagName="headcontent" Src="UserControl/headcontent.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="mobilenav" Src="UserControl/mobilenav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="desktopnav" Src="UserControl/desktopnav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="footer" Src="UserControl/footer1.ascx"%>
<!DOCTYPE html>
<html>
<head>
<title>EshineAspNet - <asp:Localize ID="Localize1" runat="server" Text='<%$ Resources:GResource,titletext %>' /></title>
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
    <asp:Panel ID="Panel0" runat="server" class='choose_level tile'>
<div class='row'>
<div class='twelvecol'>
<h2><asp:Label ID="Label7" runat="server" Text="您设置的安全提问" meta:resourcekey="Label7Resource1"></asp:Label></h2>
<h4 class='mobile_hidden'></h4>
</div>
</div>
<div class='row'>
<div class='fourcol'></div>
<div class='fourcol'>
<br /><br />
<div class="input string required">
    <asp:Label ID="Label8" runat="server" Text="问题：" meta:resourcekey="Label8Resource1"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="Label" meta:resourcekey="Label4Resource1"></asp:Label>
</div>
<div class="input string required">
<asp:Label ID="Label9" runat="server" Text="　答案：" meta:resourcekey="Label9Resource1"></asp:Label>***
</div>
<br />
<div class="input string required">
<asp:Button ID="Button4" runat="server" Text="返回"  class="button bluedark_button" onclick="Button4_Click"  meta:resourcekey="Button4Resource1"/>
<asp:Button ID="Button0" runat="server" Text="修改"  class="button blue_button" onclick="Button0_Click"  meta:resourcekey="Button0Resource1" />
</div>

</div>
<div class='fourcol last'>
</div>
</div>
    </asp:Panel>

    <asp:Panel ID="Panel1" runat="server" class='choose_level tile' Visible="False">
<div class='row'>
<div class='twelvecol'>
<h2><asp:Label ID="Label14" runat="server" Text="安全提问设置" meta:resourcekey="Label14Resource1"></asp:Label></h2>
<h4></h4>
</div>
</div>
<div class='row sizes'>
<div class='fourcol'></div>
<div class='fourcol'>
<br /><br />
<div class="input string required">
    <asp:Label ID="Label15" runat="server" Text="问题："  meta:resourcekey="Label15Resource1"></asp:Label>
    <select id="s1" name="s1"  class="select required customSelect"></select>
</div>
<div class="input string required">
<asp:Label ID="Label16" runat="server" Text="答案：" meta:resourcekey="Label16Resource1"></asp:Label>
<asp:TextBox ID="TextBox1" runat="server" class="string email required" placeholder='<%$ Resources:GResource,alertneedanswer %>'
        meta:resourcekey="TextBox1Resource1"></asp:TextBox>
</div>
<br />
<div class="input string required">
<asp:Button ID="Button5" runat="server" Text="返回"  class="button bluedark_button" onclick="Button4_Click"  meta:resourcekey="Button4Resource1"/>
<asp:Button ID="Button2" runat="server" Text="设置密保"   class="button blue_button" onclick="Button2_Click" 
        OnClientClick="return check1();" meta:resourcekey="Button2Resource1"/>
</div>
</div>
<div class='fourcol last'>
</div>
</div>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" class='choose_level tile' Visible="False">
<div class='row'>
<div class='twelvecol'>
<h2><asp:Label ID="Label21" runat="server" Text="验证安全提问" meta:resourcekey="Label21Resource1"></asp:Label></h2>
<h4></h4>
</div>
</div>
<div class='row sizes'>
<div class='fourcol'></div>
<div class='fourcol'>
<br /><br />
<div class="input string required">
    <asp:Label ID="Label22" runat="server" Text="问题：" meta:resourcekey="Label22Resource1"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Label" meta:resourcekey="Label1Resource1"></asp:Label>
</div>
<div class="input string required">
<asp:TextBox ID="TextBox4" runat="server" class="string email required" placeholder="请输入答案"
        meta:resourcekey="TextBox4Resource1"></asp:TextBox>
</div>

<br />
<div class="input string required">
<asp:Button ID="Button1" runat="server" Text="返回"  class="button bluedark_button" onclick="Button4_Click"  meta:resourcekey="Button4Resource1"/>
<asp:Button ID="Button3" runat="server" Text="确认提交" class="button blue_button" onclick="Button3_Click" OnClientClick="return check2();" meta:resourcekey="Button3Resource1"/>
</div>
</div>
<div class='fourcol last'>
</div>
</div>
    </asp:Panel>

<asp:Panel ID="Panel3" runat="server" class='choose_level tile' Visible="False">
<div class='row'>
<div class='twelvecol'>
<h1><asp:Label ID="Label29" runat="server" Text="确认" meta:resourcekey="Label29Resource1"></asp:Label></h1>
<h4></h4>
</div>
</div>
<div class='row sizes'>
<div class='fourcol'></div>
<div class='fourcol'>

<div class="input string required">
<br /><br />
    <asp:Label ID="Label28" runat="server" Text="您的安全问题已经成功设置，请牢记您的新密保!" meta:resourcekey="Label28Resource1"></asp:Label>
</div>
<div class="input string required">
<br />
<asp:Button ID="Button6" runat="server" Text="返回"  class="button bluedark_button" onclick="Button4_Click"  meta:resourcekey="Button4Resource1"/>
<asp:HyperLink ID="HyperLink1" runat="server" class="button blue_button" NavigateUrl="~/reserveexam.aspx" Text="预约体检"></asp:HyperLink>
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
<script type="text/javascript">
    var qObj = {
        elmt: 'select',
        tip: '<asp:Localize runat="server" Text="<%$ Resources:GResource,select %>" />',
        tVal: '',
        cur: [],
        arr: {
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq1 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq1 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq2 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq2 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq3 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq3 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq4 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq4 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq5 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq5 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq6 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq6 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq7 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq7 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq8 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq8 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq9 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq9 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq10 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq10 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq11 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq11 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq12 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq12 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq13 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq13 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq14 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq14 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq15 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq15 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq16 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq16 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq17 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq17 %>' />",
            "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq18 %>' />": "<asp:Localize runat='server' Text='<%$ Resources:GResource,safeq18 %>' />"
        }
    }
    $(function () {
        //获取所有的select选框 
        var elements = $(qObj.elmt);
        //这一步只是初始化操作，将所有问题写入select选框 
        elements.each(function (i) {
            var html = '<option value="' + qObj.tVal + '">' + qObj.tip + '</option>';
            for (var q in qObj.arr) {
                html += '<option value="' + q + '">' + qObj.arr[q] + '</option>';
            }
            $(this).html(html);
        });
        //select选框添加监听事件 
        elements.change(function () {
            var 
cValue = {}, //用于记录当前被选中的问题 
elmts = elements,
cIndex = elmts.index($(this)); //当前select选框索引值 
            //遍历所有select选框，记录当前每个选框的选择 
            elmts.each(function (i) {
                qObj.cur[i] = $(this).val();
            });
            //记录当前已被选中的问题，实现互斥锁 
            for (var i in qObj.cur) {
                cValue[qObj.cur[i]] = 1;
            }
            //遍历所有select选框，重置所有问题 
            elmts.each(function (i) {
                //跳过当前的select选框，因为该内容无需校正 
                if (cIndex == i) return;
                var html = '<option value="' + qObj.tVal + '">' + qObj.tip + '</option>';
                for (var q in qObj.arr) {
                    //如果是互斥内容，且不属于这个选框则跳过（重点） 
                    if (cValue[q] && q != qObj.cur[i]) continue;
                    html += '<option value="' + q + '"' + (q == qObj.cur[i] ? ' selected="selected"' : '') + '>' + qObj.arr[q] + '</option>';
                }
                $(this).html(html);
            });
        });
    }) 

</script>
<script>
    function check1() {
        var q1 = document.getElementById("s1").value;
        if (q1 == "" ) {
            alert('<asp:Localize runat="server" Text="<%$ Resources:GResource,alertneedquestion %>" />');
            return false;
        }
        else {
            var t1 = document.getElementById("<%=TextBox1.ClientID%>").value;
            if (t1 == "" ) {
                alert('<asp:Localize runat="server" Text="<%$ Resources:GResource,alertneedanswer %>" />');
                return false;
            }
            else
                return true;
        }

    }
    function check2() {
        var t1 = document.getElementById("<%=TextBox4.ClientID%>").value;
        if (t1 == "" ) {
            alert('<asp:Localize runat="server" Text="<%$ Resources:GResource,alertneedanswer %>" />');
            return false;
        }
        else
            return true;
    }
</script>
</body>
</html>


