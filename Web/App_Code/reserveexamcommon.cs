using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Text;
/// <summary>
/// reserveexamcommon 的摘要说明
/// </summary>
public class reserveexamcommon: System.Web.UI.Page
{
	public reserveexamcommon()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    Bll.CustomerBll Cb = new Bll.CustomerBll();
    Bll.SupplierBll sb = new Bll.SupplierBll();
    Bll.companyBll comb = new Bll.companyBll();
    PublicClass pc = new PublicClass();

    

    public string initprovincecitydropdown(bool isrel, Model.tab_customers modelCu, DropDownList com_Province, DropDownList com_City)
    {
        try
        {
            DataTable dt;
            if (isrel)
            {
                dt = Bll.reserveexam.getexamprovinceRel(modelCu.customerCompany);
            }
            else
            {
                dt = Bll.reserveexam.getexamprovince(modelCu.customerCompany);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                com_Province.Items.Add(dt.Rows[i][0].ToString());
            }
            int proindex, cityindex;
            string province = "", city = "";
            if (modelCu.customerProvince != "")
            {
                province = modelCu.customerProvince;
            }
            else if (modelCu.customerCompanyProvince != "")
            {
                province = modelCu.customerCompanyProvince;
            }

            if (modelCu.customerCity != "")
            {
                city = modelCu.customerCity;
            }
            else if (modelCu.customerCompanyCity != "")
            {
                city = modelCu.customerCompanyCity;
            }
            if (province != "")
            {
                proindex = com_Province.Items.IndexOf(com_Province.Items.FindByText(province));
                if (proindex > 0)
                {
                    com_Province.SelectedIndex = proindex;
                    if (isrel)
                    {
                        com_Province_SelectedIndexChanged(true, modelCu.customerCompany, com_Province, com_City);

                    }
                    else
                    {
                        com_Province_SelectedIndexChanged(false, modelCu.customerCompany, com_Province, com_City);
                    }

                    if (city != "")
                    {
                        cityindex = com_City.Items.IndexOf(com_City.Items.FindByText(city));
                        if (cityindex > 0)
                        {
                            com_City.SelectedIndex = cityindex;
                            
                        }
                    }
                }

            }
        }
        catch (Exception)
        {
            return "error";
        }
        return "success";
    }

