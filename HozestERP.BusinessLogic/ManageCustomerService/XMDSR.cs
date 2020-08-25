
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-05-27 15:07:06
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
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Codes;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMDSR: BaseEntity
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
        /// Gets or sets the PlatfromTypeId
        /// </summary>
        public Nullable<int> PlatfromTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Month
        /// </summary>
        public string Month { get; set; }
    
    	/// <summary>
        /// Gets or sets the CommodityDes
        /// </summary>
        public Nullable<decimal> CommodityDes { get; set; }
    
    	/// <summary>
        /// Gets or sets the ServiceAttitude
        /// </summary>
        public Nullable<decimal> ServiceAttitude { get; set; }
    
    	/// <summary>
        /// Gets or sets the DeliverySpeed
        /// </summary>
        public Nullable<decimal> DeliverySpeed { get; set; }
    
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
        /// <summary>
        /// 平台类型
        /// </summary>
        public XMNick NickName
        {
            get
            {
                if (this.NickId != null)
                {
                    return IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        /// <summary>
        /// 平台类型
        /// </summary>
        public CodeList PlatformTypeCodeName
        {
            get
            {
                if (this.PlatfromTypeId != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PlatfromTypeId.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        #endregion
    }
}
