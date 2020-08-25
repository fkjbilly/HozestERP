
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
    public partial interface ISys_AlertSettingsService
    {
        #region ISys_AlertSettingsService成员
        /// <summary>
        /// Insert into Sys_AlertSettings
        /// </summary>
        /// <param name="sys_alertsettings">Sys_AlertSettings</param>
    	void InsertSys_AlertSettings(Sys_AlertSettings sys_alertsettings);
    	
        /// <summary>
        /// Update into Sys_AlertSettings
        /// </summary>
        /// <param name="sys_alertsettings">Sys_AlertSettings</param>
        void UpdateSys_AlertSettings(Sys_AlertSettings sys_alertsettings);	
    	
        /// <summary>
        /// get to Sys_AlertSettings list
        /// </summary>
        List<Sys_AlertSettings> GetSys_AlertSettingsList();
    	       
    	/// <summary>
    	/// get to Sys_AlertSettings Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Sys_AlertSettings Page List</returns>
    	PagedList<Sys_AlertSettings> SearchSys_AlertSettings(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Sys_AlertSettings by ID
        /// </summary>
        /// <param name="id">Sys_AlertSettings ID</param>
        /// <returns>Sys_AlertSettings</returns>   
        Sys_AlertSettings GetSys_AlertSettingsByID(int id);
    
    	/// <summary>
        /// delete Sys_AlertSettings by ID
        /// </summary>
        /// <param name="ID">Sys_AlertSettings ID</param>
        void DeleteSys_AlertSettings(int id);
    	
    	/// <summary>
        /// Batch delete Sys_AlertSettings by ID
        /// </summary>
        /// <param name="IDs">Sys_AlertSettings ID</param>
        void BatchDeleteSys_AlertSettings(List<int> ids);

        #endregion
    }
}
