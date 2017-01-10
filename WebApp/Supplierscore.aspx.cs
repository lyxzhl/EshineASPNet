using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Supplierscore : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Model.tab_suppliers supp = new Model.tab_suppliers();

    }
}