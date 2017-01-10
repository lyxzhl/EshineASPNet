using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_login : System.Web.UI.Page
{
    Bll.empBll emp = new Bll.empBll();
    Bll.RolesBll ro = new Bll.RolesBll();
    Model.tab_roles modelRo = new Model.tab_roles();
    Model.tab_emps modelEmp = new Model.tab_emps();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void butLogin_Click(object sender, EventArgs e)
    {
        if (this.TextBox3.Text == "")
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('请输入验证码！')</script>");
            return;
        }
        else if (this.TextBox1.Text == "" || this.TextBox2.Text == "")
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('请输入用户名和密码！')</script>");
            this.TextBox3.Text = "";
            return;
        }
        else
        {
            if (this.TextBox3.Text.ToLower() == Request.Cookies["CheckCode"].Value.ToLower())
            {
                modelEmp.empName = this.TextBox1.Text;
                modelEmp.empPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.TextBox2.Text, "MD5").ToLower();
                DataTable dr = emp.GetModel(modelEmp);
                if (dr.Rows.Count > 0)
                {
                    Session["roleName"] = dr.Rows[0]["roleName"].ToString();
                    Session["roleID"] = dr.Rows[0]["roleID"].ToString();
                    Session["empName"] = dr.Rows[0]["empName"].ToString();
                    Session["empID"] = dr.Rows[0]["empID"].ToString();
                    Response.Redirect("~/Admin/login/adminDefault.htm");
                }
                else
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('不存在此用户明和密码')</script>");
                    this.TextBox3.Text = "";
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>alert('验证码错误!')</script>");
                this.TextBox3.Text = "";
                return;
            }
        }
        
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        this.ImageButton1.ImageUrl = "~/Admin/login/CheckCode.aspx";
    }
}