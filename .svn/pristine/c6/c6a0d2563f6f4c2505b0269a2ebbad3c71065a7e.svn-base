using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DALFactory
{
  public  class customer_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.customerDal Createusers()
        {
            string classname = path + ".sql_customer";
            return (IDAL.customerDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
