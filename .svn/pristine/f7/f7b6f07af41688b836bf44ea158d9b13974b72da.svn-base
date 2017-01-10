using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Bll
{
    public class RolesBll
    {
        IDAL.RolesDal itu = DALFactory.RolesFactory.Createusers();
        /// <summary>
        /// 查看所有权限
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            return itu.GetAll();
        }
        /// <summary>
        /// 根据选择查看不同的权限信息
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public DataTable GetAny(Model.tab_roles roles)
        {
            return itu.GetAny(roles);
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public int Add(Model.tab_roles roles)
        {
            return itu.Add(roles);
        }
        /// <summary>
        /// 根据ID删除权限
        /// </summary>
        /// <param name="powerID"></param>
        /// <returns></returns>
        public int Delete(int powerID)
        {
            return itu.Delete(powerID);
        }
        /// <summary>
        /// 放在同一个DataSet
        /// </summary>
        /// <param name="sql1"></param>
        /// <param name="sql2"></param>
        /// <returns></returns>
        public DataSet GetPowClass(string sql1, string sql2)
        {
            return itu.GetPowClass(sql1,sql2);
        }
        public int update(Model.tab_roles ro)
        {
            return itu.update(ro);
        }

    }
}
