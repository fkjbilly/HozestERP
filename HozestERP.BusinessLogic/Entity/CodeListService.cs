
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
    public partial class CodeListService: ICodeListService
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
    	public CodeListService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICodeListService成员
        /// <summary>
        /// Insert into CodeList
        /// </summary>
        /// <param name="codelist">CodeList</param>
    	public void InsertCodeList(CodeList codelist)
    	{	
            if (codelist == null)
                return;
    
            if (!this._context.IsAttached(codelist))
    			
                this._context.CodeLists.AddObject(codelist);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into CodeList
        /// </summary>
        /// <param name="codelist">CodeList</param>
        public void UpdateCodeList(CodeList codelist)
        {
            if (codelist == null)
                return;
    
            if (this._context.IsAttached(codelist))
                this._context.CodeLists.Attach(codelist);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to CodeList list
        /// </summary>
        public List<CodeList> GetCodeListList()
        {		
            var query = from p in this._context.CodeLists
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to CodeList Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CodeList Page List</returns>
        public PagedList<CodeList> SearchCodeList(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CodeLists
                        orderby p.CodeID
                        select p;
            return new PagedList<CodeList>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a CodeList by CodeID
        /// </summary>
        /// <param name="codeid">CodeList CodeID</param>
        /// <returns>CodeList</returns>   
        public CodeList GetCodeListByCodeID(int codeid)
        {
            var query = from p in this._context.CodeLists
                        where p.CodeID.Equals(codeid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete CodeList by CodeID
        /// </summary>
        /// <param name="CodeID">CodeList CodeID</param>
        public void DeleteCodeList(int codeid)
        {
            var codelist = this.GetCodeListByCodeID(codeid);
            if (codelist == null)
                return;
    
            if (!this._context.IsAttached(codelist))
                this._context.CodeLists.Attach(codelist);
    
            this._context.DeleteObject(codelist);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete CodeList by CodeID
        /// </summary>
        /// <param name="CodeIDs">CodeList CodeID</param>
        public void BatchDeleteCodeList(List<int> codeids)
        {
    	   var query = from q in _context.CodeLists
                    where codeids.Contains(q.CodeID)
                    select q;
            var codelists = query.ToList();
            foreach (var item in codelists)
            {
                if (!_context.IsAttached(item))
                    _context.CodeLists.Attach(item);  
    
                _context.CodeLists.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
