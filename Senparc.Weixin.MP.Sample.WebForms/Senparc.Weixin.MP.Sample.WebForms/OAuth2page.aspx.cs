using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Sample.CommonService.CustomMessageHandler;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Senparc.Weixin.MP.Sample.WebForms
{
    public partial class OAuth2page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = base.Request.QueryString["q"];
            string url = "";
            switch (str)
            {
                case "1"://功能1
                    url = OAuthApi.GetAuthorizeUrl(Weixin.Appid,
                        "http://weixin.eshinelee.com/webpage/page1.aspx", "something", OAuthScope.snsapi_base, "code");
                    break;

                case "2"://功能2
                    url = OAuthApi.GetAuthorizeUrl(Weixin.Appid,
                        "http://weixin.eshinelee.com/webpage/page2.aspx", "cus", OAuthScope.snsapi_base, "code");
                    break;
                    
            }
            base.Response.Redirect(url);
        }
    }
}