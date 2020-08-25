
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2014-12-25 14:25:59
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
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class AdvanceApplicationDetail: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the AdvanceId
        /// </summary>
        public Nullable<int> AdvanceId { get; set; }
    
    	/// <summary>
        /// Gets or sets the AdvanceTypeId
        /// </summary>
        public Nullable<int> AdvanceTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PayTypeId
        /// </summary>
        public Nullable<int> PayTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the TheAdvanceMoney
        /// </summary>
        public Nullable<decimal> TheAdvanceMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the RecipientsId
        /// </summary>
        public Nullable<int> RecipientsId { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public Nullable<int> CreatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateTime
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdatorID
        /// </summary>
        public Nullable<int> UpdatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateTime { get; set; }

        #endregion
        #region Custom Properties


        /// <summary>
        /// 暂支申请类型
        /// </summary>
        public CodeList AdvanceTypeName
        {
            get
            {
                if (this.AdvanceTypeId != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.AdvanceTypeId.Value);
                }
                else
                {

                    return null;
                }
            }
        }

        /// <summary>
        /// 领/还款类型
        /// </summary>
        public CodeList PayTypeName
        {
            get
            {
                if (this.PayTypeId != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PayTypeId.Value);
                }
                else
                {

                    return null;
                }
            }
        }

        /// <summary>
        /// 领/还款人
        /// </summary>
        public CustomerInfo RecipientsFunName
        {
            get
            {
                if (this.RecipientsId != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.RecipientsId.Value);
                }
                else
                {

                    return null;
                }
            }
        }

    	
        #endregion
    }
}
