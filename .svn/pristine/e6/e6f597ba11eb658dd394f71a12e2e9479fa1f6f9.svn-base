using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using MediPlus;
using System.Data;

public partial class wodyuyue : System.Web.UI.Page
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
        Model.tab_orders orderr = new Model.tab_orders();
        Bll.OrdersBll cb = new Bll.OrdersBll();
        logininfo pi = new logininfo();

        string ID = Request.Form["id"].ToString();

        DataTable dt = MediPlus.login.prostati(ID);
        if (dt != null)
        {
            pi.code = "1";
            pi.message = "查询成功";
            pi.data = pc.ToJsonlist(dt);
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