using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;
using Bll;
public partial class Admin_supplierAdmin_supplierinfo : System.Web.UI.Page
{
    Bll.SupplierBll sb = new Bll.SupplierBll();
    Model.tab_suppliers modelCb = new Model.tab_suppliers();
    PublicClass pc = new PublicClass();
    upExcel ue = new upExcel();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string s = this.TextBox1.Text;
        string scmd = @"select * from tab_suppliers where supplier like '%" + s + "%' or "
           + " hospid like '%" + s + "%' or "
+ " province like '%" + s + "%' or "
+ " city like '%" + s + "%' or "
+ " branch like '%" + s + "%' or "
+ " phone like '%" + s + "%' or "
+ " type like '%" + s + "%'";

        this.SqlDataSource1.SelectCommand = scmd;
        this.SqlDataSource1.DataBind();
    }


    protected void Button3_Click(object sender, EventArgs e)
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
                    throw new Exception("Excel文件读取失败!找不到表Sheet1");
                }

                int j;
                string erroritems = "";
                SupplierBll supp = new SupplierBll();
                tab_suppliers supplier;
                for (int i = 0; i < inputdt.Rows.Count; i++)
                {
                    j = 0;
                    supplier = new tab_suppliers();
                    supplier.supplier = inputdt.Rows[i][j++].ToString().Trim();
                    supplier.branch = inputdt.Rows[i][j++].ToString().Trim();
                    supplier.hospid = inputdt.Rows[i][j++].ToString().Trim();
                    supplier.province = inputdt.Rows[i][j++].ToString().Trim();
                    supplier.city = inputdt.Rows[i][j++].ToString().Trim();
                    supplier.zone = inputdt.Rows[i][j++].ToString().Trim();
                    supplier.address = inputdt.Rows[i][j++].ToString().Trim();
                    supplier.phone = inputdt.Rows[i][j++].ToString().Trim();
                    supplier.note = inputdt.Rows[i][j++].ToString().Trim();
                    supplier.lat = inputdt.Rows[i][j++].ToString().Trim();
                    supplier.lng = inputdt.Rows[i][j++].ToString().Trim();
                    supplier.type = inputdt.Rows[i][j++].ToString().Trim();




                    try
                    {
                        if (supp.Add(supplier) < 1)
                        {
                            errorcount++;
                        }
                        else
                        {
                            successfulcount++;
                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        errorcount++;
                        erroritems += supplier.supplier + " " + supplier.branch + "\n";
                    }
                }
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('操作已完成！其中成功导入数据" + successfulcount + "条，失败" + errorcount + "条," + erroritems + "'); </script>");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string supplierid="";
        int i = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            if ((row.FindControl("CheckBox1") as CheckBox).Checked)
            {
                int id = 0;
                id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
                supplierid += id.ToString()+",";
                i++;
            }
        }
        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('" + supplierid + "'); </script>");
    }
    public void updatenote(object sender, EventArgs e)
    {
        
        int i = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            if ((row.FindControl("CheckBox1") as CheckBox).Checked)
            {
                int id = 0;
                id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
                modelCb.id = id;
                modelCb = sb.getsuppliers(modelCb);
                modelCb.note = this.TextBox7.Text;
                sb.update(modelCb);
                i++;
            }
        }
        if (i==0)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('请选择门店'); </script>");
        }
        else
        {
            GridView1.DataSourceID = this.SqlDataSource1.ID;
            GridView1.DataBind();
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('成功修改" + i + "个门店'); </script>");
        }
    }
}