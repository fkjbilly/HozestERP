
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
    public partial interface IXMPremiumsService
    {
        #region IXMPremiumsService成员
        /// <summary>
        /// Insert into XMPremiums
        /// </summary>
        /// <param name="xmpremiums">XMPremiums</param>
    	void InsertXMPremiums(XMPremiums xmpremiums);
    	
        /// <summary>
        /// Update into XMPremiums
        /// </summary>
        /// <param name="xmpremiums">XMPremiums</param>
        void UpdateXMPremiums(XMPremiums xmpremiums);	
    	
        /// <summary>
        /// get to XMPremiums list
        /// </summary>
        List<XMPremiums> GetXMPremiumsList();
    	       
    	/// <summary>
    	/// get to XMPremiums Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMPremiums Page List</returns>
    	PagedList<XMPremiums> SearchXMPremiums(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMPremiums by Id
        /// </summary>
        /// <param name="id">XMPremiums Id</param>
        /// <returns>XMPremiums</returns>   
        XMPremiums GetXMPremiumsById(int id);
    
    	/// <summary>
        /// delete XMPremiums by Id
        /// </summary>
        /// <param name="Id">XMPremiums Id</param>
        void DeleteXMPremiums(int id);
    	
    	/// <summary>
        /// Batch delete XMPremiums by Id
        /// </summary>
        /// <param name="Ids">XMPremiums Id</param>
        void BatchDeleteXMPremiums(List<int> ids);

        #endregion
    }
}
