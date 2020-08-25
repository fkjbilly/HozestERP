
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
    public partial class XMAdvertisingFeeDetailService: IXMAdvertisingFeeDetailService
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
    	public XMAdvertisingFeeDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMAdvertisingFeeDetailService成员
        /// <summary>
        /// Insert into XMAdvertisingFeeDetail
        /// </summary>
        /// <param name="xmadvertisingfeedetail">XMAdvertisingFeeDetail</param>
    	public void InsertXMAdvertisingFeeDetail(XMAdvertisingFeeDetail xmadvertisingfeedetail)
    	{	
            if (xmadvertisingfeedetail == null)
                return;
    
            if (!this._context.IsAttached(xmadvertisingfeedetail))
    			
                this._context.XMAdvertisingFeeDetails.AddObject(xmadvertisingfeedetail);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMAdvertisingFeeDetail
        /// </summary>
        /// <param name="xmadvertisingfeedetail">XMAdvertisingFeeDetail</param>
        public void UpdateXMAdvertisingFeeDetail(XMAdvertisingFeeDetail xmadvertisingfeedetail)
        {
            if (xmadvertisingfeedetail == null)
                return;
    
            if (this._context.IsAttached(xmadvertisingfeedetail))
                this._context.XMAdvertisingFeeDetails.Attach(xmadvertisingfeedetail);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMAdvertisingFeeDetail list
        /// </summary>
        public List<XMAdvertisingFeeDetail> GetXMAdvertisingFeeDetailList()
        {		
            var query = from p in this._context.XMAdvertisingFeeDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMAdvertisingFeeDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAdvertisingFeeDetail Page List</returns>
        public PagedList<XMAdvertisingFeeDetail> SearchXMAdvertisingFeeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMAdvertisingFeeDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMAdvertisingFeeDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMAdvertisingFeeDetail by Id
        /// </summary>
        /// <param name="id">XMAdvertisingFeeDetail Id</param>
        /// <returns>XMAdvertisingFeeDetail</returns>   
        public XMAdvertisingFeeDetail GetXMAdvertisingFeeDetailById(int id)
        {
            var query = from p in this._context.XMAdvertisingFeeDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMAdvertisingFeeDetail by Id
        /// </summary>
        /// <param name="Id">XMAdvertisingFeeDetail Id</param>
        public void DeleteXMAdvertisingFeeDetail(int id)
        {
            var xmadvertisingfeedetail = this.GetXMAdvertisingFeeDetailById(id);
            if (xmadvertisingfeedetail == null)
                return;
    
            if (!this._context.IsAttached(xmadvertisingfeedetail))
                this._context.XMAdvertisingFeeDetails.Attach(xmadvertisingfeedetail);
    
            this._context.DeleteObject(xmadvertisingfeedetail);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMAdvertisingFeeDetail by Id
        /// </summary>
        /// <param name="Ids">XMAdvertisingFeeDetail Id</param>
        public void BatchDeleteXMAdvertisingFeeDetail(List<int> ids)
        {
    	   var query = from q in _context.XMAdvertisingFeeDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmadvertisingfeedetails = query.ToList();
            foreach (var item in xmadvertisingfeedetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMAdvertisingFeeDetails.Attach(item);  
    
                _context.XMAdvertisingFeeDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
