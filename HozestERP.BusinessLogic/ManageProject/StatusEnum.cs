using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{
    public enum StatusEnum : int
    {
        /// <summary>
        /// 未返现
        /// </summary>
        [Description("未返现")]
        NotCashBack = 0,

        /// <summary>
        /// 已返现
        /// </summary>
        [Description("已返现")]
        AlreadyCashBack = 1,

        ///// <summary>
        ///// 异常未返现
        ///// </summary>
        //[Description("异常未返现")]
        //AbnormalNotCashBack = 2,

        /// <summary>
        /// 未审核
        /// </summary>
        [Description("未审核")]
        NotCheck = 3,

        /// <summary>
        /// 已审核
        /// </summary>
        [Description("已审核")]
        AlreadyCheck = 4,

        ///// <summary>
        ///// 未通过
        ///// </summary>
        //[Description("未通过")]
        //DidNotPass = 5,

        /// <summary>
        /// 未排单
        /// </summary>
        [Description("未排单")]
        PremiumsNoHair = 6,

        /// <summary>
        /// 已排单
        /// </summary>
        [Description("已排单")]
        PremiumsIssued = 7,

        ///// <summary>
        ///// 异常未发
        ///// </summary>
        //[Description("异常未发")]
        //PremiumsAbnormalNoHair = 8,

        /// <summary>
        /// 返现
        /// </summary>
        [Description("返现")]
        ChildCashBack = 9,

        /// <summary>
        /// 赔付
        /// </summary>
        [Description("赔付")]
        ChildPayment = 10,

        /// <summary>
        /// 赠品
        /// </summary>
        [Description("赠品")]
        ChildPremiums = 11,

        ///// <summary>
        ///// 类型：混合：赔付、赠品
        ///// </summary>
        //[Description("混合：赔付、赠品")]
        //ChildPaymentAndPremiums = 12,

        /// <summary>
        /// 正常订单
        /// </summary>
        [Description("正常订单")]
        NormalOrder = 13,

        /// <summary>
        /// 换货订单
        /// </summary>
        [Description("换货订单")]
        ApplicationOrder = 14,

        /// <summary>
        /// 发票
        /// </summary>
        [Description("发票")]
        InvoiceInfo = 15,
    }
}
