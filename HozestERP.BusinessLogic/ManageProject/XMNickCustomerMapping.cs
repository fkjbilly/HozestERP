
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 方银朗
** 创建日期:2013-09-05 14:38:49
** 修改人:
** 修改日期:
** 描 述: 
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMNickCustomerMapping : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the NickCustomerID
        /// </summary>
        public int NickCustomerID { get; set; }

        /// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }

        /// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public Nullable<int> CustomerID { get; set; }

        /// <summary>
        /// Gets or sets the CustomerTypeID
        /// </summary>
        public Nullable<int> CustomerTypeID { get; set; }

        /// <summary>
        /// Gets or sets the Created
        /// </summary>
        public Nullable<System.DateTime> Created { get; set; }

        /// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public Nullable<int> CreatorID { get; set; }

        /// <summary>
        /// Gets or sets the Updated
        /// </summary>
        public Nullable<System.DateTime> Updated { get; set; }

        /// <summary>
        /// Gets or sets the UpdatorID
        /// </summary>
        public Nullable<int> UpdatorID { get; set; }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Nullable<int> Id { get; set; }

        #endregion
        #region Custom Properties

        /// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName
        {
            get
            {
                var customerInfo = IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID((int)this.CustomerID);
                if (customerInfo != null)
                    return customerInfo.FullName;
                return string.Empty;
            }

        }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentId
        {
            get
            {
                var customerInfo = IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID((int)this.CustomerID);
                if (customerInfo != null)
                    return customerInfo.DepartmentID.ToString();
                return string.Empty;
            }
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName
        {
            get
            {
                if(!string.IsNullOrEmpty(this.DepartmentId))
                {
                    var department = IoC.Resolve<IEnterpriseService>().GetDepartmentById(Convert.ToInt16(this.DepartmentId));
                    if (department != null)
                        return department.DepName;
                }
                return string.Empty;
            }
        }


        #endregion
    }
}
