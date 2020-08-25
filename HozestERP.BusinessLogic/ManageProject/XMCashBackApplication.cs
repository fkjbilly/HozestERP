
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-01-19 14:14:45
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMCashBackApplication: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the QuestionDetailID
        /// </summary>
        public string QuestionDetailID { get; set; }
    
    	/// <summary>
        /// 申请类型：返现、赔付
        /// </summary>
        public Nullable<int> ApplicationTypeId { get; set; }
    	/// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the WantNo
        /// </summary>
        public string WantNo { get; set; }

        /// <summary>
        /// 赔付方
        /// </summary>
        public Nullable<int> PaymentPerson { get; set; }
    
    	/// <summary>
        /// Gets or sets the BuyerName
        /// </summary>
        public string BuyerName { get; set; }
    
    	/// <summary>
        /// Gets or sets the CashBackMoney
        /// </summary>
        public Nullable<decimal> CashBackMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the BuyerAlipayNo
        /// </summary>
        public string BuyerAlipayNo { get; set; }
    
    	/// <summary>
        /// 返现状态
        /// </summary>
        public Nullable<int> CashBackStatus { get; set; }

        /// <summary>
        /// 返现金额类型：返现、赔付
        /// </summary>
        public Nullable<int> CashBackTypeId { get; set; }

        /// <summary>
        /// 无订单店铺ID
        /// </summary>
        public int? NickID { get; set; }

        /// <summary>
        /// 无订单项目ID
        /// </summary>
        public int? ProjectID { get; set; }

        /// <summary>
        /// 审核人（财务）
        /// </summary>
        public Nullable<int> FinancePeople { get; set; }
    
    	/// <summary>
        /// 财务是否审核
        /// </summary>
        public Nullable<bool> FinanceIsAudit { get; set; }
    
    	/// <summary>
        /// 审核时间（财务）
        /// </summary>
        public Nullable<System.DateTime> FinanceTime { get; set; }
    
    	/// <summary>
        /// 审核人（店长改项目）
        /// </summary>
        public Nullable<int> ManagerPeople { get; set; }
    
    	/// <summary>
        /// 审核状态（店长改项目）
        /// </summary>
        public Nullable<int> ManagerStatus { get; set; }
    
    	/// <summary>
        /// 审核时间（店长改项目）
        /// </summary>
        public Nullable<System.DateTime> ManagerTime { get; set; }
    
    	/// <summary>
        /// 未审核通过说明（店长改项目）
        /// </summary>
        public string ManagerExplanation { get; set; }
    
    	/// <summary>
        /// 审核人（总监）
        /// </summary>
        public Nullable<int> DirectorPeople { get; set; }
    
    	/// <summary>
        ///审核状态（总监
        /// </summary>
        public Nullable<int> DirectorStatus { get; set; }
    
    	/// <summary>
        /// 审核时间（总监）
        /// </summary>
        public Nullable<System.DateTime> DirectorTime { get; set; }
    
    	/// <summary>
        /// 总监未审核说明
        /// </summary>
        public string DirectorExplanation { get; set; }
         
        ///// <summary>
        ///// 情况说明
        ///// </summary>
        //public string FactSheets { get; set; }
         
    	/// <summary>
        /// 是否删除 true 删除；false 不删除
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

        public string PaymentPersonName
        {
            get
            {
                if (this.PaymentPerson != null)
                {
                    var codeEntity = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID((int)this.PaymentPerson);
                    if(codeEntity != null)
                    {
                        return codeEntity.CodeName;
                    }
                    else
                    {
                        return "";
                    }
                    
                }
                else
                {
                    return "";
                }
            }
        }
    	
        #endregion
    }
}
