
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-03-23 15:30:11
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
    public partial class XMAdvertisingFeeDetail: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the AdvertingFeeId
        /// </summary>
        public int AdvertingFeeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the FieldId
        /// </summary>
        public int FieldId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Cost
        /// </summary>
        public decimal Cost { get; set; }
    
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

        #endregion
        #region Custom Properties

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string FieldName
        {
            get
            {
                string result = "";
                if (this.FieldId != null)
                {
                    var f = IoC.Resolve<IXMAdvertingFieldService>().GetXMAdvertingFieldById(this.FieldId);
                    if (f != null)
                    {
                        result = f.FieldName;
                    }
                }
                return result;
            }

        }
    	
        #endregion
    }
}
