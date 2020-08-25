
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-07-21 08:58:00
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

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial class ProvinceWarehouseSpare : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the ProvinceWarehouseID
        /// </summary>
        public Nullable<int> ProvinceWarehouseID { get; set; }

        /// <summary>
        /// Gets or sets the Sequence
        /// </summary>
        public Nullable<int> Sequence { get; set; }

        /// <summary>
        /// Gets or sets the SpareWarehouseID
        /// </summary>
        public Nullable<int> SpareWarehouseID { get; set; }

        /// <summary>
        /// Gets or sets the IsEnabled
        /// </summary>
        public Nullable<bool> IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public Nullable<int> CreatorID { get; set; }

        /// <summary>
        /// Gets or sets the CreateTime
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the UpdatorID
        /// </summary>
        public Nullable<int> UpdatorID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateTime { get; set; }

        #endregion
        #region Custom Properties

        public string ProvinceName
        {
            get
            {
                string value = "";
                if (this.ProvinceWarehouseID != null)
                {
                    var Info = IoC.Resolve<IProvinceWarehouseService>().GetProvinceWarehouseByID(this.ProvinceWarehouseID.Value);
                    if (Info != null)
                    {
                        value = Info.ProvinceName;
                    }
                }
                return value;
            }
        }

        public string SpareWarehouse
        {
            get
            {
                string value = "";
                if (this.SpareWarehouseID != null)
                {
                    var list = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(227);
                    foreach (var item in list)
                    {
                        if (item.CodeID == this.SpareWarehouseID.Value)
                        {
                            value = item.CodeName;
                        }
                    }
                }
                return value;
            }
        }

        #endregion
    }
}
