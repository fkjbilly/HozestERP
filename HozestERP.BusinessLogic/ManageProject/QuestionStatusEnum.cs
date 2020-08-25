using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace HozestERP.BusinessLogic.ManageProject
{
    public enum QuestionStatusEnum : int
    {
        /// <summary>
        /// 提交中
        /// </summary>
        [Description("提交中")]
        Submit = 0,

        /// <summary>
        /// 处理中
        /// </summary>
        [Description("处理中")]
        Deal = 1,

        /// <summary>
        /// 完成
        /// </summary>
        [Description("完成")]
        Complete = 2,
    }
}
