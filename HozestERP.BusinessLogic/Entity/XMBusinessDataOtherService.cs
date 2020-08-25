
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
    public partial class XMBusinessDataOtherService: IXMBusinessDataOtherService
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
    	public XMBusinessDataOtherService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMBusinessDataOtherService成员
        /// <summary>
        /// Insert into XMBusinessDataOther
        /// </summary>
        /// <param name="xmbusinessdataother">XMBusinessDataOther</param>
    	public void InsertXMBusinessDataOther(XMBusinessDataOther xmbusinessdataother)
    	{	
            if (xmbusinessdataother == null)
                return;
    
            if (!this._context.IsAttached(xmbusinessdataother))
    			
                this._context.XMBusinessDataOthers.AddObject(xmbusinessdataother);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMBusinessDataOther
        /// </summary>
        /// <param name="xmbusinessdataother">XMBusinessDataOther</param>
        public void UpdateXMBusinessDataOther(XMBusinessDataOther xmbusinessdataother)
        {
            if (xmbusinessdataother == null)
                return;
    
            if (this._context.IsAttached(xmbusinessdataother))
                this._context.XMBusinessDataOthers.Attach(xmbusinessdataother);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMBusinessDataOther list
        /// </summary>
        public List<XMBusinessDataOther> GetXMBusinessDataOtherList()
        {		
            var query = from p in this._context.XMBusinessDataOthers
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMBusinessDataOther Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMBusinessDataOther Page List</returns>
        public PagedList<XMBusinessDataOther> SearchXMBusinessDataOther(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMBusinessDataOthers
                        orderby p.ID
                        select p;
            return new PagedList<XMBusinessDataOther>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMBusinessDataOther by ID
        /// </summary>
        /// <param name="id">XMBusinessDataOther ID</param>
        /// <returns>XMBusinessDataOther</returns>   
        public XMBusinessDataOther GetXMBusinessDataOtherByID(int id)
        {
            var query = from p in this._context.XMBusinessDataOthers
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMBusinessDataOther by ID
        /// </summary>
        /// <param name="ID">XMBusinessDataOther ID</param>
        public void DeleteXMBusinessDataOther(int id)
        {
            var xmbusinessdataother = this.GetXMBusinessDataOtherByID(id);
            if (xmbusinessdataother == null)
                return;
    
            if (!this._context.IsAttached(xmbusinessdataother))
                this._context.XMBusinessDataOthers.Attach(xmbusinessdataother);
    
            this._context.DeleteObject(xmbusinessdataother);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMBusinessDataOther by ID
        /// </summary>
        /// <param name="IDs">XMBusinessDataOther ID</param>
        public void BatchDeleteXMBusinessDataOther(List<int> ids)
        {
    	   var query = from q in _context.XMBusinessDataOthers
                    where ids.Contains(q.ID)
                    select q;
            var xmbusinessdataothers = query.ToList();
            foreach (var item in xmbusinessdataothers)
            {
                if (!_context.IsAttached(item))
                    _context.XMBusinessDataOthers.Attach(item);  
    
                _context.XMBusinessDataOthers.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
