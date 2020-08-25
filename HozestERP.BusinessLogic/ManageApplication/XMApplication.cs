
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-08-04 09:20:44
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
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageApplication
{
    public partial class XMApplication : BaseEntity
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
        /// 4 未发货退款,5 先退货后退款,6 换货,9 售后,10 售中,8 退运费,7 先退款后退货
        /// </summary>
        public Nullable<int> ApplicationType { get; set; }

        /// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> NickId { get; set; }

        /// <summary>
        /// 物流费用
        /// </summary>
        public Nullable<decimal> LogisticsCost { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public Nullable<decimal> Amount { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> ReturnCategoryID { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> FactoryID { get; set; }

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
        /// Gets or sets the IsSingleRow
        /// </summary>
        public Nullable<bool> IsSingleRow { get; set; }

        /// <summary>
        /// Gets or sets the FinancialStatus
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


        /// <summary>
        /// 店铺名称
        /// </summary>
        public string NickName
        {
            get
            {
                string result = "";
                if (this.NickId != 0 && this.NickId != null)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId.Value);
                    if (nick != null)
                    {
                        result = nick.nick;
                    }
                }
                return result;
            }

        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get
            {
                string result = "";
                if (this.NickId != 0 && this.NickId != null)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetProjectNameByID(this.NickId.Value);
                    if (nick != null)
                    {
                        result = nick.ProjectName;
                    }
                }
                return result;
            }

        }

        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatformType
        {
            get
            {
                string result = "";
                if (this.PlatformTypeId.HasValue)
                {
                    var codelist = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PlatformTypeId.Value);
                    if (codelist != null)
                    {
                        result = codelist.CodeName;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 项目Id
        /// </summary>
        public int ProjectId
        {
            get
            {
                int result = 0;
                if (this.NickId.HasValue)
                {
                    var Info = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId.Value);
                    if (Info != null)
                    {
                        result = (int)Info.ProjectId;
                    }
                }
                return result;
            }
        }

        #endregion
    }
}
