using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{ 
    public partial class XMDeliveryDetailsMapping : BaseEntity
    {
        #region 发货单主表

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }  
        /// <summary>
        /// 发货单类型：正常:480、非正常:481
        /// </summary>
        public Nullable<int> DeliveryTypeId { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryNumber
        /// </summary>
        public string DeliveryNumber { get; set; } 

        /// <summary>
        /// Gets or sets the LogisticsNumber
        /// </summary>
        public string LogisticsNumber { get; set; }

        /// <summary>
        /// Gets or sets the LogisticsId
        /// </summary>
        public Nullable<int> LogisticsId { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        public Nullable<decimal> Price { get; set; }

        /// <summary>
        /// Gets or sets the IsDelivery
        /// </summary>
        public Nullable<bool> IsDelivery { get; set; }
          
        /// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }
         

        #endregion

        #region 发货单明细

        /// <summary>
        /// 明细Id
        /// </summary>
        public int XMDeliveryDetailsId { get; set; } 

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
        /// 仓库ID
        /// </summary>
        public Nullable<int> WarehouseID { get; set; }
        /// <summary>
        /// Gets or sets the IsEnabled
        /// </summary>
        public Nullable<bool> IsEnabled { get; set; }
         

         
        #endregion
        
    }
}
