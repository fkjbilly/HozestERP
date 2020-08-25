/******************************************************************
** Copyright (c) 2008 -2012 呈邦食品
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

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;


namespace HozestERP.BusinessLogic.ModuleManagement
{
    
    public partial class ModuleService : IModuleService
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
        public ModuleService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IModuleService 成员

        /// <summary>
        /// 根据 moduleID 查询 Module 列表
        /// </summary>
        /// <param name="moduleID">moduleID</param>
        /// <returns>Module List</returns>
        public List<Module> GetModuleListByModuleID(int moduleID)
        {
            var query = from p in this._context.Modules
                        where p.ParentID == moduleID && !p.Deleted
                        orderby p.DisplayOrder ascending
                        select p;
            var modules = query.ToList();

            return modules;
        }
        /// <summary>
        /// 根据 moduleID 查询 Module 列表 字段Published为true
        /// </summary>
        /// <param name="moduleID">moduleID</param>
        /// <returns>Module List</returns>
        public List<Module> GetModulesByModuleID(int moduleID)
        {
            var query = from p in this._context.Modules
                        where p.ParentID == moduleID && !p.Deleted
                        && p.Published
                        orderby p.DisplayOrder ascending
                        select p;
            var modules = query.ToList();

            return modules;
        }


        /// <summary>
        ///  根据 moduleID 查询 Module
        /// </summary>
        /// <param name="moduleID">moduleID</param>
        /// <returns>Module</returns>
        public Module getModuleByModuleID(int moduleID)
        {
            var query = from p in this._context.Modules
                        where p.ModuleID == moduleID && !p.Deleted
                        orderby p.DisplayOrder ascending
                        select p;
            return query.SingleOrDefault();
        }


        /// <summary>
        /// 查询 Module 分页列表
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">返回记录数</param>
        /// <returns>Module Page List</returns>
        public PagedList<Module> GetModuleList(int pageIndex, int pageSize)
        {
            var query = from p in this._context.Modules
                        where !p.Deleted
                        orderby p.DisplayOrder ascending
                        select p;
            return new PagedList<Module>(query, pageIndex, pageSize);
        }


        /// <summary>
        /// Deletes a Module item
        /// </summary>
        /// <param name="logId">Log item identifier</param>
        public void DeleteModule(int moduleId)
        {
            var module = getModuleByModuleID(moduleId);
            if (module == null)
                return;

            module.Deleted = true;
            if (!_context.IsAttached(module))
                _context.Modules.Attach(module);
            _context.SaveChanges();
        }

        /// <summary>
        /// 插入Module数据
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="moduleName"></param>
        /// <param name="moduleCode"></param>
        /// <param name="istarget"></param>
        /// <param name="strHref"></param>
        /// <param name="expand"></param>
        /// <param name="displayOrder"></param>
        /// <returns></returns>
        public Module InsertModule(int? parentId, string moduleName, string moduleCode, bool istarget
            , string strHref, bool expand, int displayOrder, bool published, string iconcls, string appIconcls)
        {

            var module = _context.Modules.CreateObject();
            module.ParentID = parentId;
            module.ModuleName = moduleName;
            module.ModuleCode = moduleCode;
            module.isTarget = istarget;
            module.href = strHref;
            module.Expand = expand;
            module.DisplayOrder = displayOrder;
            module.Published = published;
            module.Deleted = false;
            module.iconCls = iconcls;
            module.AppIconCls = appIconcls;
            _context.Modules.AddObject(module);
            _context.SaveChanges();

            //raise event  
            EventContext.Current.OnModuleUpdated(null,
                new ModuleEventArgs() { Module = module });

            return module;
        }

        /// <summary>
        /// 修改Module数据
        /// </summary>
        /// <param name="moduleID"></param>
        /// <param name="parentId"></param>
        /// <param name="moduleName"></param>
        /// <param name="moduleCode"></param>
        /// <param name="istarget"></param>
        /// <param name="strHref"></param>
        /// <param name="expand"></param>
        /// <param name="displayOrder"></param>
        public void UpdateModule(int moduleID, int? parentId, string moduleName, string moduleCode, bool istarget
            , string strHref, bool expand, int displayOrder, bool published, string iconcls, string appIconcls)
        {
            var module = getModuleByModuleID(moduleID);
            if (module == null)
                return;

            module.ParentID = parentId;
            module.ModuleName = moduleName;
            module.ModuleCode = moduleCode;
            module.isTarget = istarget;
            module.href = strHref;
            module.Expand = expand;
            module.DisplayOrder = displayOrder;
            module.Published = published;
            module.iconCls = iconcls;
            module.AppIconCls = appIconcls;
            if (!_context.IsAttached(module))
                _context.Modules.Attach(module);
            _context.SaveChanges();
            
            //raise event             
            EventContext.Current.OnModuleUpdated(null,
                new ModuleEventArgs() { Module = module });
        }
        #endregion
    }
}
