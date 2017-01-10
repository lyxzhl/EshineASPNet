using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DALFactory;

namespace Bll
{
    public class ProductBll
    {
        IDAL.ProductDal itu = DALFactory.Produt_Factory.Createusers();
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        /// <summary>
        ///向产品表添加信息
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public int AddPro(Model.tab_products pro)
        {
            return itu.Add(pro);
        }
        /// <summary>
        /// 根据ID删除产品表的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelPro(int id)
        {
            return itu.Delete(id);
        }
        /// <summary>
        /// 根据SQL语句查询产品数据
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public DataTable SelectPro(string sq)
        {
            return itu.GetTable(sq);
        }
        /// <summary>
        /// 根据SQL语句修改产品数据
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public int UpdatePro(string sq)
        {
            return itu.Update(sq);
        }
        public Model.tab_products getproducts(Model.tab_products products1)
        {
            return itu.getproducts(products1);
        }
        public int update(Model.tab_products products)
        {
            return itu.update(products);
        }
        public int getidfromname(string name)
        {
            return Convert.ToInt32(sql.ExecuteSc("select  productID from tab_products where productName='" + name+"'"));
       
        }
        public string getname(string productID)
        {
            object obj;
            obj = sql.ExecuteSc("select  productName from tab_products where productID='" + productID + "'");
            if(obj!=null)
            {
                return obj.ToString();
            }
            else
            {
                return "此商品被删除";
            }
            

        }
        public string getname_eng(string productID)
        {
            object obj;
            obj = sql.ExecuteSc("select  productName_eng from tab_products where productID='" + productID + "'");
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "此商品被删除";
            }


        }
        public string getcategory(string productID)
        {
            int num=Convert.ToInt32(sql.ExecuteSc("select count(*) from  tab_products where productName=( select  productName from tab_products where productID='" + productID + "')"));
            if(num>1)
            {
                return " "+sql.ExecuteSc("select  ex1ID from tab_products where productID='" + productID + "'").ToString();
            }
            else 
            {
                return "";
            }


        }
        public string getstring(string productID,string ziduan)
        {
            return sql.ExecuteSc("select  " + ziduan + " from tab_products where productID='" + productID + "'").ToString();

        }

    }
}
