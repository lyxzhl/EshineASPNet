using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AssessmentReport : PublicClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Error = "";
        try
        {

            Byte[] bytes = Request.BinaryRead(Request.ContentLength);
            NameValueCollection req = FillFromEncodedBytes(bytes, Encoding.UTF8);
            int customerID;
            if (!int.TryParse(req["customerID"].ToString(), out customerID))
            {
                Error = "你错了";
            }
            int CType;
            if (!int.TryParse(req["CType"].ToString(), out CType))
            {
                Error = "你错了";
            }
            int customerGender;
            if (!int.TryParse(req["customerGender"].ToString(), out customerGender))
            {
                Error = "你错了";
            }
            int Marriage;
            if (!int.TryParse(req["Marriage"].ToString(), out Marriage))
            {
                Error = "你错了";
            }
            DateTime customerDOB;
            if (!DateTime.TryParse(req["customerDOB"].ToString(), out customerDOB))
            {
                Error = "你错了";
            }
            string customerCode = req["customerCode"];
            string QTShortName = req["QTShortName"];
            string ARDetail = req["ARDetail"];

            DataTable  dt = MediPlus.login.report(customerID,CType,customerCode,customerGender,customerDOB,QTShortName,ARDetail,Marriage);
            if (dt != null)
            {
                //List<AssessmentQuestionObj> list = TableToList.ConvertTo<AssessmentQuestionObj>(dt).ToList();

                string jsonString = javascript.Serialize(dt);
                Response.Write(jsonString);
            }
            else
            {
                //pi.code = "0";
                //pi.message = "id错误";
                //string jsonString1 = javascript.Serialize(pi);
                //Response.Write(jsonString1);
            }
            //Response.End();
        }
        catch (Exception ex)
        {
            Response.Write(Error.ToString());
        }
    }
}