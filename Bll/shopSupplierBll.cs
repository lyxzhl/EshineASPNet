using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Bll
{
    public class shopSupplierBll
    {
        IDAL.shopsupplierDal itu = DALFactory.shopsupplier_Factory.Createusers();
        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <returns></returns>
        public int getMax()
        {
            return itu.getMax();
        }
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            return itu.GetAll();
        }
        /// <summary>
        /// 获取指定信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetAny(string sql)
        {
            return itu.GetAny(sql);
        }

        public Model.tab_shopsuppliers getsuppliers(Model.tab_shopsuppliers suppliers1)
        {
            return itu.getsuppliers(suppliers1);
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="m_supplier"></param>
        /// <returns></returns>
        public int Add(Model.tab_shopsuppliers m_supplier)
        {
            return itu.Add(m_supplier);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int update(Model.tab_shopsuppliers suppliers)
        {
            return itu.update(suppliers);
        }
        /// <summary>
        /// 父子表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlx"></param>
        /// <returns></returns>
        public DataSet getsupplierInfo(string sql, string sqlx)
        {
            return itu.getsupplierInfo(sql, sqlx);
        }
        public int Delete(string st)
        {
            return itu.Delete(st);
        }
    }
}
