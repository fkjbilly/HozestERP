
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
    public partial class BannedIpAddressService: IBannedIpAddressService
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
    	public BannedIpAddressService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IBannedIpAddressService成员
        /// <summary>
        /// Insert into BannedIpAddress
        /// </summary>
        /// <param name="bannedipaddress">BannedIpAddress</param>
    	public void InsertBannedIpAddress(BannedIpAddress bannedipaddress)
    	{	
            if (bannedipaddress == null)
                return;
    
            if (!this._context.IsAttached(bannedipaddress))
    			
                this._context.BannedIpAddresses.AddObject(bannedipaddress);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into BannedIpAddress
        /// </summary>
        /// <param name="bannedipaddress">BannedIpAddress</param>
        public void UpdateBannedIpAddress(BannedIpAddress bannedipaddress)
        {
            if (bannedipaddress == null)
                return;
    
            if (this._context.IsAttached(bannedipaddress))
                this._context.BannedIpAddresses.Attach(bannedipaddress);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to BannedIpAddress list
        /// </summary>
        public List<BannedIpAddress> GetBannedIpAddressList()
        {		
            var query = from p in this._context.BannedIpAddresses
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to BannedIpAddress Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>BannedIpAddress Page List</returns>
        public PagedList<BannedIpAddress> SearchBannedIpAddress(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.BannedIpAddresses
                        orderby p.BannedIpAddressID
                        select p;
            return new PagedList<BannedIpAddress>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a BannedIpAddress by BannedIpAddressID
        /// </summary>
        /// <param name="bannedipaddressid">BannedIpAddress BannedIpAddressID</param>
        /// <returns>BannedIpAddress</returns>   
        public BannedIpAddress GetBannedIpAddressByBannedIpAddressID(int bannedipaddressid)
        {
            var query = from p in this._context.BannedIpAddresses
                        where p.BannedIpAddressID.Equals(bannedipaddressid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete BannedIpAddress by BannedIpAddressID
        /// </summary>
        /// <param name="BannedIpAddressID">BannedIpAddress BannedIpAddressID</param>
        public void DeleteBannedIpAddress(int bannedipaddressid)
        {
            var bannedipaddress = this.GetBannedIpAddressByBannedIpAddressID(bannedipaddressid);
            if (bannedipaddress == null)
                return;
    
            if (!this._context.IsAttached(bannedipaddress))
                this._context.BannedIpAddresses.Attach(bannedipaddress);
    
            this._context.DeleteObject(bannedipaddress);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete BannedIpAddress by BannedIpAddressID
        /// </summary>
        /// <param name="BannedIpAddressIDs">BannedIpAddress BannedIpAddressID</param>
        public void BatchDeleteBannedIpAddress(List<int> bannedipaddressids)
        {
    	   var query = from q in _context.BannedIpAddresses
                    where bannedipaddressids.Contains(q.BannedIpAddressID)
                    select q;
            var bannedipaddresss = query.ToList();
            foreach (var item in bannedipaddresss)
            {
                if (!_context.IsAttached(item))
                    _context.BannedIpAddresses.Attach(item);  
    
                _context.BannedIpAddresses.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
