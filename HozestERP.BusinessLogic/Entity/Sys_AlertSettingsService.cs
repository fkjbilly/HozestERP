
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
    public partial class Sys_AlertSettingsService: ISys_AlertSettingsService
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
    	public Sys_AlertSettingsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ISys_AlertSettingsService成员
        /// <summary>
        /// Insert into Sys_AlertSettings
        /// </summary>
        /// <param name="sys_alertsettings">Sys_AlertSettings</param>
    	public void InsertSys_AlertSettings(Sys_AlertSettings sys_alertsettings)
    	{	
            if (sys_alertsettings == null)
                return;
    
            if (!this._context.IsAttached(sys_alertsettings))
    			
                this._context.Sys_AlertSettings.AddObject(sys_alertsettings);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Sys_AlertSettings
        /// </summary>
        /// <param name="sys_alertsettings">Sys_AlertSettings</param>
        public void UpdateSys_AlertSettings(Sys_AlertSettings sys_alertsettings)
        {
            if (sys_alertsettings == null)
                return;
    
            if (this._context.IsAttached(sys_alertsettings))
                this._context.Sys_AlertSettings.Attach(sys_alertsettings);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Sys_AlertSettings list
        /// </summary>
        public List<Sys_AlertSettings> GetSys_AlertSettingsList()
        {		
            var query = from p in this._context.Sys_AlertSettings
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Sys_AlertSettings Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Sys_AlertSettings Page List</returns>
        public PagedList<Sys_AlertSettings> SearchSys_AlertSettings(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Sys_AlertSettings
                        orderby p.ID
                        select p;
            return new PagedList<Sys_AlertSettings>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Sys_AlertSettings by ID
        /// </summary>
        /// <param name="id">Sys_AlertSettings ID</param>
        /// <returns>Sys_AlertSettings</returns>   
        public Sys_AlertSettings GetSys_AlertSettingsByID(int id)
        {
            var query = from p in this._context.Sys_AlertSettings
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Sys_AlertSettings by ID
        /// </summary>
        /// <param name="ID">Sys_AlertSettings ID</param>
        public void DeleteSys_AlertSettings(int id)
        {
            var sys_alertsettings = this.GetSys_AlertSettingsByID(id);
            if (sys_alertsettings == null)
                return;
    
            if (!this._context.IsAttached(sys_alertsettings))
                this._context.Sys_AlertSettings.Attach(sys_alertsettings);
    
            this._context.DeleteObject(sys_alertsettings);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Sys_AlertSettings by ID
        /// </summary>
        /// <param name="IDs">Sys_AlertSettings ID</param>
        public void BatchDeleteSys_AlertSettings(List<int> ids)
        {
    	   var query = from q in _context.Sys_AlertSettings
                    where ids.Contains(q.ID)
                    select q;
            var sys_alertsettingss = query.ToList();
            foreach (var item in sys_alertsettingss)
            {
                if (!_context.IsAttached(item))
                    _context.Sys_AlertSettings.Attach(item);  
    
                _context.Sys_AlertSettings.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
