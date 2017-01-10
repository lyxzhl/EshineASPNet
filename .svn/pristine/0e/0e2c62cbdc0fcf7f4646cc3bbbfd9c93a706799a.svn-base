using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using MediPlus;

public partial class updatepersonaldetail : System.Web.UI.Page
{

    PublicClass pc = new PublicClass();
    JavaScriptSerializer jss = new JavaScriptSerializer();

    public class personalinfo
    {
        public string code;
        public string message;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        int type = Convert.ToInt32(Request.Form["type"]);
        switch (type)
        {
            case 1: updatebasic(); break;
            case 2: updatepassword(); break;
        }
    }
    void updatebasic()
    {
        Dictionary<string, object> dic = new Dictionary<string, object>();
        personalinfo pi = new personalinfo();
        dic.Add("name", Request.Form["name"].ToString());
        dic.Add("email", Request.Form["email"].ToString());
        dic.Add("customerMobile", Request.Form["customerMobile"].ToString());
        dic.Add("customerGender", Request.Form["customerGender"].ToString());
        dic.Add("customerMarriageStatus", Request.Form["customerMarriageStatus"].ToString());
        dic.Add("DOB", Request.Form["DOB"].ToString());
        dic.Add("IDcard", Request.Form["IDcard"].ToString());
        dic.Add("customerCompanyProvince", Request.Form["customerCompanyProvince"].ToString());
        dic.Add("customerCompanyCity", Request.Form["customerCompanyCity"].ToString());

        int count = MediPlus.login.updatepersonaldetail(Request.Form["id"].ToString(), dic);
        if (count == 1)
        {
            pi.code = "1";
            pi.message = "修改成功";
        }
        else
        {
            pi.code = "0";
            pi.message = "修改失败";
        }
        string stringjson = jss.Serialize(pi);
        Response.Write(stringjson);

    }

     void  updatepassword()
    {
     Dictionary<string, object> dic = new Dictionary<string, object>();
        personalinfo pi = new personalinfo();
        string pw = Request.Form["password"].ToString();
        string pw_old = Request.Form["password_old"].ToString();
        pw = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pw, "MD5").ToLower();
        pw_old = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pw_old, "MD5").ToLower();
        dic.Add("password", pw);
        dic.Add("password_old", pw_old);
        int count = MediPlus.login.updatepersonaldetail(Request.Form["id"].ToString(), dic);
        if (count == 1)
        {
            pi.code = "1";
            pi.message = "修改成功";
        }
        else if (count == -1)
        {
            pi.code = "0";
            pi.message = "原密码输入错误";
        }
        else
        {
            pi.code = "0";
            pi.message = "修改失败";
        }
        string stringjson = jss.Serialize(pi);
        Response.Write(stringjson);
}
}