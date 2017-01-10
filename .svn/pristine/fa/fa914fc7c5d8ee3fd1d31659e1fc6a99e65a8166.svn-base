using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SQLServerDAL
{
    class sql_customer:IDAL.customerDal
    {
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        #region customerDal 成员
        /// <summary>
        /// 客户表的添加
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        DateTime baddate = DateTime.Parse("1900-01-01");
        public int CustomerAdd(Model.tab_customers customer)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_customers values (");
            strsql.AppendFormat("'{0}',", customer.customerCode);
            strsql.AppendFormat("N'{0}',", customer.customerName);
            strsql.AppendFormat("'{0}',", customer.customerEmail);
            strsql.AppendFormat("'{0}',", customer.customerPrivateEmail);
            strsql.AppendFormat("'{0}',", customer.customerMobile);
            strsql.AppendFormat("'{0}',", customer.customerTel);
            strsql.AppendFormat("N'{0}',", customer.customerProvince);
            strsql.AppendFormat("N'{0}',", customer.customerCity);
            strsql.AppendFormat("N'{0}',", customer.customerZone);
            strsql.AppendFormat("N'{0}',", customer.customerAddress);
            strsql.AppendFormat("N'{0}',", customer.customerAllAddr);
            strsql.AppendFormat("N'{0}',", customer.customerDefaultAddr);
            strsql.AppendFormat("N'{0}',", customer.customerGender);
            strsql.AppendFormat("N'{0}',", customer.customerMarriageStatus);
            strsql.AppendFormat("{0},", customer.customerDOB == baddate ? "null" : "'" + customer.customerDOB.ToString() + "'");
            strsql.AppendFormat("N'{0}',", customer.customerNation);
            strsql.AppendFormat("'{0}',", customer.customerIDcard);
            strsql.AppendFormat("N'{0}',", customer.customerCompany);
            strsql.AppendFormat("'{0}',", customer.customerCompanycode);
            strsql.AppendFormat("N'{0}',", customer.customerClass);
            strsql.AppendFormat("'{0}',", customer.customerCompanyTel);
            strsql.AppendFormat("N'{0}',", customer.customerCompanyProvince);
            strsql.AppendFormat("N'{0}',", customer.customerCompanyCity);
            strsql.AppendFormat("N'{0}',", customer.customerCompanyZone);
            strsql.AppendFormat("N'{0}',", customer.customerCompanyAddress);
            
            strsql.AppendFormat("N'{0}',", customer.customerCompanyBU);
            strsql.AppendFormat("N'{0}',", customer.customerVIP);
            strsql.AppendFormat("'{0}',", customer.customerBalance);
            strsql.AppendFormat("'{0}',", customer.customerPwd);
            strsql.AppendFormat("{0},", customer.customerLastLogin == baddate ? "null" : "'" + customer.customerLastLogin.ToString() + "'");
            strsql.AppendFormat("{0},", customer.customerLastPWChanged == baddate ? "null" : "'" + customer.customerLastPWChanged.ToString() + "'");
            strsql.AppendFormat("'{0}',", customer.customerOldPW1);
            strsql.AppendFormat("'{0}',", customer.customerOldPW2);
            strsql.AppendFormat("'{0}',", customer.customerOldPW3);
            strsql.AppendFormat("'{0}',", customer.customerValidateCode);
            strsql.AppendFormat("N'{0}',", customer.customerMsg);
            strsql.AppendFormat("N'{0}',", customer.customerSafeQ1);
            strsql.AppendFormat("N'{0}',", customer.customerSafeQ2);
            strsql.AppendFormat("N'{0}',", customer.customerSafeQ3);
            strsql.AppendFormat("N'{0}',", customer.customerSafeA1);
            strsql.AppendFormat("N'{0}',", customer.customerSafeA2);
            strsql.AppendFormat("N'{0}',", customer.customerSafeA3);
            strsql.AppendFormat("N'{0}',", customer.disablebranch);
            strsql.AppendFormat("N'{0}',", customer.packagecode);
            strsql.AppendFormat("'{0}',", customer.customerBudget);
            strsql.AppendFormat("N'{0}'", customer.customerorderstatus);
            strsql.Append(")");
            return sql.ExecuteNonQuery(strsql.ToString());
            
        }

        /// <summary>
        /// 客户表的查找
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public System.Data.DataTable CustomerSelect(Model.tab_customers cus)
        {
             StringBuilder strsql = new StringBuilder();
             strsql.Append("select * from tab_customers where ");
             strsql.AppendFormat("customerID='{0}'", cus.customerID);
             strsql.AppendFormat(" or ((customerIDcard='{0}'", cus.customerIDcard);
             if (cus.customerMobile != "") strsql.AppendFormat(" or customerMobile='{0}'", cus.customerMobile);
             if (cus.customerEmail != "") strsql.AppendFormat(" or customerEmail='{0}'", cus.customerEmail);
             if (cus.customerPrivateEmail != "") strsql.AppendFormat(" or customerPrivateEmail='{0}'", cus.customerPrivateEmail);
             if (cus.customerCompany != "") strsql.AppendFormat(" or customerCode='{0}'", cus.customerCode);
             strsql.Append(")");
            if (cus.customerCompany != "") strsql.AppendFormat(" and customerCompany='{0}'", cus.customerCompany);
             strsql.AppendFormat(" and customerPwd='{0}')", cus.customerPwd);
             
             return sql.ExecuteDataSet(strsql.ToString()).Tables[0];
        }
        /// <summary>
        /// 返回客户
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public Model.tab_customers getCustomer(Model.tab_customers cus)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_customers where ");
            if (cus.customerID != 0)
            {
                strsql.AppendFormat("customerID='{0}'", cus.customerID);
            }
            else if (cus.customerEmail != "")
            {
                strsql.AppendFormat("customerEmail='{0}'", cus.customerEmail);
            }
            else if (cus.customerPrivateEmail != "")
            {
                strsql.AppendFormat("customerPrivateEmail='{0}'", cus.customerPrivateEmail);
            }
            else if (cus.customerName != ""&& cus.customerIDcard!="")
            {
                strsql.AppendFormat("customerName='{0}'", cus.customerName);
                strsql.AppendFormat("and customerIDcard='{0}'", cus.customerIDcard);
            }
            else
            {
                return null;
            }
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            Model.tab_customers customers = new Model.tab_customers();
            customers.customerID = Convert.ToInt32( dt.Rows[0]["customerID"]);
            customers.customerCode = dt.Rows[0]["customerCode"].ToString();
            customers.customerName = dt.Rows[0]["customerName"].ToString();
            customers.customerEmail = dt.Rows[0]["customerEmail"].ToString();
            customers.customerPrivateEmail = dt.Rows[0]["customerPrivateEmail"].ToString();
            customers.customerMobile = dt.Rows[0]["customerMobile"].ToString();
            customers.customerTel = dt.Rows[0]["customerTel"].ToString();
            customers.customerProvince = dt.Rows[0]["customerProvince"].ToString();
            customers.customerCity = dt.Rows[0]["customerCity"].ToString();
            customers.customerZone = dt.Rows[0]["customerZone"].ToString();
            customers.customerAddress = dt.Rows[0]["customerAddress"].ToString();
            customers.customerAllAddr = dt.Rows[0]["customerAllAddr"].ToString();
            customers.customerDefaultAddr = dt.Rows[0]["customerDefaultAddr"].ToString();
            customers.customerGender = dt.Rows[0]["customerGender"].ToString();
            customers.customerMarriageStatus = dt.Rows[0]["customerMarriageStatus"].ToString();
            customers.customerDOB = dt.Rows[0]["customerDOB"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["customerDOB"].ToString());
            customers.customerNation = dt.Rows[0]["customerNation"].ToString();
            customers.customerIDcard = dt.Rows[0]["customerIDcard"].ToString();
            customers.customerCompany = dt.Rows[0]["customerCompany"].ToString();
            customers.customerCompanycode = dt.Rows[0]["customerCompanycode"].ToString();
            customers.customerClass = dt.Rows[0]["customerClass"].ToString();
            customers.customerCompanyTel = dt.Rows[0]["customerCompanyTel"].ToString();
            customers.customerCompanyProvince = dt.Rows[0]["customerCompanyProvince"].ToString();
            customers.customerCompanyCity = dt.Rows[0]["customerCompanyCity"].ToString();
            customers.customerCompanyAddress = dt.Rows[0]["customerCompanyAddress"].ToString();
            customers.customerCompanyZone = dt.Rows[0]["customerCompanyZone"].ToString();
            customers.customerCompanyBU = dt.Rows[0]["customerCompanyBU"].ToString();
            customers.customerVIP = dt.Rows[0]["customerVIP"].ToString();
            customers.customerBalance = double.Parse(dt.Rows[0]["customerBalance"].ToString());
            customers.customerPwd = dt.Rows[0]["customerPwd"].ToString();
            customers.customerLastLogin = dt.Rows[0]["customerLastLogin"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["customerLastLogin"].ToString());
            customers.customerLastPWChanged = dt.Rows[0]["customerLastPWChanged"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["customerLastPWChanged"].ToString());
            customers.customerOldPW1 = dt.Rows[0]["customerOldPW1"].ToString();
            customers.customerOldPW2 = dt.Rows[0]["customerOldPW2"].ToString();
            customers.customerOldPW3 = dt.Rows[0]["customerOldPW3"].ToString();
            customers.customerValidateCode = dt.Rows[0]["customerValidateCode"].ToString();
            customers.customerMsg = dt.Rows[0]["customerMsg"].ToString();
            customers.customerSafeQ1 = dt.Rows[0]["customerSafeQ1"].ToString();
            customers.customerSafeQ2 = dt.Rows[0]["customerSafeQ2"].ToString();
            customers.customerSafeQ3 = dt.Rows[0]["customerSafeQ3"].ToString();
            customers.customerSafeA1 = dt.Rows[0]["customerSafeA1"].ToString();
            customers.customerSafeA2 = dt.Rows[0]["customerSafeA2"].ToString();
            customers.customerSafeA3 = dt.Rows[0]["customerSafeA3"].ToString();
            customers.disablebranch = dt.Rows[0]["disablebranch"].ToString();
            customers.packagecode = dt.Rows[0]["packagecode"].ToString();
            customers.customerBudget = double.Parse(dt.Rows[0]["customerBudget"].ToString());
            customers.customerorderstatus = dt.Rows[0]["customerorderstatus"].ToString();
            return customers;
        }
        /// <summary>
        /// 查找所有客户的信息
        /// </summary>
        /// <returns></returns>

        public System.Data.DataTable CustomerSelectAll()
        {
            return sql.ExecuteDataSet("select * from tab_customers").Tables[0];
        }
/// <summary>
/// 删除客户的信息
/// </summary>
/// <param name="customerID"></param>
/// <returns></returns>
        public int Delete(int customerID)
        {
            return sql.ExecuteNonQuery("delete from tab_customers where customerID=" + customerID);
        }
        /// <summary>
        /// 修改客户的信息
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>

        public int update(Model.tab_customers cus)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_customers set ");
            strsql.AppendFormat(" customerCode ='{0}',", cus.customerCode);
            strsql.AppendFormat(" customerName =N'{0}',", cus.customerName);
            strsql.AppendFormat(" customerEmail ='{0}',", cus.customerEmail);
            strsql.AppendFormat(" customerPrivateEmail ='{0}',", cus.customerPrivateEmail);
            strsql.AppendFormat(" customerMobile ='{0}',", cus.customerMobile);
            strsql.AppendFormat(" customerTel ='{0}',", cus.customerTel);
            strsql.AppendFormat(" customerProvince =N'{0}',", cus.customerProvince);
            strsql.AppendFormat(" customerCity =N'{0}',", cus.customerCity);
            strsql.AppendFormat(" customerZone =N'{0}',", cus.customerZone);
            strsql.AppendFormat(" customerAddress =N'{0}',", cus.customerAddress);
            strsql.AppendFormat(" customerAllAddr =N'{0}',", cus.customerAllAddr);
            strsql.AppendFormat(" customerDefaultAddr =N'{0}',", cus.customerDefaultAddr);
            strsql.AppendFormat(" customerGender =N'{0}',", cus.customerGender);
            strsql.AppendFormat(" customerMarriageStatus =N'{0}',", cus.customerMarriageStatus);
            strsql.AppendFormat(" customerDOB ={0},", cus.customerDOB == baddate ? "null" : "'" + cus.customerDOB.ToString() + "'");
            strsql.AppendFormat(" customerNation =N'{0}',", cus.customerNation);
            strsql.AppendFormat(" customerIDcard ='{0}',", cus.customerIDcard);
            strsql.AppendFormat(" customerCompany =N'{0}',", cus.customerCompany);
            strsql.AppendFormat(" customerCompanycode ='{0}',", cus.customerCompanycode);
            strsql.AppendFormat(" customerClass =N'{0}',", cus.customerClass);
            strsql.AppendFormat(" customerCompanyTel ='{0}',", cus.customerCompanyTel);
            strsql.AppendFormat(" customerCompanyProvince =N'{0}',", cus.customerCompanyProvince);
            strsql.AppendFormat(" customerCompanyCity =N'{0}',", cus.customerCompanyCity);
            strsql.AppendFormat(" customerCompanyAddress =N'{0}',", cus.customerCompanyAddress);
            strsql.AppendFormat(" customerCompanyZone =N'{0}',", cus.customerCompanyZone);
            strsql.AppendFormat(" customerCompanyBU =N'{0}',", cus.customerCompanyBU);
            strsql.AppendFormat(" customerVIP =N'{0}',", cus.customerVIP);
            strsql.AppendFormat(" customerBalance ='{0}',", cus.customerBalance);
            strsql.AppendFormat(" customerPwd ='{0}',", cus.customerPwd);
            strsql.AppendFormat(" customerLastLogin ={0},", cus.customerLastLogin == baddate ? "null" : "'" + cus.customerLastLogin.ToString() + "'");
            strsql.AppendFormat(" customerLastPWChanged ={0},", cus.customerLastPWChanged == baddate ? "null" : "'" + cus.customerLastPWChanged.ToString() + "'");
            strsql.AppendFormat(" customerOldPW1 ='{0}',", cus.customerOldPW1);
            strsql.AppendFormat(" customerOldPW2 ='{0}',", cus.customerOldPW2);
            strsql.AppendFormat(" customerOldPW3 ='{0}',", cus.customerOldPW3);
            strsql.AppendFormat(" customerValidateCode ='{0}',", cus.customerValidateCode);
            strsql.AppendFormat(" customerMsg =N'{0}',", cus.customerMsg);
            strsql.AppendFormat(" customerSafeQ1 =N'{0}',", cus.customerSafeQ1);
            strsql.AppendFormat(" customerSafeQ2 =N'{0}',", cus.customerSafeQ2);
            strsql.AppendFormat(" customerSafeQ3 =N'{0}',", cus.customerSafeQ3);
            strsql.AppendFormat(" customerSafeA1 =N'{0}',", cus.customerSafeA1);
            strsql.AppendFormat(" customerSafeA2 =N'{0}',", cus.customerSafeA2);
            strsql.AppendFormat(" customerSafeA3 =N'{0}',", cus.customerSafeA3);
            strsql.AppendFormat(" disablebranch =N'{0}',", cus.disablebranch.Replace("'","''"));
            strsql.AppendFormat(" packagecode =N'{0}',", cus.packagecode);
            strsql.AppendFormat(" customerBudget ='{0}',", cus.customerBudget);
            strsql.AppendFormat(" customerorderstatus =N'{0}'", cus.customerorderstatus);
            strsql.AppendFormat(" where customerID={0}", cus.customerID);

            return sql.ExecuteNonQuery(strsql.ToString());

        }
        public DataTable CustomerSelect(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }



        public double getbalance(int id)
        {
            return Convert.ToDouble(sql.ExecuteSc("select customerBalance from tab_customers where customerID=" + id ));
        }

        #endregion
    }
}
