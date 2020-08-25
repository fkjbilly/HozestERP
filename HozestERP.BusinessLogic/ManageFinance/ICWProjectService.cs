
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-06-02 15:24:33
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

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial interface ICWProjectService
    {
        #region ICWProjectService成员
        /// <summary>
        /// Insert into CWProject
        /// </summary>
        /// <param name="cwproject">CWProject</param>
    	void InsertCWProject(CWProject cwproject);
    	
        /// <summary>
        /// Update into CWProject
        /// </summary>
        /// <param name="cwproject">CWProject</param>
        void UpdateCWProject(CWProject cwproject);	
    	
        /// <summary>
        /// get to CWProject list
        /// </summary>
        List<CWProject> GetCWProjectList(int TableTypeId);
    	       
    	/// <summary>
    	/// get to CWProject Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>CWProject Page List</returns>
    	PagedList<CWProject> SearchCWProject(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a CWProject by Id
        /// </summary>
        /// <param name="id">CWProject Id</param>
        /// <returns>CWProject</returns>   
        CWProject GetCWProjectById(int id);
    
    	/// <summary>
        /// delete CWProject by Id
        /// </summary>
        /// <param name="Id">CWProject Id</param>
        void DeleteCWProject(int id);
    	
    	/// <summary>
        /// Batch delete CWProject by Id
        /// </summary>
        /// <param name="Ids">CWProject Id</param>
        void BatchDeleteCWProject(List<int> ids);

          
        /// <summary>
        /// 根据父Id查询
        /// </summary>
        /// <param name="ParentID">父级Id</param>
        /// <returns>module collection</returns>
        List<CWProject> GetCWProjectListByParentID(int ParentID);

        /// <summary>
        /// 根据 Id 查询 CWProject 列表 (获取子节点菜单列表)
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Module List</returns>
        List<CWProject> GetCWProjectByParentID(int Id);
         
         /// <summary>
        /// 新增
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="ProjectExplanation"></param>
        /// <param name="TableTypeId"></param>
        /// <param name="DisplayOrder"></param>
        /// <returns></returns> 
        CWProject InsertCWProject(int? parentId, string ProjectExplanation, int TableTypeId, int DisplayOrder);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="parentId"></param>
        /// <param name="ProjectExplanation"></param>
        /// <param name="TableTypeId"></param>
        /// <param name="DisplayOrder"></param>
        void UpdateCWProject(int Id, int? parentId, string ProjectExplanation, int TableTypeId, int DisplayOrder);
        #endregion
    }
}
