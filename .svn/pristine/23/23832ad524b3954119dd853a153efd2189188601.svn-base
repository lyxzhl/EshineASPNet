using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class about : PageBases
{
    Bll.newsBll nb = new Bll.newsBll();
    public string maincontent;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["language"] == null)
            {
                Session["language"] = "zh-cn";
            }
            maincontent = nb.getNews("静态文本", "关于我们", Session["language"].ToString());

        }
    }
}