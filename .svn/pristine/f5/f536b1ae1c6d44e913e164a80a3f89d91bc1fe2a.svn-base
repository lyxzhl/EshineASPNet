using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using MediPlus;
using System.Data;

public partial class products : System.Web.UI.Page
{
    PublicClass pc = new PublicClass();
    JavaScriptSerializer jss = new JavaScriptSerializer();

    public class logininfo
    {
        public string code;
        public string message;
        public List<Dictionary<string, object>> data;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Model.tab_product_class proclass = new Model.tab_product_class();
        Model.tab_products pro = new Model.tab_products();
        Bll.ProdutClassBLL ck = new Bll.ProdutClassBLL();
        Bll.ProductBll cb = new Bll.ProductBll();
        logininfo pi = new logininfo();

        string id = Request.Form["id"].ToString();

        DataTable dt = MediPlus.login.products(id);
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