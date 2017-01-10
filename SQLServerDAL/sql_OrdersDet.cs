using System;
using System.Collections.Generic;
using System.Text;

namespace SQLServerDAL
{
   public class sql_OrdersDet:IDAL.OrdersDetDal
   {
       DBunit.SQLAccess sql = new DBunit.SQLAccess();
       public int Add(Model.tab_orderDets m_orderDet)
       {
           StringBuilder strsql = new StringBuilder();
           strsql.Append("insert into tab_orderDets(productID,proCount,orderID,productUnitPrice) values (");
           strsql.AppendFormat("'{0}',", m_orderDet.productID);
           strsql.AppendFormat("'{0}',", m_orderDet.proCount);
           strsql.AppendFormat("'{0}',", m_orderDet.orderID);
           strsql.AppendFormat("{0})", m_orderDet.productUnitPrice);
           return sql.ExecuteNonQuery(strsql.ToString());
       }
    }
}
