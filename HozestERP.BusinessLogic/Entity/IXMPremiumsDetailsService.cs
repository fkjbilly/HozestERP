
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:27:57
** 修改人:
** 修改日期:
** 描 述: 接口类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Entity
{
    public partial interface IXMPremiumsDetailsService
    {
        #region IXMPremiumsDetailsService成员
        /// <summary>
        /// Insert into XMPremiumsDetails
        /// </summary>
        /// <param name="xmpremiumsdetails">XMPremiumsDetails</param>
    	void InsertXMPremiumsDetails(XMPremiumsDetails xmpremiumsdetails);
    	
        /// <summary>
        /// Update into XMPremiumsDetails
        /// </summary>
        /// <param name="xmpremiumsdetails">XMPremiumsDetails</param>
        void UpdateXMPremiumsDetails(XMPremiumsDetails xmpremiumsdetails);	
    	
        /// <summary>
        /// get to XMPremiumsDetails list
        /// </summary>
        List<XMPremiumsDetails> GetXMPremiumsDetailsList();
    	       
    	/// <summary>
    	/// get to XMPremiumsDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMPremiumsDetails Page List</returns>
    	PagedList<XMPremiumsDetails> SearchXMPremiumsDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMPremiumsDetails by Id
        /// </summary>
        /// <param name="id">XMPremiumsDetails Id</param>
        /// <returns>XMPremiumsDetails</returns>   
        XMPremiumsDetails GetXMPremiumsDetailsById(int id);
    
    	/// <summary>
        /// delete XMPremiumsDetails by Id
        /// </summary>
        /// <param name="Id">XMPremiumsDetails Id</param>
        void DeleteXMPremiumsDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMPremiumsDetails by Id
        /// </summary>
        /// <param name="Ids">XMPremiumsDetails Id</param>
        void BatchDeleteXMPremiumsDetails(List<int> ids);

        #endregion
    }
}
