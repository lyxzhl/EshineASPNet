using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DALFactory
{
    public class paras_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.parasDal Createusers()
        {
            string classname = path + ".sql_paras";
            return (IDAL.parasDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
