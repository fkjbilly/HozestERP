using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Codes;

namespace HozestERP.BusinessLogic.ManageFinance
{ 
    public partial class CWPlatformSpendingMapping : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// 项目Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 平台费用Id
        /// </summary>
        public Nullable<int> PSId { get; set; }

        /// <summary>
        ///  上级Id （注这里指sys_codelist 平台Id）
        /// </summary>
        public Nullable<int> ParentID { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string ProjectExplanation { get; set; } 

        /// <summary>
        ///平台id 
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }

        /// <summary>
        /// 平台费用项目Id
        /// </summary>
        public Nullable<int> ProfitProjectId { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        public string YearStr { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        public string MonthStr { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public Nullable<decimal> CountMoney { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

         
        #endregion
        #region Custom Properties


        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatformName
        {
            get
            {
                string result = "";
                if (this.PlatformTypeId.HasValue)
                {
                    var codelist = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PlatformTypeId.Value);
                    if (codelist != null)
                    {
                        result = codelist.CodeName;
                    }
                }
                return result;
            }
        }



        #endregion
    }
}
