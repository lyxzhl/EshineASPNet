using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace DALFactory
{
    /// <summary>
    /// 反射出产品类别表
    /// </summary>
   public static class ProductClass_Factory
    {
        private static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        public static IDAL.ProdutClassDal Createusers()
        {
            string className = path + ".sql_product_class";
            return (IDAL.ProdutClassDal)Assembly.Load(path).CreateInstance(className);
        }
    }
}
