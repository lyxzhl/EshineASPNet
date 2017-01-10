using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Bll
{
    public class deliveryaddressBll
    {
        IDAL.deliveryaddressDal itu = DALFactory.deliveryaddress_Factory.Createusers();
        public int Add(Model.deliveryaddress deliveryaddress)
        {
            return itu.Add(deliveryaddress);
        }
        public Model.deliveryaddress getdeliveryaddress(Model.deliveryaddress deliveryaddress1)
        {
            return itu.getdeliveryaddress(deliveryaddress1);
        }
        public int update(Model.deliveryaddress deliveryaddress)
        {
            return itu.update(deliveryaddress);
        }
        public int Delete(int id)
        {
            return itu.Delete(id);
        }
        public DataTable Select(string ss)
        {
            return itu.Select(ss);
        }
    }

}
