
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-02-29 09:08:36
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

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial interface IXMIncludeFieldsService
    {
        #region IXMIncludeFieldsService成员
        /// <summary>
        /// Insert into XMIncludeFields
        /// </summary>
        /// <param name="xmincludefields">XMIncludeFields</param>
    	void InsertXMIncludeFields(XMIncludeFields xmincludefields);
    	
        /// <summary>
        /// Update into XMIncludeFields
        /// </summary>
        /// <param name="xmincludefields">XMIncludeFields</param>
        void UpdateXMIncludeFields(XMIncludeFields xmincludefields);	
    	
        /// <summary>
        /// get to XMIncludeFields list
        /// </summary>
        List<XMIncludeFields> GetXMIncludeFieldsList();
    	       
    	/// <summary>
    	/// get to XMIncludeFields Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMIncludeFields Page List</returns>
    	PagedList<XMIncludeFields> SearchXMIncludeFields(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMIncludeFields by Id
        /// </summary>
        /// <param name="id">XMIncludeFields Id</param>
        /// <returns>XMIncludeFields</returns>   
        XMIncludeFields GetXMIncludeFieldsById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        XMIncludeFields GetXMIncludeFieldsListByProjectID(int projectID);
        /// <summary>
        /// 根据部门ID 查询部门所属字段集合
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        XMIncludeFields GetXMIncludeFieldsListByDepartmentID(int departmentID);

        XMIncludeFields GetXMIncludeFieldsListByNickID(int nickID);

        /// <summary>
        /// delete XMIncludeFields by Id
        /// </summary>
        /// <param name="Id">XMIncludeFields Id</param>
        void DeleteXMIncludeFields(int id);
    	
    	/// <summary>
        /// Batch delete XMIncludeFields by Id
        /// </summary>
        /// <param name="Ids">XMIncludeFields Id</param>
        void BatchDeleteXMIncludeFields(List<int> ids);

        #endregion
    }
}
