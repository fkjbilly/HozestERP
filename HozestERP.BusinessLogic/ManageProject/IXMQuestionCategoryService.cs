
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-04-08 09:48:59
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
    public partial interface IXMQuestionCategoryService
    {
        #region IXMQuestionCategoryService成员
        /// <summary>
        /// Insert into XMQuestionCategory
        /// </summary>
        /// <param name="xmquestioncategory">XMQuestionCategory</param>
        void InsertXMQuestionCategory(XMQuestionCategory xmquestioncategory);

        /// <summary>
        /// Update into XMQuestionCategory
        /// </summary>
        /// <param name="xmquestioncategory">XMQuestionCategory</param>
        void UpdateXMQuestionCategory(XMQuestionCategory xmquestioncategory);

        /// <summary>
        /// get to XMQuestionCategory list
        /// </summary>
        List<XMQuestionCategory> GetXMQuestionCategoryList();
        /// <summary>
        /// 获取所有父节点列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<XMQuestionCategory> GetXMQuestionCategoryPrarentList(int parentId);

        //根据父节点ID查询列表
        List<XMQuestionCategory> GetXMQuestionCategoryByParentID(int parentID);

        /// <summary>
        /// 删除问题类型
        /// </summary>
        /// <param name="id"></param>
        void MarkQuestionCategoryAsDeleted(int id);

        /// <summary>
        /// get to XMQuestionCategory Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMQuestionCategory Page List</returns>
        PagedList<XMQuestionCategory> SearchXMQuestionCategory(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMQuestionCategory by Id
        /// </summary>
        /// <param name="id">XMQuestionCategory Id</param>
        /// <returns>XMQuestionCategory</returns>   
        XMQuestionCategory GetXMQuestionCategoryById(int id);

        /// <summary>
        /// delete XMQuestionCategory by Id
        /// </summary>
        /// <param name="Id">XMQuestionCategory Id</param>
        void DeleteXMQuestionCategory(int id);

        /// <summary>
        /// Batch delete XMQuestionCategory by Id
        /// </summary>
        /// <param name="Ids">XMQuestionCategory Id</param>
        void BatchDeleteXMQuestionCategory(List<int> ids);

        #endregion
    }
}
