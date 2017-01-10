using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class Admin_login_admin_left : System.Web.UI.Page
{
    public int f=0; 
    Bll.RolesBll ro = new Bll.RolesBll();
        Model.tab_roles model =new Model.tab_roles();
        Bll.ProwerBll bp = new Bll.ProwerBll();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            ViewState["roleID"] = int.Parse(Session["roleID"].ToString());
            model.RoleID = Convert.ToInt32(ViewState["roleID"]);
            DataTable dt = ro.GetAny(model);
            string roleInfo = dt.Rows[0]["roleInfo"].ToString();
            string[] pows = roleInfo.Split('|');
            powerBind(pows);
        }
        
    }
    void powerBind(string[] pows)
    {
        StringBuilder strsql=new StringBuilder ();
        StringBuilder sb = new StringBuilder();
        sb.Append("(select distinct powerPID from tab_powers where powerPID<>0 and");
        strsql.Append("select * from tab_powers where powerPID<>0 and");
        foreach (string pow in pows)
        {
            strsql.AppendFormat(" powerID={0} or", pow);
            sb.AppendFormat(" powerID={0} or", pow);
        }
        strsql.Remove(strsql.Length - 2, 2);
        sb.Remove(sb.Length - 2, 2);
        sb.Append(")");
        DataSet ds = ro.GetPowClass("select * from tab_powers where powerPID=0 and powerID in "+sb.ToString(), strsql.ToString());
        ds.Relations.Add("pc", ds.Tables[0].Columns["powerID"], ds.Tables[1].Columns["powerPID"]);
        this.Repeater1.DataSource = ds.Tables[0];
        this.Repeater1.DataBind();
    }
}
