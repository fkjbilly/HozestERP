using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HozestERP.WebApi.Message
{
    /// <summary>
    /// 请求库存信息的参数
    /// </summary>
    public class RequestInventoryApi
    {
        /// <summary>
        /// 商品编码(数组个数不能超过500)
        /// </summary>
        public List<string> PlatformMerchantCode { get; set; }
        /// <summary>
        /// 每次请求的条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 请求的页数
        /// </summary>
        public int PageNum { get; set; }
        /// <summary>
        /// 请求秘钥
        /// </summary>
        public string SecretKey { get; set; }
    }
    /// <summary>
    /// 请求产品信息的参数
    /// </summary>
    public class RequestProductApi
    {
        /// <summary>
        /// 商品编码(数组个数不能超过500)
        /// </summary>
        public List<string> PlatformMerchantCode { get; set; }
        /// <summary>
        /// 每次请求的条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 请求的页数
        /// </summary>
        public int PageNum { get; set; }
        /// <summary>
        /// 请求秘钥
        /// </summary>
        public string SecretKey { get; set; }
    }

    /// <summary>
    /// 内部请求订单发货状态的参数
    /// </summary>
    public class RequestOrderStatusApi
    {
        /// <summary>
        /// 请求的参数数组
        /// </summary>
        public List<RequestOrderStatusList> OrderStatusList { get; set; }
    }

    /// <summary>
    /// 内部请求订单发货状态的参数
    /// </summary>
    public class RequestOrderStatusList
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }
    }

    /// <summary>
    /// 请求取消订单
    /// </summary>
    public class RequestCancelOrder
    {
        /// <summary>
        /// 请求的参数数组
        /// </summary>
        public List<string> OrderCodeList { get; set; }
    }
}