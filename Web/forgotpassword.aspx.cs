using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forgotpassword : PageBases
{
    Model.tab_customers modelCu = new Model.tab_customers();
    Bll.CustomerBll Cb = new Bll.CustomerBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["f"] != null && Request.QueryString["f"].ToString() == "fp")
        {
            this.Button12.Visible = false;
            this.Label4.Text = (string)GetGlobalResourceObject("GResource", "fetchpassword");
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        modelCu.customerPrivateEmail = this.TextBox1.Text;
        modelCu = Cb.getCustomer(modelCu);
        if (modelCu != null)
        {
            this.Label1.Text = modelCu.customerSafeQ1;
            this.Panel3.Visible = false;
            this.Panel4.Visible = true;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + (string)GetGlobalResourceObject("GResource", "alertnoemailrecord") + "');</script>");
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        modelCu.customerPrivateEmail = this.TextBox1.Text;
        modelCu = Cb.getCustomer(modelCu);
        if (modelCu.customerSafeA1 == this.TextBox4.Text)
        {
            Response.Redirect("fetchpassword.aspx?sc=20130828&ne=" + this.TextBox1.Text);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + (string)GetGlobalResourceObject("GResource", "alertwronganswer") + "');</script>");

        }




    }


    protected void Button12_Click(object sender, EventArgs e)
    {
        this.Panel1.Visible = false;
        this.Panel3.Visible = true;
    }

}