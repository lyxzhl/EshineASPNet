using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Bll
{
    public class eticketBll
    {
        IDAL.eticketDal itu = DALFactory.eticket_Factory.Createusers();
        public int Add(Model.tab_eticket eticket)
        {
            return itu.Add(eticket);
        }
        public Model.tab_eticket geteticket(Model.tab_eticket eticket1)
        {
            return itu.geteticket(eticket1);
        }
        public int update(Model.tab_eticket eticket)
        {
            return itu.update(eticket);
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
