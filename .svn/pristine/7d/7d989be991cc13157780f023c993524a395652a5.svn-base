using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testtijiajiashu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Collections.Specialized.NameValueCollection PostVars;
        PostVars = new System.Collections.Specialized.NameValueCollection();


        PostVars.Add("relativeCustomer", this.TextBox1.Text);
        PostVars.Add("relativeName", this.TextBox2.Text);
        PostVars.Add("relativeIDcard", this.TextBox3.Text);
        PostVars.Add("relativeMobile", this.TextBox4.Text);
        PostVars.Add("relativeDOB", this.TextBox5.Text);
        PostVars.Add("relativeGender", this.TextBox6.Text);
        PostVars.Add("MarriageStatus", this.TextBox7.Text);
        PostVars.Add("Relationship", this.TextBox9.Text);


        string s = PublicClass.postrequest(System.Configuration.ConfigurationManager.AppSettings["appurl"] + "tijiajiashu.aspx", PostVars);
        this.TextBox8.Text = s;
    }
}