using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public class SaleDeliveryProduct
    {
        /// <summary>
        /// 厂家编码
        /// </summary>
        public string pcode;
        public int saleDeliveryCount;
        public int wareHoueseID;
        public int InventoryInfoID;
        public string ProductName;
        public decimal ProductPrice;
        public int ProductID;
        public string DeliveryNo;
        public int StockNumber;
    }
}
