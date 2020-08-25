
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
    public partial interface IXMWangNoService
    {
        #region IXMWangNoService成员
        /// <summary>
        /// Insert into XMWangNo
        /// </summary>
        /// <param name="xmwangno">XMWangNo</param>
    	void InsertXMWangNo(XMWangNo xmwangno);
    	
        /// <summary>
        /// Update into XMWangNo
        /// </summary>
        /// <param name="xmwangno">XMWangNo</param>
        void UpdateXMWangNo(XMWangNo xmwangno);	
    	
        /// <summary>
        /// get to XMWangNo list
        /// </summary>
        List<XMWangNo> GetXMWangNoList();
    	       
    	/// <summary>
    	/// get to XMWangNo Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMWangNo Page List</returns>
    	PagedList<XMWangNo> SearchXMWangNo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMWangNo by ID
        /// </summary>
        /// <param name="id">XMWangNo ID</param>
        /// <returns>XMWangNo</returns>   
        XMWangNo GetXMWangNoByID(int id);
    
    	/// <summary>
        /// delete XMWangNo by ID
        /// </summary>
        /// <param name="ID">XMWangNo ID</param>
        void DeleteXMWangNo(int id);
    	
    	/// <summary>
        /// Batch delete XMWangNo by ID
        /// </summary>
        /// <param name="IDs">XMWangNo ID</param>
        void BatchDeleteXMWangNo(List<int> ids);

        #endregion
    }
}
