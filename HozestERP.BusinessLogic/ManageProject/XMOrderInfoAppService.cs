
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 方银朗
** 创建日期:2014-06-10 09:51:46
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
    public partial class XMOrderInfoAppService : IXMOrderInfoAppService
 
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
    	public XMOrderInfoAppService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMOrderInfoAppService成员
        /// <summary>
        /// Insert into XMOrderInfoApp
        /// </summary>
        /// <param name="xmorderinfoapp">XMOrderInfoApp</param>
    	public void InsertXMOrderInfoApp(XMOrderInfoApp xmorderinfoapp)
    	{	
            if (xmorderinfoapp == null)
                return;
    
            if (!this._context.IsAttached(xmorderinfoapp))
    			
                this._context.XMOrderInfoApps.AddObject(xmorderinfoapp);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMOrderInfoApp
        /// </summary>
        /// <param name="xmorderinfoapp">XMOrderInfoApp</param>
        public void UpdateXMOrderInfoApp(XMOrderInfoApp xmorderinfoapp)
        {
            if (xmorderinfoapp == null)
                return;
    
            if (this._context.IsAttached(xmorderinfoapp))
                this._context.XMOrderInfoApps.Attach(xmorderinfoapp);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMOrderInfoApp list
        /// </summary>
        public List<XMOrderInfoApp> GetXMOrderInfoAppList()
        {		
            var query = from p in this._context.XMOrderInfoApps
                        where !p.IsEnabled.Value
                        select p;
            return query.ToList();
        }
        /// <summary>
        ///  根据店铺和平台类型查询
        /// </summary>
        /// <param name="ddlNickId">店铺ID</param>
        /// <param name="ProjectTypeId">平台ID</param>
        /// <returns></returns>
        public List<XMOrderInfoApp> GetXMProjectList(int ddlNickId, int ProjectTypeId)
        {
            var query = from p in this._context.XMOrderInfoApps
                        where (p.NickId == ddlNickId || ddlNickId==-1)  && (p.PlatformTypeId == ProjectTypeId || ProjectTypeId==-1) && p.IsEnabled == false
                        orderby p.CreateDate descending
                        select p;
                  return query.ToList();
        }


        /// <summary>
        /// 根据平台类型查询
        /// </summary>
        /// <param name="PlatformTypeId"></param>
        /// <returns></returns>
        public List<XMOrderInfoApp> GetXMOrderInfoAppByPlatformTypeId(int PlatformTypeId)
        { 
            var query = from p in this._context.XMOrderInfoApps
                        where p.PlatformTypeId == PlatformTypeId
                        && !p.IsEnabled.Value
                        select p;
            return query.ToList();
        }
    	
        /// <summary>
        /// get to XMOrderInfoApp Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMOrderInfoApp Page List</returns>
        public PagedList<XMOrderInfoApp> SearchXMOrderInfoApp(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMOrderInfoApps
                        orderby p.ID
                        select p;
            return new PagedList<XMOrderInfoApp>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMOrderInfoApp by ID
        /// </summary>
        /// <param name="id">XMOrderInfoApp ID</param>
        /// <returns>XMOrderInfoApp</returns>   
        public XMOrderInfoApp GetXMOrderInfoAppByID(int id)
        {
            var query = from p in this._context.XMOrderInfoApps
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMOrderInfoApp by ID
        /// </summary>
        /// <param name="ID">XMOrderInfoApp ID</param>
        public void DeleteXMOrderInfoApp(int id)
        {
            var xmorderinfoapp = this.GetXMOrderInfoAppByID(id);
            if (xmorderinfoapp == null)
                return;
    
            if (!this._context.IsAttached(xmorderinfoapp))
                this._context.XMOrderInfoApps.Attach(xmorderinfoapp);
    
            this._context.DeleteObject(xmorderinfoapp);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMOrderInfoApp by ID
        /// </summary>
        /// <param name="IDs">XMOrderInfoApp ID</param>
        public void BatchDeleteXMOrderInfoApp(List<int> ids)
        {
    	   var query = from q in _context.XMOrderInfoApps
                    where ids.Contains(q.ID)
                    select q;
            var xmorderinfoapps = query.ToList();
            foreach (var item in xmorderinfoapps)
            {
                if (!_context.IsAttached(item))
                    _context.XMOrderInfoApps.Attach(item);  
    
                _context.XMOrderInfoApps.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
