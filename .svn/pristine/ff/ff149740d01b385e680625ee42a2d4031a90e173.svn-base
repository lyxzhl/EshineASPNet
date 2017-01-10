using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;


namespace DALFactory
{
   public class Orders_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.OrdersDal Createusers()
        {
            string classname = path + ".sql_Orders";
            return (IDAL.OrdersDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
