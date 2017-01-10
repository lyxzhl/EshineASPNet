using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace IDAL
{
    public interface loginlogDal
    {
        int Add(Model.tab_loginlog loginlog);
        Model.tab_loginlog getloginlog(Model.tab_loginlog loginlog1);
        int update(Model.tab_loginlog loginlog);
        int Delete(int id);
        DataTable Select(string ss);

    }
}
