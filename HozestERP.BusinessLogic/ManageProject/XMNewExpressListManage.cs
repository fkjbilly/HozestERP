using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMNewExpressListManage : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the Year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the Month
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets the ExpressID
        /// </summary>
        public int ExpressID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ExpressName { get; set; }

        /// <summary>
        /// Gets or sets the Cost
        /// </summary>
        public Nullable<decimal> Cost { get; set; }

    }
}
