using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
/// <summary>
/// Summary description for upExcel
/// </summary>
public class upExcel : System.Web.UI.Page 
{
    /// <summary>
    /// 获取文件扩展名部分
    /// </summary>
    /// <param name="File">上传文件控件</param>
    /// <returns></returns>
    private string path;
    public string GetExtension(FileUpload File)
    {
        FileInfo f = new FileInfo(File.FileName);
        return f.Extension;
    }
    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="savePath">保存图片的完整路径</param>
    /// <param name="File">上传图片File控件ID</param>
    public bool SaveUpFile(string savePath, FileUpload File)
    {
        try
        {
            if (!File.HasFile||GetExtension(File) != "xls")
            {
                path = Server.MapPath(savePath + File.FileName);
                File.SaveAs(path); //上传文件
                return true;
            }
            else
            {
                return false;
            }
        }
        catch {
            return false;
        }
    }

    public DataTable InputExcel(string TableName)
    {
        try
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path  + ";" + "Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "select * from [" + TableName + "$]";
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn);
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            conn.Close();
            return dt;
        }
        catch (Exception ex)
        {
            //throw new Exception(ex.Message + "inputexcel");
            return null;
        }
    }
}