using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testcustomergetstart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Collections.Specialized.NameValueCollection PostVars;
        PostVars = new System.Collections.Specialized.NameValueCollection();

        PostVars.Add("nickname", this.TextBox1.Text);
        PostVars.Add("gender", this.TextBox7.Text);
        PostVars.Add("mobile", this.TextBox6.Text);
        PostVars.Add("password", this.TextBox10.Text);
        PostVars.Add("iDcard", this.TextBox2.Text);
        PostVars.Add("DOB", this.TextBox9.Text);
        PostVars.Add("hunyin", this.TextBox8.Text);

        string s = PublicClass.postrequest(System.Configuration.ConfigurationManager.AppSettings["appurl"] + "customergetstart.aspx", PostVars);
        this.TextBox3.Text = s;
    }
}