
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
    public partial class XMPreSalesSalary : BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the GroupID
        /// </summary>
        public Nullable<int> GroupID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Group
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public Nullable<int> CustomerID { get; set; }

    	/// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }
    
    	/// <summary>
        /// Gets or sets the RankID
        /// </summary>
        public Nullable<int> RankID { get; set; }
    
    	/// <summary>
        /// Gets or sets the RankName
        /// </summary>
        public string RankName { get; set; }
    
    	/// <summary>
        /// Gets or sets the TotalMoney
        /// </summary>
        public Nullable<decimal> TotalMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the TotalCommission
        /// </summary>
        public Nullable<decimal> TotalCommission { get; set; }

        /// <summary>
        /// Gets or sets the TotalClickFarming
        /// </summary>
        public Nullable<decimal> TotalClickFarming { get; set; }

        /// <summary>
        /// Gets or sets the TotalRefund
        /// </summary>
        public Nullable<decimal> TotalRefund { get; set; }
    
    	/// <summary>
        /// Gets or sets the BasicSalary
        /// </summary>
        public Nullable<int> BasicSalary { get; set; }

        /// <summary>
        /// Gets or sets the BonusBase
        /// </summary>
        public Nullable<int> BonusBase { get; set; }

    	/// <summary>
        /// Gets or sets the Total
        /// </summary>
        public Nullable<decimal> Total { get; set; }

        /// <summary>
        /// Gets or sets the WangNoID
        /// </summary>
        public Nullable<int> WangNoID { get; set; }

        /// <summary>
        /// Gets or sets the WangNo
        /// </summary>
        public string WangNo { get; set; }

        /// <summary>
        /// Gets or sets the Total
        /// </summary>
        public Nullable<decimal> ActualSales { get; set; }

        /// <summary>
        /// Gets or sets the RankCoefficient
        /// </summary>
        public Nullable<decimal> RankCoefficient { get; set; }

        /// <summary>
        /// Gets or sets the Commission
        /// </summary>
        public Nullable<decimal> Commission { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<decimal> PlatformTypeId { get; set; }

        /// <summary>
        /// Gets or sets the PayPrice
        /// </summary>
        public Nullable<decimal> PayPrice { get; set; }

        /// <summary>
        /// Gets or sets the JingMao
        /// </summary>
        public Nullable<decimal> JingMao { get; set; }

        /// <summary>
        /// Gets or sets the OtherPerformance
        /// </summary>
        public Nullable<decimal> OtherPerformance { get; set; }

        /// <summary>
        /// Gets or sets the tabWangNo
        /// </summary>
        public string tabWangNo { get; set; }

        /// <summary>
        /// Gets or sets the tabWangNoList
        /// </summary>
        public List<XMPreSalesSalary> tabWangNoList { get; set; }

        #endregion
        #region Custom Properties
        
        #endregion
    }
}
