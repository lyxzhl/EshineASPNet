using Model.WebApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class jiekpost : PublicClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        System.Collections.Specialized.NameValueCollection PostVars;
        PostVars = new System.Collections.Specialized.NameValueCollection();

        //Dictionary<string, object> ans = new Dictionary<string, object>();
        //ans.Add("1", 1);
        //ans.Add("2", 31);
        //ans.Add("3", 0);
        //ans.Add("4", 0);
        //ans.Add("5", 0);
        //ans.Add("6", 139);
        //ans.Add("7", 33);
        //ans.Add("8", 33);
        List<iAnswerItem> list = new List<iAnswerItem>();
        List<iAnswer> listcall = new List<iAnswer>();

        list.Add(new iAnswerItem
        {
            qid = "bmi",
            qvalue = "21.9"
        });
        list.Add(new iAnswerItem
        {
            qid = "whr",
            qvalue = "0.9"
        });
        list.Add(new iAnswerItem
        {
            qid = "q5",
            qvalue = "0"
        });
        list.Add(new iAnswerItem
        {
            qid = "q18",
            qvalue = "0"
        });
        list.Add(new iAnswerItem
        {
            qid = "q23",
            qvalue = "-1.5|-1"
        });
        list.Add(new iAnswerItem
        {
            qid = "q24",
            qvalue = "-1.5|-1"
        });
        list.Add(new iAnswerItem
        {
            qid = "q25",
            qvalue = "1"
        });
        list.Add(new iAnswerItem
        {
            qid = "q26",
            qvalue = "2"
        });

        Dictionary<string, string> dicList = new Dictionary<string, string>();
        dicList.Add("year", "1984");
        dicList.Add("month", "3");
        dicList.Add("day", "9");

        list.Add(new iAnswerItem
        {
            qid = "birthday",
            qvalue = dicList
        });
        list.Add(new iAnswerItem
        {
            qid = "gender",
            qvalue = "0"
        });
        listcall.Add(new iAnswer
        {
                 qclass = "health",
                 qlist = list
         });
        // iAnswer qwcalls = new iAnswer();


        List<iAnswerItem> list1 = new List<iAnswerItem>();

        list1.Add(new iAnswerItem
        {
            qid = "q65",
            qvalue = "0.5"
        });
        list1.Add(new iAnswerItem
        {
            qid = "q66",
            qvalue = "-1"
        });
        list1.Add(new iAnswerItem
        {
            qid = "q67",
            qvalue = "0"
        });
        list1.Add(new iAnswerItem
        {
            qid = "q68",
            qvalue = "0"
        });
        list1.Add(new iAnswerItem
        {
            qid = "q69",
            qvalue = "0.5"
        });
        list1.Add(new iAnswerItem
        {
            qid = "q70",
            qvalue = "-0.5"
        });
        list1.Add(new iAnswerItem
        {
            qid = "q30",
            qvalue = "0"
        });
        list1.Add(new iAnswerItem
        {
            qid = "q64",
            qvalue = "0.5"
        });

        listcall.Add(new iAnswer
        {
            qclass = "health_2",
            qlist = list1
        });


        List<iAnswerItem> list2 = new List<iAnswerItem>();

        list2.Add(new iAnswerItem
        {
            qid = "q71",
            qvalue = "0"
        });
        list2.Add(new iAnswerItem
        {
            qid = "q72",
            qvalue = "0"
        });
        list2.Add(new iAnswerItem
        {
            qid = "q73",
            qvalue = "0"
        });
        list2.Add(new iAnswerItem
        {
            qid = "q74",
            qvalue = "0"
        });
        list2.Add(new iAnswerItem
        {
            qid = "q75",
            qvalue = "0"
        });
        list2.Add(new iAnswerItem
        {
            qid = "q76",
            qvalue = "-0.5"
        });
        list2.Add(new iAnswerItem
        {
            qid = "q77",
            qvalue = "0"
        });
        

        listcall.Add(new iAnswer
        {
            qclass = "health_3",
            qlist = list2
        });


        List<iAnswerItem> list3 = new List<iAnswerItem>();

        list3.Add(new iAnswerItem
        {
            qid = "q47",
            qvalue = "0"
        });
        list3.Add(new iAnswerItem
        {
            qid = "q48",
            qvalue = "-0.5"
        });
        list3.Add(new iAnswerItem
        {
            qid = "q51",
            qvalue = "-0.5"
        });
        list3.Add(new iAnswerItem
        {
            qid = "q50",
            qvalue = "-0.5"
        });
     
       

        listcall.Add(new iAnswer
        {
            qclass = "hereditary",
            qlist = list3
        });



        
        List<iAnswerItem> list4 = new List<iAnswerItem>();

        list4.Add(new iAnswerItem
        {
            qid = "q9",
            qvalue = "-3"
        });
        list4.Add(new iAnswerItem
        {
            qid = "q13",
            qvalue = "0"
        });
        list4.Add(new iAnswerItem
        {
            qid = "q16",
            qvalue = "-0.5|0"
        });
        list4.Add(new iAnswerItem
        {
            qid = "q21",
            qvalue = "1"
        });
        list4.Add(new iAnswerItem
        {
            qid = "q22",
            qvalue = "1"
        });
        list4.Add(new iAnswerItem
        {
            qid = "q27",
            qvalue = "-1.5"
        });
        list4.Add(new iAnswerItem
        {
            qid = "q28",
            qvalue = "1.5"
        });
        list4.Add(new iAnswerItem
        {
            qid = "q29",
            qvalue = "-2"
        });
        list4.Add(new iAnswerItem
        {
            qid = "q39",
            qvalue = "0.5"
        });
        list4.Add(new iAnswerItem
        {
            qid = "q41",
            qvalue = "0"
        });



        listcall.Add(new iAnswer
        {
            qclass = "habits",
            qlist = list4
        });




           List<iAnswerItem> list5 = new List<iAnswerItem>();

        list5.Add(new iAnswerItem
        {
            qid = "q14",
            qvalue = "-0.5"
        });
        list5.Add(new iAnswerItem
        {
            qid = "q15",
            qvalue = "-0.5"
        });
        list5.Add(new iAnswerItem
        {
            qid = "q31",
            qvalue = "-1"
        });
        list5.Add(new iAnswerItem
        {
            qid = "q32",
            qvalue = "-1"
        });
        list5.Add(new iAnswerItem
        {
            qid = "q33",
            qvalue = "-1"
        });
        list5.Add(new iAnswerItem
        {
            qid = "q34",
            qvalue = "0"
        });
        list5.Add(new iAnswerItem
        {
            qid = "q35",
            qvalue = "0"
        });
        list5.Add(new iAnswerItem
        {
            qid = "q36",
            qvalue = "-1"
        });

        listcall.Add(new iAnswer
        {
            qclass = "diet",
            qlist = list5
        });



            List<iAnswerItem> list6 = new List<iAnswerItem>();

        list6.Add(new iAnswerItem
        {
            qid = "q37",
            qvalue = "-1"
        });
        list6.Add(new iAnswerItem
        {
            qid = "q38",
            qvalue = "-2"
        });
        list6.Add(new iAnswerItem
        {
            qid = "q40",
            qvalue = "-1"
        });
        list6.Add(new iAnswerItem
        {
            qid = "q42",
            qvalue = "-1"
        });
        list6.Add(new iAnswerItem
        {
            qid = "q43",
            qvalue = "0.5"
        });
        list6.Add(new iAnswerItem
        {
            qid = "q44",
            qvalue = "0"
        });
        list6.Add(new iAnswerItem
        {
            qid = "q45",
            qvalue = "0"
        });
        list6.Add(new iAnswerItem
        {
            qid = "q46",
            qvalue = "0"
        });
      

        listcall.Add(new iAnswer
        {
            qclass = "diet_2",
            qlist = list6
        });


        
            List<iAnswerItem> list7 = new List<iAnswerItem>();

        list7.Add(new iAnswerItem
        {
            qid = "q17",
            qvalue = "0"
        });
        list7.Add(new iAnswerItem
        {
            qid = "q19",
            qvalue = "-1"
        });
        list7.Add(new iAnswerItem
        {
            qid = "q20",
            qvalue = "0.5"
        });


        listcall.Add(new iAnswer
        {
            qclass = "fitness",
            qlist = list7
        });


            List<iAnswerItem> list8 = new List<iAnswerItem>();

        list8.Add(new iAnswerItem
        {
            qid = "q10",
            qvalue = "0"
        });
        list8.Add(new iAnswerItem
        {
            qid = "q11",
            qvalue = "0"
        });
        list8.Add(new iAnswerItem
        {
            qid = "q12",
            qvalue = "0"
        });


        listcall.Add(new iAnswer
        {
            qclass = "environment",
            qlist = list8
        });


        List<iAnswerItem> list9 = new List<iAnswerItem>();

        list9.Add(new iAnswerItem
        {
            qid = "q52",
            qvalue = "1"
        });
        list9.Add(new iAnswerItem
        {
            qid = "q54",
            qvalue = "-0.5"
        });
        list9.Add(new iAnswerItem
        {
            qid = "q56",
            qvalue = "-2"
        });
        list9.Add(new iAnswerItem
        {
            qid = "q57",
            qvalue = "0"
        });
        list9.Add(new iAnswerItem
        {
            qid = "q58",
            qvalue = "-1"
        });
        list9.Add(new iAnswerItem
        {
            qid = "q59",
            qvalue = "0"
        });


        listcall.Add(new iAnswer
        {
            qclass = "stress",
            qlist = list9
        });

        List<iAnswerItem> list10 = new List<iAnswerItem>();

        list10.Add(new iAnswerItem
        {
            qid = "q6",
            qvalue = "-0.5"
        });
        list10.Add(new iAnswerItem
        {
            qid = "q7",
            qvalue = "-0.5"
        });
        list10.Add(new iAnswerItem
        {
            qid = "q8",
            qvalue = "-1"
        });

        list10.Add(new iAnswerItem
        {
            qid = "q49",
            qvalue = "-0.5"
        });
        list10.Add(new iAnswerItem
        {
            qid = "q53",
            qvalue = "0"
        });
        list10.Add(new iAnswerItem
        {
            qid = "q55",
            qvalue = "1.5"
        });

        list10.Add(new iAnswerItem
        {
            qid = "q60",
            qvalue = "0"
        });
        list10.Add(new iAnswerItem
        {
            qid = "q61",
            qvalue = "-1.5|-0.5"
        });
        list10.Add(new iAnswerItem
        {
            qid = "q62",
            qvalue = "0"
        });
        list10.Add(new iAnswerItem
        {
            qid = "q63",
            qvalue = "0"
        });


        listcall.Add(new iAnswer
        {
            qclass = "others",
            qlist = list10
        });

        //string output = jss.Serialize(qwcalls);
        //PostVars.Add("answer", output);
        //PostVars.Add("disease", "heart-attack");
        //PostVars.Add("user", "13456");

        iAssessmentReport info1 = new iAssessmentReport();
        info1.alist = new List<iAnswer>();
        info1.alist = listcall;
        info1.user = "1235";

        string temp;
        string url = "http://www.drmed.cn/api/overall";

        url += "?appkey=" + "b32a34fabefe7f04";
        temp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();

        url += "&timestamp=" + temp;
        temp = "b32a34fabefe7f04" + "-" + "2c6bcc543f6f0c07435b5a6dcb90c96a" + "-" + temp;

        url += "&token=" + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(temp, "MD5").ToLower();

        url += "&version=1.1";

         string s;
        //s= PublicClass.postrequest(url, PostVars);
        s = getrequest(url,getJsonToInerface(info1));
        Response.Write(s);


    }

    private  string getrequest(string url, string JSONData)
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

    /// <summary>
    /// 根据实体转换成接口认可的数据格式
    /// </summary>
    /// <param name="report">实体对象</param>
    /// <returns></returns>
    public string getJsonToInerface(iAssessmentReport report)
    {
        JavaScriptSerializer javascript = new JavaScriptSerializer();
        Dictionary<string, object> dictReport = new Dictionary<string, object>();
        if (dictReport != null)
        {
            string answer = string.Empty;
            Dictionary<string, object> dictAnswer = new Dictionary<string, object>();
            foreach (var aitem in report.alist)
            {
                if (checkItemStr(aitem.qclass) == "")
                    continue;
                if (aitem.qlist.Count() < 1)
                    continue;
                Dictionary<string, object> dictAnswerList = new Dictionary<string, object>();
                foreach (var qitem in aitem.qlist)
                {
                    if (checkItemStr(qitem.qid) == "")
                        continue;
                    dictAnswerList.Add(qitem.qid, qitem.qvalue);
                }
                dictAnswer.Add(aitem.qclass, dictAnswerList);
            }
            dictReport.Add("answer", dictAnswer);
            dictReport.Add("user", "xxxx");
        }
        return javascript.Serialize(dictReport);
    }

    /// <summary>
    /// 检查字符串值
    /// </summary>
    /// <param name="value">所判断的值</param>
    /// <returns></returns>
    public string checkItemStr(string value)
    {
        if (!string.IsNullOrEmpty(value) && value.Trim().ToString() != "")
            return value;
        return "";
    }

}