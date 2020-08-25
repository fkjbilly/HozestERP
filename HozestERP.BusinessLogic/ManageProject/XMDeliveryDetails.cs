
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-04-09 10:25:19
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
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMDeliveryDetails : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryId
        /// </summary>
        public Nullable<int> DeliveryId { get; set; }

        /// <summary>
        /// OrderNo：订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 类型：赔付、赠品、(混合：赔付、赠品,暂不需要)
        /// </summary>
        public Nullable<int> DetailsTypeId { get; set; }

        /// <summary>
        /// Gets or sets the ProductlId
        /// </summary>
        public Nullable<int> ProductlId { get; set; }

        /// <summary>
        /// Gets or sets the WarehouseID
        /// </summary>
        public Nullable<int> WarehouseID { get; set; }

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the PrdouctName
        /// </summary>
        public string PrdouctName { get; set; }

        /// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public Nullable<int> ProductNum { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceInfoID
        /// </summary>
        public Nullable<int> InvoiceInfoID { get; set; }

        /// <summary>
        /// 记录来源ID
        /// </summary>
        public Nullable<int> SourceID { get; set; }

        /// <summary>
        /// Gets or sets the IsEnabled
        /// </summary>
        public Nullable<bool> IsEnabled { get; set; }

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
        /// Gets or sets the VerificationStatus
        /// </summary>
        public string VerificationStatus { get; set; }

        #endregion
        #region Custom Properties

        public string WarehouseName
        {
            get
            {
                string result = "";
                if (this.WarehouseID != null && this.WarehouseID > 0)
                {
                    var OrderInfo = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoListByOrderCode(this.OrderNo,1);
                    if (OrderInfo != null && OrderInfo.Count > 0)
                    {
                        var Project = IoC.Resolve<IXMNickService>().GetProjectNameByID((int)OrderInfo[0].NickID);
                        if (Project != null && Project.Id == 2 && (this.XM_Delivery.DeliveryTypeId == 480 || this.XM_Delivery.DeliveryTypeId == 708))//喜临门
                        {
                            var Info = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.WarehouseID.Value);
                            if (Info != null)
                            {
                                result = Info.CodeName;
                                return result;
                            }
                        }
                    }
                    var info = IoC.Resolve<IXMWareHousesService>().GetXMWareHousesById(this.WarehouseID.Value);
                    if (info != null)
                    {
                        result = info.Name;
                    }
                }
                return result;
            }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_Delivery
        /// </summary>
        public virtual XMDelivery XM_Delivery { get; set; }

        #endregion
    }
}
