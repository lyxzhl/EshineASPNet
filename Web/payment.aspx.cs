using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Alipay;

public partial class payment : System.Web.UI.Page
{
    Bll.OrdersBll ob = new Bll.OrdersBll();
    Model.tab_orders orders = new Model.tab_orders();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["oid"] != null && Request.QueryString["oid"].ToString() != "")
        {
            ViewState["orderid"] = Request.QueryString["oid"];
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        string paytype = Request.Form["paytype"].ToString();
        orders.orderID = Convert.ToInt32(ViewState["orderid"]);
        orders = ob.getorders(orders);

        if (orders.orderStatus == "待付款")
        {
            goalipay(orders.orderID.ToString(), orders.examBill.ToString(), paytype);
        }

    }



    public void goalipay(string out_trade_no, string total_fee, string paytype)
    {
        //支付类型
        string payment_type = "1";
        string notify_url = System.Configuration.ConfigurationManager.AppSettings["notify_url"];
        string return_url = System.Configuration.ConfigurationManager.AppSettings["return_url"];
        string seller_email = "pay@eshinelee.com";


        //订单名称
        string subject = (string)GetGlobalResourceObject("GResource", "mpselection");
        //订单描述
        string body = "";
        //商品展示地址
        string show_url = "";

        //防钓鱼时间戳
        string anti_phishing_key = Submit.Query_timestamp();
        //若要使用请调用类文件submit中的query_timestamp函数

        //客户端的IP地址
        string exter_invoke_ip = "";
        //非局域网的外网IP地址，如：221.0.0.1



        //把请求参数打包成数组
        SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
        sParaTemp.Add("partner", Config.Partner);
        sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
        sParaTemp.Add("service", "create_direct_pay_by_user");
        sParaTemp.Add("payment_type", payment_type);
        sParaTemp.Add("notify_url", notify_url);
        sParaTemp.Add("return_url", return_url);
        sParaTemp.Add("seller_email", seller_email);
        sParaTemp.Add("out_trade_no", out_trade_no);
        sParaTemp.Add("subject", subject);
        sParaTemp.Add("total_fee", total_fee);
        sParaTemp.Add("body", body);

        if (paytype != "alipay")
        {
            sParaTemp.Add("paymethod", "bankPay");
            sParaTemp.Add("defaultbank", paytype.Substring(7, paytype.Length - 7));
        }

        sParaTemp.Add("show_url", show_url);
        sParaTemp.Add("anti_phishing_key", anti_phishing_key);
        sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);

        //建立请求
        string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
        Response.Write(sHtmlText);
    }
}