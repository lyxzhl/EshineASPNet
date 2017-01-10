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
using System.IO;
public partial class Admin_roleAdmin_roleInfo :basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this.CheckUser((Hashtable)Application["Online"]);
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
        Response.ContentType = "application/excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        GridView gv = new GridView();

        gv.DataSource = this.roleDataSource;
        gv.DataBind();
        gv.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        StringBuilder strsel = new StringBuilder();
        strsel.Append("SELECT [roleID], [roleName], [roleContent] FROM [tab_roles] ");
        strsel.AppendFormat(" where roleName like '{0}'+'%'", this.TextBox1.Text);
        this.roleDataSource.SelectCommand = strsel.ToString();
        this.roleDataSource.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.roleDataSource.DeleteCommand = "delete from tab_roles where roleID=" + this.GridView1.DataKeys[e.RowIndex].Value;
        this.GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // 为每一个数据行添加两个属性，实现当鼠标经过时高亮的效果

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //鼠标移到该行时所在行变颜色，移出时恢复原来颜色

                e.Row.Attributes.Add("onMouseOver", "this.style.cursor='hand';this.originalcolor=this.style.backgroundColor;this.style.backgroundColor='#E2DED6';");
                e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=this.originalcolor;");
            }
            //Onclick删除按钮事件，弹出提示对话框，提示是否想要删除该记录

        }
        if (e.Row.DataItemIndex == -1)
        {
            return;
        }

    }
}
