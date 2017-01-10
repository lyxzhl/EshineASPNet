using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bll
{
    public class newsBll
    {

        IDAL.newsDal itu = DALFactory.news_Factory.Createusers();
        /// <summary>
        /// 客户表的添加
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public int NewsAdd(Model.tab_news news)
        {
            return itu.NewsAdd(news);
        }
        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //public static bool Register(Model.tab_news news)
        //{
        //    if (LoginIdExists(user.LoginId))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        itu.NewsAdd(news);
        //        return true;
        //    }
        //}

        public string getfirst(string discription, string item)
        {
            return itu.getfirst(discription,item);
        }

        /// <summary>
        /// 根据条件客户表的查寻
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public DataTable NewsSelect(Model.tab_news cus)
        {
            return itu.NewsSelect(cus);
        }
        public string getNews(string discription, string title)
        {
            return itu.getNews(discription, title);
        }
        public string getNews(string discription, string title, string language)
        {
            return itu.getNews(discription, title, language);
        }
        public Model.tab_news getNews(Model.tab_news cus)
        {
            return itu.getNews(cus);
        }
        /// <summary>
        /// 客户表的查寻
        /// </summary>
        /// <returns></returns>
        public DataTable NewsSelectAll()
        {
            return itu.NewsSelectAll();
        }
        /// <summary>
        /// 客户表的删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            return itu.Delete(id);
        }
        public int Delete(string discription, string title)
        {
            return itu.Delete(discription, title);
        }
        /// <summary>
        /// 客户表的修改
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public int update(Model.tab_news cus)
        {
            return itu.update(cus);
        }
        public DataTable NewsSelect(string ss)
        {
            return itu.NewsSelect(ss);
        }
        public string getfirsttitle(string discription)
        {
            return itu.getfirsttitle(discription);
        }
        public DataTable NewsSelect(int id)
        {
            return itu.NewsSelect(id);
        }
        public bool hasnews(string discription)
        {
            return itu.hasnews(discription);
        }
    }
}
