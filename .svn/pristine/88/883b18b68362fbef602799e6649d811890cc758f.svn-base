using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL
{
   public interface RolesDal
    { 
        //获取权限部分信息
        DataTable GetAll();
        DataTable GetAny(Model.tab_roles roles);
        int Add(Model.tab_roles roles);
        int Delete(int powerID);
        DataSet GetPowClass(string sql1, string sql2);
       int update(Model.tab_roles roles);
    }
}
