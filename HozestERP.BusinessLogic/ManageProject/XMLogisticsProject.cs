using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMLogisticsProject
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepName { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        public int? ProjectID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 包裹数量
        /// </summary>
        public int PackageNum { get; set; }
    }
}
