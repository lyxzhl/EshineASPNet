using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace DALFactory
{
    public class V_ProClass_Factory
    {
        
            static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
            public static IDAL.v_ProClassDal Createusers()
            {
                string classname = path + ".sql_v_ProClass";
                return (IDAL.v_ProClassDal)Assembly.Load(path).CreateInstance(classname);
            }
        
    }
}
