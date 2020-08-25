using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.BusinessLogic.ManageContract
{
    public enum CustomerTypeEnum : int
    {
        /// <summary>
        /// AM
        /// </summary>
        [Description("AM")]
        AM = 0,

        /// <summary>
        /// AE
        /// </summary>
        [Description("AE")]
        AE = 1,

        /// <summary>
        /// 店长
        /// </summary>
        [Description("店长")]
        ShopOwner = 2,

        /// <summary>
        /// 策划专员
        /// </summary>
        [Description("策划专员")]
        PlanningCommissioner = 3,

        /// <summary>
        /// 推广专员
        /// </summary>
        [Description("推广专员")]
        PromotionSpecialist = 4,

        /// <summary>
        /// 活动专员
        /// </summary>
        [Description("活动专员")]
        ActivitiesCommissioner = 5,

        /// <summary>
        /// 设计师
        /// </summary>
        [Description("设计师")]
        Designer = 6,

        /// <summary>
        /// 运营专员
        /// </summary>
        [Description("运营专员")]
        OperationCommissioner = 7,

        /// <summary>
        /// 文案专员
        /// </summary>
        [Description("文案专员")]
        CopywriterCommissioner = 8,

        /// <summary>
        /// 客户经理
        /// </summary>
        [Description("客户经理")]
        CustomerManager=9,

        /// <summary>
        /// 客户
        /// </summary>
        [Description("客户")]
        ClientManager = 10,

        /// <summary>
        /// 项目经理
        /// </summary>
        [Description("项目经理")]
        ProjectManager = 11,
    }
}
