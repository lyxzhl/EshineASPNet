using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testupdatepassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Collections.Specialized.NameValueCollection PostVars = new System.Collections.Specialized.NameValueCollection();
        PostVars.Add("type", "2");

        PostVars.Add("id",this.TextBox1.Text);
        PostVars.Add("password",this.TextBox2.Text);
        PostVars.Add("password_old",this.TextBox3.Text);


        string s = PublicClass.postrequest(System.Configuration.ConfigurationManager.AppSettings["appurl"] + "updatepersonaldetail.aspx", PostVars);
        this.TextBox4.Text = s;
    }
}