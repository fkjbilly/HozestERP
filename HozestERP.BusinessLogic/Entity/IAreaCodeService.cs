
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
    public partial interface IAreaCodeService
    {
        #region IAreaCodeService成员
        /// <summary>
        /// Insert into AreaCode
        /// </summary>
        /// <param name="areacode">AreaCode</param>
    	void InsertAreaCode(AreaCode areacode);
    	
        /// <summary>
        /// Update into AreaCode
        /// </summary>
        /// <param name="areacode">AreaCode</param>
        void UpdateAreaCode(AreaCode areacode);	
    	
        /// <summary>
        /// get to AreaCode list
        /// </summary>
        List<AreaCode> GetAreaCodeList();
    	       
    	/// <summary>
    	/// get to AreaCode Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>AreaCode Page List</returns>
    	PagedList<AreaCode> SearchAreaCode(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a AreaCode by xmlid
        /// </summary>
        /// <param name="xmlid">AreaCode xmlid</param>
        /// <returns>AreaCode</returns>   
        AreaCode GetAreaCodeByxmlid(int xmlid);
    
    	/// <summary>
        /// delete AreaCode by xmlid
        /// </summary>
        /// <param name="xmlid">AreaCode xmlid</param>
        void DeleteAreaCode(int xmlid);
    	
    	/// <summary>
        /// Batch delete AreaCode by xmlid
        /// </summary>
        /// <param name="xmlids">AreaCode xmlid</param>
        void BatchDeleteAreaCode(List<int> xmlids);

        #endregion
    }
}
