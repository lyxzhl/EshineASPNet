using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Collections;
public partial class addressmanaging : PageBases
{
    Model.tab_customers modelCu = new Model.tab_customers();
    Bll.CustomerBll Cb = new Bll.CustomerBll();


    //接收省份的集合
    DataSet ds_Province;
    //接收市的集合
    DataSet ds_City;
    //接收区的集合
    DataSet ds_Area;
    string address = "";
    string[] sArray;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.CheckUser((Hashtable)Application["Online"]);
        }
        modelCu.customerID = int.Parse(Session["id"].ToString());
        modelCu = Cb.getCustomer(modelCu);

        if (!Page.IsPostBack)
        {
            init();
            initcity(sender, e);
            
        }
        filladdresses();
    }
    void init()
    {
        
    }

    void initcity(object sender, EventArgs e)
    {
        try
        {

            ds_Province = DBHelper.GetSet("select * from province");
            for (int i = 0; i < ds_Province.Tables[0].Rows.Count; i++)
            {
                com_Province.Items.Add(ds_Province.Tables[0].Rows[i][2].ToString());
            }
            int proindex, cityindex;
            if (modelCu.customerProvince != "")
            {
                proindex = this.com_Province.Items.IndexOf(this.com_Province.Items.FindByText(modelCu.customerProvince));
                if (proindex > 0)
                {
                    com_Province.SelectedIndex = proindex;
                    com_Province_SelectedIndexChanged(sender, e);
                    if (modelCu.customerCity != "")
                    {
                        cityindex = this.com_City.Items.IndexOf(this.com_City.Items.FindByText(modelCu.customerCity));
                        if (cityindex > 0)
                        {
                            com_City.SelectedIndex = cityindex;
                            com_City_SelectedIndexChanged(sender, e);

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
    protected void com_Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            com_City.Items.Clear();
            com_City.Items.Add((string)GetGlobalResourceObject("GResource", "selectCity"));
            ds_City = DBHelper.GetSet(string.Format("select name from city where provinceId in (select code from province where name='{0}')", com_Province.Text));
            if (ds_City.Tables[0].Rows.Count == 0)
                com_City.Items.Add(com_Province.Text);
            for (int i = 0; i < ds_City.Tables[0].Rows.Count; i++)
                com_City.Items.Add(ds_City.Tables[0].Rows[i][0].ToString());
            com_City.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('error:" + ex.Message + "');</script>");
        }
    }
    protected void com_City_SelectedIndexChanged(object sender, EventArgs e)
    {
        com_Area.Items.Clear();
        com_Area.Items.Add((string)GetGlobalResourceObject("GResource", "selectZone"));
        ds_Area = DBHelper.GetSet(string.Format("select name from area where cityId in (select code from city where name='{0}')", com_City.Text));
        if (ds_Area.Tables[0].Rows.Count == 0)
            com_Area.Items.Add(com_City.Text);
        for (int i = 0; i < ds_Area.Tables[0].Rows.Count; i++)
            com_Area.Items.Add(ds_Area.Tables[0].Rows[i][0].ToString());
        com_Area.SelectedIndex = 0;
    }
    private void filladdresses()
    {
        address = modelCu.customerAllAddr;
        if (modelCu.customerAllAddr == null||modelCu.customerAllAddr == "")
        {
            this.no_addresses.InnerText = (string)GetGlobalResourceObject("GResource", "nosavedaddress"); 
        }
        else
        {
            sArray = address.Split('|');
            foreach (string s in sArray)
            {
                Table t = new Table();
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.CssClass = "address";
                cell1.Text = s;
                TableCell cell2 = new TableCell();
                Button btn = new Button();
                btn.CssClass = "delete button gray_button";
                btn.Text = (string)GetGlobalResourceObject("GResource", "delete"); 
                btn.Click += new EventHandler(deleteaddress);
                cell2.Controls.Add(btn);

                row.Controls.Add(cell1);
                row.Controls.Add(cell2);
                t.Controls.Add(row);

                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Controls.Add(t);
                this.all_addresses.Controls.Add(li);
            }
        }
    }
    public void deleteaddress(object sender, EventArgs e)
    {
        int index = 0;
        if (sArray.Length == 1)
        {
            address = "";
        }
        else
        {
            index = this.all_addresses.Controls.IndexOf(((Control)sender).Parent.Parent.Parent.Parent) - 1;

            string ds = sArray[index];
            address = address.Replace(ds, "");
            if (index == 0)
            {
                address = address.Substring(1);
            }
            else if (index == sArray.Length - 1)
            {
                address = address.Substring(0, address.Length - 1);
            }
            else
            {
                address = address.Replace("||", "|");
            }
        }
        modelCu.customerAllAddr = address;
        Cb.update(modelCu);
        this.all_addresses.Controls.RemoveAt(index + 1);
    }

    protected void save_address_Click(object sender, EventArgs e)
    {
        string s = this.TextBox4.Text + "," + com_Province.SelectedValue +com_City.SelectedValue+com_Area.SelectedValue+this.TextBox7.Text + "," + this.TextBox9.Text;
        string newalladdress = "";
        if (modelCu.customerAllAddr == null || modelCu.customerAllAddr == "")
        {
            newalladdress = s;
        }
        else
        {
            newalladdress = s + "|" + modelCu.customerAllAddr;
        }
        modelCu.customerAllAddr = newalladdress;
        Cb.update(modelCu);

        this.TextBox4.Text = "";
        this.TextBox7.Text = "";
        this.TextBox9.Text = "";

        this.no_addresses.InnerText = "";
        this.all_addresses.Controls.Clear();
        filladdresses();
    }
}