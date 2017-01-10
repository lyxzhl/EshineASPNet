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
using System.IO;
using System.Text;

public partial class Admin_empAdmin_empInfo :basePage
{
    GetPowerPage power = new GetPowerPage();
    Bll.empBll pow = new Bll.empBll();
    Model.tab_emps tem = new Model.tab_emps();
    Model.tab_roles roles = new Model.tab_roles();
    Bll.RolesBll ro = new Bll.RolesBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this.CheckUser((Hashtable)Application["Online"]);
            this.DropDownList1.DataSource = ro.GetAll();
            this.DropDownList1.DataTextField = "roleName";
            this.DropDownList1.DataValueField = "roleID";
            this.DropDownList1.DataBind();
            this.DropDownList1.Items.Insert(0, new ListItem("------", "0"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        StringBuilder strsel = new StringBuilder();
        strsel.Append("SELECT tab_roles.roleName, tab_emps.empID, tab_emps.empName FROM tab_emps INNER JOIN tab_roles ON tab_emps.roleID = tab_roles.roleID ");
        strsel.AppendFormat(" and empName like '{0}'+'%' ", this.TextBox1.Text);
        if (this.DropDownList1.SelectedIndex > 0)
        strsel.AppendFormat(" and tab_roles.roleID={0}", this.DropDownList1.SelectedValue);
        this.empDataSource.SelectCommand = strsel.ToString();
        this.empDataSource.DataBind();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.ContentType = "application/excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        GridView gv = new GridView();

        gv.DataSource = this.empDataSource;
        gv.DataBind();
        gv.RenderControl(htw);
        //string style = @"<style> .text { mso-number-format:\@; } </script> ";
        //Response.Write(style);
        Response.Write(sw.ToString());
        Response.End();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.empDataSource.DeleteCommand = "delete from tab_emps where empID=" + this.GridView1.DataKeys[e.RowIndex].Value;
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
