using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SQLServerDAL
{
     public class sql_Dictionary :IDAL.DictionaryDal
    {
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        DateTime baddate = DateTime.Parse("1900-01-01");
        public int Add(Model.Dictionary Dictionary)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into Dictionary values (");
            strsql.AppendFormat("'{0}',", Dictionary.dicType);
            strsql.AppendFormat("'{0}',", Dictionary.dicValue);
            strsql.AppendFormat("'{0}',", Dictionary.dicEName);
            strsql.AppendFormat("N'{0}',", Dictionary.dicCName);
            strsql.AppendFormat("{0},", Dictionary.ParentID);
            strsql.AppendFormat("'{0}',", Dictionary.dicRemark);
            strsql.AppendFormat("{0},", Dictionary.CreateTime == baddate ? "null" : "'" + Dictionary.CreateTime.ToString() + "'");
            strsql.AppendFormat("{0},", Dictionary.UpdateTime == baddate ? "null" : "'" + Dictionary.UpdateTime.ToString() + "'");
            strsql.AppendFormat("{0},", Dictionary.CreateUser);
            strsql.AppendFormat("{0},", Dictionary.UpdateUser);
            strsql.AppendFormat("{0},", Dictionary.IsShow);
            strsql.AppendFormat("{0}", Dictionary.IsDel);
            strsql.Append(") select SCOPE_IDENTITY()");
            return Convert.ToInt32(sql.ExecuteSc(strsql.ToString()));
        }


        public Model.Dictionary getDictionary(Model.Dictionary Dictionary1)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from Dictionary where ");
            strsql.AppendFormat("dicID='{0}'", Dictionary1.dicID);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            Model.Dictionary Dictionary = new Model.Dictionary();
            Dictionary.dicID = Dictionary1.dicID;
            Dictionary.dicType = dt.Rows[0]["dicType"].ToString();
            Dictionary.dicValue = dt.Rows[0]["dicValue"].ToString();
            Dictionary.dicEName = dt.Rows[0]["dicEName"].ToString();
            Dictionary.dicCName = dt.Rows[0]["dicCName"].ToString();
            Dictionary.ParentID = int.Parse(dt.Rows[0]["ParentID"].ToString());
            Dictionary.dicRemark = dt.Rows[0]["dicRemark"].ToString();
            Dictionary.CreateTime = dt.Rows[0]["CreateTime"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["CreateTime"].ToString());
            Dictionary.UpdateTime = dt.Rows[0]["UpdateTime"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["UpdateTime"].ToString());
            Dictionary.CreateUser = int.Parse(dt.Rows[0]["CreateUser"].ToString());
            Dictionary.UpdateUser = int.Parse(dt.Rows[0]["UpdateUser"].ToString());
            Dictionary.IsShow = int.Parse(dt.Rows[0]["IsShow"].ToString());
            Dictionary.IsDel = int.Parse(dt.Rows[0]["IsDel"].ToString());
            return Dictionary;
        }


        public int update(Model.Dictionary Dictionary)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update Dictionary set ");
            strsql.AppendFormat(" dicType ='{0}',", Dictionary.dicType);
            strsql.AppendFormat(" dicValue ='{0}',", Dictionary.dicValue);
            strsql.AppendFormat(" dicEName ='{0}',", Dictionary.dicEName);
            strsql.AppendFormat(" dicCName =N'{0}',", Dictionary.dicCName);
            strsql.AppendFormat(" ParentID ='{0}',", Dictionary.ParentID);
            strsql.AppendFormat(" dicRemark ='{0}',", Dictionary.dicRemark);
            strsql.AppendFormat(" CreateTime ={0},", Dictionary.CreateTime == baddate ? "null" : "'" + Dictionary.CreateTime.ToString() + "'");
            strsql.AppendFormat(" UpdateTime ={0},", Dictionary.UpdateTime == baddate ? "null" : "'" + Dictionary.UpdateTime.ToString() + "'");
            strsql.AppendFormat(" CreateUser ='{0}',", Dictionary.CreateUser);
            strsql.AppendFormat(" UpdateUser ='{0}',", Dictionary.UpdateUser);
            strsql.AppendFormat(" IsShow ='{0}',", Dictionary.IsShow);
            strsql.AppendFormat(" IsDel ='{0}'", Dictionary.IsDel);
            strsql.AppendFormat(" where dicID={0}", Dictionary.dicID);
            return sql.ExecuteNonQuery(strsql.ToString());
        }


        public int Delete(int dicID)
        {
            return sql.ExecuteNonQuery("delete from Dictionary where dicID=" + dicID);
        }
        public DataTable Select(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }

    }
}
