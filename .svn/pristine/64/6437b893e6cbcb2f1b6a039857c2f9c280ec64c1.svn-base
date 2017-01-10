using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_mobilenav : System.Web.UI.UserControl
{
    public string onlineqq1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        onlineqq1 = "http://wpa.qq.com/msgrd@v=3&uin=" + System.Configuration.ConfigurationManager.AppSettings["onlineqq1"] + "&site=qq&menu=yes";

        if (Session["id"] == null || Session["id"].ToString() == "" || (Session["firstlogin"] != null && Session["firstlogin"] == "1"))
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
        }
        else
        {
            initpanel();
        }
    }



    void initpanel()
    {
        Bll.OrdersBll ob = new Bll.OrdersBll();
        //this.LinkButton3.Text = "";
        //this.HyperLink1.Text = (String)GetLocalResourceObject("LinkButton3Resource1.Text") + "(" + ob.getordernum(Convert.ToInt32(Session["id"])) + ")";
        //this.HyperLink2.Text = (String)GetLocalResourceObject("LinkButton4Resource1.Text") + "(" + mb.getunread(Convert.ToInt32(Session["id"])) + ")";

    }
}