
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
    public partial interface IXMActivityTypeService
    {
        #region IXMActivityTypeService成员
        /// <summary>
        /// Insert into XMActivityType
        /// </summary>
        /// <param name="xmactivitytype">XMActivityType</param>
    	void InsertXMActivityType(XMActivityType xmactivitytype);
    	
        /// <summary>
        /// Update into XMActivityType
        /// </summary>
        /// <param name="xmactivitytype">XMActivityType</param>
        void UpdateXMActivityType(XMActivityType xmactivitytype);	
    	
        /// <summary>
        /// get to XMActivityType list
        /// </summary>
        List<XMActivityType> GetXMActivityTypeList();
    	       
    	/// <summary>
    	/// get to XMActivityType Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMActivityType Page List</returns>
    	PagedList<XMActivityType> SearchXMActivityType(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMActivityType by Id
        /// </summary>
        /// <param name="id">XMActivityType Id</param>
        /// <returns>XMActivityType</returns>   
        XMActivityType GetXMActivityTypeById(int id);
    
    	/// <summary>
        /// delete XMActivityType by Id
        /// </summary>
        /// <param name="Id">XMActivityType Id</param>
        void DeleteXMActivityType(int id);
    	
    	/// <summary>
        /// Batch delete XMActivityType by Id
        /// </summary>
        /// <param name="Ids">XMActivityType Id</param>
        void BatchDeleteXMActivityType(List<int> ids);

        #endregion
    }
}
