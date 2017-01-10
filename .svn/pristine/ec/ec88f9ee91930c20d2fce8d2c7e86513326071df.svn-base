using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_discriptionAdmin_msgUpdate : System.Web.UI.Page
{
    Bll.newsBll nb = new Bll.newsBll();
    Model.tab_news modelNb = new Model.tab_news();
    string gs = "系统邮件"; //global string
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            content1.Value = nb.getfirst(gs,"msg");
            TextBox1.Text = nb.getfirst(gs,"title");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            modelNb.discription = gs;
            modelNb.title = DropDownList1.SelectedValue;
            modelNb = nb.getNews(modelNb);

            modelNb.title = TextBox1.Text;
            modelNb.msg = content1.Value.Replace("'", "''");
            nb.update(modelNb);

            int si = this.DropDownList1.SelectedIndex;
            this.DropDownList1.DataBind();
            this.DropDownList1.SelectedIndex = si;
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('更新成功！');</script>");
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('保存失败！" + ex.Message + "');</script>");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        modelNb.discription = gs;
        modelNb.title = DropDownList1.SelectedValue;
        modelNb = nb.getNews(modelNb);
        content1.Value = modelNb.msg;
        TextBox1.Text = modelNb.title;
    }
}