
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
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMSaleInfo : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Ref
        /// </summary>
        public string Ref { get; set; }
        /// <summary>
        /// Gets or sets the OrderInfoID
        /// </summary>
        public int OrderInfoID { get; set; }
        /// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> ProjectId { get; set; }
        /// <summary>
        /// Gets or sets the CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets the Tel
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// Gets or sets the SaleAddress
        /// </summary>
        public string SaleAddress { get; set; }
        /// <summary>
        /// Gets or sets the SaleMoney
        /// </summary>
        public Nullable<decimal> SaleMoney { get; set; }

        /// <summary>
        /// Gets or sets the ReceivingType
        /// </summary>
        public Nullable<int> ReceivingType { get; set; }
        /// <summary>
        /// 快递费
        /// </summary>
        public Nullable<decimal> ExpressFee { get; set; }
        /// <summary>
        /// 配件费
        /// </summary>
        public Nullable<decimal> PartsFee { get; set; }
        /// <summary>
        /// 安装费
        /// </summary>
        public Nullable<decimal> InstallFee { get; set; }
        /// <summary>
        /// Gets or sets the BillStatus
        /// </summary>
        public Nullable<int> BillStatus { get; set; }

        /// <summary>
        /// Gets or sets the FinancialStatus
        /// </summary>
        public Nullable<bool> FinancialStatus { get; set; }

        /// <summary>
        /// Gets or sets the Remarks
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets the BizUserId
        /// </summary>
        public Nullable<int> BizUserId { get; set; }

        /// <summary>
        /// Gets or sets the BizDt
        /// </summary>
        public Nullable<System.DateTime> BizDt { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

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

        #endregion
        #region Custom Properties

        public string ProjectName
        {
            get
            {
                string result = "";
                if (this.ProjectId != null && this.ProjectId > 0)
                {
                    var Project = IoC.Resolve<IXMProjectService>().GetXMProjectById(this.ProjectId.Value);
                    if (Project != null)
                    {
                        result = Project.ProjectName;
                    }
                }
                return result;
            }
        }

        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_SaleInfoProductDetails list
        /// </summary>
        public virtual ICollection<XMSaleInfoProductDetails> XM_SaleInfoProductDetails { get; set; }

        #endregion
    }
}
