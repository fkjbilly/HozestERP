
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:27:57
** 修改人:
** 修改日期:
** 描 述: 接口类
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
    public partial interface ISettingService
    {
        #region ISettingService成员
        /// <summary>
        /// Insert into Setting
        /// </summary>
        /// <param name="setting">Setting</param>
    	void InsertSetting(Setting setting);
    	
        /// <summary>
        /// Update into Setting
        /// </summary>
        /// <param name="setting">Setting</param>
        void UpdateSetting(Setting setting);	
    	
        /// <summary>
        /// get to Setting list
        /// </summary>
        List<Setting> GetSettingList();
    	       
    	/// <summary>
    	/// get to Setting Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Setting Page List</returns>
    	PagedList<Setting> SearchSetting(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Setting by SettingID
        /// </summary>
        /// <param name="settingid">Setting SettingID</param>
        /// <returns>Setting</returns>   
        Setting GetSettingBySettingID(int settingid);
    
    	/// <summary>
        /// delete Setting by SettingID
        /// </summary>
        /// <param name="SettingID">Setting SettingID</param>
        void DeleteSetting(int settingid);
    	
    	/// <summary>
        /// Batch delete Setting by SettingID
        /// </summary>
        /// <param name="SettingIDs">Setting SettingID</param>
        void BatchDeleteSetting(List<int> settingids);

        #endregion
    }
}
