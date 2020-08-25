
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
    public partial interface IXMScalpingApplicationService
    {
        #region IXMScalpingApplicationService成员
        /// <summary>
        /// Insert into XMScalpingApplication
        /// </summary>
        /// <param name="xmscalpingapplication">XMScalpingApplication</param>
    	void InsertXMScalpingApplication(XMScalpingApplication xmscalpingapplication);
    	
        /// <summary>
        /// Update into XMScalpingApplication
        /// </summary>
        /// <param name="xmscalpingapplication">XMScalpingApplication</param>
        void UpdateXMScalpingApplication(XMScalpingApplication xmscalpingapplication);	
    	
        /// <summary>
        /// get to XMScalpingApplication list
        /// </summary>
        List<XMScalpingApplication> GetXMScalpingApplicationList();
    	       
    	/// <summary>
    	/// get to XMScalpingApplication Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMScalpingApplication Page List</returns>
    	PagedList<XMScalpingApplication> SearchXMScalpingApplication(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMScalpingApplication by ScalpingId
        /// </summary>
        /// <param name="scalpingid">XMScalpingApplication ScalpingId</param>
        /// <returns>XMScalpingApplication</returns>   
        XMScalpingApplication GetXMScalpingApplicationByScalpingId(int scalpingid);
    
    	/// <summary>
        /// delete XMScalpingApplication by ScalpingId
        /// </summary>
        /// <param name="ScalpingId">XMScalpingApplication ScalpingId</param>
        void DeleteXMScalpingApplication(int scalpingid);
    	
    	/// <summary>
        /// Batch delete XMScalpingApplication by ScalpingId
        /// </summary>
        /// <param name="ScalpingIds">XMScalpingApplication ScalpingId</param>
        void BatchDeleteXMScalpingApplication(List<int> scalpingids);

        #endregion
    }
}
