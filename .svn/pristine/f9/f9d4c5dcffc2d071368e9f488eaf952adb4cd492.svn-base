using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace DALFactory
{
    public class deliveryaddress_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.deliveryaddressDal Createusers()
        {
            string classname = path + ".sql_deliveryaddress";
            return (IDAL.deliveryaddressDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
