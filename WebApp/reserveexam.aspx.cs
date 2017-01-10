using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using MediPlus;
using System.Data;

public partial class reserveexam : System.Web.UI.Page
{
    PublicClass pc = new PublicClass();
    JavaScriptSerializer jss = new JavaScriptSerializer();

    public class logininfo
    {
        public string code;
        public string message;
        public List<Dictionary<string, object>> data;
        public string key;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Model.tab_customers mc=new Model.tab_customers();
        Bll.CustomerBll cb= new Bll.CustomerBll();
        logininfo pi = new logininfo();
        string ID = Request.Form["ID"].ToString();

        DataTable dt = MediPlus.login.sdk(ID);

        if (dt != null)
        {
            pi.code = "1";
            pi.message = "查询成功";
            pi.data = pc.ToJsonlist(dt);
            pi.key = dt.Rows[0]["customerID"].ToString();
        }
        else
        {
            pi.code = "0";
            pi.message = "id错误";
        }

        string jsonString = jss.Serialize(pi);
        Response.Write(jsonString);
    }
}