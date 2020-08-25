using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public enum CustomerStatusEnum:int
    {
        /// <summary>
        /// 还未转试用
        /// </summary>
        [Description("未接收")]
        NoneStatus = 0,

        /// <summary>
        /// 试用状态
        /// </summary>
        [Description("试用")]
        TrialStatus = 1,

        /// <summary>
        /// 转正状态
        /// </summary>
        [Description("转正")]
        ProbationPassed = 2,

        /// <summary>
        /// 离职状态
        /// </summary>
        [Description("离职")]
        Turnover = 3,

        /// <summary>
        /// 复职状态
        /// </summary>
        [Description("复职")]
        Reinstatement = 4,

        /// <summary>
        /// 退休状态
        /// </summary>
        [Description("退休")]
        Retired = 5,

    }
}
