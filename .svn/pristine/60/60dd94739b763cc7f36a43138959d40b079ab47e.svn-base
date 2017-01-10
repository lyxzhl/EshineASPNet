using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SQLServerDAL
{
    class sql_shoporder:IDAL.shoporderDal
    {
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        DateTime baddate = DateTime.Parse("1900-01-01");
        public int Add(Model.tab_shoporder shoporder)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_shoporder values (");
            strsql.AppendFormat("{0},", shoporder.customerID);
            strsql.AppendFormat("N'{0}',", shoporder.customerName);
            strsql.AppendFormat("{0},", shoporder.orderdate == baddate ? "null" : "'" + shoporder.orderdate.ToString() + "'");
            strsql.AppendFormat("'{0}',", shoporder.out_trade_no);
            strsql.AppendFormat("N'{0}',", shoporder.subject);
            strsql.AppendFormat("{0},", shoporder.total_fee);
            strsql.AppendFormat("N'{0}',", shoporder.body);
            strsql.AppendFormat("N'{0}',", shoporder.show_url);
            strsql.AppendFormat("N'{0}',", shoporder.anti_phishing_key);
            strsql.AppendFormat("N'{0}',", shoporder.exter_invoke_ip);
            strsql.AppendFormat("'{0}',", shoporder.trade_no);
            strsql.AppendFormat("'{0}',", shoporder.trade_status);
            strsql.AppendFormat("N'{0}',", shoporder.orderStatus);
            strsql.AppendFormat("N'{0}'", shoporder.Msg);
            strsql.Append(")");
            return sql.ExecuteNonQuery(strsql.ToString());
        }


        public Model.tab_shoporder getshoporder(Model.tab_shoporder shoporder1)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_shoporder where ");
            strsql.AppendFormat("id='{0}'", shoporder1.id);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            Model.tab_shoporder shoporder = new Model.tab_shoporder();
            shoporder.id = shoporder1.id;
            shoporder.customerID = int.Parse(dt.Rows[0]["customerID"].ToString());
            shoporder.customerName = dt.Rows[0]["customerName"].ToString();
            shoporder.orderdate = dt.Rows[0]["orderdate"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["orderdate"].ToString());
            shoporder.out_trade_no = dt.Rows[0]["out_trade_no"].ToString();
            shoporder.subject = dt.Rows[0]["subject"].ToString();
            shoporder.total_fee = double.Parse(dt.Rows[0]["total_fee"].ToString());
            shoporder.body = dt.Rows[0]["body"].ToString();
            shoporder.show_url = dt.Rows[0]["show_url"].ToString();
            shoporder.anti_phishing_key = dt.Rows[0]["anti_phishing_key"].ToString();
            shoporder.exter_invoke_ip = dt.Rows[0]["exter_invoke_ip"].ToString();
            shoporder.trade_no = dt.Rows[0]["trade_no"].ToString();
            shoporder.trade_status = dt.Rows[0]["trade_status"].ToString();
            shoporder.orderStatus = dt.Rows[0]["orderStatus"].ToString();
            shoporder.Msg = dt.Rows[0]["Msg"].ToString();
            return shoporder;
        }


        public int update(Model.tab_shoporder shoporder)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_shoporder set ");
            strsql.AppendFormat(" customerID ='{0}',", shoporder.customerID);
            strsql.AppendFormat(" customerName =N'{0}',", shoporder.customerName);
            strsql.AppendFormat(" orderdate ={0},", shoporder.orderdate == baddate ? "null" : "'" + shoporder.orderdate.ToString() + "'");
            strsql.AppendFormat(" out_trade_no ='{0}',", shoporder.out_trade_no);
            strsql.AppendFormat(" subject =N'{0}',", shoporder.subject);
            strsql.AppendFormat(" total_fee ='{0}',", shoporder.total_fee);
            strsql.AppendFormat(" body =N'{0}',", shoporder.body);
            strsql.AppendFormat(" show_url =N'{0}',", shoporder.show_url);
            strsql.AppendFormat(" anti_phishing_key =N'{0}',", shoporder.anti_phishing_key);
            strsql.AppendFormat(" exter_invoke_ip =N'{0}',", shoporder.exter_invoke_ip);
            strsql.AppendFormat(" trade_no ='{0}',", shoporder.trade_no);
            strsql.AppendFormat(" trade_status ='{0}',", shoporder.trade_status);
            strsql.AppendFormat(" orderStatus =N'{0}',", shoporder.orderStatus);
            strsql.AppendFormat(" Msg =N'{0}'", shoporder.Msg);
            strsql.AppendFormat(" where id={0}", shoporder.id);
            return sql.ExecuteNonQuery(strsql.ToString());
        }


        public int Delete(int id)
        {
            return sql.ExecuteNonQuery("delete from tab_shoporder where id=" + id);
        }
        public DataTable Select(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }

    }
}
