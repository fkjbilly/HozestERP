
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-09-19 13:36:06
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
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class XMDeliveryProductInventory : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }

        /// <summary>
        /// Gets or sets the Year
        /// </summary>
        public Nullable<int> Year { get; set; }

        /// <summary>
        /// Gets or sets the Month
        /// </summary>
        public Nullable<int> Month { get; set; }

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
        /// Gets or sets the StorageCount
        /// </summary>
        public Nullable<int> SurplusInventory { get; set; }

        /// <summary>
        /// Gets or sets the StorageCount
        /// </summary>
        public Nullable<int> StorageCount { get; set; }

        /// <summary>
        /// Gets or sets the StorageAmount
        /// </summary>
        public Nullable<decimal> StorageAmount { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryCount
        /// </summary>
        public Nullable<int> DeliveryCount { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryAmount
        /// </summary>
        public Nullable<decimal> DeliveryAmount { get; set; }

        /// <summary>
        /// Gets or sets the InventoryCount
        /// </summary>
        public Nullable<int> InventoryCount { get; set; }

        /// <summary>
        /// Gets or sets the InventoryAmount
        /// </summary>
        public Nullable<decimal> InventoryAmount { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        #endregion
        #region Custom Properties

        public string YearMonth
        {
            get
            {
                string date = this.Year.ToString() + "年" + this.Month.ToString() + "月";
                return date;
            }
        }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string NickName
        {
            get
            {
                string result = "";
                if (this.NickId != null && this.NickId > 0)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId.Value);
                    if (nick != null)
                    {
                        result = nick.nick;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ProjectName
        {
            get
            {
                string result = "";
                if (this.ProjectId != null && this.ProjectId > 0)
                {
                    var project = IoC.Resolve<IXMProjectService>().GetXMProjectById(this.ProjectId);
                    if (project != null)
                    {
                        result = project.ProjectName;
                    }
                }
                return result;
            }
        }

        public int ProjectId
        {
            get
            {
                int result = -1;
                if (this.NickId != null && this.NickId > 0)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId.Value);
                    if (nick != null)
                    {
                        result = (int)nick.ProjectId;
                    }
                }
                return result;
            }
        }

        #endregion
    }
}
