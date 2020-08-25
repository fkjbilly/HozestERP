
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
    public partial class BulletinService: IBulletinService
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
    	public BulletinService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IBulletinService成员
        /// <summary>
        /// Insert into Bulletin
        /// </summary>
        /// <param name="bulletin">Bulletin</param>
    	public void InsertBulletin(Bulletin bulletin)
    	{	
            if (bulletin == null)
                return;
    
            if (!this._context.IsAttached(bulletin))
    			
                this._context.Bulletins.AddObject(bulletin);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Bulletin
        /// </summary>
        /// <param name="bulletin">Bulletin</param>
        public void UpdateBulletin(Bulletin bulletin)
        {
            if (bulletin == null)
                return;
    
            if (this._context.IsAttached(bulletin))
                this._context.Bulletins.Attach(bulletin);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Bulletin list
        /// </summary>
        public List<Bulletin> GetBulletinList()
        {		
            var query = from p in this._context.Bulletins
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Bulletin Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Bulletin Page List</returns>
        public PagedList<Bulletin> SearchBulletin(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Bulletins
                        orderby p.BulletinID
                        select p;
            return new PagedList<Bulletin>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Bulletin by BulletinID
        /// </summary>
        /// <param name="bulletinid">Bulletin BulletinID</param>
        /// <returns>Bulletin</returns>   
        public Bulletin GetBulletinByBulletinID(int bulletinid)
        {
            var query = from p in this._context.Bulletins
                        where p.BulletinID.Equals(bulletinid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Bulletin by BulletinID
        /// </summary>
        /// <param name="BulletinID">Bulletin BulletinID</param>
        public void DeleteBulletin(int bulletinid)
        {
            var bulletin = this.GetBulletinByBulletinID(bulletinid);
            if (bulletin == null)
                return;
    
            if (!this._context.IsAttached(bulletin))
                this._context.Bulletins.Attach(bulletin);
    
            this._context.DeleteObject(bulletin);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Bulletin by BulletinID
        /// </summary>
        /// <param name="BulletinIDs">Bulletin BulletinID</param>
        public void BatchDeleteBulletin(List<int> bulletinids)
        {
    	   var query = from q in _context.Bulletins
                    where bulletinids.Contains(q.BulletinID)
                    select q;
            var bulletins = query.ToList();
            foreach (var item in bulletins)
            {
                if (!_context.IsAttached(item))
                    _context.Bulletins.Attach(item);  
    
                _context.Bulletins.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
