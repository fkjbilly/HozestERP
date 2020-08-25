using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ModuleManagement;

namespace HozestERP.BusinessLogic.Security
{
    public partial  interface IACLService
    {
        #region ACL
        
        /// <summary>
        /// 判断事件KeyWord是否存在
        /// </summary>
        /// <param name="customerActionID">事件ID</param>
        /// <param name="systemKeyword">KeyWord</param>
        /// <returns>true 存在 false 不存在</returns>
        bool CheckCustomerActionByKeyword(int customerActionID, string systemKeyword);
        
        /// <summary>
        /// Inserts an CustomerAction
        /// </summary>
        /// <param name="customerAction">CustomerAction</param>
        void InsertCustomerAction(CustomerAction customerAction);

        /// <summary>
        /// Updates the CustomerAction
        /// </summary>
        /// <param name="acl">CustomerAction</param>
        void UpdateCustomerAction(CustomerAction customerAction);

        /// <summary>
        /// Deletes a customer action
        /// </summary>
        /// <param name="customerActionId">Customer action identifier</param>
        void DeleteCustomerAction(int customerActionId);

        /// <summary>
        /// Gets a customer action by identifier
        /// </summary>
        /// <param name="customerActionId">Customer action identifier</param>
        /// <returns>Customer action</returns>
        CustomerAction GetCustomerActionById(int customerActionId);

        /// <summary>
        /// Gets all customer actions
        /// </summary>
        /// <returns>Customer action collection</returns>
        List<CustomerAction> GetAllCustomerActions();

         /// <summary>
        /// Gets all customer actions
        /// </summary>
        /// <returns>Customer action collection</returns>
        List<CustomerAction> GetAllCustomerActionsByACLModule(int customerRoleID);

        /// <summary>
        /// Gets all customer actions
        /// </summary>
        /// <returns>Customer action collection</returns>
        List<SelectCustomerAction> GetAllCustomerActionsByACLModule(int customerRoleID, int? moduleID);

        /// <summary>
        /// Gets all customer actions
        /// </summary>
        /// <param name="moduleID">ModuleID</param>
        /// <returns>Customer action collection</returns>
        List<CustomerAction> GetAllCustomerActions(int moduleID);

        /// <summary>
        /// Deletes an ACL
        /// </summary>
        /// <param name="aclId">ACL identifier</param>
        void DeleteAcl(int aclId);

        /// <summary>
        /// Gets an ACL by identifier
        /// </summary>
        /// <param name="aclId">ACL identifier</param>
        /// <returns>ACL</returns>
        ACL GetAclById(int aclId);

        /// <summary>
        /// Gets all ACL
        /// </summary>
        /// <param name="customerActionId">Customer action identifier; 0 to load all records</param>
        /// <param name="customerRoleId">Customer role identifier; 0 to load all records</param>
        /// <param name="allow">Value indicating whether action is allowed; null to load all records</param>
        /// <returns>ACL collection</returns>
        List<ACL> GetAllAcl(int customerActionId,
            int customerRoleId, bool? allow);

        /// <summary>
        /// Inserts an ACL
        /// </summary>
        /// <param name="acl">ACL</param>
        void InsertAcl(ACL acl);

        /// <summary>
        /// Updates the ACL
        /// </summary>
        /// <param name="acl">ACL</param>
        void UpdateAcl(ACL acl);

        /// <summary>
        /// Updates the ACL by Customer Role ID
        /// </summary>
        /// <param name="customerRoleID">Customer role identifier</param>
        void DeleteAclByCustomerRoleID(int customerRoleID);

        /// <summary>
        /// Indicates whether action is allowed
        /// </summary>
        /// <param name="actionSystemKeyword">Action system keyword</param>
        /// <returns>Result</returns>
        bool IsActionAllowed(string actionSystemKeyword);

        /// <summary>
        /// Indicates whether action is allowed
        /// </summary>
        /// <param name="customerId">Customer identifer</param>
        /// <param name="actionSystemKeyword">Action system keyword</param>
        /// <returns>Result</returns>
        bool IsActionAllowed(int customerId, string actionSystemKeyword);

        #endregion

        #region ACL Module
        /// <summary>
        /// Indicates whether action is allowed
        /// </summary>
        /// <param name="actionSystemKeyword">Action system keyword</param>
        /// <returns>Result</returns>
        bool IsModuleAllowed(int moduleID);

        /// <summary>
        /// Indicates whether action is allowed
        /// </summary>
        /// <param name="customerId">Customer identifer</param>
        /// <param name="actionSystemKeyword">Action system keyword</param>
        /// <returns>Result</returns>
        bool IsModuleAllowed(int moduleID, int customerId);

        /// <summary>
        /// Deletes an ACLModule
        /// </summary>
        /// <param name="aclModuleId">ACLModule identifier</param>
        void DeleteAclModule(int aclModuleId);

        /// <summary>
        /// Gets an ACL by identifier
        /// </summary>
        /// <param name="aclId">ACL identifier</param>
        /// <returns>ACL</returns>
        ACLModule GetAclModuleById(int aclModuleId);
        
        /// <summary>
        /// 获取当前用户菜单
        /// </summary>
        /// <param name="moduleID">Module identifier</param>
        /// <returns>Module collection</returns>
        List<Module> GetModulesByModuleID(int moduleID);

        
        /// <summary>
        /// 获取指定用户菜单
        /// </summary>
        /// <param name="moduleID">Module identifier</param>
        /// <param name="customerID">Customer identifier</param>
        /// <returns>Module collection</returns>
        List<Module> GetModulesByModuleID(int moduleID, int customerID);

        /// <summary>
        /// Gets all ACLModule
        /// </summary>
        /// <param name="customerActionId">Customer action identifier; 0 to load all records</param>
        /// <param name="customerRoleId">Customer role identifier; 0 to load all records</param>
        /// <param name="allow">Value indicating whether action is allowed; null to load all records</param>
        /// <returns>ACLModule collection</returns>
        List<ACLModule> GetAllACLModule(int mdouleID,
            int customerRoleId, bool? allow);

        /// <summary>
        /// Inserts an ACLModule
        /// </summary>
        /// <param name="aCLModule">ACLModule</param>
        void InsertACLModule(ACLModule aCLModule);
        
        /// <summary>
        /// Updates the ACLModule
        /// </summary>
        /// <param name="acl">ACLModule</param>
        void UpdateACLModule(ACLModule aCLModule);

         /// <summary>
        /// delete the ACLModule by customerRoleId
        /// </summary>
        /// <param name="customerRoleId">customerRoleId</param>
        void DeleteACLModuleByCustomerRoleId(int customerRoleId);

        #endregion

        /// <summary>
        /// Gets a value indicating ACL feature is enabled
        /// </summary>
        bool Enabled { get; set; }
    }
}
