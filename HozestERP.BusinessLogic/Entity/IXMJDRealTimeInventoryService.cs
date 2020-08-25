
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
    public partial interface IXMJDRealTimeInventoryService
    {
        #region IXMJDRealTimeInventoryService成员
        /// <summary>
        /// Insert into XMJDRealTimeInventory
        /// </summary>
        /// <param name="xmjdrealtimeinventory">XMJDRealTimeInventory</param>
    	void InsertXMJDRealTimeInventory(XMJDRealTimeInventory xmjdrealtimeinventory);
    	
        /// <summary>
        /// Update into XMJDRealTimeInventory
        /// </summary>
        /// <param name="xmjdrealtimeinventory">XMJDRealTimeInventory</param>
        void UpdateXMJDRealTimeInventory(XMJDRealTimeInventory xmjdrealtimeinventory);	
    	
        /// <summary>
        /// get to XMJDRealTimeInventory list
        /// </summary>
        List<XMJDRealTimeInventory> GetXMJDRealTimeInventoryList();
    	       
    	/// <summary>
    	/// get to XMJDRealTimeInventory Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMJDRealTimeInventory Page List</returns>
    	PagedList<XMJDRealTimeInventory> SearchXMJDRealTimeInventory(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMJDRealTimeInventory by Id
        /// </summary>
        /// <param name="id">XMJDRealTimeInventory Id</param>
        /// <returns>XMJDRealTimeInventory</returns>   
        XMJDRealTimeInventory GetXMJDRealTimeInventoryById(int id);
    
    	/// <summary>
        /// delete XMJDRealTimeInventory by Id
        /// </summary>
        /// <param name="Id">XMJDRealTimeInventory Id</param>
        void DeleteXMJDRealTimeInventory(int id);
    	
    	/// <summary>
        /// Batch delete XMJDRealTimeInventory by Id
        /// </summary>
        /// <param name="Ids">XMJDRealTimeInventory Id</param>
        void BatchDeleteXMJDRealTimeInventory(List<int> ids);

        #endregion
    }
}
