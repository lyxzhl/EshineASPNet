using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class viewshopitem_multi : PageBases
{
    public string content = "员工身体健康是公司最大的财富";
    public string shuoming = "";
    public string parameter = "";
    public string brandintro = "";
    public string shuomingclass = "";
    public string parameterclass = "";
    public string brandintroclass = "";
    
    public string sameproduct = "";
    public string displayimg = "";
    public string allpics = "";
    public string picnum = "1";
    public string itemid;
    Bll.ProductBll pb = new Bll.ProductBll();
    Bll.shopSupplierBll sb = new Bll.shopSupplierBll();
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
            //this.CheckUser((Hashtable)Application["Online"]);
            init(sender,e);
        }
        else
        {
            loadcontent();
        }
        if (this.com_Province.SelectedIndex > 0)
        {
            com_Province_SelectedIndexChanged(sender, e);
        }
        
    }
    void init(object sender, EventArgs e)
    {
        if (Request.QueryString["productID"] != null)
        {
            ViewState["shopitemid"] = Request.QueryString["productID"];
            Session["currentproductid"] = ViewState["shopitemid"];
        }
        else
        {
            if (Session["currentproductid"] != null)
            {
                ViewState["shopitemid"] = Session["currentproductid"];
            }
        }


        string s = Session["language"].ToString() == "zh-cn" ? "select productID,productName,productClassID,ikangName,ikangID,meinianName,meinianID,cimingNmae,cimingID,ex1Name,ex1ID,type,unit,uplimit,downlimit,productUnitPrice,productMarketPrice,productContent,productDate,productImg,productCount,msg,px from tab_products where type=N'商城' and productID=" + ViewState["shopitemid"] :
            "select productID,productName_eng as productName,productClassID,ikangName_eng as ikangName,ikangID,meinianName_eng as meinianName,meinianID,cimingName_eng as cimingNmae,cimingID,ex1Name_eng as ex1Name,ex1ID_eng as ex1ID,type,unit,uplimit,downlimit_eng as downlimit,productUnitPrice,productMarketPrice,productContent_eng as productContent,productDate,productImg_eng as productImg,productCount,msg_eng as msg,px from tab_products where type=N'商城' and productID=" + ViewState["shopitemid"];
        DataTable dt = pb.SelectPro(s);
        //this.Label1.Text = DateTime.Parse(dt.Rows[0]["productDate"].ToString()).ToShortDateString();
        //this.HyperLink1.NavigateUrl = this.HyperLink2.NavigateUrl = "#";
        this.Label1.Text = dt.Rows[0]["productName"].ToString();
        content = dt.Rows[0]["msg"].ToString();
        shuoming = dt.Rows[0]["ikangName"].ToString();
        parameter = dt.Rows[0]["meinianName"].ToString();
        brandintro = dt.Rows[0]["cimingNmae"].ToString();
        if (shuoming == "") shuomingclass = "hide";
        if (parameter == "") parameterclass = "hide";
        if (brandintro == "") brandintroclass = "hide";



        displayimg = dt.Rows[0]["productImg"].ToString();

        int productCount=Convert.ToInt32(dt.Rows[0]["productCount"]) ;
        if (productCount < this.NumericUpDownExtender1.Maximum)
        {
            this.NumericUpDownExtender1.Maximum = productCount;
        }
        if (productCount<= 0)
        {
            this.paybutton.Attributes["class"] = "xbtn_cart_disabled";
            this.num.Text = "0";
            this.num.Enabled = false;
           
        }
        this.Label4.Text=this.Label2.Text = dt.Rows[0]["productUnitPrice"].ToString();
        this.Label3.Text = dt.Rows[0]["ex1ID"].ToString(); //品类
        this.Label6.Text = dt.Rows[0]["productMarketPrice"].ToString();

        


        itemid = ViewState["shopitemid"].ToString();
        fillsameproduct(dt.Rows[0]["productName"].ToString());
        fillpics(dt.Rows[0]["ex1Name"].ToString());
        if (Session["cartitems"] != null && ((DataTable)Session["cartitems"]).Rows.Count>0)
        {
            this.Label5.Text = caltotalprice().ToString();
        }
        else
        {
            this.Label5.Text = "0";
        }
        if (this.Label5.Text != "0")
        {
            this.HyperLink2.NavigateUrl = "healthshop.aspx?tocart=true";
            
        }

        dt = sb.GetAny("select distinct province from tab_shopsuppliers where hospid='" + ViewState["shopitemid"] + "' ");
        for (int i = 0; i < dt.Rows.Count; i++)
            this.com_Province.Items.Add(dt.Rows[i][0].ToString());
        if (dt.Rows.Count > 0)
        {
            this.com_Province.SelectedIndex = 1;
            
        }
        else
        {
            this.Panel1.Visible = false;
        }
    }

    void loadcontent()
    {
        string s = Session["language"].ToString() == "zh-cn" ? "select productID,productName,productClassID,ikangName,ikangID,meinianName,meinianID,cimingNmae,cimingID,ex1Name,ex1ID,type,unit,uplimit,downlimit,productUnitPrice,productMarketPrice,productContent,productDate,productImg,productCount,msg,px from tab_products where type=N'商城' and productID=" + ViewState["shopitemid"] :
            "select productID,productName_eng as productName,productClassID,ikangName_eng as ikangName,ikangID,meinianName_eng as meinianName,meinianID,cimingName_eng as cimingNmae,cimingID,ex1Name_eng as ex1Name,ex1ID_eng as ex1ID,type,unit,uplimit,downlimit_eng as downlimit,productUnitPrice,productMarketPrice,productContent_eng as productContent,productDate,productImg_eng as productImg,productCount,msg_eng as msg,px from tab_products where type=N'商城' and productID=" + ViewState["shopitemid"];
        
        DataTable dt = pb.SelectPro(s);
        content = dt.Rows[0]["msg"].ToString();
        shuoming = dt.Rows[0]["ikangName"].ToString();
        parameter = dt.Rows[0]["meinianName"].ToString();
        brandintro = dt.Rows[0]["cimingNmae"].ToString();
        if (shuoming == "") shuomingclass = "hide";
        if (parameter == "") parameterclass = "hide";
        if (brandintro == "") brandintroclass = "hide";

        displayimg = dt.Rows[0]["productImg"].ToString();
        fillsameproduct(dt.Rows[0]["productName"].ToString());
        fillpics(dt.Rows[0]["ex1Name"].ToString());
    }
    void fillsameproduct(string name)
    {
        string s = Session["language"].ToString() == "zh-cn" ? "select productID,productName,productClassID,ikangName,ikangID,meinianName,meinianID,cimingNmae,cimingID,ex1Name,ex1ID,type,unit,uplimit,downlimit,productUnitPrice,productMarketPrice,productContent,productDate,productImg,productCount,msg,px from tab_products where type=N'商城' and unit='发布' and productName=N'" + name + "'" :
            "select productID,productName_eng as productName,productClassID,ikangName_eng as ikangName,ikangID,meinianName_eng as meinianName,meinianID,cimingName_eng as cimingNmae,cimingID,ex1Name_eng as ex1Name,ex1ID_eng as ex1ID,type,unit,uplimit,downlimit_eng as downlimit,productUnitPrice,productMarketPrice,productContent_eng as productContent,productDate,productImg_eng as productImg,productCount,msg_eng as msg,px from tab_products where type=N'商城' and unit='发布' and productName_eng=N'" + name + "'";
        
        DataTable dt = pb.SelectPro(s);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (ViewState["shopitemid"].ToString() == dt.Rows[i]["productID"].ToString())
            {
                sb.Append("<li class='xoption xoption_selected'>");
                sb.AppendLine("<a href='#' hidefocus='true'>");
            }
            else
            {
                sb.Append("<li class='xoption'>");
                sb.AppendLine("<a href='viewshopitem_multi.aspx?productID=" + dt.Rows[i]["productID"] + "' hidefocus='true'>");
            }
            
            sb.AppendLine("<img src='" + dt.Rows[i]["productImg"] + "' width='30' height='30'>");
            sb.AppendLine("<span class='xoption_val'>" + dt.Rows[i]["ex1ID"] + "</span>");
            if (ViewState["shopitemid"].ToString() == dt.Rows[i]["productID"].ToString())
            {
                sb.Append("<i class='xoption_ico_selected'></i>");
            }
            sb.AppendLine("</a></li>");
        }
        sameproduct = sb.ToString();
    }

    void fillpics(string allpic)
    {
        if (allpic == "") return;
        StringBuilder sb = new StringBuilder();
        string[] simg = allpic.Split(';');

        picnum = (simg.Length + 1).ToString();

        for (int i = 0; i < simg.Length; i++)
        {
            sb.AppendLine("<li idx='"+(i+1).ToString()+"'><a href='javascript:' hidefocus='true'>");
            sb.AppendLine("<img src='"+simg[i]+"'></a></li>");
        }
        allpics = sb.ToString();
    }

    protected void buyme_ServerClick(object sender, EventArgs e)
    {
        if (this.num.Text == "0")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请选择商品数量！');</script>");
            return;
        }
        checkaddtocart();
        //Response.Redirect("healthshop.aspx?tocart=true&productID=" + ViewState["shopitemid"]+"&addnum="+this.num.Text);
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
        if (ViewState["shopitemid"] != null)
        {
            int num = Convert.ToInt32(this.num.Text);

            bool exist = false;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == ViewState["shopitemid"].ToString())
                {
                    exist = true;
                    dt.Rows[i][1] = Convert.ToInt32(dt.Rows[i][1]) + num;

                    break;
                }
            }

            if (!exist)
            {
                DataRow dr = dt.NewRow();
                dr[0] = ViewState["shopitemid"];
                dr[1] = num;
                dt.Rows.Add(dr);
            }
            Session["cartitems"] = dt;

        }

        this.Label5.Text = caltotalprice().ToString();
        if (this.Label5.Text != "0")
        {
            this.HyperLink2.NavigateUrl = "healthshop.aspx?tocart=true";
            Session["viewshopitem_multiPrice"] = this.Label5.Text;
        }

    }

    public double caltotalprice()
    {
        DataTable dt = (DataTable)Session["cartitems"];
        StringBuilder sb = new StringBuilder();
        StringBuilder orderbys = new StringBuilder();
        sb.Append("select productUnitPrice from tab_products where productID in (");
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
        //g_itemsdt = dt;

        DataTable pricedt = pb.SelectPro(sb.ToString());
        double totalprice=0;
        for (int i = 0; i < pricedt.Rows.Count; i++)
        {
            totalprice += Convert.ToDouble(pricedt.Rows[i][0]) * Convert.ToInt32(dt.Rows[i][1]);
        }
        return totalprice;

    }

    protected void com_Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        Province_SelectedIndexChanged();

        fillbranch();

    }
    protected void com_City_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillbranch();
    }

    public string contentlist1, contentlist2, contentlist3;
    public void fillbranch()
    {

        contentlist1 = contentlist2 = contentlist3 = "";
        int index = 0;
        string letter, lilist = "", ballooncontent;
        int itemik = 0, itemcm = 0, itemmn = 0;
        int count = 0;

        string s = "select * from tab_shopsuppliers where hospid='" + ViewState["shopitemid"] + "'";
        if (this.com_Province.SelectedIndex > 0)
        {
            s += " and province='" + this.com_Province.SelectedItem.Text + "'";
        }
        if (this.com_City.SelectedIndex > 0)
        {
            s += " and city='" + this.com_City.SelectedItem.Text + "'";
        }
        DataTable dt = sb.GetAny(s);

   

        foreach (DataRow dr in dt.Rows)
        {
            lilist = fillsupplierlist( dr["supplier"].ToString(), dr["branch"].ToString(), dr["address"].ToString()) + "\n\n";
          



            if (count%3== 0)
            {
                contentlist1 += lilist;
            }
            else if (count % 3 == 1)
            {
                contentlist2 += lilist;
            }
            else if (count % 3 == 2)
            {
                contentlist3 += lilist;
            }
            count++;
        }


    }

    public string fillsupplierlist(string supplier, string branch, string address)
    {
        string lilist;
        lilist = "<LI ><a style='width:287px;'><DIV class='store'><DIV ></DIV><LABEL  style='text-align:left;' >";


        lilist += "<H4><span >" + branch + "</span></H4>";

        lilist += "<H5 style=\"width:270px;\">" + address + "</H5></LABEL></DIV></a></LI>";
   
        return lilist;
    }

    public void Province_SelectedIndexChanged()
    {
        com_City.Items.Clear();
        com_City.Items.Add((string)GetGlobalResourceObject("GResource", "com_CityResource1"));
        string s="select distinct city from tab_shopsuppliers where hospid='" + ViewState["shopitemid"] + "' ";
        if(this.com_Province.SelectedIndex>0)
        {
            s+=" and province='"+this.com_Province.SelectedItem.Text+"'";
        }
        DataTable dt = sb.GetAny(s);
        if (dt.Rows.Count == 0)
        {
            com_City.Items.Add(com_Province.Text);
        }
        else
        {
            for (int i = 0; i < dt.Rows.Count; i++)
                com_City.Items.Add(dt.Rows[i][0].ToString());
        }
        com_City.SelectedIndex = 0;

    }
}