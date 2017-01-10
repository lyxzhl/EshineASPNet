using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SQLServerDAL
{
    class sql_news : IDAL.newsDal
    {
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        #region newsDal 成员
        /// <summary>
        /// 客户表的添加
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        DateTime baddate = DateTime.Parse("1900-01-01");
        public int NewsAdd(Model.tab_news news)
        {
            //DateTime baddate = DateTime.Parse("1900-01-01");
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_news values (");
            strsql.AppendFormat("N'{0}',", news.discription);
            strsql.AppendFormat("N'{0}',", news.title);
            strsql.AppendFormat("'{0}',", news.title_eng);
            strsql.AppendFormat("N'{0}',", news.msg);
            strsql.AppendFormat("'{0}',", news.msg_eng);
            strsql.AppendFormat("N'{0}',", news.img);
            strsql.AppendFormat("N'{0}',", news.note);
            strsql.AppendFormat("N'{0}',", news.link);
            strsql.AppendFormat("N'{0}',", news.link_eng);
            strsql.AppendFormat("{0}", news.time == baddate ? "null" : "'" + news.time.ToString() + "'");
            strsql.Append(")");
            return sql.ExecuteNonQuery(strsql.ToString());

        }
        public string getfirst(string discription, string item)
        {
            object x = sql.ExecuteSc("select top 1 "+item+" from tab_news where discription=N'" + discription+"'");
            return Convert.ToString(x);
        }
        public string getfirsttitle(string discription)
        {
            object x = sql.ExecuteSc("select top 1 title from tab_news where discription=N'" + discription + "'");
            return Convert.ToString(x);
        }
        /// <summary>
        /// 客户表的查找
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public System.Data.DataTable NewsSelect(Model.tab_news cus)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_news where ");
            strsql.AppendFormat("id='{0}'", cus.id);
            return sql.ExecuteDataSet(strsql.ToString()).Tables[0];
        }
        public System.Data.DataTable NewsSelect(int id)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_news where ");
            strsql.AppendFormat("id='{0}'", id);
            return sql.ExecuteDataSet(strsql.ToString()).Tables[0];
        }
        public DataTable NewsSelect(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }
        public string getNews(string discription, string title)
        {
            object x = sql.ExecuteSc("select top 1 msg from tab_news where discription=N'" + discription + "' and title=N'"+title+"'");
            return Convert.ToString(x);
        }

        public string getNews(string discription, string title, string language)
        {
            string s ;
            if (language == "en-us")
            {
                s = "select top 1 msg_eng from tab_news where discription=N'" + discription + "' and title=N'" + title + "'";
            }
            else
            {
                s = "select top 1 msg from tab_news where discription=N'" + discription + "' and title=N'" + title + "'";
            }
            object x = sql.ExecuteSc(s);
            return Convert.ToString(x);
        }

        /// <summary>
        /// 返回客户
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public Model.tab_news getNews(Model.tab_news cus)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_news where ");
            strsql.AppendFormat("id='{0}'", cus.id);
            strsql.AppendFormat(" or (title_eng<>'' and title_eng='{0}')", cus.title_eng);
            strsql.AppendFormat(" or (title<>'' and title=N'{0}')", cus.title);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];

            if (dt.Rows.Count < 1) return null;

            Model.tab_news news = new Model.tab_news();
            news.id = int.Parse(dt.Rows[0]["id"].ToString());
            news.discription = dt.Rows[0]["discription"].ToString();
            news.title = dt.Rows[0]["title"].ToString();
            news.title_eng = dt.Rows[0]["title_eng"].ToString();
            news.msg = dt.Rows[0]["msg"].ToString();
            news.msg_eng = dt.Rows[0]["msg_eng"].ToString();
            news.img = dt.Rows[0]["img"].ToString();
            news.note = dt.Rows[0]["note"].ToString();
            news.link = dt.Rows[0]["link"].ToString();
            news.link_eng = dt.Rows[0]["link_eng"].ToString();
            news.time = dt.Rows[0]["time"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["time"].ToString());
            return news;
        }
        /// <summary>
        /// 查找所有客户的信息
        /// </summary>
        /// <returns></returns>

        public System.Data.DataTable NewsSelectAll()
        {
            return sql.ExecuteDataSet("select * from tab_news").Tables[0];
        }
        /// <summary>
        /// 删除客户的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            return sql.ExecuteNonQuery("delete from tab_news where id=" + id);
        }
        public int Delete(string discription, string title)
        {
            return sql.ExecuteNonQuery("delete from tab_news where discription=N'" + discription + "' and title=N'" + title + "'");
        }
        /// <summary>
        /// 修改客户的信息
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>

        public int update(Model.tab_news news)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_news set ");
            strsql.AppendFormat(" discription =N'{0}',", news.discription);
            strsql.AppendFormat(" title =N'{0}',", news.title);
            strsql.AppendFormat(" title_eng ='{0}',", news.title_eng);
            strsql.AppendFormat(" msg =N'{0}',", news.msg);
            strsql.AppendFormat(" msg_eng ='{0}',", news.msg_eng);
            strsql.AppendFormat(" img =N'{0}',", news.img);
            strsql.AppendFormat(" note =N'{0}',", news.note);
            strsql.AppendFormat(" link =N'{0}',", news.link);
            strsql.AppendFormat(" link_eng =N'{0}',", news.link_eng);
            strsql.AppendFormat(" time ={0}", news.time == baddate ? "null" : "'" + news.time.ToString() + "'");
            strsql.AppendFormat(" where id={0}", news.id);
            return sql.ExecuteNonQuery(strsql.ToString());

        }
        
        public bool hasnews(string discription)
        {
            if (Convert.ToInt32(sql.ExecuteSc("select count(title) from tab_news where discription=N'" + discription + "'")) > 0)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
