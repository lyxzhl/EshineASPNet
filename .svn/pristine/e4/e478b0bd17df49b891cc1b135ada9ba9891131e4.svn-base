using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class textupdatepersonaldetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Collections.Specialized.NameValueCollection PostVars = new System.Collections.Specialized.NameValueCollection();
        PostVars.Add("type", "1");

        PostVars.Add("id", this.TextBox1.Text);
        PostVars.Add("name", this.TextBox2.Text);
        PostVars.Add("email", this.TextBox3.Text);
        PostVars.Add("customerMobile", this.TextBox4.Text);
        PostVars.Add("customerGender", this.TextBox5.Text);
        PostVars.Add("customerMarriageStatus", this.TextBox6.Text);
        PostVars.Add("DOB", this.TextBox7.Text);
        PostVars.Add("IDcard", this.TextBox8.Text);
        PostVars.Add("customerCompanyProvince", this.TextBox9.Text);
        PostVars.Add("customerCompanyCity", this.TextBox11.Text);





        string s = PublicClass.postrequest(System.Configuration.ConfigurationManager.AppSettings["appurl"] + "updatepersonaldetail.aspx", PostVars);
        this.TextBox10.Text = s;
    }
}