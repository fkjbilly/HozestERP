
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 方银朗
** 创建日期:2014-06-10 09:51:27
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

namespace HozestERP.BusinessLogic.ManageProject
{ 
    public partial interface IXMOrderInfoAppService
    {
        #region IXMOrderInfoAppService成员
        /// <summary>
        /// Insert into XMOrderInfoApp
        /// </summary>
        /// <param name="xmorderinfoapp">XMOrderInfoApp</param>
    	void InsertXMOrderInfoApp(XMOrderInfoApp xmorderinfoapp);
    	
        /// <summary>
        /// Update into XMOrderInfoApp
        /// </summary>
        /// <param name="xmorderinfoapp">XMOrderInfoApp</param>
        void UpdateXMOrderInfoApp(XMOrderInfoApp xmorderinfoapp);	
    	
        /// <summary>
        /// get to XMOrderInfoApp list
        /// </summary>
        List<XMOrderInfoApp> GetXMOrderInfoAppList();

        /// <summary>
        /// get to XMProject list
        /// </summary>
        List<XMOrderInfoApp> GetXMProjectList(int ddlNickId, int ProjectTypeId);

        /// <summary>
        /// get to XMOrderInfoApp list
        /// </summary>
        List<XMOrderInfoApp> GetXMOrderInfoAppByPlatformTypeId(int PlatformTypeId);
    	       
    	/// <summary>
    	/// get to XMOrderInfoApp Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMOrderInfoApp Page List</returns>
    	PagedList<XMOrderInfoApp> SearchXMOrderInfoApp(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMOrderInfoApp by ID
        /// </summary>
        /// <param name="id">XMOrderInfoApp ID</param>
        /// <returns>XMOrderInfoApp</returns>   
        XMOrderInfoApp GetXMOrderInfoAppByID(int id);
    
    	/// <summary>
        /// delete XMOrderInfoApp by ID
        /// </summary>
        /// <param name="ID">XMOrderInfoApp ID</param>
        void DeleteXMOrderInfoApp(int id);
    	
    	/// <summary>
        /// Batch delete XMOrderInfoApp by ID
        /// </summary>
        /// <param name="IDs">XMOrderInfoApp ID</param>
        void BatchDeleteXMOrderInfoApp(List<int> ids);

        #endregion
    }
}
