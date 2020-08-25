
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2013-06-14 15:52:32
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

namespace HozestERP.BusinessLogic.ManageProject
{
    [Serializable]
    public partial class XMOrderInfoNew : BaseEntity
    {

        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the NickID
        /// </summary>
        public Nullable<int> NickID { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryTime
        /// </summary>
        public Nullable<System.DateTime> OrderInfoCreateDate { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryTime
        /// </summary>
        public Nullable<System.DateTime> DeliveryTime { get; set; }

        /// <summary>
        /// Gets or sets the PayDate
        /// </summary>
        public Nullable<System.DateTime> PayDate { get; set; }

        /// <summary>
        /// Gets or sets the OrderInfoModified
        /// </summary>
        public Nullable<System.DateTime> OrderInfoModified { get; set; }

        /// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets the JDId
        /// </summary>
        public string JDId { get; set; }

        /// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public Nullable<int> ProductNum { get; set; }

        /// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 县
        /// </summary>
        public string County { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; } 

        /// <summary>
        /// Gets or sets the DeliveryAddress
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// Gets or sets the 备用收货地址
        /// </summary>
        public string DeliveryAddressSpare { get; set; }

        /// <summary>
        /// Gets or sets the Mobile
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the Tel
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Gets or sets the MasterWangNo
        /// </summary>
        public string WantID { get; set; }

        /// <summary>
        /// Gets or sets the LogisticsNumber
        /// </summary>
        public string LogisticsNumber { get; set; }
        /// <summary>
        /// Gets or sets the LogisticsId
        /// </summary>
        public string LogisticsId { get; set; }

        /// <summary>
        /// 创建交易时的物流方式（交易完成前，物流方式有可能改变，但系统里的这个字段一直不变）。
        /// 可选值：free(卖家包邮),post(平邮),express(快递),ems(EMS),virtual(虚拟发货)，25(次日必达)，26(预约配送)。
        /// </summary>
        public string  ShippingType{get;set;}

        /// <summary>
        /// Gets or sets the FactoryPrice
        /// </summary>
        public Nullable<decimal> FactoryPrice { get; set; }

        /// <summary>
        /// Gets or sets the SalesPrice
        /// </summary>
        public Nullable<decimal> SalesPrice { get; set; }

        
        /// <summary>
        /// (供货价,特供价 {单个商品的价额})
        /// </summary>
        public Nullable<decimal> Costprice { get; set; }

        /// <summary>
        /// Gets or sets the SalesOrder
        /// </summary>
        public string SalesOrder { get; set; }

        /// <summary>
        /// Gets or sets the ISArrivedLibrary
        /// </summary>
        public string ISArrivedLibrary { get; set; }

        /// <summary>
        /// Gets or sets the Remarks
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets the CutoffShipDay
        /// </summary>
        public Nullable<System.DateTime> CutoffShipDay { get; set; }

        /// <summary>
        /// Gets or sets the CustomerServiceRemark
        /// </summary>
        public string CustomerServiceRemark { get; set; }

        /// <summary>
        /// Gets or sets the QuestionDesc
        /// </summary>
        public string QuestionDesc { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }
        /// <summary>
        /// 是否加急
        /// </summary>
        public Nullable<bool> IsExpedited { get; set; }
        /// <summary>
        /// 是否返现
        /// </summary>
        public Nullable<bool> IsCashBack { get; set; }
        /// <summary>
        /// 是否已发赠品
        /// </summary>
        public Nullable<bool> IsSentGifts { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatusId { get; set; }

        /// <summary>
        /// 是否排单
        /// </summary>
        public Nullable<bool> IsHadPlanBill { get; set; }

        /// <summary>
        /// IsReDelivery
        /// </summary>
        public Nullable<bool> IsReDelivery { get; set; }

        /// <summary>
        /// IsChangeGoods
        /// </summary>
        public Nullable<bool> IsChangeGoods { get; set; }

        /// <summary>
        /// IsReturnGoods
        /// </summary>
        public Nullable<bool> IsReturnGoods { get; set; }

        /// <summary>
        /// IsContinue
        /// </summary>
        public Nullable<bool> IsContinue { get; set; }
        /// <summary>
        /// 是否已评价
        /// </summary>
        public Nullable<bool> IsEvaluate { get; set; }
         

        /// <summary>
        /// 是否发票
        /// </summary>
        public Nullable<bool> IsInvoices { get; set; }

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
        /// Gets or sets the OrderStatus
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// Gets or sets the SourceType
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// Gets or sets the IsScalping
        /// </summary>
        public Nullable<bool> IsScalping { get; set; }

        /// <summary>
        /// Gets or sets the OrderInfoID
        /// </summary>
        public Nullable<int> OrderInfoID { get; set; }

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }


        /// <summary>
        /// Gets or sets the TCostprice
        /// </summary>
        public Nullable<decimal> TCostprice { get; set; }


        /// <summary>
        /// Gets or sets the AuditStatus
        /// </summary>
        public Nullable<bool> AuditStatus { get; set; }
        #endregion

        #region Custom Properties

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


        public string NickName {
            get
            {
                string result = "";
                if (this.NickID!=null  && this.NickID>0)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(int.Parse(this.NickID.ToString()));
                    if (nick != null)
                    {
                        result = nick.nick;
                    }
                }
                return result;
            }
        
        }

        public string ProjectName
        {
            get
            {
                string result = "";
                if (this.ProjectId != null && this.ProjectId > 0)
                {
                    var project = IoC.Resolve<IXMProjectService>().GetXMProjectById(int.Parse(this.ProjectId.ToString()));
                    if (project != null)
                    {
                        result = project.ProjectName;
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
                if (this.NickID.HasValue)
                {
                    var Info = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickID.Value);
                    if (Info != null)
                    {
                        result = (int)Info.ProjectId;
                    }
                }
                return result;
            }
        }

        #endregion

        #region Navigation Properties


        #endregion
    }
}
