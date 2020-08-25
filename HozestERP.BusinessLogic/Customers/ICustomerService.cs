
using System;
using System.Collections.Generic;
using System.Web.Security;
using HozestERP.Common;
using HozestERP.BusinessLogic.Enterprises;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public partial interface ICustomerService
    {

        #region CustomerManagement

        /// <summary>
        /// Reset data required for checkout
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="clearCouponCodes">A value indicating whether to clear coupon code</param>
        void ResetCheckoutData(int customerId, bool clearCouponCodes);

        /// <summary>
        /// Sets a customer email
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="newEmail">New email</param>
        /// <returns>Customer</returns>
        Customer SetEmail(int customerId, string newEmail);

        /// <summary>
        /// Sets a customer username
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="newUsername">New Username</param>
        /// <returns>Customer</returns>
        Customer ChangeCustomerUsername(int customerId, string newUsername);

        /// <summary>
        /// Sets a customer sugnature
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="signature">Signature</param>
        /// <returns>Customer</returns>
        Customer SetCustomerSignature(int customerId, string signature);

        /// <summary>
        /// Create anonymous user for current user
        /// </summary>
        /// <returns>Guest user</returns>
        void CreateAnonymousUser();

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>Customer collection</returns>
        PagedList<Customer> GetAllCustomers();

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <param name="registrationFrom">Customer registration from; null to load all customers</param>
        /// <param name="registrationTo">Customer registration to; null to load all customers</param>
        /// <param name="email">Customer Email</param>
        /// <param name="username">Customer username</param>
        /// <param name="dontLoadGuestCustomers">A value indicating whether to don't load guest customers</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <returns>Customer collection</returns>
        PagedList<Customer> GetAllCustomers(DateTime? registrationFrom,
            DateTime? registrationTo, string email, string username,
            bool dontLoadGuestCustomers, int pageSize, int pageIndex);


        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <param name="email">Customer Email</param>
        /// <param name="username">Customer username</param>
        /// <param name="active">Customer Active</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <returns>Customer collection</returns>
        PagedList<Customer> GetAllCustomers(string email, string username, bool active, int pageSize, int pageIndex);

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <param name="registrationFrom">Customer registration from; null to load all customers</param>
        /// <param name="registrationTo">Customer registration to; null to load all customers</param>
        /// <param name="email">Customer Email</param>
        /// <param name="username">Customer username</param>
        /// <param name="dontLoadGuestCustomers">A value indicating whether to don't load guest customers</param>
        /// <param name="dateOfBirthMonth">Filter by date of birth (month); 0 to load all customers;</param>
        /// <param name="dateOfBirthDay">Filter by date of birth (day); 0 to load all customers;</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <returns>Customer collection</returns>
        PagedList<Customer> GetAllCustomers(DateTime? registrationFrom,
            DateTime? registrationTo, string email, string username,
            bool dontLoadGuestCustomers, int dateOfBirthMonth, int dateOfBirthDay,
            int pageSize, int pageIndex);


        /// <summary>
        /// Gets all customers by customer role id
        /// </summary>
        /// <param name="customerRoleId">Customer role identifier</param>
        /// <returns>Customer collection</returns>
        List<Customer> GetCustomersByCustomerRoleId(int customerRoleId);

        /// <summary>
        /// delete customerRole 
        /// </summary>
        /// <param name="customerRoleID"></param>
        void DeleteCustomerRole(int customerRoleID);

        /// <summary>
        /// Marks customer as deleted
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        void MarkCustomerAsDeleted(int customerId);

        /// <summary>
        /// Gets a customer by email
        /// </summary>
        /// <param name="email">Customer Email</param>
        /// <returns>A customer</returns>
        Customer GetCustomerByEmail(string email);

        /// <summary>
        /// Gets a customer by Username
        /// </summary>
        /// <param name="username">Customer username</param>
        /// <returns>A customer</returns>
        List<Customer> GetCustomerByUsernameList(string username);


        /// <summary>
        /// Gets a customer by Username
        /// </summary>
        /// <param name="username">Customer username</param>
        /// <returns>A customer</returns>
        Customer GetCustomerByUsername(string username);

        List<Customer> GetCustomerByLikeUsername(string username);
        List<Customer> GetCustomerByLikeEmail(string username);

        /// <summary>
        /// Gets a DepartMent
        /// </summary>
        /// <param name="customerId">Department identifier</param>
        /// <returns>A Department</returns>
        Department GetDepartmentByCustomerID(int customerID);
        /// <summary>
        /// Gets a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>A customer</returns>
        Customer GetCustomerById(int customerId);
        /// <summary>
        /// delete 人事基本信息 by Id
        /// </summary>
        /// <param name="Id"> Id</param>
        void DeleteCustomer(int id);

        /// <summary>
        /// Batch delete CustomerInfoes by CustomerID
        /// </summary>
        /// <param name="Ids">CustomerInfoes CustomerID</param>
        void BatchDeleteCustomer(List<int> ids);
        /// <summary>
        /// 清空数据
        /// </summary>
        int DeleteDataEmptyCustomer();

        /// <summary>
        /// Gets a customer by GUID
        /// </summary>
        /// <param name="customerGuid">Customer GUID</param>
        /// <returns>A customer</returns>
        Customer GetCustomerByGuid(Guid customerGuid);

        /// <summary>
        /// Adds a customer
        /// </summary>
        /// <param name="email">The email</param>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <param name="isAdmin">A value indicating whether the customer is administrator</param>
        /// <param name="isGuest">A value indicating whether the customer is guest</param>
        /// <param name="active">A value indicating whether the customer is active</param>
        /// <param name="status">Status</param>
        /// <returns>A customer</returns>
        Customer AddCustomer(string email, string username, string password,
            bool isAdmin, bool isGuest, bool active, out MembershipCreateStatus status);


        /// <summary>
        /// Adds a customer
        /// </summary>
        /// <param name="customerGuid">The customer identifier</param>
        /// <param name="email">The email</param>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <param name="isAdmin">A value indicating whether the customer is administrator</param>
        /// <param name="isGuest">A value indicating whether the customer is guest</param>
        /// <param name="isForumModerator">A value indicating whether the customer is forum moderator</param>
        /// <param name="totalForumPosts">A forum post count</param>
        /// <param name="signature">Signature</param>
        /// <param name="adminComment">Admin comment</param>
        /// <param name="active">A value indicating whether the customer is active</param>
        /// <param name="deleted">A value indicating whether the customer has been deleted</param>
        /// <param name="registrationDate">The date and time of customer registration</param>
        /// <param name="timeZoneId">The time zone identifier</param>
        /// <param name="avatarId">The avatar identifier</param>
        /// <param name="dateOfBirth">Date of birth</param>
        /// <param name="status">Status</param>
        /// <returns>A customer</returns>
        Customer AddCustomer(Guid customerGuid, string email, string username,
            string password, bool isAdmin, bool isGuest, string signature, string adminComment,
            bool active, bool deleted, DateTime registrationDate,
            string timeZoneId, int avatarId, DateTime? dateOfBirth, out MembershipCreateStatus status);

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        string PublicPasswordHash(string password, string salt);

         /// <summary>
        /// Public a salt
        /// </summary>
        /// <param name="size">A salt size</param>
        /// <returns>A salt</returns>
        string PublicSalt(int size);

        /// <summary>
        /// Adds a customer without any validations, welcome messages
        /// </summary>
        /// <param name="customerGuid">The customer identifier</param>
        /// <param name="email">The email</param>
        /// <param name="username">The username</param>
        /// <param name="passwordHash">The password hash</param>
        /// <param name="saltKey">The salt key</param>
        /// <param name="isAdmin">A value indicating whether the customer is administrator</param>
        /// <param name="isGuest">A value indicating whether the customer is guest</param>
        /// <param name="signature">Signature</param>
        /// <param name="adminComment">Admin comment</param>
        /// <param name="active">A value indicating whether the customer is active</param>
        /// <param name="deleted">A value indicating whether the customer has been deleted</param>
        /// <param name="registrationDate">The date and time of customer registration</param>
        /// <param name="timeZoneId">The time zone identifier</param>
        /// <param name="avatarId">The avatar identifier</param>
        /// <param name="dateOfBirth">Date of birth</param>
        /// <returns>A customer</returns>
        Customer AddCustomerForced(Guid customerGuid, string email,
            string username, string passwordHash, string saltKey,
            bool isAdmin, bool isGuest, string signature, string adminComment,
            bool active, bool deleted, DateTime registrationDate, string timeZoneId,
            int avatarId, DateTime? dateOfBirth);

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        void UpdateCustomer(Customer customer);

        /// <summary>
        /// Modifies password
        /// </summary>
        /// <param name="email">Customer email</param>
        /// <param name="oldPassword">Old password</param>
        /// <param name="password">Password</param>
        void ModifyPassword(string email, string oldPassword, string password);

        /// <summary>
        /// Modifies password
        /// </summary>
        /// <param name="email">Customer email</param>
        /// <param name="newPassword">New password</param>
        void ModifyPassword(string email, string newPassword);

        /// <summary>
        /// Modifies password
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="newPassword">New password</param>
        void ModifyPassword(int customerId, string newPassword);

        /// <summary>
        /// Modifies password
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="newPassword">New password</param>
        string ModifyPassword(int customerId, string oldPassword, string newPassword);

        /// <summary>
        /// Activates a customer
        /// </summary>
        /// <param name="customerGuid">Customer identifier</param>
        void Activate(Guid customerGuid);

        /// <summary>
        /// Activates a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        void Activate(int customerId);

        /// <summary>
        /// Activates a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="sendCustomerWelcomeMessage">A value indivating whether to send customer welcome message</param>
        void Activate(int customerId, bool sendCustomerWelcomeMessage);

        /// <summary>
        /// Deactivates a customer
        /// </summary>
        /// <param name="customerGuid">Customer identifier</param>
        void Deactivate(Guid customerGuid);

        /// <summary>
        /// Deactivates a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        void Deactivate(int customerId);

        /// <summary>
        /// Login a customer
        /// </summary>
        /// <param name="userName">A customer userName</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        bool Login(string userName, string password);

        /// <summary>
        /// Logout customer
        /// </summary>
        void Logout();

        /// <summary>
        /// 将密码进行加密
        /// </summary>
        void ChangePassWordHash();

        /// <summary>
        /// WebService登录信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>WebServiceUserInfo</returns>
        WebServiceUserInfo WebServiceLogin(string userName, string password);
        #endregion

        #region Customer attributes

        /// <summary>
        /// Deletes a customer attribute
        /// </summary>
        /// <param name="customerAttributeId">Customer attribute identifier</param>
        void DeleteCustomerAttribute(int customerAttributeId);

        /// <summary>
        /// Gets a customer attribute
        /// </summary>
        /// <param name="customerAttributeId">Customer attribute identifier</param>
        /// <returns>A customer attribute</returns>
        CustomerAttribute GetCustomerAttributeById(int customerAttributeId);

        /// <summary>
        /// Gets a collection of customer attributes by customer identifier
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>Customer attributes</returns>
        List<CustomerAttribute> GetCustomerAttributesByCustomerId(int customerId);

        /// <summary>
        /// Inserts a customer attribute
        /// </summary>
        /// <param name="customerAttribute">Customer attribute</param>
        void InsertCustomerAttribute(CustomerAttribute customerAttribute);

        /// <summary>
        /// Updates the customer attribute
        /// </summary>
        /// <param name="customerAttribute">Customer attribute</param>
        void UpdateCustomerAttribute(CustomerAttribute customerAttribute);

        #endregion

        #region Customer sessions

        /// <summary>
        /// Gets a customer session
        /// </summary>
        /// <param name="customerSessionGuid">Customer session GUID</param>
        /// <returns>Customer session</returns>
        CustomerSession GetCustomerSessionByGuid(Guid customerSessionGuid);

        /// <summary>
        /// Gets a customer session by customer identifier
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>Customer session</returns>
        CustomerSession GetCustomerSessionByCustomerId(int customerId);

        /// <summary>
        /// Deletes a customer session
        /// </summary>
        /// <param name="customerSessionGuid">Customer session GUID</param>
        void DeleteCustomerSession(Guid customerSessionGuid);

        /// <summary>
        /// Gets all customer sessions
        /// </summary>
        /// <returns>Customer session collection</returns>
        List<CustomerSession> GetAllCustomerSessions();

        /// <summary>
        /// Gets all customer sessions
        /// </summary>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>Customer session collection</returns>
        PagedList<CustomerSession> GetAllCustomerSessions(int pageIndex, int pageSize);


        /// <summary>
        /// Deletes all expired customer sessions
        /// </summary>
        /// <param name="olderThan">Older than date and time</param>
        void DeleteExpiredCustomerSessions(DateTime olderThan);

        /// <summary>
        /// Saves a customer session to the data storage if it exists or creates new one
        /// </summary>
        /// <param name="customerSessionGuid">Customer session GUID</param>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="lastAccessed">The last accessed date and time</param>
        /// <param name="isExpired">A value indicating whether the customer session is expired</param>
        /// <returns>Customer session</returns>
        CustomerSession SaveCustomerSession(Guid customerSessionGuid,
            int customerId, DateTime lastAccessed, bool isExpired);
        #endregion



        #region Cutomer Role StaffPrivileges
        /// <summary>
        /// Adds a customer to role StaffPrivileges
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="customerRoleId">Customer role identifier</param>
        void AddCustomerToRoleStaffPrivileges(int customerId, int customerRoleId);

        /// <summary>
        /// Removes a customer from role StaffPrivileges
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="customerRoleId">Customer role identifier</param>
        void RemoveCustomerFromRoleStaffPrivileges(int customerId, int customerRoleId);

        /// <summary>
        /// Gets CustomerInfo by CustomerRole identifier
        /// </summary>
        /// <param name="customerRoleId">Customer Role identifier</param>
        /// <returns>Customer role collection</returns>
        List<CustomerInfo> GetCustomerRoleStaffPrivilegesByCustomerId(int customerRoleId);
        #endregion



        #region Customer roles

        /// <summary>
        /// Marks customer role as deleted
        /// </summary>
        /// <param name="customerRoleId">Customer role identifier</param>
        void MarkCustomerRoleAsDeleted(int customerRoleId);

        /// <summary>
        /// Gets a customer role
        /// </summary>
        /// <param name="customerRoleId">Customer role identifier</param>
        /// <returns>Customer role</returns>
        CustomerRole GetCustomerRoleById(int customerRoleId);

        /// <summary>
        /// 获取该父节点下子节点中Code 最大的记录
        /// </summary>
        /// <param name="parentCustomerRoleID"></param>
        /// <returns></returns>
        List<CustomerRole> GetCustomerRoleByParentCustomerRoleID(int parentCustomerRoleID);

        /// <summary>
        /// 按条件获取角色记录
        /// </summary>
        /// <param name="parentCustomerRoleID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        List<CustomerRole> GetCustomerRoleByCondition(int parentCustomerRoleID, string name);

        /// <summary>
        /// Gets all customer roles
        /// </summary>
        /// <returns>Customer role collection</returns>
        List<CustomerRole> GetAllCustomerRoles();

        /// <summary>
        /// Gets all customer roles
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>Customer role collection</returns>
        PagedList<CustomerRole> GetAllCustomerRoles(string name, int pageIndex, int pageSize);

        /// <summary>
        /// Gets customer roles by customer identifier
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>Customer role collection</returns>
        List<CustomerRole> GetCustomerRolesByCustomerId(int customerId);

        List<CustomerRole> GetRolesByCustomerId(int CustomerID);

        /// <summary>
        /// Gets customer roles by customer identifier
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Customer role collection</returns>
        List<CustomerRole> GetCustomerRolesByCustomerId(int customerId, bool showHidden);

        /// <summary>
        /// Gets Department by customer Role Id
        /// </summary>
        /// <param name="customerRoleId">customer Role Id</param>
        /// <returns>Customer role collection</returns>
        List<Department> GetDepartmentByCustomerRoleId(int customerRoleId);


        /// <summary>
        /// Inserts a customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        void InsertCustomerRole(CustomerRole customerRole);

        /// <summary>
        /// Updates the customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        void UpdateCustomerRole(CustomerRole customerRole);

        /// <summary>
        /// Adds a customer to role
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="customerRoleId">Customer role identifier</param>
        void AddCustomerToRole(int customerId, int customerRoleId);


        /// <summary>
        /// Adds a department to role
        /// </summary>
        /// <param name="customerId">department identifier</param>
        /// <param name="customerRoleId">Customer role identifier</param>
        void AddDepartmentToRole(int departmentId, int customerRoleId);

        /// <summary>
        /// Removes a customer from role
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="customerRoleId">Customer role identifier</param>
        void RemoveCustomerFromRole(int customerId, int customerRoleId);


        /// <summary>
        /// Removes a department from role
        /// </summary>
        /// <param name="customerId">department identifier</param>
        /// <param name="customerRoleId">Customer role identifier</param>
        void RemoveDepartmentFromRole(int departmentId, int customerRoleId);

        /// <summary>
        /// Gets CustomerInfo by customer identifier
        /// </summary>
        /// <param name="customerRoleId">Customer Role identifier</param>
        /// <returns>Customer role collection</returns>
        List<CustomerInfo> GetCustomerInfosByCustomerRoleId(int customerRoleId);

        List<CustomerInfo> GetCustomerInfosByRoleID(int RoleId);

        /// <summary>
        /// 身份验证，分配权限
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        int testIdentity(int CustomerID);

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether anonymous checkout allowed
        /// </summary>
        bool AnonymousCheckoutAllowed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether usernames are used instead of emails
        /// </summary>
        bool UsernamesEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to change their usernames
        /// </summary>
        bool AllowCustomersToChangeUsernames { get; set; }

        /// <summary>
        /// Customer name formatting
        /// </summary>
        CustomerNameFormatEnum CustomerNameFormatting { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to upload avatars.
        /// </summary>
        bool AllowCustomersToUploadAvatars { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display default user avatar.
        /// </summary>
        bool DefaultAvatarEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers location is shown
        /// </summary>
        bool ShowCustomersLocation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show customers join date
        /// </summary>
        bool ShowCustomersJoinDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to view profiles of other customers
        /// </summary>
        bool AllowViewingProfiles { get; set; }

        /// <summary>
        /// Tax display type
        /// </summary>
        CustomerRegistrationTypeEnum CustomerRegistrationType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow navigation only for registered users.
        /// </summary>
        bool AllowNavigationOnlyRegisteredCustomers { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether product reviews must be approved by administrator.
        /// </summary>
        bool ProductReviewsMustBeApproved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow anonymous users write product reviews.
        /// </summary>
        bool AllowAnonymousUsersToReviewProduct { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow anonymous users to email a friend.
        /// </summary>
        bool AllowAnonymousUsersToEmailAFriend { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow anonymous users to set product ratings.
        /// </summary>
        bool AllowAnonymousUsersToSetProductRatings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'New customer' notification message should be sent to a store owner
        /// </summary>
        bool NotifyNewCustomerRegistration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Gender' is enabled
        /// </summary>
        bool FormFieldGenderEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Date of Birth' is enabled
        /// </summary>
        bool FormFieldDateOfBirthEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Company' is enabled
        /// </summary>
        bool FormFieldCompanyEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Company' is required
        /// </summary>
        bool FormFieldCompanyRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Street Address' is enabled
        /// </summary>
        bool FormFieldStreetAddressEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Street Address' is required
        /// </summary>
        bool FormFieldStreetAddressRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Street Address 2' is enabled
        /// </summary>
        bool FormFieldStreetAddress2Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Street Address 2' is required
        /// </summary>
        bool FormFieldStreetAddress2Required { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Post Code' is enabled
        /// </summary>
        bool FormFieldPostCodeEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Post Code' is required
        /// </summary>
        bool FormFieldPostCodeRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'City' is enabled
        /// </summary>
        bool FormFieldCityEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'City' is required
        /// </summary>
        bool FormFieldCityRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Country' is enabled
        /// </summary>
        bool FormFieldCountryEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'State' is enabled
        /// </summary>
        bool FormFieldStateEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Phone' is enabled
        /// </summary>
        bool FormFieldPhoneEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Phone' is required
        /// </summary>
        bool FormFieldPhoneRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Fax' is enabled
        /// </summary>
        bool FormFieldFaxEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Fax' is required
        /// </summary>
        bool FormFieldFaxRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Newsletter' is enabled
        /// </summary>
        bool FormFieldNewsletterEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Time Zone' is enabled
        /// </summary>
        bool FormFieldTimeZoneEnabled { get; set; }

        #endregion
    }
}
