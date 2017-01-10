using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DALFactory
{
    public class supplier_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.supplierDal Createusers()
        {
            string classname = path + ".sql_supplier";
            return (IDAL.supplierDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
