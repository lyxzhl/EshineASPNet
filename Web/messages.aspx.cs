using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class messages : PageBases
{
    //每页显示的最多记录的条数  
    private int pageSize = 5;
    //当前页号  
    private int currentPageNumber;
    //排序表达式  
    private string sortExpression = string.Empty;
    //排序方向  
    private string sortDirection = string.Empty;
    //显示数据的总条数  
    private static int rowCount;
    //总页数  
    private static int unreadCount;
    //总页数  
    private static int pageCount;
    Bll.messageBll mb = new Bll.messageBll();
    Model.tab_customers modelCu = new Model.tab_customers();
    void init()
    {
        rowCount = mb.getmsgnum(modelCu.customerID, "");
        lblMessage.Text = (string)GetGlobalResourceObject("GResource", "total") + rowCount + (string)GetGlobalResourceObject("GResource", "items") + ",";
        unreadCount = mb.getunread(modelCu.customerID);
        lblunread.Text = unreadCount + (string)GetGlobalResourceObject("GResource", "unreaditems");

        if (this.DropDownList1.SelectedIndex == 1)
        {
            rowCount = mb.getmsgnum(modelCu.customerID, " and (Status is null or Status!=N'已读') ");
        }
        else if (this.DropDownList1.SelectedIndex == 2)
        {
            rowCount = mb.getmsgnum(modelCu.customerID, " and Status=N'已读' ");
        }
        pageCount = (rowCount - 1) / pageSize + 1;
        currentPageNumber = 1;
        dropPage.Items.Clear();
        for (int i = 1; i <= pageCount; i++)
        {

            dropPage.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        dropPage.SelectedValue = dropPage.Items.FindByValue(currentPageNumber.ToString()).Value;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.CheckUser((Hashtable)Application["Online"]);
        }
        modelCu.customerID = int.Parse(Session["id"].ToString());
        if (!IsPostBack)
        {
            chkAll.Attributes.Add("onclick", "chooseAll('" + chkAll.ClientID + "')");
            init();
            Query();
        }

        sortExpression = ViewState["sortExpression"].ToString();
        sortDirection = ViewState["sortDirection"].ToString();
        currentPageNumber = Convert.ToInt32(ViewState["currentPageNumber"]);
    }

    private void Query()
    {
        SetButton(currentPageNumber);
        string wheres = " from tab_message where Receiver= " + modelCu.customerID;
        string orders = " order by Status, Messageid desc ";
        if (this.DropDownList1.SelectedIndex == 1)
        {
            wheres += " and (Status is null or Status!=N'已读') ";
        }
        else if (this.DropDownList1.SelectedIndex == 2)
        {
            wheres += " and Status=N'已读' ";
        }

        string sqls = "select top " + pageSize + " * " + wheres + "and Messageid  not in (select top " + (currentPageNumber - 1) * pageSize + " Messageid " + wheres + orders + ")" + orders;
        rptMessage.DataSource = mb.Select(sqls);
        rptMessage.DataBind();

        //lblMessage.Text = "共找到" + rowCount + "条记录, 当前第" + currentPageNumber + "/" + pageCount + "页";
        Save();
    }

    protected void lbtnPage_Command(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "First":
                currentPageNumber = 1;
                break;
            case "Previous":
                currentPageNumber = (int)ViewState["currentPageNumber"] - 1 > 1 ? (int)ViewState["currentPageNumber"] - 1 : 1;
                break;
            case "Next":
                currentPageNumber = (int)ViewState["currentPageNumber"] + 1 < pageCount ? (int)ViewState["currentPageNumber"] + 1 : pageCount;
                break;
            case "Last":
                currentPageNumber = pageCount;
                break;
        }
        dropPage.SelectedValue = dropPage.Items.FindByValue(currentPageNumber.ToString()).Value;
        Query();
    }

    protected void lbtnSort_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName != ViewState["sortExpression"].ToString())
        {
            sortDirection = "ASC";
        }
        else
        {
            if (sortDirection == "ASC")
            {
                sortDirection = "DESC";
            }
            else if (sortDirection == "DESC" || sortDirection == string.Empty)
            {
                sortDirection = "ASC";
            }
        }
        sortExpression = e.CommandName;
        Query();
    }

    protected void dropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        currentPageNumber = int.Parse(dropPage.SelectedValue);
        Query();
    }

    private void SetButton(int currentPageNumber)
    {
        lbtnFirst.Enabled = currentPageNumber != 1;
        lbtnPrevious.Enabled = currentPageNumber != 1;
        lbtnNext.Enabled = currentPageNumber != pageCount;
        lbtnLast.Enabled = currentPageNumber != pageCount;
    }

    private void Save()
    {
        ViewState["currentPageNumber"] = currentPageNumber;
        ViewState["sortExpression"] = sortExpression;
        ViewState["sortDirection"] = sortDirection;
    }

    protected void rptMessage_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            if (!string.IsNullOrEmpty(sortDirection))
            {
                Label lblSort = new Label();
                lblSort.EnableTheming = false;
                lblSort.Font.Name = "webdings";
                lblSort.Font.Size = FontUnit.Small;
                lblSort.Text = sortDirection == "ASC" ? "5" : "6";
                (e.Item.FindControl("td" + sortExpression) as HtmlTableCell).Controls.Add(lblSort);
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        CheckBox chkSelect;
        ImageButton BtnDelete;
        foreach (RepeaterItem item in rptMessage.Items)
        {
            chkSelect = item.FindControl("chkSelect") as CheckBox;
            if (chkSelect != null && chkSelect.Checked)
            {
                BtnDelete = item.FindControl("BtnDelete") as ImageButton;
                string sArg = BtnDelete.CommandArgument;
                mb.Delete(int.Parse(sArg));

                //Response.Write(lblProductID.Text);  
                //可以在这里完成删除逻辑  
            }
        }
        init();
        Query();
        this.chkAll.Checked = false;
    }
    protected void btnRead_Click(object sender, EventArgs e)
    {
        CheckBox chkSelect;
        ImageButton BtnDelete;
        foreach (RepeaterItem item in rptMessage.Items)
        {
            chkSelect = item.FindControl("chkSelect") as CheckBox;
            if (chkSelect != null && chkSelect.Checked)
            {
                BtnDelete = item.FindControl("BtnDelete") as ImageButton;
                string sArg = BtnDelete.CommandArgument;
                mb.markasread(sArg);
            }
        }
        init();
        Query();
    }
    protected void rptMessage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Header)
        //{
        //    CheckBox chkAll = e.Item.FindControl("chkAll") as CheckBox;

        //}

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Image mailimg = e.Item.FindControl("Image1") as Image;
            Label labeltime = e.Item.FindControl("lbltime") as Label;
            LinkButton lbltitle = e.Item.FindControl("lbltitle") as LinkButton;
            Label lblcontent = e.Item.FindControl("lblcontent") as Label;
            //Panel Panel1 = e.Item.FindControl("Panel1") as Panel;

            //如果databind的是ExecuteReader,则e.Item.DataItem要转换为System.Data.Common.DbDataRecord
            if (((DataRowView)e.Item.DataItem)["Status"].ToString() == "已读")
            {
                mailimg.ImageUrl = "~/Images/mailread.png";
            }
            else
            {
                lbltitle.Font.Bold = true;

            }
            TimeSpan ts = DateTime.Now - DateTime.Parse(((DataRowView)e.Item.DataItem)["MessageDate"].ToString());

            if (ts.Days > 30)
            {
                labeltime.Text = (string)GetGlobalResourceObject("GResource", "onemonthago");
            }
            else if (ts.Days > 7)
            {
                labeltime.Text = (string)GetGlobalResourceObject("GResource", "oneweekago");
            }
            else if (ts.Days > 1)
            {
                labeltime.Text = (string)GetGlobalResourceObject("GResource", "onedayago");
            }
            else if (ts.Hours > 2)
            {
                labeltime.Text = (string)GetGlobalResourceObject("GResource", "twohourago");
            }
            else if (ts.Hours > 2)
            {
                labeltime.Text = (string)GetGlobalResourceObject("GResource", "justnow");
            }

            lbltitle.Text = ((DataRowView)e.Item.DataItem)["Title"].ToString();
            string msg = ((DataRowView)e.Item.DataItem)["Msg"].ToString();
            //Literal lit = new Literal();
            //lit.Text = msg.Length < 24 ? msg : msg.Substring(0, 24) + "..."; ;
            lblcontent.Text = msg.Length < 24 ? msg : msg.Substring(0, 24) + "...";
            //Panel1.Controls.Add(lit);

            CheckBox chkSelect = e.Item.FindControl("chkSelect") as CheckBox;
            chkSelect.Attributes.Add("onclick", "highLightSelected(this);");
        }
    }
    protected void lbltitle_Click(object sender, EventArgs e)
    {
        string[] sArg = ((LinkButton)sender).CommandArgument.Split('|');

        RepeaterItem rptitem = this.rptMessage.Items[int.Parse(sArg[0])];
        Panel p1 = ((Panel)(rptitem.FindControl("Panel1")));
        Label lblcontent = rptitem.FindControl("lblcontent") as Label;
        Literal lit = ((Literal)(rptitem.FindControl("Literal1")));
        Panel ptemp;
        for (int i = 0; i < this.rptMessage.Items.Count; i++)
        {
            if (i != int.Parse(sArg[0]))
            {
                ptemp = (Panel)(this.rptMessage.Items[i].FindControl("Panel1"));
                ptemp.ScrollBars = ScrollBars.None;
                ptemp.Height = 30;
                ptemp.BorderWidth = 0;
                ((Label)this.rptMessage.Items[i].FindControl("lblcontent")).Visible = true;
                ((Literal)this.rptMessage.Items[i].FindControl("Literal1")).Visible = false;
            }
        }

        if (p1.Height == 30)
        {
            lblcontent.Visible = false;

            lit.Text = mb.getmessage(int.Parse(sArg[1]));
            lit.Visible = true;
            
            p1.Height = 200;
            p1.ScrollBars = ScrollBars.Auto;
            p1.BorderWidth = 1;

            LinkButton lbltitle = rptitem.FindControl("lbltitle") as LinkButton;
            if (lbltitle.Font.Bold == true)
            {
                mb.markasread(sArg[1]);//写入已读

                lbltitle.Font.Bold = false;
                Image mailimg = rptitem.FindControl("Image1") as Image;
                mailimg.ImageUrl = "~/Images/mailread.png";
            }
        }
        else
        {
            lblcontent.Visible = true;
            p1.Height = 30;
            p1.BorderWidth = 0;
        }


    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string sArg = ((ImageButton)sender).CommandArgument;
        mb.Delete(int.Parse(sArg));
        init();
        Query();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        init();
        Query();
    }
}