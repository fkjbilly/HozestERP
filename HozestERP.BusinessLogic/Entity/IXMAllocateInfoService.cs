
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
    public partial interface IXMAllocateInfoService
    {
        #region IXMAllocateInfoService成员
        /// <summary>
        /// Insert into XMAllocateInfo
        /// </summary>
        /// <param name="xmallocateinfo">XMAllocateInfo</param>
    	void InsertXMAllocateInfo(XMAllocateInfo xmallocateinfo);
    	
        /// <summary>
        /// Update into XMAllocateInfo
        /// </summary>
        /// <param name="xmallocateinfo">XMAllocateInfo</param>
        void UpdateXMAllocateInfo(XMAllocateInfo xmallocateinfo);	
    	
        /// <summary>
        /// get to XMAllocateInfo list
        /// </summary>
        List<XMAllocateInfo> GetXMAllocateInfoList();
    	       
    	/// <summary>
    	/// get to XMAllocateInfo Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMAllocateInfo Page List</returns>
    	PagedList<XMAllocateInfo> SearchXMAllocateInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMAllocateInfo by Id
        /// </summary>
        /// <param name="id">XMAllocateInfo Id</param>
        /// <returns>XMAllocateInfo</returns>   
        XMAllocateInfo GetXMAllocateInfoById(int id);
    
    	/// <summary>
        /// delete XMAllocateInfo by Id
        /// </summary>
        /// <param name="Id">XMAllocateInfo Id</param>
        void DeleteXMAllocateInfo(int id);
    	
    	/// <summary>
        /// Batch delete XMAllocateInfo by Id
        /// </summary>
        /// <param name="Ids">XMAllocateInfo Id</param>
        void BatchDeleteXMAllocateInfo(List<int> ids);

        #endregion
    }
}
