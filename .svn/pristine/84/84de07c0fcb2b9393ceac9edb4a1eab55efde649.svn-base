using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DALFactory
{
    public class company_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.companyDal Createusers()
        {
            string classname = path + ".sql_company";
            return (IDAL.companyDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
