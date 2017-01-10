using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bll
{
  public  class ProwerBll
    {
        IDAL.PowersDal itu = DALFactory.Powers_Factory.Createusers();
        /// <summary>
        /// 向权限表添加一条信息
        /// </summary>
        /// <param name="tab_power"></param>
        /// <returns></returns>
        public int AddPrower(Model.tab_powers tab_power)
        {
            return itu.Add(tab_power);
        }
        /// <summary>
        /// 获取所有权限信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetProwerALL()
        {
            return itu.GetAll();
        }
        /// <summary>
        /// 获取部分权限
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public DataTable GetProwerAny(string sq)
        {
            return itu.GetAny(sq);
        }
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public int UpdataPrower(Model.tab_powers sq)
        {
            return itu.PowerUpdate(sq);
        }
        
    }
}
