
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
    public partial interface IXMNickService
    {
        #region IXMNickService成员
        /// <summary>
        /// Insert into XMNick
        /// </summary>
        /// <param name="xmnick">XMNick</param>
    	void InsertXMNick(XMNick xmnick);
    	
        /// <summary>
        /// Update into XMNick
        /// </summary>
        /// <param name="xmnick">XMNick</param>
        void UpdateXMNick(XMNick xmnick);	
    	
        /// <summary>
        /// get to XMNick list
        /// </summary>
        List<XMNick> GetXMNickList();
    	       
    	/// <summary>
    	/// get to XMNick Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMNick Page List</returns>
    	PagedList<XMNick> SearchXMNick(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMNick by nick_id
        /// </summary>
        /// <param name="nick_id">XMNick nick_id</param>
        /// <returns>XMNick</returns>   
        XMNick GetXMNickBynick_id(int nick_id);
    
    	/// <summary>
        /// delete XMNick by nick_id
        /// </summary>
        /// <param name="nick_id">XMNick nick_id</param>
        void DeleteXMNick(int nick_id);
    	
    	/// <summary>
        /// Batch delete XMNick by nick_id
        /// </summary>
        /// <param name="nick_ids">XMNick nick_id</param>
        void BatchDeleteXMNick(List<int> nick_ids);

        #endregion
    }
}
