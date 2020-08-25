
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-05-09 16:59:04
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

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMAdjustedInfo : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the PdInfoId
        /// </summary>
        public Nullable<int> PdInfoId { get; set; }

        /// <summary>
        /// Gets or sets the Ref
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// Gets or sets the WarehouseId
        /// </summary>
        public Nullable<int> WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the SaleMoney
        /// </summary>
        public Nullable<decimal> SaleMoney { get; set; }

        /// <summary>
        /// Gets or sets the MoneywithTax
        /// </summary>
        public Nullable<decimal> MoneywithTax { get; set; }

        /// <summary>
        /// Gets or sets the ReceivingType
        /// </summary>
        public Nullable<int> ReceivingType { get; set; }

        /// <summary>
        /// Gets or sets the BizUserId
        /// </summary>
        public Nullable<int> BizUserId { get; set; }

        /// <summary>
        /// Gets or sets the BizDt
        /// </summary>
        public Nullable<System.DateTime> BizDt { get; set; }

        /// <summary>
        /// Gets or sets the BillMemo
        /// </summary>
        public string BillMemo { get; set; }

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
        /// Gets or sets the FinancialStatus
        /// </summary>
        public Nullable<bool> FinancialStatus { get; set; }

        /// <summary>
        /// Gets or sets the AuditTime
        /// </summary>
        public Nullable<System.DateTime> AuditTime { get; set; }

        #endregion
        #region Custom Properties

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayType
        {
            get
            {
                string payType = "";
                if (this.ReceivingType != null)
                {
                    var code = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.ReceivingType.Value);
                    if (code != null)
                    {
                        payType = code.CodeName;
                    }
                }
                return payType;
            }
        }


        public string WareHouseName
        {
            get
            {
                string wareHourseName = "";
                if (this.WarehouseId != null)
                {
                    var wareHourses = IoC.Resolve<IXMWareHousesService>().GetXMWareHousesById(this.WarehouseId.Value);
                    if (wareHourses != null)
                    {
                        wareHourseName = wareHourses.Name;
                    }
                }
                return wareHourseName;
            }
        }

        public int ProjectId
        {
            get
            {
                int projectId = 1;
                if (this.WarehouseId != null)
                {
                    var wareHourses = IoC.Resolve<IXMWareHousesService>().GetXMWareHousesById(this.WarehouseId.Value);
                    if (wareHourses != null)
                    {
                        projectId = wareHourses.ProjectId.Value;
                    }
                }
                return projectId;
            }
        }

        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_AdjustedProductDetail list
        /// </summary>
        public virtual ICollection<XMAdjustedProductDetail> XM_AdjustedProductDetail { get; set; }

        #endregion
    }
}
