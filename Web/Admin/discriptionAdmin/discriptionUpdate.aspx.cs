using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_discriptionAdmin_discriptionUpdate : System.Web.UI.Page
{
    Bll.newsBll nb = new Bll.newsBll();
    Model.tab_news modelNb = new Model.tab_news();
    string gs = "静态文本"; //global string
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            init();
        }
    }
    void init()
    {
        DataTable dt = nb.NewsSelect("SELECT title,title_eng,msg,msg_eng FROM [tab_news] WHERE [discription] = '静态文本'");
        this.DropDownList1.Items.Clear();
        foreach (DataRow dr in dt.Rows)
        {
            if (Session["language"] != null && Session["language"].ToString() == "en-us")
            {
                this.DropDownList1.Items.Add(dr["title_eng"].ToString());
            }
            else
            {
                this.DropDownList1.Items.Add(dr["title"].ToString());
            }
        }
        if (dt.Rows.Count > 0)
        {
            if (Session["language"] != null && Session["language"].ToString() == "en-us")
            {
                content1.Value = dt.Rows[0]["msg_eng"].ToString();
            }
            else
            {
                content1.Value = dt.Rows[0]["msg"].ToString();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            
            if (Session["language"] != null && Session["language"].ToString() == "en-us")
            {
                modelNb.title_eng = DropDownList1.SelectedValue;
                modelNb = nb.getNews(modelNb);
                modelNb.msg_eng = content1.Value.Replace("'", "''");
            }
            else
            {
                modelNb.title = DropDownList1.SelectedValue;
                modelNb = nb.getNews(modelNb);
                modelNb.msg = content1.Value.Replace("'", "''");
            }
            nb.update(modelNb);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('更新成功！');</script>");
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('保存失败！"+ex.Message+"');</script>");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["language"] != null && Session["language"].ToString() == "en-us")
        {
            modelNb.title_eng = DropDownList1.SelectedValue;
            modelNb = nb.getNews(modelNb);
            content1.Value = modelNb.msg_eng;
        }
        else
        {
            modelNb.title = DropDownList1.SelectedValue;
            modelNb = nb.getNews(modelNb);
            content1.Value = modelNb.msg;
        }
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        init();
    }
}