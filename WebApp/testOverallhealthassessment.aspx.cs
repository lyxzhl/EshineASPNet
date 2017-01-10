using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testOverallhealthassessment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Collections.Specialized.NameValueCollection PostVars;
        PostVars = new System.Collections.Specialized.NameValueCollection();


        PostVars.Add("customerID", this.TextBox1.Text);
        PostVars.Add("CType", this.TextBox2.Text);
        PostVars.Add("customerCode", this.TextBox3.Text);
        PostVars.Add("customerGender", this.TextBox4.Text);
        PostVars.Add("customerDOB", this.TextBox5.Text);
        PostVars.Add("QTShortName", this.TextBox6.Text);
        PostVars.Add("ARDetail", this.TextBox7.Text);
        PostVars.Add("Marriage", this.TextBox7.Text);


        string s = PublicClass.postrequest(System.Configuration.ConfigurationManager.AppSettings["appurl"] + "Overallhealthassessment.aspx", PostVars);
        this.TextBox8.Text = s;
    }
}