using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace DALFactory
{
    /// <summary>
    /// 反射出产品表
    /// </summary>
    public static class Produt_Factory
    {
        private static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.ProductDal Createusers()
        {
            string className = path + ".sql_products";
            return (IDAL.ProductDal)Assembly.Load(path).CreateInstance(className);
        }
    }
}
