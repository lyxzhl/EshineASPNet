using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace IDAL
{
    public interface shopsupplierDal
    {
        int getMax();
        DataTable GetAll();
        DataTable GetAny(string sql);
        Model.tab_shopsuppliers getsuppliers(Model.tab_shopsuppliers suppliers1);
        int Add(Model.tab_shopsuppliers m_supplier);
        int update(Model.tab_shopsuppliers suppliers);
        DataSet getsupplierInfo(string sql, string sqlx);
        int Delete(string st);
    }
}
