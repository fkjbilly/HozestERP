using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageBulletin
{
    public enum BulletinStatusEnum : int
    {
        /// <summary>
        /// 创建
        /// </summary>
        [Description("创建")]
        Found = 0,

        /// <summary>
        /// 发布
        /// </summary>
        [Description("发布")]
        Released = 1,

        /// <summary>
        /// 终止
        /// </summary>
        [Description("终止")]
        End = 2,

    }
}
