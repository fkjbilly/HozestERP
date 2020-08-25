/******************************************************************
** Copyright (c) 2008 -2012 
** 创建人:方银朗
** 创建日期:2011-04-12
** 修改人: 方银朗
** 修改日期: 2011-04-12
** 描 述: 方银朗 2011-02-11 创建
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HozestERP.Common;

namespace HozestERP.BusinessLogic.ModuleManagement
{
    public partial interface  IModuleService
    {
        /// <summary>
        /// Gets all modules by module id
        /// </summary>
        /// <param name="moduleID">module identifier</param>
        /// <returns>module collection</returns>
        List<Module> GetModuleListByModuleID(int moduleID);

        /// <summary>
        /// Gets all modules by module id
        /// </summary>
        /// <param name="moduleID">module identifier</param>
        /// <returns>module collection</returns>
        List<Module> GetModulesByModuleID(int moduleID);

        /// <summary>
        /// Gets module by module id
        /// </summary>
        /// <param name="moduleID">module identifier</param>
        /// <returns>module</returns>
        Module getModuleByModuleID(int moduleID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedList<Module> GetModuleList(int pageIndex, int pageSize);


        /// <summary>
        /// Deletes a Module item
        /// </summary>
        /// <param name="logId">Log item identifier</param>
        void DeleteModule(int moduleId);

        /// <summary>
        /// Inserts a module item
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="moduleName"></param>
        /// <param name="moduleCode"></param>
        /// <param name="istarget"></param>
        /// <param name="strHref"></param>
        /// <param name="expand"></param>
        /// <param name="displayOrder"></param>
        /// <param name="published"></param>
        /// <returns></returns>
        Module InsertModule(int? parentId, string moduleName, string moduleCode, bool istarget, string strHref, bool expand, int displayOrder, bool published, string iconcls,string appIconcls);


        /// <summary>
        /// Updates a module item
        /// </summary>
        /// <param name="moduleID"></param>
        /// <param name="parentId"></param>
        /// <param name="moduleName"></param>
        /// <param name="moduleCode"></param>
        /// <param name="istarget"></param>
        /// <param name="strHref"></param>
        /// <param name="expand"></param>
        /// <param name="displayOrder"></param>
        /// <param name="published"></param>
        void UpdateModule(int moduleID, int? parentId, string moduleName, string moduleCode, bool istarget, string strHref, bool expand, int displayOrder, bool published, string iconcls, string appIconcls);

    }
}
