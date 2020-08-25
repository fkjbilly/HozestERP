
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
    public partial class XMNickAchieveValueService: IXMNickAchieveValueService
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
    	public XMNickAchieveValueService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMNickAchieveValueService成员
        /// <summary>
        /// Insert into XMNickAchieveValue
        /// </summary>
        /// <param name="xmnickachievevalue">XMNickAchieveValue</param>
    	public void InsertXMNickAchieveValue(XMNickAchieveValue xmnickachievevalue)
    	{	
            if (xmnickachievevalue == null)
                return;
    
            if (!this._context.IsAttached(xmnickachievevalue))
    			
                this._context.XMNickAchieveValue.AddObject(xmnickachievevalue);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMNickAchieveValue
        /// </summary>
        /// <param name="xmnickachievevalue">XMNickAchieveValue</param>
        public void UpdateXMNickAchieveValue(XMNickAchieveValue xmnickachievevalue)
        {
            if (xmnickachievevalue == null)
                return;
    
            if (this._context.IsAttached(xmnickachievevalue))
                this._context.XMNickAchieveValue.Attach(xmnickachievevalue);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMNickAchieveValue list
        /// </summary>
        public List<XMNickAchieveValue> GetXMNickAchieveValueList()
        {		
            var query = from p in this._context.XMNickAchieveValue
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMNickAchieveValue Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMNickAchieveValue Page List</returns>
        public PagedList<XMNickAchieveValue> SearchXMNickAchieveValue(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMNickAchieveValue
                        orderby p.Id
                        select p;
            return new PagedList<XMNickAchieveValue>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMNickAchieveValue by Id
        /// </summary>
        /// <param name="id">XMNickAchieveValue Id</param>
        /// <returns>XMNickAchieveValue</returns>   
        public XMNickAchieveValue GetXMNickAchieveValueById(int id)
        {
            var query = from p in this._context.XMNickAchieveValue
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMNickAchieveValue by Id
        /// </summary>
        /// <param name="Id">XMNickAchieveValue Id</param>
        public void DeleteXMNickAchieveValue(int id)
        {
            var xmnickachievevalue = this.GetXMNickAchieveValueById(id);
            if (xmnickachievevalue == null)
                return;
    
            if (!this._context.IsAttached(xmnickachievevalue))
                this._context.XMNickAchieveValue.Attach(xmnickachievevalue);
    
            this._context.DeleteObject(xmnickachievevalue);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMNickAchieveValue by Id
        /// </summary>
        /// <param name="Ids">XMNickAchieveValue Id</param>
        public void BatchDeleteXMNickAchieveValue(List<int> ids)
        {
    	   var query = from q in _context.XMNickAchieveValue
                    where ids.Contains(q.Id)
                    select q;
            var xmnickachievevalues = query.ToList();
            foreach (var item in xmnickachievevalues)
            {
                if (!_context.IsAttached(item))
                    _context.XMNickAchieveValue.Attach(item);  
    
                _context.XMNickAchieveValue.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
