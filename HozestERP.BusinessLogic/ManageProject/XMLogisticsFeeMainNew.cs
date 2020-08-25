using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{
    public class XMLogisticsFeeMainNew
    {
        public int ID { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// 发货点ID
        /// </summary>
        public int WareHouseID { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 物流公司ID
        /// </summary>
        public int LogisticsID { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public decimal Fee { get; set; }


    }
}
