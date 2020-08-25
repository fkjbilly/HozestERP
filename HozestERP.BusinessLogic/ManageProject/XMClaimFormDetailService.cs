
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-09-24 15:14:40
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMClaimFormDetailService: IXMClaimFormDetailService
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
    	public XMClaimFormDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMClaimFormDetailService成员
        /// <summary>
        /// Insert into XMClaimFormDetail
        /// </summary>
        /// <param name="xmclaimformdetail">XMClaimFormDetail</param>
    	public void InsertXMClaimFormDetail(XMClaimFormDetail xmclaimformdetail)
    	{	
            if (xmclaimformdetail == null)
                return;
    
            if (!this._context.IsAttached(xmclaimformdetail))
    			
                this._context.XMClaimFormDetails.AddObject(xmclaimformdetail);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMClaimFormDetail
        /// </summary>
        /// <param name="xmclaimformdetail">XMClaimFormDetail</param>
        public void UpdateXMClaimFormDetail(XMClaimFormDetail xmclaimformdetail)
        {
            if (xmclaimformdetail == null)
                return;
    
            if (this._context.IsAttached(xmclaimformdetail))
                this._context.XMClaimFormDetails.Attach(xmclaimformdetail);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMClaimFormDetail list
        /// </summary>
        public List<XMClaimFormDetail> GetXMClaimFormDetailList()
        {		
            var query = from p in this._context.XMClaimFormDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public List<XMClaimFormDetail> GetXMClaimFormDetailListByClaimFormID(int ClaimFormID)
        {
            var query = from p in this._context.XMClaimFormDetails
                        where p.IsEnable == false
                        && p.ClaimFormID == ClaimFormID
                        select p;
            return query.ToList();
        }
    	
        /// <summary>
        /// get to XMClaimFormDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMClaimFormDetail Page List</returns>
        public PagedList<XMClaimFormDetail> SearchXMClaimFormDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMClaimFormDetails
                        orderby p.ID
                        select p;
            return new PagedList<XMClaimFormDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMClaimFormDetail by ID
        /// </summary>
        /// <param name="id">XMClaimFormDetail ID</param>
        /// <returns>XMClaimFormDetail</returns>   
        public XMClaimFormDetail GetXMClaimFormDetailByID(int id)
        {
            var query = from p in this._context.XMClaimFormDetails
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMClaimFormDetail by ID
        /// </summary>
        /// <param name="ID">XMClaimFormDetail ID</param>
        public void DeleteXMClaimFormDetail(int id)
        {
            var xmclaimformdetail = this.GetXMClaimFormDetailByID(id);
            if (xmclaimformdetail == null)
                return;
    
            if (!this._context.IsAttached(xmclaimformdetail))
                this._context.XMClaimFormDetails.Attach(xmclaimformdetail);
    
            this._context.DeleteObject(xmclaimformdetail);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMClaimFormDetail by ID
        /// </summary>
        /// <param name="IDs">XMClaimFormDetail ID</param>
        public void BatchDeleteXMClaimFormDetail(List<int> ids)
        {
    	   var query = from q in _context.XMClaimFormDetails
                    where ids.Contains(q.ID)
                    select q;
            var xmclaimformdetails = query.ToList();
            foreach (var item in xmclaimformdetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMClaimFormDetails.Attach(item);  
    
                _context.XMClaimFormDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
