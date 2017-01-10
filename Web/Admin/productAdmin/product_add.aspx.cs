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

public partial class Admin_product_product_add : basePage
{
    upImage ui = new upImage();
    PublicClass pc = new PublicClass();
    Bll.ProductBll B_pro = new Bll.ProductBll();
    Model.tab_products M_pro = new Model.tab_products();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.CheckUser();
            pc.GetProductClass(this.DropDownList1);
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        M_pro.productName = this.TextBox1.Text;
        M_pro.productUnitPrice = Convert.ToSingle(this.TextBox2.Text);
        M_pro.productCount = Convert.ToInt32(this.TextBox3.Text);
        M_pro.productClassID = Convert.ToInt32(this.DropDownList1.SelectedValue);
        M_pro.productContent = this.TextBox4.Text;
        M_pro.msg = content1.Value.Replace("'", "''");
        M_pro.ex1ID = this.TextBox5.Text;
        if (this.File1.Value != null && this.File1.Value != "")
        {
            ui.SaveSmallImg(Server.MapPath("~/Images/SmallImages") + "\\" + ui.GetFileName(this.File1), 145, 184, "Eshine", 14, this.File1);
            M_pro.productImg = ui.GetFileName(this.File1);
            ui.SaveUpFile(Server.MapPath("~/Images/BigImages") + "\\" + ui.GetFileName(this.File1), this.File1);
            //M_pro.productImg = ui.GetFileName(this.File1);
            B_pro.AddPro(M_pro);
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('添加成功');location='product_admin.aspx'</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('添加失败')</script>");
        }

    }
}
