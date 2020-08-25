
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
    public partial class CodeTypeService: ICodeTypeService
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
    	public CodeTypeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICodeTypeService成员
        /// <summary>
        /// Insert into CodeType
        /// </summary>
        /// <param name="codetype">CodeType</param>
    	public void InsertCodeType(CodeType codetype)
    	{	
            if (codetype == null)
                return;
    
            if (!this._context.IsAttached(codetype))
    			
                this._context.CodeTypes.AddObject(codetype);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into CodeType
        /// </summary>
        /// <param name="codetype">CodeType</param>
        public void UpdateCodeType(CodeType codetype)
        {
            if (codetype == null)
                return;
    
            if (this._context.IsAttached(codetype))
                this._context.CodeTypes.Attach(codetype);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to CodeType list
        /// </summary>
        public List<CodeType> GetCodeTypeList()
        {		
            var query = from p in this._context.CodeTypes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to CodeType Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CodeType Page List</returns>
        public PagedList<CodeType> SearchCodeType(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CodeTypes
                        orderby p.CodeTypeID
                        select p;
            return new PagedList<CodeType>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a CodeType by CodeTypeID
        /// </summary>
        /// <param name="codetypeid">CodeType CodeTypeID</param>
        /// <returns>CodeType</returns>   
        public CodeType GetCodeTypeByCodeTypeID(int codetypeid)
        {
            var query = from p in this._context.CodeTypes
                        where p.CodeTypeID.Equals(codetypeid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete CodeType by CodeTypeID
        /// </summary>
        /// <param name="CodeTypeID">CodeType CodeTypeID</param>
        public void DeleteCodeType(int codetypeid)
        {
            var codetype = this.GetCodeTypeByCodeTypeID(codetypeid);
            if (codetype == null)
                return;
    
            if (!this._context.IsAttached(codetype))
                this._context.CodeTypes.Attach(codetype);
    
            this._context.DeleteObject(codetype);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete CodeType by CodeTypeID
        /// </summary>
        /// <param name="CodeTypeIDs">CodeType CodeTypeID</param>
        public void BatchDeleteCodeType(List<int> codetypeids)
        {
    	   var query = from q in _context.CodeTypes
                    where codetypeids.Contains(q.CodeTypeID)
                    select q;
            var codetypes = query.ToList();
            foreach (var item in codetypes)
            {
                if (!_context.IsAttached(item))
                    _context.CodeTypes.Attach(item);  
    
                _context.CodeTypes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
