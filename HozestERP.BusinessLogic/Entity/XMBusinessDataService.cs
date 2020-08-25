
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
    public partial class XMBusinessDataService: IXMBusinessDataService
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
    	public XMBusinessDataService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMBusinessDataService成员
        /// <summary>
        /// Insert into XMBusinessData
        /// </summary>
        /// <param name="xmbusinessdata">XMBusinessData</param>
    	public void InsertXMBusinessData(XMBusinessData xmbusinessdata)
    	{	
            if (xmbusinessdata == null)
                return;
    
            if (!this._context.IsAttached(xmbusinessdata))
    			
                this._context.XMBusinessDatas.AddObject(xmbusinessdata);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMBusinessData
        /// </summary>
        /// <param name="xmbusinessdata">XMBusinessData</param>
        public void UpdateXMBusinessData(XMBusinessData xmbusinessdata)
        {
            if (xmbusinessdata == null)
                return;
    
            if (this._context.IsAttached(xmbusinessdata))
                this._context.XMBusinessDatas.Attach(xmbusinessdata);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMBusinessData list
        /// </summary>
        public List<XMBusinessData> GetXMBusinessDataList()
        {		
            var query = from p in this._context.XMBusinessDatas
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMBusinessData Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMBusinessData Page List</returns>
        public PagedList<XMBusinessData> SearchXMBusinessData(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMBusinessDatas
                        orderby p.ID
                        select p;
            return new PagedList<XMBusinessData>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMBusinessData by ID
        /// </summary>
        /// <param name="id">XMBusinessData ID</param>
        /// <returns>XMBusinessData</returns>   
        public XMBusinessData GetXMBusinessDataByID(int id)
        {
            var query = from p in this._context.XMBusinessDatas
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMBusinessData by ID
        /// </summary>
        /// <param name="ID">XMBusinessData ID</param>
        public void DeleteXMBusinessData(int id)
        {
            var xmbusinessdata = this.GetXMBusinessDataByID(id);
            if (xmbusinessdata == null)
                return;
    
            if (!this._context.IsAttached(xmbusinessdata))
                this._context.XMBusinessDatas.Attach(xmbusinessdata);
    
            this._context.DeleteObject(xmbusinessdata);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMBusinessData by ID
        /// </summary>
        /// <param name="IDs">XMBusinessData ID</param>
        public void BatchDeleteXMBusinessData(List<int> ids)
        {
    	   var query = from q in _context.XMBusinessDatas
                    where ids.Contains(q.ID)
                    select q;
            var xmbusinessdatas = query.ToList();
            foreach (var item in xmbusinessdatas)
            {
                if (!_context.IsAttached(item))
                    _context.XMBusinessDatas.Attach(item);  
    
                _context.XMBusinessDatas.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
