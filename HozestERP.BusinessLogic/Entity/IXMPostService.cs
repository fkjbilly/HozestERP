
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
    public partial interface IXMPostService
    {
        #region IXMPostService成员
        /// <summary>
        /// Insert into XMPost
        /// </summary>
        /// <param name="xmpost">XMPost</param>
    	void InsertXMPost(XMPost xmpost);
    	
        /// <summary>
        /// Update into XMPost
        /// </summary>
        /// <param name="xmpost">XMPost</param>
        void UpdateXMPost(XMPost xmpost);	
    	
        /// <summary>
        /// get to XMPost list
        /// </summary>
        List<XMPost> GetXMPostList();
    	       
    	/// <summary>
    	/// get to XMPost Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMPost Page List</returns>
    	PagedList<XMPost> SearchXMPost(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMPost by Id
        /// </summary>
        /// <param name="id">XMPost Id</param>
        /// <returns>XMPost</returns>   
        XMPost GetXMPostById(int id);
    
    	/// <summary>
        /// delete XMPost by Id
        /// </summary>
        /// <param name="Id">XMPost Id</param>
        void DeleteXMPost(int id);
    	
    	/// <summary>
        /// Batch delete XMPost by Id
        /// </summary>
        /// <param name="Ids">XMPost Id</param>
        void BatchDeleteXMPost(List<int> ids);

        #endregion
    }
}
