using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DALFactory
{
    public class shoporder_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.shoporderDal Createusers()
        {
            string classname = path + ".sql_shoporder";
            return (IDAL.shoporderDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
