<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码
        RegisterRoutes(RouteTable.Routes);

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码
        
    }

    void Session_End(object sender, EventArgs e) 
    {
        if (Application["Online"] != null)
        {
            Hashtable h = (Hashtable)Application["Online"];
            if (h[Session.SessionID] != null)
                h.Remove(Session.SessionID);
            Application["Online"] = h;
        }
        
        Session["id"] = null;
        Session["cus"] = null;
    }
    
    void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("companyname",
            "co/{cc}",
            "~/processroute.aspx");

    }

</script>
