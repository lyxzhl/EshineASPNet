using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class processroute : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bll.companyBll cb = new Bll.companyBll();
        if (!IsPostBack)
        {
            string cc = "_undifined";
            if (Page.RouteData.Values["cc"] != null && Page.RouteData.Values["cc"].ToString() != "index.aspx" && Page.RouteData.Values["cc"].ToString() != "login2.aspx")
            {
                cc = Page.RouteData.Values["cc"].ToString();
                DataTable dt = cb.Select("select * from tab_company where CompanyAbbreviation='" + cc + "'");
                if (dt.Rows.Count > 0)
                {
                    Session["cc"] = cc;
                    
                }
            }
        }
        Response.Redirect(@"~\login2.aspx");
    }
}