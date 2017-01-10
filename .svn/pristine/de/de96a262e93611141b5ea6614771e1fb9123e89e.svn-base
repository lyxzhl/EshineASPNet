using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SQLServerDAL
{
    class sql_relative:IDAL.relativeDal
    {
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        #region relativeDal 成员
        /// <summary>
        /// 客户表的添加
        /// </summary>
        /// <param name="relative"></param>
        /// <returns></returns>
        DateTime baddate = DateTime.Parse("1900-01-01");
        public int RelativeAdd(Model.tab_relatives relative)
        {
            //DateTime baddate = DateTime.Parse("1900-01-01");
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_relatives values (");
            strsql.AppendFormat("N'{0}',", relative.relativeName);
            strsql.AppendFormat("'{0}',", relative.relativeEmail);
            strsql.AppendFormat("'{0}',", relative.relativeMobile);
            strsql.AppendFormat("N'{0}',", relative.relativeProvince);
            strsql.AppendFormat("N'{0}',", relative.relativeCity);
            strsql.AppendFormat("N'{0}',", relative.relativeAddress);
            strsql.AppendFormat("N'{0}',", relative.relativeGender);
            strsql.AppendFormat("N'{0}',", relative.relativeMarriageStatus);
            strsql.AppendFormat("{0},", relative.relativeDOB == baddate ? "null" : "'" + relative.relativeDOB.ToString() + "'");
            strsql.AppendFormat("N'{0}',", relative.relativeNation);
            strsql.AppendFormat("'{0}',", relative.relativeIDcard);
            strsql.AppendFormat("'{0}',", relative.relativeCustomer);
            strsql.AppendFormat("N'{0}'", relative.relativeRelationship);
            strsql.Append(") select SCOPE_IDENTITY()");

            return Convert.ToInt32(sql.ExecuteSc(strsql.ToString()));
            //return sql.ExecuteNonQuery(strsql.ToString());

        }
        /// <summary>
        /// 客户表的查找
        /// </summary>
        /// <param name="rel"></param>
        /// <returns></returns>
        public System.Data.DataTable RelativeSelect(Model.tab_relatives rel)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_relatives where ");
            strsql.AppendFormat("relativeID='{0}'", rel.relativeID);
            strsql.AppendFormat(" or relativeEmail='{0}'", rel.relativeEmail);
            return sql.ExecuteDataSet(strsql.ToString()).Tables[0];
        }
        /// <summary>
        /// 返回客户
        /// </summary>
        /// <param name="rel"></param>
        /// <returns></returns>
        public Model.tab_relatives getRelative(Model.tab_relatives rel)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_relatives where ");
            strsql.AppendFormat("relativeID='{0}'", rel.relativeID);
            //strsql.AppendFormat(" or relativeEmail='{0}'", rel.relativeEmail);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];

            Model.tab_relatives relative = new Model.tab_relatives();
            relative.relativeName = dt.Rows[0]["relativeName"].ToString();
            relative.relativeEmail = dt.Rows[0]["relativeEmail"].ToString();
            relative.relativeMobile = dt.Rows[0]["relativeMobile"].ToString();
            relative.relativeProvince = dt.Rows[0]["relativeProvince"].ToString();
            relative.relativeCity = dt.Rows[0]["relativeCity"].ToString();
            relative.relativeAddress = dt.Rows[0]["relativeAddress"].ToString();
            relative.relativeGender = dt.Rows[0]["relativeGender"].ToString();
            relative.relativeMarriageStatus = dt.Rows[0]["relativeMarriageStatus"].ToString();
            relative.relativeDOB = dt.Rows[0]["relativeDOB"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["relativeDOB"].ToString());
            relative.relativeNation = dt.Rows[0]["relativeNation"].ToString();
            relative.relativeIDcard = dt.Rows[0]["relativeIDcard"].ToString();
            relative.relativeCustomer = int.Parse(dt.Rows[0]["relativeCustomer"].ToString());
            relative.relativeRelationship = dt.Rows[0]["relativeRelationship"].ToString();
            relative.relativeID = int.Parse(dt.Rows[0]["relativeID"].ToString());

            return relative;
        }
        /// <summary>
        /// 查找所有客户的信息
        /// </summary>
        /// <returns></returns>

        public System.Data.DataTable RelativeSelectAll()
        {
            return sql.ExecuteDataSet("select * from tab_relatives").Tables[0];
        }
        /// <summary>
        /// 删除客户的信息
        /// </summary>
        /// <param name="relativeID"></param>
        /// <returns></returns>
        public int Delete(int relativeID)
        {
            return sql.ExecuteNonQuery("delete from tab_relatives where relativeID=" + relativeID);
        }
        /// <summary>
        /// 修改客户的信息
        /// </summary>
        /// <param name="rel"></param>
        /// <returns></returns>

        public int update(Model.tab_relatives rel)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_relatives set ");
            strsql.AppendFormat(" relativeName =N'{0}',", rel.relativeName);
            strsql.AppendFormat(" relativeEmail ='{0}',", rel.relativeEmail);
            strsql.AppendFormat(" relativeProvince =N'{0}',", rel.relativeProvince);
            strsql.AppendFormat(" relativeCity =N'{0}',", rel.relativeCity);
            strsql.AppendFormat(" relativeAddress =N'{0}',", rel.relativeAddress);
            strsql.AppendFormat(" relativeGender =N'{0}',", rel.relativeGender);
            strsql.AppendFormat(" relativeMarriageStatus =N'{0}',", rel.relativeMarriageStatus);
            strsql.AppendFormat(" relativeDOB ={0},", rel.relativeDOB == baddate ? "null" : "'" + rel.relativeDOB.ToString() + "'");
            strsql.AppendFormat(" relativeNation =N'{0}',", rel.relativeNation);
            strsql.AppendFormat(" relativeIDcard ='{0}',", rel.relativeIDcard);
            strsql.AppendFormat(" relativeMobile ='{0}',", rel.relativeMobile);
            strsql.AppendFormat(" relativeCustomer ={0},", rel.relativeCustomer);
            strsql.AppendFormat(" relativeRelationship =N'{0}'", rel.relativeRelationship);
            strsql.AppendFormat(" where relativeID={0}", rel.relativeID);
            return sql.ExecuteNonQuery(strsql.ToString());

        }
        public DataTable RelativeSelect(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }

        #endregion
    }
}
