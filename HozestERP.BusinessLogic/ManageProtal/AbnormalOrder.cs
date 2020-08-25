using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProtal
{
    public class AbnormalOrder
    {
        public string OrderCode { get; set; }

        public int ProjectId { get; set; }

        public decimal OrderPrice { get; set; }

        public decimal minprice { get; set; }

        public decimal cashbackmoney { get; set; }

        public decimal price { get; set; }

        public decimal amount { get; set; }

        public decimal differenceprice { get; set; }
    }
}
