using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Collections;
public partial class safeemail : PageBases
{
    Model.tab_customers modelCu = new Model.tab_customers();
    Bll.CustomerBll Cb = new Bll.CustomerBll();
    PublicClass pc = new PublicClass();
    void init()
    {
        modelCu = Cb.getCustomer(modelCu);
        if (modelCu.customerPrivateEmail != "")
        {
            this.Panel1.Visible = true;
            this.Panel2.Visible = false;
            this.Label4.Text = modelCu.customerPrivateEmail;
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
        Random random = new Random();
        string checkCode = "";
        for (int i = 0; i <= 4; i++)
        {
            int num = random.Next(1, 10);
            checkCode += num.ToString();
        }

        modelCu = Cb.getCustomer(modelCu);
        modelCu.customerValidateCode = pc.md5(checkCode);
        Cb.update(modelCu);

        string newemaillink = "http://www.eshinelee.com/confirmemail.aspx?id=" + modelCu.customerID + "&vc=" + modelCu.customerValidateCode + "&ne=" + this.TextBox4.Text;
        try
        {

            SendEmail(modelCu.customerName, newemaillink);

            this.Panel2.Visible = false;
            this.Label1.Text = this.TextBox4.Text;
            this.Panel3.Visible = true;
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('" + (string)GetGlobalResourceObject("GResource", "alertsendemailerror") + ex.Message + "')</script>");
            return;
        }

    }

    private void SendEmail(string strName, string strne)
    {
        string Subject = "修改邮箱";

        string strPath = System.Web.HttpContext.Current.Server.MapPath("~/email_changeemail.htm");
        StreamReader sr = new StreamReader(strPath, System.Text.Encoding.Default);
        StringBuilder body = new StringBuilder();
        body.Append(sr.ReadToEnd());
        sr.Close();

        body = body.Replace("<%customname%>", strName);
        body = body.Replace("<%newemaillink%>", strne);
        body = body.Replace("<%date%>", DateTime.Now.ToShortDateString());

        pc.SendsettingEMail(this.TextBox4.Text, Subject, body.ToString().Trim());
    }
}