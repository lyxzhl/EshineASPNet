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

public partial class Admin_empAdmin_empAdd : basePage
{
    GetPowerPage power = new GetPowerPage();
    Bll.empBll pow = new Bll.empBll();
    Model.tab_emps tem = new Model.tab_emps();
    Model.tab_roles roles = new Model.tab_roles();
    Bll.RolesBll ro =new Bll.RolesBll();
    protected void Page_Load(object sender, EventArgs e)
    {       
        if(!Page.IsPostBack)
        {
            //this.CheckUser((Hashtable)Application["Online"]);
            this.RadioButtonList1.DataSource = ro.GetAll();
            this.RadioButtonList1.DataTextField = "roleName";
            this.RadioButtonList1.DataValueField = "roleID";
            this.RadioButtonList1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        tem.empName = this.TextBox1.Text;
        tem.empPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.TextBox2.Text, "MD5").ToLower(); 
        tem.Roles=Convert.ToInt32( this.RadioButtonList1.SelectedValue);
        int i= pow.insert(tem);
        if (i > 0)
        {
            Response.Redirect("empInfo.aspx");
        }
    }
}
