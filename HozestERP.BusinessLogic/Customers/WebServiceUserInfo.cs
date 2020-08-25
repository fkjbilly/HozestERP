using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public partial class WebServiceUserInfo
    {
        #region Primitive Properties
        
        /// <summary>
        /// 员工ID
        /// </summary>
        public int EmpID { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        #endregion
    }
}
