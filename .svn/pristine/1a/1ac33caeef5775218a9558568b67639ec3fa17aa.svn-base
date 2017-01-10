using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bll
{
   public class ProdutClassBLL
    {
        IDAL.ProdutClassDal itu = DALFactory.ProductClass_Factory.Createusers();
        /// <summary>
        /// 向产品类别表添加数据
        /// </summary>
        /// <param name="ProClass"></param>
        /// <returns></returns>
        public int AddProClass(Model.tab_product_class ProClass)
        {
            return itu.Add(ProClass);
        }
        /// <summary>
        /// 根据ID删除产品类别表的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelProClass(int id)
        {
            return itu.Delete(id);
 
        }
        /// <summary>
        /// 根据SQL语句查询产品类别表的信息
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public DataTable SelectProClass(string sq)
        {
            return itu.getAll(sq);
        }
        /// <summary>
        /// 根据SQL语句修改产品类别表的信息
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public int UpdateProClass(string sq)
        {
            return itu.Update(sq);
        }
        /// <summary>
        /// 根据SQL语句查询产品类型表第一行第一列数据
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public object ScProClass(string sq)
        {
            return itu.GetItem(sq);
        }
    }
}
