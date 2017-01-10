using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    
    public class tab_customers
    {

        //#define baddate = DateTime.Parse("1900-01-01");  C#里面没有define只能用const
        //private const DateTime baddate = DateTime.Parse("1900-01-01");  Datetime不能作为常量
        private int _customerID = 0;
        private string _customerCode = "";
        private string _customerName = "";
        private string _customerEmail = "";
        private string _customerPrivateEmail = "";
        private string _customerMobile = "";
        private string _customerTel = "";
        private string _customerProvince = "";
        private string _customerCity = "";
        private string _customerZone = "";
        private string _customerAddress = "";
        private string _customerAllAddr = "";
        private string _customerDefaultAddr = "";
        private string _customerGender = "";
        private string _customerMarriageStatus = "";
        private DateTime _customerDOB = DateTime.Parse("1900-01-01"); //date
        private string _customerNation = "";
        private string _customerIDcard = "";
        private string _customerCompany = "";
        private string _customerCompanycode = "";
        private string _customerClass = "";
        private string _customerCompanyTel = "";
        private string _customerCompanyProvince = "";
        private string _customerCompanyCity = "";
        private string _customerCompanyAddress = "";
        private string _customerCompanyZone = "";
        private string _customerCompanyBU = "";
        private string _customerVIP = "";
        private double _customerBalance = 0.0;
        private string _customerPwd = "";
        private DateTime _customerLastLogin = DateTime.Parse("1900-01-01");
        private DateTime _customerLastPWChanged = DateTime.Parse("1900-01-01"); //date
        private string _customerOldPW1 = "";
        private string _customerOldPW2 = "";
        private string _customerOldPW3 = "";
        private string _customerValidateCode = "";
        private string _customerMsg = "";
        private string _customerSafeQ1 = "";
        private string _customerSafeQ2 = "";
        private string _customerSafeQ3 = "";
        private string _customerSafeA1 = "";
        private string _customerSafeA2 = "";
        private string _customerSafeA3 = "";
        private string _disablebranch = "";
        private string _packagecode = "";
        private double _customerBudget = 0.0;
        private string _customerorderstatus = "";


        public int customerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        public string customerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        public string customerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public string customerEmail
        {
            get { return _customerEmail; }
            set { _customerEmail = value; }
        }

        public string customerPrivateEmail
        {
            get { return _customerPrivateEmail; }
            set { _customerPrivateEmail = value; }
        }

        public string customerMobile
        {
            get { return _customerMobile; }
            set { _customerMobile = value; }
        }

        public string customerTel
        {
            get { return _customerTel; }
            set { _customerTel = value; }
        }

        public string customerProvince
        {
            get { return _customerProvince; }
            set { _customerProvince = value; }
        }

        public string customerCity
        {
            get { return _customerCity; }
            set { _customerCity = value; }
        }

        public string customerZone
        {
            get { return _customerZone; }
            set { _customerZone = value; }
        }

        public string customerAddress
        {
            get { return _customerAddress; }
            set { _customerAddress = value; }
        }

        public string customerAllAddr
        {
            get { return _customerAllAddr; }
            set { _customerAllAddr = value; }
        }

        public string customerDefaultAddr
        {
            get { return _customerDefaultAddr; }
            set { _customerDefaultAddr = value; }
        }

        public string customerGender
        {
            get { return _customerGender; }
            set { _customerGender = value; }
        }

        public string customerMarriageStatus
        {
            get { return _customerMarriageStatus; }
            set { _customerMarriageStatus = value; }
        }

        public DateTime customerDOB
        {
            get { return _customerDOB; }
            set { _customerDOB = value; }
        }

        public string customerNation
        {
            get { return _customerNation; }
            set { _customerNation = value; }
        }

        public string customerIDcard
        {
            get { return _customerIDcard; }
            set { _customerIDcard = value; }
        }

        public string customerCompany
        {
            get { return _customerCompany; }
            set { _customerCompany = value; }
        }

        public string customerCompanycode
        {
            get { return _customerCompanycode; }
            set { _customerCompanycode = value; }
        }

        public string customerClass
        {
            get { return _customerClass; }
            set { _customerClass = value; }
        }

        public string customerCompanyTel
        {
            get { return _customerCompanyTel; }
            set { _customerCompanyTel = value; }
        }

        public string customerCompanyProvince
        {
            get { return _customerCompanyProvince; }
            set { _customerCompanyProvince = value; }
        }

        public string customerCompanyCity
        {
            get { return _customerCompanyCity; }
            set { _customerCompanyCity = value; }
        }

        public string customerCompanyAddress
        {
            get { return _customerCompanyAddress; }
            set { _customerCompanyAddress = value; }
        }

        public string customerCompanyZone
        {
            get { return _customerCompanyZone; }
            set { _customerCompanyZone = value; }
        }

        public string customerCompanyBU
        {
            get { return _customerCompanyBU; }
            set { _customerCompanyBU = value; }
        }

        public string customerVIP
        {
            get { return _customerVIP; }
            set { _customerVIP = value; }
        }

        public double customerBalance
        {
            get { return _customerBalance; }
            set { _customerBalance = value; }
        }

        public string customerPwd
        {
            get { return _customerPwd; }
            set { _customerPwd = value; }
        }

        public DateTime customerLastLogin
        {
            get { return _customerLastLogin; }
            set { _customerLastLogin = value; }
        }

        public DateTime customerLastPWChanged
        {
            get { return _customerLastPWChanged; }
            set { _customerLastPWChanged = value; }
        }

        public string customerOldPW1
        {
            get { return _customerOldPW1; }
            set { _customerOldPW1 = value; }
        }

        public string customerOldPW2
        {
            get { return _customerOldPW2; }
            set { _customerOldPW2 = value; }
        }

        public string customerOldPW3
        {
            get { return _customerOldPW3; }
            set { _customerOldPW3 = value; }
        }

        public string customerValidateCode
        {
            get { return _customerValidateCode; }
            set { _customerValidateCode = value; }
        }

        public string customerMsg
        {
            get { return _customerMsg; }
            set { _customerMsg = value; }
        }

        public string customerSafeQ1
        {
            get { return _customerSafeQ1; }
            set { _customerSafeQ1 = value; }
        }

        public string customerSafeQ2
        {
            get { return _customerSafeQ2; }
            set { _customerSafeQ2 = value; }
        }

        public string customerSafeQ3
        {
            get { return _customerSafeQ3; }
            set { _customerSafeQ3 = value; }
        }

        public string customerSafeA1
        {
            get { return _customerSafeA1; }
            set { _customerSafeA1 = value; }
        }

        public string customerSafeA2
        {
            get { return _customerSafeA2; }
            set { _customerSafeA2 = value; }
        }

        public string customerSafeA3
        {
            get { return _customerSafeA3; }
            set { _customerSafeA3 = value; }
        }

        public string disablebranch
        {
            get { return _disablebranch; }
            set { _disablebranch = value; }
        }

        public string packagecode
        {
            get { return _packagecode; }
            set { _packagecode = value; }
        }
        public double customerBudget
        {
            get { return _customerBudget; }
            set { _customerBudget = value; }
        }
        public string customerorderstatus
        {
            get { return _customerorderstatus; }
            set { _customerorderstatus = value; }
        }


    }
}
