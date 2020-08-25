
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
    public partial interface IXMAdjustedInfoService
    {
        #region IXMAdjustedInfoService成员
        /// <summary>
        /// Insert into XMAdjustedInfo
        /// </summary>
        /// <param name="xmadjustedinfo">XMAdjustedInfo</param>
    	void InsertXMAdjustedInfo(XMAdjustedInfo xmadjustedinfo);
    	
        /// <summary>
        /// Update into XMAdjustedInfo
        /// </summary>
        /// <param name="xmadjustedinfo">XMAdjustedInfo</param>
        void UpdateXMAdjustedInfo(XMAdjustedInfo xmadjustedinfo);	
    	
        /// <summary>
        /// get to XMAdjustedInfo list
        /// </summary>
        List<XMAdjustedInfo> GetXMAdjustedInfoList();
    	       
    	/// <summary>
    	/// get to XMAdjustedInfo Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMAdjustedInfo Page List</returns>
    	PagedList<XMAdjustedInfo> SearchXMAdjustedInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMAdjustedInfo by Id
        /// </summary>
        /// <param name="id">XMAdjustedInfo Id</param>
        /// <returns>XMAdjustedInfo</returns>   
        XMAdjustedInfo GetXMAdjustedInfoById(int id);
    
    	/// <summary>
        /// delete XMAdjustedInfo by Id
        /// </summary>
        /// <param name="Id">XMAdjustedInfo Id</param>
        void DeleteXMAdjustedInfo(int id);
    	
    	/// <summary>
        /// Batch delete XMAdjustedInfo by Id
        /// </summary>
        /// <param name="Ids">XMAdjustedInfo Id</param>
        void BatchDeleteXMAdjustedInfo(List<int> ids);

        #endregion
    }
}
