using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
public partial class safecenter : PageBases
{
    Model.tab_customers modelCu = new Model.tab_customers();
    Bll.CustomerBll Cb = new Bll.CustomerBll();
    void init()
    {
        modelCu = Cb.getCustomer(modelCu);
        string s = modelCu.customerIDcard;
        if (s != "" && s.Length > 5)
        {
            this.Label1.Text = (string)GetGlobalResourceObject("GResource", "Bound") + s.Substring(0, 5) + "***********" + s.Substring(s.Length - 2, 2) + "，";
        }

        if (modelCu.customerSafeQ1 != "")
        {
            this.Label2.Text = (string)GetGlobalResourceObject("GResource", "settedquestion");
        }
        else
        {
            this.Label2.Text = (string)GetGlobalResourceObject("GResource", "notsettedques");
        }

        if (modelCu.customerPrivateEmail != "")
        {
            this.Label3.Text = (string)GetGlobalResourceObject("GResource", "Bound") + modelCu.customerPrivateEmail;
        }
        else
        {
            this.Label3.Text = (string)GetGlobalResourceObject("GResource", "notboundset");
        }

        s = modelCu.customerMobile;
        if (s != "" && s.Length > 5)
        {
            this.Label4.Text = (string)GetGlobalResourceObject("GResource", "Bound") + s.Substring(0, 3) + "******" + s.Substring(s.Length - 2, 2);
        }
        else
        {
            this.Label4.Text = (string)GetGlobalResourceObject("GResource", "notboundset");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            this.CheckUser((Hashtable)Application["Online"]);
            
        }
        modelCu.customerID = int.Parse(Session["id"].ToString());
        if (!Page.IsPostBack)
        {
            init();
        }
    }
}