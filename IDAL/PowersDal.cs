using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace IDAL
{
   public interface PowersDal
    {
        //获取所有权限信息
        DataTable GetAll();
        //获取权限部分信息
        DataTable GetAny(string sq);
        //向权限表添加一条信息
       int Add(Model.tab_powers mopower);
        //向权限表删除一条信息
        int Delete(string sq);
        //获取具有父子关系的权限;
        DataSet GetPowClass(string sq, string sq1);
        //修改权限
        int PowerUpdate(Model.tab_powers tow);
    }
}
