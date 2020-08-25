
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
    public partial class XMFinancialCapitalFlowService: IXMFinancialCapitalFlowService
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
    	public XMFinancialCapitalFlowService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMFinancialCapitalFlowService成员
        /// <summary>
        /// Insert into XMFinancialCapitalFlow
        /// </summary>
        /// <param name="xmfinancialcapitalflow">XMFinancialCapitalFlow</param>
    	public void InsertXMFinancialCapitalFlow(XMFinancialCapitalFlow xmfinancialcapitalflow)
    	{	
            if (xmfinancialcapitalflow == null)
                return;
    
            if (!this._context.IsAttached(xmfinancialcapitalflow))
    			
                this._context.XMFinancialCapitalFlows.AddObject(xmfinancialcapitalflow);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMFinancialCapitalFlow
        /// </summary>
        /// <param name="xmfinancialcapitalflow">XMFinancialCapitalFlow</param>
        public void UpdateXMFinancialCapitalFlow(XMFinancialCapitalFlow xmfinancialcapitalflow)
        {
            if (xmfinancialcapitalflow == null)
                return;
    
            if (this._context.IsAttached(xmfinancialcapitalflow))
                this._context.XMFinancialCapitalFlows.Attach(xmfinancialcapitalflow);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMFinancialCapitalFlow list
        /// </summary>
        public List<XMFinancialCapitalFlow> GetXMFinancialCapitalFlowList()
        {		
            var query = from p in this._context.XMFinancialCapitalFlows
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMFinancialCapitalFlow Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMFinancialCapitalFlow Page List</returns>
        public PagedList<XMFinancialCapitalFlow> SearchXMFinancialCapitalFlow(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMFinancialCapitalFlows
                        orderby p.ID
                        select p;
            return new PagedList<XMFinancialCapitalFlow>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMFinancialCapitalFlow by ID
        /// </summary>
        /// <param name="id">XMFinancialCapitalFlow ID</param>
        /// <returns>XMFinancialCapitalFlow</returns>   
        public XMFinancialCapitalFlow GetXMFinancialCapitalFlowByID(int id)
        {
            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMFinancialCapitalFlow by ID
        /// </summary>
        /// <param name="ID">XMFinancialCapitalFlow ID</param>
        public void DeleteXMFinancialCapitalFlow(int id)
        {
            var xmfinancialcapitalflow = this.GetXMFinancialCapitalFlowByID(id);
            if (xmfinancialcapitalflow == null)
                return;
    
            if (!this._context.IsAttached(xmfinancialcapitalflow))
                this._context.XMFinancialCapitalFlows.Attach(xmfinancialcapitalflow);
    
            this._context.DeleteObject(xmfinancialcapitalflow);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMFinancialCapitalFlow by ID
        /// </summary>
        /// <param name="IDs">XMFinancialCapitalFlow ID</param>
        public void BatchDeleteXMFinancialCapitalFlow(List<int> ids)
        {
    	   var query = from q in _context.XMFinancialCapitalFlows
                    where ids.Contains(q.ID)
                    select q;
            var xmfinancialcapitalflows = query.ToList();
            foreach (var item in xmfinancialcapitalflows)
            {
                if (!_context.IsAttached(item))
                    _context.XMFinancialCapitalFlows.Attach(item);  
    
                _context.XMFinancialCapitalFlows.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
