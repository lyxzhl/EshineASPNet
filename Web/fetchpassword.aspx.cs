using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;//StringBuilder相关的命名空间
using System.IO;//文件流相关的命名空间
public partial class fetchpassword : PageBases
{
    Model.tab_customers modelCu = new Model.tab_customers();
    Bll.CustomerBll Cb = new Bll.CustomerBll();
    PublicClass pc = new PublicClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["sc"] != null && Request.QueryString["sc"] == "20130828" && Request.QueryString["ne"] != null)
            {
                this.TextBox1.Text = Request.QueryString["ne"];
                modelCu.customerPrivateEmail = this.TextBox1.Text;
                processsend();
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        this.ImageButton1.ImageUrl = "~/Admin/login/CheckCode.aspx";
    }

    private void SendEmail(string strName, string strpw, string strid, string coname)
    {
        PublicClass pc = new PublicClass();
        string Subject = "Medi-Plus登录密码";

        //读取HTML模板，即发送的页面
        string strPath = System.Web.HttpContext.Current.Server.MapPath("~/email_fetchpw.htm");
        //读取文件，“System.Text.Encoding.Default”可以解决中文乱码问题
        StreamReader sr = new StreamReader(strPath, System.Text.Encoding.Default);

        StringBuilder body = new StringBuilder();
        body.Append(sr.ReadToEnd());
        sr.Close();//关闭文件流
        body = body.Replace("<%customname%>", strName);//替换指定内容，通常为需要变动的内容
        body = body.Replace("<%password%>", strpw);
        body = body.Replace("<%customid%>", strid);
        body = body.Replace("<%coname%>", coname);
        body = body.Replace("<%date%>", DateTime.Now.ToShortDateString());

        //pc.SendSMTPEMail("smtp.sina.com", "lyx_zhl@sina.com", "lyx_password", this.TextBox1.Text, "标题", "内容");
        pc.SendsettingEMail(this.TextBox1.Text, Subject, body.ToString().Trim());
    }
    void processsend()
    {
        string pw = pc.MakePassword(6);
        modelCu = Cb.getCustomer(modelCu);
        modelCu.customerPwd = pc.md5(pw);
        Cb.update(modelCu);

        if (Request.QueryString["sc"] != null)
        {
            pc.addlog(this.TextBox1.Text, pw, "", "", "用户邮件获取密码", "安全问题");
        }
        else
        {
            pc.addlog(this.TextBox1.Text, pw, "", "", "用户邮件获取密码", "");
        }

        try
        {

            SendEmail(modelCu.customerName, pw, modelCu.customerCode,modelCu.customerCompany);

            this.Label1.Text = this.TextBox1.Text;
            this.Panel1.Visible = true;
            this.Panel2.Visible = false;
            Session["cc"] = modelCu.customerCompany;
            //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('登陆成功')</script>");
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('发送邮件出错!!" + ex.Message + "')</script>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text == "")
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('" + (string)GetGlobalResourceObject("GResource", "alertneedemail") + "')</script>");
            this.TextBox1.Focus();
            return;
        }
        else if (this.TextBox2.Text == "")
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('" + (string)GetGlobalResourceObject("GResource", "alertneedvericode") + "')</script>");
            this.TextBox2.Focus();
            return;
        }
        if (this.TextBox2.Text.ToLower() == Request.Cookies["CheckCode"].Value.ToLower())
        {

            //modelCu.customerEmail = this.TextBox1.Text;
            //DataTable dt = Cb.CustomerSelect(modelCu);
            DataTable dt = Cb.CustomerSelect("select * from tab_customers where customerEmail='" + this.TextBox1.Text + "'");


            if (dt.Rows.Count > 0)
            {
                modelCu.customerEmail = this.TextBox1.Text;
                processsend();
                
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('" + (string)GetGlobalResourceObject("GResource", "alertnoemailrecord") + "')</script>");
            }

        }
        else
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('" + (string)GetGlobalResourceObject("GResource", "alertwrongvericode") + "')</script>");
            this.TextBox2.Text = "";
            this.TextBox2.Focus();
            return;
        }
    }
}