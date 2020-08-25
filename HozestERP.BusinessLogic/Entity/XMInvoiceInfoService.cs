
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
    public partial class XMInvoiceInfoService: IXMInvoiceInfoService
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
    	public XMInvoiceInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMInvoiceInfoService成员
        /// <summary>
        /// Insert into XMInvoiceInfo
        /// </summary>
        /// <param name="xminvoiceinfo">XMInvoiceInfo</param>
    	public void InsertXMInvoiceInfo(XMInvoiceInfo xminvoiceinfo)
    	{	
            if (xminvoiceinfo == null)
                return;
    
            if (!this._context.IsAttached(xminvoiceinfo))
    			
                this._context.XMInvoiceInfoes.AddObject(xminvoiceinfo);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMInvoiceInfo
        /// </summary>
        /// <param name="xminvoiceinfo">XMInvoiceInfo</param>
        public void UpdateXMInvoiceInfo(XMInvoiceInfo xminvoiceinfo)
        {
            if (xminvoiceinfo == null)
                return;
    
            if (this._context.IsAttached(xminvoiceinfo))
                this._context.XMInvoiceInfoes.Attach(xminvoiceinfo);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMInvoiceInfo list
        /// </summary>
        public List<XMInvoiceInfo> GetXMInvoiceInfoList()
        {		
            var query = from p in this._context.XMInvoiceInfoes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMInvoiceInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInvoiceInfo Page List</returns>
        public PagedList<XMInvoiceInfo> SearchXMInvoiceInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMInvoiceInfoes
                        orderby p.ID
                        select p;
            return new PagedList<XMInvoiceInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMInvoiceInfo by ID
        /// </summary>
        /// <param name="id">XMInvoiceInfo ID</param>
        /// <returns>XMInvoiceInfo</returns>   
        public XMInvoiceInfo GetXMInvoiceInfoByID(int id)
        {
            var query = from p in this._context.XMInvoiceInfoes
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMInvoiceInfo by ID
        /// </summary>
        /// <param name="ID">XMInvoiceInfo ID</param>
        public void DeleteXMInvoiceInfo(int id)
        {
            var xminvoiceinfo = this.GetXMInvoiceInfoByID(id);
            if (xminvoiceinfo == null)
                return;
    
            if (!this._context.IsAttached(xminvoiceinfo))
                this._context.XMInvoiceInfoes.Attach(xminvoiceinfo);
    
            this._context.DeleteObject(xminvoiceinfo);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMInvoiceInfo by ID
        /// </summary>
        /// <param name="IDs">XMInvoiceInfo ID</param>
        public void BatchDeleteXMInvoiceInfo(List<int> ids)
        {
    	   var query = from q in _context.XMInvoiceInfoes
                    where ids.Contains(q.ID)
                    select q;
            var xminvoiceinfos = query.ToList();
            foreach (var item in xminvoiceinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMInvoiceInfoes.Attach(item);  
    
                _context.XMInvoiceInfoes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
