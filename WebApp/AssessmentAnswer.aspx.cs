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

public partial class AssessmentAnswer : PublicClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AssessmentAnswerBll cb = new AssessmentAnswerBll();

        Byte[] bytes = Request.BinaryRead(Request.ContentLength);
        NameValueCollection req = FillFromEncodedBytes(bytes, Encoding.UTF8);

        int AQID = int.Parse(req["AQID"]);//类别题目Id

        AssessmentQuestionObj dt = MediPlus.login.tijiandaan(AQID);
        if (dt != null)
        {
            Response.Write(javascript.Serialize(dt));
        }
        else
        {
            //pi.code = "0";
            //pi.message = "id错误";
            //string jsonString1 = javascript.Serialize(pi);
            //Response.Write(jsonString1);
        }
        Response.End();
    }
}