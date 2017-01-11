using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Bll
{
    public class OrdersBll
    {
        IDAL.OrdersDal itu = DALFactory.Orders_Factory.Createusers();
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <returns></returns>
        public int getMax()
        {
            return itu.getMax();
        }
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            return itu.GetAll();
        }
        /// <summary>
        /// 获取指定信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetAny(string sql)
        {
            return itu.GetAny(sql);
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="m_order"></param>
        /// <returns></returns>
        public int Add(Model.tab_orders m_order)
        {
            return itu.Add(m_order);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string Update(Model.tab_orders m_order)
        {
            return itu.update(m_order).ToString();
        }
        /// <summary>
        /// 父子表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlx"></param>
        /// <returns></returns>
        public DataSet getOrderInfo(string sql, string sqlx)
        {
            return itu.getOrderInfo(sql, sqlx);
        }
        public Model.tab_orders getorders(Model.tab_orders orders1)
        {
            return itu.gettab_orders(orders1.orderID);
        }
        public int Delete(int orderID)
        {
            return itu.Delete(orderID);
        }
        public int Delete(string st)
        {
            return itu.Delete(st);
        }
        public int getordernum(int id)
        {
            return itu.getordernum(id);
        }
        public int updatereportpath(int orderID, string path)
        {
            return itu.updatereportpath(orderID, path);
        }
        public DataTable Select(string ss)
        {
            return itu.Select(ss);
        }
        public bool hasarrangement(int id)
        {
            return itu.hasarrangement(id);
        }
        public bool hasRelarrangement(int id)
        {
            return itu.hasRelarrangement(id);
        }
        public bool has2Relarrangement(int id)
        {
            return itu.has2Relarrangement(id);
        }

        public bool hasSpecRelarrangement(int id)
        {
            return itu.hasSpecRelarrangement(id);
        }

        public bool hasshoporder(int id)
        {
            if (Convert.ToInt32(sql.ExecuteSc("select count(orderID) from tab_orders where ReportType=N'商城' and customerName<>N'' and customerID=" + id)) >= 1)
            {
                return true;
            }
            else
                return false;
        }
        public int getshopordernum(int id)
        {
            return Convert.ToInt32(sql.ExecuteSc("select count(orderID) from tab_orders where ReportType=N'商城' and orderStatus='待付款' and customerName<>N'' and customerID=" + id));
        }

        public string getstring(string orderID, string ziduan)
        {
            return sql.ExecuteSc("select  " + ziduan + " from tab_orders where orderID='" + orderID + "'").ToString();

        }
    }
}
