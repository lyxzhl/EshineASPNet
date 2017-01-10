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

public partial class Admin_powerAdmin_powerAdd : basePage
{
    GetPowerPage power = new GetPowerPage();
    Bll.ProwerBll pow = new Bll.ProwerBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this.CheckUser((Hashtable)Application["Online"]);
            TreeNode node = power.CreateNode();
            this.TreeView1.Nodes.Add(node);

            GetPower(this.DropDownList1);
        }

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
    Model.tab_powers mpower = new Model.tab_powers();
    protected void Button1_Click(object sender, EventArgs e)
    {
        mpower.PowerName = this.TextBox1.Text;
        mpower.PowerContent = this.TextBox4.Text;
        mpower.PowerUrl = this.TextBox2.Text;
        mpower.PowerPID = Convert.ToInt32(this.DropDownList1.SelectedValue);
        pow.AddPrower(mpower);
        GetPower(this.DropDownList1);
        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('添加成功');location='powerInfo.aspx'</script>");
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.TextBox2.Text = this.TreeView1.SelectedNode.Value;
    }
}
