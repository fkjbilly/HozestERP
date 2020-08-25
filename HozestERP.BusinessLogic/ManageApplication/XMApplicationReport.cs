using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageApplication
{
    public class XMApplicationReport
    {
        /// <summary>
        /// 厂家编码
        /// </summary>
        public string ManufacturersCode { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        public int Num { get; set; }

        public string CountProportion { get; set; }
    }
}
