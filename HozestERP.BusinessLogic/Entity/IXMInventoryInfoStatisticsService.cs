
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
    public partial interface IXMInventoryInfoStatisticsService
    {
        #region IXMInventoryInfoStatisticsService成员
        /// <summary>
        /// Insert into XMInventoryInfoStatistics
        /// </summary>
        /// <param name="xminventoryinfostatistics">XMInventoryInfoStatistics</param>
    	void InsertXMInventoryInfoStatistics(XMInventoryInfoStatistics xminventoryinfostatistics);
    	
        /// <summary>
        /// Update into XMInventoryInfoStatistics
        /// </summary>
        /// <param name="xminventoryinfostatistics">XMInventoryInfoStatistics</param>
        void UpdateXMInventoryInfoStatistics(XMInventoryInfoStatistics xminventoryinfostatistics);	
    	
        /// <summary>
        /// get to XMInventoryInfoStatistics list
        /// </summary>
        List<XMInventoryInfoStatistics> GetXMInventoryInfoStatisticsList();
    	       
    	/// <summary>
    	/// get to XMInventoryInfoStatistics Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMInventoryInfoStatistics Page List</returns>
    	PagedList<XMInventoryInfoStatistics> SearchXMInventoryInfoStatistics(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMInventoryInfoStatistics by Id
        /// </summary>
        /// <param name="id">XMInventoryInfoStatistics Id</param>
        /// <returns>XMInventoryInfoStatistics</returns>   
        XMInventoryInfoStatistics GetXMInventoryInfoStatisticsById(int id);
    
    	/// <summary>
        /// delete XMInventoryInfoStatistics by Id
        /// </summary>
        /// <param name="Id">XMInventoryInfoStatistics Id</param>
        void DeleteXMInventoryInfoStatistics(int id);
    	
    	/// <summary>
        /// Batch delete XMInventoryInfoStatistics by Id
        /// </summary>
        /// <param name="Ids">XMInventoryInfoStatistics Id</param>
        void BatchDeleteXMInventoryInfoStatistics(List<int> ids);

        #endregion
    }
}
