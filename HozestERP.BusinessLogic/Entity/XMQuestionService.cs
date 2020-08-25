
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
    public partial class XMQuestionService: IXMQuestionService
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
    	public XMQuestionService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMQuestionService成员
        /// <summary>
        /// Insert into XMQuestion
        /// </summary>
        /// <param name="xmquestion">XMQuestion</param>
    	public void InsertXMQuestion(XMQuestion xmquestion)
    	{	
            if (xmquestion == null)
                return;
    
            if (!this._context.IsAttached(xmquestion))
    			
                this._context.XMQuestions.AddObject(xmquestion);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMQuestion
        /// </summary>
        /// <param name="xmquestion">XMQuestion</param>
        public void UpdateXMQuestion(XMQuestion xmquestion)
        {
            if (xmquestion == null)
                return;
    
            if (this._context.IsAttached(xmquestion))
                this._context.XMQuestions.Attach(xmquestion);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMQuestion list
        /// </summary>
        public List<XMQuestion> GetXMQuestionList()
        {		
            var query = from p in this._context.XMQuestions
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMQuestion Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMQuestion Page List</returns>
        public PagedList<XMQuestion> SearchXMQuestion(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMQuestions
                        orderby p.ID
                        select p;
            return new PagedList<XMQuestion>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMQuestion by ID
        /// </summary>
        /// <param name="id">XMQuestion ID</param>
        /// <returns>XMQuestion</returns>   
        public XMQuestion GetXMQuestionByID(int id)
        {
            var query = from p in this._context.XMQuestions
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMQuestion by ID
        /// </summary>
        /// <param name="ID">XMQuestion ID</param>
        public void DeleteXMQuestion(int id)
        {
            var xmquestion = this.GetXMQuestionByID(id);
            if (xmquestion == null)
                return;
    
            if (!this._context.IsAttached(xmquestion))
                this._context.XMQuestions.Attach(xmquestion);
    
            this._context.DeleteObject(xmquestion);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMQuestion by ID
        /// </summary>
        /// <param name="IDs">XMQuestion ID</param>
        public void BatchDeleteXMQuestion(List<int> ids)
        {
    	   var query = from q in _context.XMQuestions
                    where ids.Contains(q.ID)
                    select q;
            var xmquestions = query.ToList();
            foreach (var item in xmquestions)
            {
                if (!_context.IsAttached(item))
                    _context.XMQuestions.Attach(item);  
    
                _context.XMQuestions.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
