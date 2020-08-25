
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-06-05 10:06:06
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

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class CWStaffSpending: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
        /// <summary>
        /// Gets or sets the FinancialFieldId
        /// </summary>
        public Nullable<int> FinancialFieldId { get; set; }

    	/// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the Department
        /// </summary>
        public Nullable<int> DepartmentTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the YearStr
        /// </summary>
        public string YearStr { get; set; }
    
    	/// <summary>
        /// Gets or sets the MonthStr
        /// </summary>
        public string MonthStr { get; set; }
    
    	/// <summary>
        /// Gets or sets the CountMoney
        /// </summary>
        public Nullable<decimal> CountMoney { get; set; }


        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDateTime
        /// </summary>
        public Nullable<System.DateTime> CreateDateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateDateTime { get; set; }

        #endregion
        #region Custom Properties

        /// <summary>
        /// 预算字段名称
        /// </summary>
        public string FinancialFieldName
        {
            get
            {
                var Name = IoC.Resolve<ICWStaffSpendingService>().GetFinancialFieldName((int)this.FinancialFieldId);
                if (Name != null)
                    return Name.FieldName;
                return string.Empty;
            }
        }
    	
        #endregion
    }
}
