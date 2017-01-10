using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
public partial class Admin_ordersAdmin_ordersshop : System.Web.UI.Page
{
    Bll.ProductBll pb = new Bll.ProductBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["ordershopselectcomm"] != null && ViewState["ordershopselectcomm"].ToString() != "")
        {
            this.SqlDataSource1.SelectCommand = ViewState["ordershopselectcomm"].ToString();
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell tc;

            tc = e.Row.Cells[5];
            string[] ts = tc.Text.Split(';');
            StringBuilder sb = new StringBuilder();
            string s, ss;
            int index, barindex;
            for (int i = 0; i < ts.Length; i++)
            {
              
                index = ts[i].IndexOf('*');
                if (index <= 0)
                    continue;
                
                s = ts[i].Substring(0, index);
                ss = ts[i].Substring(index, ts[i].Length - index);
                if (ss == "*0")
                {
                     continue;
                }
                sb.Append("<a target='_blank' href='/viewshopitem_multi.aspx?productID=" + s + "'>" +
                    pb.getname(s) + pb.getcategory(s));
                
                
                if (ss.Contains("|"))
                {
                    barindex = ss.IndexOf('|');
                    sb.Append(ss.Substring(0, barindex) + "</a><br />密码：");
                    sb.Append(ss.Substring(barindex + 1) + "<br />");
                }
                else
                {
                    sb.Append(ss + "</a><br />");
                }
                //sb.Append(",");
            }
            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            tc.Text = sb.ToString();


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        updateselection();
    }

    void updateselection()
    {
        string s = this.TextBox1.Text;
        string scmd = "SELECT [orderDate], [customerName], [examBill], [ReportContent], [orderStatus], [personAddress], [Msg], [orderID] FROM [tab_orders] WHERE ReportType='商城' ";

        if (this.CheckBox1.Checked)
        {
            scmd += " and personAddress<>'' ";
        }

        if (s != "")
        {
            scmd += " and (customerName like '%" + s + "%' or  ReportContent like '%" + s + "%' or  orderStatus like '%" + s + "%' or  personAddress like '%" + s + "%' or  orderID like '%" + s + "%')";
        }
        ViewState["ordershopselectcomm"] = scmd;
        this.SqlDataSource1.SelectCommand = scmd;
        this.SqlDataSource1.DataBind();
    }
}