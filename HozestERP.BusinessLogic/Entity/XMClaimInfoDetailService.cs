
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
    public partial class XMClaimInfoDetailService: IXMClaimInfoDetailService
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
    	public XMClaimInfoDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMClaimInfoDetailService成员
        /// <summary>
        /// Insert into XMClaimInfoDetail
        /// </summary>
        /// <param name="xmclaiminfodetail">XMClaimInfoDetail</param>
    	public void InsertXMClaimInfoDetail(XMClaimInfoDetail xmclaiminfodetail)
    	{	
            if (xmclaiminfodetail == null)
                return;
    
            if (!this._context.IsAttached(xmclaiminfodetail))
    			
                this._context.XMClaimInfoDetails.AddObject(xmclaiminfodetail);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMClaimInfoDetail
        /// </summary>
        /// <param name="xmclaiminfodetail">XMClaimInfoDetail</param>
        public void UpdateXMClaimInfoDetail(XMClaimInfoDetail xmclaiminfodetail)
        {
            if (xmclaiminfodetail == null)
                return;
    
            if (this._context.IsAttached(xmclaiminfodetail))
                this._context.XMClaimInfoDetails.Attach(xmclaiminfodetail);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMClaimInfoDetail list
        /// </summary>
        public List<XMClaimInfoDetail> GetXMClaimInfoDetailList()
        {		
            var query = from p in this._context.XMClaimInfoDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMClaimInfoDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMClaimInfoDetail Page List</returns>
        public PagedList<XMClaimInfoDetail> SearchXMClaimInfoDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMClaimInfoDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMClaimInfoDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMClaimInfoDetail by Id
        /// </summary>
        /// <param name="id">XMClaimInfoDetail Id</param>
        /// <returns>XMClaimInfoDetail</returns>   
        public XMClaimInfoDetail GetXMClaimInfoDetailById(int id)
        {
            var query = from p in this._context.XMClaimInfoDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMClaimInfoDetail by Id
        /// </summary>
        /// <param name="Id">XMClaimInfoDetail Id</param>
        public void DeleteXMClaimInfoDetail(int id)
        {
            var xmclaiminfodetail = this.GetXMClaimInfoDetailById(id);
            if (xmclaiminfodetail == null)
                return;
    
            if (!this._context.IsAttached(xmclaiminfodetail))
                this._context.XMClaimInfoDetails.Attach(xmclaiminfodetail);
    
            this._context.DeleteObject(xmclaiminfodetail);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMClaimInfoDetail by Id
        /// </summary>
        /// <param name="Ids">XMClaimInfoDetail Id</param>
        public void BatchDeleteXMClaimInfoDetail(List<int> ids)
        {
    	   var query = from q in _context.XMClaimInfoDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmclaiminfodetails = query.ToList();
            foreach (var item in xmclaiminfodetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMClaimInfoDetails.Attach(item);  
    
                _context.XMClaimInfoDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
