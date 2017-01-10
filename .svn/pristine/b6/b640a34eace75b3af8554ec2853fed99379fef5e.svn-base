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

public partial class Admin_roleAdmin_roleUpdate :basePage
{
    Bll.RolesBll ro = new Bll.RolesBll();
    Model.tab_roles Mro = new Model.tab_roles();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this.CheckUser((Hashtable)Application["Online"]);
            powClass();
            string rID = Request.QueryString["rid"].ToString();
            Mro.RoleID = Convert.ToInt32(rID);
            DataTable dr =ro.GetAny(Mro);
            ViewState["rid"] = rID;

            this.TextBox1.Text = dr.Rows[0]["roleName"].ToString();
            this.TextBox4.Text = dr.Rows[0]["roleContent"].ToString();

            string[] pows = dr.Rows[0]["roleInfo"].ToString().Split('|');

            for (int j = 0; j < this.Repeater1.Items.Count; j++)
            {
                CheckBoxList ck = (CheckBoxList)this.Repeater1.Items[j].FindControl("CheckBoxList1");
                for (int k = 0; k < ck.Items.Count; k++)
                {
                    for (int i = 0; i < pows.Length; i++)
                    {
                        if (ck.Items[k].Value == pows[i])
                        {
                            ck.Items[k].Selected = true;
                        }
                    }
                }
            }
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
        Mro.RoleID = Convert.ToInt32(ViewState["rid"].ToString());
        Mro.RoleName = this.TextBox1.Text;
        Mro.RoleInfo = pows.ToString();
        Mro.RoleContent = this.TextBox4.Text;
        ro.update(Mro);
        this.Label1.Text = "<font color='red'>更新成功</font>";
            
    }
    void powClass()
    {
        DataSet ds = ro.GetPowClass("select * from tab_powers where powerPID=0", "select * from tab_powers where powerPID<>0");
        ds.Relations.Add("pc", ds.Tables["P"].Columns["powerID"], ds.Tables["C"].Columns["powerPID"]);

        this.Repeater1.DataSource = ds.Tables["P"];
        this.Repeater1.DataBind();
    }
}
