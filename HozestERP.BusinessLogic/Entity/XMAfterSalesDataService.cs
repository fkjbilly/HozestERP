
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
    public partial class XMAfterSalesDataService: IXMAfterSalesDataService
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
    	public XMAfterSalesDataService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMAfterSalesDataService成员
        /// <summary>
        /// Insert into XMAfterSalesData
        /// </summary>
        /// <param name="xmaftersalesdata">XMAfterSalesData</param>
    	public void InsertXMAfterSalesData(XMAfterSalesData xmaftersalesdata)
    	{	
            if (xmaftersalesdata == null)
                return;
    
            if (!this._context.IsAttached(xmaftersalesdata))
    			
                this._context.XMAfterSalesDatas.AddObject(xmaftersalesdata);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMAfterSalesData
        /// </summary>
        /// <param name="xmaftersalesdata">XMAfterSalesData</param>
        public void UpdateXMAfterSalesData(XMAfterSalesData xmaftersalesdata)
        {
            if (xmaftersalesdata == null)
                return;
    
            if (this._context.IsAttached(xmaftersalesdata))
                this._context.XMAfterSalesDatas.Attach(xmaftersalesdata);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMAfterSalesData list
        /// </summary>
        public List<XMAfterSalesData> GetXMAfterSalesDataList()
        {		
            var query = from p in this._context.XMAfterSalesDatas
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMAfterSalesData Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAfterSalesData Page List</returns>
        public PagedList<XMAfterSalesData> SearchXMAfterSalesData(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMAfterSalesDatas
                        orderby p.ID
                        select p;
            return new PagedList<XMAfterSalesData>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMAfterSalesData by ID
        /// </summary>
        /// <param name="id">XMAfterSalesData ID</param>
        /// <returns>XMAfterSalesData</returns>   
        public XMAfterSalesData GetXMAfterSalesDataByID(int id)
        {
            var query = from p in this._context.XMAfterSalesDatas
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMAfterSalesData by ID
        /// </summary>
        /// <param name="ID">XMAfterSalesData ID</param>
        public void DeleteXMAfterSalesData(int id)
        {
            var xmaftersalesdata = this.GetXMAfterSalesDataByID(id);
            if (xmaftersalesdata == null)
                return;
    
            if (!this._context.IsAttached(xmaftersalesdata))
                this._context.XMAfterSalesDatas.Attach(xmaftersalesdata);
    
            this._context.DeleteObject(xmaftersalesdata);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMAfterSalesData by ID
        /// </summary>
        /// <param name="IDs">XMAfterSalesData ID</param>
        public void BatchDeleteXMAfterSalesData(List<int> ids)
        {
    	   var query = from q in _context.XMAfterSalesDatas
                    where ids.Contains(q.ID)
                    select q;
            var xmaftersalesdatas = query.ToList();
            foreach (var item in xmaftersalesdatas)
            {
                if (!_context.IsAttached(item))
                    _context.XMAfterSalesDatas.Attach(item);  
    
                _context.XMAfterSalesDatas.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
