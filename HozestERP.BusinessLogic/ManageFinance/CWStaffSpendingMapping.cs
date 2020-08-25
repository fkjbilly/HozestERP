using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageFinance
{  
    public partial class CWStaffSpendingMapping: BaseEntity
    {
        /// <summary>
        /// Gets or sets the FinancialFieldId
        /// </summary>
        public Nullable<int> FinancialFieldId { get; set; }

        /// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the Department
        /// </summary>
        public Nullable<int> DepartmentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }

        /// <summary>
        /// Gets or sets the YearStr
        /// </summary>
        public string YearStr { get; set; }

        /// <summary>
        /// Gets or sets the MonthStr
        /// </summary>
        public string MonthStr { get; set; }

        public Nullable<decimal> MonthTotal { get; set; }//月实际
        public Nullable<decimal> YearTotal { get; set; }//年实际
        public decimal MonthTarget { get; set; }//月目标
        public decimal YearTarget { get; set; }//年目标
        public decimal MonthReachRate { get; set; }//月达成率
        public decimal MonthGrowthRate { get; set; }//月增长率
        public decimal YearReachRate { get; set; }//年达成率
        public decimal YearGrowthRate { get; set; }//年增长率
        public decimal LastMonthTotal { get; set; }//去年该月同期
        public decimal LastYearTotal { get; set; }//去年同期
        public string TypeName { get; set; }//类型名

        /// <summary>
        /// 预算字段名称
        /// </summary>
        public string FinancialFieldName
        {
            get
            {
                if (this.FinancialFieldId == 666)
                {
                    return "财务费用";
                }
                var Name = IoC.Resolve<ICWStaffSpendingService>().GetFinancialFieldName((int)this.FinancialFieldId);
                if (Name != null)
                {
                    if (Name.ParentID != 0)
                    {
                        return "&nbsp;&nbsp;" + Name.FieldName;
                    }
                    else
                    {
                        return Name.FieldName;
                    }
                }
                return string.Empty;
            }
        }
    }
}
