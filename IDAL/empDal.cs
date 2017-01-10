using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL
{
    public interface empDal
    {
      DataTable GetAll();
      DataTable Getany(string id);
      int Delete(int id);
      int Update(Model.tab_emps tem);
      int insert(Model.tab_emps tem);
      DataTable GetModel(Model.tab_emps tem);
    }
}
