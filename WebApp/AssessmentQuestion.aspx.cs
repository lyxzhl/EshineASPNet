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
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssessmentQuestion : PublicClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AssessmentQuestionBll cb = new AssessmentQuestionBll();
        Byte[] bytes = Request.BinaryRead(Request.ContentLength);
        NameValueCollection req = FillFromEncodedBytes(bytes, Encoding.UTF8);
        string QTShortName = req["ShortName"];
        int AQGender = int.Parse(req["Gender"]);
        int Age = int.Parse(req["Age"]);
        int Marriage = int.Parse(req["Marriage"]);
        //1.TijianID is not null,ID is null
        //return ID List
        //2.TijianID is not null,ID is not null
        //return ID ==> DataRow


        DataTable dt = MediPlus.login.tijianwj(QTShortName, AQGender, Age, Marriage);
        if (dt != null)
        {
            List<AssessmentQuestionApp> intList = TableToList.ConvertTo<AssessmentQuestionApp>(dt).ToList();

            //pi.code = "1";
            //pi.message = "查询成功";

            string jsonString = javascript.Serialize(intList);
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
}