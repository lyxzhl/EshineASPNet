using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace IDAL
{
   public interface ProdutClassDal
    {
        DataTable getAll(string sq);
        int Add(Model.tab_product_class proClass);
        int Delete(int productClassID);
        object GetItem(string sq);
       int Update(string sq);
    }
}
