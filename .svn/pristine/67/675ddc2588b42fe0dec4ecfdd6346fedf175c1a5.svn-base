using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;
namespace DALFactory
{
    /// <summary>
    /// 反射出权限表
    /// </summary>
    public class Powers_Factory
    {
        static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.PowersDal Createusers()
        {
            string classname = path + ".sql_powers";
            return (IDAL.PowersDal)Assembly.Load(path).CreateInstance(classname);

        }

    }
}
