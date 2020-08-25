
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-23 15:24:23
** 修改人:
** 修改日期:
** 描 述: 接口实现类
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
    public partial class XMProjectService: IXMProjectService
    {
        #region Fields
    	/// <summary>
    	/// Object context
    	/// </summary>
    	private readonly HozestERPObjectContext _context;
    	/// <summary>
    	/// Cache manager
    	/// </summary>
    	private readonly ICacheManager _cacheManager;

        #endregion
    	
        #region Ctor
    	
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
    	public XMProjectService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion

        #region IXMProjectService成员
        /// <summary>
        /// Insert into XMProject
        /// </summary>
        /// <param name="xmproject">XMProject</param>
        public void InsertXMProject(XMProject xmproject)
        {
            if (xmproject == null)
                return;

            if (!this._context.IsAttached(xmproject))

                this._context.XMProjects.AddObject(xmproject);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMProject
        /// </summary>
        /// <param name="xmproject">XMProject</param>
        public void UpdateXMProject(XMProject xmproject)
        {
            if (xmproject == null)
                return;

            if (this._context.IsAttached(xmproject))
                this._context.XMProjects.Attach(xmproject);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMProject list
        /// </summary>
        public List<XMProject> GetXMProjectList()
        {
            var query = from p in this._context.XMProjects
                        where p.IsEnable==true
                        select p;
            return query.ToList();
        }


        /// <summary>
        ///根据客户Id 查询对应的项目
        /// </summary>
        /// <param name="ClientId"></param>
        /// <returns></returns>
        public List<XMProject> GetXMProjectClientId(int ClientId)
        {
            var query = from p in this._context.XMProjects
                        where p.ClientId == ClientId
                        //&& !p.IsEnable.Value
                        select p;
            return query.ToList();
        }

        public List<XMProject> GetXMProjectListByDepID(int DepID)
        {
            var query = from p in this._context.XMProjects
                        where p.IsEnable == true
                        && p.DepartmentID == DepID
                        select p;
            return query.ToList();
        }

        /// <summary>
        ///根据项目Id 查询对应的项目
        /// </summary>
        /// <param name="ClientId"></param>
        /// <returns></returns>
      public  List<XMProject> GetXMProjectProjectIdList(List<int> ProjectId) {

          var query = from p in this._context.XMProjects
                      where ProjectId.Contains(p.Id)
                      select p;
          return query.ToList();

        }

        /// <summary>
        ///根据项目负责人查询
        /// </summary>
        /// <param name="ClientId"></param>
        /// <returns></returns>
        public List<XMProject> GetXMProjectCustomerId(int customerId)
        {
            var query = from p in this._context.XMProjects
                        where p.customerId == customerId
                        && p.IsEnable.Value==true
                        select p;
            return query.ToList();

        }



        /// <summary>
        /// 根据项目类型查询数据
        /// </summary>
        /// <param name="ProjectTypeId"></param>
        /// <returns></returns>
        public List<XMProject> GetXMProjectProjectTypeId(int ProjectTypeId) {

            var query = from p in this._context.XMProjects
                        where p.ProjectTypeId == ProjectTypeId
                        && p.IsEnable.Value == true
                        select p;
            return query.ToList();
        
        }

        /// <summary>
        /// get to XMProject list
        /// </summary>
        public List<XMProject> GetXMProjectList(string ProjectName, int ProjectTypeId, int IsEnable)
        {

            var query = from p in this._context.XMProjects
                        where p.ProjectName.Contains(ProjectName)
                        && (ProjectTypeId == -1 || p.ProjectTypeId == ProjectTypeId || p.ProjectTypeId == null)
                         && (IsEnable == -1 || p.IsEnable.Value.Equals(IsEnable == 0 ? false : true))
                        orderby p.ProjectTypeId
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据人员查询项目
        /// </summary>
        public List<XMProject> GetXMProjectListSS(int customerId,int ProjectName)
        {

            IQueryable<XMProject> query = from a in this._context.XMProjects
                        join b in this._context.XMNicks
                        on a.Id equals b.ProjectId
                        join c in this._context.XMNickCustomerMappings
                        on b.nick_id equals c.NickId
                        where (a.customerId == customerId || c.CustomerID == customerId)
                        && a.IsEnable == true && (a.ProjectTypeId == ProjectName || ProjectName==0)
                        //group a by new { Id = a.Id, ProjectName = a.ProjectName } into g
                        select a;
            return new List<XMProject>(query.ToList());
        }

        /// <summary>
        /// get to XMProject Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMProject Page List</returns>
        public PagedList<XMProject> SearchXMProject(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMProjects
                        orderby p.Id
                        select p;
            return new PagedList<XMProject>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMProject by Id
        /// </summary>
        /// <param name="id">XMProject Id</param>
        /// <returns>XMProject</returns>   
        public XMProject GetXMProjectById(int id)
        {
            var query = from p in this._context.XMProjects
                        where p.Id.Equals(id)
                         //&& !p.IsEnable.Value
                        select p;
            return query.SingleOrDefault();
        }

        public XMProject GetXMProjectByName(string ProjectName)
        {
            var query = from p in this._context.XMProjects
                        where p.ProjectName == ProjectName
                        && p.IsEnable.Value
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMProject by Id
        /// </summary>
        /// <param name="Id">XMProject Id</param>
        public void DeleteXMProject(int id)
        {
            var xmproject = this.GetXMProjectById(id);
            if (xmproject == null)
                return;

            if (!this._context.IsAttached(xmproject))
                this._context.XMProjects.Attach(xmproject);

            this._context.DeleteObject(xmproject);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMProject by Id
        /// </summary>
        /// <param name="Ids">XMProject Id</param>
        public void BatchDeleteXMProject(List<int> ids)
        {
            var query = from q in _context.XMProjects
                        where ids.Contains(q.Id)
                        select q;
            var xmprojects = query.ToList();
            foreach (var item in xmprojects)
            {
                if (!_context.IsAttached(item))
                    _context.XMProjects.Attach(item);

                _context.XMProjects.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
