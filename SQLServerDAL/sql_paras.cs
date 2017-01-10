using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SQLServerDAL
{
    class sql_paras:IDAL.parasDal
    {
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        DateTime baddate = DateTime.Parse("1900-01-01");
        public int Add(Model.tab_paras paras)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_paras values (");
            strsql.AppendFormat("N'{0}',", paras.pname);
            strsql.AppendFormat("N'{0}',", paras.pvalue);
            strsql.AppendFormat("N'{0}'", paras.ptype);
            strsql.Append(") select SCOPE_IDENTITY()");
            return Convert.ToInt32(sql.ExecuteSc(strsql.ToString()));
        }


        public Model.tab_paras getparas(Model.tab_paras paras1)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_paras where ");
            strsql.AppendFormat("id='{0}'", paras1.id);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            Model.tab_paras paras = new Model.tab_paras();
            paras.id = paras1.id;
            paras.pname = dt.Rows[0]["pname"].ToString();
            paras.pvalue = dt.Rows[0]["pvalue"].ToString();
            paras.ptype = dt.Rows[0]["ptype"].ToString();
            return paras;
        }


        public int update(Model.tab_paras paras)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_paras set ");
            strsql.AppendFormat(" pname =N'{0}',", paras.pname);
            strsql.AppendFormat(" pvalue =N'{0}',", paras.pvalue);
            strsql.AppendFormat(" ptype =N'{0}'", paras.ptype);
            strsql.AppendFormat(" where id={0}", paras.id);
            return sql.ExecuteNonQuery(strsql.ToString());
        }


        public int Delete(int id)
        {
            return sql.ExecuteNonQuery("delete from tab_paras where id=" + id);
        }
        public DataTable Select(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }

        public string getvalue(string pname)
        {
            return sql.ExecuteSc("select pvalue from tab_paras where pname='" + pname + "'").ToString();
        }

        public int execmd(string s)
        {
            return sql.ExecuteNonQuery(s);
        }
    }
}
