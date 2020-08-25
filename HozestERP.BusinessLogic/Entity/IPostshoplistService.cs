
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
    public partial interface IPostshoplistService
    {
        #region IPostshoplistService成员
        /// <summary>
        /// Insert into Postshoplist
        /// </summary>
        /// <param name="postshoplist">Postshoplist</param>
    	void InsertPostshoplist(Postshoplist postshoplist);
    	
        /// <summary>
        /// Update into Postshoplist
        /// </summary>
        /// <param name="postshoplist">Postshoplist</param>
        void UpdatePostshoplist(Postshoplist postshoplist);	
    	
        /// <summary>
        /// get to Postshoplist list
        /// </summary>
        List<Postshoplist> GetPostshoplistList();
    	       
    	/// <summary>
    	/// get to Postshoplist Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Postshoplist Page List</returns>
    	PagedList<Postshoplist> SearchPostshoplist(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Postshoplist by NickCustomerID
        /// </summary>
        /// <param name="nickcustomerid">Postshoplist NickCustomerID</param>
        /// <returns>Postshoplist</returns>   
        Postshoplist GetPostshoplistByNickCustomerID(int nickcustomerid);
    
    	/// <summary>
        /// delete Postshoplist by NickCustomerID
        /// </summary>
        /// <param name="NickCustomerID">Postshoplist NickCustomerID</param>
        void DeletePostshoplist(int nickcustomerid);
    	
    	/// <summary>
        /// Batch delete Postshoplist by NickCustomerID
        /// </summary>
        /// <param name="NickCustomerIDs">Postshoplist NickCustomerID</param>
        void BatchDeletePostshoplist(List<int> nickcustomerids);

        #endregion
    }
}
