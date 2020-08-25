
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-12-08 13:14:09
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
using HozestERP.BusinessLogic.Enterprises;

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial class XMBusinessDataBrief : BaseEntity
    {
    	/// <summary>
        /// Gets or sets the ContractNumber
        /// </summary>
        public string ContractNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the ContractAmount
        /// </summary>
        public Nullable<decimal> ContractAmount { get; set; }
    
    	/// <summary>
        /// Gets or sets the ClientCompany
        /// </summary>
        public string ClientCompany { get; set; }

        /// <summary>
        /// Gets or sets the PayPerson
        /// </summary>
        public string PayPerson { get; set; }
    }
}
