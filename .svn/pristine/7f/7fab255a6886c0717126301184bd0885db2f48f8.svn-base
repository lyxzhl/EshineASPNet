using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DBHelper
/// </summary>
public class DBHelper
{
    public static readonly string connstr = ConfigurationManager.ConnectionStrings["db_ConnectionString"].ConnectionString;

    static SqlConnection conn = null;
    public static void Conn()
    {
        conn = new SqlConnection(connstr);
    }
    /// <summary>
    /// 返回结果集
    /// </summary>
    /// <param name="sql">查询语句</param>
    /// <returns></returns>
    public static DataSet GetSet(string sql)
    {
        Conn();
        DataSet ds = new DataSet();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(ds);
        }
        catch (Exception)
        {
            ds = null;
        }
        return ds;
    }
}