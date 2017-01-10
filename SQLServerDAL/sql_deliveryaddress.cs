using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SQLServerDAL
{
    class sql_deliveryaddress : IDAL.deliveryaddressDal
    {
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        DateTime baddate = DateTime.Parse("1900-01-01");
        public int Add(Model.deliveryaddress deliveryaddress)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into deliveryaddress values (");
            strsql.AppendFormat("N'{0}',", deliveryaddress.company);
            strsql.AppendFormat("N'{0}',", deliveryaddress.provence);
            strsql.AppendFormat("N'{0}'", deliveryaddress.address);
            strsql.Append(") select SCOPE_IDENTITY()");
            return Convert.ToInt32(sql.ExecuteSc(strsql.ToString()));
        }


        public Model.deliveryaddress getdeliveryaddress(Model.deliveryaddress deliveryaddress1)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from deliveryaddress where ");
            strsql.AppendFormat("id='{0}'", deliveryaddress1.id);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            Model.deliveryaddress deliveryaddress = new Model.deliveryaddress();
            deliveryaddress.id = deliveryaddress1.id;
            deliveryaddress.company = dt.Rows[0]["company"].ToString();
            deliveryaddress.provence = dt.Rows[0]["provence"].ToString();
            deliveryaddress.address = dt.Rows[0]["address"].ToString();
            return deliveryaddress;
        }


        public int update(Model.deliveryaddress deliveryaddress)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update deliveryaddress set ");
            strsql.AppendFormat(" company =N'{0}',", deliveryaddress.company);
            strsql.AppendFormat(" provence =N'{0}',", deliveryaddress.provence);
            strsql.AppendFormat(" address =N'{0}'", deliveryaddress.address);
            strsql.AppendFormat(" where id={0}", deliveryaddress.id);
            return sql.ExecuteNonQuery(strsql.ToString());
        }


        public int Delete(int id)
        {
            return sql.ExecuteNonQuery("delete from deliveryaddress where id=" + id);
        }
        public DataTable Select(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }

    }
}
