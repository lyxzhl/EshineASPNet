using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
     public class Dictionary
    {
        private int _dicID = 0;
        private string _dicType = "";
        private string _dicValue = "";
        private string _dicEName = "";
        private string _dicCName = "";
        private int _ParentID = 0;
        private string _dicRemark = "";
        private DateTime _CreateTime = DateTime.Parse("1900-01-01");
        private DateTime _UpdateTime = DateTime.Parse("1900-01-01");
        private int _CreateUser = 0;
        private int _UpdateUser = 0;
        private int _IsShow = 0;
        private int _IsDel = 0;


        public int dicID
        {
            get { return _dicID; }
            set { _dicID = value; }
        }

        public string dicType
        {
            get { return _dicType; }
            set { _dicType = value; }
        }

        public string dicValue
        {
            get { return _dicValue; }
            set { _dicValue = value; }
        }

        public string dicEName
        {
            get { return _dicEName; }
            set { _dicEName = value; }
        }

        public string dicCName
        {
            get { return _dicCName; }
            set { _dicCName = value; }
        }

        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

        public string dicRemark
        {
            get { return _dicRemark; }
            set { _dicRemark = value; }
        }

        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        public DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { _UpdateTime = value; }
        }

        public int CreateUser
        {
            get { return _CreateUser; }
            set { _CreateUser = value; }
        }

        public int UpdateUser
        {
            get { return _UpdateUser; }
            set { _UpdateUser = value; }
        }

        public int IsShow
        {
            get { return _IsShow; }
            set { _IsShow = value; }
        }

        public int IsDel
        {
            get { return _IsDel; }
            set { _IsDel = value; }
        }


    }
}
