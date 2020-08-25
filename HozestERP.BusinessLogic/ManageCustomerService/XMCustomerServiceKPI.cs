
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-05-27 09:22:34
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

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMCustomerServiceKPI : BaseEntity
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
        /// Gets or sets the BasicSalary
        /// </summary>
        public Nullable<int> BasicSalary { get; set; }

        /// <summary>
        /// Gets or sets the BonusBase
        /// </summary>
        public Nullable<int> BonusBase { get; set; }

        /// <summary>
        /// Gets or sets the RealBonus
        /// </summary>
        public string RealBonus { get; set; }

        /// <summary>
        /// Gets or sets the Total
        /// </summary>
        public double Total { get; set; }

        /// <summary>
        /// Gets or sets the CustomerComplaintsS
        /// </summary>
        public int CustomerComplaintsS { get; set; }

        /// <summary>
        /// Gets or sets the TMIndex
        /// </summary>
        public int TMIndexS { get; set; }

        /// <summary>
        /// Gets or sets the EvaluationPoints
        /// </summary>
        public double EvaluationPointsS { get; set; }

        /// <summary>
        /// Gets or sets the ReturnRateA
        /// </summary>
        public double ReturnRate { get; set; }

        /// <summary>
        /// Gets or sets the ReturnRateS
        /// </summary>
        public double ReturnRateS { get; set; }

        /// <summary>
        /// Gets or sets the GroupAverage
        /// </summary>
        public double GroupAverage { get; set; }

        /// <summary>
        /// Gets or sets the GroupAverageP
        /// </summary>
        public string GroupAverageP { get; set; }

        /// <summary>
        /// Gets or sets the GroupAverageS
        /// </summary>
        public double GroupAverageS { get; set; }

        /// <summary>
        /// Gets or sets the ResponseTimeS
        /// </summary>
        public double ResponseTimeS { get; set; }

        /// <summary>
        /// Gets or sets the DSRS
        /// </summary>
        public double DSRS { get; set; }

        /// <summary>
        /// Gets or sets the JingdongSaleS
        /// </summary>
        public double JingdongSaleS { get; set; }

        /// <summary>
        /// Gets or sets the AftermarketErrorS
        /// </summary>
        public int AftermarketErrorS { get; set; }

        /// <summary>
        /// Gets or sets the KPIScore
        /// </summary>
        public string KPIScore { get; set; }

        /// <summary>
        /// Gets or sets the tabKPI
        /// </summary>
        public string tabKPI { get; set; }

        /// <summary>
        /// Gets or sets the Percent
        /// </summary>
        public string Percent { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
