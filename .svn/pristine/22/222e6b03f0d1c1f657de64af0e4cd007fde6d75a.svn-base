using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SQLServerDAL
{
    class sql_loginlog:IDAL.loginlogDal
    {
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        DateTime baddate = DateTime.Parse("1900-01-01");
        public int Add(Model.tab_loginlog loginlog)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_loginlog values (");
            strsql.AppendFormat("'{0}',", loginlog.loginid);
            strsql.AppendFormat("'{0}',", loginlog.loginpw);
            strsql.AppendFormat("{0},", loginlog.time == baddate ? "null" : "'" + loginlog.time.ToString() + "'");
            strsql.AppendFormat("'{0}',", loginlog.loginip);
            strsql.AppendFormat("'{0}',", loginlog.loginbrowser);
            strsql.AppendFormat("'{0}',", loginlog.logindevice);
            strsql.AppendFormat("'{0}',", loginlog.status);
            strsql.AppendFormat("N'{0}'", loginlog.note);
            strsql.Append(")");
            return sql.ExecuteNonQuery(strsql.ToString());
        }


        public Model.tab_loginlog getloginlog(Model.tab_loginlog loginlog1)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_loginlog where ");
            strsql.AppendFormat("id='{0}'", loginlog1.id);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            Model.tab_loginlog loginlog = new Model.tab_loginlog();
            loginlog.loginid = dt.Rows[0]["loginid"].ToString();
            loginlog.loginpw = dt.Rows[0]["loginpw"].ToString();
            loginlog.time = dt.Rows[0]["time"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["time"].ToString());
            loginlog.loginip = dt.Rows[0]["loginip"].ToString();
            loginlog.loginbrowser = dt.Rows[0]["loginbrowser"].ToString();
            loginlog.logindevice = dt.Rows[0]["logindevice"].ToString();
            loginlog.status = dt.Rows[0]["status"].ToString();
            loginlog.note = dt.Rows[0]["note"].ToString();
            return loginlog;
        }


        public int update(Model.tab_loginlog loginlog)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_loginlog set ");
            strsql.AppendFormat(" loginid ='{0}',", loginlog.loginid);
            strsql.AppendFormat(" loginpw ='{0}',", loginlog.loginpw);
            strsql.AppendFormat(" time ={0},", loginlog.time == baddate ? "null" : "'" + loginlog.time.ToString() + "'");
            strsql.AppendFormat(" loginip ='{0}',", loginlog.loginip);
            strsql.AppendFormat(" loginbrowser ='{0}',", loginlog.loginbrowser);
            strsql.AppendFormat(" logindevice ='{0}',", loginlog.logindevice);
            strsql.AppendFormat(" status ='{0}',", loginlog.status);
            strsql.AppendFormat(" note =N'{0}'", loginlog.note);
            strsql.AppendFormat(" where id={0}", loginlog.id);
            return sql.ExecuteNonQuery(strsql.ToString());
        }


        public int Delete(int id)
        {
            return sql.ExecuteNonQuery("delete from tab_loginlog where id=" + id);
        }
        public DataTable Select(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }

    }
}
