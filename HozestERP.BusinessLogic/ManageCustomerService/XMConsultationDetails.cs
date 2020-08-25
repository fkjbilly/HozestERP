
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-07-16 14:53:29
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
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMConsultationDetails: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the id
        /// </summary>
        public int id { get; set; }
    
    	/// <summary>
        /// Gets or sets the ConsultationId
        /// </summary>
        public Nullable<int> ConsultationId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ContactTime
        /// </summary>
        public Nullable<System.DateTime> ContactTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the ContactContent
        /// </summary>
        public string ContactContent { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public Nullable<int> CreatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Created
        /// </summary>
        public Nullable<System.DateTime> Created { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdatorID
        /// </summary>
        public Nullable<int> UpdatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Updated
        /// </summary>
        public Nullable<System.DateTime> Updated { get; set; }

        #endregion
        #region Custom Properties

        /// <summary>
        /// 获取创建人信息
        /// </summary>
        public CustomerInfo CreateName
        {
            get
            {
                if (this.CreatorID != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.CreatorID.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        /// <summary>
        /// 获取修改人人信息
        /// </summary>
        public CustomerInfo UpdateName
        {
            get
            {
                if (this.UpdatorID != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.UpdatorID.Value);
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
