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

public partial class customergetstart : System.Web.UI.Page
{

    public class info
    {
        public string code;
        public string message;

        public int memberid;
        public string key;

        public List<Dictionary<string, object>> data;//咨询师列表
    }
    JavaScriptSerializer jss = new JavaScriptSerializer();
    //PublicClass pc = new PublicClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        Model.tab_customers cus = new tab_customers();
        Bll.CustomerBll cb = new Bll.CustomerBll();
        info io = new info();
        try
        {
            string nickname = Request.Form["nickname"];
            string gender = Request.Form["gender"];
            string mobile = Request.Form["mobile"];
            string password = Request.Form["password"];
            string iDcard = Request.Form["iDcard"];
            DateTime DOB = DateTime.Parse(Request.Form["DOB"]);
            string hunyin = Request.Form["hunyin"];
                int count = MediPlus.login.customerstart(nickname, gender, mobile, password, iDcard, DOB, hunyin);

                if (count == -1)
                {
                    io.code = "0";
                    io.message = "密码长度不得小于6位";
                }
                else if (count == -2)
                {
                    io.code="0";
                    io.message="身份证长度错误";
                }
                else if (count == -3)
                {
                    io.code = "0";
                    io.message = "手机号长度错误";
                }
                else
                {
               cb.CustomerAdd(cus);

                    io.code = "1";
                    io.message = "注册成功";
                    io.memberid = cus.customerID;

                    io.key = cus.customerPwd;

                }
            }
        catch (Exception ex)
        {
            io.code = "0";
            io.message = ex.ToString();
        }
        string jsonString = jss.Serialize(io);
        Response.Write(jsonString);
    }

    protected void ronglianyunrest(int memberid)
    {
        ////int memberid = int.Parse(Request.Form["memberid"]);
        //string ret = null;

        //CCPRestSDK.CCPRestSDK api = new CCPRestSDK.CCPRestSDK();
        ////ip格式如下，不带https://
        //bool isInit = api.init("sandboxapp.cloopen.com", "8883");
        //api.setAccount("aaf98f894bc4f9b9014bc8e84d3901db", "dae0b75159174bcc8a5c1765ea191c85");
        //api.setAppId("8a48b5514c49eb79014c5576505708b6");
        //string result = "";
        //try
        //{
        //    if (isInit)
        //    {
        //        Dictionary<string, object> retData = api.CreateSubAccount("xinshui_" + memberid);
        //        //ret = getDictionaryData(retData);

        //        result += "statusCode:" + retData["statusCode"] + "\n";
        //        result += "statusMsg:" + retData["statusMsg"] + "\n";
        //        Dictionary<string, object> ret1 = (Dictionary<string, object>)((Dictionary<string, object>)retData["data"])["SubAccount"];
        //        result += "dateCreated：" + ret1["dateCreated"] + "\n";
        //        result += "subAccountSid：" + ret1["subAccountSid"] + "\n";
        //        result += "subToken：" + ret1["subToken"] + "\n";
        //        result += "voipAccount：" + ret1["voipAccount"] + "\n";
        //        result += "voipPwd：" + ret1["voipPwd"] + "\n";
        //        int num = updatecustomeryonglianyun(memberid, ret1["subAccountSid"].ToString(), ret1["subToken"].ToString(), ret1["voipAccount"].ToString(), ret1["voipPwd"].ToString());
        //        if (num == 0)
        //        {
        //            result += "创建子账号成功，但不存在此用户id";
        //        }
        //    }
        //    else
        //    {
        //        ret = "初始化失败";
        //    }
        //}
        //catch (Exception exc)
        //{
        //    ret = exc.Message;
        //}
    }
    //protected int updatecustomeryonglianyun(int memberid, string subAccountSid, string subToken, string voipAccount, string voipPwd)
    //{
    //    Bll.customerBll cb = new Bll.customerBll();
    //    Model.customer modelCu = new Model.customer();
    //    modelCu.memberid = memberid;
    //    modelCu = cb.getcustomer(modelCu);
    //    if (modelCu == null) return 0;
    //    modelCu.usid_ronglianyun_subAccountSid = subAccountSid;
    //    modelCu.usid_ronglianyun_subToken = subToken;
    //    modelCu.usid_ronglianyun_voipAccount = voipAccount;
    //    modelCu.usid_ronglianyun_voipPwd = voipPwd;
    //    cb.update(modelCu);
    //    return 1;

    //}

}