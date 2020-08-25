
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-09-06 16:02:23
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMGiftStorageRecord: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> ProductId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Batch
        /// </summary>
        public string Batch { get; set; }
    
    	/// <summary>
        /// Gets or sets the Count
        /// </summary>
        public Nullable<int> Count { get; set; }
    
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

        public string NicklId
        {
            get
            {
                if (this.ProductId != null)
                {
                    var info = IoC.Resolve<IXMGiftStorageRecordService>().GetProductInfo(this.ProductId.Value);
                    if (info != null)
                    {
                        return info.NickId.ToString();
                    }
                }
                return "";
            }
        }

        public string ProductName
        {
            get
            {
                var info = IoC.Resolve<IXMGiftStorageRecordService>().GetProductInfo(this.ProductId.Value);
                if (info != null)
                {
                    return info.ProductName.ToString();
                }
                return "";
            }
        }

        public string ManufacturersCode
        {
            get
            {
                var info = IoC.Resolve<IXMGiftStorageRecordService>().GetProductInfo(this.ProductId.Value);
                if (info != null)
                {
                    return info.ManufacturersCode.ToString();
                }
                return "";
            }
        }

        public string Specifications
        {
            get
            {
                var info = IoC.Resolve<IXMGiftStorageRecordService>().GetProductInfo(this.ProductId.Value);
                if (info != null)
                {
                    return info.Specifications.ToString();
                }
                return "";
            }
        }


        #endregion

        #region Custom Properties
    		
    	
        #endregion
    }
}
