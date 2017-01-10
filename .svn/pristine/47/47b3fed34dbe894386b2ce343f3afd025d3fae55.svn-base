using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Bll
{
    public class shoporderBll
    {
        IDAL.shoporderDal itu = DALFactory.shoporder_Factory.Createusers();

        public int Add(Model.tab_shoporder shoporder)
        {
            return itu.Add(shoporder);
        }
        public Model.tab_shoporder getshoporder(Model.tab_shoporder shoporder1)
        {
            return itu.getshoporder(shoporder1);
        }
        public int update(Model.tab_shoporder shoporder)
        {
            return itu.update(shoporder);
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
