using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace HozestERP.BusinessLogic.ManageApplication
{

    public enum AppStatusEnum : int
    {
        /// <summary>
        /// 未审核
        /// </summary>
        [Description("未审核")]
        NotCheck = 0,

        /// <summary>
        /// 已审核
        /// </summary>
        [Description("已审核")]
        AlreadyCheck = 1,

        /// <summary>
        /// 未送出
        /// </summary>
        [Description("未送出")]
        NotSend = 2,

        /// <summary>
        /// 已送出
        /// </summary>
        [Description("已送出")]
        Send = 3,


        /// <summary>
        /// 未发货退款
        /// </summary>
        [Description("未发货退款")]
        weifahuo = 4,

        /// <summary>
        /// 先退货后退款
        /// </summary>
        [Description("先退货后退款")]
        tuihuo = 5,

        /// <summary>
        /// 换货
        /// </summary>
        [Description("换货")]
        huanhuo = 6,

        /// <summary>
        /// 先退款后退货
        /// </summary>
        [Description("先退款后退货")]
        secondtuihuan = 7,

        /// <summary>
        /// 退运费
        /// </summary>
        [Description("退运费")]
        tuiyunfei = 8,

        /// <summary>
        /// 售后
        /// </summary>
        [Description("售后")]
        shouhou = 9,

        /// <summary>
        /// 售中
        /// </summary>
        [Description("售中")]
        shouzhong = 10
        
    }
}
