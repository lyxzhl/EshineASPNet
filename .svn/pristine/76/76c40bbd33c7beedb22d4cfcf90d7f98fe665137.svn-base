using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace IDAL
{
    public interface supplierDal
    {
        int getMax();
        DataTable GetAll();
        DataTable GetAny(string sql);
        Model.tab_suppliers getsuppliers(Model.tab_suppliers suppliers1);
        int Add(Model.tab_suppliers m_supplier);
        int update(Model.tab_suppliers suppliers);
        DataSet getsupplierInfo(string sql, string sqlx);
        int Delete(string st);
    }
}
