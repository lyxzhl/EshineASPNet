using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SQLServerDAL
{
    class sql_company:IDAL.companyDal
    {
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        DateTime baddate = DateTime.Parse("1900-01-01");
        public int Add(Model.tab_company company)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_company values (");
            strsql.AppendFormat("N'{0}',", company.CompanyName);
            strsql.AppendFormat("N'{0}',", company.CompanyShortName);
            strsql.AppendFormat("N'{0}',", company.CompanyAbbreviation);
            strsql.AppendFormat("'{0}',", company.Companycode);
            strsql.AppendFormat("'{0}',", company.CompanyTel);
            strsql.AppendFormat("N'{0}',", company.CompanyProvince);
            strsql.AppendFormat("N'{0}',", company.CompanyCity);
            strsql.AppendFormat("N'{0}',", company.CompanyZone);
            strsql.AppendFormat("N'{0}',", company.CompanyAddress);
            strsql.AppendFormat("N'{0}',", company.CompanyLogo);
            strsql.AppendFormat("N'{0}',", company.CompanyAvaiSuppProv);
            strsql.AppendFormat("N'{0}',", company.CompanyAvaiSuppCity);
            strsql.AppendFormat("N'{0}',", company.CompanyAvailableSupplier);
            strsql.AppendFormat("'{0}',", company.canfrontpay);
            strsql.AppendFormat("'{0}',", company.canduallanguage);
            strsql.AppendFormat("'{0}',", company.canenglishservice);
            strsql.AppendFormat("'{0}',", company.canhealthconsult);
            strsql.AppendFormat("'{0}',", company.canreserve);
            strsql.AppendFormat("'{0}',", company.candilivertocompany);
            strsql.AppendFormat("N'{0}',", company.CompanyAvaiSuppProvRel);
            strsql.AppendFormat("N'{0}',", company.CompanyAvaiSuppCityRel);
            strsql.AppendFormat("N'{0}',", company.CompanyAvaiSupplierRel);
            strsql.AppendFormat("{0},", company.reservestartdate == baddate ? "null" : "'" + company.reservestartdate.ToString() + "'");
            strsql.AppendFormat("'{0}',", company.canplatformpay);
            strsql.AppendFormat("N'{0}',", company.standby1);
            strsql.AppendFormat("N'{0}',", company.standby2);
            strsql.AppendFormat("N'{0}',", company.standby3);
            strsql.AppendFormat("N'{0}',", company.currentperiod);
            strsql.AppendFormat("'{0}',", company.canxiya);
            strsql.AppendFormat("N'{0}',", company.xiyaSupplier);
            strsql.AppendFormat("'{0}',", company.canhomepayge);
            strsql.AppendFormat("'{0}',", company.canuploadreport);
            strsql.AppendFormat("N'{0}',", company.standby4);
            strsql.AppendFormat("N'{0}',", company.standby5);
            strsql.AppendFormat("N'{0}',", company.standby6);
            strsql.AppendFormat("N'{0}',", company.standby7);
            strsql.AppendFormat("N'{0}',", company.standby8);
            strsql.AppendFormat("N'{0}'", company.standby9);
            strsql.Append(") select SCOPE_IDENTITY()");
            return Convert.ToInt32(sql.ExecuteSc(strsql.ToString()));
        }


        public Model.tab_company getcompany(Model.tab_company company1)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_company where ");
            strsql.AppendFormat("id='{0}'", company1.id);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            Model.tab_company company = new Model.tab_company();
            company.id = company1.id;
            company.CompanyName = dt.Rows[0]["CompanyName"].ToString();
            company.CompanyShortName = dt.Rows[0]["CompanyShortName"].ToString();
            company.CompanyAbbreviation = dt.Rows[0]["CompanyAbbreviation"].ToString();
            company.Companycode = dt.Rows[0]["Companycode"].ToString();
            company.CompanyTel = dt.Rows[0]["CompanyTel"].ToString();
            company.CompanyProvince = dt.Rows[0]["CompanyProvince"].ToString();
            company.CompanyCity = dt.Rows[0]["CompanyCity"].ToString();
            company.CompanyZone = dt.Rows[0]["CompanyZone"].ToString();
            company.CompanyAddress = dt.Rows[0]["CompanyAddress"].ToString();
            company.CompanyLogo = dt.Rows[0]["CompanyLogo"].ToString();
            company.CompanyAvaiSuppProv = dt.Rows[0]["CompanyAvaiSuppProv"].ToString();
            company.CompanyAvaiSuppCity = dt.Rows[0]["CompanyAvaiSuppCity"].ToString();
            company.CompanyAvailableSupplier = dt.Rows[0]["CompanyAvailableSupplier"].ToString();
            company.canfrontpay = dt.Rows[0]["canfrontpay"].ToString();
            company.canduallanguage = dt.Rows[0]["canduallanguage"].ToString();
            company.canenglishservice = dt.Rows[0]["canenglishservice"].ToString();
            company.canhealthconsult = dt.Rows[0]["canhealthconsult"].ToString();
            company.canreserve = dt.Rows[0]["canreserve"].ToString();
            company.candilivertocompany = dt.Rows[0]["candilivertocompany"].ToString();
            company.CompanyAvaiSuppProvRel = dt.Rows[0]["CompanyAvaiSuppProvRel"].ToString();
            company.CompanyAvaiSuppCityRel = dt.Rows[0]["CompanyAvaiSuppCityRel"].ToString();
            company.CompanyAvaiSupplierRel = dt.Rows[0]["CompanyAvaiSupplierRel"].ToString();
            company.reservestartdate = dt.Rows[0]["reservestartdate"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["reservestartdate"].ToString());
            company.canplatformpay = dt.Rows[0]["canplatformpay"].ToString();
            company.standby1 = dt.Rows[0]["standby1"].ToString();
            company.standby2 = dt.Rows[0]["standby2"].ToString();
            company.standby3 = dt.Rows[0]["standby3"].ToString();
            company.currentperiod = dt.Rows[0]["currentperiod"].ToString();
            company.canxiya = dt.Rows[0]["canxiya"].ToString();
            company.xiyaSupplier = dt.Rows[0]["xiyaSupplier"].ToString();
            company.canhomepayge = dt.Rows[0]["canhomepayge"].ToString();
            company.canuploadreport = dt.Rows[0]["canuploadreport"].ToString();
            company.standby4 = dt.Rows[0]["standby4"].ToString();
            company.standby5 = dt.Rows[0]["standby5"].ToString();
            company.standby6 = dt.Rows[0]["standby6"].ToString();
            company.standby7 = dt.Rows[0]["standby7"].ToString();
            company.standby8 = dt.Rows[0]["standby8"].ToString();
            company.standby9 = dt.Rows[0]["standby9"].ToString();
            return company;
        }


        public int update(Model.tab_company company)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_company set ");
            strsql.AppendFormat(" CompanyName =N'{0}',", company.CompanyName);
            strsql.AppendFormat(" CompanyShortName =N'{0}',", company.CompanyShortName);
            strsql.AppendFormat(" CompanyAbbreviation =N'{0}',", company.CompanyAbbreviation);
            strsql.AppendFormat(" Companycode ='{0}',", company.Companycode);
            strsql.AppendFormat(" CompanyTel ='{0}',", company.CompanyTel);
            strsql.AppendFormat(" CompanyProvince =N'{0}',", company.CompanyProvince);
            strsql.AppendFormat(" CompanyCity =N'{0}',", company.CompanyCity);
            strsql.AppendFormat(" CompanyZone =N'{0}',", company.CompanyZone);
            strsql.AppendFormat(" CompanyAddress =N'{0}',", company.CompanyAddress);
            strsql.AppendFormat(" CompanyLogo =N'{0}',", company.CompanyLogo);
            strsql.AppendFormat(" CompanyAvaiSuppProv =N'{0}',", company.CompanyAvaiSuppProv);
            strsql.AppendFormat(" CompanyAvaiSuppCity =N'{0}',", company.CompanyAvaiSuppCity);
            strsql.AppendFormat(" CompanyAvailableSupplier =N'{0}',", company.CompanyAvailableSupplier);
            strsql.AppendFormat(" canfrontpay ='{0}',", company.canfrontpay);
            strsql.AppendFormat(" canduallanguage ='{0}',", company.canduallanguage);
            strsql.AppendFormat(" canenglishservice ='{0}',", company.canenglishservice);
            strsql.AppendFormat(" canhealthconsult ='{0}',", company.canhealthconsult);
            strsql.AppendFormat(" canreserve ='{0}',", company.canreserve);
            strsql.AppendFormat(" candilivertocompany ='{0}',", company.candilivertocompany);
            strsql.AppendFormat(" CompanyAvaiSuppProvRel =N'{0}',", company.CompanyAvaiSuppProvRel);
            strsql.AppendFormat(" CompanyAvaiSuppCityRel =N'{0}',", company.CompanyAvaiSuppCityRel);
            strsql.AppendFormat(" CompanyAvaiSupplierRel =N'{0}',", company.CompanyAvaiSupplierRel);
            strsql.AppendFormat(" reservestartdate ={0},", company.reservestartdate == baddate ? "null" : "'" + company.reservestartdate.ToString() + "'");
            strsql.AppendFormat(" canplatformpay ='{0}',", company.canplatformpay);
            strsql.AppendFormat(" standby1 =N'{0}',", company.standby1);
            strsql.AppendFormat(" standby2 =N'{0}',", company.standby2);
            strsql.AppendFormat(" standby3 =N'{0}',", company.standby3);
            strsql.AppendFormat(" currentperiod =N'{0}',", company.currentperiod);
            strsql.AppendFormat(" canxiya ='{0}',", company.canxiya);
            strsql.AppendFormat(" xiyaSupplier =N'{0}',", company.xiyaSupplier);
            strsql.AppendFormat(" canhomepayge ='{0}',", company.canhomepayge);
            strsql.AppendFormat(" canuploadreport ='{0}',", company.canuploadreport);
            strsql.AppendFormat(" standby4 =N'{0}',", company.standby4);
            strsql.AppendFormat(" standby5 =N'{0}',", company.standby5);
            strsql.AppendFormat(" standby6 =N'{0}',", company.standby6);
            strsql.AppendFormat(" standby7 =N'{0}',", company.standby7);
            strsql.AppendFormat(" standby8 =N'{0}',", company.standby8);
            strsql.AppendFormat(" standby9 =N'{0}'", company.standby9);
            strsql.AppendFormat(" where id={0}", company.id);
            return sql.ExecuteNonQuery(strsql.ToString());
        }


        public int Delete(int id)
        {
            return sql.ExecuteNonQuery("delete from tab_company where id=" + id);
        }
        public DataTable Select(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }




    }
}
