using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
/// <summary>
/// StrSecurity 的摘要说明
/// </summary>
public class StrSecurity
{
    public static bool CheckStr(string str)
    {
        bool zr = true;
        string ss = "',and,select,delete,insert,or,exec,<>,script,alert,(,),drop,mid,order";
        string[] aa = ss.Split(',');
        for (int i = 0; i < aa.Length; i++)
        {
            if (str.Length >= aa.Length)
            {
                if (str.IndexOf(aa[i].ToString(), 0) != -1)
                {
                    zr = false;
                }
            }
            else
            {
                if (str.IndexOf(aa[i].ToString(), 0, str.Length) != -1)
                {
                    zr = false;
                }
            }
            
        }
        return zr;
    }
}
