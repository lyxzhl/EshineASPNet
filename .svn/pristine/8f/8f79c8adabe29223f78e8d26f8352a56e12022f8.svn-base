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
public partial class Admin_roleAdmin_roleAdd : basePage
{
    Bll.RolesBll ro = new Bll.RolesBll();
    Model.tab_roles Mro = new Model.tab_roles();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.CheckUser();
            powClass();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string pows = string.Empty;
        for (int i = 0; i < this.Repeater1.Items.Count; i++)
        {
            CheckBoxList ck = (CheckBoxList)this.Repeater1.Items[i].FindControl("CheckBoxList1");
            for (int j = 0; j < ck.Items.Count; j++)
            {
                if (ck.Items[j].Selected)
                {
                    pows += ck.Items[j].Value + "|";
                }
            }
        }
        if (pows.IndexOf('|') > 0)
        {
            pows = pows.Remove(pows.Length - 1);
        }
        if (pows.Length == 0)
        {
            pows = "-1";
        }
        Mro.RoleName=this.TextBox1.Text;
        Mro.RoleInfo = pows;
        //SQLAccess.ExecuteNonQuery("insert into tab_roles values('" + this.TextBox1.Text + "','" + pows + "','" + this.TextBox4.Text + "')");
        ro.Add(Mro);
        this.Label1.Text = "<font color='red'>添加成功</font>";
    }
    void powClass()
    {
        DataSet ds = ro.GetPowClass("select * from tab_powers where powerPID=0", "select * from tab_powers where powerPID<>0");
        ds.Relations.Add("pc", ds.Tables["P"].Columns["powerID"], ds.Tables["C"].Columns["powerPID"]);
        this.Repeater1.DataSource = ds.Tables["P"];
        this.Repeater1.DataBind();
    }
}
