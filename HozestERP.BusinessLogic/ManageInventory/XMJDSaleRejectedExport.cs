using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public class XMJDSaleRejectedExport:BaseEntity
    {
        /// <summary>
        /// 退货单号
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 业务时间
        /// </summary>
        public DateTime? Time { get; set; }

        /// <summary>
        /// 退货类型
        /// </summary>
        public string ReturnCategoryName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 厂家编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 尺寸规格
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// 退货数量
        /// </summary>
        public int? RejectionCount { get; set; }

        /// <summary>
        /// 退货单价
        /// </summary>
        public decimal? RejectionPrice { get; set; }

        /// <summary>
        /// 退货金额
        /// </summary>
        public decimal? RejectionMoney { get; set; }

        /// <summary>
        /// 京东确认
        /// </summary>
        public bool? JDIsConfirm { get; set; }

        /// <summary>
        /// 新邦确认
        /// </summary>
        public bool? XBIsConfirm { get; set; }

        /// <summary>
        /// 喜临门确认
        /// </summary>
        public bool? XLMIsConfirm { get; set; }
    }
}
