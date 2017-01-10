using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Net;
using System.Xml;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using smsWebRef;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
using Model.WebApp;
using System.Data;

/// <summary>
/// PublicClass 的摘要说明
/// </summary>
public class PublicClass : System.Web.UI.Page
{

    public static JavaScriptSerializer javascript = new JavaScriptSerializer();
    public PublicClass()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }


    public bool AmIOnline(string s, Hashtable h)
    {
        //System.Web.SessionState.HttpSessionState Session = HttpContext.Current.Session;
        //Hashtable h = (Hashtable)Application["Online"];


        //继续判断是否该用户已经登陆 
        if (h == null)
            return false;

        //判断哈希表中是否有该用户 
        IDictionaryEnumerator e1 = h.GetEnumerator();
        bool flag = false;
        //string s;
        while (e1.MoveNext())
        {
            //s = Session["id"] + "|" + Session["ip"];
            if (e1.Value.ToString().CompareTo(s) == 0)
            {
                flag = true;
                break;
            }
        }
        return flag;
    }

    public List<Dictionary<string, object>> ToJsonlist(DataTable dt)
    {
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        foreach (DataRow dr in dt.Rows)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (DataColumn dc in dt.Columns)
            {
                result.Add(dc.ColumnName, dr[dc].ToString());
            }
            list.Add(result);
        }

        return list;
    }
    public List<Dictionary<string, object>> ToJsonlist(DataTable dt, DataTable dt2)
    {
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        foreach (DataRow dr in dt.Rows)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (DataColumn dc in dt.Columns)
            {
                result.Add(dc.ColumnName, dr[dc]);
            }
            list.Add(result);
        }
        foreach (DataRow dr in dt2.Rows)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (DataColumn dc in dt2.Columns)
            {
                result.Add(dc.ColumnName, dr[dc]);
            }
            list.Add(result);
        }

        return list;
    }

    public List<Dictionary<string, object>> ToJsonlist(DataTable dt1, string dt2name, string dtsql, string para)
    {
        DataTable dt2;
        string s;
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        foreach (DataRow dr in dt1.Rows)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (DataColumn dc in dt1.Columns)
            {
                result.Add(dc.ColumnName, dr[dc]);
            }
            list.Add(result);

            result = new Dictionary<string, object>();

            //result.Add(dt2name);
            list.Add(result);

        }

        return list;
    }

    private string postrequest2(string url, string s)
    {
        //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        ////string s = "要提交的数据";
        //byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(s);
        //req.Method = "POST";
        //req.ContentType = "application/x-www-form-urlencoded";
        //req.ContentLength = requestBytes.Length;
        //Stream requestStream = req.GetRequestStream();
        //requestStream.Write(requestBytes, 0, requestBytes.Length);
        //requestStream.Close();

        //HttpWebResponse res = (HttpWebResponse)req.GetResponse();
        //StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
        //string backstr = sr.ReadToEnd();
        ////Response.Write(backstr);
        //sr.Close();
        //res.Close();
        //return backstr;
        return "";
    }
    public static string postrequest(string url, System.Collections.Specialized.NameValueCollection PostVars)
    {
        try
        {
            System.Net.WebClient WebClientObj = new System.Net.WebClient();
            //WebClientObj.Headers.Add("Content-Type", "application/json");
            byte[] byRemoteInfo = WebClientObj.UploadValues(url, "POST", PostVars);

            string sRemoteInfo = System.Text.Encoding.UTF8.GetString(byRemoteInfo);

            return sRemoteInfo;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }


    public static NameValueCollection FillFromEncodedBytes(byte[] bytes, Encoding encoding)
    {
        NameValueCollection _form = new NameValueCollection();

        int num = (bytes != null) ? bytes.Length : 0;
        for (int i = 0; i < num; i++)
        {
            string str;
            string str2;
            int offset = i;
            int num4 = -1;
            while (i < num)
            {
                byte num5 = bytes[i];
                if (num5 == 0x3d)
                {
                    if (num4 < 0)
                    {
                        num4 = i;
                    }
                }
                else if (num5 == 0x26)
                {
                    break;
                }
                i++;
            }
            if (num4 >= 0)
            {
                str = HttpUtility.UrlDecode(bytes, offset, num4 - offset, encoding);
                str2 = HttpUtility.UrlDecode(bytes, num4 + 1, (i - num4) - 1, encoding);
            }
            else
            {
                str = null;
                str2 = HttpUtility.UrlDecode(bytes, offset, i - offset, encoding);
            }
            _form.Add(str, str2);
            if ((i == (num - 1)) && (bytes[i] == 0x26))
            {
                _form.Add(null, string.Empty);
            }
        }
        return _form;
    }



    public static string postrequest(string url, string s)
    {
        try
        {
            System.Net.WebClient WebClientObj = new System.Net.WebClient();
            //byte[] byRemoteInfo = WebClientObj.UploadValues(url, "POST", PostVars);
            byte[] byRemoteInfo = WebClientObj.UploadData(url, "POST", System.Text.Encoding.UTF8.GetBytes(s));
            string sRemoteInfo = System.Text.Encoding.UTF8.GetString(byRemoteInfo);
            return sRemoteInfo;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    private const double EARTH_RADIUS = 6378.137;//地球半径
    private static double rad(double d)
    {
        return d * Math.PI / 180.0;
    }

    public static double GetDistance(double lng1, double lat1, double lng2, double lat2)
    {
        double radLat1 = rad(lat1);
        double radLat2 = rad(lat2);
        double a = radLat1 - radLat2;
        double b = rad(lng1) - rad(lng2);

        double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
         Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
        s = s * EARTH_RADIUS;
        s = Math.Round(s * 10000) / 10000;

        if (s < 10)
        {
            s = Math.Round(s, 2);
        }
        else
        {
            s = Math.Round(s, 0);
        }

        return s;
    }


    public static string GetAddress(string lng, string lat)
    {
        try
        {
            //string url = @"http://api.map.baidu.com/geocoder/v2/ak=E4805d16520de693a3fe707cdc962045&callback=renderReverse&location=" + lat + "," + lng + @"&output=xml&pois=1";
            string url = @"http://api.map.baidu.com/geocoder/v2/ak=YG2iv0eCzo1z6YTsau5pgd24&callback=renderReverse&location=" + lat + "," + lng + @"&output=xml&pois=1";
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            XmlDocument xmlDoc = new XmlDocument();
            string sendData = xmlDoc.InnerXml;
            byte[] byteArray = Encoding.Default.GetBytes(sendData);

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, System.Text.Encoding.GetEncoding("utf-8"));
            string responseXml = reader.ReadToEnd();

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(responseXml);
            string status = xml.DocumentElement.SelectSingleNode("status").InnerText;
            if (status == "0")
            {

                XmlNodeList nodes = xml.DocumentElement.GetElementsByTagName("formatted_address");
                if (nodes.Count > 0)
                {
                    return nodes[0].InnerText;
                }
                else
                    return "未获取到位置信息,错误码3";
            }
            else
            {
                return "未获取到位置信息,错误码1";
            }
        }
        catch (System.Exception ex)
        {
            return "未获取到位置信息,错误码2";
        }
    }

    public static string smsmd5(string str)
    {
        byte[] result = Encoding.Default.GetBytes(str);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] output = md5.ComputeHash(result);
        String md = BitConverter.ToString(output).Replace("-", "");
        return md.ToLower();
    }

    public static void sendsms(string Phone, string Content)
    {
        ISmsService4XML sms = new SmsService4XMLClient();
        //XmlDocument doc = new XmlDocument();


        String Account = "dh7748";
        String Password = smsmd5("aaaa1111");
        //String Phone = "12312";
        String sendtime = "";
        String sign = "";
        String subcode = "";
        //String Content = "尊敬的" + "体检。Medi-plus服务咨询电话：4000993363";
        String message = "<?xml version='1.0' encoding='UTF-8'?><message>"
            + "<account>" + Account + "</account>" + "<password>"
            + Password + "</password>"
            + "<msgid></msgid>"
            + "<phones>" + Phone + "</phones><content>"
            + Content + "</content><sign>" + sign + "</sign>"
            + "<subcode>" + subcode + "</subcode><sendtime>" + sendtime + "</sendtime>"
            + "</message>";

        sms.submit(message);

    }

    public static string AssessmentReportToInterface(iAssessmentReport obj)
    {
        string strReport = string.Empty;
        if (obj != null)
        {
            
        }
        return strReport;
    }

}