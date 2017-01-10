using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Application["Online"] != null)
        {
            Hashtable h = (Hashtable)Application["Online"];
            if (h[Session.SessionID] != null)
                h.Remove(Session.SessionID);
            Application["Online"] = h;
        }

        Session["id"] = null;
        Session["cus"] = null;
    }
}