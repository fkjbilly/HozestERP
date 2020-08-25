using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class CWProfitMapping : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///项目父级Id
        /// </summary>
        public Nullable<int> ParentID { get; set; }

        /// <summary>
        /// 项目说明
        /// </summary>
        public string ProjectExplanation { get; set; }

        /// <summary>
        /// 表类型
        /// </summary>
        public Nullable<int> TableTypeId { get; set; }


        /// <summary>
        /// 项目说明Id
        /// </summary>
        public Nullable<int> ProjectId { get; set; }

        /// <summary>
        /// 本月数
        /// </summary>
        public Nullable<decimal> CountMoney { get; set; }


         /// <summary>
        /// 年度累计数
        /// </summary>
        public Nullable<decimal> YearCountMoney { get; set; }


        /// <summary>
        /// 月度达成率
        /// </summary>
        public Nullable<decimal> MonthProfit { get; set; }


        /// <summary>
        /// 年度达成率
        /// </summary>
        public Nullable<decimal> YearProfit { get; set; }


        /// <summary>
        /// 项目说明
        /// </summary>
        public string ProjectExplanationVlue
        {
            get
            {
                string result = "";
                if (this.ProjectId != null && this.ProjectId > 0)
                {
                    var project = IoC.Resolve<ICWProjectService>().GetCWProjectById(this.ProjectId.Value);
                    if (project != null)
                    {
                        result = project.ProjectExplanation;
                    }
                }
                return result;
            }

        }
        
    }
}
