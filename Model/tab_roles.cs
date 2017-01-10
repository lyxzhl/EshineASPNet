using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class tab_roles
    {
        private int _roleID=0;
        private string _roleName="";
        private string _roleInfo="";
        private string _roleContent = "";

        public string RoleContent
        {
            get { return _roleContent; }
            set { _roleContent = value; }
        }

        /// <summary>
        /// 权限信息
        /// </summary>
        public string RoleInfo
        {
            get { return _roleInfo; }
            set { _roleInfo = value; }
        }

        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }
    }
}
