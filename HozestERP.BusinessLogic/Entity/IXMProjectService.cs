
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
    public partial interface IXMProjectService
    {
        #region IXMProjectService成员
        /// <summary>
        /// Insert into XMProject
        /// </summary>
        /// <param name="xmproject">XMProject</param>
    	void InsertXMProject(XMProject xmproject);
    	
        /// <summary>
        /// Update into XMProject
        /// </summary>
        /// <param name="xmproject">XMProject</param>
        void UpdateXMProject(XMProject xmproject);	
    	
        /// <summary>
        /// get to XMProject list
        /// </summary>
        List<XMProject> GetXMProjectList();
    	       
    	/// <summary>
    	/// get to XMProject Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMProject Page List</returns>
    	PagedList<XMProject> SearchXMProject(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMProject by Id
        /// </summary>
        /// <param name="id">XMProject Id</param>
        /// <returns>XMProject</returns>   
        XMProject GetXMProjectById(int id);
    
    	/// <summary>
        /// delete XMProject by Id
        /// </summary>
        /// <param name="Id">XMProject Id</param>
        void DeleteXMProject(int id);
    	
    	/// <summary>
        /// Batch delete XMProject by Id
        /// </summary>
        /// <param name="Ids">XMProject Id</param>
        void BatchDeleteXMProject(List<int> ids);

        #endregion
    }
}
