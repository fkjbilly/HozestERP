
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-01-04 17:32:46
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

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial class XMNickAchieveValue: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public int NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the DateTime
        /// </summary>
        public System.DateTime DateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the SaleCount
        /// </summary>
        public int SaleCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the SalePrice
        /// </summary>
        public decimal SalePrice { get; set; }
        /// <summary>
        /// Gets or sets the  Cost
        /// </summary>
        public decimal Cost { get; set; }
    
    	/// <summary>
        /// Gets or sets the GuestUnitPrice
        /// </summary>
        public decimal GuestUnitPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public System.DateTime CreateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Updater
        /// </summary>
        public Nullable<int> Updater { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        #endregion
        #region Custom Properties

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get
            {
                string result = "";
                if (this.NickId != 0 && this.NickId != null)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetProjectNameByID(this.NickId);
                    if (nick != null)
                    {
                        result = nick.ProjectName;
                    }
                }
                return result;
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
                if (this.NickId != null)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID((int)this.NickId);
                    if (nick != null)
                    {
                        result = nick.nick;
                    }
                }
                return result;
            }

        }

        #endregion
    }
}
