using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Bll
{
    
        public class DictionaryBll
        {
            IDAL.DictionaryDal itu = DALFactory.Dictionary_Factory.Createusers();
            public int Add(Model.Dictionary Dictionary)
            {
                return itu.Add(Dictionary);
            }
            public Model.Dictionary getDictionary(Model.Dictionary Dictionary1)
            {
                return itu.getDictionary(Dictionary1);
            }
            public int update(Model.Dictionary Dictionary)
            {
                return itu.update(Dictionary);
            }
            public int Delete(int dicID)
            {
                return itu.Delete(dicID);
            }
            public DataTable Select(string ss)
            {
                return itu.Select(ss);
            }
        }

    
}
