using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bll
{
   public class empBll
    {
        IDAL.empDal itu = DALFactory.emp_Factory.Createusers();
        /// <summary>
        /// 查询用户所有信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            return itu.GetAll();
        }
        /// <summary>
        /// 查询用户部分信息 模型
        /// </summary>
        /// <param name="mopower"></param>
        /// <returns></returns>
       public DataTable Getany(string id)
        {
           return itu.Getany(id);
 
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public  int Delete(int id)
        {
            return itu.Delete(id);
 
        }
        /// <summary>
        /// 修改拥护
        /// </summary>
        /// <param name="tem"></param>
        /// <returns></returns>
        public int Update(Model.tab_emps tem)
        {
            return  itu.Update(tem);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="tem"></param>
        /// <returns></returns>
        public int insert(Model.tab_emps tem)
        {
            return itu.insert(tem);
        }
         public DataTable  GetModel(Model.tab_emps tem)
          {
              return itu.GetModel(tem);
          }
    }
}
