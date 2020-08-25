
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-06-23 16:30:04
** 修改人:
** 修改日期:
** 描 述: 
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMXLMInventory : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the WarehouseID
        /// </summary>
        public Nullable<int> WarehouseID { get; set; }

        /// <summary>
        /// Gets or sets the ManufacturersCode
        /// </summary>
        public string ManufacturersCode { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the BarCode
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// Gets or sets the Unit
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the Inventory
        /// </summary>
        public Nullable<int> Inventory { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        #endregion
        #region Custom Properties

        public string WarehouseName
        {
            get
            {
                string result = "";
                if (this.WarehouseID != null && this.WarehouseID > 0)
                {
                    var info = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.WarehouseID.Value);
                    if (info != null)
                    {
                        result = info.CodeName;
                    }
                }
                return result;
            }
        }

        #endregion
    }
}
