using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class tab_news
    {
        private int _id = 0;
        private string _discription = "";
        private string _title = "";
        private string _title_eng = "";
        private string _msg = "";
        private string _msg_eng = "";
        private string _img = "";
        private string _note = "";
        private string _link = "";
        private string _link_eng = "";
        private DateTime _time = DateTime.Parse("1900-01-01");


        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string discription
        {
            get { return _discription; }
            set { _discription = value; }
        }

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string title_eng
        {
            get { return _title_eng; }
            set { _title_eng = value; }
        }

        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        public string msg_eng
        {
            get { return _msg_eng; }
            set { _msg_eng = value; }
        }

        public string img
        {
            get { return _img; }
            set { _img = value; }
        }

        public string note
        {
            get { return _note; }
            set { _note = value; }
        }

        public string link
        {
            get { return _link; }
            set { _link = value; }
        }

        public string link_eng
        {
            get { return _link_eng; }
            set { _link_eng = value; }
        }

        public DateTime time
        {
            get { return _time; }
            set { _time = value; }
        }



    }
}
