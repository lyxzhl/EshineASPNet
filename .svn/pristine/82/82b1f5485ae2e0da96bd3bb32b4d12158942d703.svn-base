using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;
namespace DALFactory
{
    public class emp_Factory
    {
       static readonly string path=System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.empDal Createusers()
        {
            string classname = path + ".sql_emp";
            return (IDAL.empDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
