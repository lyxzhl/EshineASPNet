using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Senparc.Weixin.MP.Sample.WebForms
{
    public class basePage : System.Web.UI.Page
    {

        public void CheckUser(System.Web.HttpRequest Request)
        {
            //判断用户是否登陆
            if (Session["openid"] == null || Session["openid"].ToString()=="")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["code"]))
                {
                    string openid = publicclass.getopenidbyOAuth2(Request.QueryString["code"], Request.QueryString["state"]);
                    if (openid != "" && !openid.Contains("错误"))
                    {
                        Session["openid"] = openid;
                    }
                }
                else
                {
                    Response.Redirect("~/webpage/lost.aspx", true);
                }
            }
        }
    }
}