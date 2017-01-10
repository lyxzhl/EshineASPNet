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
using System.Text;
using Model;
using Bll;
public partial class admin_product_product_update : basePage
{
    upImage ui = new upImage();
    PublicClass pc = new PublicClass();
    Bll.ProductBll B_pro = new Bll.ProductBll();
    Model.tab_products M_pro = new Model.tab_products();
    DBunit.SQLAccess dbsql = new DBunit.SQLAccess();
    upExcel ue = new upExcel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if(Session["language"]==null||Session["language"].ToString()=="")
            {
                Session["language"] = "zh-cn";
            }
            if (Session["language"].ToString()== "zh-cn")
            {
                this.Button5.Text = "English";
            }
            else
            {
                this.Button5.Text = "中文";
            }
            //this.CheckUser((Hashtable)Application["Online"]);
            if (Request.QueryString["newproduct"] != null && Request.QueryString["newproduct"].ToString() == "yes")
            {
                this.Label1.Text = "新增商品";
                this.Button2.Text = "新增";
            }
            else
            {
                pc.GetProductClass(this.DropDownList1);
                string proID = Request.QueryString["proID"];
                ViewState["proID"] = int.Parse(proID);
                showProduct(proID);

            }
            string s = "select px from tab_products order by px desc";
            DataTable dt = dbsql.ExecuteDataSet(s).Tables[0];
            this.Label2.Text = dt.Rows[0][0].ToString();
            if (this.TextBox21.Text=="")
            this.Image1.ImageUrl = "~/Images/houtai/点我换图.jpg";
            if (this.TextBox26.Text == "")
            this.Image6.ImageUrl = "~/Images/houtai/点我换图.jpg";
        }
        fillnamelist();
        if (this.Button2.Text != "新增")
        {
            initsupplier();
        }

    }
    void showProduct(string proID)
    {
        DataTable dt = B_pro.SelectPro("select * from tab_products,tab_productClass where tab_products.productClassID=tab_productClass.productClassID and productID=" + proID);
        if (Session["language"] != null && Session["language"].ToString() == "zh-cn")
        {
            this.TextBox1.Text = dt.Rows[0]["productName"].ToString();
            this.TextBox2.Text = dt.Rows[0]["productUnitPrice"].ToString();
            this.TextBox3.Text = dt.Rows[0]["productCount"].ToString();

            this.TextBox4.Text = dt.Rows[0]["productContent"].ToString();
            this.TextBox5.Text = dt.Rows[0]["ex1ID"].ToString();
            this.TextBox6.Text = dt.Rows[0]["productMarketPrice"].ToString();
            content1.Value = dt.Rows[0]["msg"].ToString();
            content2.Value = dt.Rows[0]["ikangName"].ToString();
            content3.Value = dt.Rows[0]["meinianName"].ToString();
            content4.Value = dt.Rows[0]["cimingNmae"].ToString();



            this.Image1.ImageUrl = "~/" + dt.Rows[0]["productImg"].ToString();
            this.TextBox21.Text = dt.Rows[0]["productImg"].ToString();
            this.Image6.ImageUrl = "~/" + dt.Rows[0]["downlimit"].ToString();
            this.TextBox26.Text = dt.Rows[0]["downlimit"].ToString();
            this.CheckBox1.Checked = dt.Rows[0]["unit"].ToString() == "发布" ? true : false;
            if (dt.Rows[0]["uplimit"].ToString() != "电子码")
            {
                this.RadioButton1.Checked = true;
            }
            else
            {
                this.RadioButton2.Checked = true;
            }

            if (dt.Rows[0]["ex1Name"].ToString() != "")
            {
                string[] simg = dt.Rows[0]["ex1Name"].ToString().Split(';');
                for (int i = 0; i < simg.Length; i++)
                {
                    switch (i)
                    {
                        case 0: this.Image2.ImageUrl = "~/" + simg[i];
                            this.TextBox22.Text = simg[i];
                            break;
                        case 1: this.Image3.ImageUrl = "~/" + simg[i];
                            this.TextBox23.Text = simg[i];
                            break;
                        case 2: this.Image4.ImageUrl = "~/" + simg[i];
                            this.TextBox24.Text = simg[i];
                            break;
                        case 3: this.Image5.ImageUrl = "~/" + simg[i];
                            this.TextBox25.Text = simg[i];
                            break;
                    }
                }
            }
        }
        else
        {
            this.TextBox1.Text = dt.Rows[0]["productName_eng"].ToString();
            this.TextBox2.Text = dt.Rows[0]["productUnitPrice"].ToString();
            this.TextBox3.Text = dt.Rows[0]["productCount"].ToString();

            this.TextBox4.Text = dt.Rows[0]["productContent_eng"].ToString();
            this.TextBox5.Text = dt.Rows[0]["ex1ID_eng"].ToString();
            this.TextBox6.Text = dt.Rows[0]["productMarketPrice"].ToString();
            content1.Value = dt.Rows[0]["msg_eng"].ToString();
            content2.Value = dt.Rows[0]["ikangName_eng"].ToString();
            content3.Value = dt.Rows[0]["meinianName_eng"].ToString();
            content4.Value = dt.Rows[0]["cimingName_eng"].ToString();



            this.Image1.ImageUrl = "~/" + dt.Rows[0]["productImg_eng"].ToString();
            this.TextBox21.Text = dt.Rows[0]["productImg_eng"].ToString();
            this.Image6.ImageUrl = "~/" + dt.Rows[0]["downlimit_eng"].ToString();
            this.TextBox26.Text = dt.Rows[0]["downlimit_eng"].ToString();
            this.CheckBox1.Checked = dt.Rows[0]["unit"].ToString() == "发布" ? true : false;
            if (dt.Rows[0]["uplimit"].ToString() != "电子码")
            {
                this.RadioButton1.Checked = true;
            }
            else
            {
                this.RadioButton2.Checked = true;
            }

            if (dt.Rows[0]["ex1Name_eng"].ToString() != "")
            {
                string[] simg = dt.Rows[0]["ex1Name_eng"].ToString().Split(';');
                for (int i = 0; i < simg.Length; i++)
                {
                    switch (i)
                    {
                        case 0: this.Image2.ImageUrl = "~/" + simg[i];
                            this.TextBox22.Text = simg[i];
                            break;
                        case 1: this.Image3.ImageUrl = "~/" + simg[i];
                            this.TextBox23.Text = simg[i];
                            break;
                        case 2: this.Image4.ImageUrl = "~/" + simg[i];
                            this.TextBox24.Text = simg[i];
                            break;
                        case 3: this.Image5.ImageUrl = "~/" + simg[i];
                            this.TextBox25.Text = simg[i];
                            break;
                    }
                }
            }
        }

            for (int i = 0; i < this.DropDownList1.Items.Count; i++)
            {
                if (this.DropDownList1.Items[i].Value == dt.Rows[0]["productClassID"].ToString())
                {
                    this.DropDownList1.SelectedIndex = i;
                }
            }
    }

    void fillnamelist()
    {
        DataTable dt = B_pro.SelectPro("select distinct productName  from tab_products ");
        this.DropDownList2.DataSource = dt;
        this.DropDownList2.DataTextField = "productName";
        this.DropDownList2.DataBind();
        this.DropDownList2.Items.Insert(0, new ListItem("选择已有商品名"));
    }
    void initsupplier()
    {
        this.SqlDataSource1.SelectCommand = "SELECT * FROM [tab_shopsuppliers] where hospid='" + ViewState["proID"] + "'";
        this.GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (this.TextBox21.Text == "")
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('请选择图片！');</script>");
            return;
        }

        StringBuilder strpic = new StringBuilder();
        if (this.TextBox22.Text != "")
        {
            strpic.Append(this.TextBox22.Text + ";");
        }
        if (this.TextBox23.Text != "")
        {
            strpic.Append(this.TextBox23.Text + ";");
        }
        if (this.TextBox24.Text != "")
        {
            strpic.Append(this.TextBox24.Text + ";");
        }
        if (this.TextBox25.Text != "")
        {
            strpic.Append(this.TextBox25.Text + ";");
        }
        if (strpic.Length > 0)
        {
            strpic.Remove(strpic.Length - 1, 1);
            

        }

        if (this.Button2.Text == "新增")
        {
            if (Session["language"] != null && Session["language"] == "zh-cn")
            {
                M_pro.productName = this.TextBox1.Text;
                M_pro.productClassID = 71;
                M_pro.productUnitPrice = double.Parse(this.TextBox2.Text);
                M_pro.productMarketPrice = double.Parse(this.TextBox6.Text);
                M_pro.productCount = int.Parse(this.TextBox3.Text);
                M_pro.productContent = this.TextBox4.Text;
                M_pro.msg = content1.Value.Replace("'", "''");
                M_pro.ikangName = content2.Value.Replace("'", "''");
                M_pro.meinianName = content3.Value.Replace("'", "''");
                M_pro.cimingNmae = content4.Value.Replace("'", "''");


                M_pro.ex1ID = this.TextBox5.Text;
                M_pro.unit = this.CheckBox1.Checked ? "发布" : "隐藏";
                M_pro.productImg = this.TextBox21.Text;
                M_pro.ex1Name = strpic.ToString();
                M_pro.downlimit = this.TextBox26.Text;
                M_pro.type = "商城";
                M_pro.productDate = DateTime.Now;
                M_pro.uplimit = this.RadioButton1.Checked ? "快递实物" : "电子码";
                M_pro.px = int.Parse(this.Label2.Text) + 1;
            }
            else
            {
                M_pro.productName_eng = this.TextBox1.Text;
                M_pro.productClassID = 71;
                M_pro.productUnitPrice = double.Parse(this.TextBox2.Text);
                M_pro.productMarketPrice = double.Parse(this.TextBox6.Text);
                M_pro.productCount = int.Parse(this.TextBox3.Text);
                M_pro.productContent_eng = this.TextBox4.Text;
                M_pro.msg_eng = content1.Value.Replace("'", "''");
                M_pro.ikangName_eng = content2.Value.Replace("'", "''");
                M_pro.meinianName_eng = content3.Value.Replace("'", "''");
                M_pro.cimingName_eng = content4.Value.Replace("'", "''");
                

                M_pro.ex1ID_eng = this.TextBox5.Text;
                M_pro.unit = this.CheckBox1.Checked ? "发布" : "隐藏";
                M_pro.productImg_eng = this.TextBox21.Text;
                M_pro.ex1Name_eng = strpic.ToString();
                M_pro.downlimit_eng = this.TextBox26.Text;
                M_pro.type = "商城";
                M_pro.productDate = DateTime.Now;
                M_pro.uplimit = this.RadioButton1.Checked ? "快递实物" : "电子码";
                M_pro.px = int.Parse(this.Label2.Text) + 1;
            }
                B_pro.AddPro(M_pro);
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('新增成功');location='product_admin.aspx'</script>");
            
        }
        else
        {
            StringBuilder str = new StringBuilder();
            if (Session["language"] != null && Session["language"].ToString() == "zh-cn")
            {
                str.Append("update tab_products set ");
                str.AppendFormat("productName=N'{0}',", this.TextBox1.Text);
                str.AppendFormat("productClassID={0},", this.DropDownList1.SelectedValue);
                str.AppendFormat("productUnitPrice={0},", this.TextBox2.Text);
                str.AppendFormat("productMarketPrice={0},", this.TextBox6.Text);
                str.AppendFormat("productCount={0},", this.TextBox3.Text);
                str.AppendFormat("productContent='{0}',", this.TextBox4.Text);
                str.AppendFormat("msg=N'{0}',", content1.Value.Replace("'", "''"));
                str.AppendFormat("ikangName=N'{0}',", content2.Value.Replace("'", "''"));
                str.AppendFormat("meinianName=N'{0}',", content3.Value.Replace("'", "''"));
                str.AppendFormat("cimingNmae=N'{0}',", content4.Value.Replace("'", "''"));


                str.AppendFormat("ex1ID=N'{0}',", this.TextBox5.Text);
                str.AppendFormat("unit=N'{0}',", this.CheckBox1.Checked ? "发布" : "隐藏");
                str.AppendFormat("productImg='{0}',", this.TextBox21.Text);
                str.AppendFormat("ex1Name=N'{0}',", strpic.ToString());
                str.AppendFormat("downlimit=N'{0}',", this.TextBox26.Text);
                str.AppendFormat("uplimit=N'{0}',", this.RadioButton1.Checked ? "快递实物" : "电子码");


                if (false && this.File1.Value != "" || this.File1.Value != string.Empty)
                {
                    ui.SaveSmallImg(Server.MapPath("~/Images/SmallImages") + "\\" + ui.GetFileName(this.File1), 65, 65, "mediplus", 14, this.File1);
                    str.AppendFormat("productImg='{0}',", ui.GetFileName(File1));
                    ui.SaveUpFile(Server.MapPath("~/Images/BigImages") + "\\" + ui.GetFileName(this.File1), this.File1);
                    //str.AppendFormat("productImg='{0}',", ui.GetFileName(File1));
                }
                str.Remove(str.Length - 1, 1);
                str.Append(" where productID=" + Convert.ToInt32(ViewState["proID"]));
            }
            else
            {
                str.Append("update tab_products set ");
                str.AppendFormat("productName_eng=N'{0}',", this.TextBox1.Text);
                str.AppendFormat("productClassID={0},", this.DropDownList1.SelectedValue);
                str.AppendFormat("productUnitPrice={0},", this.TextBox2.Text);
                str.AppendFormat("productMarketPrice={0},", this.TextBox6.Text);
                str.AppendFormat("productCount={0},", this.TextBox3.Text);
                str.AppendFormat("productContent_eng='{0}',", this.TextBox4.Text);
                str.AppendFormat("msg_eng=N'{0}',", content1.Value.Replace("'", "''"));
                str.AppendFormat("ikangName_eng=N'{0}',", content2.Value.Replace("'", "''"));
                str.AppendFormat("meinianName_eng=N'{0}',", content3.Value.Replace("'", "''"));
                str.AppendFormat("cimingName_eng=N'{0}',", content4.Value.Replace("'", "''"));


                str.AppendFormat("ex1ID_eng=N'{0}',", this.TextBox5.Text);
                str.AppendFormat("unit=N'{0}',", this.CheckBox1.Checked ? "发布" : "隐藏");
                str.AppendFormat("productImg_eng='{0}',", this.TextBox21.Text);
                str.AppendFormat("ex1Name_eng=N'{0}',", strpic.ToString());
                str.AppendFormat("downlimit_eng=N'{0}',", this.TextBox26.Text);
                str.AppendFormat("uplimit=N'{0}',", this.RadioButton1.Checked ? "快递实物" : "电子码");


                if (false && this.File1.Value != "" || this.File1.Value != string.Empty)
                {
                    ui.SaveSmallImg(Server.MapPath("~/Images/SmallImages") + "\\" + ui.GetFileName(this.File1), 65, 65, "mediplus", 14, this.File1);
                    str.AppendFormat("productImg='{0}',", ui.GetFileName(File1));
                    ui.SaveUpFile(Server.MapPath("~/Images/BigImages") + "\\" + ui.GetFileName(this.File1), this.File1);
                    //str.AppendFormat("productImg='{0}',", ui.GetFileName(File1));
                }
                str.Remove(str.Length - 1, 1);
                str.Append(" where productID=" + Convert.ToInt32(ViewState["proID"]));
            }
            //Response.Write(str.ToString());
            B_pro.UpdatePro(str.ToString());
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('更新成功');location='product_admin.aspx'</script>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("product_admin.aspx");
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
                    throw new Exception("Excel文件读取失败!");
                }

                int j;
                string erroritems = "";
                shopSupplierBll supp = new shopSupplierBll();
                tab_shopsuppliers supplier;
                for (int i = 0; i < inputdt.Rows.Count; i++)
                {
                    j = 0;
                    supplier = new tab_shopsuppliers();
                    supplier.supplier = inputdt.Rows[i][j++].ToString().Trim();
                    supplier.branch = inputdt.Rows[i][j++].ToString().Trim();
                    j++;

                    supplier.hospid = ViewState["proID"].ToString();
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

    protected void Button4_Click(object sender, EventArgs e)
    {
        string s = "delete FROM [tab_shopsuppliers] where hospid='" + ViewState["proID"] + "'";
        dbsql.ExecuteNonQuery(s);
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.TextBox1.Text = this.DropDownList2.SelectedItem.Text;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if(this.Button5.Text=="English")
        {
            Session["language"] = "en-us";
            this.Button5.Text = "中文";
            showProduct(ViewState["proID"].ToString());
        }
        else
        {
            Session["language"] = "zh-cn";
            this.Button5.Text = "English";
            showProduct(ViewState["proID"].ToString());
        }
    }
}
