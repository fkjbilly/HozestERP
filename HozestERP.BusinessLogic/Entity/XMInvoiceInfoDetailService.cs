
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
    public partial class XMInvoiceInfoDetailService: IXMInvoiceInfoDetailService
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
    	public XMInvoiceInfoDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMInvoiceInfoDetailService成员
        /// <summary>
        /// Insert into XMInvoiceInfoDetail
        /// </summary>
        /// <param name="xminvoiceinfodetail">XMInvoiceInfoDetail</param>
    	public void InsertXMInvoiceInfoDetail(XMInvoiceInfoDetail xminvoiceinfodetail)
    	{	
            if (xminvoiceinfodetail == null)
                return;
    
            if (!this._context.IsAttached(xminvoiceinfodetail))
    			
                this._context.XMInvoiceInfoDetails.AddObject(xminvoiceinfodetail);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMInvoiceInfoDetail
        /// </summary>
        /// <param name="xminvoiceinfodetail">XMInvoiceInfoDetail</param>
        public void UpdateXMInvoiceInfoDetail(XMInvoiceInfoDetail xminvoiceinfodetail)
        {
            if (xminvoiceinfodetail == null)
                return;
    
            if (this._context.IsAttached(xminvoiceinfodetail))
                this._context.XMInvoiceInfoDetails.Attach(xminvoiceinfodetail);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMInvoiceInfoDetail list
        /// </summary>
        public List<XMInvoiceInfoDetail> GetXMInvoiceInfoDetailList()
        {		
            var query = from p in this._context.XMInvoiceInfoDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMInvoiceInfoDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInvoiceInfoDetail Page List</returns>
        public PagedList<XMInvoiceInfoDetail> SearchXMInvoiceInfoDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMInvoiceInfoDetails
                        orderby p.ID
                        select p;
            return new PagedList<XMInvoiceInfoDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMInvoiceInfoDetail by ID
        /// </summary>
        /// <param name="id">XMInvoiceInfoDetail ID</param>
        /// <returns>XMInvoiceInfoDetail</returns>   
        public XMInvoiceInfoDetail GetXMInvoiceInfoDetailByID(int id)
        {
            var query = from p in this._context.XMInvoiceInfoDetails
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMInvoiceInfoDetail by ID
        /// </summary>
        /// <param name="ID">XMInvoiceInfoDetail ID</param>
        public void DeleteXMInvoiceInfoDetail(int id)
        {
            var xminvoiceinfodetail = this.GetXMInvoiceInfoDetailByID(id);
            if (xminvoiceinfodetail == null)
                return;
    
            if (!this._context.IsAttached(xminvoiceinfodetail))
                this._context.XMInvoiceInfoDetails.Attach(xminvoiceinfodetail);
    
            this._context.DeleteObject(xminvoiceinfodetail);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMInvoiceInfoDetail by ID
        /// </summary>
        /// <param name="IDs">XMInvoiceInfoDetail ID</param>
        public void BatchDeleteXMInvoiceInfoDetail(List<int> ids)
        {
    	   var query = from q in _context.XMInvoiceInfoDetails
                    where ids.Contains(q.ID)
                    select q;
            var xminvoiceinfodetails = query.ToList();
            foreach (var item in xminvoiceinfodetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMInvoiceInfoDetails.Attach(item);  
    
                _context.XMInvoiceInfoDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
