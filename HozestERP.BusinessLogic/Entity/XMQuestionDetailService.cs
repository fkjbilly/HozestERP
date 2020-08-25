
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
    public partial class XMQuestionDetailService: IXMQuestionDetailService
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
    	public XMQuestionDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMQuestionDetailService成员
        /// <summary>
        /// Insert into XMQuestionDetail
        /// </summary>
        /// <param name="xmquestiondetail">XMQuestionDetail</param>
    	public void InsertXMQuestionDetail(XMQuestionDetail xmquestiondetail)
    	{	
            if (xmquestiondetail == null)
                return;
    
            if (!this._context.IsAttached(xmquestiondetail))
    			
                this._context.XMQuestionDetails.AddObject(xmquestiondetail);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMQuestionDetail
        /// </summary>
        /// <param name="xmquestiondetail">XMQuestionDetail</param>
        public void UpdateXMQuestionDetail(XMQuestionDetail xmquestiondetail)
        {
            if (xmquestiondetail == null)
                return;
    
            if (this._context.IsAttached(xmquestiondetail))
                this._context.XMQuestionDetails.Attach(xmquestiondetail);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMQuestionDetail list
        /// </summary>
        public List<XMQuestionDetail> GetXMQuestionDetailList()
        {		
            var query = from p in this._context.XMQuestionDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMQuestionDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMQuestionDetail Page List</returns>
        public PagedList<XMQuestionDetail> SearchXMQuestionDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMQuestionDetails
                        orderby p.ID
                        select p;
            return new PagedList<XMQuestionDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMQuestionDetail by ID
        /// </summary>
        /// <param name="id">XMQuestionDetail ID</param>
        /// <returns>XMQuestionDetail</returns>   
        public XMQuestionDetail GetXMQuestionDetailByID(int id)
        {
            var query = from p in this._context.XMQuestionDetails
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMQuestionDetail by ID
        /// </summary>
        /// <param name="ID">XMQuestionDetail ID</param>
        public void DeleteXMQuestionDetail(int id)
        {
            var xmquestiondetail = this.GetXMQuestionDetailByID(id);
            if (xmquestiondetail == null)
                return;
    
            if (!this._context.IsAttached(xmquestiondetail))
                this._context.XMQuestionDetails.Attach(xmquestiondetail);
    
            this._context.DeleteObject(xmquestiondetail);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMQuestionDetail by ID
        /// </summary>
        /// <param name="IDs">XMQuestionDetail ID</param>
        public void BatchDeleteXMQuestionDetail(List<int> ids)
        {
    	   var query = from q in _context.XMQuestionDetails
                    where ids.Contains(q.ID)
                    select q;
            var xmquestiondetails = query.ToList();
            foreach (var item in xmquestiondetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMQuestionDetails.Attach(item);  
    
                _context.XMQuestionDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
