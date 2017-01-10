using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using Com.Alipay;
using System.Collections;
using System.Web.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


public partial class healthshop : PageBases
{
    Model.tab_product_class css = new Model.tab_product_class();
    Model.tab_customers modelCu = new Model.tab_customers();
    Bll.CustomerBll Cb = new Bll.CustomerBll();
    Bll.ProductBll pb = new Bll.ProductBll();
    DataTable g_itemsdt = new DataTable();
    public string addrclass = "display:none";
    void fillshopitem()
    {
        string s = Session["language"].ToString() == "zh-cn" ? "select productID,productName,productClassID,ikangName,ikangID,meinianName,meinianID,cimingNmae,cimingID,ex1Name,ex1ID,type,unit,uplimit,downlimit,productUnitPrice,productMarketPrice,productContent,productDate,productImg,productCount,msg,px from tab_products where type=N'商城' and unit='发布' and productID in( select   min( productID)  id from tab_products group by productName) order by px desc" :
            "select productID,productName_eng as productName,productClassID,ikangName_eng as ikangName,ikangID,meinianName_eng as meinianName,meinianID,cimingName_eng as cimingNmae,cimingID,ex1Name_eng as ex1Name,ex1ID_eng as ex1ID,type,unit,uplimit,downlimit_eng as downlimit,productUnitPrice,productMarketPrice,productContent_eng as productContent,productDate,productImg_eng as productImg,productCount,msg_eng as msg,px from tab_products where type=N'商城' and unit='发布' and productID in( select   min( productID)  id from tab_products group by productName) order by px desc";
        DataTable dt = pb.SelectPro(s);
        if (dt != null)
        {
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('没有商品')</script>");
            return;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request["language"] == null)
            {
                if (Session["language"] == null)
                {
                    Session["language"] = "zh-cn";
                }
            }
            else
            {
                Session["language"] = Request["language"];
            }
            this.CheckUser((Hashtable)Application["Online"]);
            fillshopitem();
            //return;
            initcity(sender, e);
            checkaddtocart();
            checktocart(sender, e);
        }
        if (this.Panel1.Visible)
        {

        }
        modelCu.customerID = int.Parse(Session["id"].ToString());
        modelCu = Cb.getCustomer(modelCu);

        if (this.Panel2.Visible)
        {
            filladdresses();
            this.Panel5.Visible = true;
        }
        else
        {
            this.Panel5.Visible = false;
        }

