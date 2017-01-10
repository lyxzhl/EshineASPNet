using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Selectstore : System.Web.UI.Page
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
        Model.tab_customers mc = new Model.tab_customers();
        Bll.CustomerBll cb = new Bll.CustomerBll();
        logininfo pi = new logininfo();
        string id = Request.Form["id"].ToString();
        string shengfen = Request.Form["shengfen"].ToString();
        string chengshi = Request.Form["chengshi"].ToString();

      

        DataTable ds = MediPlus.login.mdian(shengfen, chengshi,id);
        if (ds!=null)
        {
             pi.code = "1";
            pi.message = "查询成功";
            pi.data = pc.ToJsonlist(ds);
            pi.key = ds.Rows[0]["hospid"].ToString();
        }
        else
        {
            pi.code = "0";
            pi.message = "输入错误";
        }

        string jsonString = jss.Serialize(pi);
        Response.Write(jsonString);
    }
}