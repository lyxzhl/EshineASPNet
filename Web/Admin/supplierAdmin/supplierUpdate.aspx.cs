using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_supplierAdmin_supplierUpdate : System.Web.UI.Page
{
    Bll.SupplierBll sb = new Bll.SupplierBll();
    Model.tab_suppliers modelsb = new Model.tab_suppliers();
    PublicClass pc = new PublicClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["supid"] = Request.QueryString["Cid"];
            modelsb.id = Convert.ToInt32(ViewState["supid"].ToString());
            modelsb = sb.getsuppliers(modelsb);
            this.TextBox1.Text = modelsb.supplier;
            this.TextBox9.Text = modelsb.hospid;
            this.TextBox2.Text = modelsb.province;
            this.TextBox3.Text = modelsb.city;
            this.TextBox7.Text = modelsb.branch;
            this.TextBox6.Text = modelsb.phone;
            this.TextBox4.Text = modelsb.address;
            this.TextBox5.Text = modelsb.note;
            //this.TextBox8.Text = modelsb.map;
            this.TextBox10.Text = modelsb.type;
            this.TextBox11.Text = modelsb.lat;
            this.TextBox12.Text = modelsb.lng;
            //string sgm = "http://ditu.google.cn/maps?q=" + Server.UrlEncode(modelsb.branch) + "&hl=zh-CN&ie=UTF8"
            //+ "&ll=" + modelsb.lat + "," + modelsb.lng + "&hq=" + Server.UrlEncode(modelsb.address) + "&z=15";
            string sgm = "baidumap.aspx?lng=" + modelsb.lng + "&lat=" + modelsb.lat + "";
            this.HyperLink1.NavigateUrl = sgm;
            this.TextBox8.Text = sgm;

            //Button3_Click(sender, e);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("supplierinfo.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        modelsb.supplier = this.TextBox1.Text;
        modelsb.hospid = this.TextBox9.Text;
        modelsb.province = this.TextBox2.Text;
        modelsb.city = this.TextBox3.Text;
        modelsb.branch = this.TextBox7.Text;
        modelsb.phone = this.TextBox6.Text;
        modelsb.address = this.TextBox4.Text;
        modelsb.note = this.TextBox5.Text;
        //modelsb.map = this.TextBox8.Text;
        modelsb.hospid = this.TextBox9.Text;
        modelsb.type = this.TextBox10.Text;
        modelsb.lat = this.TextBox11.Text;
        modelsb.lng = this.TextBox12.Text;
        modelsb.id = Convert.ToInt32(ViewState["supid"].ToString());
        int i = sb.update(modelsb);
        if (i != 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('更新成功');location='supplierinfo.aspx'</script>");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Literal li = new Literal();
        if (this.TextBox8.Text.Contains("iframe"))
        {
            
            li.Text = this.TextBox8.Text;
            this.Panel1.Controls.Add(li);
        }
        else if (this.TextBox8.Text.Contains("http"))
        {
            li.Text = "<iframe src='"+this.TextBox8.Text+"'  height='800' width='1280'></iframe>";
            this.Panel1.Height = 400;
            this.Panel1.Controls.Add(li);
        }
        
    }

}