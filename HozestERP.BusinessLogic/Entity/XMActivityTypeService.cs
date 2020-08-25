
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
    public partial class XMActivityTypeService: IXMActivityTypeService
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
    	public XMActivityTypeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMActivityTypeService成员
        /// <summary>
        /// Insert into XMActivityType
        /// </summary>
        /// <param name="xmactivitytype">XMActivityType</param>
    	public void InsertXMActivityType(XMActivityType xmactivitytype)
    	{	
            if (xmactivitytype == null)
                return;
    
            if (!this._context.IsAttached(xmactivitytype))
    			
                this._context.XMActivityTypes.AddObject(xmactivitytype);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMActivityType
        /// </summary>
        /// <param name="xmactivitytype">XMActivityType</param>
        public void UpdateXMActivityType(XMActivityType xmactivitytype)
        {
            if (xmactivitytype == null)
                return;
    
            if (this._context.IsAttached(xmactivitytype))
                this._context.XMActivityTypes.Attach(xmactivitytype);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMActivityType list
        /// </summary>
        public List<XMActivityType> GetXMActivityTypeList()
        {		
            var query = from p in this._context.XMActivityTypes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMActivityType Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMActivityType Page List</returns>
        public PagedList<XMActivityType> SearchXMActivityType(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMActivityTypes
                        orderby p.Id
                        select p;
            return new PagedList<XMActivityType>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMActivityType by Id
        /// </summary>
        /// <param name="id">XMActivityType Id</param>
        /// <returns>XMActivityType</returns>   
        public XMActivityType GetXMActivityTypeById(int id)
        {
            var query = from p in this._context.XMActivityTypes
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMActivityType by Id
        /// </summary>
        /// <param name="Id">XMActivityType Id</param>
        public void DeleteXMActivityType(int id)
        {
            var xmactivitytype = this.GetXMActivityTypeById(id);
            if (xmactivitytype == null)
                return;
    
            if (!this._context.IsAttached(xmactivitytype))
                this._context.XMActivityTypes.Attach(xmactivitytype);
    
            this._context.DeleteObject(xmactivitytype);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMActivityType by Id
        /// </summary>
        /// <param name="Ids">XMActivityType Id</param>
        public void BatchDeleteXMActivityType(List<int> ids)
        {
    	   var query = from q in _context.XMActivityTypes
                    where ids.Contains(q.Id)
                    select q;
            var xmactivitytypes = query.ToList();
            foreach (var item in xmactivitytypes)
            {
                if (!_context.IsAttached(item))
                    _context.XMActivityTypes.Attach(item);  
    
                _context.XMActivityTypes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
