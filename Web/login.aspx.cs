using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
public partial class login : PageBases
{
    Model.tab_customers modelCu = new Model.tab_customers();
    Model.tab_loginlog loginlog = new Model.tab_loginlog();
    Bll.loginlogBll lb = new Bll.loginlogBll();
    Bll.newsBll nb = new Bll.newsBll();
    Bll.CustomerBll Cb = new Bll.CustomerBll();

    PublicClass pc = new PublicClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["id"] = null;
        Session["cartitems"] = null;
        if (Application["Online"] != null)
        {
            Hashtable h = (Hashtable)Application["Online"];
            if (h[Session.SessionID] != null)
                h.Remove(Session.SessionID);
            Application["Online"] = h;
        }

    }
    void addloginlog()
    {
        loginlog.loginid = this.TextBox1.Text;
        loginlog.loginpw = this.TextBox2.Text;
        loginlog.time = DateTime.Now;
        loginlog.loginip = pc.getIp(Request);
        loginlog.loginbrowser = Request.Browser.Type;
        loginlog.logindevice = Request.Browser.MobileDeviceManufacturer + " " + Request.Browser.MobileDeviceModel;
        //loginlog.status = ;
        //loginlog.note = "IsMobileDevice:" + Request.Browser.IsMobileDevice + "|" + "UserAgent:" + Request.UserAgent ;
        loginlog.note = "company=" + Session["cc"];
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (this.TextBox1.Text != "" && this.TextBox2.Text != "")
        {
            if (false && StrSecurity.CheckStr(this.TextBox1.Text + this.TextBox2.Text) == false)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('用户提交非法字符')</script>");
                return;
            }
            addloginlog();

            modelCu.customerCode = this.TextBox1.Text;
            modelCu.customerIDcard = this.TextBox1.Text;
            modelCu.customerMobile = this.TextBox1.Text;
            modelCu.customerEmail = this.TextBox1.Text;
            modelCu.customerPrivateEmail = this.TextBox1.Text;
            modelCu.customerPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.TextBox2.Text, "MD5").ToLower();
            if (Session["cc"] != null)
                modelCu.customerCompany = Session["cc"].ToString();
            DataTable dt = Cb.CustomerSelect(modelCu);

            if (dt.Rows.Count > 0)
            {
                Session["cus"] = dt.Rows[0]["customerName"];
                Session["Companycode"] = dt.Rows[0]["customerCompanycode"];
                Session["Company"] = dt.Rows[0]["customerCompany"];
                Session["id"] = dt.Rows[0]["customerID"];
                if (Session["language"] == null)
                {
                    Session["language"] = "zh-cn";
                }


                checkdoublelogin(dt.Rows[0]["customerID"].ToString(), loginlog.loginip);

                loginlog.status = "ok";
                lb.Add(loginlog);

                //更新最后登录时间
                modelCu.customerID = int.Parse(dt.Rows[0]["customerID"].ToString());
                modelCu = Cb.getCustomer(modelCu);
                modelCu.customerLastLogin = DateTime.Now;
                Cb.update(modelCu);


                //检查是否密码已过期
                //if (DateTime.Now > DateTime.Parse(dt.Rows[0]["customerLastPWChanged"].ToString()).AddDays(180))
                //{
                //    Response.Redirect("changepassword.aspx", true);
                //}

                Response.Redirect("index.aspx");
                //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('登陆成功')</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('用户名及密码不能为空')</script>");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("fetchpassword.aspx");
    }

    public bool checkdoublelogin(string strUserID, string ip)
    {
        Session["ip"] = ip;
        Hashtable h = (Hashtable)Application["Online"];

        bool doublelogin = false;

        if (h == null)
        {
            h = new Hashtable();
        }
        else
        {

            //判断哈希表中是否有该用户 
            IDictionaryEnumerator e1 = h.GetEnumerator();
            while (e1.MoveNext())
            {
                if (e1.Value.ToString().Split('|')[0].CompareTo(strUserID) == 0 && e1.Value.ToString() != strUserID + "|" + ip)
                //if (e1.Value.ToString().Split('|')[0].CompareTo(strUserID) == 0 )
                {

                    h.Remove(e1.Key);
                    Application["Online"] = h;
                    doublelogin = true;
                    break;
                }
            }
        }
        h[Session.SessionID] = strUserID + "|" + ip;
        Application["Online"] = h;
        return doublelogin;
    }
}