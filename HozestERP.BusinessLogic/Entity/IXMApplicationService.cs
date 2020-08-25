
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
    public partial interface IXMApplicationService
    {
        #region IXMApplicationService成员
        /// <summary>
        /// Insert into XMApplication
        /// </summary>
        /// <param name="xmapplication">XMApplication</param>
    	void InsertXMApplication(XMApplication xmapplication);
    	
        /// <summary>
        /// Update into XMApplication
        /// </summary>
        /// <param name="xmapplication">XMApplication</param>
        void UpdateXMApplication(XMApplication xmapplication);	
    	
        /// <summary>
        /// get to XMApplication list
        /// </summary>
        List<XMApplication> GetXMApplicationList();
    	       
    	/// <summary>
    	/// get to XMApplication Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMApplication Page List</returns>
    	PagedList<XMApplication> SearchXMApplication(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMApplication by ID
        /// </summary>
        /// <param name="id">XMApplication ID</param>
        /// <returns>XMApplication</returns>   
        XMApplication GetXMApplicationByID(int id);
    
    	/// <summary>
        /// delete XMApplication by ID
        /// </summary>
        /// <param name="ID">XMApplication ID</param>
        void DeleteXMApplication(int id);
    	
    	/// <summary>
        /// Batch delete XMApplication by ID
        /// </summary>
        /// <param name="IDs">XMApplication ID</param>
        void BatchDeleteXMApplication(List<int> ids);

        #endregion
    }
}
