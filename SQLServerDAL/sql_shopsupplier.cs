using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SQLServerDAL
{
    class sql_shopsupplier:IDAL.shopsupplierDal
    {
        #region SuppliersDal 成员
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <returns></returns>
        public int getMax()
        {
            object x = sql.ExecuteSc("select top 1 id from tab_shopsuppliers supplier by id desc");
            return Convert.ToInt32(x) + 1;
        }
        public Model.tab_shopsuppliers getsuppliers(Model.tab_shopsuppliers suppliers1)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_shopsuppliers where ");
            strsql.AppendFormat("id='{0}'", suppliers1.id);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            Model.tab_shopsuppliers suppliers = new Model.tab_shopsuppliers();
            suppliers.id = suppliers1.id;
            suppliers.supplier = dt.Rows[0]["supplier"].ToString();
            suppliers.hospid = dt.Rows[0]["hospid"].ToString();
            suppliers.province = dt.Rows[0]["province"].ToString();
            suppliers.city = dt.Rows[0]["city"].ToString();
            suppliers.zone = dt.Rows[0]["zone"].ToString();
            suppliers.branch = dt.Rows[0]["branch"].ToString();
            suppliers.address = dt.Rows[0]["address"].ToString();
            suppliers.phone = dt.Rows[0]["phone"].ToString();
            suppliers.note = dt.Rows[0]["note"].ToString();
            suppliers.map = dt.Rows[0]["map"].ToString();
            suppliers.lat = dt.Rows[0]["lat"].ToString();
            suppliers.lng = dt.Rows[0]["lng"].ToString();
            suppliers.type = dt.Rows[0]["type"].ToString();
            suppliers.msg = dt.Rows[0]["msg"].ToString();
            return suppliers;
        }
        public System.Data.DataTable GetAll()
        {
            return sql.ExecuteDataSet("select * from tab_shopsuppliers").Tables[0];
        }

        public System.Data.DataTable GetAny(string sq)
        {
            return sql.ExecuteDataSet(sq).Tables[0];
        }

        public int Add(Model.tab_shopsuppliers suppliers)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_shopsuppliers values (");
            strsql.AppendFormat("N'{0}',", suppliers.supplier);
            strsql.AppendFormat("'{0}',", suppliers.hospid);
            strsql.AppendFormat("N'{0}',", suppliers.province);
            strsql.AppendFormat("N'{0}',", suppliers.city);
            strsql.AppendFormat("N'{0}',", suppliers.zone);
            strsql.AppendFormat("N'{0}',", suppliers.branch);
            strsql.AppendFormat("N'{0}',", suppliers.address);
            strsql.AppendFormat("'{0}',", suppliers.phone);
            strsql.AppendFormat("N'{0}',", suppliers.note);
            strsql.AppendFormat("N'{0}',", suppliers.map);
            strsql.AppendFormat("'{0}',", suppliers.lat);
            strsql.AppendFormat("'{0}',", suppliers.lng);
            strsql.AppendFormat("N'{0}',", suppliers.type);
            strsql.AppendFormat("N'{0}'", suppliers.msg);
            strsql.Append(") select SCOPE_IDENTITY()");
            return Convert.ToInt32(sql.ExecuteSc(strsql.ToString()));
        }

        public int update(Model.tab_shopsuppliers suppliers)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_shopsuppliers set ");
            strsql.AppendFormat(" supplier =N'{0}',", suppliers.supplier);
            strsql.AppendFormat(" hospid ='{0}',", suppliers.hospid);
            strsql.AppendFormat(" province =N'{0}',", suppliers.province);
            strsql.AppendFormat(" city =N'{0}',", suppliers.city);
            strsql.AppendFormat(" zone =N'{0}',", suppliers.zone);
            strsql.AppendFormat(" branch =N'{0}',", suppliers.branch);
            strsql.AppendFormat(" address =N'{0}',", suppliers.address);
            strsql.AppendFormat(" phone ='{0}',", suppliers.phone);
            strsql.AppendFormat(" note =N'{0}',", suppliers.note);
            strsql.AppendFormat(" map =N'{0}',", suppliers.map);
            strsql.AppendFormat(" lat ='{0}',", suppliers.lat);
            strsql.AppendFormat(" lng ='{0}',", suppliers.lng);
            strsql.AppendFormat(" type =N'{0}',", suppliers.type);
            strsql.AppendFormat(" msg =N'{0}'", suppliers.msg);
            strsql.AppendFormat(" where id={0}", suppliers.id);
            return sql.ExecuteNonQuery(strsql.ToString());
        }

        public System.Data.DataSet getsupplierInfo(string sq, string sqlx)
        {
            return sql.ExecuteDataSet(sq, sqlx);
        }
        public int Delete(string st)
        {
            return sql.ExecuteNonQuery(st);
        }
        #endregion
    }
}
