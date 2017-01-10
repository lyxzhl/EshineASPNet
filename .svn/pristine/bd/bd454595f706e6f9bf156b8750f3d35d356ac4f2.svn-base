using System;
using System.Collections.Generic;
using System.Text;

namespace SQLServerDAL
{
    class sql_roles : IDAL.RolesDal
    {
        #region RolesDal 成员
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        public System.Data.DataTable GetAll()
        {
            return sql.ExecuteDataSet("select * from tab_roles").Tables[0];
        }

        public System.Data.DataTable GetAny(Model.tab_roles roles)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_roles where ");
            strsql.AppendFormat("RoleID='{0}'", roles.RoleID);
            strsql.AppendFormat("or RoleInfo='{0}'", roles.RoleInfo);
            strsql.AppendFormat("or RoleName='{0}'", roles.RoleName);
            return sql.ExecuteDataSet(strsql.ToString()).Tables[0];
        }

        public int Add(Model.tab_roles roles)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_roles(RoleInfo,RoleName) values( ");
            strsql.AppendFormat("'{0}',", roles.RoleInfo);
            strsql.AppendFormat("'{0}')", roles.RoleName);
            return sql.ExecuteNonQuery(strsql.ToString());
        }

        public int Delete(int powerID)
        {
            return sql.ExecuteNonQuery("delete from tab_powers where powerID=" + powerID);
        }

        public System.Data.DataSet GetPowClass(string sql1, string sql2)
        {
            return sql.ExecuteDataSet(sql1, sql2);
        }
        public int update(Model.tab_roles roles)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_roles set ");
            strsql.AppendFormat("roleName='{0}',", roles.RoleName);
            strsql.AppendFormat("roleContent='{0}',", roles.RoleContent);

            strsql.AppendFormat("roleInfo='{0}' ", roles.RoleInfo);
            strsql.AppendFormat("where roleID={0}", roles.RoleID);
            return sql.ExecuteNonQuery(strsql.ToString());
        }

        #endregion
    }
}
