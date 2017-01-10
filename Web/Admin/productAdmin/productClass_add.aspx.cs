using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_product_productClass_add : basePage
{    upImage ui = new upImage();
    PublicClass pc = new PublicClass();
    Bll.ProdutClassBLL B_pro = new Bll.ProdutClassBLL();
    Model.tab_product_class M_pro = new Model.tab_product_class();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this.CheckUser((Hashtable)Application["Online"]);
            pc.GetProductClass(DropDownList1);
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        M_pro.ProductClassName = this.TextBox1.Text;
        M_pro.ProductClassParentID = Convert.ToInt32(this.DropDownList1.SelectedValue);
        M_pro.ProductClassContent = this.TextBox4.Text;

        int i = B_pro.AddProClass(M_pro);
        if (i != 0)
        {
            Response.Redirect("productClass_admin.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("productClass_admin.aspx");
    }
}
