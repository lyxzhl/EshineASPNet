using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bll
{
    public class companyBll
    {
        IDAL.companyDal itu = DALFactory.company_Factory.Createusers();
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        public int Add(Model.tab_company company)
        {
            return itu.Add(company);
        }
        public Model.tab_company getcompany(Model.tab_company company1)
        {
            return itu.getcompany(company1);
        }
        public int update(Model.tab_company company)
        {
            return itu.update(company);
        }
        public int Delete(int id)
        {
            return itu.Delete(id);
        }
        public DataTable Select(string ss)
        {
            return itu.Select(ss);
        }
        public string getavailablesupplier(string CompanyName)
        {
            return sql.ExecuteSc("select CompanyAvailableSupplier from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }
        public string getperiod(string CompanyName)
        {
            return sql.ExecuteSc("select currentperiod from tab_company where CompanyName='" + CompanyName + "'  order by id desc").ToString();
        }
        public string getAvaiSuppProv(string CompanyName)
        {
            return sql.ExecuteSc("select CompanyAvaiSuppProv from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }
        public string getAvaiSuppCity(string CompanyName)
        {
            return sql.ExecuteSc("select CompanyAvaiSuppCity from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }
        public string getcanfrontpay(string CompanyName)
        {
            return sql.ExecuteSc("select canfrontpay from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }

        public string getcanduallanguage(string companyname)
        {
            return sql.ExecuteSc("select canduallanguage from tab_company where CompanyName=N'" + companyname + "'").ToString();
        }
        public string getcandilivertocompany(string CompanyName)
        {
            return sql.ExecuteSc("select candilivertocompany from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }

        public string getcanplatformpay(string CompanyName)
        {
            return sql.ExecuteSc("select canplatformpay from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }

        public string getavailablesupplierRel(string CompanyName)
        {
            return sql.ExecuteSc("select CompanyAvaiSupplierRel from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }

        public string getAvaiSuppProvRel(string CompanyName)
        {
            return sql.ExecuteSc("select CompanyAvaiSuppProvRel from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }
        public string getAvaiSuppCityRel(string CompanyName)
        {
            return sql.ExecuteSc("select CompanyAvaiSuppCityRel from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }

        public string getreservestartdate(string CompanyName)
        {
            return sql.ExecuteSc("select reservestartdate from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }
        public string getreserveenddate(string CompanyName)
        {
            return sql.ExecuteSc("select distinct expiredate from tab_package where company='" + CompanyName + "' order by expiredate desc").ToString();
        }
        public string getcompanyname(string CompanyCode)
        {
            return sql.ExecuteSc("select CompanyName from tab_company where Companycode='" + CompanyCode + "'").ToString();
        }
        public string getxiyasupplier(string CompanyName)
        {
            return sql.ExecuteSc("select xiyaSupplier from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }

        public  string getdisplayfuke(string CompanyName)
        {
            return sql.ExecuteSc("select standby3 from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }

        public string getcanhomepayge(string CompanyName)
        {
            return sql.ExecuteSc("select canhomepayge from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }

        public string getcanuploadreport(string CompanyName)
        {
            return sql.ExecuteSc("select canuploadreport from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }

        public string getcandownloadpdf(string CompanyName)
        {
            return sql.ExecuteSc("select standby4 from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }
        public string getcandownloaddianzibaog(string CompanyName)
        {
            return sql.ExecuteSc("select standby5 from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }
        public string getcandownloaddaohang(string CompanyName)
        {
            return sql.ExecuteSc("select standby6 from tab_company where CompanyName='" + CompanyName + "'").ToString();
        }

    }
}
