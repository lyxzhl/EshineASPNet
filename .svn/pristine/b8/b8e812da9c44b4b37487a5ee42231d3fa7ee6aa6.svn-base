using System;
using System.Collections.Generic;
using System.Text;

namespace SQLServerDAL
{
    class sql_v_ProClass:IDAL.v_ProClassDal
    {
        #region v_ProClassDal 成员
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        /// <summary>
        /// 把2张表放在同一个DataSat里面
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public System.Data.DataSet GetTable(string str1, string str2)
        {
            return sql.ExecuteDataSet(str1, str2);
        }

        #endregion
    }
}
