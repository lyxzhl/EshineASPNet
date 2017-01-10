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

public partial class Admin_CustomersAdmin_customersUpdate : System.Web.UI.Page
{
    Bll.CustomerBll cb = new Bll.CustomerBll();
    Model.tab_customers modelCu = new Model.tab_customers();
    PublicClass pc = new PublicClass();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {



            ViewState["cusID"] = Request.QueryString["Cid"];

            Session["id"] = ViewState["cusID"];
            modelCu.customerID = Convert.ToInt32( ViewState["cusID"]);
            modelCu = cb.getCustomer(modelCu);
            Session["cus"] = modelCu.customerName;
            Session["Companycode"] = modelCu.customerCompanycode;
            Session["Company"] = modelCu.customerCompany;
            
        }
        modelCu.customerID = Convert.ToInt32(ViewState["cusID"].ToString());
        modelCu = cb.getCustomer(modelCu);
        if (!Page.IsPostBack)
        {
            

            init();
            displayage();
            initcityDilivery(sender,e);
        }
        
        filladdresses();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (this.RadioButton1.Checked)
            modelCu.customerGender = "男";
        else if (this.RadioButton2.Checked)
            modelCu.customerGender = "女";

        if (this.RadioButton3.Checked)
            modelCu.customerMarriageStatus = "未婚";
        else if (this.RadioButton4.Checked)
            modelCu.customerMarriageStatus = "已婚";
        modelCu.customerDOB = DateTime.Parse(DropDownListYear.SelectedValue + "-" + DropDownListMonth.SelectedValue + "-" + DropDownListDay.SelectedValue);//出生日期
        modelCu.customerNation = this.TextBox13.Text;
        modelCu.customerIDcard = this.TextBox3.Text != "" ? this.TextBox3.Text : this.TextBox5.Text;
        modelCu.customerMobile = this.TextBox4.Text;
        modelCu.customerCompany = this.TextBox7.Text;
        modelCu.customerCode = this.TextBox8.Text;
        modelCu.customerEmail = this.TextBox9.Text;
        modelCu.customerPrivateEmail = this.TextBox2.Text;
        modelCu.customerCompanyTel = this.TextBox10.Text;
        modelCu.customerCompanyAddress = this.TextBox11.Text;
        modelCu.customerCompanyBU = this.TextBox12.Text;
        modelCu.customerName = this.TextBox1.Text;
        modelCu.packagecode = this.TextBox21.Text;

        modelCu.customerBalance = double.Parse(this.TextBox14.Text);
        modelCu.customerVIP = this.TextBox15.Text;
        modelCu.customerBudget = double.Parse(this.TextBox19.Text);
        if (this.com_Province1.SelectedIndex > 0)
        {
            modelCu.customerProvince = this.com_Province1.SelectedValue;
            if (this.com_City1.SelectedIndex > 0)
            {
                modelCu.customerCity = this.com_City1.SelectedValue;
                if (this.com_Area1.SelectedIndex > 0)
                {
                    modelCu.customerZone = this.com_Area1.SelectedValue;
                }
            }
        }

