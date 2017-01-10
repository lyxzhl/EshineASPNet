using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bll
{
    public class RelativeBLL
    {
        IDAL.relativeDal itu = DALFactory.relative_Factory.Createusers();
        /// <summary>
        /// 客户表的添加
        /// </summary>
        /// <param name="relative"></param>
        /// <returns></returns>
        public int RelativeAdd(Model.tab_relatives relative)
        {
            return itu.RelativeAdd(relative);
        }
        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //public static bool Register(Model.tab_relatives relative)
        //{
        //    if (LoginIdExists(user.LoginId))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        itu.RelativeAdd(relative);
        //        return true;
        //    }
        //}
        /// <summary>
        /// 根据条件客户表的查寻
        /// </summary>
        /// <param name="rel"></param>
        /// <returns></returns>
        public DataTable RelativeSelect(Model.tab_relatives rel)
        {
            return itu.RelativeSelect(rel);
        }

        public Model.tab_relatives getRelative(Model.tab_relatives rel)
        {
            return itu.getRelative(rel);
        }
        /// <summary>
        /// 客户表的查寻
        /// </summary>
        /// <returns></returns>
        public DataTable RelativeSelectAll()
        {
            return itu.RelativeSelectAll();
        }
        /// <summary>
        /// 客户表的删除
        /// </summary>
        /// <param name="relativeID"></param>
        /// <returns></returns>
        public int Delete(int relativeID)
        {
            return itu.Delete(relativeID);
        }
        /// <summary>
        /// 客户表的修改
        /// </summary>
        /// <param name="rel"></param>
        /// <returns></returns>
        public int update(Model.tab_relatives rel)
        {
            return itu.update(rel);
        }
        public DataTable RelativeSelect(string ss)
        {
            return itu.RelativeSelect(ss);
        }
    }
}
