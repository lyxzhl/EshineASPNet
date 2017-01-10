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

public partial class Admin_product_product_admin : basePage
{
    Bll.ProductBll B_pro = new Bll.ProductBll();
    Model.tab_products product = new Model.tab_products();
    protected void Page_Load(object sender, EventArgs e)
    {
        PublicClass pce = new PublicClass();
        if (!Page.IsPostBack)
        {
            //this.CheckUser((Hashtable)Application["Online"]);
            pce.GetProductClass(this.DropDownList1);
    
            databind("select  * from tab_productClass,tab_products where tab_products.productClassID=tab_productClass.productClassID and tab_productClass.productClassID=tab_products.productClassID");
            //ProBin("select * from tab_products,tab_productClass where tab_products.productClassID=tab_productClass.productClassID");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("product_update.aspx?newproduct=yes");
    }
    Bll.ProductBll bp = new Bll.ProductBll();
   /// <summary>
   /// 绑定repeater 控件
   /// </summary>
   /// <param name="sql"></param>
    void ProBin(string sql)
    {
        
        DataTable dt = bp.SelectPro(sql);
        this.Repeater1.DataSource = dt;
        this.Repeater1.DataBind();
    }
    void repeaterBind()
    {
        string s = "select * from tab_products order by px";
        //StringBuilder str = new StringBuilder();
        //str.Append("select * from tab_products,tab_productClass where tab_products.productClassID=tab_productClass.productClassID ");
        //if (this.TextBox1.Text != string.Empty || this.TextBox1.Text != "")
        //    str.AppendFormat(" and productName like '%'+'{0}'+'%'", this.TextBox1.Text);
        //if (this.DropDownList1.SelectedIndex != 0)
        //    str.AppendFormat(" and tab_products.productClassID ={0}", this.DropDownList1.SelectedValue);
        //str.Append(" order by px");
        DataTable dt = bp.SelectPro(s);
        this.Repeater1.DataSource = dt;
        this.Repeater1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {   //模糊查询产品数据
        StringBuilder str = new StringBuilder();
        str.Append("select * from tab_products,tab_productClass where tab_products.productClassID=tab_productClass.productClassID ");
        if (this.TextBox1.Text != string.Empty || this.TextBox1.Text != "")
            str.AppendFormat(" and productName like '%'+'{0}'+'%'", this.TextBox1.Text);
        if (this.DropDownList1.SelectedIndex != 0)
            str.AppendFormat(" and tab_products.productClassID ={0}", this.DropDownList1.SelectedValue);
        str.Append(" order by px");
        ProBin(str.ToString());

    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "con")
        {
            Label la = (Label)e.Item.FindControl("Label1");
            int proID = Convert.ToInt32(la.Text);
            Response.Redirect("product_update.aspx?proID=" + proID);
        }
        else if(e.CommandName=="down")
        {
            int pid = int.Parse(e.CommandArgument.ToString());
            for(int i=0;i<this.Repeater1.Items.Count-1;i++)
            {
                Label label2a = (Label)Repeater1.Items[i].FindControl("Label2");
                Label label2b = (Label)Repeater1.Items[i + 1].FindControl("Label2");
                string temp = "";
                LinkButton LinkButton2a = (LinkButton)Repeater1.Items[i].FindControl("LinkButton2");
                LinkButton LinkButton2b = (LinkButton)Repeater1.Items[i + 1].FindControl("LinkButton2");
                if (LinkButton2a.CommandArgument.ToString() == e.CommandArgument.ToString())
                {
                    //交换px
                    temp = label2a.Text;
                    label2a.Text = label2b.Text;
                    label2b.Text = temp;
                    //更新本条目录的px
                    product.productID = pid;
                    product = B_pro.getproducts(product);
                    product.px = int.Parse(label2a.Text);
                    B_pro.update(product);
                    //更新下一条目录的px
                    product.productID = int.Parse(LinkButton2b.CommandArgument.ToString()); ;
                    product = B_pro.getproducts(product);
                    product.px = int.Parse(label2b.Text);
                    B_pro.update(product);
                }
            }
            repeaterBind();
        }
        else if(e.CommandName=="up")
        {
            int pid = int.Parse(e.CommandArgument.ToString());
            for (int i = 1; i < this.Repeater1.Items.Count; i++)
            {
                Label label2a = (Label)Repeater1.Items[i].FindControl("Label2");
                Label label2b = (Label)Repeater1.Items[i - 1].FindControl("Label2");
                string temp = "";
                LinkButton ImageButton3a = (LinkButton)Repeater1.Items[i].FindControl("LinkButton3");
                LinkButton ImageButton3b = (LinkButton)Repeater1.Items[i - 1].FindControl("LinkButton3");
                if (ImageButton3a.CommandArgument.ToString() == e.CommandArgument.ToString())
                {
                    //交换px
                    temp = label2a.Text;
                    label2a.Text = label2b.Text;
                    label2b.Text = temp;
                    //更新本条目录的px
                    product.productID = pid;
                    product = B_pro.getproducts(product);
                    product.px = int.Parse(label2a.Text);
                    B_pro.update(product);
                    //更新下一条目录的px
                    product.productID = int.Parse(ImageButton3b.CommandArgument.ToString()); ;
                    product = B_pro.getproducts(product);
                    product.px = int.Parse(label2b.Text);
                    B_pro.update(product);
                }
                
            }
            repeaterBind();
        }

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //删除选中的产品数据
        for (int i = 0; i < Repeater1.Items.Count; i++)
        {
            CheckBox cb = (CheckBox)this.Repeater1.Items[i].FindControl("CheckBox1");
            if (cb.Checked)
            {
                Label la = (Label)this.Repeater1.Items[i].FindControl("Label1");
                int id = Convert.ToInt32(la.Text);
                bp.DelPro(id);
            
            }
        }
        ProBin("select * from tab_products,tab_productClass where tab_products.productClassID=tab_productClass.productClassID");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         this.labPage.Text = this.TextBox2.Text;

        databind("select * from tab_productClass,tab_products where tab_products.productClassID=tab_productClass.productClassID and tab_productClass.productClassID=tab_products.productClassID");
    
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    }
    protected void lnkbtnOne_Click(object sender, EventArgs e)
    {
        this.labPage.Text = "1";

        databind("select * from tab_productClass,tab_products where tab_products.productClassID=tab_productClass.productClassID and tab_productClass.productClassID=tab_products.productClassID");

        
        

    }
    protected void lnkbtnUp_Click(object sender, EventArgs e)
    {
        this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) - 1);

