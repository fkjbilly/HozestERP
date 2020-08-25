

using System.Collections.Generic;

using HozestERP.Common;

namespace HozestERP.BusinessLogic.Configuration.Settings
{
    /// <summary>
    /// Setting service interface
    /// </summary>
    public partial interface ISettingManager
    {
        /// <summary>
        /// Gets a setting
        /// </summary>
        /// <param name="settingId">Setting identifer</param>
        /// <returns>Setting</returns>
        Setting GetSettingById(int settingId);

        /// <summary>
        /// Deletes a setting
        /// </summary>
        /// <param name="settingId">Setting identifer</param>
        void DeleteSetting(int settingId);

        /// <summary>
        /// Gets all settings
        /// </summary>
        /// <returns>Setting collection</returns>
        Dictionary<string, Setting> GetAllSettings();

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        List<Setting> GetSettingsList();

           /// <summary>
        ///  Gets all settings
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns>Setting collection</returns>
        PagedList<Setting> GetAllSettings(string Name, int pageIndex, int pageSize);

         /// <summary>
        /// Inserts/updates a param
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>Setting</returns>
        Setting SetParam(string name, string value);

        /// <summary>
        /// Inserts/updates a param
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        Setting SetParam(string name, string value, string description);

        /// <summary>
        /// Inserts/updates a param in US locale
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>Setting</returns>
        Setting SetParamNative(string name, decimal value);

        /// <summary>
        /// Inserts/updates a param in US locale
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        Setting SetParamNative(string name, decimal value, string description);

        /// <summary>
        /// Adds a setting
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        Setting AddSetting(string name, string value, string description);

        /// <summary>
        /// Updates a setting
        /// </summary>
        /// <param name="settingId">Setting identifier</param>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        Setting UpdateSetting(int settingId, string name, string value, string description);
        /// <summary>
        /// Gets a boolean value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        bool GetSettingValueBoolean(string name);

        /// <summary>
        /// Gets a boolean value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        bool GetSettingValueBoolean(string name, bool defaultValue);

        /// <summary>
        /// Gets an integer value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        int GetSettingValueInteger(string name);

        /// <summary>
        /// Gets an integer value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        int GetSettingValueInteger(string name, int defaultValue);

        /// <summary>
        /// Gets a long value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        long GetSettingValueLong(string name);

        /// <summary>
        ///  Gets a long value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        long GetSettingValueLong(string name, int defaultValue);

        /// <summary>
        /// Gets a decimal value of a setting in US locale
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        decimal GetSettingValueDecimalNative(string name);

        /// <summary>
        /// Gets a decimal value of a setting in US locale
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        decimal GetSettingValueDecimalNative(string name, decimal defaultValue);

        /// <summary>
        /// Gets a setting value
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        string GetSettingValue(string name);

        /// <summary>
        /// Gets a setting value
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        string GetSettingValue(string name, string defaultValue);

        /// <summary>
        /// Get a setting by name
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>Setting instance</returns>
        Setting GetSettingByName(string name);

        /// <summary>
        /// Gets or sets a store name
        /// </summary>
        string StoreName {get;set;}

        /// <summary>
        /// Gets or sets a store URL (ending with "/")
        /// </summary>
        string StoreUrl { get; set; }

        /// <summary>
        /// Get current version
        /// </summary>
        /// <returns></returns>
        string CurrentVersion { get; }



        #region  AlertSettings
        /// <summary>
        /// 查询所有Sys_AlertSettings数据
        /// </summary>
        /// <returns></returns>
        List<Sys_AlertSettings> GetAllAlertSettings();


        /// <summary>
        /// 查询所有Sys_AlertSettings数据
        /// </summary>
        /// <param name="rmdname">提示类型名称</param>
        /// <returns></returns>
        PagedList<Sys_AlertSettings> GetAllAlertSettings(string rmdname, int pageIndex, int pageSize);

        /// <summary>
        /// 根据角色ID查询提示类型列表
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        List<Sys_AlertSettings> GetRoleAlertSettings(int roleId);

        /// <summary>
        /// 根据alertSettingsID获取Sys_AlertSettings表
        /// </summary>
        /// <param name="alertSettingsID">alertSettingsID</param>
        /// <returns></returns>
        Sys_AlertSettings GetAlertSettingsByID(int alertSettingsID);


        /// <summary>
        /// 更新Sys_AlertSettings表信息
        /// </summary>
        /// <param name="alertSettings">alertSettings</param>
        void UpdateAlertSettings(Sys_AlertSettings alertSettings);


        /// <summary>
        /// 添加Sys_AlertSettings表信息
        /// </summary>
        /// <param name="alertSettings">alertSettings</param>
        void InsertAlertSettings(Sys_AlertSettings alertSettings);
       

        /// <summary>
        /// 删除Sys_AlertSettings表信息
        /// </summary>
        /// <param name="alertSettingsID">alertSettingsID</param>
        void DeleteAlertSettings(int alertSettingsID);

        /// <summary>
        /// 删除Sys_AlertSettings表信息
        /// </summary>
        /// <param name="alertSettingsIDs">alertSettingsIDs</param>
        void DeleteAlertSettings(List<int> alertSettingsIDs);
       

        #endregion

        #region  AlertTimeSet

        /// <summary>
        /// 根据alertTimeSetID获取Sys_AlertTimeSet表
        /// </summary>
        /// <param name="alertTimeSetID">alertTimeSetID</param>
        /// <returns></returns>
        Sys_AlertTimeSet GetAlertTimeSetByID(int alertTimeSetID);
       
        /// <summary>
        /// 更新Sys_AlertTimeSet表信息
        /// </summary>
        /// <param name="alertTimeSet">alertTimeSet</param>
        void UpdateAlertTimeSet(Sys_AlertTimeSet alertTimeSet);
      

        /// <summary>
        /// 添加Sys_AlertTimeSet表信息
        /// </summary>
        /// <param name="alertTimeSet">alertTimeSet</param>
        void InsertAlertTimeSet(Sys_AlertTimeSet alertTimeSet);
        
        /// <summary>
        /// 删除Sys_AlertTimeSet表信息
        /// </summary>
        /// <param name="alertTimeSetID">alertTimeSetID</param>
        void DeleteAlertTimeSet(int alertTimeSetID);

        /// <summary>
        /// 根据管理员ID获取Sys_AlertTimeSet分页列表
        /// </summary>
        /// <param name="customerID">业务员ID</param>
        /// <param name="rmdname">名称</param>
        /// <param name="pageIndex">显示页</param>
        /// <param name="pageSize">显示记录数</param>
        /// <returns>Sys_AlertTimeSet</returns>
        PagedList<Sys_AlertTimeSet> GetAlertTimeSetList(int customerID, string rmdname, int pageIndex, int pageSize);


        /// <summary>
        /// 根据角色ID查询AlertTimeSet数据  
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="alertId">提示类型ID</param>
        /// <returns></returns>
        List<Sys_AlertTimeSet> GetAlertTimeSetByRoleID(string roleID, int alertId);


        /// <summary>
        /// 根据角色ID和提示类型ID删除AlertTimeSet数据  
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="AlertId">提示类型ID集合</param>
        void DeleteAlertTimeSetByRoleID(string roleID, string alertIds);


        /// <summary>
        /// 根据用户ID和提示类型ID获取Sys_AlertTimeSet表
        /// </summary>
        /// <param name="alertTimeSetID">alertTimeSetID</param>
        /// <returns></returns>
        Sys_AlertTimeSet GetAlertTimeSetByAlertIDAndCustomerID(int alertID, int customerId);

        #endregion
    }
}
