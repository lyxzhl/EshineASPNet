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

        public int Add(Model.tab_orders orders)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_orders values (");
            strsql.AppendFormat("'{0}',", orders.supplierOrderID);
            strsql.AppendFormat("'{0}',", orders.cardNumber);
            strsql.AppendFormat("{0},", orders.customerID);
            strsql.AppendFormat("'{0}',", orders.customerCode);
            strsql.AppendFormat("N'{0}',", orders.customerName);
            strsql.AppendFormat("{0},", orders.relativeID);
            strsql.AppendFormat("N'{0}',", orders.relativeName);
            strsql.AppendFormat("{0},", orders.orderDate == baddate ? "null" : "'" + orders.orderDate.ToString() + "'");
            strsql.AppendFormat("N'{0}',", orders.orderStatus);
            strsql.AppendFormat("N'{0}',", orders.personSex);
            strsql.AppendFormat("{0},", orders.personAge);
            strsql.AppendFormat("'{0}',", orders.personIDcard);
            strsql.AppendFormat("'{0}',", orders.personMobile);
            strsql.AppendFormat("'{0}',", orders.personPrivateEmail);
            strsql.AppendFormat("N'{0}',", orders.personCompany);
            strsql.AppendFormat("'{0}',", orders.personCompanycode);
            strsql.AppendFormat("N'{0}',", orders.personMarriageStatus);
            strsql.AppendFormat("N'{0}',", orders.personAddress);
            strsql.AppendFormat("{0},", orders.examDate == baddate ? "null" : "'" + orders.examDate.ToString() + "'");
            strsql.AppendFormat("N'{0}',", orders.examCity);
            strsql.AppendFormat("N'{0}',", orders.examSupplier);
            strsql.AppendFormat("N'{0}',", orders.examBranch);
            strsql.AppendFormat("'{0}',", orders.examhosip);
            strsql.AppendFormat("N'{0}',", orders.examPackage);
            strsql.AppendFormat("N'{0}',", orders.examUpPkg);
            strsql.AppendFormat("{0},", orders.examTotalFee);
            strsql.AppendFormat("{0},", orders.examBill);
            strsql.AppendFormat("N'{0}',", orders.examInfo);
            strsql.AppendFormat("'{0}',", orders.examWorkNo);
            strsql.AppendFormat("N'{0}',", orders.Msg);
            strsql.AppendFormat("N'{0}',", orders.Report);
            strsql.AppendFormat("N'{0}',", orders.ReportContent);
            strsql.AppendFormat("N'{0}',", orders.ReportType);
            strsql.AppendFormat("N'{0}',", orders.ReportUploader);
            strsql.AppendFormat("{0},", orders.ReportUploadDate == baddate ? "null" : "'" + orders.ReportUploadDate.ToString() + "'");
            strsql.AppendFormat("N'{0}',", orders.ReportNote);
            strsql.AppendFormat("N'{0}',", orders.payMethod);
            strsql.AppendFormat("'{0}',", orders.payRefNum);
            strsql.AppendFormat("{0},", orders.payTime == baddate ? "null" : "'" + orders.payTime.ToString() + "'");
            strsql.AppendFormat("N'{0}',", orders.payNote);
            strsql.AppendFormat("N'{0}'", orders.ordernote);
            strsql.Append(") select SCOPE_IDENTITY()");

            return Convert.ToInt32(sql.ExecuteSc(strsql.ToString()));
            //return sql.ExecuteNonQuery(strsql.ToString());
        }


        public Model.tab_orders getorders(Model.tab_orders orders1)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_orders where ");
            strsql.AppendFormat("orderID='{0}'", orders1.orderID);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            Model.tab_orders orders = new Model.tab_orders();
            orders.orderID = orders1.orderID;
            orders.supplierOrderID = dt.Rows[0]["supplierOrderID"].ToString();
            orders.cardNumber = dt.Rows[0]["cardNumber"].ToString();
            orders.customerID = int.Parse(dt.Rows[0]["customerID"].ToString());
            orders.customerCode = dt.Rows[0]["customerCode"].ToString();
            orders.customerName = dt.Rows[0]["customerName"].ToString();
            orders.relativeID = int.Parse(dt.Rows[0]["relativeID"].ToString());
            orders.relativeName = dt.Rows[0]["relativeName"].ToString();
            orders.orderDate = dt.Rows[0]["orderDate"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["orderDate"].ToString());
            orders.orderStatus = dt.Rows[0]["orderStatus"].ToString();
            orders.personSex = dt.Rows[0]["personSex"].ToString();
            orders.personAge = int.Parse(dt.Rows[0]["personAge"].ToString());
            orders.personIDcard = dt.Rows[0]["personIDcard"].ToString();
            orders.personMobile = dt.Rows[0]["personMobile"].ToString();
            orders.personPrivateEmail = dt.Rows[0]["personPrivateEmail"].ToString();
            orders.personCompany = dt.Rows[0]["personCompany"].ToString();
            orders.personCompanycode = dt.Rows[0]["personCompanycode"].ToString();
            orders.personMarriageStatus = dt.Rows[0]["personMarriageStatus"].ToString();
            orders.personAddress = dt.Rows[0]["personAddress"].ToString();
            orders.examDate = dt.Rows[0]["examDate"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["examDate"].ToString());
            orders.examCity = dt.Rows[0]["examCity"].ToString();
            orders.examSupplier = dt.Rows[0]["examSupplier"].ToString();
            orders.examBranch = dt.Rows[0]["examBranch"].ToString();
            orders.examhosip = dt.Rows[0]["examhosip"].ToString();
            orders.examPackage = dt.Rows[0]["examPackage"].ToString();
            orders.examUpPkg = dt.Rows[0]["examUpPkg"].ToString();
            orders.examTotalFee = double.Parse(dt.Rows[0]["examTotalFee"].ToString());
            orders.examBill = double.Parse(dt.Rows[0]["examBill"].ToString());
            orders.examInfo = dt.Rows[0]["examInfo"].ToString();
            orders.examWorkNo = dt.Rows[0]["examWorkNo"].ToString();
            orders.Msg = dt.Rows[0]["Msg"].ToString();
            orders.Report = dt.Rows[0]["Report"].ToString();
            orders.ReportContent = dt.Rows[0]["ReportContent"].ToString();
            orders.ReportType = dt.Rows[0]["ReportType"].ToString();
            orders.ReportUploader = dt.Rows[0]["ReportUploader"].ToString();
            orders.ReportUploadDate = dt.Rows[0]["ReportUploadDate"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["ReportUploadDate"].ToString());
            orders.ReportNote = dt.Rows[0]["ReportNote"].ToString();
            orders.payMethod = dt.Rows[0]["payMethod"].ToString();
            orders.payRefNum = dt.Rows[0]["payRefNum"].ToString();
            orders.payTime = dt.Rows[0]["payTime"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["payTime"].ToString());
            orders.payNote = dt.Rows[0]["payNote"].ToString();
            orders.ordernote = dt.Rows[0]["ordernote"].ToString();
            return orders;
        }


        public string Update(Model.tab_orders orders)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_orders set ");
            strsql.AppendFormat(" supplierOrderID ='{0}',", orders.supplierOrderID);
            strsql.AppendFormat(" cardNumber ='{0}',", orders.cardNumber);
            strsql.AppendFormat(" customerID ='{0}',", orders.customerID);
            strsql.AppendFormat(" customerCode ='{0}',", orders.customerCode);
            strsql.AppendFormat(" customerName =N'{0}',", orders.customerName);
            strsql.AppendFormat(" relativeID ='{0}',", orders.relativeID);
            strsql.AppendFormat(" relativeName =N'{0}',", orders.relativeName);
            strsql.AppendFormat(" orderDate ={0},", orders.orderDate == baddate ? "null" : "'" + orders.orderDate.ToString() + "'");
            strsql.AppendFormat(" orderStatus =N'{0}',", orders.orderStatus);
            strsql.AppendFormat(" personSex =N'{0}',", orders.personSex);
            strsql.AppendFormat(" personAge ='{0}',", orders.personAge);
            strsql.AppendFormat(" personIDcard ='{0}',", orders.personIDcard);
            strsql.AppendFormat(" personMobile ='{0}',", orders.personMobile);
            strsql.AppendFormat(" personPrivateEmail ='{0}',", orders.personPrivateEmail);
            strsql.AppendFormat(" personCompany =N'{0}',", orders.personCompany);
            strsql.AppendFormat(" personCompanycode ='{0}',", orders.personCompanycode);
            strsql.AppendFormat(" personMarriageStatus =N'{0}',", orders.personMarriageStatus);
            strsql.AppendFormat(" personAddress =N'{0}',", orders.personAddress);
            strsql.AppendFormat(" examDate ={0},", orders.examDate == baddate ? "null" : "'" + orders.examDate.ToString() + "'");
            strsql.AppendFormat(" examCity =N'{0}',", orders.examCity);
            strsql.AppendFormat(" examSupplier =N'{0}',", orders.examSupplier);
            strsql.AppendFormat(" examBranch =N'{0}',", orders.examBranch);
            strsql.AppendFormat(" examhosip ='{0}',", orders.examhosip);
            strsql.AppendFormat(" examPackage =N'{0}',", orders.examPackage);
            strsql.AppendFormat(" examUpPkg =N'{0}',", orders.examUpPkg);
            strsql.AppendFormat(" examTotalFee ='{0}',", orders.examTotalFee);
            strsql.AppendFormat(" examBill ='{0}',", orders.examBill);
            strsql.AppendFormat(" examInfo =N'{0}',", orders.examInfo);
            strsql.AppendFormat(" examWorkNo ='{0}',", orders.examWorkNo);
            strsql.AppendFormat(" Msg =N'{0}',", orders.Msg);
            strsql.AppendFormat(" Report =N'{0}',", orders.Report);
            strsql.AppendFormat(" ReportContent =N'{0}',", orders.ReportContent);
            strsql.AppendFormat(" ReportType =N'{0}',", orders.ReportType);
            strsql.AppendFormat(" ReportUploader =N'{0}',", orders.ReportUploader);
            strsql.AppendFormat(" ReportUploadDate ={0},", orders.ReportUploadDate == baddate ? "null" : "'" + orders.ReportUploadDate.ToString() + "'");
            strsql.AppendFormat(" ReportNote =N'{0}',", orders.ReportNote);
            strsql.AppendFormat(" payMethod =N'{0}',", orders.payMethod);
            strsql.AppendFormat(" payRefNum ='{0}',", orders.payRefNum);
            strsql.AppendFormat(" payTime ={0},", orders.payTime == baddate ? "null" : "'" + orders.payTime.ToString() + "'");
            strsql.AppendFormat(" payNote =N'{0}',", orders.payNote);
            strsql.AppendFormat(" ordernote =N'{0}'", orders.ordernote);
            strsql.AppendFormat(" where orderID={0}", orders.orderID);

            //Model.tab_loginlog loginlog = new Model.tab_loginlog();
            //loginlog.note = strsql.ToString().Replace("'","''");
            //sql_loginlog sll = new sql_loginlog();
            //sll.Add(loginlog);


            //return sql.ExecuteNonQuery(strsql.ToString());
            
            int i=sql.ExecuteNonQuery(strsql.ToString());
            return i.ToString();
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
