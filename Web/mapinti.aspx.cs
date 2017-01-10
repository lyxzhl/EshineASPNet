using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using Subgurim.Controles;
using System.IO;
using System.Xml;
using Com.Alipay;
using System.Collections;
public partial class mapinti : PageBases
{
    Model.tab_customers modelCu = new Model.tab_customers();
    Bll.CustomerBll Cb = new Bll.CustomerBll();
   
    GMap GMap1 = new GMap();

    reserveexamcommon rc = new reserveexamcommon();
    
    //接收省份的集合
    DataSet ds_Province;
    //接收市的集合
    DataSet ds_City;
    //接收区的集合
    DataSet ds_Area;
    DateTime firstdate;
    DateTime lastdate;
    string DOB;
    public string classmale, classfemale, classmarried, classunmarried, branchmapclass = "hidden", newaddressclass = "hidden", closscompanyaddressclass = "hidden";
    public string supplierlistcontentikang, supplierlistcontentciming, supplierlistcontentmeinian;
    int uppkgcount = -1;
    public string continue2class = "hidden", xiyaclass = "hidden";
    public string hideik = "", hidemn = "";
    public int limit1, limit2, limit3, limit4, limit5, limit6, limit7, limit8, limit9, limit10;
    public string supplierpackagecode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string s = "";
     


        modelCu.customerID = int.Parse(Session["id"].ToString());
        modelCu = Cb.getCustomer(modelCu);

        if (!Page.IsPostBack)
        {
            rc.initcitySupplier(false, ref branchmapclass, modelCu, com_Province, com_City, DropDownList1, GMap1, Literal1, ref  hideik, ref  hidemn, ref  continue2class, ref  supplierlistcontentikang, ref  supplierlistcontentciming, ref  supplierlistcontentmeinian, Panel14, Panel15, Panel16);
        }

        branchmapclass = "";

        rc.fillsupplier(modelCu, this.com_Province, this.com_City, this.DropDownList1);
        rc.fillbranch(false, ref branchmapclass, modelCu, com_Province, com_City, DropDownList1, GMap1, Literal1, ref  hideik, ref  hidemn, ref  continue2class, ref  supplierlistcontentikang, ref  supplierlistcontentciming, ref  supplierlistcontentmeinian, Panel14, Panel15, Panel16);
        return;
    }


    protected void com_Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        branchmapclass = "";
        try
        {
            rc.com_Province_SelectedIndexChanged(false, modelCu.customerCompany, this.com_Province, this.com_City);

            rc.fillsupplier(modelCu, this.com_Province, this.com_City, this.DropDownList1);
            rc.fillbranch(false, ref branchmapclass, modelCu, com_Province, com_City, DropDownList1, GMap1, Literal1, ref  hideik, ref  hidemn, ref  continue2class, ref  supplierlistcontentikang, ref  supplierlistcontentciming, ref  supplierlistcontentmeinian, Panel14, Panel15, Panel16);
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('error:" + ex.Message + "');</script>");
        }
    }
    protected void com_City_SelectedIndexChanged(object sender, EventArgs e)
    {
        branchmapclass = "";

        rc.fillsupplier(modelCu, this.com_Province, this.com_City, this.DropDownList1);
        rc.fillbranch(false, ref branchmapclass, modelCu, com_Province, com_City, DropDownList1, GMap1, Literal1, ref  hideik, ref  hidemn, ref  continue2class, ref  supplierlistcontentikang, ref  supplierlistcontentciming, ref  supplierlistcontentmeinian, Panel14, Panel15, Panel16);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        branchmapclass = "";
        rc.fillbranch(false, ref branchmapclass, modelCu, com_Province, com_City, DropDownList1, GMap1, Literal1, ref  hideik, ref  hidemn, ref  continue2class, ref  supplierlistcontentikang, ref  supplierlistcontentciming, ref  supplierlistcontentmeinian, Panel14, Panel15, Panel16);

    }


    protected void Button4_Click(object sender, EventArgs e) //下一步
    {
        Session["a"]  = Request.Form["checkboxstores"].ToString();


        Response.Redirect("nextpage.aspx?province=" + com_Province.SelectedValue + "&city=" + com_City.SelectedValue);
        

    }



    
}