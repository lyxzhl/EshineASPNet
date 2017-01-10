using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
public partial class RelativesDetails : PageBases
{
    Model.tab_relatives modelRel = new Model.tab_relatives();
    Bll.RelativeBLL RB = new Bll.RelativeBLL();
    PublicClass pc = new PublicClass();
    public string classmale, classfemale, classmarried, classunmarried;
    
    void initrel()
    {
        string i = Request.QueryString["Cid"];
        Session["relid"] = i;
        modelRel.relativeID = int.Parse(i);
        modelRel = RB.getRelative(modelRel);

        this.TextBox1.Text = modelRel.relativeName;
        this.TextBox3.Text = modelRel.relativeIDcard;
        this.TextBox4.Text = modelRel.relativeMobile;

        if (modelRel.relativeGender == "男")
        {
            this.RadioButton1.Checked = true;
            classmale = "selected";
        }
        else if (modelRel.relativeGender == "女")
        {
            this.RadioButton2.Checked = true;
            classfemale = "selected";
        }

        if (modelRel.relativeMarriageStatus == "未婚")
        {
            this.RadioButton3.Checked = true;
            classunmarried = "selected";
        }
        else if (modelRel.relativeMarriageStatus == "已婚")
        {
            this.RadioButton4.Checked = true;
            classmarried = "selected";
        }

        if (modelRel.relativeRelationship == "配偶")
        {
            this.RadioButton14.Checked = true;
        }
        else if (modelRel.relativeRelationship == "子女")
        {
            this.RadioButton15.Checked = true;
        }
        else if (modelRel.relativeRelationship == "父母")
        {
            this.RadioButton16.Checked = true;
        }
        else if (modelRel.relativeRelationship == "其他")
        {
            this.RadioButton17.Checked = true;
        }

    }
    void init()
    {
        if (Request.QueryString["Cid"] == null || Request.QueryString["Cid"].ToString() == "")
        {
        }
        else
        {
            initrel();
            this.Button1.Visible = false;
            this.Button2.Visible = true;
            this.Button3.Visible = true;
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
                classmale = "selected";
            }
            else
            {
                this.RadioButton1.Checked = false;
                classfemale = "selected";
            }
        }
        else
        {
            if (modelRel.relativeDOB != null && modelRel.relativeDOB != pc.baddate)
            {
                year = modelRel.relativeDOB.Year;
                month = modelRel.relativeDOB.Month;
                day = modelRel.relativeDOB.Day;
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.CheckUser((Hashtable)Application["Online"]);
            Session["relid"] = "";
            init();
            displayage();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell tc = e.Row.Cells[1];
            if (tc.Text == "配偶")
            {
                tc.Text = (string)GetGlobalResourceObject("GResource", "couple");
            }
            else if (tc.Text == "子女")
            {
                tc.Text = (string)GetGlobalResourceObject("GResource", "children");
            }
            else if (tc.Text == "父母")
            {
                tc.Text = (string)GetGlobalResourceObject("GResource", "parent");
            }
            else if (tc.Text == "其他")
            {
                tc.Text = (string)GetGlobalResourceObject("GResource", "other");
            }
        }

        return;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink link1 = (HyperLink)e.Row.FindControl("HyperLink1");
            if (((DataRowView)e.Row.DataItem)["arrangestatus"].ToString() == "已预约")
            {
                link1.Text = "查看预约";
                link1.NavigateUrl = "viewarrangement.aspx";
            }
            else
            {
                link1.Text = "预约体检";
                link1.NavigateUrl = "reserverelexam.aspx?relativeID=" + ((DataRowView)e.Row.DataItem)["relativeID"].ToString();
            }


        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        modelRel.relativeID = int.Parse(Session["relid"].ToString());
        modelRel = RB.getRelative(modelRel);
        modelRel.relativeName = this.TextBox1.Text;
        modelRel.relativeIDcard = this.TextBox3.Text;
        modelRel.relativeMobile = this.TextBox4.Text;


        if (this.RadioButton1.Checked)
            modelRel.relativeGender = "男";
        else if (this.RadioButton2.Checked)
            modelRel.relativeGender = "女";

        if (this.RadioButton3.Checked)
            modelRel.relativeMarriageStatus = "未婚";
        else if (this.RadioButton4.Checked)
            modelRel.relativeMarriageStatus = "已婚";

        if (this.RadioButton14.Checked)
            modelRel.relativeRelationship = "配偶";
        else if (this.RadioButton15.Checked)
            modelRel.relativeRelationship = "子女";
        else if (this.RadioButton16.Checked)
            modelRel.relativeRelationship = "父母";
        else if (this.RadioButton17.Checked)
            modelRel.relativeRelationship = "其他";

        modelRel.relativeDOB = DateTime.Parse(DropDownListYear.SelectedValue + "-" + DropDownListMonth.SelectedValue + "-" + DropDownListDay.SelectedValue);

        RB.update(modelRel);
        this.Button3_Click(sender, e);
        this.GridView1.DataBind();
        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('更新家属信息成功！');</script>");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        this.Button1.Visible = true;
        this.Button2.Visible = false;
        this.Button3.Visible = false;

        clearcontent();

    }
    void clearcontent()
    {
        this.TextBox1.Text = "";
        this.TextBox3.Text = "";
        this.TextBox4.Text = "";
        classmale = classfemale = classmarried = classunmarried = "";
        
        this.RadioButton1.Checked = false;
        this.RadioButton2.Checked = false;
        this.RadioButton3.Checked = false;
        this.RadioButton4.Checked = false;
        this.RadioButton14.Checked = false;
        this.RadioButton15.Checked = false;
        this.RadioButton16.Checked = false;
        this.RadioButton17.Checked = false;

        this.DropDownListYear.SelectedIndex = 0;
        this.DropDownListMonth.SelectedIndex = 0;
        this.DropDownListDay.SelectedIndex = 0;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = RB.RelativeSelect("SELECT relativeName,relativeID,relativeIDcard FROM tab_relatives WHERE relativeCustomer=" + Session["id"].ToString());
        if (dt.Rows.Count >= 6)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('您至多可以添加6个家属！');</script>");
            return;
        }
        else if (dt.Rows[0]["relativeName"].ToString() != this.TextBox1.Text && dt.Rows[0]["relativeIDcard"].ToString()!=this.TextBox3.Text)
        {
        Model.tab_relatives relative = new Model.tab_relatives();
        relative.relativeCustomer = int.Parse(Session["id"].ToString());
        relative.relativeName = this.TextBox1.Text;
        relative.relativeIDcard = this.TextBox3.Text;
        relative.relativeMobile = this.TextBox4.Text;

        if (this.RadioButton1.Checked)
            relative.relativeGender = "男";
        else if (this.RadioButton2.Checked)
            relative.relativeGender = "女";

        if (this.RadioButton3.Checked)
            relative.relativeMarriageStatus = "未婚";
        else if (this.RadioButton4.Checked)
            relative.relativeMarriageStatus = "已婚";

        if (this.RadioButton14.Checked)
            relative.relativeRelationship = "配偶";
        else if (this.RadioButton15.Checked)
            relative.relativeRelationship = "子女";
        else if (this.RadioButton16.Checked)
            relative.relativeRelationship = "父母";
        else if (this.RadioButton17.Checked)
            relative.relativeRelationship = "其他";

        relative.relativeDOB = DateTime.Parse(DropDownListYear.SelectedValue + "-" + DropDownListMonth.SelectedValue + "-" + DropDownListDay.SelectedValue);

        RB.RelativeAdd(relative);
        clearcontent();
        this.GridView1.DataBind();
        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('新增家属成功,可以继续添加！');</script>");
        }
        else
        {
            Response.Write("<script>alert('提交失败!')</script>");
        }
    }

}