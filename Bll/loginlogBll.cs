using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bll
{
    public class loginlogBll
    {
        IDAL.loginlogDal itu = DALFactory.loginlog_Facotry.Createusers();
        public int Add(Model.tab_loginlog loginlog)
        {
            return itu.Add(loginlog);
        }
        public Model.tab_loginlog getloginlog(Model.tab_loginlog loginlog1)
        {
            return itu.getloginlog(loginlog1);
        }
        public int update(Model.tab_loginlog loginlog)
        {
            return itu.update(loginlog);
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
