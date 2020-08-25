

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
        /// ��ѯ����
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
        /// ��ѯ����Sys_AlertSettings����
        /// </summary>
        /// <returns></returns>
        List<Sys_AlertSettings> GetAllAlertSettings();


        /// <summary>
        /// ��ѯ����Sys_AlertSettings����
        /// </summary>
        /// <param name="rmdname">��ʾ��������</param>
        /// <returns></returns>
        PagedList<Sys_AlertSettings> GetAllAlertSettings(string rmdname, int pageIndex, int pageSize);

        /// <summary>
        /// ���ݽ�ɫID��ѯ��ʾ�����б�
        /// </summary>
        /// <param name="roleId">��ɫID</param>
        /// <returns></returns>
        List<Sys_AlertSettings> GetRoleAlertSettings(int roleId);

        /// <summary>
        /// ����alertSettingsID��ȡSys_AlertSettings��
        /// </summary>
        /// <param name="alertSettingsID">alertSettingsID</param>
        /// <returns></returns>
        Sys_AlertSettings GetAlertSettingsByID(int alertSettingsID);


        /// <summary>
        /// ����Sys_AlertSettings����Ϣ
        /// </summary>
        /// <param name="alertSettings">alertSettings</param>
        void UpdateAlertSettings(Sys_AlertSettings alertSettings);


        /// <summary>
        /// ���Sys_AlertSettings����Ϣ
        /// </summary>
        /// <param name="alertSettings">alertSettings</param>
        void InsertAlertSettings(Sys_AlertSettings alertSettings);
       

        /// <summary>
        /// ɾ��Sys_AlertSettings����Ϣ
        /// </summary>
        /// <param name="alertSettingsID">alertSettingsID</param>
        void DeleteAlertSettings(int alertSettingsID);

        /// <summary>
        /// ɾ��Sys_AlertSettings����Ϣ
        /// </summary>
        /// <param name="alertSettingsIDs">alertSettingsIDs</param>
        void DeleteAlertSettings(List<int> alertSettingsIDs);
       

        #endregion

        #region  AlertTimeSet

        /// <summary>
        /// ����alertTimeSetID��ȡSys_AlertTimeSet��
        /// </summary>
        /// <param name="alertTimeSetID">alertTimeSetID</param>
        /// <returns></returns>
        Sys_AlertTimeSet GetAlertTimeSetByID(int alertTimeSetID);
       
        /// <summary>
        /// ����Sys_AlertTimeSet����Ϣ
        /// </summary>
        /// <param name="alertTimeSet">alertTimeSet</param>
        void UpdateAlertTimeSet(Sys_AlertTimeSet alertTimeSet);
      

        /// <summary>
        /// ���Sys_AlertTimeSet����Ϣ
        /// </summary>
        /// <param name="alertTimeSet">alertTimeSet</param>
        void InsertAlertTimeSet(Sys_AlertTimeSet alertTimeSet);
        
        /// <summary>
        /// ɾ��Sys_AlertTimeSet����Ϣ
        /// </summary>
        /// <param name="alertTimeSetID">alertTimeSetID</param>
        void DeleteAlertTimeSet(int alertTimeSetID);

        /// <summary>
        /// ���ݹ���ԱID��ȡSys_AlertTimeSet��ҳ�б�
        /// </summary>
        /// <param name="customerID">ҵ��ԱID</param>
        /// <param name="rmdname">����</param>
        /// <param name="pageIndex">��ʾҳ</param>
        /// <param name="pageSize">��ʾ��¼��</param>
        /// <returns>Sys_AlertTimeSet</returns>
        PagedList<Sys_AlertTimeSet> GetAlertTimeSetList(int customerID, string rmdname, int pageIndex, int pageSize);


        /// <summary>
        /// ���ݽ�ɫID��ѯAlertTimeSet����  
        /// </summary>
        /// <param name="roleID">��ɫID</param>
        /// <param name="alertId">��ʾ����ID</param>
        /// <returns></returns>
        List<Sys_AlertTimeSet> GetAlertTimeSetByRoleID(string roleID, int alertId);


        /// <summary>
        /// ���ݽ�ɫID����ʾ����IDɾ��AlertTimeSet����  
        /// </summary>
        /// <param name="roleID">��ɫID</param>
        /// <param name="AlertId">��ʾ����ID����</param>
        void DeleteAlertTimeSetByRoleID(string roleID, string alertIds);


        /// <summary>
        /// �����û�ID����ʾ����ID��ȡSys_AlertTimeSet��
        /// </summary>
        /// <param name="alertTimeSetID">alertTimeSetID</param>
        /// <returns></returns>
        Sys_AlertTimeSet GetAlertTimeSetByAlertIDAndCustomerID(int alertID, int customerId);

        #endregion
    }
}
