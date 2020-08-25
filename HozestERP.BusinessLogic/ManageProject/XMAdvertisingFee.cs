
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-07-07 10:13:34
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMAdvertisingFee: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Feedate
        /// </summary>
        public Nullable<System.DateTime> Feedate { get; set; }
    
    	/// <summary>
        /// Gets or sets the Fee
        /// </summary>
        public Nullable<decimal> Fee { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public Nullable<int> CreatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorTime
        /// </summary>
        public Nullable<System.DateTime> CreatorTime { get; set; }
    
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
                    var nick = IoC.Resolve<IXMNickService>().GetProjectNameByID(this.NickId.Value);
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
