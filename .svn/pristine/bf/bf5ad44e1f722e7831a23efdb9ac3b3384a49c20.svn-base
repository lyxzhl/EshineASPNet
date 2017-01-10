using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class confirmemail : PageBases
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["id"] = "";
            if (Request.QueryString["id"] != null && Request.QueryString["vc"] != null && Request.QueryString["ne"] != null)
            {
                Model.tab_customers modelCu = new Model.tab_customers();
                Bll.CustomerBll Cb = new Bll.CustomerBll();
                modelCu.customerID = int.Parse(Request.QueryString["id"]);
                modelCu = Cb.getCustomer(modelCu);
                if (modelCu == null || modelCu.customerValidateCode != Request.QueryString["vc"])
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + (string)GetGlobalResourceObject("GResource", "alertlinkcannotrec") + "');window.location.href = 'login.aspx';</script>");
                    //Response.Redirect("login.aspx", true);
                }
                else
                {
                    modelCu.customerPrivateEmail = Request.QueryString["ne"];
                    Cb.update(modelCu);
                    Session["id"] = modelCu.customerID;
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + (string)GetGlobalResourceObject("GResource", "alertnewemailok") + "');window.location.href = 'index.aspx';</script>");
                    //Response.Redirect("default.aspx");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + (string)GetGlobalResourceObject("GResource", "alertlinkcannotrec") + "');window.location.href = 'login.aspx';</script>");
                //Response.Redirect("login.aspx", true);
            }
        }
    }
}