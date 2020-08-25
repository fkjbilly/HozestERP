
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-02-10 09:55:45
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
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMPremiums : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the QuestionID
        /// </summary>
        public string QuestionDetailID { get; set; }

        /// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets the WantId
        /// </summary>
        public string WantId { get; set; }

        /// <summary>
        /// 是否评价
        /// </summary>
        public Nullable<bool> IsEvaluation { get; set; }

        /// <summary>
        /// 确认评价时间
        /// </summary>
        public Nullable<System.DateTime> EvaluationDate { get; set; }

        /// <summary>
        /// 赠品状态
        /// </summary>
        public Nullable<int> PremiumsStatus { get; set; }


        /// <summary>
        /// 返现金额类型：赠品：11、赔付:10
        /// </summary>
        public Nullable<int> PremiumsTypeId { get; set; }

        /// <summary>
        /// 赔付方
        /// </summary>
        public Nullable<int> PaymentPerson { get; set; }

        /// <summary>
        /// Gets or sets the ActivityExplanation
        /// </summary>
        public string ActivityExplanation { get; set; }

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
        ///审核人（店长改项目）
        /// </summary>
        public Nullable<int> ManagerPeople { get; set; }

        /// <summary>
        ///审核状态（店长改项目）
        /// </summary>
        public Nullable<int> ManagerStatus { get; set; }

        /// <summary>
        /// 审核时间（店长改项目）
        /// </summary>
        public Nullable<System.DateTime> ManagerTime { get; set; }

        /// <summary>
        /// 店长(改运营)未审核通过说明
        /// </summary>
        public string ManagerExplanation { get; set; }

        /// <summary>
        /// 审核人（总监）
        /// </summary>
        public Nullable<int> DirectorPeople { get; set; }

        /// <summary>
        /// 审核状态（总监）
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

        /// <summary>
        /// 是否排单
        /// </summary>
        public Nullable<bool> IsSingleRow { get; set; }

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

        /// <summary>
        /// Gets or sets the EvaluationID
        /// </summary>
        public Nullable<int> EvaluationID { get; set; }

        /// <summary>
        /// Gets or sets the NoOrderNickId
        /// </summary>
        public Nullable<int> NoOrderNickId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        public int NoOrderProjectId
        {
            get
            {
                if (this.NoOrderNickId != null)
                {
                    var Nick = IoC.Resolve<IXMNickService>().GetXMNickByID((int)this.NoOrderNickId);
                    if (Nick != null)
                    {
                        return (int)Nick.ProjectId;
                    }
                    return -1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public string EvaluationName
        {
            get
            {
                if (this.EvaluationID != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID((int)this.EvaluationID).FullName;
                }
                else
                {
                    return "";
                }
            }
        }

        #endregion
        #region Custom Properties

        public string CustomerServiceRemark
        {
            get
            {
                if (this.OrderCode != null)
                {
                    return IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(this.OrderCode).CustomerServiceRemark;
                }
                else
                {
                    return "";
                }
            }
        }

        public string PaymentPersonName
        {
            get
            {
                if (this.PaymentPerson != null && this.PaymentPerson != -1)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID((int)this.PaymentPerson).CodeName;
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