        //jiekong();
        //string shuzi = "182";
        //jieshu(shuzi);

    }
    public void jieshu(string shuzi)
    {
        //获取数据
        string url = "http://app.eshinelee.com/products.aspx";
        System.Collections.Specialized.NameValueCollection PostVars;
        PostVars = new System.Collections.Specialized.NameValueCollection();
        PostVars.Add("id",shuzi);
        string s = PublicClass.postrequest(url, PostVars);

        JavaScriptSerializer jss = new JavaScriptSerializer();
        Dictionary<string, object> json = (Dictionary<string, object>)jss.DeserializeObject(s);

        object value;
        if (json.TryGetValue("data", out value))
        {
            object[] array = (object[])value;
            for (int i = 0; i < array.Length; i++)
            {

                Dictionary<string, object> dd = (Dictionary<string, object>)array[i];
                switch (i)
                {
                    case 0: this.Label8.Text = dd["productName"].ToString(); break;
                    case 1: this.Label9.Text = dd["productName"].ToString(); break;
                    case 2: this.Label10.Text = dd["productName"].ToString(); break;
                    case 3: this.Label11.Text = dd["productName"].ToString(); break;
                    case 4: this.Label12.Text = dd["productName"].ToString(); break;
                    case 5: this.Label13.Text = dd["productName"].ToString(); break;
                    case 6: this.Label14.Text = dd["productName"].ToString(); break;
                }

            }

        }
       
    }

    public void jiekong()
    {
        //获取数据
        string url = "http://app.eshinelee.com/productClass.aspx";
        System.Collections.Specialized.NameValueCollection PostVars;
        PostVars = new System.Collections.Specialized.NameValueCollection();
        PostVars.Add("ID", "0");
        string s = PublicClass.postrequest(url, PostVars);

        JavaScriptSerializer jss = new JavaScriptSerializer();
        Dictionary<string, object> json = (Dictionary<string, object>)jss.DeserializeObject(s);

        object value;
        if (json.TryGetValue("data", out value))
        {
            object[] array = (object[])value;
            for (int i = 0; i < array.Length; i++)
            {

                Dictionary<string, object> dd = (Dictionary<string, object>)array[i];
                switch (i)
                {
                    case 0: this.Label1.Text = dd["productClassName"].ToString(); break;
                    case 1: this.Label2.Text = dd["productClassName"].ToString(); break;
                    case 2: this.Label3.Text = dd["productClassName"].ToString(); break;
                    case 3: this.Label4.Text = dd["productClassName"].ToString(); break;
                    case 4: this.Label5.Text = dd["productClassName"].ToString(); break;
                    case 5: this.Label6.Text = dd["productClassName"].ToString(); break;
                    case 6: this.Label7.Text = dd["productClassName"].ToString(); break;
                }

            }

        }
        
    }

    void checkaddtocart()
    {
        if (Session["cartitems"] == null)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id", Type.GetType("System.String"));
            dt1.Columns.Add("num", Type.GetType("System.String"));
            Session["cartitems"] = dt1;
        }
        DataTable dt = (DataTable)Session["cartitems"];



        if (Request["productID"] != null)
        {
            int num = 1;
            if (Request["addnum"] != null )
            {
                num = Convert.ToInt32(Request["addnum"]);
            }

            bool exist = false;
        
            for (int i=0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == Request["productID"].ToString())
                {
                    exist = true;
                    dt.Rows[i][1] = Convert.ToInt32(dt.Rows[i][1]) + num;
                    
                    break;
                }
            }

            if (!exist)
            {
                DataRow dr = dt.NewRow();
                dr[0] = Request["productID"];
                dr[1] = num;
                dt.Rows.Add(dr);
            }
            Session["cartitems"] = dt;
         
        }

        int totalitemnum = 0;
        for (int i=0; i < dt.Rows.Count; i++)
        {
            totalitemnum += Convert.ToInt32(dt.Rows[i][1]);
        }
        this.TextBox2.Text = totalitemnum.ToString();
        if (totalitemnum == 0)
        {
            this.Button2.Enabled = false;
        }
    }

    void checktocart(object sender, EventArgs e)
    {
        if (Request["tocart"] != null && Request["tocart"].ToString() == "true")
        {
            this.Button2_Click(sender, e);
        }
       
    }

    void fillcart()
    {
        DataTable dt = (DataTable)Session["cartitems"];


        if (dt.Rows.Count == 0)
        {
            this.Panel6.Visible = true;
            //this.Panel5.Visible = true;
            this.Panel1.Visible = false;
            return;
        }

        StringBuilder sb = new StringBuilder();
        StringBuilder orderbys = new StringBuilder();
        string s = Session["language"].ToString() == "zh-cn" ? "select productID,productName,productClassID,ikangName,ikangID,meinianName,meinianID,cimingNmae,cimingID,ex1Name,ex1ID,type,unit,uplimit,downlimit,productUnitPrice,productMarketPrice,productContent,productDate,productImg,productCount,msg,px from tab_products where productID in (" :
            "select productID,productName_eng as productName,productClassID,ikangName_eng as ikangName,ikangID,meinianName_eng as meinianName,meinianID,cimingName_eng as cimingNmae,cimingID,ex1Name_eng as ex1Name,ex1ID_eng as ex1ID,type,unit,uplimit,downlimit_eng as downlimit,productUnitPrice,productMarketPrice,productContent_eng as productContent,productDate,productImg_eng as productImg,productCount,msg_eng as msg,px from tab_products where productID in (";
        
        sb.Append(s);
        orderbys.Append(" order by charindex(rtrim(productID),'");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sb.Append(dt.Rows[i][0] + ",");
            orderbys.Append(dt.Rows[i][0] + ",");
        }
        if (dt.Rows.Count > 0)
        {
            sb.Remove(sb.Length - 1, 1);
            orderbys.Remove(orderbys.Length - 1, 1);
        }
        sb.Append(")");
        orderbys.Append("')");
        sb.Append(orderbys);
        g_itemsdt = dt;

        dt = pb.SelectPro(sb.ToString());
        if (dt != null)
        {
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('没有商品')</script>");
            return;
        }
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        this.Panel1.Visible = false;

        bool needshipping = false;
        DataTable dt = (DataTable)Session["cartitems"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (pb.getstring(dt.Rows[i][0].ToString(), "uplimit") != "电子码")
            {
                needshipping = true;
                break;
            }
        }
        if (needshipping)
        {
            filladdresses();
            this.Panel2.Visible = true;
            this.Panel5.Visible = true;
        }
        else
        {
            this.Button1_Click(sender, e);
        }
        
    }


    int numindex = 0;
    public string productName="";
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if(Session["language"]!=null&&Session["language"].ToString()=="zh-cn")
            {
                productName = "productName";
            }
            else
            {
                productName = "productName_eng";
            }
            //TextBox tbprice = (e.Row.Cells[2].FindControl("price") as TextBox);
            string tbprice = e.Row.Cells[2].Text;
            TextBox tbnum = (e.Row.Cells[1].FindControl("num") as TextBox);
            TextBox tbamt = (e.Row.Cells[2].FindControl("amt") as TextBox);

            tbnum.Text = g_itemsdt.Rows[numindex][1].ToString();
            numindex++;

            StringBuilder script = new StringBuilder();
            //输入数值之后总自动金额更新
            script.Append(" var amount=0;");
            script.Append(" vAmt=document.getElementById('" + tbamt.ClientID + "');");
            script.Append(" vNum=document.getElementById('" + tbnum.ClientID + "');");
            script.Append(" vPrice=" + tbprice + ";");
            script.Append("var amt=vPrice*parseFloat(vNum.value);");
            script.Append("vAmt.value=amt;");

            tbnum.Attributes.Add("onchange", script.ToString());
        }
    }
    //接收省份的集合
    DataSet ds_Province;
    //接收市的集合
    DataSet ds_City;
    //接收区的集合
    DataSet ds_Area;
    void initcity(object sender, EventArgs e)
    {
        ds_Province = DBHelper.GetSet("select * from province");
        for (int i = 0; i < ds_Province.Tables[0].Rows.Count; i++)
        {
            com_Province1.Items.Add(ds_Province.Tables[0].Rows[i][2].ToString());
        }
    }
    protected void com_Province1_SelectedIndexChanged(object sender, EventArgs e)
    {
        com_City1.Items.Clear();
        com_City1.Items.Add((string)GetGlobalResourceObject("GResource", "selectCity"));
        ds_City = DBHelper.GetSet(string.Format("select name from city where provinceId in (select code from province where name='{0}')", com_Province1.Text));
        if (ds_City.Tables[0].Rows.Count == 0)
            com_City1.Items.Add(com_Province1.Text);
        for (int i = 0; i < ds_City.Tables[0].Rows.Count; i++)
            com_City1.Items.Add(ds_City.Tables[0].Rows[i][0].ToString());
        com_City1.SelectedIndex = 0;
    }
    protected void com_City1_SelectedIndexChanged(object sender, EventArgs e)
    {
        com_Area1.Items.Clear();
        com_Area1.Items.Add((string)GetGlobalResourceObject("GResource", "selectZone"));
        ds_Area = DBHelper.GetSet(string.Format("select name from area where cityId in (select code from city where name='{0}')", com_City1.Text));
        if (ds_Area.Tables[0].Rows.Count == 0)
            com_Area1.Items.Add(com_City1.Text);
        for (int i = 0; i < ds_Area.Tables[0].Rows.Count; i++)
            com_Area1.Items.Add(ds_Area.Tables[0].Rows[i][0].ToString());
        com_Area1.SelectedIndex = 0;
    }
    private void filladdresses()
    {
        string address = modelCu.customerAllAddr;
        if (!string.IsNullOrEmpty(address))
        {
            bool setted = false;
            string[] sArray = address.Split('|');

            foreach (string s in sArray)
            {
                if (this.TextBoxPA.Text == "")
                {
                    this.TextBoxPA.Text = s;
                }
                Literal div = new Literal();
                div.Text = "<div>";
                Literal divend = new Literal();
                divend.Text = "</div>";

                this.Panel3.Controls.Add(div);
                RadioButton rbtn = new RadioButton();
                rbtn.GroupName = "reportaddr";
                rbtn.Text = (string)GetGlobalResourceObject("GResource", "Toaddress") + s;
                rbtn.Attributes.Add("class", "radiopaperaddr");
                if (!setted)
                {
                    rbtn.Checked = true;
                    setted = true;
                }
                this.Panel3.Controls.Add(rbtn);
                this.Panel3.Controls.Add(divend);
            }
        }
        else
        {
                this.RadioButton7.Checked = true;
                addrclass = "";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Bll.OrdersBll ob = new Bll.OrdersBll();
        Model.tab_orders orders = new Model.tab_orders();
        StringBuilder sb = new StringBuilder();

        DataTable dt = (DataTable)Session["cartitems"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sb.Append(dt.Rows[i][0] + "*" + dt.Rows[i][1]+";");
        }

        if (sb.Length > 0)
        {
            sb.Remove(sb.Length - 1, 1);
        }
        orders.customerName = modelCu.customerName;
        orders.personMobile = modelCu.customerMobile;
        orders.ReportContent = sb.ToString();
        orders.ReportType = "商城";
        double price = double.Parse(this.TextBox1.Text);
        
        orders.examBill = price;
        orders.orderDate = DateTime.Now;
        orders.personAddress = this.TextBoxPA.Text;
        orders.customerID = modelCu.customerID;
        orders.orderStatus = "待付款";
        int ordernum = ob.Add(orders);

        Session["cartitems"] = null;
        Response.Redirect("shopordersubmitted.aspx?oid=" + ordernum + "&price=" + orders.examBill);
        //goalipay(ordernum);
  
    }
    protected void Repeater1_DataBinding(object sender, EventArgs e)
    {
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel1.Visible = true;
        this.Panel4.Visible = false;
        fillcart();
    }
    public void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //updateitemsseesion();
    }


    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
        {
            DataRowView dv = e.Item.DataItem as DataRowView;
            //if (dv[17].ToString().Length > 98)
            //    ((HyperLink)e.Item.FindControl("HyperLink1")).Text = dv[17].ToString().Substring(0, 98);
            //else
                ((HyperLink)e.Item.FindControl("HyperLink1")).Text = dv[17].ToString();
            ((HyperLink)e.Item.FindControl("HyperLink1")).NavigateUrl = "viewshopitem_multi.aspx?productID="+dv[0].ToString();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        this.Panel6.Visible = false;
        //this.Panel5.Visible = false;
        this.Panel4.Visible = true;
    }
}