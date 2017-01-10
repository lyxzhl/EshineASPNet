using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testAssessmentAnswer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Collections.Specialized.NameValueCollection PostVars;
        PostVars = new System.Collections.Specialized.NameValueCollection();


        PostVars.Add("AQID", this.TextBox1.Text);
      


       // string s = PublicClass.postrequest(System.Configuration.ConfigurationManager.AppSettings["appurl"] + "AssessmentAnswer.aspx", PostVars);
       // this.TextBox2.Text = s;
    }
}