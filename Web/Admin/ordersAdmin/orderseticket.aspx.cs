using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Admin_ordersAdmin_orderseticket : System.Web.UI.Page
{
    Bll.ProductBll pb = new Bll.ProductBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["ordereticketselectcomm"] != null && ViewState["ordereticketselectcomm"].ToString() != "")
        {
            this.SqlDataSource1.SelectCommand = ViewState["ordereticketselectcomm"].ToString();
        }
    }
    protected void ButtonEE_Click(object sender, EventArgs e)
    {
        PublicClass pc = new PublicClass();
        GridView1.AllowPaging = false;// turn off paging 
        GridView1.DataSourceID = "";
        GridView1.DataSourceID = this.SqlDataSource1.ID;

        GridView1.DataBind();
        pc.gridviewtoexcel(GridView1, "MediPlusexport");
        GridView1.AllowPaging = true;
        GridView1.DataSourceID = "";
        GridView1.DataSourceID = this.SqlDataSource1.ID;

        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        updateselection();
    }

    void updateselection()
    {
        string s = this.TextBox1.Text;
        string scmd = "SELECT [orderID], [customerName], [productName], [productID], [itemnum], [eticket], [time], [id] FROM [tab_eticket]  ";



        if (s != "")
        {
            scmd += "WHERE  (orderID like '%" + s + "%' or  customerName like '%" + s + "%' or  productName like '%" + s + "%' or  productID like '%" + s + "%' or  eticket = '" + s + "')";
        }
        ViewState["ordereticketselectcomm"] = scmd;
        this.SqlDataSource1.SelectCommand = scmd;
        this.SqlDataSource1.DataBind();
    }
}