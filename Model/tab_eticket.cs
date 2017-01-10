using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class tab_eticket
    {
        private int _id = 0;
        private int _orderID = 0;
        private string _customerName = "";
        private string _productName = "";
        private int _productID = 0;
        private string _itemnum = "";
        private string _eticket = "";
        private string _used = "";
        private DateTime _time = DateTime.Parse("1900-01-01");
        private string _note = "";


        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int orderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        public string customerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public string productName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public int productID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public string itemnum
        {
            get { return _itemnum; }
            set { _itemnum = value; }
        }

        public string eticket
        {
            get { return _eticket; }
            set { _eticket = value; }
        }

        public string used
        {
            get { return _used; }
            set { _used = value; }
        }

        public DateTime time
        {
            get { return _time; }
            set { _time = value; }
        }

        public string note
        {
            get { return _note; }
            set { _note = value; }
        }


    }
}
