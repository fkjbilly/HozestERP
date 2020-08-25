
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2017-04-26 15:27:24
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

namespace HozestERP.BusinessLogic.Entity
{
    public partial class XMApplication: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ApplicationNo
        /// </summary>
        public string ApplicationNo { get; set; }
    
    	/// <summary>
        /// Gets or sets the ApplicationType
        /// </summary>
        public Nullable<int> ApplicationType { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public Nullable<decimal> Amount { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsSend
        /// </summary>
        public Nullable<bool> IsSend { get; set; }
    
    	/// <summary>
        /// Gets or sets the SupervisorStatus
        /// </summary>
        public Nullable<bool> SupervisorStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinancialStatus
        /// </summary>
        public Nullable<bool> FinancialStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReturnTime
        /// </summary>
        public Nullable<System.DateTime> ReturnTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinishTime
        /// </summary>
        public Nullable<System.DateTime> FinishTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReservepriceOrder
        /// </summary>
        public string ReservepriceOrder { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remarks
        /// </summary>
        public string Remarks { get; set; }
    
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
    
    	/// <summary>
        /// Gets or sets the IsSingleRow
        /// </summary>
        public Nullable<bool> IsSingleRow { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReturnLogisticsNumber
        /// </summary>
        public string ReturnLogisticsNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the GoodsConfirmSendOut
        /// </summary>
        public Nullable<bool> GoodsConfirmSendOut { get; set; }
    
    	/// <summary>
        /// Gets or sets the GoodsConfirmReturn
        /// </summary>
        public Nullable<bool> GoodsConfirmReturn { get; set; }
    
    	/// <summary>
        /// Gets or sets the MoneyConfirmReturn
        /// </summary>
        public Nullable<bool> MoneyConfirmReturn { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
