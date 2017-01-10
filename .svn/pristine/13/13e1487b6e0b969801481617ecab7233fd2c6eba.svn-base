using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SQLServerDAL
{
    class sql_emp:IDAL.empDal
    {
        #region empDal 成员
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        public System.Data.DataTable GetAll()
        {
            return sql.ExecuteDataSet("select * from tab_emps join tab_roles on tab_emps.roleID=tab_roles.roleID").Tables[0];
        }

        public System.Data.DataTable Getany(string id)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_emps where ");
            strsql.AppendFormat("empID='{0}'",id);
            return sql.ExecuteDataSet(strsql.ToString()).Tables[0];
       
        }
        public System.Data.DataTable GetModel(Model.tab_emps tem)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select tab_emps.*,tab_roles.roleName  from tab_emps join tab_roles on tab_emps.roleID=tab_roles.roleID where ");
            strsql.AppendFormat("empName='{0}' ", tem.empName);
            strsql.AppendFormat("and empPwd='{0}'", tem.empPwd);
            return sql.ExecuteDataSet(strsql.ToString()).Tables[0];
        }

        public int Delete(int id)
        {
            return sql.ExecuteNonQuery("delete from tab_emps where empID=" + id);
        }

        public int Update(Model.tab_emps mopower)
        {
           StringBuilder strsql = new StringBuilder();
           strsql.Append("update tab_emps set ");
           strsql.AppendFormat("empName='{0}',", mopower.empName);
           strsql.AppendFormat("empPwd='{0}',", mopower.empPwd);
           strsql.AppendFormat("roleID='{0}'", mopower.Roles);
           strsql.AppendFormat("where empID='{0}'", mopower.empID);
       

           return sql.ExecuteNonQuery(strsql.ToString());
        }
        public int insert(Model.tab_emps mopower)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_emps(empName,empPwd,roleID) values(");
            strsql.AppendFormat("'{0}',", mopower.empName);
            strsql.AppendFormat("'{0}',", mopower.empPwd);
            strsql.AppendFormat("'{0}')", mopower.Roles);
            return sql.ExecuteNonQuery(strsql.ToString());
        }
        #endregion
    }
}
