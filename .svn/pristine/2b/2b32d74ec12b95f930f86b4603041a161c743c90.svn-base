using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Net;
using System.Text;
using System.IO;
public partial class textdrmed : System.Web.UI.Page
{
    public class info
    {
        public Dictionary<string, object> answer;
        public string disease;
        public string user;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        System.Collections.Specialized.NameValueCollection PostVars;
        PostVars = new System.Collections.Specialized.NameValueCollection();

        Dictionary<string, object> ans = new Dictionary<string, object>();
        ans.Add("1", 1);
        ans.Add("2", 31);
        ans.Add("3", 0);
        ans.Add("4", 0);
        ans.Add("5", 0);
        ans.Add("6", 139);
        ans.Add("7", 33);
        ans.Add("8", 33);



        string output = jss.Serialize(ans);
       // PostVars.Add("answer", output);
       // PostVars.Add("disease", "heart-attack");
        //PostVars.Add("user", "13456");

        info info1 = new info();
        info1.answer = ans;
        info1.disease = "heart-attack";
        info1.user = "1235";

        string temp;
        string url = "http://www.drmed.cn/api/disease";

        url += "?appkey=" + "b32a34fabefe7f04";
        temp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();

        url += "&timestamp=" + temp;
        temp = "b32a34fabefe7f04" + "-" + "2c6bcc543f6f0c07435b5a6dcb90c96a" + "-" + temp;

        url += "&token=" + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(temp, "MD5").ToLower();

        url += "&version=1.1";

        string s;
        //s= PublicClass.postrequest(url, PostVars);
        s = getrequest(url, jss.Serialize(info1));
        this.TextBox1.Text = s;


    }

    private string getrequest(string url, string JSONData)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(JSONData);
        HttpWebRequest myReq;
        HttpWebResponse res;
        string result;

        myReq = (HttpWebRequest)HttpWebRequest.Create(url);
        myReq.ContentType = "application/json";
        myReq.ContentLength = bytes.Length;
        myReq.Method = "post";
        Stream reqstream = myReq.GetRequestStream();
        reqstream.Write(bytes, 0, bytes.Length);


        myReq.Timeout = 600000;

        try
        {
            res = (HttpWebResponse)myReq.GetResponse();
            if (res != null)
            {
                result = new StreamReader(res.GetResponseStream()).ReadToEnd();
                res.Close();
                return result;
            }
        }
        catch (WebException ex)
        {
            result = "error:" + ex.ToString();
            return result;
        }
        return "error";
    }
}