
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
    public partial class XMProjectCostDetailService: IXMProjectCostDetailService
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
    	public XMProjectCostDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMProjectCostDetailService成员
        /// <summary>
        /// Insert into XMProjectCostDetail
        /// </summary>
        /// <param name="xmprojectcostdetail">XMProjectCostDetail</param>
    	public void InsertXMProjectCostDetail(XMProjectCostDetail xmprojectcostdetail)
    	{	
            if (xmprojectcostdetail == null)
                return;
    
            if (!this._context.IsAttached(xmprojectcostdetail))
    			
                this._context.XMProjectCostDetails.AddObject(xmprojectcostdetail);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMProjectCostDetail
        /// </summary>
        /// <param name="xmprojectcostdetail">XMProjectCostDetail</param>
        public void UpdateXMProjectCostDetail(XMProjectCostDetail xmprojectcostdetail)
        {
            if (xmprojectcostdetail == null)
                return;
    
            if (this._context.IsAttached(xmprojectcostdetail))
                this._context.XMProjectCostDetails.Attach(xmprojectcostdetail);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMProjectCostDetail list
        /// </summary>
        public List<XMProjectCostDetail> GetXMProjectCostDetailList()
        {		
            var query = from p in this._context.XMProjectCostDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMProjectCostDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMProjectCostDetail Page List</returns>
        public PagedList<XMProjectCostDetail> SearchXMProjectCostDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMProjectCostDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMProjectCostDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMProjectCostDetail by Id
        /// </summary>
        /// <param name="id">XMProjectCostDetail Id</param>
        /// <returns>XMProjectCostDetail</returns>   
        public XMProjectCostDetail GetXMProjectCostDetailById(int id)
        {
            var query = from p in this._context.XMProjectCostDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMProjectCostDetail by Id
        /// </summary>
        /// <param name="Id">XMProjectCostDetail Id</param>
        public void DeleteXMProjectCostDetail(int id)
        {
            var xmprojectcostdetail = this.GetXMProjectCostDetailById(id);
            if (xmprojectcostdetail == null)
                return;
    
            if (!this._context.IsAttached(xmprojectcostdetail))
                this._context.XMProjectCostDetails.Attach(xmprojectcostdetail);
    
            this._context.DeleteObject(xmprojectcostdetail);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMProjectCostDetail by Id
        /// </summary>
        /// <param name="Ids">XMProjectCostDetail Id</param>
        public void BatchDeleteXMProjectCostDetail(List<int> ids)
        {
    	   var query = from q in _context.XMProjectCostDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmprojectcostdetails = query.ToList();
            foreach (var item in xmprojectcostdetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMProjectCostDetails.Attach(item);  
    
                _context.XMProjectCostDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
