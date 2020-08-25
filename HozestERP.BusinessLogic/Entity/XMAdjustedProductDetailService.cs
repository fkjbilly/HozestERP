
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
    public partial class XMAdjustedProductDetailService: IXMAdjustedProductDetailService
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
    	public XMAdjustedProductDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMAdjustedProductDetailService成员
        /// <summary>
        /// Insert into XMAdjustedProductDetail
        /// </summary>
        /// <param name="xmadjustedproductdetail">XMAdjustedProductDetail</param>
    	public void InsertXMAdjustedProductDetail(XMAdjustedProductDetail xmadjustedproductdetail)
    	{	
            if (xmadjustedproductdetail == null)
                return;
    
            if (!this._context.IsAttached(xmadjustedproductdetail))
    			
                this._context.XMAdjustedProductDetails.AddObject(xmadjustedproductdetail);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMAdjustedProductDetail
        /// </summary>
        /// <param name="xmadjustedproductdetail">XMAdjustedProductDetail</param>
        public void UpdateXMAdjustedProductDetail(XMAdjustedProductDetail xmadjustedproductdetail)
        {
            if (xmadjustedproductdetail == null)
                return;
    
            if (this._context.IsAttached(xmadjustedproductdetail))
                this._context.XMAdjustedProductDetails.Attach(xmadjustedproductdetail);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMAdjustedProductDetail list
        /// </summary>
        public List<XMAdjustedProductDetail> GetXMAdjustedProductDetailList()
        {		
            var query = from p in this._context.XMAdjustedProductDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMAdjustedProductDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAdjustedProductDetail Page List</returns>
        public PagedList<XMAdjustedProductDetail> SearchXMAdjustedProductDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMAdjustedProductDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMAdjustedProductDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMAdjustedProductDetail by Id
        /// </summary>
        /// <param name="id">XMAdjustedProductDetail Id</param>
        /// <returns>XMAdjustedProductDetail</returns>   
        public XMAdjustedProductDetail GetXMAdjustedProductDetailById(int id)
        {
            var query = from p in this._context.XMAdjustedProductDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMAdjustedProductDetail by Id
        /// </summary>
        /// <param name="Id">XMAdjustedProductDetail Id</param>
        public void DeleteXMAdjustedProductDetail(int id)
        {
            var xmadjustedproductdetail = this.GetXMAdjustedProductDetailById(id);
            if (xmadjustedproductdetail == null)
                return;
    
            if (!this._context.IsAttached(xmadjustedproductdetail))
                this._context.XMAdjustedProductDetails.Attach(xmadjustedproductdetail);
    
            this._context.DeleteObject(xmadjustedproductdetail);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMAdjustedProductDetail by Id
        /// </summary>
        /// <param name="Ids">XMAdjustedProductDetail Id</param>
        public void BatchDeleteXMAdjustedProductDetail(List<int> ids)
        {
    	   var query = from q in _context.XMAdjustedProductDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmadjustedproductdetails = query.ToList();
            foreach (var item in xmadjustedproductdetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMAdjustedProductDetails.Attach(item);  
    
                _context.XMAdjustedProductDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
