using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data;

public partial class jiashuzil : System.Web.UI.Page
{
    public class logininfo
    {
        public string code;
        public string message;
        public List<Dictionary<string, object>> data;
        public string key;
    }
    PublicClass pc = new PublicClass();
    JavaScriptSerializer jss = new JavaScriptSerializer();
    protected void Page_Load(object sender, EventArgs e)
    {
        Model.tab_relatives modelRel = new Model.tab_relatives();
        Bll.RelativeBLL RBc = new Bll.RelativeBLL();
        logininfo pi = new logininfo();

        string ID = Request.Form["id"].ToString();

        DataTable dt = MediPlus.login.jiashu(ID);
        if (dt != null)
        {
            pi.code = "1";
            pi.message = "查询成功";
            pi.data = pc.ToJsonlist(dt);
            pi.key = dt.Rows[0]["relativeCustomer"].ToString();
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