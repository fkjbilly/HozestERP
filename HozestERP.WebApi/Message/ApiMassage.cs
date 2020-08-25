using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HozestERP.WebApi.Message
{
    public class ApiMassage
    {
        public Header Header { get; set; }
    }
    public class Header
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 返回的消息
        /// </summary>
        public string Message { get; set; }
    }

    public class TotalHeader
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 返回的消息
        /// </summary>
        public string Message { get; set; }
    }
    /// <summary>
    /// 返回erp库存信息
    /// </summary>
    public class ErpInventoryInfo
    {
        public TotalHeader Header { get; set; }
        /// <summary>
        /// 库存信息
        /// </summary>
        public List<ErpInventoryList> InventoryList { get; set; }
    }

    public class ErpInventoryList
    {
        /// <summary>
        ///商品编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// 单位(想，包，张等)
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 可用库存
        /// </summary>
        public int Inventory { get; set; }

    }
    /// <summary>
    /// 返回erp商品信息
    /// </summary>
    public class ErpProduct
    {
        public TotalHeader Header { get; set; }
        /// <summary>
        /// 商品信息
        /// </summary>
        public List<ErpProductList> ProductList { get; set; }
    }

    public class ErpProductList
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }
        /// <summary>
        /// 如果是组合商品，则会有组成商品的子商品信息
        /// </summary>
        public List<ErpProductChildList> ProductChildList { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>
        public Nullable<decimal> Saleprice { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string ProductUnit { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public string ProductWeight { get; set; }
    }
    /// <summary>
    /// 组合商品中组合商品的组成商品信息
    /// </summary>
    public class ErpProductChildList
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public Nullable<int> ProductNum { get; set; }
    }
    /// <summary>
    /// 返回erp商品信息
    /// </summary>
    public class ErpOrderStatus
    {
        public Header Header { get; set; }
        /// <summary>
        /// 订单物品的发货状态信息
        /// </summary>
        public List<ErpOrderStatusList> OrderStatusList { get; set; }
    }

    public class ErpOrderStatusList
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }
        /// <summary>
        /// 物流单号
        /// </summary>
        public string LogisticsNumber { get; set; }
        /// <summary>
        /// 物流公司
        /// </summary>
        public string LogisticsName { get; set; }
        /// <summary>
        /// 发货单状态
        /// </summary>
        public bool IsDelivery { get; set; }

    }
    public class ErpOrderInfo
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsIsAudit { get; set; }


    }
    /// <summary>
    /// 五道项目所对应的仓库id
    /// </summary>
    public class ErpWarehouseId
    {
        public int Id { get; set; }
    }

}