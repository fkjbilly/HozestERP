
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
    public partial interface IXMStorageService
    {
        #region IXMStorageService成员
        /// <summary>
        /// Insert into XMStorage
        /// </summary>
        /// <param name="xmstorage">XMStorage</param>
    	void InsertXMStorage(XMStorage xmstorage);
    	
        /// <summary>
        /// Update into XMStorage
        /// </summary>
        /// <param name="xmstorage">XMStorage</param>
        void UpdateXMStorage(XMStorage xmstorage);	
    	
        /// <summary>
        /// get to XMStorage list
        /// </summary>
        List<XMStorage> GetXMStorageList();
    	       
    	/// <summary>
    	/// get to XMStorage Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMStorage Page List</returns>
    	PagedList<XMStorage> SearchXMStorage(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMStorage by Id
        /// </summary>
        /// <param name="id">XMStorage Id</param>
        /// <returns>XMStorage</returns>   
        XMStorage GetXMStorageById(int id);
    
    	/// <summary>
        /// delete XMStorage by Id
        /// </summary>
        /// <param name="Id">XMStorage Id</param>
        void DeleteXMStorage(int id);
    	
    	/// <summary>
        /// Batch delete XMStorage by Id
        /// </summary>
        /// <param name="Ids">XMStorage Id</param>
        void BatchDeleteXMStorage(List<int> ids);

        #endregion
    }
}
