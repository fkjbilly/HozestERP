
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-06-08 08:58:26
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
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMAllocateInfo : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Ref
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// Gets or sets the From_WarehouseId
        /// </summary>
        public int From_WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the To_WarehouseId
        /// </summary>
        public int To_WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the BizUserId
        /// </summary>
        public Nullable<int> BizUserId { get; set; }

        /// <summary>
        /// Gets or sets the BizDt
        /// </summary>
        public Nullable<System.DateTime> BizDt { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the BillStatus
        /// </summary>
        public int BillStatus { get; set; }

        /// <summary>
        /// Gets or sets the BillMemo
        /// </summary>
        public string BillMemo { get; set; }
        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        #endregion
        #region Custom Properties


        /// <summary>
        /// 出库仓库所属项目
        /// </summary>
        public int FromProjectId
        {
            get
            {
                int fromProjectId = 1;
                var wareHouses = IoC.Resolve<XMWareHousesService>().GetXMWareHousesById(this.From_WarehouseId);
                if (wareHouses != null)
                {
                    fromProjectId = wareHouses.ProjectId.Value;
                }
                return fromProjectId;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ToProjectId
        {
            get
            {
                int toProjectId = 1;
                var wareHouses = IoC.Resolve<XMWareHousesService>().GetXMWareHousesById(this.To_WarehouseId);
                if (wareHouses != null)
                {
                    toProjectId = wareHouses.ProjectId.Value;
                }
                return toProjectId;
            }
        }


        /// <summary>
        /// 出库仓库名称
        /// </summary>
        public string FromWarehouseName
        {
            get
            {
                string fromWareHouseName = "";
                var wareHouses = IoC.Resolve<XMWareHousesService>().GetXMWareHousesById(this.From_WarehouseId);
                if (wareHouses != null)
                {
                    fromWareHouseName = wareHouses.Name;
                }
                return fromWareHouseName;
            }
        }
        /// <summary>
        /// 调拨人仓库
        /// </summary>
        public string ToWarehouseName
        {
            get
            {
                string toWareHousesName = "";
                var wareHouses = IoC.Resolve<XMWareHousesService>().GetXMWareHousesById(this.To_WarehouseId);
                if (wareHouses != null)
                {
                    toWareHousesName = wareHouses.Name;
                }
                return toWareHousesName;
            }
        }

        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_AllocateProductDetails list
        /// </summary>
        public virtual ICollection<XMAllocateProductDetails> XM_AllocateProductDetails { get; set; }

        #endregion
    }
}
