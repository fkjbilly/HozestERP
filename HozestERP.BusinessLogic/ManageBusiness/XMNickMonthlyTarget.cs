
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-12-22 09:49:03
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
    public partial class XMNickMonthlyTarget: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the DateTime
        /// </summary>
        public System.DateTime DateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the TurnoverAmount
        /// </summary>
        public decimal TurnoverAmount { get; set; }
    
    	/// <summary>
        /// Gets or sets the TurnoverNumber
        /// </summary>
        public int TurnoverNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the NewCusOrderCount
        /// </summary>
        public int NewCusOrderCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the OldCusOrderCount
        /// </summary>
        public int OldCusOrderCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the TurnoverPersonCount
        /// </summary>
        public int TurnoverPersonCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the GuestUnitPrice
        /// </summary>
        public decimal GuestUnitPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public int NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    
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
    
    	/// <summary>
        /// Gets or sets the IsAudit
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }

        #endregion
        #region Custom Properties


        public string AuthorName
        {
            get
            {
                if (this.Updater != null)
                {
                    return IoC.Resolve<IXMBusinessDataService>().GetCustomerName(this.Updater.Value.ToString());
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get
            {
                string result = "";
                if (this.NickId != null)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetProjectNameByID(this.NickId);
                    if (nick != null)
                    {
                        if (nick.DepartmentID == 63)
                        {
                            result = "B2C";
                        }
                        else
                        {
                            result = nick.ProjectName;
                        }
                    }
                }
                return result;
            }

        }

        /// <summary>
        /// 项目ID
        /// </summary>
        public string ProjectId
        {
            get
            {
                string result = "";
                if (this.NickId != null)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetProjectNameByID(this.NickId);
                    if (nick != null)
                    {
                        if (nick.DepartmentID == 63)
                        {
                            result = "B2C";
                        }
                        else
                        {
                            result = nick.Id.ToString();
                        }
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
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId);
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
