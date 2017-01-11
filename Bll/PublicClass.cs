using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Web;
using System.Data;

namespace Bll
{
    public class PublicClass
    {
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

        public static string BuildRandomStr(int length)
        {
            string str = new Random().Next().ToString();
            if (str.Length > length)
            {
                return str.Substring(0, length);
            }
            if (str.Length < length)
            {
                for (int i = length - str.Length; i > 0; i--)
                {
                    str.Insert(0, "0");
                }
            }
            return str;
        }
        public static string CheckCidInfo(string cid, ref DateTime dob, ref string gender, ref string constellation)//检查身份证
        {
            string[] aCity = new string[] { null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "新疆", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null, null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外" };
            double iSum = 0;
            string info = "";
            Regex rg = new Regex(@"^\d{17}(\d|x)$");
            Match mc = rg.Match(cid);
            if (!mc.Success)
            {
                return "必须为18位数字或x结尾";
            }
            cid = cid.ToLower();
            cid = cid.Replace("x", "a");
            if (aCity[int.Parse(cid.Substring(0, 2))] == null)
            {
                return "非法地区";
            }
            try
            {
                DateTime.Parse(cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2));
            }
            catch
            {
                return "非法生日";
            }
            for (int i = 17; i >= 0; i--)
            {
                iSum += (Math.Pow(2, i) % 11) * int.Parse(cid[17 - i].ToString(), System.Globalization.NumberStyles.HexNumber);

            }
            if (iSum % 11 != 1)
                return ("非法证号");

            dob = DateTime.Parse(cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2));
            gender = (int.Parse(cid.Substring(16, 1)) % 2 == 1 ? "男" : "女");
            constellation = GetAtomFromBirthday(dob);

            return ("合法身份证号");

            //return (aCity[int.Parse(cid.Substring(0, 2))] + "," + cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2) + "," + (int.Parse(cid.Substring(16, 1)) % 2 == 1 ? "男" : "女"));

        }

        public static bool checkemailinfo(string email)
        {
            return Regex.IsMatch(email, "^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
        }
        public static bool checkmobileinfo(string mobile)
        {
            return Regex.IsMatch(mobile, "^1[3|4|5|7|8][0-9]\\d{4,8}$");
        }

        public static string GetAtomFromBirthday(DateTime birthday)
        {
            float birthdayF = 0.00F;

            if (birthday.Month == 1 && birthday.Day < 20)
            {
                birthdayF = float.Parse(string.Format("13.{0}", birthday.Day));
            }
            else
            {
                birthdayF = float.Parse(string.Format("{0}.{1}", birthday.Month, birthday.Day));
            }
            float[] atomBound = { 1.20F, 2.20F, 3.21F, 4.21F, 5.21F, 6.22F, 7.23F, 8.23F, 9.23F, 10.23F, 11.21F, 12.22F, 13.20F };
            string[] atoms = { "水瓶座", "双鱼座", "白羊座", "金牛座", "双子座", "巨蟹座", "狮子座", "处女座", "天秤座", "天蝎座", "射手座", "魔羯座" };

            string ret = "靠！外星人啊。";
            for (int i = 0; i < atomBound.Length - 1; i++)
            {
                if (atomBound[i] <= birthdayF && atomBound[i + 1] > birthdayF)
                {
                    ret = atoms[i];
                    break;
                }
            }
            return ret;
        }

        public static NameValueCollection FillFromEncodedBytes(byte[] bytes, Encoding encoding)
        {
            NameValueCollection values = new NameValueCollection();
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
                values.Add(str, str2);
                if ((i == (num - 1)) && (bytes[i] == 0x26))
                {
                    values.Add(null, string.Empty);
                }
            }
            return values;
        }

        public List<Dictionary<string, object>> ToJsonlist(DataTable dt)
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

        public static string getrequest(string url)
        {
            try
            {
                System.Net.WebClient WebClientObj = new System.Net.WebClient();
                byte[] byRemoteInfo = WebClientObj.DownloadData(url);

                string sRemoteInfo = System.Text.Encoding.UTF8.GetString(byRemoteInfo);
                return sRemoteInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
