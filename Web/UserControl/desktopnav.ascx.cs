using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UserControl_desktopnav : System.Web.UI.UserControl
{
    Bll.companyBll comb = new Bll.companyBll();
    public string shopshow = "display:none";
    Bll.CustomerBll cb = new Bll.CustomerBll();
    Model.tab_customers modeCu = new Model.tab_customers();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Image1.Visible == false)
        {
            if (Session["cc"] != null && Session["cc"].ToString() != "")
            {
                this.Image1.ImageUrl = "~/Images/customers/" + Session["cc"].ToString() + ".jpg";
                this.Image1.Visible = true;

                if (comb.getcanduallanguage(Session["cc"].ToString()) != "1")
                {
                    this.HyperLink3.Visible = false;
                }
            }
        }
        
        
        if (Session["id"] == null || Session["id"].ToString() == "" || (Session["firstlogin"] != null && Session["firstlogin"] == "1"))
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
        }
        else
        {
            modeCu.customerID = int.Parse(Session["id"].ToString());
            modeCu = cb.getCustomer(modeCu);
           
            this.Label1.Text = Session["cus"].ToString();
            initpanel();
        }
    }
    


    void initpanel()
    {
        Bll.OrdersBll ob = new Bll.OrdersBll();
        Bll.messageBll mb = new Bll.messageBll();
        int cusid = Convert.ToInt32(Session["id"]);
        this.HyperLink2.Text = (String)GetLocalResourceObject("LinkButton4Resource1.Text") + "(" + mb.getunread(cusid) + ")";
        this.HyperLink13.Text = (String)GetLocalResourceObject("myorder") + "(" + ob.getshopordernum(cusid) + ")";

    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //if (Session["viewshopitem_multiPrice"] != null)
        {
            //if (int.Parse(Session["viewshopitem_multiPrice"].ToString()) > 0)
                Response.Redirect("~/healthshop.aspx?tocart=true");
            
                
        }
    }
}