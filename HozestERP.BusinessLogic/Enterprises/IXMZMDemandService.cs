
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-08-02 16:02:10
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

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial interface IXMZMDemandService
    {
        #region IXMZMDemandService成员
        /// <summary>
        /// Insert into XMZMDemand
        /// </summary>
        /// <param name="xmzmdemand">XMZMDemand</param>
    	void InsertXMZMDemand(XMZMDemand xmzmdemand);
    	
        /// <summary>
        /// Update into XMZMDemand
        /// </summary>
        /// <param name="xmzmdemand">XMZMDemand</param>
        void UpdateXMZMDemand(XMZMDemand xmzmdemand);	
    	
        /// <summary>
        /// get to XMZMDemand list
        /// </summary>
        List<XMZMDemand> GetXMZMDemandList();
        List<XMZMDemand> GetXMZMDemandList(string requirements,int Tid);
    	       
    	/// <summary>
    	/// get to XMZMDemand Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMZMDemand Page List</returns>
    	PagedList<XMZMDemand> SearchXMZMDemand(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMZMDemand by ID
        /// </summary>
        /// <param name="id">XMZMDemand ID</param>
        /// <returns>XMZMDemand</returns>   
        XMZMDemand GetXMZMDemandByID(int id);

        int GetXMZMDemandTidByID(int id);

        List<XMZMDemand> GetXMZMDemandListByTid(int Tid);
    	/// <summary>
        /// delete XMZMDemand by ID
        /// </summary>
        /// <param name="ID">XMZMDemand ID</param>
        void DeleteXMZMDemand(int id);
    	
    	/// <summary>
        /// Batch delete XMZMDemand by ID
        /// </summary>
        /// <param name="IDs">XMZMDemand ID</param>
        void BatchDeleteXMZMDemand(List<int> ids);

        #endregion
    }
}
