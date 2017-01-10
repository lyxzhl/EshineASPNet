using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DALFactory
{
    public class shopsupplier_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.shopsupplierDal Createusers()
        {
            string classname = path + ".sql_shopsupplier";
            return (IDAL.shopsupplierDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
