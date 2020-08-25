using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{
    public class ProductChose
    {
        public int ID { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// 厂家编码
        /// </summary>
        public string ManufacturersCode { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// 出厂价
        /// </summary>
        public decimal? Costprice { get; set; }

        /// <summary>
        /// 销售价
        /// </summary>
        public decimal? Saleprice { get; set; }

        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatformTypeName { get; set; }
    }
}
