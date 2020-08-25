using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class PuchaseStrategyInfo
    {
        #region Primitive Properties
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the PrductId
        /// </summary>
        public int PrductId { get; set; }

        /// <summary>
        /// Gets or sets the PrductName
        /// </summary>
        public string PrductName { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandTypeName { get; set; }
        /// <summary>
        /// 商品编码(唯一)
        /// </summary>
        public string PlatformMerchantCode { get; set; }
        /// <summary>
        /// Gets or sets the WfName
        /// </summary>
        public string WfName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int WfId { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string OrganizationName { get; set; }
        /// <summary>
        /// Gets or sets the StockNumber    库存数量
        /// </summary>
        public Nullable<int> StockNumber { get; set; }
        /// <summary>
        /// 预测采购数量
        /// </summary>
        public Nullable<int> ForecastNumber { get; set; }
        /// <summary>
        /// 实际需采购数量
        /// </summary>
        public Nullable<int> RealityNumber { get; set; }
        /// <summary>
        /// 前第1周销量
        /// </summary>
        public Nullable<int> FirstOneWeekSales { get; set; }
        /// <summary>
        /// 前第2周销量
        /// </summary>
        public Nullable<int> FirstTwoWeekSales { get; set; }
        /// <summary>
        /// 前第3周销量
        /// </summary>
        public Nullable<int> FirstThreeWeekSales { get; set; }
        /// <summary>
        /// 前第4周销量
        /// </summary>
        public Nullable<int> FirstFourWeekSales { get; set; }
        /// <summary>
        /// 前第5周销量
        /// </summary>
        public Nullable<int> FirstFiveWeekSales { get; set; }
        /// <summary>
        /// 前第6周销量
        /// </summary>
        public Nullable<int> FirstSixWeekSales { get; set; }
        /// <summary>
        /// 前第7周销量
        /// </summary>
        public Nullable<int> FirstSevenWeekSales { get; set; }
        /// <summary>
        /// 前第8周销量
        /// </summary>
        public Nullable<int> FirstEightWeekSales { get; set; }
        /// <summary>
        /// 历史四周销量和
        /// </summary>
        public Nullable<int> HistoryFourWeekSales { get; set; }
        /// <summary>
        /// 历史八周销量和
        /// </summary>
        public Nullable<int> HistoryEightWeekSales { get; set; }
        /// <summary>
        /// 备货周期
        /// </summary>
        public Nullable<int> StockingCycle { get; set; }
        /// <summary>
        /// 不补货原因
        /// </summary>
        public string reason { get; set; }

        #endregion
    }
}
