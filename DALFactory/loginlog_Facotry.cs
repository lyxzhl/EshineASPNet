using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DALFactory
{
    public class loginlog_Facotry
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.loginlogDal Createusers()
        {
            string classname = path + ".sql_loginlog";
            return (IDAL.loginlogDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
