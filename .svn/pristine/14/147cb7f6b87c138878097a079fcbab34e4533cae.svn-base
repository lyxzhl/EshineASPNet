using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_CustomersAdmin_editidpwd : System.Web.UI.Page
{
    PublicClass pc = new PublicClass();
    DBunit.SQLAccess dbsql = new DBunit.SQLAccess();
    Bll.OrdersBll ob = new Bll.OrdersBll();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string s = "";
        int sus = 0, err = 0;
        string errid = "";
        if(this.TextBox2.Text!="")
        {
            if (this.TextBox1.Text.Contains('-') || this.TextBox1.Text.Contains(','))
            {
                string[] oid = this.TextBox1.Text.Split('-');
                if (this.TextBox1.Text.Contains('-'))
                {
                    s = "select * from tab_customers where customerID>=" + oid[0] + " and customerID<=" + oid[1];
                }
                else
                {
                    s = "select * from tab_customers where customerID in (" + oid[0] + ")";
                }
                DataTable dt = ob.Select(s);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string pwd = ob.Select("select RIGHT(customerIDcard,6) from tab_customers where customerID=" + dt.Rows[i]["customerID"]).Rows[0][0].ToString();
                    pwd = pc.md5(this.TextBox2.Text);
                    string up = "update tab_customers set customerPwd='" + pwd + "' where customerID=" + dt.Rows[i]["customerID"];
                    int num = dbsql.ExecuteNonQuery(up);
                    if (num > 0)
                    {
                        sus++;
                    }
                    else
                    {
                        err++;
                        errid += dt.Rows[i]["customerID"] + ",";
                    }
                }
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改成功。成功"+sus+"条，失败"+err+"条，失败id："+errid+"');</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入密码！');</script>");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string s = "";
        int sus = 0, err = 0;
        string errid = "";
        if (this.TextBox2.Text == "")
        {
            if (this.TextBox1.Text.Contains('-') || this.TextBox1.Text.Contains(','))
            {
                string[] oid = this.TextBox1.Text.Split('-');
                if (this.TextBox1.Text.Contains('-'))
                {
                    s = "select customerID, customerCode,customerIDcard from tab_customers where customerID>=" + oid[0] + " and customerID<=" + oid[1];
                }
                else
                {
                    s = "select customerID, customerCode,customerIDcard from tab_customers where customerID in (" + oid[0] + ")";
                }
                Model.tab_customers cus = new Model.tab_customers();
                Bll.CustomerBll cusb = new Bll.CustomerBll();
                DataTable dt = dbsql.ExecuteDataSet(s).Tables[0];
                string pw = "123456";
                string idcard;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cus.customerID = Convert.ToInt32(dt.Rows[i]["customerID"]);
                    cus = cusb.getCustomer(cus);
                    cus.customerPwd = "";

                    idcard = dt.Rows[i]["customerIDcard"].ToString();
                    if (idcard.Length < 6)
                    {
                        idcard = "123456";
                    }
                    else
                    {
                        idcard = idcard.Substring(idcard.Length - 6, 6);
                    }
                    pw = idcard;
                    cus.customerPwd = pc.md5(pw);
                    cusb.update(cus);
                }
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改成功。');</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入密码！');</script>");
        }
    }
}