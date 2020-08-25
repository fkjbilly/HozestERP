using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Objects;

using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ModuleManagement;

namespace HozestERP.BusinessLogic.Security
{
    public partial class ACLService : IACLService
    {
        #region Constants
        private const string CUSTOMERACTIONS_ALL_KEY = "CRM.customeraction.all";
        private const string CUSTOMERACTIONS_BY_ModuleID_KEY = "CRM.customeraction.ModuleID-{0}";
        private const string CUSTOMERACTIONS_BY_ID_KEY = "CRM.customeraction.id-{0}";
        private const string CUSTOMERACTIONS_PATTERN_KEY = "CRM.customeraction.";
        private const string CUSTOMERACTIONS_BY_ModuleID_UserID_KEY = "CRM.customeraction.ModuleID-{0}-UserID-{1}";
        private const string PageIsActionAllowed_KEY = "PageIsActionAllowed-CustomerID-{0}-actionSystemKeyword-{1}";
        private const string PageIsAllowed_BY_ModuleID_CutomerID_KEY = "PageIsAllowed-ModuleID-{0}-CustomerID-{1}";
        #endregion

        #region Fields

        /// <summary>
        /// Object context
        /// </summary>
        private readonly HozestERPObjectContext _context;

        /// <summary>
        /// Cache service
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public ACLService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPStaticCache();
        }

        #endregion

        #region Methods

        #region ACL


        /// <summary>
        /// 判断事件KeyWord是否存在
        /// </summary>
        /// <param name="customerActionID">事件ID</param>
        /// <param name="systemKeyword">KeyWord</param>
        /// <returns>true 存在 false 不存在</returns>
        public bool CheckCustomerActionByKeyword(int customerActionID, string systemKeyword)
        {
            var query = from ca in _context.CustomerActions
                        where ca.SystemKeyword == systemKeyword
                        && (customerActionID == 0 || ca.CustomerActionID != customerActionID)
                        select ca;
            return query.Count() > 0 ? true : false;
        }

