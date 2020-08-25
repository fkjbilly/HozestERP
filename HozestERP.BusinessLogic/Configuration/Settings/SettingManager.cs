

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using HozestERP.BusinessLogic.Data;
using HozestERP.Common.Utils;
using HozestERP.Common;



namespace HozestERP.BusinessLogic.Configuration.Settings
{
    /// <summary>
    /// Setting manager
    /// </summary>
    public partial class SettingManager : ISettingManager
    {

        #region Fields

        /// <summary>
        /// Object context
        /// </summary>
        private readonly HozestERPObjectContext _context;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public SettingManager(HozestERPObjectContext context)
        {
            this._context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a setting
        /// </summary>
        /// <param name="settingId">Setting identifer</param>
        /// <returns>Setting</returns>
        public Setting GetSettingById(int settingId)
        {
            if (settingId == 0)
                return null;

            
            var query = from s in _context.Settings
                        where s.SettingID == settingId
                        select s;
            var setting = query.SingleOrDefault();
            return setting;
        }

        /// <summary>
        /// Deletes a setting
        /// </summary>
        /// <param name="settingId">Setting identifer</param>
        public void DeleteSetting(int settingId)
        {
            var setting = GetSettingById(settingId);
            if (setting == null)
                return;

            
            if (!_context.IsAttached(setting))
                _context.Settings.Attach(setting);
            _context.DeleteObject(setting);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all settings
        /// </summary>
        /// <returns>Setting collection</returns>
        public Dictionary<string, Setting> GetAllSettings()
        {

            
            var query = from s in _context.Settings
                        orderby s.Name
                        select s;
            var settings = query.ToDictionary(s => s.Name.ToLowerInvariant());

            return settings;
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<Setting> GetSettingsList()
        {
            var query = from s in this._context.Settings
                        select s;
            return query.ToList();
        }

        /// <summary>
        ///  Gets all settings
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns>Setting collection</returns>
        public PagedList<Setting> GetAllSettings(string Name, int pageIndex, int pageSize)
        {
            var query = from s in this._context.Settings
                        where s.Name.Contains(Name)
                        orderby s.Name
                        select s;
            return new PagedList<Setting>(query, pageIndex, pageSize);
        }

         /// <summary>
        /// Inserts/updates a param
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>Setting</returns>
        public Setting SetParam(string name, string value)
        {
            var setting = GetSettingByName(name);
            if (setting != null)
                return SetParam(name, value, setting.Description);
            else
                return SetParam(name, value, string.Empty);
        }

        /// <summary>
        /// Inserts/updates a param
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        public Setting SetParam(string name, string value, string description)
        {
            var setting = GetSettingByName(name);
            if (setting != null)
            {
                if (setting.Name != name || setting.Value != value || setting.Description != description)
                    setting = UpdateSetting(setting.SettingID, name, value, description);
            }
            else
                setting = AddSetting(name, value, description);

            return setting;
        }

        /// <summary>
        /// Inserts/updates a param in US locale
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>Setting</returns>
        public Setting SetParamNative(string name, decimal value)
        {
            return SetParamNative(name, value, string.Empty);
        }

        /// <summary>
        /// Inserts/updates a param in US locale
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        public Setting SetParamNative(string name, decimal value, string description)
        {
            string valueStr = value.ToString(new CultureInfo("en-US"));
            return SetParam(name, valueStr, description);
        }

        /// <summary>
        /// Adds a setting
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        public Setting AddSetting(string name, string value, string description)
        {
            name = CommonHelper.EnsureNotNull(name);
            name = CommonHelper.EnsureMaximumLength(name, 200);
            value = CommonHelper.EnsureNotNull(value);
            value = CommonHelper.EnsureMaximumLength(value, 2000);
            description = CommonHelper.EnsureNotNull(description);

            

            var setting = _context.Settings.CreateObject();
            setting.Name = name;
            setting.Value = value;
            setting.Description = description;

            _context.Settings.AddObject(setting);
            _context.SaveChanges();

            return setting;
        }

        /// <summary>
        /// Updates a setting
        /// </summary>
        /// <param name="settingId">Setting identifier</param>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        public Setting UpdateSetting(int settingId, string name, string value, string description)
        {
            name = CommonHelper.EnsureNotNull(name);
            name = CommonHelper.EnsureMaximumLength(name, 200);
            value = CommonHelper.EnsureNotNull(value);
            value = CommonHelper.EnsureMaximumLength(value, 2000);
            description = CommonHelper.EnsureNotNull(description);

            var setting = GetSettingById(settingId);
            if (setting == null)
                return null;

            
            if (!_context.IsAttached(setting))
                _context.Settings.Attach(setting);

            setting.Name = name;
            setting.Value = value;
            setting.Description = description;
            _context.SaveChanges();


            return setting;
        }

        /// <summary>
        /// Gets a boolean value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        public bool GetSettingValueBoolean(string name)
        {
            return GetSettingValueBoolean(name, false);
        }

        /// <summary>
        /// Gets a boolean value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        public bool GetSettingValueBoolean(string name, bool defaultValue)
        {
            string value = GetSettingValue(name);
            if (!String.IsNullOrEmpty(value))
            {
                return bool.Parse(value);
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets an integer value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        public int GetSettingValueInteger(string name)
        {
            return GetSettingValueInteger(name, 0);
        }

        /// <summary>
        /// Gets an integer value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        public int GetSettingValueInteger(string name, int defaultValue)
        {
            string value = GetSettingValue(name);
            if (!String.IsNullOrEmpty(value))
            {
                return int.Parse(value);
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets a long value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        public long GetSettingValueLong(string name)
        {
            return GetSettingValueLong(name, 0);
        }

        /// <summary>
        ///  Gets a long value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        public long GetSettingValueLong(string name, int defaultValue)
        {
            string value = GetSettingValue(name);
            if (!String.IsNullOrEmpty(value))
            {
                return long.Parse(value);
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets a decimal value of a setting in US locale
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        public decimal GetSettingValueDecimalNative(string name)
        {
            return GetSettingValueDecimalNative(name, decimal.Zero);
        }

        /// <summary>
        /// Gets a decimal value of a setting in US locale
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        public decimal GetSettingValueDecimalNative(string name, decimal defaultValue)
        {
            string value = GetSettingValue(name);
            if (!String.IsNullOrEmpty(value))
            {
                return decimal.Parse(value, new CultureInfo("en-US"));
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets a setting value
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        public string GetSettingValue(string name)
        {
            var setting = GetSettingByName(name);
            if (setting != null)
                return setting.Value;
            return string.Empty;
        }

        /// <summary>
        /// Gets a setting value
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        public string GetSettingValue(string name, string defaultValue)
        {
            string value = GetSettingValue(name);
            if (!String.IsNullOrEmpty(value))
            {
                return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// Get a setting by name
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>Setting instance</returns>
        public Setting GetSettingByName(string name)
        {
            if (String.IsNullOrEmpty(name))
                return null;

            name = name.Trim().ToLowerInvariant();

            var settings = GetAllSettings();
            if (settings.ContainsKey(name))
            {
                var setting = settings[name];
                return setting;
            }
            return null;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether cache is enabled
        /// </summary>
        public bool CacheEnabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets a store name
        /// </summary>
        public string StoreName
        {
            get
            {
                string storeName = GetSettingValue("Common.StoreName");
                return storeName;
            }
            set
            {
                SetParam("Common.StoreName", value);
            }
        }

        /// <summary>
        /// Gets or sets a store URL (ending with "/")
        /// </summary>
        public string StoreUrl
        {
            get
            {
                string storeUrl = GetSettingValue("Common.StoreURL");
                if (!storeUrl.EndsWith("/"))
                    storeUrl += "/";
                return storeUrl;
            }
            set
            {
                SetParam("Common.StoreURL", value);
            }
        }

        /// <summary>
        /// Get current version
        /// </summary>
        /// <returns></returns>
        public string CurrentVersion
        {
            get
            {
                return GetSettingValue("Common.CurrentVersion");
            }
        }

        /// <summary> 
        /// 人员数据权限
        /// </summary>
        private IQueryable<int> SecuritySql
        {
            get
            {
                return this._context.Security(HozestERPContext.Current.User.CustomerID);
            }
        }
        #endregion

        #region  AlertSettings
        /// <summary>
        /// 查询所有Sys_AlertSettings数据
        /// </summary>
        /// <returns></returns>
        public List<Sys_AlertSettings> GetAllAlertSettings()
        {
            var query = from p in this._context.Sys_AlertSettings
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 查询所有Sys_AlertSettings数据
        /// </summary>
        /// <returns></returns>
        public PagedList<Sys_AlertSettings> GetAllAlertSettings(string rmdname, int pageIndex, int pageSize)
        {
            var query = from p in this._context.Sys_AlertSettings
                        where p.Rmdname.Contains(rmdname)
                        orderby p.ID
                        select p;
            return new PagedList<Sys_AlertSettings>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// 根据角色ID查询提示类型列表
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public List<Sys_AlertSettings> GetRoleAlertSettings(int roleId)
        {
            string role = roleId.ToString();
            var query = from p in this._context.Sys_AlertSettings
                        where
                         (from ats in this._context.Sys_AlertTimeSet
                          where ats.Spare1 == role
                          select ats.AlertID).Distinct().Contains(p.ID)
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据alertSettingsID获取Sys_AlertSettings表
        /// </summary>
        /// <param name="alertSettingsID">alertSettingsID</param>
        /// <returns></returns>
        public Sys_AlertSettings GetAlertSettingsByID(int alertSettingsID)
        {
            var query = from p in this._context.Sys_AlertSettings
                        where p.ID.Equals(alertSettingsID)
                        select p;
            var alertSettings = query.SingleOrDefault();
            return alertSettings;
        }

        /// <summary>
        /// 更新Sys_AlertSettings表信息
        /// </summary>
        /// <param name="alertSettings">alertSettings</param>
        public void UpdateAlertSettings(Sys_AlertSettings alertSettings)
        {
            if (alertSettings == null)
                throw new ArgumentNullException("Sys_AlertSettings");

            if (!_context.IsAttached(alertSettings))
                _context.Sys_AlertSettings.Attach(alertSettings);

            _context.SaveChanges();
        }

        /// <summary>
        /// 添加Sys_AlertSettings表信息
        /// </summary>
        /// <param name="alertSettings">alertSettings</param>
        public void InsertAlertSettings(Sys_AlertSettings alertSettings)
        {
            if (alertSettings == null)
                throw new ArgumentNullException("Sys_AlertSettings");

            _context.Sys_AlertSettings.AddObject(alertSettings);
            _context.SaveChanges();
        }

        /// <summary>
        /// 删除Sys_AlertSettings表信息
        /// </summary>
        /// <param name="alertSettingsID">alertSettingsID</param>
        public void DeleteAlertSettings(int alertSettingsID)
        {
            var alertSettings = GetAlertSettingsByID(alertSettingsID);
            if (alertSettings == null)
                return;

            if (!_context.IsAttached(alertSettings))
                _context.Sys_AlertSettings.Attach(alertSettings);
            _context.DeleteObject(alertSettings);
            _context.SaveChanges();
        }

        /// <summary>
        /// 删除Sys_AlertSettings表信息
        /// </summary>
        /// <param name="alertSettingsIDs">alertSettingsIDs</param>
        public void DeleteAlertSettings(List<int> alertSettingsIDs)
        {
            foreach (var alertSettingsID in alertSettingsIDs)
            {
                var alertSettings = GetAlertSettingsByID(alertSettingsID);
                if (alertSettings == null)
                    return;

                if (!_context.IsAttached(alertSettings))
                    _context.Sys_AlertSettings.Attach(alertSettings);
                _context.DeleteObject(alertSettings);
                _context.SaveChanges();

            }
            _context.SaveChanges();
        }
   
        #endregion

        #region  AlertTimeSet

        /// <summary>
        /// 根据alertTimeSetID获取Sys_AlertTimeSet表
        /// </summary>
        /// <param name="alertTimeSetID">alertTimeSetID</param>
        /// <returns></returns>
        public Sys_AlertTimeSet GetAlertTimeSetByID(int alertTimeSetID)
        {
            var query = from p in this._context.Sys_AlertTimeSet
                        where p.ID.Equals(alertTimeSetID)
                        select p;
            var alertTimeSet = query.SingleOrDefault();
            return alertTimeSet;
        }

        /// <summary>
        /// 更新Sys_AlertTimeSet表信息
        /// </summary>
        /// <param name="alertTimeSet">alertTimeSet</param>
        public void UpdateAlertTimeSet(Sys_AlertTimeSet alertTimeSet)
        {
            if (alertTimeSet == null)
                throw new ArgumentNullException("Sys_AlertTimeSet");

            if (!_context.IsAttached(alertTimeSet))
                _context.Sys_AlertTimeSet.Attach(alertTimeSet);

            _context.SaveChanges();
        }

        /// <summary>
        /// 添加Sys_AlertTimeSet表信息
        /// </summary>
        /// <param name="alertTimeSet">alertTimeSet</param>
        public void InsertAlertTimeSet(Sys_AlertTimeSet alertTimeSet)
        {
            if (alertTimeSet == null)
                throw new ArgumentNullException("Sys_AlertTimeSet");

            _context.Sys_AlertTimeSet.AddObject(alertTimeSet);
            _context.SaveChanges();
        }

        /// <summary>
        /// 删除Sys_AlertTimeSet表信息
        /// </summary>
        /// <param name="alertTimeSetID">alertTimeSetID</param>
        public void DeleteAlertTimeSet(int alertTimeSetID)
        {
            var alertTimeSet = GetAlertTimeSetByID(alertTimeSetID);
            if (alertTimeSet == null)
                return;

            if (!_context.IsAttached(alertTimeSet))
                _context.Sys_AlertTimeSet.Attach(alertTimeSet);
            _context.DeleteObject(alertTimeSet);
            _context.SaveChanges();
        }

        /// <summary>
        /// 根据管理员ID获取Sys_AlertTimeSet分页列表
        /// </summary>
        /// <param name="customerID">业务员ID</param>
        /// <param name="rmdname">名称</param>
        /// <param name="pageIndex">显示页</param>
        /// <param name="pageSize">显示记录数</param>
        /// <returns>Sys_AlertTimeSet</returns>
        public PagedList<Sys_AlertTimeSet> GetAlertTimeSetList(int customerID, string rmdname, int pageIndex, int pageSize)
        {
            var query = from p in this._context.Sys_AlertTimeSet 
                        join c in this._context.Sys_AlertSettings on p.AlertID equals c.ID
                        where (p.CustomerID==0||p.CustomerID==customerID)
                        && c.Rmdname.Contains(rmdname)
                        orderby p.ID
                        select p;
            return new PagedList<Sys_AlertTimeSet>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// 根据角色ID查询AlertTimeSet数据  
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="alertId">提示类型ID</param>
        /// <returns></returns>
        public List<Sys_AlertTimeSet> GetAlertTimeSetByRoleID(string roleID,int alertId)
        { 
            var query=from p in this._context.Sys_AlertTimeSet
                      where p.Spare1==roleID
                      && (alertId==0 || p.AlertID==alertId)
                      orderby p.ID
                      select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据角色ID和提示类型ID删除AlertTimeSet数据
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="alertIds">提示类型ID集合</param>
        public void DeleteAlertTimeSetByRoleID(string roleID,string alertIds)
        {
            string sql = "delete from  Sys_AlertTimeSet where  AlertID not in (" + alertIds + ") and Spare1='" + roleID + "'";
            this._context.ExecuteStoreCommand(sql);
        }


        /// <summary>
        /// 根据用户ID和提示类型ID获取Sys_AlertTimeSet表
        /// </summary>
        /// <param name="alertTimeSetID">alertTimeSetID</param>
        /// <returns></returns>
        public Sys_AlertTimeSet GetAlertTimeSetByAlertIDAndCustomerID(int alertID,int customerId)
        {
            var query = from p in this._context.Sys_AlertTimeSet
                        where p.AlertID==alertID
                        && p.CustomerID==customerId
                        select p;
            var alertTimeSet = query.SingleOrDefault();
            return alertTimeSet;
        }
        #endregion
    }
}