        databind("select * from tab_productClass,tab_products where tab_products.productClassID=tab_productClass.productClassID and tab_productClass.productClassID=tab_products.productClassID");

        
       
    }
    protected void lnkbtnBack_Click(object sender, EventArgs e)
    {
        this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) + 1);
        databind("select * from tab_productClass,tab_products where tab_products.productClassID=tab_productClass.productClassID and tab_productClass.productClassID=tab_products.productClassID");
        
      
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        this.labPage.Text = this.labBackPage.Text;

        databind("select * from tab_productClass,tab_products where tab_products.productClassID=tab_productClass.productClassID and tab_productClass.productClassID=tab_products.productClassID");

        
       
    }
    private void databind(string Sql)//datalist2数据绑定和分页
    {
        int curpage = Convert.ToInt32(this.labPage.Text);
        DataTable dt = B_pro.SelectPro(Sql);
        this.CountProLab.Text = dt.Rows.Count.ToString();
        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = dt.DefaultView;
        ps.AllowPaging = true;//可以分页
        ps.PageSize = 10;//页面大小
        ps.CurrentPageIndex = curpage - 1;//当前页
        this.lnkbtnUp.Enabled = true;
        this.lnkbtnNext.Enabled = true;
        this.lnkbtnBack.Enabled = true;
        this.lnkbtnOne.Enabled = true;
        if (curpage == 1)
        {
            this.lnkbtnOne.Enabled = false;//不显示第一页按钮
            this.lnkbtnUp.Enabled = false;//不显示上一页按钮
        }
        if (curpage == ps.PageCount)
        {
            this.lnkbtnNext.Enabled = false;//不显示下一页
            this.lnkbtnBack.Enabled = false;//不显示最后一页
        }
        this.labBackPage.Text = Convert.ToString(ps.PageCount);
        this.TextBox1.Text = this.labPage.Text;
        this.Repeater1.DataSource = ps;
        this.Repeater1.DataBind();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        this.labPage.Text = this.TextBox1.Text;

        databind("select * from tab_productClass,tab_products where tab_products.productClassID=tab_productClass.productClassID and tab_productClass.productClassID=tab_products.productClassID");
    }
}
