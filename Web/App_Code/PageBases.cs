using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Threading;
using System.Globalization;

/// <summary>
/// PageBases 的摘要说明
/// </summary>
public class PageBases : System.Web.UI.Page
{
    PublicClass pc = new PublicClass();
    public PageBases()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public void CheckUser( Hashtable h)
    {
        //判断用户是否登陆
        if (Session["id"] == null || Session["id"] == "")
        {
            //Response.Write("<script>parent.location='~/login.aspx'</script>");
            Response.Redirect("login.aspx", true);

        }
        if (Session["from"] != null && Session["from"] == "pf")
        { }
        else
        {
            try
            {
                if (!pc.AmIOnline(Session["id"] + "|" + Session["ip"], h))
                {
                    //用户没有在线 ，转到登录界面
                    // Response.Write("<script>parent.document.location.href='Login.aspx';</script>"); ////有框架时用
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('本帐号在其他地方登陆！'); window.location.href = 'login.aspx';</script>");
                    //Response.Redirect("login.aspx"); ////无框架时用
                    return;
                }
            }
            catch
            {
                //会话过期 ，转到登录界面
                //Response.Write("<script>parent.document.location.href='Login.aspx';</script>"); ////有框架时所用
                Response.Redirect("login.aspx"); ////无框架时用
                return;
            }
        }
    }
    protected override void InitializeCulture()
    {
        base.InitializeCulture();


        string s = Request.QueryString["language"];
        if (!String.IsNullOrEmpty(s))
        {
            Page.UICulture = s;
            Page.Culture = s;
            Session["language"] = s;
            //return;
            //UICulture - 决定了采用哪一种本地化资源，也就是使用哪种语言
            //Culture - 决定各种数据类型是如何组织，如数字与日期
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(s);
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(s);
        }
        else if (!String.IsNullOrEmpty(Session["language"] as string))
        {
            this.UICulture = Session["language"].ToString();
            this.Culture = Session["language"].ToString();
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["language"].ToString());
        }
        return;
        string language = (String)Context.Profile.GetPropertyValue("languagePreference");

        if (!String.IsNullOrEmpty(language) && (language != "Auto"))
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
            Page.UICulture = language;
        }

    }
}
