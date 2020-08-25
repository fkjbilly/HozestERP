
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2017-04-14 10:05:06
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
using HozestERP.BusinessLogic.ManageProductionOrder;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageProductionOrder
{
    public partial class XMProductionOrder : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the NickID
        /// </summary>
        public Nullable<int> NickID { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }

        /// <summary>
        /// Gets or sets the ProductionNumber
        /// </summary>
        public string ProductionNumber { get; set; }

        /// <summary>
        /// Gets or sets the EstimateStorageDate
        /// </summary>
        public Nullable<System.DateTime> EstimateStorageDate { get; set; }

        /// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets the WantID
        /// </summary>
        public string WantID { get; set; }

        /// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryAddress
        /// </summary>
        public string DeliveryAddress { get; set; }

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

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        /// <summary>
        /// Gets or sets the Province
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// Gets or sets the Mobile
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the County
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public Nullable<int> Status { get; set; }

        /// <summary>
        /// Gets or sets the SingleRowStatus
        /// </summary>
        public Nullable<int> SingleRowStatus { get; set; }

        #endregion
        #region Custom Properties

        public int OrderInfoID
        {
            get
            {
                int Id = 1;
                if (!string.IsNullOrEmpty(OrderCode))
                {
                    var orderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(OrderCode);
                    if (orderInfo != null)
                    {
                        Id = orderInfo.ID;
                    }
                }
                return Id;
            }
        }

        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_ProductionOrderDetails list
        /// </summary>
        public virtual ICollection<XMProductionOrderDetails> XM_ProductionOrderDetails { get; set; }

        #endregion
    }
}
