using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SQLServerDAL
{
    public class sql_eticket:IDAL.eticketDal
    {
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        DateTime baddate = DateTime.Parse("1900-01-01");
        public int Add(Model.tab_eticket eticket)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_eticket values (");
            strsql.AppendFormat("{0},", eticket.orderID);
            strsql.AppendFormat("N'{0}',", eticket.customerName);
            strsql.AppendFormat("N'{0}',", eticket.productName);
            strsql.AppendFormat("{0},", eticket.productID);
            strsql.AppendFormat("'{0}',", eticket.itemnum);
            strsql.AppendFormat("N'{0}',", eticket.eticket);
            strsql.AppendFormat("N'{0}',", eticket.used);
            strsql.AppendFormat("{0},", eticket.time == baddate ? "null" : "'" + eticket.time.ToString() + "'");
            strsql.AppendFormat("N'{0}'", eticket.note);
            strsql.Append(") select SCOPE_IDENTITY()");
            return Convert.ToInt32(sql.ExecuteSc(strsql.ToString()));
        }


        public Model.tab_eticket geteticket(Model.tab_eticket eticket1)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_eticket where ");
            strsql.AppendFormat("id='{0}'", eticket1.id);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            Model.tab_eticket eticket = new Model.tab_eticket();
            eticket.id = eticket1.id;
            eticket.orderID = int.Parse(dt.Rows[0]["orderID"].ToString());
            eticket.customerName = dt.Rows[0]["customerName"].ToString();
            eticket.productName = dt.Rows[0]["productName"].ToString();
            eticket.productID = int.Parse(dt.Rows[0]["productID"].ToString());
            eticket.itemnum = dt.Rows[0]["itemnum"].ToString();
            eticket.eticket = dt.Rows[0]["eticket"].ToString();
            eticket.used = dt.Rows[0]["used"].ToString();
            eticket.time = dt.Rows[0]["time"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["time"].ToString());
            eticket.note = dt.Rows[0]["note"].ToString();
            return eticket;
        }


        public int update(Model.tab_eticket eticket)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_eticket set ");
            strsql.AppendFormat(" orderID ='{0}',", eticket.orderID);
            strsql.AppendFormat(" customerName =N'{0}',", eticket.customerName);
            strsql.AppendFormat(" productName =N'{0}',", eticket.productName);
            strsql.AppendFormat(" productID ='{0}',", eticket.productID);
            strsql.AppendFormat(" itemnum ='{0}',", eticket.itemnum);
            strsql.AppendFormat(" eticket =N'{0}',", eticket.eticket);
            strsql.AppendFormat(" used =N'{0}',", eticket.used);
            strsql.AppendFormat(" time ={0},", eticket.time == baddate ? "null" : "'" + eticket.time.ToString() + "'");
            strsql.AppendFormat(" note =N'{0}'", eticket.note);
            strsql.AppendFormat(" where id={0}", eticket.id);
            return sql.ExecuteNonQuery(strsql.ToString());
        }


        public int Delete(int id)
        {
            return sql.ExecuteNonQuery("delete from tab_eticket where id=" + id);
        }
        public DataTable Select(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }

    }
}
