
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
    public partial class SettingService: ISettingService
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
    	public SettingService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ISettingService成员
        /// <summary>
        /// Insert into Setting
        /// </summary>
        /// <param name="setting">Setting</param>
    	public void InsertSetting(Setting setting)
    	{	
            if (setting == null)
                return;
    
            if (!this._context.IsAttached(setting))
    			
                this._context.Settings.AddObject(setting);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Setting
        /// </summary>
        /// <param name="setting">Setting</param>
        public void UpdateSetting(Setting setting)
        {
            if (setting == null)
                return;
    
            if (this._context.IsAttached(setting))
                this._context.Settings.Attach(setting);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Setting list
        /// </summary>
        public List<Setting> GetSettingList()
        {		
            var query = from p in this._context.Settings
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Setting Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Setting Page List</returns>
        public PagedList<Setting> SearchSetting(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Settings
                        orderby p.SettingID
                        select p;
            return new PagedList<Setting>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Setting by SettingID
        /// </summary>
        /// <param name="settingid">Setting SettingID</param>
        /// <returns>Setting</returns>   
        public Setting GetSettingBySettingID(int settingid)
        {
            var query = from p in this._context.Settings
                        where p.SettingID.Equals(settingid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Setting by SettingID
        /// </summary>
        /// <param name="SettingID">Setting SettingID</param>
        public void DeleteSetting(int settingid)
        {
            var setting = this.GetSettingBySettingID(settingid);
            if (setting == null)
                return;
    
            if (!this._context.IsAttached(setting))
                this._context.Settings.Attach(setting);
    
            this._context.DeleteObject(setting);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Setting by SettingID
        /// </summary>
        /// <param name="SettingIDs">Setting SettingID</param>
        public void BatchDeleteSetting(List<int> settingids)
        {
    	   var query = from q in _context.Settings
                    where settingids.Contains(q.SettingID)
                    select q;
            var settings = query.ToList();
            foreach (var item in settings)
            {
                if (!_context.IsAttached(item))
                    _context.Settings.Attach(item);  
    
                _context.Settings.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
