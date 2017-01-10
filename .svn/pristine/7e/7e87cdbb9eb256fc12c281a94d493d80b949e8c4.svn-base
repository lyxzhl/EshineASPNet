using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_companyAdmin_companyUpdate : System.Web.UI.Page
{
    Bll.companyBll cb = new Bll.companyBll();
    Model.tab_company modelcp = new Model.tab_company();
    DBunit.SQLAccess dbsql = new DBunit.SQLAccess();


    PublicClass pc = new PublicClass();
    upImage ui = new upImage();

    //接收省份的集合
    DataSet ds_Province;
    //接收市的集合
    DataSet ds_City;
    //接收区的集合
    DataSet ds_Area;
    void initcity(object sender, EventArgs e)
    {
        try
        {

            ds_Province = DBHelper.GetSet("select * from province");
            for (int i = 0; i < ds_Province.Tables[0].Rows.Count; i++)
            {
                com_Province.Items.Add(ds_Province.Tables[0].Rows[i][2].ToString());
            }
            int proindex, cityindex,areaindex;
            if (modelcp.CompanyProvince != "")
            {
                proindex = this.com_Province.Items.IndexOf(this.com_Province.Items.FindByText(modelcp.CompanyProvince));
                if (proindex > 0)
                {
                    com_Province.SelectedIndex = proindex;
                    com_Province_SelectedIndexChanged(sender, e);
                    if (modelcp.CompanyCity != "")
                    {
                        cityindex = this.com_City.Items.IndexOf(this.com_City.Items.FindByText(modelcp.CompanyCity));
                        if (cityindex > 0)
                        {
                            com_City.SelectedIndex = cityindex;
                            com_City_SelectedIndexChanged(sender, e);
                            if (modelcp.CompanyZone != "")
                            {
                                areaindex = this.com_Area.Items.IndexOf(this.com_Area.Items.FindByText(modelcp.CompanyZone));
                                if (areaindex > 0)
                                {
                                    com_Area.SelectedIndex = areaindex;
                                }
                            }
                        }
                    }
                }

            }
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('数据库连接错误 .')</script>");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["newcompany"] != null && Request.QueryString["newcompany"].ToString() == "yes")
            {
                this.Label1.Text = "新增公司";
                this.Button1.Visible = false;
                this.Button4.Visible = true;
            }
            else
            {
                ViewState["companyID"] = Request.QueryString["Cid"];
                modelcp.id = Convert.ToInt32(ViewState["companyID"]);
                modelcp = cb.getcompany(modelcp);
                this.TextBox1.Text = modelcp.CompanyName;
                this.HyperLink1.NavigateUrl = "~/Admin/companyAdmin/companyDeliveryaddress.aspx?companyname=" + modelcp.CompanyName;
                this.TextBox2.Text = modelcp.CompanyShortName;
                this.TextBox3.Text = modelcp.CompanyAbbreviation;
                this.TextBox4.Text = modelcp.Companycode;
                this.TextBox5.Text = modelcp.CompanyAddress;
                this.TextBox7.Text = modelcp.CompanyAvaiSuppProv;
                this.TextBox8.Text = modelcp.CompanyAvaiSuppCity;
                this.TextBox9.Text = modelcp.CompanyAvailableSupplier;
                this.TextBox11.Text = modelcp.currentperiod;
                this.TextBox13.Text = modelcp.CompanyLogo;//用来当体检类型了
                this.TextBox6.Text = modelcp.CompanyAvaiSuppProvRel;
                this.TextBox12.Text = modelcp.CompanyAvaiSuppCityRel;
                this.TextBox14.Text = modelcp.CompanyAvaiSupplierRel;
                this.TextBox15.Text = modelcp.reservestartdate.ToString();

                this.TextBox16.Text = modelcp.standby1;
                if (modelcp.standby2 == "1")//妇科项目付费
                {
                    this.CheckBox5.Checked = true;
                }
                else
                {
                    this.CheckBox5.Checked = false;
                }

                this.CheckBox6.Checked = modelcp.canxiya == "0" ? false : true;
                this.CheckBox7.Checked = modelcp.canhomepayge == "0" ? false : true;
                this.CheckBox8.Checked = modelcp.canuploadreport == "0" ? false : true;
                this.CheckBox9.Checked = modelcp.standby4 == "0" ? false : true;
                this.CheckBox10.Checked = modelcp.standby5 == "0" ? false : true;
                this.TextBox17.Text = modelcp.xiyaSupplier;
                

                if (modelcp.canfrontpay == "0") CheckBox2.Checked = false;
                if (modelcp.canduallanguage == "0") CheckBox1.Checked = false;
                if (modelcp.candilivertocompany == "0") CheckBox3.Checked = false;
                if (modelcp.canplatformpay == "0") CheckBox4.Checked = false;
                if (modelcp.standby5 == "0") CheckBox10.Checked = false; 
                initcity(sender, e);
            }
        }
        else
        {
            if (ViewState["companyID"] != null && ViewState["companyID"].ToString() != "")
            {
                modelcp.id = Convert.ToInt32(ViewState["companyID"]);
                modelcp = cb.getcompany(modelcp);
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("companyInfo.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillcommonmodel();
  
        int i = cb.update(modelcp);
        if (i != 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('更新成功');location='companyInfo.aspx'</script>");
        }
    }

    void fillcommonmodel()
    {
        modelcp.CompanyName = this.TextBox1.Text;
        modelcp.CompanyShortName = this.TextBox2.Text;
        modelcp.CompanyAbbreviation = this.TextBox3.Text;
        modelcp.Companycode = this.TextBox4.Text;
        modelcp.CompanyAddress = this.TextBox5.Text;
        modelcp.CompanyAvaiSuppProv = this.TextBox7.Text.Replace("'", "''");
        modelcp.CompanyAvaiSuppCity = this.TextBox8.Text.Replace("'", "''");
        modelcp.CompanyAvailableSupplier = this.TextBox9.Text;
        modelcp.currentperiod = this.TextBox11.Text;
        modelcp.CompanyLogo = this.TextBox13.Text;
        modelcp.canduallanguage = CheckBox1.Checked ? "1" : "0";
        modelcp.canfrontpay = CheckBox2.Checked ? "1" : "0";
        modelcp.candilivertocompany = CheckBox3.Checked ? "1" : "0";
        modelcp.CompanyAvaiSuppProvRel = this.TextBox6.Text.Replace("'", "''");
        modelcp.CompanyAvaiSuppCityRel = this.TextBox12.Text.Replace("'", "''");
        modelcp.CompanyAvaiSupplierRel = this.TextBox14.Text;
        modelcp.reservestartdate = DateTime.Parse( this.TextBox15.Text);
        modelcp.canplatformpay = CheckBox4.Checked ? "1" : "0";
        modelcp.standby1 = this.TextBox16.Text;
        modelcp.standby2 = this.CheckBox5.Checked ? "1" : "0";
        modelcp.canxiya = this.CheckBox6.Checked ? "1" : "0";
        modelcp.xiyaSupplier = this.TextBox17.Text;
        modelcp.canhomepayge = this.CheckBox7.Checked ? "1" : "0";
        modelcp.canuploadreport = this.CheckBox8.Checked ? "1" : "0";
        modelcp.standby4 = this.CheckBox9.Checked ? "1" : "0";
        modelcp.standby5 = this.CheckBox10.Checked ? "1" : "0";
        modelcp.standby6 = this.TextBox18.Text;
        //if (this.File1.Value != null && this.File1.Value != "")
        //{
        //    modelcp.CompanyLogo = "~/Images/companyimg/" + ui.GetFileName(this.File1);
        //    ui.SaveUpFile(Server.MapPath("~/Images/companyimg") + "\\" + ui.GetFileName(this.File1), this.File1);
        //}
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

        fillcommonmodel();
        int i = cb.Add(modelcp);
        if (i != 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('添加成功');location='companyInfo.aspx'</script>");
        }
    }

    protected void com_Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        com_City.Items.Clear();
        com_City.Items.Add("请选择市");
        ds_City = DBHelper.GetSet(string.Format("select name from city where provinceId in (select code from province where name='{0}')", com_Province.Text));
        if (ds_City.Tables[0].Rows.Count == 0)
            com_City.Items.Add(com_Province.Text);
        for (int i = 0; i < ds_City.Tables[0].Rows.Count; i++)
            com_City.Items.Add(ds_City.Tables[0].Rows[i][0].ToString());
        com_City.SelectedIndex = 0;
    }
    protected void com_City_SelectedIndexChanged(object sender, EventArgs e)
    {
        com_Area.Items.Clear();
        com_Area.Items.Add("请选择区");
        ds_Area = DBHelper.GetSet(string.Format("select name from area where cityId in (select code from city where name='{0}')", com_City.Text));
        if (ds_Area.Tables[0].Rows.Count == 0)
            com_Area.Items.Add(com_City.Text);
        for (int i = 0; i < ds_Area.Tables[0].Rows.Count; i++)
            com_Area.Items.Add(ds_Area.Tables[0].Rows[i][0].ToString());
        com_Area.SelectedIndex = 0;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (this.RadioButton3.Checked && this.TextBox10.Text=="")
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('请填写初始化密码！');</script>");
            return;
        }
        Model.tab_customers cus = new Model.tab_customers();
        Bll.CustomerBll cusb=new Bll.CustomerBll();
        string s = "select customerID, customerCode,customerIDcard from tab_customers where customerCompanycode='" + modelcp.Companycode + "'";
        DataTable dt = dbsql.ExecuteDataSet(s).Tables[0];
        string pw="123456";
        string idcard;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            cus.customerID = Convert.ToInt32(dt.Rows[i]["customerID"]);
            cus = cusb.getCustomer(cus);
            cus.customerPwd = "";

            if (this.RadioButton1.Checked)
            {
                pw = dt.Rows[i]["customerCode"].ToString();
            }
            else if (this.RadioButton2.Checked)
            {
                idcard = dt.Rows[i]["customerIDcard"].ToString();
                if (idcard.Length < 6)
                {
                    idcard = "123456";
                }
                else
                {
                    idcard = idcard.Substring(idcard.Length - 6, 6);
                }
                pw = idcard;
            }
            else if(this.RadioButton3.Checked)
            {
                pw = this.TextBox10.Text;
            }
            cus.customerPwd = pc.md5(pw);
            cusb.update(cus);
        }

        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('初始化密码完成！');</script>");
    }
}