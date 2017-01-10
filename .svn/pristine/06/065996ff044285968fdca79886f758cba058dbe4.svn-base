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

public partial class Admin_empAdmin_empUpdate :basePage
{
    GetPowerPage power = new GetPowerPage();
    Bll.empBll pow = new Bll.empBll();
    Model.tab_emps tem = new Model.tab_emps();
    Model.tab_roles roles = new Model.tab_roles();
    Bll.RolesBll ro = new Bll.RolesBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this.CheckUser((Hashtable)Application["Online"]);
            this.RadioButtonList1.DataSource = ro.GetAll();
            this.RadioButtonList1.DataTextField = "roleName";
            this.RadioButtonList1.DataValueField = "roleID";
            this.RadioButtonList1.DataBind();
            ViewState["eid"] = Request.QueryString["eid"].ToString();

            DataTable dt = pow.Getany(ViewState["eid"].ToString());
            this.Label1.Text = dt.Rows[0]["empName"].ToString();
            for (int i = 0; i < this.RadioButtonList1.Items.Count; i++)
            {
                if (this.RadioButtonList1.Items[i].Value == dt.Rows[0]["roleID"].ToString())
                {
                    this.RadioButtonList1.Items[i].Selected = true;
                    break;
                }
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        tem.empName = this.Label1.Text;
        tem.empPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.TextBox2.Text, "MD5").ToLower(); 
        tem.Roles = Convert.ToInt32(this.RadioButtonList1.SelectedValue);
        tem.empID = Convert.ToInt32(ViewState["eid"].ToString());
        pow.Update(tem);
        this.Label2.Text = "<font color='green'>更新成功</font>";
    }
}
