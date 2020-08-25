
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
    public partial interface IXMXLMInventoryService
    {
        #region IXMXLMInventoryService成员
        /// <summary>
        /// Insert into XMXLMInventory
        /// </summary>
        /// <param name="xmxlminventory">XMXLMInventory</param>
    	void InsertXMXLMInventory(XMXLMInventory xmxlminventory);
    	
        /// <summary>
        /// Update into XMXLMInventory
        /// </summary>
        /// <param name="xmxlminventory">XMXLMInventory</param>
        void UpdateXMXLMInventory(XMXLMInventory xmxlminventory);	
    	
        /// <summary>
        /// get to XMXLMInventory list
        /// </summary>
        List<XMXLMInventory> GetXMXLMInventoryList();
    	       
    	/// <summary>
    	/// get to XMXLMInventory Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMXLMInventory Page List</returns>
    	PagedList<XMXLMInventory> SearchXMXLMInventory(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMXLMInventory by ID
        /// </summary>
        /// <param name="id">XMXLMInventory ID</param>
        /// <returns>XMXLMInventory</returns>   
        XMXLMInventory GetXMXLMInventoryByID(int id);
    
    	/// <summary>
        /// delete XMXLMInventory by ID
        /// </summary>
        /// <param name="ID">XMXLMInventory ID</param>
        void DeleteXMXLMInventory(int id);
    	
    	/// <summary>
        /// Batch delete XMXLMInventory by ID
        /// </summary>
        /// <param name="IDs">XMXLMInventory ID</param>
        void BatchDeleteXMXLMInventory(List<int> ids);

        #endregion
    }
}
