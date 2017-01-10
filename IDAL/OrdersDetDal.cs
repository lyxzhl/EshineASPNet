using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace IDAL
{
   public interface OrdersDetDal
    {
       int Add(Model.tab_orderDets m_orderDet);
       
    }
}
