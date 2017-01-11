using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using System.Data;
using Bll;

namespace Senparc.Weixin.MP.Sample.WebForms.webpage.webinterface
{
    public partial class ExchangeData : System.Web.UI.Page
    {
        public class info
        {
            public int code;
            public string message;
            public string data;
        }

        public struct ExData
        {
            public string exchange_code;
            public string product_code;
            public string vol_date;
            public string link_contract;
            public string link_contract_list;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Stopwatch watch1 = new Stopwatch();
            watch1.Start();
            info info = new info();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            NameValueCollection req = PublicClass.FillFromEncodedBytes(base.Request.BinaryRead(base.Request.ContentLength), Encoding.UTF8);

            try
            {
                if (req["excode"].Length>0)
                {
                    info.code = 1;
                    info.message = "成功";
                    info.data = loaddata(req["excode"]);
                }
                else
                {
                    info.code = 0;
                    info.message = "失败";
                }
            }
            catch (Exception ex)
            {
                //new Thread(() => errorBll.log("interface_ExchangeData", ex.ToString(), "")).Start();
            }

            string str = serializer.Serialize(info);
            Response.Write(str);
            watch1.Stop();
            //new Thread((ThreadStart)(() => log_interfaceBll.add("wx_mko2oorder", Convert.ToInt32(watch1.ElapsedMilliseconds)))).Start();
        }
        

        public string loaddata(string ExCode)
        {
            List<ExData> datalist = new List<ExData>();

            //Bll.AssetPrice apBll = new Bll.AssetPrice();
            //DataTable dt = apBll.getContractByExCode(ExCode);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    DataTable contrctdt = apBll.getCoefByContract(dr["link_contract"].ToString());

            //    ExData ExData = new webinterface.ExchangeData.ExData();
            //    ExData.exchange_code = dr["exchange_code"].ToString();
            //    ExData.product_code = dr["product_code"].ToString();
            //    ExData.vol_date = dr["vol_date"].ToString();
            //    ExData.link_contract = dr["link_contract"].ToString();
            //    ExData.link_contract_list = new JavaScriptSerializer().Serialize(publicclass.ToJsonlist(contrctdt));

            //    datalist.Add(ExData);
            //}
            return new JavaScriptSerializer().Serialize(datalist);
        }
    }
}