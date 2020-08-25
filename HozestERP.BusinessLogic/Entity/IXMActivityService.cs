
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
    public partial interface IXMActivityService
    {
        #region IXMActivityService成员
        /// <summary>
        /// Insert into XMActivity
        /// </summary>
        /// <param name="xmactivity">XMActivity</param>
    	void InsertXMActivity(XMActivity xmactivity);
    	
        /// <summary>
        /// Update into XMActivity
        /// </summary>
        /// <param name="xmactivity">XMActivity</param>
        void UpdateXMActivity(XMActivity xmactivity);	
    	
        /// <summary>
        /// get to XMActivity list
        /// </summary>
        List<XMActivity> GetXMActivityList();
    	       
    	/// <summary>
    	/// get to XMActivity Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMActivity Page List</returns>
    	PagedList<XMActivity> SearchXMActivity(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMActivity by Id
        /// </summary>
        /// <param name="id">XMActivity Id</param>
        /// <returns>XMActivity</returns>   
        XMActivity GetXMActivityById(int id);
    
    	/// <summary>
        /// delete XMActivity by Id
        /// </summary>
        /// <param name="Id">XMActivity Id</param>
        void DeleteXMActivity(int id);
    	
    	/// <summary>
        /// Batch delete XMActivity by Id
        /// </summary>
        /// <param name="Ids">XMActivity Id</param>
        void BatchDeleteXMActivity(List<int> ids);

        #endregion
    }
}
