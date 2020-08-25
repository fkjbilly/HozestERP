
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-10-12 10:51:23
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
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public partial class XMExpressManagement : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the ExpressID
        /// </summary>
        public Nullable<int> ExpressID { get; set; }

        /// <summary>
        /// Gets or sets the CourierNumber
        /// </summary>
        public string CourierNumber { get; set; }

        /// <summary>
        /// Gets or sets the DepartmentID
        /// </summary>
        public Nullable<int> DepartmentID { get; set; }

        /// <summary>
        /// Gets or sets the SenderID
        /// </summary>
        public Nullable<int> SenderID { get; set; }

        /// <summary>
        /// Gets or sets the SendDate
        /// </summary>
        public Nullable<System.DateTime> SendDate { get; set; }

        /// <summary>
        /// Gets or sets the ReceivingName
        /// </summary>
        public string ReceivingName { get; set; }

        /// <summary>
        /// Gets or sets the ReceivingCompany
        /// </summary>
        public string ReceivingCompany { get; set; }

        /// <summary>
        /// Gets or sets the ReceivingTel
        /// </summary>
        public string ReceivingTel { get; set; }

        /// <summary>
        /// Gets or sets the Province
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the County
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        public Nullable<decimal> Price { get; set; }

        /// <summary>
        /// Gets or sets the Remarks
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets the PrintCount
        /// </summary>
        public Nullable<int> PrintCount { get; set; }

        /// <summary>
        /// Gets or sets the PrintDate
        /// </summary>
        public Nullable<System.DateTime> PrintDate { get; set; }

        /// <summary>
        /// Gets or sets the Goods
        /// </summary>
        public string Goods { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        #endregion
        #region Custom Properties

        public string ReceivingAddress
        {
            get
            {
                return this.Province + this.City + this.County + this.Address;
            }
        }

        public string ExpressName
        {
            get
            {
                string value = "";
                if (this.ExpressID != null)
                {
                    var list = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomByLogisticId(this.ExpressID.Value.ToString());//快递公司
                    if (list != null)
                    {
                        value = list.LogisticsName;
                    }
                }
                return value;
            }
        }

        public string SenderName
        {
            get
            {
                string value = "";
                if (this.SenderID != null)
                {
                    var Info = IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID((int)this.SenderID);
                    if (Info != null)
                    {
                        value = Info.FullName;
                    }
                }
                return value;
            }
        }

        public string DepartmentName
        {
            get
            {
                string value = "";
                if (this.DepartmentID != null)
                {
                    var Department = IoC.Resolve<IEnterpriseService>().GetDepartmentById((int)this.DepartmentID);
                    if (Department != null)
                    {
                        value = Department.DepName;
                    }
                }
                return value;
            }
        }

        #endregion
    }
}
