using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data;
using MediPlus;
using Model;

public partial class tijiajiashu : System.Web.UI.Page
{
    public class info
    {
        public string code;
        public string message;

        public int memberid;
        public string key;

        public List<Dictionary<string, object>> data;
    }
    JavaScriptSerializer jss = new JavaScriptSerializer();
    PublicClass pc = new PublicClass();
    protected void Page_Load(object sender, EventArgs e)
    {
          Model.tab_relatives moreti= new tab_relatives();
         Bll.RelativeBLL cb= new Bll.RelativeBLL ();
            info io = new info();
        try
        {
             string relativeCustomer = Request.Form["relativeCustomer"];
            string relativeName = Request.Form["relativeName"];
            string relativeMobile = Request.Form["relativeMobile"];
            string relativeGender = Request.Form["relativeGender"];
            string MarriageStatus = Request.Form["MarriageStatus"];
            string relativeIDcard = Request.Form["relativeIDcard"];
            DateTime relativeDOB = DateTime.Parse(Request.Form["relativeDOB"]);
            string Relationship = Request.Form["Relationship"];
                int count = MediPlus.login.tiajiajiashu(relativeCustomer,relativeName,relativeMobile,relativeGender,MarriageStatus,relativeIDcard,relativeDOB,Relationship);

                if (count == -1)
                {
                    io.code = "0";
                    io.message = "身份证号重复";
                }
                else if (count == -2)
                {
                    io.code = "0";
                    io.message = "id重复";
                }
                else
                {
                 cb.RelativeAdd(moreti);

                    io.code = "1";
                    io.message = "注册成功";
                    io.memberid = moreti.relativeCustomer;


                }
            }
        catch (Exception ex)
        {
            io.code = "0";
            io.message = ex.ToString();
        }
        string jsonString = jss.Serialize(io);
        Response.Write(jsonString);
    }
    
}