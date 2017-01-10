using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Bll
{
    public class reserveexam
    {
        static DBunit.SQLAccess dbsql = new DBunit.SQLAccess();
        static Bll.CustomerBll Cb = new Bll.CustomerBll();
        static Bll.SupplierBll sb = new Bll.SupplierBll();
        static Bll.companyBll comb = new Bll.companyBll();
    
        public static DataTable getexamprovince(string CompanyName)
        {
            return dbsql.ExecuteDataSet("select name from province where name  in (" + comb.getAvaiSuppProv(CompanyName) + ")").Tables[0];
        }
        public static DataTable getexamcity(string CompanyName, string com_ProvinceText)
        {
            return dbsql.ExecuteDataSet(string.Format("select name from city where provinceId in (select code from province where name='{0}') and name  in ({1})", com_ProvinceText, comb.getAvaiSuppCity(CompanyName))).Tables[0];
        }

        public static DataTable getexamprovinceRel(string CompanyName)
        {
            return dbsql.ExecuteDataSet("select name from province where name  in (" + comb.getAvaiSuppProvRel(CompanyName) + ")").Tables[0];
        }
        public static DataTable getexamcityRel(string CompanyName, string com_ProvinceText)
        {
            return dbsql.ExecuteDataSet(string.Format("select name from city where provinceId in (select code from province where name='{0}') and name  in ({1})", com_ProvinceText, comb.getAvaiSuppCityRel(CompanyName))).Tables[0];
        }

        public static DataTable getbranchlist(Model.tab_customers modelCu, string Province, string city, string supplier)
        {
            string s = "select * from tab_suppliers where id in (" + comb.getavailablesupplier(modelCu.customerCompany)
            + ") and province like N'" + Province + "'";
            if (city!="")
            {
                s += " and city like N'" + city + "'";
            }
            if (supplier!="")
            {
                s += " and supplier=N'" + supplier + "'";
            }

            if (modelCu.disablebranch != "")
            {
                s += " and supplier not in (" + modelCu.disablebranch + ")";
            }
            return sb.GetAny(s);
        }

        public static DataTable getbranchlistRel(Model.tab_customers modelCu, string Province, string city, string supplier)
        {
            string s = "select * from tab_suppliers where id in (" + comb.getavailablesupplierRel(modelCu.customerCompany)
            + ") and province like N'" + Province + "'";
            if (city != "")
            {
                s += " and city like N'" + city + "'";
            }
            if (supplier != "")
            {
                s += " and supplier=N'" + supplier + "'";
            }

            if (modelCu.disablebranch != "")
            {
                s += " and supplier not in (" + modelCu.disablebranch + ")";
            }
            return sb.GetAny(s);
        }


        public static string branchaddress(string examBranch, string city)
        {
            return sb.GetAny("select address from tab_suppliers where supplier+' '+ branch ='" + examBranch + "' and city='"+ city+"'").Rows[0][0].ToString();
        }
    }
}
