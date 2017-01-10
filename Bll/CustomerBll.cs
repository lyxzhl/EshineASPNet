using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bll
{
    public  class CustomerBll
    {
        IDAL.customerDal itu = DALFactory.customer_Factory.Createusers();
        /// <summary>
        /// 客户表的添加
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public int CustomerAdd(Model.tab_customers customer)
        {
            return itu.CustomerAdd(customer);
        }
        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //public static bool Register(Model.tab_customers customer)
        //{
        //    if (LoginIdExists(user.LoginId))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        itu.CustomerAdd(customer);
        //        return true;
        //    }
        //}
        /// <summary>
        /// 根据条件客户表的查寻
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public DataTable CustomerSelect(Model.tab_customers cus)
        {
            return itu.CustomerSelect(cus);
        }

        public Model.tab_customers getCustomer(Model.tab_customers cus)
        {
            return itu.getCustomer(cus);
        }
        /// <summary>
        /// 客户表的查寻
        /// </summary>
        /// <returns></returns>
        public DataTable CustomerSelectAll()
        {
            return itu.CustomerSelectAll();
        }
        /// <summary>
        /// 客户表的删除
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public int Delete(int customerID)
        {
            return itu.Delete(customerID);
        }
        /// <summary>
        /// 客户表的修改
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public int update(Model.tab_customers cus)
        {
            return itu.update(cus);
        }
        public DataTable CustomerSelect(string ss)
        {
            return itu.CustomerSelect(ss);
        }
        public double getbalance(int id)
        {
            return itu.getbalance(id);
        }
    }
}
