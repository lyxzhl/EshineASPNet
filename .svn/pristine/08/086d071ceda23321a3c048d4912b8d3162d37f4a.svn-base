using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
public partial class viewshoporder : PageBases
{
    Model.tab_customers modelCu = new Model.tab_customers();
    Model.tab_orders modelod = new Model.tab_orders();
    Bll.CustomerBll Cb = new Bll.CustomerBll();
    Bll.OrdersBll ob = new Bll.OrdersBll();
    Bll.ProductBll pb = new Bll.ProductBll();
    DBunit.SQLAccess dbsql = new DBunit.SQLAccess();
    PublicClass pc = new PublicClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.CheckUser((Hashtable)Application["Online"]);
        }

        modelCu.customerID = int.Parse(Session["id"].ToString());
        modelCu = Cb.getCustomer(modelCu);

        if (!Page.IsPostBack)
        {
            if (!ob.hasshoporder(modelCu.customerID))
            {
                this.Panel1.Visible = true;
            }
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        modelod.orderID = int.Parse(((LinkButton)sender).CommandArgument);
        modelod = ob.getorders(modelod);

        //ob.Delete(modelod.orderID);
        modelod.orderStatus = "已取消";
        ob.Update(modelod);
        //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('" + (string)GetGlobalResourceObject("GResource", "alertcancelordersucc") + "'); </script>");
        this.GridView12.DataBind();
    }


    protected void BtnPay_Click(object sender, EventArgs e)
    {
        modelod.orderID = int.Parse(((LinkButton)sender).CommandArgument);
        modelod = ob.getorders(modelod);

        Response.Redirect("shopordersubmitted.aspx?oid=" + modelod.orderID + "&price=" + modelod.examBill, true);
    }


    protected void GridView12_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell tc;

            tc = e.Row.Cells[1];
            string[] ts = tc.Text.Split(';');
            StringBuilder sb = new StringBuilder();
            string s,ss;
            int index,barindex;
            for (int i = 0; i < ts.Length; i++)
            {
                index=ts[i].IndexOf('*');
                s = ts[i].Substring(0, index);
                int count = int.Parse(dbsql.ExecuteSc("select count(*) from tab_products where productID=" + s).ToString());
                if (count == 0)
                {
                    dbsql.ExecuteNonQuery("delete from tab_orders where ReportContent like '%"+s+"%'");
                }
                if (Session["language"] != null && Session["language"].ToString() == "zh-cn")
                {
                    sb.Append("<a target='_blank' href='viewshopitem_multi.aspx?productID=" + s + "'>" +
                        pb.getname(s) + pb.getcategory(s));
                }
                else
                {
                    sb.Append("<a target='_blank' href='viewshopitem_multi.aspx?productID=" + s + "'>" +
                        pb.getname_eng(s) + pb.getcategory(s));
                }
                    ss = ts[i].Substring(index, ts[i].Length - index);
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
            sb.Remove(sb.Length - 1, 1);
            tc.Text = sb.ToString();


            tc = e.Row.Cells[3];
            if (tc.Text == "待确认")
            {
                tc.Text = (string)GetGlobalResourceObject("GResource", "os_saved");
            }
            else if (tc.Text == "待付款")
            {
                tc.Text = (string)GetGlobalResourceObject("GResource", "os_waitpay");
            }
            else if (tc.Text == "待转账")
            {
                tc.Text = (string)GetGlobalResourceObject("GResource", "os_waittransfer");
            }
            else if (tc.Text == "约检成功")
            {
                tc.Text = (string)GetGlobalResourceObject("GResource", "os_paid");
            }
            else if (tc.Text == "已体检")
            {
                tc.Text = (string)GetGlobalResourceObject("GResource", "os_checked");
            }
            else if (tc.Text == "已完成")
            {
                tc.Text = (string)GetGlobalResourceObject("GResource", "os_finish");
            }
            else if (tc.Text == "已取消")
            {
                tc.Text = (string)GetGlobalResourceObject("GResource", "os_cancel");
            }
        }


    }
}