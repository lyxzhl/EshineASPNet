using System;
using System.Collections.Generic;
using System.Text;

namespace SQLServerDAL
{
   public class sql_powers:IDAL.PowersDal
    {
        #region PowersDal 成员
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        /// <summary>
        /// //获取所有权限信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetAll()
        {
            return sql.ExecuteDataSet("select * from tab_powers").Tables[0];
        }
        /// <summary>
        /// 获取权限部分信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>

        public System.Data.DataTable GetAny(string sq)
        {
            return sql.ExecuteDataSet(sq).Tables[0];
        }
        /// <summary>
        /// 向权限表添加一条信息
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public int Add(Model.tab_powers mopower)
        {
            StringBuilder str = new StringBuilder();
            str.Append("insert into tab_powers (powerName,powerContent,powerUrl,powerPID) values(");
            str.AppendFormat("'{0}','{1}','{2}','{3}')", mopower.PowerName, mopower.PowerContent, mopower.PowerUrl, mopower.PowerPID);
            return sql.ExecuteNonQuery(str.ToString());
        }
        /// <summary>
        /// 向权限表删除一条信息
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public int Delete(string sq)
        {
            return sql.ExecuteNonQuery("delete from tab_powers where powerID="+sq);
        }
        /// <summary>
        /// 把权限放在一个DataSet里面
        /// </summary>
        /// <param name="sq"></param>
        /// <param name="sq1"></param>
        /// <returns></returns>
        public System.Data.DataSet GetPowClass(string sq, string sq1)
        {
            return sql.ExecuteDataSet(sq, sq1);
        }
        /// <summary>
        /// 修改权限表
        /// </summary>
        /// <param name="mopower"></param>
        /// <returns></returns>
       public int PowerUpdate(Model.tab_powers mopower)
       {
           StringBuilder strsql = new StringBuilder();
           strsql.Append("update tab_powers set ");
           strsql.AppendFormat("powerName='{0}',", mopower.PowerName);
           strsql.AppendFormat("powerContent='{0}',", mopower.PowerContent);

           strsql.AppendFormat("powerUrl='{0}',", mopower.PowerUrl);
           strsql.AppendFormat("powerPID='{0}'", mopower.PowerPID);
           strsql.AppendFormat("where powerID={0}", mopower.PowerID);

           return sql.ExecuteNonQuery(strsql.ToString());

       }
        #endregion
    }
}
