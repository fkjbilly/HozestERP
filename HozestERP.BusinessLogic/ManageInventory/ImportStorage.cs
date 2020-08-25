using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public class ImportStorage
    {
        public int Id { get; set; }

        public string Ref { get; set; }

        public int ProductsCount { get; set; }

        public int WareHouseId { get; set; }
    }
}
