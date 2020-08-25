using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public class XMJDSaleReport
    {
        public int ReturnCategoryID { get; set;}

        public string ReturnType { get; set; }

        public decimal Cost { get; set; }

        public decimal ReturnMoney { get; set; }

        public int Num { get; set; }

        public string CountProportion { get; set; }
    }
}
