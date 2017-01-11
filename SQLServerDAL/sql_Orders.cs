using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SQLServerDAL
{
    class sql_Orders:IDAL.OrdersDal
    {
        #region OrdersDal 成员
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        DateTime baddate = DateTime.Parse("1900-01-01");
        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <returns></returns>
        public int getMax()
        {
            object x = sql.ExecuteSc("select top 1 orderID from tab_orders order by orderID desc");
            return Convert.ToInt32(x) + 1;
        }

        public int getOrderID(string orderDate)
        {
            object x = sql.ExecuteSc("select top 1 orderID from tab_orders where orderDate='" + orderDate+"'");
            return Convert.ToInt32(x);
        }

        public System.Data.DataTable GetAll()
        {
            return sql.ExecuteDataSet("select * from tab_orders").Tables[0];
        }

        public System.Data.DataTable GetAny(string sq)
        {
            return sql.ExecuteDataSet(sq).Tables[0];
        }

        public int Add(Model.tab_orders tab_orders)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_orders values (");
            strsql.AppendFormat("'{0}',", tab_orders.supplierOrderID);
            strsql.AppendFormat("'{0}',", tab_orders.cardNumber);
            strsql.AppendFormat("{0},", tab_orders.customerID);
            strsql.AppendFormat("'{0}',", tab_orders.customerCode);
            strsql.AppendFormat("N'{0}',", tab_orders.customerName);
            strsql.AppendFormat("{0},", tab_orders.relativeID);
            strsql.AppendFormat("N'{0}',", tab_orders.relativeName);
            strsql.AppendFormat("{0},", tab_orders.orderDate == baddate ? "null" : "'" + tab_orders.orderDate.ToString() + "'");
            strsql.AppendFormat("N'{0}',", tab_orders.orderStatus);
            strsql.AppendFormat("N'{0}',", tab_orders.personSex);
            strsql.AppendFormat("{0},", tab_orders.personAge);
            strsql.AppendFormat("'{0}',", tab_orders.personIDcard);
            strsql.AppendFormat("'{0}',", tab_orders.personMobile);
            strsql.AppendFormat("'{0}',", tab_orders.personPrivateEmail);
            strsql.AppendFormat("N'{0}',", tab_orders.personCompany);
            strsql.AppendFormat("'{0}',", tab_orders.personCompanycode);
            strsql.AppendFormat("N'{0}',", tab_orders.personMarriageStatus);
            strsql.AppendFormat("N'{0}',", tab_orders.personAddress);
            strsql.AppendFormat("{0},", tab_orders.examDate == baddate ? "null" : "'" + tab_orders.examDate.ToString() + "'");
            strsql.AppendFormat("N'{0}',", tab_orders.examCity);
            strsql.AppendFormat("N'{0}',", tab_orders.examSupplier);
            strsql.AppendFormat("N'{0}',", tab_orders.examBranch);
            strsql.AppendFormat("'{0}',", tab_orders.examhosip);
            strsql.AppendFormat("N'{0}',", tab_orders.examPackage);
            strsql.AppendFormat("N'{0}',", tab_orders.examUpPkg);
            strsql.AppendFormat("{0},", tab_orders.examTotalFee);
            strsql.AppendFormat("{0},", tab_orders.examBill);
            strsql.AppendFormat("N'{0}',", tab_orders.examInfo);
            strsql.AppendFormat("'{0}',", tab_orders.examWorkNo);
            strsql.AppendFormat("N'{0}',", tab_orders.Msg);
            strsql.AppendFormat("N'{0}',", tab_orders.Report);
            strsql.AppendFormat("N'{0}',", tab_orders.ReportContent);
            strsql.AppendFormat("N'{0}',", tab_orders.ReportType);
            strsql.AppendFormat("N'{0}',", tab_orders.ReportUploader);
            strsql.AppendFormat("{0},", tab_orders.ReportUploadDate == baddate ? "null" : "'" + tab_orders.ReportUploadDate.ToString() + "'");
            strsql.AppendFormat("N'{0}',", tab_orders.ReportNote);
            strsql.AppendFormat("N'{0}',", tab_orders.payMethod);
            strsql.AppendFormat("'{0}',", tab_orders.payRefNum);
            strsql.AppendFormat("{0},", tab_orders.payTime == baddate ? "null" : "'" + tab_orders.payTime.ToString() + "'");
            strsql.AppendFormat("N'{0}',", tab_orders.payNote);
            strsql.AppendFormat("N'{0}',", tab_orders.ordernote);
            strsql.AppendFormat("N'{0}',", tab_orders.fapiaotitle);
            strsql.AppendFormat("N'{0}',", tab_orders.fapiaocontent);
            strsql.AppendFormat("N'{0}',", tab_orders.deliveryno);
            strsql.AppendFormat("N'{0}'", tab_orders.xiya);
            strsql.Append(") select SCOPE_IDENTITY()");
            return Convert.ToInt32(sql.ExecuteSc(strsql.ToString()));
        }


        public Model.tab_orders gettab_orders(DataTable dt)
        {
            Model.tab_orders tab_orders = new Model.tab_orders();
            tab_orders.orderID = int.Parse(dt.Rows[0]["orderID"].ToString());
            tab_orders.supplierOrderID = dt.Rows[0]["supplierOrderID"].ToString();
            tab_orders.cardNumber = dt.Rows[0]["cardNumber"].ToString();
            tab_orders.customerID = int.Parse(dt.Rows[0]["customerID"].ToString());
            tab_orders.customerCode = dt.Rows[0]["customerCode"].ToString();
            tab_orders.customerName = dt.Rows[0]["customerName"].ToString();
            tab_orders.relativeID = int.Parse(dt.Rows[0]["relativeID"].ToString());
            tab_orders.relativeName = dt.Rows[0]["relativeName"].ToString();
            tab_orders.orderDate = dt.Rows[0]["orderDate"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["orderDate"].ToString());
            tab_orders.orderStatus = dt.Rows[0]["orderStatus"].ToString();
            tab_orders.personSex = dt.Rows[0]["personSex"].ToString();
            tab_orders.personAge = int.Parse(dt.Rows[0]["personAge"].ToString());
            tab_orders.personIDcard = dt.Rows[0]["personIDcard"].ToString();
            tab_orders.personMobile = dt.Rows[0]["personMobile"].ToString();
            tab_orders.personPrivateEmail = dt.Rows[0]["personPrivateEmail"].ToString();
            tab_orders.personCompany = dt.Rows[0]["personCompany"].ToString();
            tab_orders.personCompanycode = dt.Rows[0]["personCompanycode"].ToString();
            tab_orders.personMarriageStatus = dt.Rows[0]["personMarriageStatus"].ToString();
            tab_orders.personAddress = dt.Rows[0]["personAddress"].ToString();
            tab_orders.examDate = dt.Rows[0]["examDate"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["examDate"].ToString());
            tab_orders.examCity = dt.Rows[0]["examCity"].ToString();
            tab_orders.examSupplier = dt.Rows[0]["examSupplier"].ToString();
            tab_orders.examBranch = dt.Rows[0]["examBranch"].ToString();
            tab_orders.examhosip = dt.Rows[0]["examhosip"].ToString();
            tab_orders.examPackage = dt.Rows[0]["examPackage"].ToString();
            tab_orders.examUpPkg = dt.Rows[0]["examUpPkg"].ToString();
            tab_orders.examTotalFee = double.Parse(dt.Rows[0]["examTotalFee"].ToString());
            tab_orders.examBill = double.Parse(dt.Rows[0]["examBill"].ToString());
            tab_orders.examInfo = dt.Rows[0]["examInfo"].ToString();
            tab_orders.examWorkNo = dt.Rows[0]["examWorkNo"].ToString();
            tab_orders.Msg = dt.Rows[0]["Msg"].ToString();
            tab_orders.Report = dt.Rows[0]["Report"].ToString();
            tab_orders.ReportContent = dt.Rows[0]["ReportContent"].ToString();
            tab_orders.ReportType = dt.Rows[0]["ReportType"].ToString();
            tab_orders.ReportUploader = dt.Rows[0]["ReportUploader"].ToString();
            tab_orders.ReportUploadDate = dt.Rows[0]["ReportUploadDate"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["ReportUploadDate"].ToString());
            tab_orders.ReportNote = dt.Rows[0]["ReportNote"].ToString();
            tab_orders.payMethod = dt.Rows[0]["payMethod"].ToString();
            tab_orders.payRefNum = dt.Rows[0]["payRefNum"].ToString();
            tab_orders.payTime = dt.Rows[0]["payTime"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["payTime"].ToString());
            tab_orders.payNote = dt.Rows[0]["payNote"].ToString();
            tab_orders.ordernote = dt.Rows[0]["ordernote"].ToString();
            tab_orders.fapiaotitle = dt.Rows[0]["fapiaotitle"].ToString();
            tab_orders.fapiaocontent = dt.Rows[0]["fapiaocontent"].ToString();
            tab_orders.deliveryno = dt.Rows[0]["deliveryno"].ToString();
            tab_orders.xiya = dt.Rows[0]["xiya"].ToString();
            return tab_orders;
        }


        public Model.tab_orders gettab_orders(int id)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_orders where ");
            strsql.AppendFormat("orderID='{0}'", id);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            return gettab_orders(dt);
        }


        public int update(Model.tab_orders tab_orders)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_orders set ");
            strsql.AppendFormat(" supplierOrderID ='{0}',", tab_orders.supplierOrderID);
            strsql.AppendFormat(" cardNumber ='{0}',", tab_orders.cardNumber);
            strsql.AppendFormat(" customerID ='{0}',", tab_orders.customerID);
            strsql.AppendFormat(" customerCode ='{0}',", tab_orders.customerCode);
            strsql.AppendFormat(" customerName =N'{0}',", tab_orders.customerName);
            strsql.AppendFormat(" relativeID ='{0}',", tab_orders.relativeID);
            strsql.AppendFormat(" relativeName =N'{0}',", tab_orders.relativeName);
            strsql.AppendFormat(" orderDate ={0},", tab_orders.orderDate == baddate ? "null" : "'" + tab_orders.orderDate.ToString() + "'");
            strsql.AppendFormat(" orderStatus =N'{0}',", tab_orders.orderStatus);
            strsql.AppendFormat(" personSex =N'{0}',", tab_orders.personSex);
            strsql.AppendFormat(" personAge ='{0}',", tab_orders.personAge);
            strsql.AppendFormat(" personIDcard ='{0}',", tab_orders.personIDcard);
            strsql.AppendFormat(" personMobile ='{0}',", tab_orders.personMobile);
            strsql.AppendFormat(" personPrivateEmail ='{0}',", tab_orders.personPrivateEmail);
            strsql.AppendFormat(" personCompany =N'{0}',", tab_orders.personCompany);
            strsql.AppendFormat(" personCompanycode ='{0}',", tab_orders.personCompanycode);
            strsql.AppendFormat(" personMarriageStatus =N'{0}',", tab_orders.personMarriageStatus);
            strsql.AppendFormat(" personAddress =N'{0}',", tab_orders.personAddress);
            strsql.AppendFormat(" examDate ={0},", tab_orders.examDate == baddate ? "null" : "'" + tab_orders.examDate.ToString() + "'");
            strsql.AppendFormat(" examCity =N'{0}',", tab_orders.examCity);
            strsql.AppendFormat(" examSupplier =N'{0}',", tab_orders.examSupplier);
            strsql.AppendFormat(" examBranch =N'{0}',", tab_orders.examBranch);
            strsql.AppendFormat(" examhosip ='{0}',", tab_orders.examhosip);
            strsql.AppendFormat(" examPackage =N'{0}',", tab_orders.examPackage);
            strsql.AppendFormat(" examUpPkg =N'{0}',", tab_orders.examUpPkg);
            strsql.AppendFormat(" examTotalFee ='{0}',", tab_orders.examTotalFee);
            strsql.AppendFormat(" examBill ='{0}',", tab_orders.examBill);
            strsql.AppendFormat(" examInfo =N'{0}',", tab_orders.examInfo);
            strsql.AppendFormat(" examWorkNo ='{0}',", tab_orders.examWorkNo);
            strsql.AppendFormat(" Msg =N'{0}',", tab_orders.Msg);
            strsql.AppendFormat(" Report =N'{0}',", tab_orders.Report);
            strsql.AppendFormat(" ReportContent =N'{0}',", tab_orders.ReportContent);
            strsql.AppendFormat(" ReportType =N'{0}',", tab_orders.ReportType);
            strsql.AppendFormat(" ReportUploader =N'{0}',", tab_orders.ReportUploader);
            strsql.AppendFormat(" ReportUploadDate ={0},", tab_orders.ReportUploadDate == baddate ? "null" : "'" + tab_orders.ReportUploadDate.ToString() + "'");
            strsql.AppendFormat(" ReportNote =N'{0}',", tab_orders.ReportNote);
            strsql.AppendFormat(" payMethod =N'{0}',", tab_orders.payMethod);
            strsql.AppendFormat(" payRefNum ='{0}',", tab_orders.payRefNum);
            strsql.AppendFormat(" payTime ={0},", tab_orders.payTime == baddate ? "null" : "'" + tab_orders.payTime.ToString() + "'");
            strsql.AppendFormat(" payNote =N'{0}',", tab_orders.payNote);
            strsql.AppendFormat(" ordernote =N'{0}',", tab_orders.ordernote);
            strsql.AppendFormat(" fapiaotitle =N'{0}',", tab_orders.fapiaotitle);
            strsql.AppendFormat(" fapiaocontent =N'{0}',", tab_orders.fapiaocontent);
            strsql.AppendFormat(" deliveryno =N'{0}',", tab_orders.deliveryno);
            strsql.AppendFormat(" xiya =N'{0}'", tab_orders.xiya);
            strsql.AppendFormat(" where orderID={0}", tab_orders.orderID);
            return sql.ExecuteNonQuery(strsql.ToString());
        }



        public int Delete(string st)
        {
            return sql.ExecuteNonQuery(st);
        }
        public int Delete(int orderID)
        {
            return sql.ExecuteNonQuery("delete from tab_orders where orderID=" + orderID);
        }
        public DataTable Select(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }




        public int getordernum(int id)
        {
            return Convert.ToInt32(sql.ExecuteSc("select count(customerID) from tab_orders where orderStatus <>N'已完成' and orderStatus <>N'已取消' and ReportType<>N'商城' and (customerID=" + id
                + " or relativeID in (select relativeID from tab_relatives where relativeCustomer=" + id+"))"));
        }
        public int updatereportpath(int orderID, string path)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_orders set ");
            strsql.AppendFormat(" orderStatus =N'{0}',", "已完成");
            strsql.AppendFormat(" Report =N'{0}'", path);
            strsql.AppendFormat(" where orderID={0}", orderID);
            return sql.ExecuteNonQuery(strsql.ToString());
        }
        public System.Data.DataSet getOrderInfo(string sq, string sqlx)
        {
            return sql.ExecuteDataSet(sq, sqlx);
        }
        public bool hasarrangement(int id)
        {
            if (Convert.ToInt32(sql.ExecuteSc("select count(orderID) from tab_orders where orderStatus <>N'已完成' and orderStatus <>N'已取消' and ReportType<>N'商城' and customerName<>N'' and customerID=" + id)) >= 1)
            {
                return true;
            }
            else
                return false;
        }
        public bool hasRelarrangement(int id)
        {
            if (Convert.ToInt32(sql.ExecuteSc("select count(orderID) from tab_orders where orderStatus <>N'已完成' and orderStatus <>N'已取消' and ReportType<>N'商城' and relativeID in (select relativeID from tab_relatives where relativeCustomer=" + id + ")")) >= 1)
            {
                return true;
            }
            else
                return false;
        }
        public bool has2Relarrangement(int id)
        {
            if (Convert.ToInt32(sql.ExecuteSc("select count(orderID) from tab_orders where orderStatus <>N'已完成' and orderStatus <>N'已取消' and ReportType<>N'商城' and relativeID in (select relativeID from tab_relatives where relativeCustomer=" + id + ")")) >= 2)
            {
                return true;
            }
            else
                return false;
        }
        public bool hasSpecRelarrangement(int id)
        {
            if (Convert.ToInt32(sql.ExecuteSc("select count(orderID) from tab_orders where orderStatus <>N'已完成' and orderStatus <>N'已取消' and relativeID =" + id)) >= 1)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
