using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
public partial class MasterPage : System.Web.UI.MasterPage
{
    Bll.OrdersBll ob = new Bll.OrdersBll();
    Bll.messageBll mb = new Bll.messageBll();


    void initpanel()
    {
        //this.LinkButton3.Text = "";
        this.LinkButton3.Text = (String)GetLocalResourceObject("LinkButton3Resource1.Text") + "(" + ob.getordernum(Convert.ToInt32(Session["id"])) + ")";
        this.LinkButton4.Text = (String)GetLocalResourceObject("LinkButton4Resource1.Text") + "(" + mb.getunread(Convert.ToInt32(Session["id"])) + ")";
 
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null || Session["id"].ToString() == "")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('没有sessionid！');</script>");
            return;      
            Response.Redirect("login.aspx");

        }
        else
        {
            LinkButton2.Text = (String)GetLocalResourceObject("LinkButton2Resource1.Text") + "," + Session["cus"];
            initpanel();
        }
        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["cus"] = "";
        Session["id"] = "";
        Response.Redirect("login.aspx");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("safecenter.aspx");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("helpcenter.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewarrangement.aspx");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("messages.aspx");
    }
}
