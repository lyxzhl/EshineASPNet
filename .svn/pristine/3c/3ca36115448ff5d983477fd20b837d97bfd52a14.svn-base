using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL
{
    public interface newsDal
    {
        int NewsAdd(Model.tab_news news);
        string getfirst(string discription, string item);
        string getfirsttitle(string discription);
        DataTable NewsSelect(Model.tab_news cus);
        string getNews(string discription, string title);
        string getNews(string discription, string title, string language);
        Model.tab_news getNews(Model.tab_news cus);
        DataTable NewsSelectAll();
        int Delete(int id);
        int Delete(string discription, string title);
        int update(Model.tab_news cus);
        DataTable NewsSelect(string ss);
        DataTable NewsSelect(int id);
        bool hasnews(string discription);
    }
}
