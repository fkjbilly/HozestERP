
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
    public partial interface IXMPdInfoService
    {
        #region IXMPdInfoService成员
        /// <summary>
        /// Insert into XMPdInfo
        /// </summary>
        /// <param name="xmpdinfo">XMPdInfo</param>
    	void InsertXMPdInfo(XMPdInfo xmpdinfo);
    	
        /// <summary>
        /// Update into XMPdInfo
        /// </summary>
        /// <param name="xmpdinfo">XMPdInfo</param>
        void UpdateXMPdInfo(XMPdInfo xmpdinfo);	
    	
        /// <summary>
        /// get to XMPdInfo list
        /// </summary>
        List<XMPdInfo> GetXMPdInfoList();
    	       
    	/// <summary>
    	/// get to XMPdInfo Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMPdInfo Page List</returns>
    	PagedList<XMPdInfo> SearchXMPdInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMPdInfo by Id
        /// </summary>
        /// <param name="id">XMPdInfo Id</param>
        /// <returns>XMPdInfo</returns>   
        XMPdInfo GetXMPdInfoById(int id);
    
    	/// <summary>
        /// delete XMPdInfo by Id
        /// </summary>
        /// <param name="Id">XMPdInfo Id</param>
        void DeleteXMPdInfo(int id);
    	
    	/// <summary>
        /// Batch delete XMPdInfo by Id
        /// </summary>
        /// <param name="Ids">XMPdInfo Id</param>
        void BatchDeleteXMPdInfo(List<int> ids);

        #endregion
    }
}
