using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace IDAL
{
    public interface  messageDal
    {
        int Add(Model.tab_message message);
        Model.tab_message getmessage(Model.tab_message message1);
        int update(Model.tab_message message);
        int Delete(int Messageid);
        DataTable Select(string ss);
        int systemMsg(int Receiver, string Title, string Msg);
        int getmsgnum(int id, string additionalwhere);
        int getunread(int id);
        int markasread(string Messageid);
        string getmessage(int id);
        void sendmsg(int newsid, Model.tab_customers modelCu);
    }
}
