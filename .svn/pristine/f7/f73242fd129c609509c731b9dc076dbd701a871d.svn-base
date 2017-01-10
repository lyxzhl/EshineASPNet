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
using System.IO;
using System.Text;
public partial class admin_product_productClass_admin : basePage
{
    upImage ui = new upImage();
    PublicClass pc = new PublicClass();
    Bll.ProdutClassBLL B_pro = new Bll.ProdutClassBLL();
    Model.tab_product_class M_pro = new Model.tab_product_class();
    Bll.ProductBll bp = new Bll.ProductBll();
    Model.tab_products products = new Model.tab_products();
    upExcel ue = new upExcel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            //this.CheckUser((Hashtable)Application["Online"]);
            pc.GetProductClass(this.DropDownList1);
          
        
            //this.DropDownList1.Items.Insert(0, new ListItem("------", "x"));
        }
    }
 
    protected void Button5_Click(object sender, EventArgs e)
    {

        Response.Write("<script>window.open('showProductClass.aspx','产品类别','300px','500px');</script>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        StringBuilder strsel = new StringBuilder();
        strsel.Append("SELECT [productClassID], [productClassName], [faName], [productClassContent] FROM [v_productClass] ");
        strsel.AppendFormat(" where productClassName like '{0}'+'%'", this.TextBox1.Text);
        if (this.DropDownList1.SelectedIndex > 0)
            strsel.AppendFormat(" and productClassParentID={0}", this.DropDownList1.SelectedValue);

        this.proClassDataSource.SelectCommand = strsel.ToString();
        this.proClassDataSource.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        Response.Redirect("productClass_add.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
        Response.ContentType = "application/excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        GridView gv = new GridView();

        gv.DataSource = this.proClassDataSource;
        gv.DataBind();
        gv.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = B_pro.SelectProClass("select * from tab_productClass where productClassParentID=" + this.GridView1.DataKeys[e.RowIndex].Value);
    if (dt.Rows.Count== 0)
    {
        this.proClassDataSource.DeleteCommand = "delete from tab_productClass where productClassID=" + this.GridView1.DataKeys[e.RowIndex].Value;
        this.GridView1.DataBind();
    }
    else
    {
        this.proClassDataSource.DeleteCommand = "delete from tab_productClass where productClassID=-1";
        ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请先删除全部子项')</script>");
        return;
    }
        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // 为每一个数据行添加两个属性，实现当鼠标经过时高亮的效果

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //鼠标移到该行时所在行变颜色，移出时恢复原来颜色

                e.Row.Attributes.Add("onMouseOver", "this.style.cursor='hand';this.originalcolor=this.style.backgroundColor;this.style.backgroundColor='#E2DED6';");
                e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=this.originalcolor;");
            }
            //Onclick删除按钮事件，弹出提示对话框，提示是否想要删除该记录

        }
        if (e.Row.DataItemIndex == -1)
        {
            return;
        }
        ImageButton ibtn = (ImageButton)e.Row.FindControl("ImageButton1");
        ibtn.Attributes.Add("onclick","javascript:return confirm('你确定要删除吗?')");
    }
    protected void Button5_Click1(object sender, EventArgs e)
    {
        int successfulcount = 0, errorcount = 0;
        try
        {
            if (this.FileUpload1.HasFile)
            {
                if (!ue.SaveUpFile("~/Admin/temp/", this.FileUpload1))//上传文件
                {
                    throw new Exception("上传文件失败!");
                }

                DataTable inputdt = ue.InputExcel("Sheet1");
                if (inputdt == null)
                {
                    throw new Exception("Excel文件读取失败!");
                }

                int j;
                
                for (int i = 0; i < inputdt.Rows.Count; i++)
                {
                    j = 0;
                    products = new Model.tab_products();
                    products.productName = inputdt.Rows[i][j++].ToString().Trim();
                    products.productClassID = int.Parse(inputdt.Rows[i][j++].ToString());
                    products.ikangName = inputdt.Rows[i][j++].ToString().Trim();
                    products.ikangID = inputdt.Rows[i][j++].ToString().Trim();
                    products.meinianName = inputdt.Rows[i][j++].ToString().Trim();
                    products.meinianID = inputdt.Rows[i][j++].ToString().Trim();
                    products.cimingNmae = inputdt.Rows[i][j++].ToString().Trim();
                    products.cimingID = inputdt.Rows[i][j++].ToString().Trim();
                    products.ex1Name = inputdt.Rows[i][j++].ToString().Trim();
                    products.ex1ID = inputdt.Rows[i][j++].ToString().Trim();
                    products.type = inputdt.Rows[i][j++].ToString().Trim();
                    products.unit = inputdt.Rows[i][j++].ToString().Trim();
                    products.uplimit = inputdt.Rows[i][j++].ToString().Trim();
                    products.downlimit = inputdt.Rows[i][j++].ToString().Trim();
                    products.productUnitPrice = inputdt.Rows[i][j++].ToString()==""?0:double.Parse(inputdt.Rows[i][j++].ToString());
                    products.productMarketPrice =inputdt.Rows[i][j++].ToString()==""?0: double.Parse(inputdt.Rows[i][j++].ToString());


                    try
                    {
                        if (bp.AddPro(products)<1 )
                        {
                            errorcount++;
                        }
                        else
                        {
                            successfulcount++;
                        }

                    }
                    catch
                    {
                        errorcount++;
                    }
                }
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('操作已完成！其中成功导入数据" + successfulcount + "条，失败" + errorcount + "条'); </script>");
                GridView1.DataBind();
            }
            else
            {
                throw new Exception("请选择Excel文件!");
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('" + ex.Message + "'); </script>");
        }
    }
}
