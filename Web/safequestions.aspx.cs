using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
public partial class safequestions : PageBases
{
    Model.tab_customers modelCu = new Model.tab_customers();
    Bll.CustomerBll Cb = new Bll.CustomerBll();
    void init()
    {
        modelCu = Cb.getCustomer(modelCu);
        if (modelCu.customerSafeQ1 != "")
        {
            this.Label4.Text = modelCu.customerSafeQ1;
        }
        else
        {
            this.Panel0.Visible = false;
            this.Panel1.Visible = true;
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Label1.Text = Request.Form["s1"];
        this.Panel1.Visible = false;
        this.Panel2.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text == this.TextBox4.Text)
        {
            modelCu = Cb.getCustomer(modelCu);
            modelCu.customerSafeQ1 = this.Label1.Text;
            modelCu.customerSafeA1 = this.TextBox1.Text;
            Cb.update(modelCu);
            this.Panel2.Visible = false;
            this.Panel3.Visible = true;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + (string)GetGlobalResourceObject("GResource", "twopassnotmatch") + "');</script>");
            //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('两次输入的安全密码答案不一致，请重试一次。');<script>");
            this.Panel1.Visible = true;
            this.Panel2.Visible = false;
            this.TextBox1.Text = "";
            this.TextBox4.Text = "";
        }
    }
    protected void Button0_Click(object sender, EventArgs e)
    {
        this.Panel0.Visible = false;
        this.Panel1.Visible = true;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("safecenter.aspx");

    }
}