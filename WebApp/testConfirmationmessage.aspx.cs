using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testConfirmationmessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Collections.Specialized.NameValueCollection PostVars;
        PostVars = new System.Collections.Specialized.NameValueCollection();

        PostVars.Add("id", this.TextBox1.Text);
        PostVars.Add("usname", this.TextBox2.Text);
        PostVars.Add("age", this.TextBox3.Text);
        PostVars.Add("dob", this.TextBox4.Text);
        PostVars.Add("iDcard", this.TextBox5.Text);
        PostVars.Add("shoujiahao", this.TextBox6.Text);
        PostVars.Add("Mailbox", this.TextBox7.Text);
        PostVars.Add("hunyin", this.TextBox8.Text);
        PostVars.Add("dizhi", this.TextBox9.Text);
        PostVars.Add("shijian", this.TextBox10.Text);
        PostVars.Add("chengshi", this.TextBox11.Text);
        PostVars.Add("mdian", this.TextBox12.Text);
        PostVars.Add("taoc", this.TextBox13.Text);
        PostVars.Add("jiaxiangbao", this.TextBox14.Text);

       // string s = PublicClass.postrequest(System.Configuration.ConfigurationManager.AppSettings["appurl"] + "Confirmationmessage.aspx", PostVars);
       // this.TextBox15.Text = s;
    }
}