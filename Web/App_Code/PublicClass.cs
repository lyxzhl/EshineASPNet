using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Bll;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using Subgurim.Controles;
using System.Text;
using System.Web.Script.Serialization;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public class PublicClass : System.Web.UI.Page
{
    public DateTime baddate = DateTime.Parse("1900-01-01");

    Bll.ProdutClassBLL tab_proClass = new ProdutClassBLL();
    Bll.OrdersBll ob = new OrdersBll();
    Bll.ProductBll pb = new ProductBll();
    Bll.eticketBll eb = new eticketBll();
    /// <summary>
    /// 绑定了产品类别
    /// </summary>
    /// <param name="dp">要绑定的控件</param>
    public void proClassBinder(DropDownList dp)
    {
        DataTable dt = tab_proClass.SelectProClass("select * from tab_productClass");
        dp.DataSource = dt;
        dp.DataTextField = "productClassName";
        dp.DataValueField = "productClassID";
        dp.DataBind();

    }

    /// <summary>
    /// 执行repeater绑定
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="rep"></param>
    public void binderRep(DataTable dt, Repeater rep)
    {
        rep.DataSource = dt;
        rep.DataBind();
    }
    /// <summary>
    /// 清空文本框
    /// </summary>
    /// <param name="tx"></param>
    public void clearText(TextBox tx)
    {
        tx.Text = "";
    }
    /// <summary>
    /// 上传图片
    /// </summary>
    /// <param name="File"></param>
    /// <returns></returns>
    public string getImgName(HtmlInputFile File)
    {
        string path = File.Value;
        string imgName = Path.GetFileName(path);
        HttpPostedFile hp = File.PostedFile;
        hp.SaveAs(Server.MapPath("~/Images") + "\\" + imgName);
        return imgName;
    }
    /// <summary>
    /// 获取产品类别信息
    /// </summary>
    /// <param name="dp"></param>
    public void GetProductClass(DropDownList dp)
    {
        dp.Items.Clear();
        ListItem list = new ListItem("------未分类------", "1");
        dp.Items.Add(list);
        DataTable ds = tab_proClass.SelectProClass("select productClassID,productClassName from tab_productClass where productClassParentID=" + list.Value);

        for (int i = 0; i < ds.Rows.Count; i++)
        {

            dp.Items.Add(new ListItem(ds.Rows[i]["productClassName"].ToString(), ds.Rows[i]["productClassID"].ToString()));
            int leng = 1;
            dpbinder(dp, int.Parse(ds.Rows[i]["productClassID"].ToString()), leng);
        }

    }
    void dpbinder(DropDownList dp, int cID, int leng)//根据父ID查询子项
    {
        DataTable ds = tab_proClass.SelectProClass("select productClassID,productClassName from tab_productClass where productClassParentID=" + cID.ToString());

        leng++;
        for (int i = 0; i < ds.Rows.Count; i++)
        {
            string tr = addtab(leng);
            dp.Items.Add(new ListItem(tr + "|---" + ds.Rows[i]["productClassName"].ToString(), ds.Rows[i]["productClassID"].ToString()));

            dpbinder(dp, int.Parse(ds.Rows[i]["productClassID"].ToString()), leng);
        }

    }
    //添加空格
    private string addtab(int i)
    {
        string aa = "　";
        for (int j = 0; j < i; j++)
        {
            aa += "　";
        }
        return aa;
    }
    


    //SMTP发送邮件，新浪邮箱SendSMTPEMail("smtp.sina.com", "邮箱", "密码", "88888@qq.com", "标题", "内容");
    public void SendSMTPEMail(string strSmtpServer, string strFrom, string strFromPass, string strto, string strSubject, string strBody)
    {
        System.Net.Mail.SmtpClient client = new SmtpClient(strSmtpServer);
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential(strFrom, strFromPass);
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        System.Net.Mail.MailMessage message = new MailMessage(strFrom, strto, strSubject, strBody);

        message.BodyEncoding = System.Text.Encoding.UTF8;
        message.IsBodyHtml = true;
        client.Send(message);
    }


    //Web.config文件中增加如下配置节：
    // <system.net>
    //    <!--如果是第三方smtp服务器,需要指定userName 和 password,并根据host指定发件人邮件地址from
    //        测试发现from值必须是userName值加上指定的smpt服务器才行,而且是必须指定的
    //        如果是本机smtp服务器,只需指定defaultCredentials="true"即可-->
    //    <mailSettings>
    //      <smtp deliveryMethod="Network" from ="youremail@hotmail.com" >
    //        <network host="smtp.126.com" port="25" userName="youremail" password="111111/>
    //      </smtp>
    //    </mailSettings>
    //  </system.net>
    public void SendsettingEMail(string strto, string strSubject, string strBody)
    {
        using (MailMessage message = new MailMessage())
        {
            message.To.Add(new MailAddress(strto)); //收件人邮箱
            message.Subject = strSubject;//邮件主题
            message.Body = strBody;  //邮件正文
            message.IsBodyHtml = true;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.HeadersEncoding = System.Text.Encoding.UTF8;


            SmtpClient mailClient = new SmtpClient();
            mailClient.Send(message);
        }
    }

    //随机密码串,pwdchars 参数指定生成的随机密码串可以使用哪些字符，pwdlen 指定生成的随机密码串的长度
    public string MakePassword(int pwdlen)
    {
        //string pwdchars = "abcdefghijklmnopqrstuvwxyz123456789ABCDEFGHIJKLMNPQRSTUVWXYZ"; 
        string pwdchars = "1234567890";
        string tmpstr = "";
        int iRandNum;
        Random rnd = new Random();
        for (int i = 0; i < pwdlen; i++)
        {
            iRandNum = rnd.Next(pwdchars.Length);
            tmpstr += pwdchars[iRandNum];
        }
        return tmpstr;
    }

    public string md5(string str)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
    }
    public string getIp()
    {
        string ip2;
        try
        {
            string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];//优先取得代理IP 
            if (string.IsNullOrEmpty(ip))
            {
                //没有代理IP则直接取客户端IP 
                ip = Request.ServerVariables["REMOTE_ADDR"];
            }

            ip2 = Request.UserHostAddress;

            if (ip != ip2)
            {
                ip += "," + ip2;
            }

            return ip;
        }
        catch (Exception ex) { }

        return "";
    }


    public bool AmIOnline(string s, Hashtable h)
    {
        //System.Web.SessionState.HttpSessionState Session = HttpContext.Current.Session;
        //Hashtable h = (Hashtable)Application["Online"];


        //继续判断是否该用户已经登陆 
        if (h == null)
            return false;

        //判断哈希表中是否有该用户 
        IDictionaryEnumerator e1 = h.GetEnumerator();
        bool flag = false;
        //string s;
        while (e1.MoveNext())
        {
            //s = Session["id"] + "|" + Session["ip"];
            if (e1.Value.ToString().CompareTo(s) == 0)
            {
                flag = true;
                break;
            }
        }
        return flag;
    }

    public void gridviewtoexcel(GridView gv, string filename)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page page = new Page();
        HtmlForm form = new HtmlForm();


        for (int i = 0; i < gv.Rows.Count; i++)
        {
            if (gv.Rows[i].FindControl("GridView2") != null)
            {
                gv.Rows[i].Cells.RemoveAt(0);
                gv.Rows[i].Cells.RemoveAt(gv.Rows[i].Cells.Count - 1);

            }
        }



        gv.EnableViewState = false;

        // Deshabilitar la validación de eventos, sólo asp.net 2
        page.EnableEventValidation = false;

        // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
        page.DesignerInitialize();

        page.Controls.Add(form);
        form.Controls.Add(gv);

        page.RenderControl(htw);

        System.Web.HttpContext.Current.Response.Clear();
        System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
        System.Web.HttpContext.Current.Response.Charset = "UTF-8";
        System.Web.HttpContext.Current.Response.ContentEncoding = Encoding.Default;
        System.Web.HttpContext.Current.Response.ContentType = "application/excel";

        string style = @"<style> .text { mso-number-format:\@; } </script> ";
        System.Web.HttpContext.Current.Response.Write(style);

        System.Web.HttpContext.Current.Response.Write(sb.ToString());
        System.Web.HttpContext.Current.Response.End();
    }



    /// <summary>
    /// 根据dataTable生成Excel
    /// </summary>
    /// <param name="dt">数据源</param>
    /// <param name="sheetName">sheet名称</param>
    /// <param name="header">标题</param>
    /// <returns></returns>


    /// <summary>
    /// 根据dataTable生成Excel
    /// </summary>
    /// <param name="dt">数据源</param>
    /// <param name="sheetName">sheet名称</param>
    /// <param name="header">标题</param>
    /// <returns></returns>
    public static XSSFWorkbook Export(DataTable dt, string sheetName, string header, out string msg)
    {
        try
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet sheet;
            if (!string.IsNullOrEmpty(sheetName))
                sheet = workbook.CreateSheet(sheetName);
            else
                sheet = workbook.CreateSheet("sheet1");

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-MM-dd hh:ss:mm");

            //取得列宽
            int[] arrColWidth = new int[dt.Columns.Count];
            foreach (DataColumn item in dt.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dt.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }

            int rowIndex = 0;

            foreach (DataRow row in dt.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                //if (rowIndex >= 1048570 || rowIndex == 0)
                if (rowIndex >= 1048570 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(header);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dt.Columns.Count - 1));
                        //headerRow
                    }
                    #endregion

                    #region 列头及样式
                    {
                        IRow headerRow = sheet.CreateRow(1);
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dt.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                        //headerRow.Dispose();
                    }
                    #endregion

                    rowIndex = 2;
                }
                #endregion

                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dt.Columns)
                {
                    ICell newCell = dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            bool torf = DateTime.TryParse(drValue, out dateV);
                            if (torf && dateV != System.Data.SqlTypes.SqlDateTime.MinValue && dateV != new DateTime())
                            {
                                newCell.SetCellValue(dateV);
                                newCell.CellStyle = dateStyle;//格式化显示
                            }
                            else
                                newCell.SetCellValue("");
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }
                }
                #endregion

                rowIndex++;
            }
            msg = string.Empty;
            return workbook;
        }
        catch (Exception ex)
        {
            msg = ex.Message;
            return null;
        }
        //try
        //{
        //    FileStream fs = new FileStream(filename, FileMode.CreateNew);//(filename, FileMode.Create, FileAccess.Write);
        //    workbook.Write(fs);
        //    //fs.Flush();
        //    return true;
        //}
        //catch (Exception ex)
        //{
        //    throw new Exception(ex.Message);
        //    return false;
        //}
        //using (MemoryStream ms = new MemoryStream())
        //{
        //    workbook.Write(ms);
        //    ms.Flush();
        //    //ms.Position = 0;

        //    //sheet.Dispose();
        //    return ms;
        //}
    }
    

    public void DatatableToExcel(DataTable list)
    {
        string msg = string.Empty;
        XSSFWorkbook work = Export(list, "", "header", out msg);
        Response.Clear();
        Response.ClearHeaders();
        if (work == null && !string.IsNullOrEmpty(msg))
            throw new Exception(msg);
        Response.Buffer = false;
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";//ContentType;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("export.xlsx", System.Text.Encoding.UTF8));
        MemoryStream ms = new MemoryStream();
        work.Write(ms);
        Response.BinaryWrite(ms.ToArray());
        work = null;
        ms.Close();
        ms.Dispose();
        Response.Flush();
        Response.End();
    }

    public static string smsmd5(string str)
    {
        byte[] result = Encoding.Default.GetBytes(str);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] output = md5.ComputeHash(result);
        String md = BitConverter.ToString(output).Replace("-", "");
        return md.ToLower();
    }
    
    public void addlog(string id, string pw, string browser, string device, string note, string status)
    {
        Bll.loginlogBll lb = new Bll.loginlogBll();
        Model.tab_loginlog loginlog = new Model.tab_loginlog();
        loginlog.loginid = id;
        loginlog.loginpw = pw;
        loginlog.time = DateTime.Now;
        loginlog.loginip = getIp();
        loginlog.loginbrowser = browser;
        loginlog.logindevice = device;
        loginlog.note = note;
        loginlog.status = status;
        lb.Add(loginlog);
    }

    public Model.tab_orders doshop_eticket(Model.tab_orders orders)
    {
        Model.tab_eticket Modeticket;
        Model.tab_products product = new Model.tab_products();

        string items = orders.ReportContent;
        string[] ts = items.Split(';');
        StringBuilder sb = new StringBuilder();
        string s;
        int index;
        for (int i = 0; i < ts.Length; i++)
        {
            sb.Append(ts[i]);
            index = ts[i].IndexOf('*');
            s = ts[i].Substring(0, index);

            product.productID = int.Parse(s);
            product = pb.getproducts(product);

            if (product.uplimit == "电子码")
            {
                string eticket = mketicket("MP" + s, product.productID * 10 + i);

                Modeticket = new Model.tab_eticket();
                Modeticket.orderID = orders.orderID;
                Modeticket.customerName = orders.customerName;
                Modeticket.productName = product.productName;
                Modeticket.productID = product.productID;
                Modeticket.itemnum = ts[i].Substring(index + 1);
                Modeticket.eticket = eticket;
                Modeticket.time = DateTime.Now;
                eb.Add(Modeticket);

                sb.Append("|" + eticket);
            }
            sb.Append(";");
        }
        sb.Remove(sb.Length - 1, 1);

        orders.ReportContent = sb.ToString();
        return orders;

    }
    public string mketicket(string pnum, int extraseed)
    {

        System.Random randnum = new System.Random(unchecked((int)DateTime.Now.Ticks + extraseed));
        StringBuilder sb = new StringBuilder();
        for (int i = pnum.Length - 1; i < 16; i++)
        {
            sb.Append(randnum.Next(0, 9));
        }
        return pnum + sb.ToString();
    }

    public static string postrequest(string url, System.Collections.Specialized.NameValueCollection PostVars)
    {
        try
        {
            System.Net.WebClient WebClientObj = new System.Net.WebClient();
            byte[] byRemoteInfo = WebClientObj.UploadValues(url, "POST", PostVars);

            string sRemoteInfo = System.Text.Encoding.UTF8.GetString(byRemoteInfo);
            return sRemoteInfo;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

}
