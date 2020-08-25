
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
    public partial interface IXMWarehouseService
    {
        #region IXMWarehouseService成员
        /// <summary>
        /// Insert into XMWarehouse
        /// </summary>
        /// <param name="xmwarehouse">XMWarehouse</param>
    	void InsertXMWarehouse(XMWarehouse xmwarehouse);
    	
        /// <summary>
        /// Update into XMWarehouse
        /// </summary>
        /// <param name="xmwarehouse">XMWarehouse</param>
        void UpdateXMWarehouse(XMWarehouse xmwarehouse);	
    	
        /// <summary>
        /// get to XMWarehouse list
        /// </summary>
        List<XMWarehouse> GetXMWarehouseList();
    	       
    	/// <summary>
    	/// get to XMWarehouse Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMWarehouse Page List</returns>
    	PagedList<XMWarehouse> SearchXMWarehouse(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMWarehouse by ID
        /// </summary>
        /// <param name="id">XMWarehouse ID</param>
        /// <returns>XMWarehouse</returns>   
        XMWarehouse GetXMWarehouseByID(int id);
    
    	/// <summary>
        /// delete XMWarehouse by ID
        /// </summary>
        /// <param name="ID">XMWarehouse ID</param>
        void DeleteXMWarehouse(int id);
    	
    	/// <summary>
        /// Batch delete XMWarehouse by ID
        /// </summary>
        /// <param name="IDs">XMWarehouse ID</param>
        void BatchDeleteXMWarehouse(List<int> ids);

        #endregion
    }
}
