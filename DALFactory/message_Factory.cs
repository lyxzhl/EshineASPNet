using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DALFactory
{
    public class message_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.messageDal Createusers()
        {
            string classname = path + ".sql_message";
            return (IDAL.messageDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
