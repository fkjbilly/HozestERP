using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace HozestERP.BusinessLogic.ManageFinance
{ 

    public enum AdvanceStateEnum : int
    {
        /// <summary>
        /// 暂支未处理
        /// </summary>
        [Description("未处理")]
        TheAdvanceNoneDealWith = 0,

        /// <summary>
        /// 暂支使用中
        /// </summary>
        [Description("暂支使用中")]
        TheAdvanceUse = 1,

        /// <summary>
        /// 暂支结束
        /// </summary>
        [Description("暂支结束")]
        TheAdvanceEnd = 2, 

    }
}
