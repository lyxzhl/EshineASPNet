using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DALFactory
{
    public class relative_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.relativeDal Createusers()
        {
            string classname = path + ".sql_relative";
            return (IDAL.relativeDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
