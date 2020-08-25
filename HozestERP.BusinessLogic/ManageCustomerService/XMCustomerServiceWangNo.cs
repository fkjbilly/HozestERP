
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
    public partial class XMCustomerServiceWangNo: BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

    	/// <summary>
        /// Gets or sets the Group
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets the GroupID
        /// </summary>
        public Nullable<int> GroupID { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public Nullable<int> CustomerID { get; set; }

    	/// <summary>
        /// Gets or sets the RankID
        /// </summary>
        public Nullable<int> RankID { get; set; }

        /// <summary>
        /// Gets or sets the RankName
        /// </summary>
        public string RankName { get; set; }

        /// <summary>
        /// Gets or sets the WangNo
        /// </summary>
        public string WangNo { get; set; }

        /// <summary>
        /// Gets or sets the BasicSalary
        /// </summary>
        public Nullable<int> BasicSalary { get; set; }

        /// <summary>
        /// Gets or sets the BonusBase
        /// </summary>
        public Nullable<int> BonusBase { get; set; }

        /// <summary>
        /// Gets or sets the PaymentAmount
        /// </summary>
        public Nullable<decimal> PaymentAmount { get; set; }

        #endregion
        #region Custom Properties
        
        #endregion
    }
}
