using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DALFactory
{
     public class Dictionary_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.DictionaryDal Createusers()
        {
            string classname = path + ".sql_Dictionary";
            return (IDAL.DictionaryDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
