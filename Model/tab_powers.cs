using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户权限信息
    /// </summary>
    public class tab_powers
    {
        private string _powerUrl;

        private int _powerPID;

        /// <summary>
        /// 权限父ID
        /// </summary>
        public int PowerPID
        {
            get { return _powerPID; }
            set { _powerPID = value; }
        }
        /// <summary>
        /// 指定页面路径
        /// </summary>
        public string PowerUrl
        {
            get { return _powerUrl; }
            set { _powerUrl = value; }
        }

        private int _powerID;
        /// <summary>
        /// 权限ID
        /// </summary>
        public int PowerID
        {
            get { return _powerID; }
            set { _powerID = value; }
        }
        private string _powerName;
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PowerName
        {
            get { return _powerName; }
            set { _powerName = value; }
        }
        private string _powerContent;
        /// <summary>
        /// 权限描述
        /// </summary>
        public string PowerContent
        {
            get { return _powerContent; }
            set { _powerContent = value; }
        }
    }
}
