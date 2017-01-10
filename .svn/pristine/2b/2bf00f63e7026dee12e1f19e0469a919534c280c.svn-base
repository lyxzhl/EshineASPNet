using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace DALFactory
{
    public class OrdersDet_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.OrdersDetDal Createusers()
        {
            string classname = path + ".sql_OrdersDet";
            return (IDAL.OrdersDetDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
