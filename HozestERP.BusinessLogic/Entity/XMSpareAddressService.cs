
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
    public partial class XMSpareAddressService: IXMSpareAddressService
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
    	public XMSpareAddressService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMSpareAddressService成员
        /// <summary>
        /// Insert into XMSpareAddress
        /// </summary>
        /// <param name="xmspareaddress">XMSpareAddress</param>
    	public void InsertXMSpareAddress(XMSpareAddress xmspareaddress)
    	{	
            if (xmspareaddress == null)
                return;
    
            if (!this._context.IsAttached(xmspareaddress))
    			
                this._context.XMSpareAddresses.AddObject(xmspareaddress);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMSpareAddress
        /// </summary>
        /// <param name="xmspareaddress">XMSpareAddress</param>
        public void UpdateXMSpareAddress(XMSpareAddress xmspareaddress)
        {
            if (xmspareaddress == null)
                return;
    
            if (this._context.IsAttached(xmspareaddress))
                this._context.XMSpareAddresses.Attach(xmspareaddress);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMSpareAddress list
        /// </summary>
        public List<XMSpareAddress> GetXMSpareAddressList()
        {		
            var query = from p in this._context.XMSpareAddresses
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMSpareAddress Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSpareAddress Page List</returns>
        public PagedList<XMSpareAddress> SearchXMSpareAddress(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMSpareAddresses
                        orderby p.ID
                        select p;
            return new PagedList<XMSpareAddress>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMSpareAddress by ID
        /// </summary>
        /// <param name="id">XMSpareAddress ID</param>
        /// <returns>XMSpareAddress</returns>   
        public XMSpareAddress GetXMSpareAddressByID(int id)
        {
            var query = from p in this._context.XMSpareAddresses
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMSpareAddress by ID
        /// </summary>
        /// <param name="ID">XMSpareAddress ID</param>
        public void DeleteXMSpareAddress(int id)
        {
            var xmspareaddress = this.GetXMSpareAddressByID(id);
            if (xmspareaddress == null)
                return;
    
            if (!this._context.IsAttached(xmspareaddress))
                this._context.XMSpareAddresses.Attach(xmspareaddress);
    
            this._context.DeleteObject(xmspareaddress);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMSpareAddress by ID
        /// </summary>
        /// <param name="IDs">XMSpareAddress ID</param>
        public void BatchDeleteXMSpareAddress(List<int> ids)
        {
    	   var query = from q in _context.XMSpareAddresses
                    where ids.Contains(q.ID)
                    select q;
            var xmspareaddresss = query.ToList();
            foreach (var item in xmspareaddresss)
            {
                if (!_context.IsAttached(item))
                    _context.XMSpareAddresses.Attach(item);  
    
                _context.XMSpareAddresses.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
