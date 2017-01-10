using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class tab_shoporder
    {
        private int _id = 0;
        private int _customerID = 0;
        private string _customerName = "";
        private DateTime _orderdate = DateTime.Parse("1900-01-01");
        private string _out_trade_no = "";
        private string _subject = "";
        private double _total_fee = 0.0;
        private string _body = "";
        private string _show_url = "";
        private string _anti_phishing_key = "";
        private string _exter_invoke_ip = "";
        private string _trade_no = "";
        private string _trade_status = "";
        private string _orderStatus = "";
        private string _Msg = "";


        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int customerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        public string customerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public DateTime orderdate
        {
            get { return _orderdate; }
            set { _orderdate = value; }
        }

        public string out_trade_no
        {
            get { return _out_trade_no; }
            set { _out_trade_no = value; }
        }

        public string subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public double total_fee
        {
            get { return _total_fee; }
            set { _total_fee = value; }
        }

        public string body
        {
            get { return _body; }
            set { _body = value; }
        }

        public string show_url
        {
            get { return _show_url; }
            set { _show_url = value; }
        }

        public string anti_phishing_key
        {
            get { return _anti_phishing_key; }
            set { _anti_phishing_key = value; }
        }

        public string exter_invoke_ip
        {
            get { return _exter_invoke_ip; }
            set { _exter_invoke_ip = value; }
        }

        public string trade_no
        {
            get { return _trade_no; }
            set { _trade_no = value; }
        }

        public string trade_status
        {
            get { return _trade_status; }
            set { _trade_status = value; }
        }

        public string orderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; }
        }

        public string Msg
        {
            get { return _Msg; }
            set { _Msg = value; }
        }


    }
}
