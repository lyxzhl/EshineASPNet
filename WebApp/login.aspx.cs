using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data;
using MediPlus;
using Model;
public partial class login : System.Web.UI.Page
{

    public class logininfo
    {
        public string code;
        public string message;
        public List<Dictionary<string, object>> data;
        public string key;
    }
    JavaScriptSerializer jss = new JavaScriptSerializer();
    PublicClass pc = new PublicClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        DBunit.SQLAccess dbsql = new DBunit.SQLAccess();
        Model.tab_customers modelCu = new Model.tab_customers();
        Model.tab_orders orders = new Model.tab_orders();
        Bll.CustomerBll Cb = new Bll.CustomerBll();
        Bll.SupplierBll sb = new Bll.SupplierBll();
        Bll.packageBll pb = new Bll.packageBll();
        Bll.uppkgBll ub = new Bll.uppkgBll();
        Bll.OrdersBll ob = new Bll.OrdersBll();
        Bll.examcardBll eb = new Bll.examcardBll();
        Bll.companyBll comb = new Bll.companyBll();
        Model.tab_company modelcomp = new Model.tab_company();
        Bll.supplierpackageBll spb = new Bll.supplierpackageBll();
        Model.tab_loginlog loglogin = new tab_loginlog();
        Bll.loginlogBll ii = new Bll.loginlogBll();
        logininfo linfo = new logininfo();


        string pw = Request.Form["password"].ToString();
        pw = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pw, "MD5").ToLower();
        string usrname =Request.Form["username"].ToString();
    
        DataTable dt = MediPlus.login.findmembers(usrname, pw);
        if (dt != null)
        {
            //if (dt.Rows[0]["blacklist"].ToString() == "1")
            //{
            //    loglogin.loginid = dt.Rows[0]["memberid"].ToString();
            //    loglogin.note = "被拉入黑名单，不能登录";
            //    loglogin.time = DateTime.Now;
            //    loglogin.lng = lng;
            //    loglogin.lat = lat;
            //    loglogin.status = 0;
            //    loglogin.geohash = xinshuiservice.Geohash.Encode(lat, lng);
            //    ll.Add(loglogin);

            //    linfo.code = "0";
            //    linfo.message = "登陆失败";
            //}
            //else
            //{
                //添加登录
                loglogin.loginid = dt.Rows[0]["customerID"].ToString();
                loglogin.note = "520";
                loglogin.time = DateTime.Now;
                loglogin.status = "ok";
                ii.Add(loglogin);
                //更新最后登录
                //Mcustomerdata.memberid = int.Parse(dt.Rows[0]["memberid"].ToString());
                //Mcustomerdata = cdb.getcustomerdata(Mcustomerdata);
                //Mcustomerdata.lastgeohash = loglogin.geohash;
                //Mcustomerdata.lastlogin = DateTime.Now;
                //cdb.update(Mcustomerdata);

                linfo.code = "1";
                linfo.message = "登陆成功";
                linfo.data = pc.ToJsonlist(dt);
                linfo.key = dt.Rows[0]["customerLastPWChanged"].ToString();
            //}
        }
        else
        {
            loglogin.loginid = usrname;
            loglogin.note = "用户名或密码错误";
            loglogin.time = DateTime.Now;
            loglogin.status = "failed";
            ii.Add(loglogin);

            linfo.code = "0";
            linfo.message = "用户名或密码错误";
        }


        string jsonString = jss.Serialize(linfo);
        Response.Write(jsonString);
    }
}