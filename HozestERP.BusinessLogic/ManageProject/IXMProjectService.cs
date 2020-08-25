
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-23 15:24:22
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
        ///根据客户Id 查询对应的项目
        /// </summary>
        /// <param name="ClientId"></param>
        /// <returns></returns>
        List<XMProject> GetXMProjectClientId(int ClientId);

        List<XMProject> GetXMProjectListByDepID(int DepID);

        /// <summary>
        ///根据项目Id 查询对应的项目
        /// </summary>
        /// <param name="ClientId"></param>
        /// <returns></returns>
        List<XMProject> GetXMProjectProjectIdList(List<int> ProjectId);

        
        /// <summary>
        ///根据项目负责人查询
        /// </summary>
        /// <param name="ClientId"></param>
        /// <returns></returns>
        List<XMProject> GetXMProjectCustomerId(int customerId);

        /// <summary>
        /// 根据项目类型查询数据
        /// </summary>
        /// <param name="ProjectTypeId"></param>
        /// <returns></returns>
        List<XMProject> GetXMProjectProjectTypeId(int ProjectTypeId);

        /// <summary>
        /// get to XMProject list
        /// </summary>
        List<XMProject> GetXMProjectList(string ProjectName, int ProjectTypeId, int IsEnable);

        /// <summary>
        /// 根据人员查询项目
        /// </summary>
        List<XMProject> GetXMProjectListSS(int customerId, int ProjectName);

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

        XMProject GetXMProjectByName(string ProjectName);


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
