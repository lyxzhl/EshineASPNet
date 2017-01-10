using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bll
{
    public class parasBll
    {
        IDAL.parasDal itu = DALFactory.paras_Factory.Createusers();
        public int Add(Model.tab_paras paras)
        {
            return itu.Add(paras);
        }
        public Model.tab_paras getparas(Model.tab_paras paras1)
        {
            return itu.getparas(paras1);
        }
        public int update(Model.tab_paras paras)
        {
            return itu.update(paras);
        }
        public int Delete(int id)
        {
            return itu.Delete(id);
        }
        public DataTable Select(string ss)
        {
            return itu.Select(ss);
        }

        public string getvalue(string pname)
        {
            return itu.getvalue(pname);
        }

        public int execmd(string s)
        {
            return itu.execmd(s);
        }
    }

}
