
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
    public partial class XMSaleReturnService: IXMSaleReturnService
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
    	public XMSaleReturnService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMSaleReturnService成员
        /// <summary>
        /// Insert into XMSaleReturn
        /// </summary>
        /// <param name="xmsalereturn">XMSaleReturn</param>
    	public void InsertXMSaleReturn(XMSaleReturn xmsalereturn)
    	{	
            if (xmsalereturn == null)
                return;
    
            if (!this._context.IsAttached(xmsalereturn))
    			
                this._context.XMSaleReturns.AddObject(xmsalereturn);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMSaleReturn
        /// </summary>
        /// <param name="xmsalereturn">XMSaleReturn</param>
        public void UpdateXMSaleReturn(XMSaleReturn xmsalereturn)
        {
            if (xmsalereturn == null)
                return;
    
            if (this._context.IsAttached(xmsalereturn))
                this._context.XMSaleReturns.Attach(xmsalereturn);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMSaleReturn list
        /// </summary>
        public List<XMSaleReturn> GetXMSaleReturnList()
        {		
            var query = from p in this._context.XMSaleReturns
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMSaleReturn Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleReturn Page List</returns>
        public PagedList<XMSaleReturn> SearchXMSaleReturn(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMSaleReturns
                        orderby p.Id
                        select p;
            return new PagedList<XMSaleReturn>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMSaleReturn by Id
        /// </summary>
        /// <param name="id">XMSaleReturn Id</param>
        /// <returns>XMSaleReturn</returns>   
        public XMSaleReturn GetXMSaleReturnById(int id)
        {
            var query = from p in this._context.XMSaleReturns
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMSaleReturn by Id
        /// </summary>
        /// <param name="Id">XMSaleReturn Id</param>
        public void DeleteXMSaleReturn(int id)
        {
            var xmsalereturn = this.GetXMSaleReturnById(id);
            if (xmsalereturn == null)
                return;
    
            if (!this._context.IsAttached(xmsalereturn))
                this._context.XMSaleReturns.Attach(xmsalereturn);
    
            this._context.DeleteObject(xmsalereturn);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMSaleReturn by Id
        /// </summary>
        /// <param name="Ids">XMSaleReturn Id</param>
        public void BatchDeleteXMSaleReturn(List<int> ids)
        {
    	   var query = from q in _context.XMSaleReturns
                    where ids.Contains(q.Id)
                    select q;
            var xmsalereturns = query.ToList();
            foreach (var item in xmsalereturns)
            {
                if (!_context.IsAttached(item))
                    _context.XMSaleReturns.Attach(item);  
    
                _context.XMSaleReturns.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
