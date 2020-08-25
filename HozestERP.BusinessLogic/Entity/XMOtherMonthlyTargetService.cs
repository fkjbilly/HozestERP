
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
    public partial class XMOtherMonthlyTargetService: IXMOtherMonthlyTargetService
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
    	public XMOtherMonthlyTargetService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMOtherMonthlyTargetService成员
        /// <summary>
        /// Insert into XMOtherMonthlyTarget
        /// </summary>
        /// <param name="xmothermonthlytarget">XMOtherMonthlyTarget</param>
    	public void InsertXMOtherMonthlyTarget(XMOtherMonthlyTarget xmothermonthlytarget)
    	{	
            if (xmothermonthlytarget == null)
                return;
    
            if (!this._context.IsAttached(xmothermonthlytarget))
    			
                this._context.XMOtherMonthlyTargets.AddObject(xmothermonthlytarget);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMOtherMonthlyTarget
        /// </summary>
        /// <param name="xmothermonthlytarget">XMOtherMonthlyTarget</param>
        public void UpdateXMOtherMonthlyTarget(XMOtherMonthlyTarget xmothermonthlytarget)
        {
            if (xmothermonthlytarget == null)
                return;
    
            if (this._context.IsAttached(xmothermonthlytarget))
                this._context.XMOtherMonthlyTargets.Attach(xmothermonthlytarget);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMOtherMonthlyTarget list
        /// </summary>
        public List<XMOtherMonthlyTarget> GetXMOtherMonthlyTargetList()
        {		
            var query = from p in this._context.XMOtherMonthlyTargets
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMOtherMonthlyTarget Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMOtherMonthlyTarget Page List</returns>
        public PagedList<XMOtherMonthlyTarget> SearchXMOtherMonthlyTarget(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMOtherMonthlyTargets
                        orderby p.ID
                        select p;
            return new PagedList<XMOtherMonthlyTarget>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMOtherMonthlyTarget by ID
        /// </summary>
        /// <param name="id">XMOtherMonthlyTarget ID</param>
        /// <returns>XMOtherMonthlyTarget</returns>   
        public XMOtherMonthlyTarget GetXMOtherMonthlyTargetByID(int id)
        {
            var query = from p in this._context.XMOtherMonthlyTargets
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMOtherMonthlyTarget by ID
        /// </summary>
        /// <param name="ID">XMOtherMonthlyTarget ID</param>
        public void DeleteXMOtherMonthlyTarget(int id)
        {
            var xmothermonthlytarget = this.GetXMOtherMonthlyTargetByID(id);
            if (xmothermonthlytarget == null)
                return;
    
            if (!this._context.IsAttached(xmothermonthlytarget))
                this._context.XMOtherMonthlyTargets.Attach(xmothermonthlytarget);
    
            this._context.DeleteObject(xmothermonthlytarget);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMOtherMonthlyTarget by ID
        /// </summary>
        /// <param name="IDs">XMOtherMonthlyTarget ID</param>
        public void BatchDeleteXMOtherMonthlyTarget(List<int> ids)
        {
    	   var query = from q in _context.XMOtherMonthlyTargets
                    where ids.Contains(q.ID)
                    select q;
            var xmothermonthlytargets = query.ToList();
            foreach (var item in xmothermonthlytargets)
            {
                if (!_context.IsAttached(item))
                    _context.XMOtherMonthlyTargets.Attach(item);  
    
                _context.XMOtherMonthlyTargets.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
