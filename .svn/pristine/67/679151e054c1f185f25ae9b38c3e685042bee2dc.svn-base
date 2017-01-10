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

public partial class Admin_powerAdmin_powerUpdate : basePage
{
    GetPowerPage power = new GetPowerPage();
    Bll.ProwerBll pow = new Bll.ProwerBll();
    Model.tab_powers mpower = new Model.tab_powers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this.CheckUser((Hashtable)Application["Online"]);
            string poid = Request.QueryString["pid"].ToString();

            TreeNode node = power.CreateNode();
            this.TreeView1.Nodes.Add(node);
            GetPower(this.DropDownList1);
            DataTable dt = pow.GetProwerAny("select * from tab_powers where powerID=" + poid);
            ViewState["pid"] = poid;
            this.TextBox1.Text = dt.Rows[0]["powerName"].ToString();//dr["powerName"].ToString();
            this.TextBox2.Text = dt.Rows[0]["powerUrl"].ToString();//dr["powerUrl"].ToString();
            this.TextBox4.Text = dt.Rows[0]["powerContent"].ToString();//dr["powerContent"].ToString();

            for (int i = 0; i < this.DropDownList1.Items.Count; i++)
            {
                if (this.DropDownList1.Items[i].Value == dt.Rows[0]["powerPID"].ToString())
                {
                    this.DropDownList1.SelectedIndex = i;
                }
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        mpower.PowerName = this.TextBox1.Text;
        mpower.PowerContent = this.TextBox4.Text;
        mpower.PowerUrl = this.TextBox2.Text;
        mpower.PowerPID = Convert.ToInt32(this.DropDownList1.SelectedValue);
        mpower.PowerID = Convert.ToInt32(ViewState["pid"]);

        pow.UpdataPrower(mpower);
        GetPower(this.DropDownList1);
        this.Label1.Text = "<font color='red'>更新成功</font>";
    }
    public void GetPower(DropDownList dp)
    {
        DataTable dt = pow.GetProwerAny("select powerID,powerName from tab_powers where powerPID=0");
        dp.DataSource = dt;
        dp.DataTextField = "powerName";
        dp.DataValueField = "powerID";
        dp.DataBind();
        dp.Items.Insert(0, new ListItem("------", "0"));
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.TextBox2.Text = this.TreeView1.SelectedNode.Value;
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TreeView1_SelectedNodeChanged1(object sender, EventArgs e)
    {
        this.TextBox2.Text = this.TreeView1.SelectedNode.Value;
    }
}
