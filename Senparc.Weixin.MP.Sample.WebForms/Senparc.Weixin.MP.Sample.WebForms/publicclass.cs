using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace Senparc.Weixin.MP.Sample.WebForms
{
    public class publicclass
    {
        public string getaccess_token()
        {
            string input = this.getrequest("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=XXXXXXXXX&secret=XXXXXXXX");
            if (input.Substring(0, 5) != "error")
            {
                object obj2;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<string, object> dictionary = (Dictionary<string, object>)serializer.DeserializeObject(input);
                if (dictionary.TryGetValue("access_token", out obj2))
                {
                    return obj2.ToString();
                }
                return "error";
            }
            return "error";
        }

        public static string getopenidbyOAuth2(string code, string state)
        {
            if (string.IsNullOrEmpty(code))
            {
                return "错误：您拒绝了授权！";
            }
            if (state != "Xinshui")
            {
            }
            OAuthAccessTokenResult result = OAuthApi.GetAccessToken(Weixin.Appid, Weixin.secret, code, "authorization_code");
            if (result.errcode > ReturnCode.请求成功)
            {
                return ("错误：" + result.errmsg);
            }
            return result.openid;
        }

        public string getrequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/html";
            request.Method = "get";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response != null)
                {
                    string str = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    response.Close();
                    return str;
                }
            }
            catch (WebException exception)
            {
                return ("error:" + exception.ToString());
            }
            return "error";
        }

        public static List<Dictionary<string, object>> ToJsonlist(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dt.Rows)
            {
                Dictionary<string, object> item = new Dictionary<string, object>();
                foreach (DataColumn column in dt.Columns)
                {
                    item.Add(column.ColumnName, row[column].ToString());
                }
                list.Add(item);
            }
            return list;
        }
    }
}