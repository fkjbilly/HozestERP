
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
    public partial interface IXMBusinessDataService
    {
        #region IXMBusinessDataService成员
        /// <summary>
        /// Insert into XMBusinessData
        /// </summary>
        /// <param name="xmbusinessdata">XMBusinessData</param>
    	void InsertXMBusinessData(XMBusinessData xmbusinessdata);
    	
        /// <summary>
        /// Update into XMBusinessData
        /// </summary>
        /// <param name="xmbusinessdata">XMBusinessData</param>
        void UpdateXMBusinessData(XMBusinessData xmbusinessdata);	
    	
        /// <summary>
        /// get to XMBusinessData list
        /// </summary>
        List<XMBusinessData> GetXMBusinessDataList();
    	       
    	/// <summary>
    	/// get to XMBusinessData Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMBusinessData Page List</returns>
    	PagedList<XMBusinessData> SearchXMBusinessData(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMBusinessData by ID
        /// </summary>
        /// <param name="id">XMBusinessData ID</param>
        /// <returns>XMBusinessData</returns>   
        XMBusinessData GetXMBusinessDataByID(int id);
    
    	/// <summary>
        /// delete XMBusinessData by ID
        /// </summary>
        /// <param name="ID">XMBusinessData ID</param>
        void DeleteXMBusinessData(int id);
    	
    	/// <summary>
        /// Batch delete XMBusinessData by ID
        /// </summary>
        /// <param name="IDs">XMBusinessData ID</param>
        void BatchDeleteXMBusinessData(List<int> ids);

        #endregion
    }
}
