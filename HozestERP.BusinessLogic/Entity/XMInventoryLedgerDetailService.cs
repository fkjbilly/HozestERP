
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
    public partial class XMInventoryLedgerDetailService: IXMInventoryLedgerDetailService
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
    	public XMInventoryLedgerDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMInventoryLedgerDetailService成员
        /// <summary>
        /// Insert into XMInventoryLedgerDetail
        /// </summary>
        /// <param name="xminventoryledgerdetail">XMInventoryLedgerDetail</param>
    	public void InsertXMInventoryLedgerDetail(XMInventoryLedgerDetail xminventoryledgerdetail)
    	{	
            if (xminventoryledgerdetail == null)
                return;
    
            if (!this._context.IsAttached(xminventoryledgerdetail))
    			
                this._context.XMInventoryLedgerDetails.AddObject(xminventoryledgerdetail);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMInventoryLedgerDetail
        /// </summary>
        /// <param name="xminventoryledgerdetail">XMInventoryLedgerDetail</param>
        public void UpdateXMInventoryLedgerDetail(XMInventoryLedgerDetail xminventoryledgerdetail)
        {
            if (xminventoryledgerdetail == null)
                return;
    
            if (this._context.IsAttached(xminventoryledgerdetail))
                this._context.XMInventoryLedgerDetails.Attach(xminventoryledgerdetail);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMInventoryLedgerDetail list
        /// </summary>
        public List<XMInventoryLedgerDetail> GetXMInventoryLedgerDetailList()
        {		
            var query = from p in this._context.XMInventoryLedgerDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMInventoryLedgerDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInventoryLedgerDetail Page List</returns>
        public PagedList<XMInventoryLedgerDetail> SearchXMInventoryLedgerDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMInventoryLedgerDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMInventoryLedgerDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMInventoryLedgerDetail by Id
        /// </summary>
        /// <param name="id">XMInventoryLedgerDetail Id</param>
        /// <returns>XMInventoryLedgerDetail</returns>   
        public XMInventoryLedgerDetail GetXMInventoryLedgerDetailById(int id)
        {
            var query = from p in this._context.XMInventoryLedgerDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMInventoryLedgerDetail by Id
        /// </summary>
        /// <param name="Id">XMInventoryLedgerDetail Id</param>
        public void DeleteXMInventoryLedgerDetail(int id)
        {
            var xminventoryledgerdetail = this.GetXMInventoryLedgerDetailById(id);
            if (xminventoryledgerdetail == null)
                return;
    
            if (!this._context.IsAttached(xminventoryledgerdetail))
                this._context.XMInventoryLedgerDetails.Attach(xminventoryledgerdetail);
    
            this._context.DeleteObject(xminventoryledgerdetail);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMInventoryLedgerDetail by Id
        /// </summary>
        /// <param name="Ids">XMInventoryLedgerDetail Id</param>
        public void BatchDeleteXMInventoryLedgerDetail(List<int> ids)
        {
    	   var query = from q in _context.XMInventoryLedgerDetails
                    where ids.Contains(q.Id)
                    select q;
            var xminventoryledgerdetails = query.ToList();
            foreach (var item in xminventoryledgerdetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMInventoryLedgerDetails.Attach(item);  
    
                _context.XMInventoryLedgerDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
