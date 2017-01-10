using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TermsOfService : PageBases
{
    Bll.newsBll nb = new Bll.newsBll();
    public string maincontent;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["language"]==null)
            {
                Session["language"] = "zh-cn";
            }
            maincontent = nb.getNews("静态文本", "服务条款", Session["language"].ToString());
            if (Session["firstlogin"] != null && Session["firstlogin"] == "1")
            {
                this.Panel1.Visible = true;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Model.tab_customers modelCu = new Model.tab_customers();
        Bll.CustomerBll Cb = new Bll.CustomerBll();
        modelCu.customerID = int.Parse(Session["id"].ToString());
        modelCu = Cb.getCustomer(modelCu);
        modelCu.customerMsg = "agreed";
        Cb.update(modelCu);
        //Bll.messageBll mb = new Bll.messageBll();
        //mb.sendmsg(1003, modelCu);
        //Session["firstlogin"] = "";
        Response.Redirect("reserveexam.aspx");
    }
}