
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-08-01 17:21:56
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

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial class XMTypeTestService: IXMTypeTestService
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
    	public XMTypeTestService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMTypeTestService成员
        /// <summary>
        /// Insert into XMTypeTest
        /// </summary>
        /// <param name="xmtypetest">XMTypeTest</param>
    	public void InsertXMTypeTest(XMTypeTest xmtypetest)
    	{	
            if (xmtypetest == null)
                return;
    
            if (!this._context.IsAttached(xmtypetest))
    			
                this._context.XMTypeTests.AddObject(xmtypetest);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMTypeTest
        /// </summary>
        /// <param name="xmtypetest">XMTypeTest</param>
        public void UpdateXMTypeTest(XMTypeTest xmtypetest)
        {
            if (xmtypetest == null)
                return;
    
            if (this._context.IsAttached(xmtypetest))
                this._context.XMTypeTests.Attach(xmtypetest);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMTypeTest list
        /// </summary>
        public List<XMTypeTest> GetXMTypeTestList()
        {		
            var query = from p in this._context.XMTypeTests
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMTypeTest Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMTypeTest Page List</returns>
        public PagedList<XMTypeTest> SearchXMTypeTest(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMTypeTests
                        orderby p.ID
                        select p;
            return new PagedList<XMTypeTest>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMTypeTest by ID
        /// </summary>
        /// <param name="id">XMTypeTest ID</param>
        /// <returns>XMTypeTest</returns>   
        public XMTypeTest GetXMTypeTestByID(int id)
        {
            var query = from p in this._context.XMTypeTests
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMTypeTest by ID
        /// </summary>
        /// <param name="ID">XMTypeTest ID</param>
        public void DeleteXMTypeTest(int id)
        {
            var xmtypetest = this.GetXMTypeTestByID(id);
            if (xmtypetest == null)
                return;
    
            if (!this._context.IsAttached(xmtypetest))
                this._context.XMTypeTests.Attach(xmtypetest);
    
            this._context.DeleteObject(xmtypetest);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMTypeTest by ID
        /// </summary>
        /// <param name="IDs">XMTypeTest ID</param>
        public void BatchDeleteXMTypeTest(List<int> ids)
        {
    	   var query = from q in _context.XMTypeTests
                    where ids.Contains(q.ID)
                    select q;
            var xmtypetests = query.ToList();
            foreach (var item in xmtypetests)
            {
                if (!_context.IsAttached(item))
                    _context.XMTypeTests.Attach(item);  
    
                _context.XMTypeTests.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
