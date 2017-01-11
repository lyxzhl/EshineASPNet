using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace IDAL
{
    public interface OrdersDal
    {
        int getMax();
        DataTable GetAll();
        DataTable GetAny(string sql);
        DataTable Select(string ss);
        int Add(Model.tab_orders tab_orders);
        Model.tab_orders gettab_orders(int id);
        Model.tab_orders gettab_orders(DataTable dt);
        int update(Model.tab_orders tab_orders);

        int updatereportpath(int orderID, string path);
        DataSet getOrderInfo(string sql, string sqlx);
        int Delete(int st);
        int Delete(string st);
        int getordernum(int id);
        bool hasarrangement(int id);
        bool hasRelarrangement(int id);
        bool has2Relarrangement(int id);
        bool hasSpecRelarrangement(int id);
    }
       
}
