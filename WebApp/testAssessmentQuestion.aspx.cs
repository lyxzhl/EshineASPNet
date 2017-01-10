using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class texttijianwj : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   

    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Collections.Specialized.NameValueCollection PostVars;
        PostVars = new System.Collections.Specialized.NameValueCollection();


        PostVars.Add("QTShortName", this.TextBox1.Text);
        PostVars.Add("AQGender", this.TextBox3.Text);
        PostVars.Add("Age", this.TextBox4.Text);
        PostVars.Add("Marriage", this.TextBox5.Text);


        string s = PublicClass.postrequest(System.Configuration.ConfigurationManager.AppSettings["appurl"] + "AssessmentQuestion.aspx", PostVars);
        this.TextBox2.Text = s;
    }
}