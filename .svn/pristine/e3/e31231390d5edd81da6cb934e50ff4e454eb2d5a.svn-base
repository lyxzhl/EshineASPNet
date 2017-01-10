using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SQLServerDAL
{
    public class sql_products : IDAL.ProductDal
    {
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        DateTime baddate = DateTime.Parse("1900-01-01");
        public int Add(Model.tab_products products)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_products values (");
            strsql.AppendFormat("N'{0}',", products.productName);
            strsql.AppendFormat("{0},", products.productClassID);
            strsql.AppendFormat("N'{0}',", products.ikangName);
            strsql.AppendFormat("'{0}',", products.ikangID);
            strsql.AppendFormat("N'{0}',", products.meinianName);
            strsql.AppendFormat("'{0}',", products.meinianID);
            strsql.AppendFormat("N'{0}',", products.cimingNmae);
            strsql.AppendFormat("'{0}',", products.cimingID);
            strsql.AppendFormat("N'{0}',", products.ex1Name);
            strsql.AppendFormat("N'{0}',", products.ex1ID);
            strsql.AppendFormat("'{0}',", products.type);
            strsql.AppendFormat("N'{0}',", products.unit);
            strsql.AppendFormat("N'{0}',", products.uplimit);
            strsql.AppendFormat("N'{0}',", products.downlimit);
            strsql.AppendFormat("{0},", products.productUnitPrice);
            strsql.AppendFormat("{0},", products.productMarketPrice);
            strsql.AppendFormat("N'{0}',", products.productContent);
            strsql.AppendFormat("{0},", products.productDate == baddate ? "null" : "'" + products.productDate.ToString() + "'");
            strsql.AppendFormat("N'{0}',", products.productImg);
            strsql.AppendFormat("{0},", products.productCount);
            strsql.AppendFormat("N'{0}',", products.msg);
            strsql.AppendFormat("{0},", products.px);
            strsql.AppendFormat("N'{0}',", products.productName_eng);
            strsql.AppendFormat("N'{0}',", products.ikangName_eng);
            strsql.AppendFormat("N'{0}',", products.meinianName_eng);
            strsql.AppendFormat("N'{0}',", products.cimingName_eng);
            strsql.AppendFormat("N'{0}',", products.ex1Name_eng);
            strsql.AppendFormat("N'{0}',", products.ex1ID_eng);
            strsql.AppendFormat("N'{0}',", products.downlimit_eng);
            strsql.AppendFormat("N'{0}',", products.productContent_eng);
            strsql.AppendFormat("N'{0}',", products.productImg_eng);
            strsql.AppendFormat("N'{0}'", products.msg_eng);
            strsql.Append(") select SCOPE_IDENTITY()");
            return Convert.ToInt32(sql.ExecuteSc(strsql.ToString()));
        }


        public Model.tab_products getproducts(Model.tab_products products1)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_products where ");
            strsql.AppendFormat("productID='{0}'", products1.productID);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            Model.tab_products products = new Model.tab_products();
            products.productID = products1.productID;
            products.productName = dt.Rows[0]["productName"].ToString();
            products.productClassID = int.Parse(dt.Rows[0]["productClassID"].ToString());
            products.ikangName = dt.Rows[0]["ikangName"].ToString();
            products.ikangID = dt.Rows[0]["ikangID"].ToString();
            products.meinianName = dt.Rows[0]["meinianName"].ToString();
            products.meinianID = dt.Rows[0]["meinianID"].ToString();
            products.cimingNmae = dt.Rows[0]["cimingNmae"].ToString();
            products.cimingID = dt.Rows[0]["cimingID"].ToString();
            products.ex1Name = dt.Rows[0]["ex1Name"].ToString();
            products.ex1ID = dt.Rows[0]["ex1ID"].ToString();
            products.type = dt.Rows[0]["type"].ToString();
            products.unit = dt.Rows[0]["unit"].ToString();
            products.uplimit = dt.Rows[0]["uplimit"].ToString();
            products.downlimit = dt.Rows[0]["downlimit"].ToString();
            products.productUnitPrice = double.Parse(dt.Rows[0]["productUnitPrice"].ToString());
            products.productMarketPrice = double.Parse(dt.Rows[0]["productMarketPrice"].ToString());
            products.productContent = dt.Rows[0]["productContent"].ToString();
            products.productDate = dt.Rows[0]["productDate"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["productDate"].ToString());
            products.productImg = dt.Rows[0]["productImg"].ToString();
            products.productCount = int.Parse(dt.Rows[0]["productCount"].ToString());
            products.msg = dt.Rows[0]["msg"].ToString();
            products.px = int.Parse(dt.Rows[0]["px"].ToString());
            products.productName_eng = dt.Rows[0]["productName_eng"].ToString();
            products.ikangName_eng = dt.Rows[0]["ikangName_eng"].ToString();
            products.meinianName_eng = dt.Rows[0]["meinianName_eng"].ToString();
            products.cimingName_eng = dt.Rows[0]["cimingName_eng"].ToString();
            products.ex1Name_eng = dt.Rows[0]["ex1Name_eng"].ToString();
            products.ex1ID_eng = dt.Rows[0]["ex1ID_eng"].ToString();
            products.downlimit_eng = dt.Rows[0]["downlimit_eng"].ToString();
            products.productContent_eng = dt.Rows[0]["productContent_eng"].ToString();
            products.productImg_eng = dt.Rows[0]["productImg_eng"].ToString();
            products.msg_eng = dt.Rows[0]["msg_eng"].ToString();
            return products;
        }


        public int update(Model.tab_products products)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_products set ");
            strsql.AppendFormat(" productName =N'{0}',", products.productName);
            strsql.AppendFormat(" productClassID ='{0}',", products.productClassID);
            strsql.AppendFormat(" ikangName =N'{0}',", products.ikangName);
            strsql.AppendFormat(" ikangID ='{0}',", products.ikangID);
            strsql.AppendFormat(" meinianName =N'{0}',", products.meinianName);
            strsql.AppendFormat(" meinianID ='{0}',", products.meinianID);
            strsql.AppendFormat(" cimingNmae =N'{0}',", products.cimingNmae);
            strsql.AppendFormat(" cimingID ='{0}',", products.cimingID);
            strsql.AppendFormat(" ex1Name =N'{0}',", products.ex1Name);
            strsql.AppendFormat(" ex1ID =N'{0}',", products.ex1ID);
            strsql.AppendFormat(" type ='{0}',", products.type);
            strsql.AppendFormat(" unit =N'{0}',", products.unit);
            strsql.AppendFormat(" uplimit =N'{0}',", products.uplimit);
            strsql.AppendFormat(" downlimit =N'{0}',", products.downlimit);
            strsql.AppendFormat(" productUnitPrice ='{0}',", products.productUnitPrice);
            strsql.AppendFormat(" productMarketPrice ='{0}',", products.productMarketPrice);
            strsql.AppendFormat(" productContent =N'{0}',", products.productContent);
            strsql.AppendFormat(" productDate ={0},", products.productDate == baddate ? "null" : "'" + products.productDate.ToString() + "'");
            strsql.AppendFormat(" productImg =N'{0}',", products.productImg);
            strsql.AppendFormat(" productCount ='{0}',", products.productCount);
            strsql.AppendFormat(" msg =N'{0}',", products.msg);
            strsql.AppendFormat(" px ='{0}',", products.px);
            strsql.AppendFormat(" productName_eng =N'{0}',", products.productName_eng);
            strsql.AppendFormat(" ikangName_eng =N'{0}',", products.ikangName_eng);
            strsql.AppendFormat(" meinianName_eng =N'{0}',", products.meinianName_eng);
            strsql.AppendFormat(" cimingName_eng =N'{0}',", products.cimingName_eng);
            strsql.AppendFormat(" ex1Name_eng =N'{0}',", products.ex1Name_eng);
            strsql.AppendFormat(" ex1ID_eng =N'{0}',", products.ex1ID_eng);
            strsql.AppendFormat(" downlimit_eng =N'{0}',", products.downlimit_eng);
            strsql.AppendFormat(" productContent_eng =N'{0}',", products.productContent_eng);
            strsql.AppendFormat(" productImg_eng =N'{0}',", products.productImg_eng);
            strsql.AppendFormat(" msg_eng =N'{0}'", products.msg_eng);
            strsql.AppendFormat(" where productID={0}", products.productID);
            return sql.ExecuteNonQuery(strsql.ToString());
        }


        public int Delete(int productID)
        {
            return sql.ExecuteNonQuery("delete from tab_products where productID=" + productID);
        }
        public DataTable Select(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }




        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public int Update(string sq)
        {

            return sql.ExecuteNonQuery(sq);
        }
        /// <summary>
        /// 查询一张表
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public DataTable GetTable(string sq)
        {
            DataTable dt = sql.ExecuteDataSet(sq).Tables[0];
            if (dt != null)
                return dt;
            else return null;
        }
    }
}
