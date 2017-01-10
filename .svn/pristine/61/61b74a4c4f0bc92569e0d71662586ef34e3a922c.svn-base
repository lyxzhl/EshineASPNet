using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DALFactory
{
    public class news_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.newsDal Createusers()
        {
            string classname = path + ".sql_news";
            return (IDAL.newsDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
