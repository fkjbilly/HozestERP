
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 方银朗
** 创建日期:2014-06-10 14:22:02
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
    public partial class XMProject: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProjectName
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 自运营、代运营
        /// </summary>
        public Nullable<int> ProjectTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the customerId
        /// </summary>
        public Nullable<int> customerId { get; set; }

    	/// <summary>
        /// Gets or sets the customerId
        /// </summary>
        public Nullable<int> ClientId { get; set; }

    	/// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }
         
        /// <summary>
        /// 运费比例%
        /// </summary>
        public Nullable<decimal> ShipmentProportion { get; set; }
    
    	/// <summary>
        /// 是否可用 true 表示可用；false 表示删除
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

        public Nullable<int> DepartmentID { get; set; }

        #endregion
        #region Custom Properties
        /// <summary>
        /// 项目类型
        /// </summary>
        public CodeList ProjectTypeCodeName
        {
            get
            {
                if (this.ProjectTypeId != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.ProjectTypeId.Value);
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
