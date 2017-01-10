<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payment.aspx.cs" Inherits="payment" %>

<%@ Register TagPrefix="MPuc" TagName="headcontent" Src="UserControl/headcontent.ascx" %>
<%@ Register TagPrefix="MPuc" TagName="mobilenav" Src="UserControl/mobilenav.ascx" %>
<%@ Register TagPrefix="MPuc" TagName="desktopnav" Src="UserControl/desktopnav.ascx" %>
<%@ Register TagPrefix="MPuc" TagName="footer" Src="UserControl/footer1.ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/payment.css" media="screen" rel="stylesheet" type="text/css" />
    <MPuc:headcontent runat="server" ID="Unnamed1" />
    <script src="JS/mp.js" type="text/javascript"></script>
</head>
<body class="signups">
    <form id="form1" runat="server">
    <MPuc:mobilenav ID="Mobilenav1" runat="server" />
    <div class='wrapper' data-behavior='Navigation'>
        <MPuc:desktopnav ID="Desktopnav1" runat="server" />
       
            <div class='container'>
                <div class='row'>
                    <div class='twelvecol'>
                        <div class='tile'>
                            <h1>选择付款方式</h1>
                            <div>
                                <div class="blk-item paytype" id="J-pay-types" style="display: block;">
                                    <div class="paytype-list" id="order-check-typelist" data-uix="collapse"
                                        data-params="{group:'bank-area', trigger:'bank-type', open:'bank-area--open'}">
                                        <div class="bank-area bank-area--open cf">
                                            <h3 class="bank-type"><i class="bank-type__icon"></i>网上银行支付<span class="bank-type__hint">（支持储蓄卡和信用卡）</span></h3>
                                            <div class="bank-list" style="display: none">
                                                <input name="paytype" class="radio" id="bank-type-CMB"
                                                    type="radio" value="alipay-CMB">
                                                <label title="招商银行"
                                                    class="bank bank--cmb" for="bank-type-CMB">
                                                    招商银行</label><a class="choose-other-bank"
                                                        id="J-choose-other-bank" href="">其它支付方式<i
                                                            class="tri"></i></a>
                                            </div>
                                            <ul class="bank-list" style="display: block;">
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="Radio1" type="radio" value="alipay-CMB">
                                                    <label title="招商银行" class="bank bank--cmb" for="bank-type-CMB">招商银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-ICBCB2C" type="radio" value="alipay-ICBCB2C">
                                                    <label title="中国工商银行" class="bank bank--icbc" for="bank-type-ICBCB2C">中国工商银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-CCB" type="radio" value="alipay-CCB">
                                                    <label title="中国建设银行" class="bank bank--ccb" for="bank-type-CCB">中国建设银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-ABC" type="radio" value="alipay-ABC">
                                                    <label title="中国农业银行" class="bank bank--abc" for="bank-type-ABC">中国农业银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-1020" type="radio" value="alipay-COMM">
                                                    <label title="交通银行" class="bank bank--boc" for="bank-type-1020">交通银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-BOCB2C" type="radio" value="alipay-BOCB2C">
                                                    <label title="中国银行" class="bank bank--bofc" for="bank-type-BOCB2C">中国银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-CIB" type="radio" value="alipay-CIB">
                                                    <label title="兴业银行" class="bank bank--cib" for="bank-type-CIB">兴业银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-CEBBANK" type="radio" value="alipay-CEBBANK">
                                                    <label title="光大银行" class="bank bank--cebb" for="bank-type-CEBBANK">光大银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-SPDB" type="radio" value="alipay-SPDB">
                                                    <label title="上海浦东发展银行" class="bank bank--spdb" for="bank-type-SPDB">上海浦东发展银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-GDB" type="radio" value="alipay-GDB">
                                                    <label title="广东发展银行" class="bank bank--gdb" for="bank-type-GDB">广东发展银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-CITIC" type="radio" value="alipay-CITIC">
                                                    <label title="中信银行" class="bank bank--zxyh" for="bank-type-CITIC">中信银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-CMBC" type="radio" value="alipay-CMBC">
                                                    <label title="中国民生银行" class="bank bank--cmbc" for="bank-type-CMBC">中国民生银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-SPABANK" type="radio" value="alipay-SPABANK">
                                                    <label title="平安银行" class="bank bank--pingan" for="bank-type-SPABANK">平安银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-BJBANK" type="radio" value="alipay-BJBANK">
                                                    <label title="北京银行" class="bank bank--bob" for="bank-type-BJBANK">北京银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-BJRCB" type="radio" value="alipay-BJRCB">
                                                    <label title="北京农商银行" class="bank bank--bjrcb" for="bank-type-BJRCB">北京农商银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-PSBC-DEBIT" type="radio" value="alipay-POSTGC">
                                                    <label title="中国邮政储蓄银行" class="bank bank--pspc" for="bank-type-PSBC-DEBIT">中国邮政储蓄银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-SHRCB" type="radio" value="alipay-SHRCB">
                                                    <label title="上海农商银行" class="bank bank--shrcb" for="bank-type-SHRCB">上海农商银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="bank-type-HZCBB2C" type="radio" value="alipay-HZCBB2C">
                                                    <label title="杭州银行" class="bank bank--hzcb" for="bank-type-HZCBB2C">杭州银行</label>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="bank-area" style="display: block;">
                                            <h3 class="bank-type"><i class="bank-type__icon"></i>支付宝</h3>
                                            <ul class="bank-list bank-list--xpay" style="display: block">
                                                <li class="item left">
                                                    <input name="paytype" class="radio" id="check-alipay" type="radio" value="alipay">
                                                    <label class="bank bank--alipay" for="check-alipay">支付宝</label>
                                                </li>
                                                <li class="item" style="display: none">
                                                    <input name="paytype" class="radio" id="check-tenpay" type="radio" value="tenpay">
                                                    <label class="bank bank--tenpay" for="check-tenpay">财付通</label>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="bank-area" style="display: none;">
                                            <h3 class="bank-type"><i class="bank-type__icon"></i>银联在线支付<span class="bank-type__hint">（支持地方银行，无需开通网银）</span></h3>
                                            <ul class="bank-list bank-list--upop">
                                                <li class="item left">
                                                    <input name="paytype" class="radio" id="check-upopdebit"
                                                        type="radio" value="upopdebit">
                                                    <label title="银联储蓄卡支付"
                                                        class="bank bank--upopdebit" for="check-upopdebit">
                                                        银联储蓄卡支付</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="check-upopcredit"
                                                        type="radio" value="upopcredit">
                                                    <label title="银联信用卡支付"
                                                        class="bank bank--upopcredit" for="check-upopcredit">
                                                        银联信用卡支付</label>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="bank-area" style="display: none;">
                                            <h3 class="bank-type"><i class="bank-type__icon"></i>快捷支付<span class="bank-type__hint">（支持信用卡付款，最高额度500，无需开通网银）</span></h3>
                                            <ul class="bank-list">
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="alipayquick-bank-type-ICBC"
                                                        type="radio" value="alipayquick-ICBC">
                                                    <label title="中国工商银行"
                                                        class="bank bank--icbc" for="alipayquick-bank-type-ICBC">
                                                        中国工商银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="alipayquick-bank-type-CCB"
                                                        type="radio" value="alipayquick-CCB">
                                                    <label title="中国建设银行"
                                                        class="bank bank--ccb" for="alipayquick-bank-type-CCB">
                                                        中国建设银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="alipayquick-bank-type-ABC"
                                                        type="radio" value="alipayquick-ABC">
                                                    <label title="中国农业银行"
                                                        class="bank bank--abc" for="alipayquick-bank-type-ABC">
                                                        中国农业银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="alipayquick-bank-type-CMB"
                                                        type="radio" value="alipayquick-CMB">
                                                    <label title="招商银行"
                                                        class="bank bank--cmb" for="alipayquick-bank-type-CMB">
                                                        招商银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="alipayquick-bank-type-SPABANK"
                                                        type="radio" value="alipayquick-SPABANK">
                                                    <label
                                                        title="平安银行" class="bank bank--pingan"
                                                        for="alipayquick-bank-type-SPABANK">
                                                        平安银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="alipayquick-bank-type-BOC"
                                                        type="radio" value="alipayquick-BOC">
                                                    <label title="中国银行"
                                                        class="bank bank--bofc" for="alipayquick-bank-type-BOC">
                                                        中国银行</label>
                                                </li>
                                                <li class="item">
                                                    <input name="paytype" class="radio" id="alipayquick-bank-type-CEB"
                                                        type="radio" value="alipayquick-CEB">
                                                    <label title="光大银行"
                                                        class="bank bank--cebb" for="alipayquick-bank-type-CEB">
                                                        光大银行</label>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="fixed_button hidden" style="z-index: 99999" id="paybuttondiv">
                <asp:Button class="button blue_button continue continue_form" ID="Button1"
                    runat="server" Text='去付款' OnClick_disable="Button1_Click" />

                <p class="terms"></p>
            </div>
        

    </div>
    <MPuc:footer ID="ucfooter" runat="server" />
        </form>
</body>
</html>
