
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
    public partial interface IXMScalpingService
    {
        #region IXMScalpingService成员
        /// <summary>
        /// Insert into XMScalping
        /// </summary>
        /// <param name="xmscalping">XMScalping</param>
    	void InsertXMScalping(XMScalping xmscalping);
    	
        /// <summary>
        /// Update into XMScalping
        /// </summary>
        /// <param name="xmscalping">XMScalping</param>
        void UpdateXMScalping(XMScalping xmscalping);	
    	
        /// <summary>
        /// get to XMScalping list
        /// </summary>
        List<XMScalping> GetXMScalpingList();
    	       
    	/// <summary>
    	/// get to XMScalping Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMScalping Page List</returns>
    	PagedList<XMScalping> SearchXMScalping(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMScalping by ID
        /// </summary>
        /// <param name="id">XMScalping ID</param>
        /// <returns>XMScalping</returns>   
        XMScalping GetXMScalpingByID(int id);
    
    	/// <summary>
        /// delete XMScalping by ID
        /// </summary>
        /// <param name="ID">XMScalping ID</param>
        void DeleteXMScalping(int id);
    	
    	/// <summary>
        /// Batch delete XMScalping by ID
        /// </summary>
        /// <param name="IDs">XMScalping ID</param>
        void BatchDeleteXMScalping(List<int> ids);

        #endregion
    }
}