    public void initcitySupplier(bool isrel, ref string branchmapclass, Model.tab_customers modelCu, DropDownList com_Province,
        DropDownList com_City, DropDownList DropDownList1, GMap GMap1, Literal Literal1, ref string hideik, ref string hidemn,
        ref string continue2class, ref string supplierlistcontentikang, ref string supplierlistcontentciming, ref string supplierlistcontentmeinian,
        Panel Panel14, Panel Panel15, Panel Panel16)
    {
        initprovincecitydropdown(isrel, modelCu, com_Province, com_City);
        fillbranch(isrel, ref branchmapclass, modelCu, com_Province, com_City, DropDownList1, GMap1, Literal1, ref  hideik, ref  hidemn, ref  continue2class, ref  supplierlistcontentikang, ref  supplierlistcontentciming, ref  supplierlistcontentmeinian, Panel14, Panel15, Panel16);
        //try
        //{
        //    DataTable dt;
        //    if (isrel)
        //    {
        //        dt = Bll.reserveexam.getexamprovinceRel(modelCu.customerCompany);
        //    }
        //    else
        //    {
        //        dt = Bll.reserveexam.getexamprovince(modelCu.customerCompany);
        //    }
             
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        com_Province.Items.Add(dt.Rows[i][0].ToString());
        //    }
        //    int proindex, cityindex;
        //    string province = "", city = "";
        //    if (modelCu.customerProvince != "")
        //    {
        //        province = modelCu.customerProvince;
        //    }
        //    else if (modelCu.customerCompanyProvince != "")
        //    {
        //        province = modelCu.customerCompanyProvince;
        //    }

        //    if (modelCu.customerCity != "")
        //    {
        //        city = modelCu.customerCity;
        //    }
        //    else if (modelCu.customerCompanyCity != "")
        //    {
        //        city = modelCu.customerCompanyCity;
        //    }
        //    if (province != "")
        //    {
        //        proindex = com_Province.Items.IndexOf(com_Province.Items.FindByText(province));
        //        if (proindex > 0)
        //        {
        //            com_Province.SelectedIndex = proindex;
        //            if (isrel)
        //            {
        //                com_Province_SelectedIndexChanged(true,modelCu.customerCompany, com_Province, com_City);
                        
        //            }
        //            else
        //            {
        //                com_Province_SelectedIndexChanged(false, modelCu.customerCompany, com_Province, com_City);
        //            }
                   
        //            if (city != "")
        //            {
        //                cityindex = com_City.Items.IndexOf(com_City.Items.FindByText(city));
        //                if (cityindex > 0)
        //                {
        //                    com_City.SelectedIndex = cityindex;
        //                    branchmapclass = "";
        //                    fillsupplier(modelCu, com_Province, com_City, DropDownList1);
                         
        //                    fillbranch(isrel, ref branchmapclass, modelCu, com_Province, com_City, DropDownList1, GMap1, Literal1, ref  hideik, ref  hidemn, ref  continue2class, ref  supplierlistcontentikang, ref  supplierlistcontentciming, ref  supplierlistcontentmeinian, Panel14, Panel15, Panel16);
   

        //                }
        //            }
        //        }

        //    }
        //}
        //catch (Exception)
        //{
        //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('数据库连接错误！');</script>");
        //}
    }
    public void com_Province_SelectedIndexChanged(bool isrel,string customerCompanyName, DropDownList com_Province,  DropDownList com_City)
    {
        com_City.Items.Clear();
        com_City.Items.Add((string)GetGlobalResourceObject("GResource", "com_CityResource1"));
        DataTable dt;
        if (isrel)
        {
             dt = Bll.reserveexam.getexamcityRel(customerCompanyName, com_Province.Text);
        }
        else
        {
             dt = Bll.reserveexam.getexamcity(customerCompanyName, com_Province.Text);
        }
        if (dt.Rows.Count == 0)
        {
            com_City.Items.Add(com_Province.Text);
        }
        else
        {
            for (int i = 0; i < dt.Rows.Count; i++)
                com_City.Items.Add(dt.Rows[i][0].ToString());
        }
        com_City.SelectedIndex = 0;

    }