        /// <summary>
        /// Inserts an CustomerAction
        /// </summary>
        /// <param name="customerAction">CustomerAction</param>
        public void InsertCustomerAction(CustomerAction customerAction)
        {
            if (customerAction == null)
                throw new ArgumentNullException("customerAction");



            _context.CustomerActions.AddObject(customerAction);
            _context.SaveChanges();
            if (this.CacheEnabled)
            {
                _cacheManager.RemoveByPattern(CUSTOMERACTIONS_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Updates the CustomerAction
        /// </summary>
        /// <param name="acl">CustomerAction</param>
        public void UpdateCustomerAction(CustomerAction customerAction)
        {
            if (customerAction == null)
                throw new ArgumentNullException("customerAction");


            if (!_context.IsAttached(customerAction))
                _context.CustomerActions.Attach(customerAction);

            _context.SaveChanges();
            if (this.CacheEnabled)
            {
                _cacheManager.RemoveByPattern(CUSTOMERACTIONS_PATTERN_KEY);
            }
        }


        /// <summary>
        /// Deletes a customer action
        /// </summary>
        /// <param name="customerActionId">Customer action identifier</param>
        public void DeleteCustomerAction(int customerActionId)
        {
            var customerAction = GetCustomerActionById(customerActionId);
            if (customerAction == null)
                return;


            if (!_context.IsAttached(customerAction))
                _context.CustomerActions.Attach(customerAction);
            _context.DeleteObject(customerAction);
            _context.SaveChanges();

            if (this.CacheEnabled)
            {
                _cacheManager.RemoveByPattern(CUSTOMERACTIONS_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Gets a customer action by identifier
        /// </summary>
        /// <param name="customerActionId">Customer action identifier</param>
        /// <returns>Customer action</returns>
        public CustomerAction GetCustomerActionById(int customerActionId)
        {
            if (customerActionId == 0)
                return null;

            string key = string.Format(CUSTOMERACTIONS_BY_ID_KEY, customerActionId);
            object obj2 = _cacheManager.Get(key);
            if (this.CacheEnabled && (obj2 != null))
            {
                return (CustomerAction)obj2;
            }


            var query = from ca in _context.CustomerActions
                        where ca.CustomerActionID == customerActionId
                        select ca;
            var customerAction = query.SingleOrDefault();

            if (this.CacheEnabled)
            {
                _cacheManager.Add(key, customerAction);
            }
            return customerAction;
        }

        /// <summary>
        /// Gets all customer actions
        /// </summary>
        /// <returns>Customer action collection</returns>
        public List<CustomerAction> GetAllCustomerActions()
        {
            string key = string.Format(CUSTOMERACTIONS_ALL_KEY);
            object obj2 = _cacheManager.Get(key);
            if (this.CacheEnabled && (obj2 != null))
            {
                return (List<CustomerAction>)obj2;
            }


            var query = from ca in _context.CustomerActions
                        orderby ca.DisplayOrder, ca.Name
                        select ca;
            var customerActions = query.ToList();

            if (this.CacheEnabled)
            {
                _cacheManager.Add(key, customerActions);
            }
            return customerActions;
        }

        /// <summary>
        /// Gets all customer actions
        /// </summary>
        /// <returns>Customer action collection</returns>
        public List<CustomerAction> GetAllCustomerActionsByACLModule(int customerRoleID)
        {
            var query = from ca in _context.CustomerActions
                        join aclM in this._context.ACLModules on ca.ModuleID equals aclM.ModuleID
                        where aclM.CustomerRoleId.Equals(customerRoleID)
                        orderby ca.ModuleID
                        select ca;
            var customerActions = query.ToList();

            return customerActions;
        }


        /// <summary>
        /// Gets all customer actions
        /// </summary>
        /// <returns>Customer action collection</returns>
        public List<SelectCustomerAction> GetAllCustomerActionsByACLModule(int customerRoleID, int? moduleID)
        {        

            var query = from ca in _context.CustomerActions
                        join m in this._context.Modules on ca.ModuleID equals m.ModuleID
                        join acl in
                            (from ss in this._context.ACLs where ss.CustomerRoleID.Equals(customerRoleID) select ss)
                        on ca.CustomerActionID equals acl.CustomerActionID into x
                        from y in x.DefaultIfEmpty()
                        where (!moduleID.HasValue || ca.ModuleID == moduleID)
                        orderby ca.ModuleID
                        select new SelectCustomerAction
                        {
                            CustomerActionID = ca.CustomerActionID,
                            ModuleName = m.ModuleName,
                            ModuleID = m.ModuleID,
                            Name = ca.Name,
                            CustomerRoleID = customerRoleID,
                            ACLID = y != null ? y.ACLID : 0,
                            Allow = y != null ? y.Allow : false
                        };
            string sql = (query as ObjectQuery<SelectCustomerAction>).ToTraceString();
            var customerActions = query.ToList();

            return customerActions;
        }


        /// <summary>
        /// Gets all customer actions
        /// </summary>
        /// <returns>Customer action collection</returns>
        public List<CustomerAction> GetAllCustomerActions(int moduleID)
        {
            string key = string.Format(CUSTOMERACTIONS_BY_ModuleID_KEY, moduleID.ToString());
            object obj2 = _cacheManager.Get(key);
            if (this.CacheEnabled && (obj2 != null))
            {
                return (List<CustomerAction>)obj2;
            }


            var query = from ca in _context.CustomerActions
                        where ca.ModuleID == moduleID
                        orderby ca.DisplayOrder, ca.Name
                        select ca;
            var customerActions = query.ToList();

            if (this.CacheEnabled)
            {
                _cacheManager.Add(key, customerActions);
            }
            return customerActions;
        }
        /// <summary>
        /// Deletes an ACL
        /// </summary>
        /// <param name="aclId">ACL identifier</param>
        public void DeleteAcl(int aclId)
        {
            var acl = GetAclById(aclId);
            if (acl == null)
                return;


            if (!_context.IsAttached(acl))
                _context.ACLs.Attach(acl);
            _context.DeleteObject(acl);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets an ACL by identifier
        /// </summary>
        /// <param name="aclId">ACL identifier</param>
        /// <returns>ACL</returns>
        public ACL GetAclById(int aclId)
        {
            if (aclId == 0)
                return null;


            var query = from a in _context.ACLs
                        where a.ACLID == aclId
                        select a;
            var acl = query.SingleOrDefault();
            return acl;
        }

        /// <summary>
        /// Gets all ACL
        /// </summary>
        /// <param name="customerActionId">Customer action identifier; 0 to load all records</param>
        /// <param name="customerRoleId">Customer role identifier; 0 to load all records</param>
        /// <param name="allow">Value indicating whether action is allowed; null to load all records</param>
        /// <returns>ACL collection</returns>
        public List<ACL> GetAllAcl(int customerActionId,
            int customerRoleId, bool? allow)
        {

            var query = (IQueryable<ACL>)_context.ACLs;
            if (customerActionId > 0)
                query = query.Where(a => a.CustomerActionID == customerActionId);
            if (customerRoleId > 0)
                query = query.Where(a => a.CustomerRoleID == customerRoleId);
            if (allow.HasValue)
                query = query.Where(a => a.Allow == allow.Value);
            query = query.OrderByDescending(a => a.ACLID);

            var aclCollection = query.ToList();

            return aclCollection;
        }

        /// <summary>
        /// Inserts an ACL
        /// </summary>
        /// <param name="acl">ACL</param>
        public void InsertAcl(ACL acl)
        {
            if (acl == null)
                throw new ArgumentNullException("acl");



            _context.ACLs.AddObject(acl);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the ACL
        /// </summary>
        /// <param name="acl">ACL</param>
        public void UpdateAcl(ACL acl)
        {
            if (acl == null)
                throw new ArgumentNullException("acl");


            if (!_context.IsAttached(acl))
                _context.ACLs.Attach(acl);

            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the ACL by Customer Role ID
        /// </summary>
        /// <param name="customerRoleID"></param>
        public void DeleteAclByCustomerRoleID(int customerRoleID)
        {
            if (customerRoleID == 0)
                return;
            string sql = "Delete Sys_ACL WHERE CustomerRoleID=" + customerRoleID;
            this._context.ExecuteStoreCommand(sql);
        }

        /// <summary>
        /// Indicates whether action is allowed
        /// </summary>
        /// <param name="actionSystemKeyword">Action system keyword</param>
        /// <returns>Result</returns>
        public bool IsActionAllowed(string actionSystemKeyword)
        {
            int userId = 0;
            if (HozestERPContext.Current.User != null)
                userId = HozestERPContext.Current.User.CustomerID;
            return IsActionAllowed(userId, actionSystemKeyword);
        }

        /// <summary>
        /// Indicates whether action is allowed
        /// </summary>
        /// <param name="customerId">Customer identifer</param>
        /// <param name="actionSystemKeyword">Action system keyword</param>
        /// <returns>Result</returns>
        public bool IsActionAllowed(int customerId, string actionSystemKeyword)
        {
            if (!this.Enabled)
                return true;

            string key = string.Format(PageIsActionAllowed_KEY,  customerId.ToString(), actionSystemKeyword);
            object obj2 = _cacheManager.Get(key);
            if (this.CacheEnabled && (obj2 != null))
            {
                return (bool)obj2;
            }

            var query = from c in _context.Customers
                        from cr in c.SCustomerRoles
                        join acl in _context.ACLs on cr.CustomerRoleID equals acl.CustomerRoleID
                        join ca in _context.CustomerActions on acl.CustomerActionID equals ca.CustomerActionID
                        where c.CustomerID == customerId && 
                        !cr.Deleted &&
                        cr.Active &&
                        acl.Allow &&
                        ca.SystemKeyword == actionSystemKeyword
                        select acl;

            bool result = query.Count() > 0;

            if (this.CacheEnabled)
            {
                _cacheManager.Add(key, result);
            }
            return result;
        }

        #endregion

        #region ACL Module
        /// <summary>
        /// Indicates whether action is allowed
        /// </summary>
        /// <param name="actionSystemKeyword">Action system keyword</param>
        /// <returns>Result</returns>
        public bool IsModuleAllowed(int moduleID)
        {
            int userId = 0;
            if (HozestERPContext.Current.User != null)
                userId = HozestERPContext.Current.User.CustomerID;
            return IsModuleAllowed(moduleID, userId);
        }

        /// <summary>
        /// Indicates whether action is allowed
        /// </summary>
        /// <param name="customerId">Customer identifer</param>
        /// <param name="actionSystemKeyword">Action system keyword</param>
        /// <returns>Result</returns>
        public bool IsModuleAllowed(int moduleID, int customerId)
        {
            if (!this.Enabled)
                return true;

            string key = string.Format(PageIsAllowed_BY_ModuleID_CutomerID_KEY, moduleID.ToString(), customerId.ToString());
            object obj2 = _cacheManager.Get(key);
            if (this.CacheEnabled && (obj2 != null))
            {
                return (bool)obj2;
            }

            var query = from c in _context.Customers
                        from cr in c.SCustomerRoles
                        join acl in _context.ACLModules on cr.CustomerRoleID equals acl.CustomerRoleId
                        where c.CustomerID == customerId && acl.ModuleID == moduleID &&
                        !cr.Deleted &&
                        cr.Active &&
                        acl.Allow
                        select acl;

            bool result = query.Count() > 0;

            if (this.CacheEnabled)
            {
                _cacheManager.Add(key, result);
            }
            return result;
        }

        /// <summary>
        /// Deletes an ACLModule
        /// </summary>
        /// <param name="aclModuleId">ACLModule identifier</param>
        public void DeleteAclModule(int aclModuleId)
        {
            var aclModule = GetAclModuleById(aclModuleId);
            if (aclModule == null)
                return;


            if (!_context.IsAttached(aclModule))
                _context.ACLModules.Attach(aclModule);
            _context.DeleteObject(aclModule);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets an ACL by identifier
        /// </summary>
        /// <param name="aclId">ACL identifier</param>
        /// <returns>ACL</returns>
        public ACLModule GetAclModuleById(int aclModuleId)
        {
            if (aclModuleId == 0)
                return null;


            var query = from a in _context.ACLModules
                        where a.ACLModuleId == aclModuleId
                        select a;
            var aclModule = query.SingleOrDefault();
            return aclModule;
        }

        /// <summary>
        /// 获取当前用户菜单
        /// </summary>
        /// <param name="moduleID">Module identifier</param>
        /// <returns>Module collection</returns>
        public List<Module> GetModulesByModuleID(int moduleID)
        {
            int userId = 0;
            if (HozestERPContext.Current.User != null)
                userId = HozestERPContext.Current.User.CustomerID;

            if (!this.Enabled)
            {
                return IoC.Resolve<IModuleService>().GetModulesByModuleID(moduleID);
            }
            return this.GetModulesByModuleID(moduleID, userId);
        }

        /// <summary>
        /// 获取指定用户菜单
        /// </summary>
        /// <param name="moduleID">Module identifier</param>
        /// <param name="customerID">Customer identifier</param>
        /// <returns>Module collection</returns>
        public List<Module> GetModulesByModuleID(int moduleID, int customerID)
        {

            string key = string.Format(CUSTOMERACTIONS_BY_ModuleID_UserID_KEY, moduleID.ToString(), customerID.ToString());
            object obj2 = _cacheManager.Get(key);
            if (this.CacheEnabled && (obj2 != null))
            {
                return (List<Module>)obj2;
            }

            var query = from p in this._context.Modules
                        join am in this._context.ACLModules
                        on p.ModuleID equals am.ModuleID
                        join cr in this._context.CustomerRoles
                        on am.CustomerRoleId equals cr.CustomerRoleID
                        from c in cr.SCustomers
                        where p.ParentID == moduleID && !p.Deleted
                        && p.Published && am.Allow && c.CustomerID.Equals(customerID)
                        orderby p.DisplayOrder ascending
                        select p;
            var modules = query.Distinct().OrderBy(P => P.DisplayOrder).ToList();


            if (this.CacheEnabled)
            {
                _cacheManager.Add(key, modules);
            }

            return modules;
        }

        /// <summary>
        /// Gets all ACLModule
        /// </summary>
        /// <param name="customerActionId">Customer action identifier; 0 to load all records</param>
        /// <param name="customerRoleId">Customer role identifier; 0 to load all records</param>
        /// <param name="allow">Value indicating whether action is allowed; null to load all records</param>
        /// <returns>ACLModule collection</returns>
        public List<ACLModule> GetAllACLModule(int mdouleID,
            int customerRoleId, bool? allow)
        {

            var query = (IQueryable<ACLModule>)_context.ACLModules;
            if (mdouleID > 0)
                query = query.Where(a => a.ModuleID == mdouleID);
            if (customerRoleId > 0)
                query = query.Where(a => a.CustomerRoleId == customerRoleId);
            if (allow.HasValue)
                query = query.Where(a => a.Allow == allow.Value);
            query = query.OrderByDescending(a => a.ACLModuleId);

            var aclModuleCollection = query.ToList();

            return aclModuleCollection;
        }

        /// <summary>
        /// Inserts an ACLModule
        /// </summary>
        /// <param name="aCLModule">ACLModule</param>
        public void InsertACLModule(ACLModule aCLModule)
        {
            if (aCLModule == null)
                throw new ArgumentNullException("aCLModule");



            _context.ACLModules.AddObject(aCLModule);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the ACLModule
        /// </summary>
        /// <param name="acl">ACLModule</param>
        public void UpdateACLModule(ACLModule aCLModule)
        {
            if (aCLModule == null)
                throw new ArgumentNullException("aCLModule");


            if (!_context.IsAttached(aCLModule))
                _context.ACLModules.Attach(aCLModule);

            _context.SaveChanges();
        }

        /// <summary>
        /// delete the ACLModule by customerRoleId
        /// </summary>
        /// <param name="customerRoleId">customerRoleId</param>
        public void DeleteACLModuleByCustomerRoleId(int customerRoleId)
        {
            string sql = "DELETE Sys_ACLModule WHERE CustomerRoleId=" + customerRoleId.ToString();
            this._context.ExecuteStoreCommand(sql);
        }
        #endregion

        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating ACL feature is enabled
        /// </summary>
        public bool Enabled
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("ACL.Enabled");
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("ACL.Enabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets a value indicating whether cache is enabled
        /// </summary>
        public bool CacheEnabled
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Cache.ACLManager.CacheEnabled");
            }
        }

        #endregion
    }
}
