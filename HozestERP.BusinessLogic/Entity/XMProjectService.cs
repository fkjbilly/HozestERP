
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:28:32
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

namespace HozestERP.BusinessLogic.Entity
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
                        select p;
            return query.ToList();
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
