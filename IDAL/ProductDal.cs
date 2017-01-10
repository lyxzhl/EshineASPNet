using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL
{
   public interface ProductDal
    {
        int Add(Model.tab_products tab);
        int Update(string sq);
        int Delete(int ID);
        Model.tab_products getproducts(Model.tab_products products1);
        int update(Model.tab_products products);

       DataTable GetTable(string sq);
    }
}
