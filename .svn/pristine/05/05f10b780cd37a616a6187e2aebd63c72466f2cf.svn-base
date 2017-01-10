using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Subgurim.Controles;
public partial class suppliermap : PageBases
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["province"] != null && Request.QueryString["city"] != null)
            {
                Bll.SupplierBll sb = new Bll.SupplierBll();
                DataTable dt = sb.GetAny("select * from tab_suppliers where province like N'" + Request.QueryString["province"] + "' and city like N'" + Request.QueryString["city"] + "'");

                GMap1.Add(new GControl(GControl.preBuilt.GOverviewMapControl));
                GMap1.Add(new GControl(GControl.preBuilt.LargeMapControl));

                GMarker marker;
                GInfoWindow window;
                double lat, lng, clat = 0.0, clng = 0.0;
                foreach (DataRow dr in dt.Rows)
                {
                    lat = Convert.ToDouble(dr["lat"]);
                    lng = Convert.ToDouble(dr["lng"]);
                    clat += lat;
                    clng += lng;
                    marker = new GMarker(new GLatLng(lat, lng));
                    window = new GInfoWindow(marker, "<center><b>" + dr["supplier"].ToString() + "</b><br />" + dr["branch"].ToString() + "</center>", false);
                    GMap1.Add(window);
                }
                clat /= dt.Rows.Count;
                clng /= dt.Rows.Count;
                GMap1.enableHookMouseWheelToZoom = true;
                GMap1.setCenter(new GLatLng(clat, clng), 12);
            }
        }
        
    }
}