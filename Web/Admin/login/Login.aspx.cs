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

public partial class Admin_login_Login : System.Web.UI.Page
{
    Bll.empBll emp = new Bll.empBll();
    Bll.RolesBll ro = new Bll.RolesBll();
    Model.tab_roles modelRo = new Model.tab_roles();
    Model.tab_emps modelEmp = new Model.tab_emps();
    static string Code = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.TextBox2.Text = "51aspx";

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
     
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        modelEmp.empName = this.TextBox1.Text;
        modelEmp.empPwd = this.TextBox2.Text;
        DataTable dr = emp.GetModel(modelEmp);
        Code = Request.Cookies["CheckCode"].Value.ToLower();
            if (dr.Rows.Count > 0)
            {
                if (true || this.TextBox3.Text.ToLower() == Code.ToLower())
                {
                    Session["roleID"] = dr.Rows[0]["roleID"].ToString();
                    Session["empName"] = dr.Rows[0]["empName"].ToString();
                    Session["empID"] = dr.Rows[0]["empID"].ToString();
                    Response.Redirect("adminDefault.htm");
                }
                else
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('验证码错误!注意大小写!!')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('不存在此用户明和密码')</script>");
            }
        
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
}
