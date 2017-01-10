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
public partial class Admin_powerAdmin_powerInfo : basePage
{
    GetPowerPage power = new GetPowerPage();
    Bll.ProwerBll pow = new Bll.ProwerBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this.CheckUser((Hashtable)Application["Online"]);
            GetPower(this.DropDownList1);
        }
    }
    public void GetPower(DropDownList dp)
    {
        DataTable dt = pow.GetProwerAny("select powerID,powerName from tab_powers where powerPID=0");
        dp.DataSource = dt;
        dp.DataTextField = "powerName";
        dp.DataValueField = "powerID";
        dp.DataBind();
        dp.Items.Insert(0, new ListItem("------", "0"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        StringBuilder strsel = new StringBuilder();
        strsel.Append("SELECT * FROM [v_power] ");
        strsel.AppendFormat(" where powerName like '{0}'+'%'", this.TextBox1.Text);
        if (this.DropDownList1.SelectedIndex > 0)
        strsel.AppendFormat("and powerPID={0}", this.DropDownList1.SelectedValue);
        this.powDataSource.SelectCommand = strsel.ToString();
        this.powDataSource.DataBind();
        

      
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
        Response.ContentType = "application/excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        GridView gv = new GridView();

        gv.DataSource = this.powDataSource;
        gv.DataBind();
        gv.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    protected void GridView1_DataBinding(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.powDataSource.DeleteCommand = "delete from tab_powers where powerID=" + this.GridView1.DataKeys[e.RowIndex].Value;
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
        ImageButton imb = (ImageButton)e.Row.FindControl("ImageButton1");
        imb.Attributes.Add("onclick", "javascript:return confirm('你确定要删除吗?')");
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
 
    }
}
