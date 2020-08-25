
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-06-02 15:24:37
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

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class CWProjectService: ICWProjectService
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
    	public CWProjectService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICWProjectService成员
        /// <summary>
        /// Insert into CWProject
        /// </summary>
        /// <param name="cwproject">CWProject</param>
    	public void InsertCWProject(CWProject cwproject)
    	{	
            if (cwproject == null)
                return;
    
            if (!this._context.IsAttached(cwproject))
    			
                this._context.CWProjects.AddObject(cwproject);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into CWProject
        /// </summary>
        /// <param name="cwproject">CWProject</param>
        public void UpdateCWProject(CWProject cwproject)
        {
            if (cwproject == null)
                return;
    
            if (this._context.IsAttached(cwproject))
                this._context.CWProjects.Attach(cwproject);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to CWProject list
        /// </summary>
        public List<CWProject> GetCWProjectList(int TableTypeId)
        {		
            var query = from p in this._context.CWProjects
                        where p.IsEnable==false
                        && p.TableTypeId.Value==TableTypeId
                        orderby p.DisplayOrder ascending
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to CWProject Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CWProject Page List</returns>
        public PagedList<CWProject> SearchCWProject(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CWProjects
                        orderby p.Id
                        select p;
            return new PagedList<CWProject>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a CWProject by Id
        /// </summary>
        /// <param name="id">CWProject Id</param>
        /// <returns>CWProject</returns>   
        public CWProject GetCWProjectById(int id)
        {
            var query = from p in this._context.CWProjects
                        where p.Id.Equals(id) 
                        && p.IsEnable == false
                        orderby p.DisplayOrder ascending
                        
                        select p;
            return query.SingleOrDefault();  
        }
    
    	/// <summary>
        /// delete CWProject by Id
        /// </summary>
        /// <param name="Id">CWProject Id</param>
        public void DeleteCWProject(int id)
        {
            var cwproject = this.GetCWProjectById(id);
            if (cwproject == null)
                return;
    
            if (!this._context.IsAttached(cwproject))
                this._context.CWProjects.Attach(cwproject);
    
            this._context.DeleteObject(cwproject);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete CWProject by Id
        /// </summary>
        /// <param name="Ids">CWProject Id</param>
        public void BatchDeleteCWProject(List<int> ids)
        {
    	   var query = from q in _context.CWProjects
                    where ids.Contains(q.Id)
                    select q;
            var cwprojects = query.ToList();
            foreach (var item in cwprojects)
            {
                if (!_context.IsAttached(item))
                    _context.CWProjects.Attach(item);  
    
                _context.CWProjects.DeleteObject(item);    
            }
            _context.SaveChanges();
        }



        /// <summary>
        /// 根据父Id查询
        /// </summary>
        /// <param name="ParentID">父级Id</param>
        /// <returns>module collection</returns>
        public List<CWProject> GetCWProjectListByParentID(int ParentID)
        { 
            var query = from p in this._context.CWProjects
                       where p.ParentID == ParentID 
                       && p.IsEnable.Value==false
                       orderby p.DisplayOrder ascending
                       select p;
           var modules = query.ToList();

           return modules;
        
        }
         
        /// <summary>
        /// 根据 Id 查询 CWProject 列表 (获取子节点菜单列表)
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Module List</returns>
        public List<CWProject> GetCWProjectByParentID(int Id)
        {
            var query = from p in this._context.CWProjects
                        where p.ParentID == Id 
                        && p.IsEnable==false
                        orderby p.DisplayOrder ascending
                        select p;
            var modules = query.ToList();

            return modules;
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="ProjectExplanation"></param>
        /// <param name="TableTypeId"></param>
        /// <param name="DisplayOrder"></param>
        /// <returns></returns> 
      public  CWProject InsertCWProject(int? parentId, string ProjectExplanation, int TableTypeId, int DisplayOrder) {

          var Project = _context.CWProjects.CreateObject();
          Project.ParentID = parentId;
          Project.ProjectExplanation=ProjectExplanation;
          Project.TableTypeId = TableTypeId;
          Project.DisplayOrder = DisplayOrder;
          Project.IsEnable = false;
          Project.CreateID = HozestERPContext.Current.User.CustomerID;
          Project.CreateDateTime = DateTime.Now;
          Project.UpdateID = HozestERPContext.Current.User.CustomerID;
          Project.UpdateDateTime = DateTime.Now;
          _context.CWProjects.AddObject(Project);
          _context.SaveChanges(); 
          return Project;

        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="parentId"></param>
        /// <param name="ProjectExplanation"></param>
        /// <param name="TableTypeId"></param>
        /// <param name="DisplayOrder"></param>
      public void UpdateCWProject(int Id, int? parentId, string ProjectExplanation, int TableTypeId, int DisplayOrder)
      {

          var Project = GetCWProjectById(Id);
          if (Project == null)
              return;

          Project.ParentID = parentId;
          Project.ProjectExplanation = ProjectExplanation;
          Project.TableTypeId = TableTypeId;
          Project.DisplayOrder = DisplayOrder;
          Project.UpdateID = HozestERPContext.Current.User.CustomerID;
          Project.UpdateDateTime = DateTime.Now;
          if (!_context.IsAttached(Project))
              _context.CWProjects.Attach(Project);
          _context.SaveChanges();
           
      }


        #endregion
    }
}
