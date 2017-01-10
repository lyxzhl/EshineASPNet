using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class tab_relatives
    {
        private string _relativeName = "";
        private string _relativeEmail = "";
        private string _relativeMobile = "";
        private string _relativeProvince = "";
        private string _relativeCity = "";
        private string _relativeAddress = "";
        private string _relativeGender = "";
        private string _relativeMarriageStatus = "";
        private DateTime _relativeDOB= DateTime.Parse("1900-01-01"); //date
        private string _relativeNation = "";
        private string _relativeIDcard = "";
        private int _relativeCustomer = 0;
        private string _relativeRelationship = "";
        private int _relativeID = 0;


        public string relativeName
        {
            get { return _relativeName; }
            set { _relativeName = value; }
        }

        public string relativeEmail
        {
            get { return _relativeEmail; }
            set { _relativeEmail = value; }
        }

        public string relativeMobile
        {
            get { return _relativeMobile; }
            set { _relativeMobile = value; }
        }

        public string relativeProvince
        {
            get { return _relativeProvince; }
            set { _relativeProvince = value; }
        }

        public string relativeCity
        {
            get { return _relativeCity; }
            set { _relativeCity = value; }
        }

        public string relativeAddress
        {
            get { return _relativeAddress; }
            set { _relativeAddress = value; }
        }

        public string relativeGender
        {
            get { return _relativeGender; }
            set { _relativeGender = value; }
        }

        public string relativeMarriageStatus
        {
            get { return _relativeMarriageStatus; }
            set { _relativeMarriageStatus = value; }
        }

        public DateTime relativeDOB
        {
            get { return _relativeDOB; }
            set { _relativeDOB = value; }
        }

        public string relativeNation
        {
            get { return _relativeNation; }
            set { _relativeNation = value; }
        }

        public string relativeIDcard
        {
            get { return _relativeIDcard; }
            set { _relativeIDcard = value; }
        }

        public int relativeCustomer
        {
            get { return _relativeCustomer; }
            set { _relativeCustomer = value; }
        }

        public string relativeRelationship
        {
            get { return _relativeRelationship; }
            set { _relativeRelationship = value; }
        }

        public int relativeID
        {
            get { return _relativeID; }
            set { _relativeID = value; }
        }


    }
}
