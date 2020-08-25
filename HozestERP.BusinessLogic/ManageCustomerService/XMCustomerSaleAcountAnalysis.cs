/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-01-11 15:07:06
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
    public partial class XMCustomerSaleAcountAnalysis
    {
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
        /// Gets or sets the DealCount
        /// </summary>
        public Nullable<int> DealCount { get; set; }


        /// <summary>
        /// Gets or sets the order DealMoney
        /// </summary>
        public Nullable<decimal> DealMoney { get; set; }
    }
}
