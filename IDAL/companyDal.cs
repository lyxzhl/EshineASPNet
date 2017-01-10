using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL
{
    public interface companyDal
    {
        int Add(Model.tab_company company);
        Model.tab_company getcompany(Model.tab_company company1);
        int update(Model.tab_company company);
        int Delete(int id);
        DataTable Select(string ss);


    }
}
