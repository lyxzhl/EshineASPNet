using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace DALFactory
{
    public class RolesFactory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.RolesDal Createusers()
        {
            string classname = path + ".sql_roles";
            return (IDAL.RolesDal)Assembly.Load(path).CreateInstance(classname);
        }
    }
}