    public void fillsupplier(Model.tab_customers modelCu, DropDownList com_Province, DropDownList com_City, DropDownList DropDownList1)
    {
        string s = "select distinct  supplier from tab_suppliers where id in (" 
            + comb.getavailablesupplier(modelCu.customerCompany)
            + ") and province like N'" + com_Province.SelectedValue + "'";
        if (com_City.SelectedValue != (string)GetGlobalResourceObject("GResource", "com_CityResource1"))
        {
            s += " and city like N'" + com_City.SelectedValue + "'";
        }

        if (modelCu.disablebranch != "")
        {
            s += " and supplier not in (" + modelCu.disablebranch + ")";
        }

        DataTable dt = sb.GetAny(s);
        DropDownList1.DataTextField = "supplier";//DropDownList1
        DropDownList1.DataValueField = "supplier";
        DropDownList1.DataSource = dt.DefaultView;
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem((string)GetGlobalResourceObject("GResource", "DropDownList1Resource1")));//

    }
    
    public void fillbranch(bool isrel, ref string branchmapclass, Model.tab_customers modelCu, DropDownList com_Province,
        DropDownList com_City, DropDownList DropDownList1, GMap GMap1, Literal Literal1, ref string hideik, ref string hidemn, 
        ref string continue2class, ref string supplierlistcontentikang, ref string supplierlistcontentciming, ref string supplierlistcontentmeinian,
        Panel Panel14, Panel Panel15,Panel Panel16)
    {
        if (branchmapclass != "") return;

        string city="", supplier="";

        if (com_City.SelectedValue != (string)GetGlobalResourceObject("GResource", "com_CityResource1"))
        {
            city= com_City.SelectedValue;
        }
        //if (DropDownList1.SelectedValue !=(string)GetGlobalResourceObject("GResource", "DropDownList1Resource1") )
        //{
        //    supplier= DropDownList1.SelectedValue ;
        //}

        if (modelCu.disablebranch != "")
        {
            if (modelCu.disablebranch.Contains("爱康国宾"))
            {
                hideik = "hidden";
            }
            if (modelCu.disablebranch.Contains("美年大健康"))
            {
                hidemn = "hidden";
            }
        }

        //int itemmax = fillbranchmap(GMap1, 
        //    Bll.reserveexam.getbranchlist(modelCu,com_Province.SelectedValue,city,supplier),
        //    ref continue2class, ref supplierlistcontentikang, ref supplierlistcontentciming, ref supplierlistcontentmeinian);

        int itemmax;

        if (isrel)
        {
            itemmax = fillbranchbaidumap(Literal1,
              Bll.reserveexam.getbranchlistRel(modelCu, com_Province.SelectedValue, city, supplier),
              ref continue2class, ref supplierlistcontentikang, ref supplierlistcontentciming, ref supplierlistcontentmeinian);
        }
        else
        {
            itemmax = fillbranchbaidumap(Literal1,
                Bll.reserveexam.getbranchlist(modelCu, com_Province.SelectedValue, city, supplier),
                ref continue2class, ref supplierlistcontentikang, ref supplierlistcontentciming, ref supplierlistcontentmeinian);
        }

        if (itemmax < 5)
        {
            Panel14.Height = itemmax * 80 + 60;
            Panel15.Height = Panel14.Height;
            Panel16.Height = Panel14.Height;
        }
        else
        {
            Panel14.Height = 440;
            Panel15.Height = Panel14.Height;
            Panel16.Height = Panel14.Height;
        }
        if(supplierlistcontentmeinian=="")
        {
            hidemn = "hidden";
        }
    }


    //本函数为谷歌地图
    public int fillbranchmap(GMap GMap1, DataTable dt, ref string continue2class, ref string supplierlistcontentikang, ref string supplierlistcontentciming, ref string supplierlistcontentmeinian)
    {

        GMap1.reset();

        GMap1.Add(new GControl(GControl.preBuilt.GOverviewMapControl));
        GMap1.Add(new GControl(GControl.preBuilt.LargeMapControl));

        GIcon baseIcon = new GIcon();
        baseIcon.shadow = "http://www.google.cn/mapfiles/shadow50.png";
        baseIcon.iconSize = new GSize(20, 34);
        baseIcon.shadowSize = new GSize(37, 34);
        baseIcon.iconAnchor = new GPoint(9, 34);
        baseIcon.infoWindowAnchor = new GPoint(9, 2);

        GIcon letteredIcon;
        GMarker marker;
        GInfoWindow window;
        double lat, lng, clat = 0.0, clng = 0.0;
        int index = 0;
        string letter, lilist = "", ballooncontent;
        supplierlistcontentikang = "";
        supplierlistcontentciming = "";
        supplierlistcontentmeinian = "";
        int itemik = 0, itemcm = 0, itemmn = 0;
        foreach (DataRow dr in dt.Rows)
        {
            letter = ((char)((int)'A' + index++)).ToString();
            letteredIcon = new GIcon(baseIcon);
            letteredIcon.image = "http://www.google.cn/mapfiles/marker" + letter + ".png";

            lat = Convert.ToDouble(dr["lat"]);
            lng = Convert.ToDouble(dr["lng"]);
            clat += lat;
            clng += lng;
            marker = new GMarker(new GLatLng(lat, lng), letteredIcon);

            string sgm = "http://ditu.google.cn/maps?q=" + Server.UrlEncode(Server.UrlEncode(dr["branch"].ToString())) + "&hl=zh-CN&ie=UTF8"
            + "&ll=" + lat + "," + lng + "&hq=" + Server.UrlEncode(Server.UrlEncode(dr["address"].ToString())) + "&z=15";

            //string sgm = "http://ditu.google.cn/maps?q=" + dr["branch"].ToString() + "&hl=zh-CN&ie=UTF8"
            //+ "&ll=" + lat + "," + lng + "&hq=" + dr["address"].ToString() + "&z=15";

            ballooncontent = "<center><b>" + dr["supplier"].ToString() + "</b><br />"
                + "<A href='javascript:void(window.open(\"" + sgm + "\",\"_blank\"));'>" + dr["branch"].ToString() + "</A><br />"
                + "</center>";
            window = new GInfoWindow(marker, ballooncontent, false);
            GMap1.Add(window);

            if (dt.Rows.Count == 1)
            {
                continue2class = "";
                lilist = fillsupplierlist(index, letteredIcon.image, dr["supplier"].ToString(), dr["branch"].ToString(), dr["address"].ToString(), dr["id"].ToString(), true) + "\n\n";
            }
            else
            {
                lilist = fillsupplierlist(index, letteredIcon.image, dr["supplier"].ToString(), dr["branch"].ToString(), dr["address"].ToString(), dr["id"].ToString(), false) + "\n\n";
            }

            if (dr["supplier"].ToString() == "爱康国宾")
            {
                supplierlistcontentikang += lilist;
                itemik++;
            }
            else if (dr["supplier"].ToString() == "美年大健康")
            {
                supplierlistcontentmeinian += lilist;
                itemmn++;
            }
            else //if (dr["supplier"].ToString() == "慈铭体检")
            {
                supplierlistcontentciming += lilist;
                itemcm++;
            }
        }


        clat /= dt.Rows.Count;
        clng /= dt.Rows.Count;
        GMap1.enableHookMouseWheelToZoom = true;
        GMap1.setCenter(new GLatLng(clat, clng), 12);

        int itemmax = Math.Max(itemik, Math.Max(itemmn, itemcm));
        return itemmax;
    }

    public int fillbranchbaidumap(Literal Literal1, DataTable dt, ref string continue2class, ref string supplierlistcontentikang, ref string supplierlistcontentciming, ref string supplierlistcontentmeinian)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<script type='text/javascript'>");
        sb.AppendLine("initMap();");


        double lat, lng, clat = 0.0, clng = 0.0;
        int index = 0;
        string letter, lilist = "";
        string iconimage;
        supplierlistcontentikang = "";
        supplierlistcontentciming = "";
        supplierlistcontentmeinian = "";
        int itemik = 0, itemcm = 0, itemmn = 0;

        try
        {
            foreach (DataRow dr in dt.Rows)
            {
                //letter = ((char)((int)'A' + index)).ToString();
                //iconimage = "/Images/marker/marker" + letter + ".png";


                if (index <= 26)
                {
                    letter = ((char)((int)'A' + index)).ToString();
                    iconimage = "/Images/marker/marker" + letter + ".png";
                }
                else
                {
                    iconimage = "/Images/marker/" + index + ".png";
                }

                lat = Convert.ToDouble(dr["lat"]);
                lng = Convert.ToDouble(dr["lng"]);
                clat += lat;
                clng += lng;

                string sgm = "http://map.baidu.com/m?word=" + Server.UrlEncode(dr["address"].ToString()) + "&ie=utf-8";

                sb.AppendLine("addMarker(" + lng + "," + lat + "," + index + ",'" +
                    dr["supplier"] + " " + dr["branch"] + "', '" + dr["address"] + "', '" + sgm + "');");

                if (dt.Rows.Count == 1)
                {
                    continue2class = "";
                    lilist = fillsupplierlist(index, iconimage, dr["supplier"].ToString(), dr["branch"].ToString(), dr["address"].ToString(), dr["id"].ToString(), true) + "\n\n";
                }
                else
                {
                    lilist = fillsupplierlist(index, iconimage, dr["supplier"].ToString(), dr["branch"].ToString(), dr["address"].ToString(), dr["id"].ToString(), false) + "\n\n";
                }

                if (dr["supplier"].ToString() == "爱康国宾")
                {
                    supplierlistcontentikang += lilist;
                    itemik++;
                }
                else if (dr["supplier"].ToString() == "美年大健康")
                {
                    supplierlistcontentmeinian += lilist;
                    itemmn++;
                }
                else //if (dr["supplier"].ToString() == "慈铭体检")
                {
                    supplierlistcontentciming += lilist;
                    itemcm++;
                }
                index++;
            }
        }
        catch
        {
            throw new Exception ("加载地图标签出错，检查省份城市信息！");
            return -1;
        }


        


        clat /= dt.Rows.Count;
        clng /= dt.Rows.Count;
        sb.AppendLine("setMapcenter(" + clng + "," + clat + ");");
        sb.AppendLine("</script>");

        Literal1.Text = sb.ToString();

        int itemmax = Math.Max(itemik, Math.Max(itemmn, itemcm));
        return itemmax;
    }
    public string fillsupplierlist(int index, string letterimg, string supplier, string branch, string address, string id, bool ched)
    {
        string lilist;
        if (ched)
        {
            lilist = "<LI ><a style='width:287px;'><DIV class='store'><DIV class='checked' id='brand" + index + "t' style='display:block; margin-top:10px; margin-bottom:-40px'></DIV>"
                           + "<LABEL for='brand" + index + "' style='text-align:left;' id='brand" + index + "i' style='filter:alpha(opacity=50);-moz-opacity:0.5;-khtml-opacity: 0.5;opacity: 0.5;'>";
        }
        else
        {
            lilist = "<LI ><a style='width:287px;'><DIV class='store'><DIV class='checked' id='brand" + index + "t'></DIV>"
                           + "<LABEL for='brand" + index + "' style='text-align:left;' id='brand" + index + "i'>";
        }
        if (supplier == "爱康国宾")
        {
            lilist += "<I class='icon3'><img src='" + letterimg + "' /></I>"
                + "<H4><span style='color:#f15a22'>" + (string)GetGlobalResourceObject("GResource", "ikangs") + "</span>"
                + branch + "</H4>";
            //
        }
        else if (supplier == "美年大健康")
        {
            lilist += "<I class='icon5'><img src='" + letterimg + "' /></I>"
                + "<H4><span style='color:#ed1266'>" + (string)GetGlobalResourceObject("GResource", "meinians") + "</span>"
               + branch + "</H4>";
            //;
        }
        else if (supplier == "慈铭体检")
        {
            lilist += "<I class='icon6'><img src='" + letterimg + "' /></I>"
                + "<H4><span style='color:#0e8e35'>" + (string)GetGlobalResourceObject("GResource", "cimings") + "</span>"
                + branch + "</H4>";
            //;
        }
        else if (supplier == "华检体检")
        {
            lilist += "<I class='icon7'><img src='" + letterimg + "' /></I>"
                + "<H4><span>" + (string)GetGlobalResourceObject("GResource", "huajians") + "</span>"
                + branch + "</H4>";
            //;
        }
        else if (supplier == "瑞慈体检")
        {
            lilist += "<I class='icon8'><img src='" + letterimg + "' /></I>"
                + "<H4><span>" + (string)GetGlobalResourceObject("GResource", "ruicis") + "</span>"
                + branch + "</H4>";
            //;
        }
        else
        {
            lilist += "<I class='icon'><img src='" + letterimg + "' /></I>"
                + "<H4><span >" + branch + "</span></H4>";
        }
        if (ched)
        {
            lilist += "<H5>" + address + "</H5></LABEL>"
                       + "<INPUT name='checkboxstores' id='brand" + index + "' type='radio' value='" + id + "' checked='checked'></DIV></a></LI>";
        }
        else
        {
            lilist += "<H5 style=\"width:260px;\">" + address + "</H5></LABEL>"
                + "<INPUT name='checkboxstores' id='brand" + index + "' type='radio' value='" + id + "'></DIV></a></LI>";
        }
        return lilist;
    }

    
}