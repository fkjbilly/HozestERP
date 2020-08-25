
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
    public partial interface IXMScalpingApplicationDetailsService
    {
        #region IXMScalpingApplicationDetailsService成员
        /// <summary>
        /// Insert into XMScalpingApplicationDetails
        /// </summary>
        /// <param name="xmscalpingapplicationdetails">XMScalpingApplicationDetails</param>
    	void InsertXMScalpingApplicationDetails(XMScalpingApplicationDetails xmscalpingapplicationdetails);
    	
        /// <summary>
        /// Update into XMScalpingApplicationDetails
        /// </summary>
        /// <param name="xmscalpingapplicationdetails">XMScalpingApplicationDetails</param>
        void UpdateXMScalpingApplicationDetails(XMScalpingApplicationDetails xmscalpingapplicationdetails);	
    	
        /// <summary>
        /// get to XMScalpingApplicationDetails list
        /// </summary>
        List<XMScalpingApplicationDetails> GetXMScalpingApplicationDetailsList();
    	       
    	/// <summary>
    	/// get to XMScalpingApplicationDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMScalpingApplicationDetails Page List</returns>
    	PagedList<XMScalpingApplicationDetails> SearchXMScalpingApplicationDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMScalpingApplicationDetails by ScalpingDetailsId
        /// </summary>
        /// <param name="scalpingdetailsid">XMScalpingApplicationDetails ScalpingDetailsId</param>
        /// <returns>XMScalpingApplicationDetails</returns>   
        XMScalpingApplicationDetails GetXMScalpingApplicationDetailsByScalpingDetailsId(int scalpingdetailsid);
    
    	/// <summary>
        /// delete XMScalpingApplicationDetails by ScalpingDetailsId
        /// </summary>
        /// <param name="ScalpingDetailsId">XMScalpingApplicationDetails ScalpingDetailsId</param>
        void DeleteXMScalpingApplicationDetails(int scalpingdetailsid);
    	
    	/// <summary>
        /// Batch delete XMScalpingApplicationDetails by ScalpingDetailsId
        /// </summary>
        /// <param name="ScalpingDetailsIds">XMScalpingApplicationDetails ScalpingDetailsId</param>
        void BatchDeleteXMScalpingApplicationDetails(List<int> scalpingdetailsids);

        #endregion
    }
}
