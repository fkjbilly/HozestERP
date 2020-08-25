using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{
    public class XMLogisticsFeeBranchNew
    {
        public int ID { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// 物流公司ID
        /// </summary>
        public int LogisticsID { get; set; }

        /// <summary>
        /// 商品类型ID
        /// </summary>
        public int ProductCategoryID { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public decimal Fee { get; set; }
    }
}
