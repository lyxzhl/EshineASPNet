using Bll;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Senparc.Weixin.MP.Sample.WebForms
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text = new publicclass().getaccess_token();
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}