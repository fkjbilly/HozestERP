
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-03-23 15:30:16
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMAdvertingFieldService
    {
        #region IXMAdvertingFieldService成员
        /// <summary>
        /// Insert into XMAdvertingField
        /// </summary>
        /// <param name="xmadvertingfield">XMAdvertingField</param>
    	void InsertXMAdvertingField(XMAdvertingField xmadvertingfield);
    	
        /// <summary>
        /// Update into XMAdvertingField
        /// </summary>
        /// <param name="xmadvertingfield">XMAdvertingField</param>
        void UpdateXMAdvertingField(XMAdvertingField xmadvertingfield);	
    	
        /// <summary>
        /// get to XMAdvertingField list
        /// </summary>
        List<XMAdvertingField> GetXMAdvertingFieldList();
    	       
    	/// <summary>
    	/// get to XMAdvertingField Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMAdvertingField Page List</returns>
    	PagedList<XMAdvertingField> SearchXMAdvertingField(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMAdvertingField by Id
        /// </summary>
        /// <param name="id">XMAdvertingField Id</param>
        /// <returns>XMAdvertingField</returns>   
        XMAdvertingField GetXMAdvertingFieldById(int id);
    
    	/// <summary>
        /// delete XMAdvertingField by Id
        /// </summary>
        /// <param name="Id">XMAdvertingField Id</param>
        void DeleteXMAdvertingField(int id);
    	
    	/// <summary>
        /// Batch delete XMAdvertingField by Id
        /// </summary>
        /// <param name="Ids">XMAdvertingField Id</param>
        void BatchDeleteXMAdvertingField(List<int> ids);

        #endregion
    }
}
