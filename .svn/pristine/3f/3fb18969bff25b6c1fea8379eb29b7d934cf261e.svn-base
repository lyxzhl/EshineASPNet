using Bll;
using Model;
using Model.WebApp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tijiandaod : PublicClass
{
    //public class logininfo
    //{
    //    public string code;
    //    public string message;
    //    public List<Dictionary<string, object>> data;
    //    public string key;
    //}
    //PublicClass pc = new PublicClass();
    //tijiandaoh pi = new tijiandaoh();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            QuestionType mocu = new QuestionType();
            QuestionTypeBll cb = new QuestionTypeBll();
          
            Byte[] bytes = Request.BinaryRead(Request.ContentLength);
            NameValueCollection req = FillFromEncodedBytes(bytes, Encoding.UTF8);
            string Tijian = req["Tijian"].ToString();
          
            DataTable dt = MediPlus.login.tijiandaoh(Tijian);
            if (dt != null)
            {
                List<QuestionTypeApp> list = TableToList.ConvertTo<QuestionTypeApp>(dt).ToList();
         
                string jsonString =javascript.Serialize(list);
                Response.Write(jsonString);
            }
            else
            {
                //pi.code = "0";
                //pi.message = "id错误";
                //string jsonString1 = javascript.Serialize(pi);
                //Response.Write(jsonString1);
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
}