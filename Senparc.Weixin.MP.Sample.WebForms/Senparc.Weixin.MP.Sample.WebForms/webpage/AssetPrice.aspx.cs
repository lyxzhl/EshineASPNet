using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;

namespace Senparc.Weixin.MP.Sample.WebForms.webpage
{
    public partial class AssetPrice : System.Web.UI.Page
    {
        public string list = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            webinterface.ExchangeData i_ed = new webinterface.ExchangeData();
            list = i_ed.loaddata("CZC");
        }
        
    }
}