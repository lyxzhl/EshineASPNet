using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 订单表信息
    /// </summary>
    public class tab_orders
    {
        private int _orderID = 0;
        private string _supplierOrderID = "";
        private string _cardNumber = "";
        private int _customerID = 0;
        private string _customerCode = "";
        private string _customerName = "";
        private int _relativeID = 0;
        private string _relativeName = "";
        private DateTime _orderDate = DateTime.Parse("1900-01-01");
        private string _orderStatus = "";
        private string _personSex = "";
        private int _personAge = 0;
        private string _personIDcard = "";
        private string _personMobile = "";
        private string _personPrivateEmail = "";
        private string _personCompany = "";
        private string _personCompanycode = "";
        private string _personMarriageStatus = "";
        private string _personAddress = "";
        private DateTime _examDate = DateTime.Parse("1900-01-01");
        private string _examCity = "";
        private string _examSupplier = "";
        private string _examBranch = "";
        private string _examhosip = "";
        private string _examPackage = "";
        private string _examUpPkg = "";
        private double _examTotalFee = 0.0;
        private double _examBill = 0.0;
        private string _examInfo = "";
        private string _examWorkNo = "";
        private string _Msg = "";
        private string _Report = "";
        private string _ReportContent = "";
        private string _ReportType = "";
        private string _ReportUploader = "";
        private DateTime _ReportUploadDate = DateTime.Parse("1900-01-01");
        private string _ReportNote = "";
        private string _payMethod = "";
        private string _payRefNum = "";
        private DateTime _payTime = DateTime.Parse("1900-01-01");
        private string _payNote = "";
        private string _ordernote = "";


        public int orderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        public string supplierOrderID
        {
            get { return _supplierOrderID; }
            set { _supplierOrderID = value; }
        }

        public string cardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

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

        public int relativeID
        {
            get { return _relativeID; }
            set { _relativeID = value; }
        }

        public string relativeName
        {
            get { return _relativeName; }
            set { _relativeName = value; }
        }

        public DateTime orderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        public string orderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; }
        }

        public string personSex
        {
            get { return _personSex; }
            set { _personSex = value; }
        }

        public int personAge
        {
            get { return _personAge; }
            set { _personAge = value; }
        }

        public string personIDcard
        {
            get { return _personIDcard; }
            set { _personIDcard = value; }
        }

        public string personMobile
        {
            get { return _personMobile; }
            set { _personMobile = value; }
        }

        public string personPrivateEmail
        {
            get { return _personPrivateEmail; }
            set { _personPrivateEmail = value; }
        }

        public string personCompany
        {
            get { return _personCompany; }
            set { _personCompany = value; }
        }

        public string personCompanycode
        {
            get { return _personCompanycode; }
            set { _personCompanycode = value; }
        }

        public string personMarriageStatus
        {
            get { return _personMarriageStatus; }
            set { _personMarriageStatus = value; }
        }

        public string personAddress
        {
            get { return _personAddress; }
            set { _personAddress = value; }
        }

        public DateTime examDate
        {
            get { return _examDate; }
            set { _examDate = value; }
        }

        public string examCity
        {
            get { return _examCity; }
            set { _examCity = value; }
        }

        public string examSupplier
        {
            get { return _examSupplier; }
            set { _examSupplier = value; }
        }

        public string examBranch
        {
            get { return _examBranch; }
            set { _examBranch = value; }
        }

        public string examhosip
        {
            get { return _examhosip; }
            set { _examhosip = value; }
        }

        public string examPackage
        {
            get { return _examPackage; }
            set { _examPackage = value; }
        }

        public string examUpPkg
        {
            get { return _examUpPkg; }
            set { _examUpPkg = value; }
        }

        public double examTotalFee
        {
            get { return _examTotalFee; }
            set { _examTotalFee = value; }
        }

        public double examBill
        {
            get { return _examBill; }
            set { _examBill = value; }
        }

        public string examInfo
        {
            get { return _examInfo; }
            set { _examInfo = value; }
        }

        public string examWorkNo
        {
            get { return _examWorkNo; }
            set { _examWorkNo = value; }
        }

        public string Msg
        {
            get { return _Msg; }
            set { _Msg = value; }
        }

        public string Report
        {
            get { return _Report; }
            set { _Report = value; }
        }

        public string ReportContent
        {
            get { return _ReportContent; }
            set { _ReportContent = value; }
        }

        public string ReportType
        {
            get { return _ReportType; }
            set { _ReportType = value; }
        }

        public string ReportUploader
        {
            get { return _ReportUploader; }
            set { _ReportUploader = value; }
        }

        public DateTime ReportUploadDate
        {
            get { return _ReportUploadDate; }
            set { _ReportUploadDate = value; }
        }

        public string ReportNote
        {
            get { return _ReportNote; }
            set { _ReportNote = value; }
        }

        public string payMethod
        {
            get { return _payMethod; }
            set { _payMethod = value; }
        }

        public string payRefNum
        {
            get { return _payRefNum; }
            set { _payRefNum = value; }
        }

        public DateTime payTime
        {
            get { return _payTime; }
            set { _payTime = value; }
        }

        public string payNote
        {
            get { return _payNote; }
            set { _payNote = value; }
        }

        public string ordernote
        {
            get { return _ordernote; }
            set { _ordernote = value; }
        }



    }
}
