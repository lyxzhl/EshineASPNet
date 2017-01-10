using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
public partial class safemobile : PageBases
{
    Model.tab_customers modelCu = new Model.tab_customers();

    Bll.CustomerBll Cb = new Bll.CustomerBll();
    PublicClass pc = new PublicClass();
    void init()
    {
        modelCu = Cb.getCustomer(modelCu);
        string s = modelCu.customerMobile;
        if (s != "" && s.Length > 5)
        {
            this.Label4.Text = s.Substring(0, 3) + "******" + s.Substring(s.Length - 2, 2);
            this.Panel1.Visible = true;
            this.Panel2.Visible = false;
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.CheckUser((Hashtable)Application["Online"]);
        }
        modelCu.customerID = int.Parse(Session["id"].ToString());
        if (!Page.IsPostBack)
        {
            init();
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("safecenter.aspx");

    }
    protected void Button0_Click(object sender, EventArgs e)
    {
        this.Panel1.Visible = false;
        this.Panel2.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        modelCu = Cb.getCustomer(modelCu);
        if (false && modelCu.customerMobile != this.TextBox1.Text)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + (string)GetGlobalResourceObject("GResource", "oldmobilewrong") + "');</script>");
            this.TextBox1.Focus();
            return;
        }

        modelCu.customerMobile = this.TextBox4.Text;
        Cb.update(modelCu);
        this.Panel2.Visible = false;
        this.Label1.Text = this.TextBox4.Text;
        this.Panel3.Visible = true;

        Bll.messageBll mb = new Bll.messageBll();
        mb.sendmsg(1008, modelCu);
    }
}