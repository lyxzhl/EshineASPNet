using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_companyAdmin_companyDeliveryaddress : System.Web.UI.Page
{
    Bll.deliveryaddressBll db = new Bll.deliveryaddressBll();
    Model.deliveryaddress deliveryaddress = new Model.deliveryaddress();
    DBunit.SQLAccess dbsql = new DBunit.SQLAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["companyname"] != null && Request["companyname"].ToString() != "")
        {
            ViewState["companyname"] = Request["companyname"];
        }
        if(!IsPostBack)
        {
            string s = "select * from province";
            //string s = "select distinct customerCompanyProvince from tab_customers where customerCompany='" + ViewState["companyname"] + "'";
            DataTable cp = db.Select(s);
            this.DropDownList1.DataSource = cp;
            this.DropDownList1.DataTextField = "name";
            this.DropDownList1.DataBind();

            gridview();
        }
    }
    void gridview()
    {
        string s = "select * from deliveryaddress";
        DataTable dt = db.Select(s);
        this.GridView1.DataSource = dt;
        this.GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        deliveryaddress.company = ViewState["companyname"].ToString();
        deliveryaddress.provence = this.DropDownList1.SelectedValue;
        deliveryaddress.address = this.TextBox1.Text;
        int num = db.Add(deliveryaddress);
        if(num>0)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('添加成功')</script>");
        }
        gridview();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string s = "delete from deliveryaddress where id=" + id;
        dbsql.ExecuteNonQuery(s);
        gridview();
    }
}