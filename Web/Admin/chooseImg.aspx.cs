using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_chooseImg : System.Web.UI.Page
{
    Bll.parasBll pb = new Bll.parasBll();
    Model.tab_paras paras = new Model.tab_paras();
    DBunit.SQLAccess dbsql = new DBunit.SQLAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            gridBind();
        }
    }
    void gridBind()
    {
        string s = "select * from tab_paras where pname='consultimg'";
        DataTable dt = pb.Select(s);
        this.GridView1.DataSource = dt;
        this.GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
            {
                if (FileUpload1.PostedFile.ContentLength < 2097152)//2MB,单位字节
                {
                    string filepath = FileUpload1.PostedFile.FileName;
                    string ext = System.IO.Path.GetExtension(filepath).ToLower();
                    if (ext == ".png")
                    {
                        string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                        string serverpath = Server.MapPath("~/Images/slides/") + filename;
                        FileUpload1.PostedFile.SaveAs(serverpath);
                        //this.lb_info.Text = "上传成功！";
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('上传成功');</script>");
                        string pxmax = "select MAX(ptype) from tab_paras where pname='consultimg'";
                        string px = dbsql.ExecuteSc(pxmax).ToString() == "" ? "0" : dbsql.ExecuteSc(pxmax).ToString();
                        paras.pname = "consultimg";
                        paras.pvalue = "Images/slides/" + filename;
                        paras.ptype = (int.Parse(px) + 1).ToString();
                        pb.Add(paras);
                        gridBind();
                    }
                    else
                    {
                        //this.lb_info.Text = "请选择jpg文件";
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('请选择png文件');</script>");
                    }
                }
                else
                {
                    //this.lb_info.Text = "jpg文件不能超过2MB";
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('jpg文件不能超过2MB');</script>");
                }
            }
            else
            {
                //this.lb_info.Text = "请正确选择文件！";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('请正确选择文件');</script>");
            }
        }
        catch (Exception error)
        {
            this.lb_info.Text = "上传发生错误！原因：" + error.ToString();
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string str = "delete from tab_paras where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        dbsql.ExecuteNonQuery(str); 
        gridBind();
    }
}