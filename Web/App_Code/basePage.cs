using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.IO;
using System.Text;
using System.Data.SqlClient;
//下载于51aspx.com
/// <summary>
/// basePage 的摘要说明
/// </summary>
public class basePage : System.Web.UI.Page
{
    Bll.RolesBll ro = new Bll.RolesBll();
    Model.tab_roles modleRo = new Model.tab_roles();
    Bll.ProwerBll pr = new Bll.ProwerBll();
    public basePage()
    {
        //Response.Write("wwww");
    }
    public void CheckUser()
    {
        //判断用户是否登陆
        if (Session["roleID"] == null)
        {
            //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('aaa')</script>");
            Response.Write("<script>parent.location='../login.aspx'</script>");
            return;
        }
        ViewState["roleID"] = int.Parse(Session["roleID"].ToString());
        modleRo.RoleID = Convert.ToInt32(ViewState["roleID"].ToString());
       DataTable dr= ro.GetAny(modleRo);
        
       // SqlDataReader dr = SQLAccess.ExecuteDataReader("select roleInfo from tab_roles where roleID=" + Convert.ToInt32(ViewState["roleID"]));
        string roleInfo = dr.Rows[0]["roleInfo"].ToString();
        string[] pows = roleInfo.Split('|');//获取登陆用户的权限信息
        powerBind(pows);

    }
    void powerBind(string[] pows)
    {
        StringBuilder strsql = new StringBuilder();
        strsql.Append("select powerUrl from tab_powers where powerPID<>0 and");
        foreach (string pow in pows)
        {
            strsql.AppendFormat(" powerID={0} or", pow);
        }
        strsql.Remove(strsql.Length - 2, 2);
        DataTable ds = pr.GetProwerAny(strsql.ToString());
        int count = 0;
        //将所有权限路径全部获取，然后和地址栏中的路径对比看是否有匹配的路径（如果没有说明没有权限访问）
        for (int i = 0; i < ds.Rows.Count; i++)
        {
            string purl = ds.Rows[i]["powerUrl"].ToString().Replace("\\","/");
            if (Request.FilePath.IndexOf(purl) > 0)
            {
                count++;
                break;
            }
        }
        //count为0说明没有匹配的路径
        if (count == 0)
        {
            Response.Write("<script>location='../login.aspx'</script>");
        }
    }

}
