
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
    public partial interface IXMInventoryInfoService
    {
        #region IXMInventoryInfoService成员
        /// <summary>
        /// Insert into XMInventoryInfo
        /// </summary>
        /// <param name="xminventoryinfo">XMInventoryInfo</param>
    	void InsertXMInventoryInfo(XMInventoryInfo xminventoryinfo);
    	
        /// <summary>
        /// Update into XMInventoryInfo
        /// </summary>
        /// <param name="xminventoryinfo">XMInventoryInfo</param>
        void UpdateXMInventoryInfo(XMInventoryInfo xminventoryinfo);	
    	
        /// <summary>
        /// get to XMInventoryInfo list
        /// </summary>
        List<XMInventoryInfo> GetXMInventoryInfoList();
    	       
    	/// <summary>
    	/// get to XMInventoryInfo Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMInventoryInfo Page List</returns>
    	PagedList<XMInventoryInfo> SearchXMInventoryInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMInventoryInfo by Id
        /// </summary>
        /// <param name="id">XMInventoryInfo Id</param>
        /// <returns>XMInventoryInfo</returns>   
        XMInventoryInfo GetXMInventoryInfoById(int id);
    
    	/// <summary>
        /// delete XMInventoryInfo by Id
        /// </summary>
        /// <param name="Id">XMInventoryInfo Id</param>
        void DeleteXMInventoryInfo(int id);
    	
    	/// <summary>
        /// Batch delete XMInventoryInfo by Id
        /// </summary>
        /// <param name="Ids">XMInventoryInfo Id</param>
        void BatchDeleteXMInventoryInfo(List<int> ids);

        #endregion
    }
}
