using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class texttijiandaoh : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Collections.Specialized.NameValueCollection PostVars;
        PostVars = new System.Collections.Specialized.NameValueCollection();

        PostVars.Add("Tijian", this.TextBox3.Text);
           

        string s = PublicClass.postrequest(System.Configuration.ConfigurationManager.AppSettings["appurl"] + "QuestionType.aspx", PostVars);
        this.TextBox2.Text = s;
    }
}