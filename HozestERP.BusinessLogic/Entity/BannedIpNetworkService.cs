
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
    public partial class BannedIpNetworkService: IBannedIpNetworkService
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
    	public BannedIpNetworkService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IBannedIpNetworkService成员
        /// <summary>
        /// Insert into BannedIpNetwork
        /// </summary>
        /// <param name="bannedipnetwork">BannedIpNetwork</param>
    	public void InsertBannedIpNetwork(BannedIpNetwork bannedipnetwork)
    	{	
            if (bannedipnetwork == null)
                return;
    
            if (!this._context.IsAttached(bannedipnetwork))
    			
                this._context.BannedIpNetworks.AddObject(bannedipnetwork);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into BannedIpNetwork
        /// </summary>
        /// <param name="bannedipnetwork">BannedIpNetwork</param>
        public void UpdateBannedIpNetwork(BannedIpNetwork bannedipnetwork)
        {
            if (bannedipnetwork == null)
                return;
    
            if (this._context.IsAttached(bannedipnetwork))
                this._context.BannedIpNetworks.Attach(bannedipnetwork);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to BannedIpNetwork list
        /// </summary>
        public List<BannedIpNetwork> GetBannedIpNetworkList()
        {		
            var query = from p in this._context.BannedIpNetworks
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to BannedIpNetwork Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>BannedIpNetwork Page List</returns>
        public PagedList<BannedIpNetwork> SearchBannedIpNetwork(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.BannedIpNetworks
                        orderby p.BannedIpNetworkID
                        select p;
            return new PagedList<BannedIpNetwork>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a BannedIpNetwork by BannedIpNetworkID
        /// </summary>
        /// <param name="bannedipnetworkid">BannedIpNetwork BannedIpNetworkID</param>
        /// <returns>BannedIpNetwork</returns>   
        public BannedIpNetwork GetBannedIpNetworkByBannedIpNetworkID(int bannedipnetworkid)
        {
            var query = from p in this._context.BannedIpNetworks
                        where p.BannedIpNetworkID.Equals(bannedipnetworkid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete BannedIpNetwork by BannedIpNetworkID
        /// </summary>
        /// <param name="BannedIpNetworkID">BannedIpNetwork BannedIpNetworkID</param>
        public void DeleteBannedIpNetwork(int bannedipnetworkid)
        {
            var bannedipnetwork = this.GetBannedIpNetworkByBannedIpNetworkID(bannedipnetworkid);
            if (bannedipnetwork == null)
                return;
    
            if (!this._context.IsAttached(bannedipnetwork))
                this._context.BannedIpNetworks.Attach(bannedipnetwork);
    
            this._context.DeleteObject(bannedipnetwork);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete BannedIpNetwork by BannedIpNetworkID
        /// </summary>
        /// <param name="BannedIpNetworkIDs">BannedIpNetwork BannedIpNetworkID</param>
        public void BatchDeleteBannedIpNetwork(List<int> bannedipnetworkids)
        {
    	   var query = from q in _context.BannedIpNetworks
                    where bannedipnetworkids.Contains(q.BannedIpNetworkID)
                    select q;
            var bannedipnetworks = query.ToList();
            foreach (var item in bannedipnetworks)
            {
                if (!_context.IsAttached(item))
                    _context.BannedIpNetworks.Attach(item);  
    
                _context.BannedIpNetworks.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
