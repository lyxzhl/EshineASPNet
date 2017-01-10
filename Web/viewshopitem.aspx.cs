using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class viewshopitem : PageBases
{
    public string content = "员工身体健康是公司最大的财富";
    public string itemid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //this.CheckUser((Hashtable)Application["Online"]);
            init();
        }
    }
    void init()
    {
        Bll.ProductBll pb = new Bll.ProductBll();
        DataTable dt = pb.SelectPro("select * from tab_products where type=N'商城' and productID=176");
       // DataTable dt = pb.SelectPro("select * from tab_products where type=N'商城' and productID=" + Request.QueryString["productID"]);
        this.Label1.Text = DateTime.Parse(dt.Rows[0]["productDate"].ToString()).ToShortDateString();
        this.HyperLink1.NavigateUrl = this.HyperLink2.NavigateUrl = "#";
        this.HyperLink1.Text = dt.Rows[0]["productName"].ToString();
        content = dt.Rows[0]["msg"].ToString();
        this.Label2.Text = dt.Rows[0]["productUnitPrice"].ToString();
        ViewState["shopitemid"] = dt.Rows[0]["productID"];

        itemid = ViewState["shopitemid"].ToString();
    }

    protected void buyme_ServerClick(object sender, EventArgs e)
    {
        checkaddtocart();
        Response.Redirect("");
    }

    void checkaddtocart()
    {
        if (Session["cartitems"] == null)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id", Type.GetType("System.String"));
            dt1.Columns.Add("num", Type.GetType("System.String"));
            Session["cartitems"] = dt1;
        }
        DataTable dt = (DataTable)Session["cartitems"];
        if (ViewState["shopitemid"] != null)
        {
            bool exist = false;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == ViewState["shopitemid"].ToString())
                {
                    exist = true;
                    dt.Rows[i][1] = Convert.ToInt32(dt.Rows[i][1]) + 1;

                    break;
                }
            }

            if (!exist)
            {
                DataRow dr = dt.NewRow();
                dr[0] = ViewState["shopitemid"];
                dr[1] = 1;
                dt.Rows.Add(dr);
            }
            Session["cartitems"] = dt;

        }

    }
}