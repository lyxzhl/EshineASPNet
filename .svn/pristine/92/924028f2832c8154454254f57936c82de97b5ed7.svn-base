using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SQLServerDAL
{
    class sql_product_class:IDAL.ProdutClassDal
    {
        #region ProdutClassDal 成员
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        /// <summary>
        /// 查询表
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public DataTable getAll(string sq)
        {
            return sql.ExecuteDataSet(sq).Tables[0];
        }
        /// <summary>
        /// 为产品类别表添加一条记录
        /// </summary>
        /// <param name="proClass">实体对象</param>
        /// <returns></returns>

        public int Add(Model.tab_product_class proClass)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_productClass(productClassName,productClassParentID,productClassContent) values( ");
            strsql.AppendFormat("'{0}',", proClass.ProductClassName);
            strsql.AppendFormat("'{0}',", proClass.ProductClassParentID);
            strsql.AppendFormat("'{0}')", proClass.ProductClassContent);
            return sql.ExecuteNonQuery(strsql.ToString());
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="productClassID"></param>
        /// <returns></returns>

        public int Delete(int productClassID)
        {
            return sql.ExecuteNonQuery("delete from tab_productClass where productClassID=" + productClassID);
        }
        /// <summary>
        /// 查询第一条记录
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public object GetItem(string sq)
        {
            return sql.ExecuteSc(sq);
        }
        public int Update(string sq)
        {
            return sql.ExecuteNonQuery(sq);
        }

        #endregion
    }
}
