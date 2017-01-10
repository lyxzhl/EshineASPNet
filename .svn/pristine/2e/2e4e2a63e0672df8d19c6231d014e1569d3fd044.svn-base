using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DBunit
{
    public class SQLAccess
    {
        public static readonly string constr = ConfigurationManager.ConnectionStrings["db_ConnectionString"].ConnectionString;
        /// <summary>
        /// 执行修改数据信息
        /// </summary>
        /// <param name="constr">连接对象</param>
        /// <param name="commandText">执行命令</param>
        /// <returns>返回受影响的行数</returns>
        public int ExecuteNonQuery(string commandText)
        {
            SqlCommand cmd =new SqlCommand();
            using(SqlConnection conn =new SqlConnection(constr))
            {
              Paremerts(conn,cmd,commandText);
              int i =cmd.ExecuteNonQuery();
              cmd.Parameters.Clear();
              return i;

            }
        }
        /// <summary>
        /// 数据阅读器查询
        /// </summary>
        /// <param name="commandText">查询语句</param>
        /// <returns>读取的结果集</returns>
        public SqlDataReader ExecuteDataReader(string commandText)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                Paremerts(conn, cmd, commandText);
                SqlDataReader dr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return dr;
            }
 
        }
        /// <summary>
        /// 查询第一行的第一条记录
        /// </summary>
        /// <param name="commandText">查询语句</param>
        /// <returns>返回结果</returns>
        public  object ExecuteSc(string commandText)
        {
             SqlCommand cmd = new SqlCommand();
             using (SqlConnection conn = new SqlConnection(constr))
             {
                 Paremerts(conn, cmd, commandText);
                 object obj = cmd.ExecuteScalar();
                 cmd.Parameters.Clear();
                 return obj;
             }
 
        }
        /// <summary>
        /// 执行数据集查询
        /// </summary>
        /// <param name="commandText">查询语句</param>
        /// <returns>返回数据集</returns>
        public DataSet ExecuteDataSet(string commandText)
        {
            SqlCommand cmd = new SqlCommand();
            using(SqlConnection conn =new SqlConnection(constr))
            {
                try
                {
                    Paremerts(conn, cmd, commandText);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet dr = new DataSet();
                    adp.Fill(dr);
                    cmd.Parameters.Clear();
                    return dr;
                }
                catch
                {
                    return null;
                }
            }
 
        }
        public  DataSet ExecuteDataSet(string commandText, string comandText2)
        {
            SqlConnection conn = new SqlConnection(constr);
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter(commandText, conn);
                SqlDataAdapter adp2 = new SqlDataAdapter(comandText2, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds, "P");
                adp2.Fill(ds, "C");
                return ds;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 连接信息
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="cmd">执行命令的对象</param>
        /// <param name="commandtext">命令</param>
        public void Paremerts(SqlConnection conn,SqlCommand cmd,string commandtext)
        {
            if(conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            cmd.Connection=conn;
            cmd.CommandText=commandtext;
            cmd.CommandType=CommandType.Text;
        }

        //public DataSet ExecuteDataSetx(string sql)
        //{
        //    SqlConnection conn = new SqlConnection(constr);
        //    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
        //    DataSet ds = new DataSet();
        //    adp.Fill(ds);
        //    return ds;
        //}



   }
}