        int i= cb.update(modelCu);
        if (i == 1)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('更新成功');</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('更新失败');</script>");
        }
    }
    void init()
    {

        this.TextBox1.Text = modelCu.customerName;
        this.TextBox2.Text = modelCu.customerPrivateEmail;
        this.TextBox19.Text = modelCu.customerBudget.ToString();
        if (modelCu.customerIDcard != "")
        {
            if (modelCu.customerIDcard.Length == 18)
            {
                this.TextBox3.Text = modelCu.customerIDcard;
            }
            else
            {
                this.TextBox5.Text = modelCu.customerIDcard;
            }
        }
        this.TextBox4.Text = modelCu.customerMobile;
        this.TextBox13.Text = modelCu.customerNation;
        this.TextBox7.Text = modelCu.customerCompany;
        this.TextBox8.Text = modelCu.customerCode;
        this.TextBox9.Text = modelCu.customerEmail;
        this.TextBox10.Text = modelCu.customerCompanyTel;
        this.TextBox11.Text = modelCu.customerCompanyAddress;
        this.TextBox12.Text = modelCu.customerCompanyBU;

        this.TextBox14.Text = modelCu.customerBalance.ToString();
        this.TextBox15.Text = modelCu.customerVIP;
        this.TextBox16.Text = modelCu.customerSafeQ1;
        this.TextBox17.Text = modelCu.customerLastLogin.ToString();
        this.TextBox18.Text = modelCu.customerLastPWChanged.ToString();
        this.TextBox21.Text = modelCu.packagecode.ToString();


        if (modelCu.customerGender == "男")
        {
            this.RadioButton1.Checked = true;
        }
        else if (modelCu.customerGender == "女")
        {
            this.RadioButton2.Checked = true;
        }

        if (modelCu.customerMarriageStatus == "未婚")
        {
            this.RadioButton3.Checked = true;
        }
        else if (modelCu.customerMarriageStatus == "已婚")
        {
            this.RadioButton4.Checked = true;
        }
    }
    void displayage()
    {
        int year = 1900, month = 0, day = 0, age = 0;
        if (this.TextBox3.Text != "" && this.TextBox3.Text.Length == 18)
        {
            year = int.Parse(this.TextBox3.Text.Substring(6, 4));
            month = int.Parse(this.TextBox3.Text.Substring(10, 2));
            day = int.Parse(this.TextBox3.Text.Substring(12, 2));
            age = DateTime.Now.Year - year;

            if (int.Parse(this.TextBox3.Text.Substring(16, 1)) % 2 != 0)
            {
                this.RadioButton1.Checked = true;
            }
            else
            {
                this.RadioButton1.Checked = false;
            }
        }
        else
        {
            if (modelCu.customerDOB != null && modelCu.customerDOB != pc.baddate)
            {
                year = modelCu.customerDOB.Year;
                month = modelCu.customerDOB.Month;
                day = modelCu.customerDOB.Day;
                age = DateTime.Now.Year - year;
            }
        }
        if (age > 1)
        {
            this.TextBox6.Text = age.ToString();
            DropDownListYear.SelectedIndex = DropDownListYear.Items.IndexOf(DropDownListYear.Items.FindByText(year.ToString()));
            DropDownListMonth.SelectedIndex = DropDownListMonth.Items.IndexOf(DropDownListMonth.Items.FindByText(month.ToString()));
            DropDownListDay.SelectedIndex = DropDownListDay.Items.IndexOf(DropDownListDay.Items.FindByText(day.ToString()));
        }

    }
    private void filladdresses()
    {
        
        string address = modelCu.customerAllAddr;
        if (modelCu.customerAllAddr == null || modelCu.customerAllAddr == "")
        {
            this.no_addresses.InnerText = (string)GetGlobalResourceObject("GResource", "nosavedaddress");
        }
        else
        {
            string[] sArray;
            sArray = address.Split('|');
            foreach (string s in sArray)
            {
                Table t = new Table();
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.CssClass = "address";
                cell1.Text = s;

                row.Controls.Add(cell1);
                t.Controls.Add(row);

                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Controls.Add(t);
                this.all_addresses.Controls.Add(li);
            }
        }
    }
    void initcityDilivery(object sender, EventArgs e)
    {
        try
        {

            ds_Province = DBHelper.GetSet("select * from province");
            for (int i = 0; i < ds_Province.Tables[0].Rows.Count; i++)
            {
                com_Province1.Items.Add(ds_Province.Tables[0].Rows[i][2].ToString());
            }
            int proindex, cityindex;
            string province = "", city = "";
            if (modelCu.customerProvince != "")
            {
                province = modelCu.customerProvince;
            }

            if (modelCu.customerCity != "")
            {
                city = modelCu.customerCity;
            }

            if (province != "")
            {
                proindex = this.com_Province1.Items.IndexOf(this.com_Province1.Items.FindByText(province));
                if (proindex > 0)
                {
                    com_Province1.SelectedIndex = proindex;
                    com_Province1_SelectedIndexChanged(sender, e);
                    if (city != "")
                    {
                        cityindex = this.com_City1.Items.IndexOf(this.com_City1.Items.FindByText(city));
                        if (cityindex > 0)
                        {
                            com_City1.SelectedIndex = cityindex;
                            com_City1_SelectedIndexChanged(sender, e);
                            if (modelCu.customerZone != "")
                            {
                                int zoneindex = this.com_Area1.Items.IndexOf(this.com_Area1.Items.FindByText(modelCu.customerZone));
                                if (zoneindex > 0)
                                {
                                    com_Area1.SelectedIndex = zoneindex;

                                }
                            }
                        }
                    }
                }

            }
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('数据库连接错误！');</script>");
        }
    }
    //接收省份的集合
    DataSet ds_Province;
    //接收市的集合
    DataSet ds_City;
    //接收区的集合
    DataSet ds_Area;
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

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (this.TextBox20.Text == "")
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('请填写密码！');</script>");
            return;
        }
        
        modelCu.customerPwd = pc.md5(this.TextBox20.Text);
        cb.update(modelCu);

        pc.addlog(modelCu.customerID.ToString(), this.TextBox20.Text, "", "", "后台修改密码", "");

        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('设置密码成功！');</script>");
    }
    protected void Button4_Click(object sender, EventArgs e)  //模拟员工登陆
    {
        string id;
        if (this.TextBox3.Text != "")
        {
               id = this.TextBox3.Text;
        }
        else
        {
               id = this.TextBox5.Text;
        }
        string s = "select * from tab_customers where customerIDcard='" + id + "'";
        DataTable dt = cb.CustomerSelect(s);
        Session["cus"] = dt.Rows[0]["customerName"];
        Session["Companycode"] = dt.Rows[0]["customerCompanycode"];
        Session["Company"] = dt.Rows[0]["customerCompany"];
        Session["id"] = dt.Rows[0]["customerID"];
        if (Session["language"] == null)
        {
            Session["language"] = "zh-cn";
        }
        Session["from"] = "pf";
        Response.Redirect("/index.aspx");
    }
}
