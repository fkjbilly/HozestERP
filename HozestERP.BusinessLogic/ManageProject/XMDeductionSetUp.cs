
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-02-02 16:29:57
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
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMDeductionSetUp: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 种类：扣点：475、返现:476
        /// </summary>
        public Nullable<int> SpeciesTypeId { get; set; }

    	/// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> ProjectId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }
    
    	/// <summary>
        /// 平台扣点%/返现金额
        /// </summary>
        public Nullable<decimal> Deduction { get; set; }

        /// <summary>
        /// 财务金额
        /// </summary>
        public Nullable<decimal> Finance { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypePersonId
        /// </summary>
        public Nullable<int> PlatformTypePersonId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remarks
        /// </summary>
        public string Remarks { get; set; }
    
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

        /// <summary>
        /// 平台名称
        /// </summary>
        public CodeList PlatformTypeName
        {
            get
            {
                if (this.PlatformTypeId != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PlatformTypeId.Value);
                }
                else
                {

                    return null;
                }
            }
        }



        /// <summary>
        /// 平台负责人
        /// </summary>
        public CustomerInfo PlatformTypePersonName
        {
            get
            {
                if (this.PlatformTypePersonId != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.PlatformTypePersonId.Value);
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
