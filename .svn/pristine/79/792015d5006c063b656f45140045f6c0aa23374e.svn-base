using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class updatecart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["matchProCode"] == null)
        {
            return;
        }
        if (Request.Form["nums"] == null)
        {
            return;
        }


        int index = Convert.ToInt32( Request.Form["matchProCode"]);
        DataTable dt = (DataTable)Session["cartitems"];
        dt.Rows[index-1][1] = Request.Form["nums"];

        Session["cartitems"] = dt;
    }
}