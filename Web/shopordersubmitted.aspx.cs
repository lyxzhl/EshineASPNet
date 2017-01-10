using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shopordersubmitted : PageBases
{
    Bll.OrdersBll ob = new Bll.OrdersBll();
    Model.tab_orders order = new Model.tab_orders();
    Bll.CustomerBll Cb = new Bll.CustomerBll();
    Model.tab_customers modelCu = new Model.tab_customers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["oid"] != null && Request.QueryString["price"] != null)
        {
            ViewState["shoporderid"] = Request.QueryString["oid"];
            ViewState["shoporderprice"] = Request.QueryString["price"];
            Session["shoporderid"] = ViewState["shoporderid"];
            Session["shoporderprice"] = ViewState["shoporderprice"];
            
        }
        else
        {
            if (Session["shoporderid"] != null && Session["shoporderprice"] != null)
            {
                ViewState["shoporderid"] = Session["shoporderid"];
                ViewState["shoporderprice"] = Session["shoporderprice"];
            }
        }

        order.orderID = int.Parse(ViewState["shoporderid"].ToString());
        order = ob.getorders(order);
        modelCu.customerID = order.customerID;
        modelCu = Cb.getCustomer(modelCu);
            this.Label2.Text = ViewState["shoporderprice"].ToString();
        this.HyperLink3.NavigateUrl += ViewState["shoporderid"];
    }

}