using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
public partial class index : PageBases
{
    Bll.companyBll comb = new Bll.companyBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["htai"] = "";
            if (Request.QueryString["cc"] != null && Request.QueryString["cc"] != "")
            {
                Session["cc"] = Request.QueryString["cc"];
            }
       
           
            this.CheckUser((Hashtable)Application["Online"]);
            
        }
    }
}