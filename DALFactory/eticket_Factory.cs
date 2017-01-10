using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace DALFactory
{
    public class eticket_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.eticketDal Createusers()
        {
            string classname = path + ".sql_eticket";
            return (IDAL.eticketDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
