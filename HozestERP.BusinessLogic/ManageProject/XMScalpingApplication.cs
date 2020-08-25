
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2014-12-31 15:51:17
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
    public partial class XMScalpingApplication: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ScalpingId
        /// </summary>
        public int ScalpingId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public int PlatformTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ScalpingCode
        /// </summary>
        public string ScalpingCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the Explanation
        /// </summary>
        public string Explanation { get; set; }
    
    	/// <summary>
        /// Gets or sets the ScalpingBeginTime
        /// </summary>
        public Nullable<System.DateTime> ScalpingBeginTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the ScalpingEndTime
        /// </summary>
        public Nullable<System.DateTime> ScalpingEndTime { get; set; } 
        /// <summary>
        /// Gets or sets the ManagerPeople
        /// </summary>
        public Nullable<int> ManagerPeople { get; set; }

        /// <summary>
        /// Gets or sets the ManagerIsAudit
        /// </summary>
        public Nullable<bool> ManagerIsAudit { get; set; }

        /// <summary>
        /// Gets or sets the ManagerTime
        /// </summary>
        public Nullable<System.DateTime> ManagerTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
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

   
        /// <summary>
        /// 平台类型
        /// </summary>
        public string PlatformTypeName
        {
            get
            {
                string result = "";
                if (this.PlatformTypeId != null)
                {
                    var list = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PlatformTypeId);
                    if (list != null)
                    {
                        result = list.CodeName;
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
                    var list= IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId.Value);
                    if (list != null)
                    {
                        result = list.nick;
                    }  
                }
                return result;
            }
        }


        #endregion
    }
}
