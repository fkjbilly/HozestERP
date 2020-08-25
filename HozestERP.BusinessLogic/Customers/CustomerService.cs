/******************************************************************
** Copyright (c) 2008 -2012 
** 创建人:方银朗
** 创建日期:2011-02-10
** 修改人: 方银朗
** 修改日期: 2011-02-10
** 描 述: 方银朗 2011-02-10 增加类的头部注释
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
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Infrastructure;
using System.Web.Security;
using System.Web;
using System.Security.Cryptography;
using System.Data;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Installation;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public partial class CustomerService : ICustomerService
    {
        #region Constants

        private const string CUSTOMERROLES_ALL_KEY = "CRM.customerrole.all-{0}";
        private const string CUSTOMERROLES_BY_ID_KEY = "CRM.customerrole.id-{0}";
        private const string CUSTOMERROLES_BY_DISCOUNTID_KEY = "CRM.customerrole.bydiscountid-{0}-{1}";
        private const string CUSTOMERROLES_PATTERN_KEY = "CRM.customerrole.";
        #endregion

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
        public CustomerService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion


        #region Customer roles

        /// <summary>
        /// Marks customer role as deleted
        /// </summary>
        /// <param name="customerRoleId">Customer role identifier</param>
        public void MarkCustomerRoleAsDeleted(int customerRoleId)
        {
            var customerRole = GetCustomerRoleById(customerRoleId);
            if (customerRole != null)
            {
                customerRole.Deleted = true;
                UpdateCustomerRole(customerRole);
            }
            var subCustomerRoles = GetCustomerRoleByParentCustomerRoleID(customerRoleId);
            if (subCustomerRoles.Count>0)
            {
                foreach (var subCustomerRole in subCustomerRoles)
                {
                    subCustomerRole.Deleted = true;
                    UpdateCustomerRole(subCustomerRole);
                }
            }

            if (this.CacheEnabled)
            {
                _cacheManager.RemoveByPattern(CUSTOMERROLES_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Gets a customer role
        /// </summary>
        /// <param name="customerRoleId">Customer role identifier</param>
        /// <returns>Customer role</returns>
        public CustomerRole GetCustomerRoleById(int customerRoleId)
        {
            if (customerRoleId == 0)
                return null;

            string key = string.Format(CUSTOMERROLES_BY_ID_KEY, customerRoleId);
            object obj2 = _cacheManager.Get(key);
            if (this.CacheEnabled && (obj2 != null))
            {
                return (CustomerRole)obj2;
            }


            var query = from cr in _context.CustomerRoles
                        where cr.CustomerRoleID == customerRoleId&&!cr.Deleted
                        select cr;
            var customerRole = query.SingleOrDefault();

            if (this.CacheEnabled)
            {
                _cacheManager.Add(key, customerRole);
            }
            return customerRole;
        }

        /// <summary>
        /// 获取该父节点下子节点中Code 最大的记录
        /// </summary>
        /// <param name="parentCustomerRoleID"></param>
        /// <returns></returns>
        public List<CustomerRole> GetCustomerRoleByParentCustomerRoleID(int parentCustomerRoleID)
        {
            var query = from cr in _context.CustomerRoles
                        where cr.ParentCustomerRoleID == parentCustomerRoleID && !cr.Deleted
                        orderby cr.CustomerRoleID 
                        select cr;
            return query.ToList();
        }

       /// <summary>
       /// 按条件获取角色记录
       /// </summary>
       /// <param name="parentCustomerRoleID"></param>
       /// <param name="name"></param>
       /// <returns></returns>
        public List<CustomerRole> GetCustomerRoleByCondition(int parentCustomerRoleID,string name)
        {
            var query = from cr in _context.CustomerRoles
                        where cr.ParentCustomerRoleID == parentCustomerRoleID && !cr.Deleted
                        && cr.Name.Equals(name)
                        orderby cr.CustomerRoleID
                        select cr;
            return query.ToList();
        }


        /// <summary>
        /// Gets all customer roles
        /// </summary>
        /// <returns>Customer role collection</returns>
        public List<CustomerRole> GetAllCustomerRoles()
        {
            bool showHidden = HozestERPContext.Current.IsAdmin;
            string key = string.Format(CUSTOMERROLES_ALL_KEY, showHidden);
            object obj2 = _cacheManager.Get(key);
            if (this.CacheEnabled && (obj2 != null))
            {
                return (List<CustomerRole>)obj2;
            }


            var query = from cr in _context.CustomerRoles
                        orderby cr.Name
                        where (showHidden || cr.Active) && !cr.Deleted
                        orderby cr.Code ascending
                        select cr;
            var customerRoles = query.ToList();

            if (this.CacheEnabled)
            {
                _cacheManager.Add(key, customerRoles);
            }
            return customerRoles;
        }

        /// <summary>
        /// Gets all customer roles
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>Customer role collection</returns>
        public PagedList<CustomerRole> GetAllCustomerRoles(string name, int pageIndex, int pageSize)
        {
            var customerRoles = from p in this._context.CustomerRoles
                                where p.Name.Contains(name) && !p.Deleted
                                orderby p.Code ascending
                                select p;
            return new PagedList<CustomerRole>(customerRoles, pageIndex, pageSize);
        }

        /// <summary>
        /// Gets customer roles by customer identifier
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>Customer role collection</returns>
        public List<CustomerRole> GetCustomerRolesByCustomerId(int customerId)
        {
            bool showHidden = HozestERPContext.Current.IsAdmin;
            return GetCustomerRolesByCustomerId(customerId, showHidden);
        }

        /// <summary>
        /// Gets customer roles by customer identifier
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Customer role collection</returns>
        public List<CustomerRole> GetCustomerRolesByCustomerId(int customerId, bool showHidden)
        {
            if (customerId == 0)
                return new List<CustomerRole>();

            var query = from cr in _context.CustomerRoles
                        from c in cr.SCustomers
                        where (showHidden || cr.Active) &&
                            !cr.Deleted &&
                            c.CustomerID == customerId
                        orderby cr.Name descending
                        select cr;

            var customerRoles = query.ToList();
            return customerRoles;
        }

        /// <summary>
        /// Gets CustomerInfo by customer identifier
        /// </summary>
        /// <param name="customerRoleId">Customer Role identifier</param>
        /// <returns>Customer role collection</returns>
        public List<CustomerInfo> GetCustomerInfosByCustomerRoleId(int customerRoleId)
        {
            if (customerRoleId == 0)
                return new List<CustomerInfo>();

            var query = from cr in _context.CustomerRoles
                        from c in cr.SCustomers
                        join cinfo in this._context.CustomerInfoes on c.CustomerID equals cinfo.CustomerID
                        where!cr.Deleted &&
                            cr.CustomerRoleID == customerRoleId
                        orderby cinfo.DisplayOrder descending
                        select cinfo;

            var customerRoles = query.ToList();
            return customerRoles;
        }

        public List<CustomerRole> GetRolesByCustomerId(int CustomerID)
        {
            if (CustomerID == 0)
                return new List<CustomerRole>();

            var query = from cr in _context.Customers
                        from c in cr.SCustomerRoles
                        where !cr.Deleted &&
                            cr.CustomerID == CustomerID
                        select c;
            return query.ToList();
        }

        public List<CustomerInfo> GetCustomerInfosByRoleID(int RoleId)
        {
            if (RoleId == 0)
                return new List<CustomerInfo>();

            var query = from cr in _context.CustomerRoles
                        from c in cr.SCustomerRoleStaffPrivileges
                        join cinfo in this._context.CustomerInfoes on c.CustomerID equals cinfo.CustomerID
                        where !cr.Deleted &&
                            cr.CustomerRoleID == RoleId
                        select cinfo;
            return query.ToList();
        }

        /// <summary>
        /// Gets Department by customer Role Id
        /// </summary>
        /// <param name="customerRoleId">customer Role Id</param>
        /// <returns>Customer role collection</returns>
        public List<Department> GetDepartmentByCustomerRoleId(int customerRoleId)
        {
            if (customerRoleId == 0)
                return new List<Department>();
            var query = from cr in _context.CustomerRoles
                        from d in cr.SDepartments
                        join depar in this._context.Departments on d.DepartmentID equals depar.DepartmentID
                        where !cr.Deleted &&
                            cr.CustomerRoleID == customerRoleId
                        orderby depar.DisplayOrder descending
                        select depar;
            var customerRoles = query.ToList();
            return customerRoles;
        }

        /// <summary>
        /// Inserts a customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        public void InsertCustomerRole(CustomerRole customerRole)
        {
            if (customerRole == null)
                throw new ArgumentNullException("customerRole");

            customerRole.Name = CommonHelper.EnsureNotNull(customerRole.Name);
            customerRole.Name = CommonHelper.EnsureMaximumLength(customerRole.Name, 255);



            _context.CustomerRoles.AddObject(customerRole);
            _context.SaveChanges();

            if (this.CacheEnabled)
            {
                _cacheManager.RemoveByPattern(CUSTOMERROLES_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Inserts a customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        public void DeleteCustomerRole(int customerRoleID)
        {
            if (customerRoleID == 0)
                return;
            CustomerRole bean = GetCustomerRoleById(customerRoleID);

            if (!_context.IsAttached(bean))
                _context.CustomerRoles.Attach(bean);

            _context.CustomerRoles.DeleteObject(bean);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        public void UpdateCustomerRole(CustomerRole customerRole)
        {
            if (customerRole == null)
                throw new ArgumentNullException("customerRole");

            customerRole.Name = CommonHelper.EnsureNotNull(customerRole.Name);
            customerRole.Name = CommonHelper.EnsureMaximumLength(customerRole.Name, 255);


            if (!_context.IsAttached(customerRole))
                _context.CustomerRoles.Attach(customerRole);

            _context.SaveChanges();

            if (this.CacheEnabled)
            {
                _cacheManager.RemoveByPattern(CUSTOMERROLES_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Adds a customer to role
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="customerRoleId">Customer role identifier</param>
        public void AddCustomerToRole(int customerId, int customerRoleId)
        {
            var customer = GetCustomerById(customerId);
            if (customer == null)
                return;

            var customerRole = GetCustomerRoleById(customerRoleId);
            if (customerRole == null)
                return;


            if (!_context.IsAttached(customer))
                _context.Customers.Attach(customer);
            if (!_context.IsAttached(customerRole))
                _context.CustomerRoles.Attach(customerRole);

            //ensure that navigation property is loaded
            if (customer.SCustomerRoles == null)
                _context.LoadProperty(customer, c => c.SCustomerRoles);

            customer.SCustomerRoles.Add(customerRole);

            _context.SaveChanges();
        }

        /// <summary>
        /// Adds a department to role
        /// </summary>
        /// <param name="customerId">department identifier</param>
        /// <param name="customerRoleId">Customer role identifier</param>
        public void AddDepartmentToRole(int departmentId, int customerRoleId)
        {
            var department = GetDepartmentById(departmentId);
            if (department == null)
                return;

            var customerRole = GetCustomerRoleById(customerRoleId);
            if (customerRole == null)
                return;


            if (!_context.IsAttached(department))
                _context.Departments.Attach(department);
            if (!_context.IsAttached(customerRole))
                _context.CustomerRoles.Attach(customerRole);

            //ensure that navigation property is loaded
            if (department.SCustomerRoles == null)
                _context.LoadProperty(department, c => c.SCustomerRoles);

            department.SCustomerRoles.Add(customerRole);

            _context.SaveChanges();
        }

        /// <summary>
        /// Removes a customer from role
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="customerRoleId">Customer role identifier</param>
        public void RemoveCustomerFromRole(int customerId, int customerRoleId)
        {
            var customer = GetCustomerById(customerId);
            if (customer == null)
                return;

            var customerRole = GetCustomerRoleById(customerRoleId);
            if (customerRole == null)
                return;


            if (!_context.IsAttached(customer))
                _context.Customers.Attach(customer);
            if (!_context.IsAttached(customerRole))
                _context.CustomerRoles.Attach(customerRole);

            //ensure that navigation property is loaded
            if (customer.SCustomerRoles == null)
                _context.LoadProperty(customer, c => c.SCustomerRoles);

            customer.SCustomerRoles.Remove(customerRole);
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes a department from role
        /// </summary>
        /// <param name="customerId">department identifier</param>
        /// <param name="customerRoleId">Customer role identifier</param>
        public void RemoveDepartmentFromRole(int departmentId, int customerRoleId)
        {
            var department = GetDepartmentById(departmentId);
            if (department == null)
                return;

            var customerRole = GetCustomerRoleById(customerRoleId);
            if (customerRole == null)
                return;


            if (!_context.IsAttached(department))
                _context.Departments.Attach(department);
            if (!_context.IsAttached(customerRole))
                _context.CustomerRoles.Attach(customerRole);

            //ensure that navigation property is loaded
            if (department.SCustomerRoles == null)
                _context.LoadProperty(department, c => c.SCustomerRoles);

            department.SCustomerRoles.Remove(customerRole);
            _context.SaveChanges();
        }

        #endregion

        #region Cutomer Role StaffPrivileges

        /// <summary>
        /// Adds a customer to role StaffPrivileges
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="customerRoleId">Customer role identifier</param>
        public void AddCustomerToRoleStaffPrivileges(int customerId, int customerRoleId)
        {
            var customer = GetCustomerById(customerId);
            if (customer == null)
                return;

            var customerRole = GetCustomerRoleById(customerRoleId);
            if (customerRole == null)
                return;


            if (!_context.IsAttached(customer))
                _context.Customers.Attach(customer);
            if (!_context.IsAttached(customerRole))
                _context.CustomerRoles.Attach(customerRole);

            //ensure that navigation property is loaded
            if (customer.SCustomerRoles == null)
                _context.LoadProperty(customer, c => c.SCustomerRoles);

            customer.SStaffPrivilegesCustomerRole.Add(customerRole);

            _context.SaveChanges();
        }

        /// <summary>
        /// Removes a customer from role StaffPrivileges
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="customerRoleId">Customer role identifier</param>
        public void RemoveCustomerFromRoleStaffPrivileges(int customerId, int customerRoleId)
        {
            var customer = GetCustomerById(customerId);
            if (customer == null)
                return;

            var customerRole = GetCustomerRoleById(customerRoleId);
            if (customerRole == null)
                return;


            if (!_context.IsAttached(customer))
                _context.Customers.Attach(customer);
            if (!_context.IsAttached(customerRole))
                _context.CustomerRoles.Attach(customerRole);

            //ensure that navigation property is loaded
            if (customer.SCustomerRoles == null)
                _context.LoadProperty(customer, c => c.SCustomerRoles);

            customer.SStaffPrivilegesCustomerRole.Remove(customerRole);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets CustomerInfo by CustomerRole identifier
        /// </summary>
        /// <param name="customerRoleId">Customer Role identifier</param>
        /// <returns>Customer role collection</returns>
        public List<CustomerInfo> GetCustomerRoleStaffPrivilegesByCustomerId(int customerRoleId)
        {
            if (customerRoleId == 0)
                return new List<CustomerInfo>();

            var query = from cr in _context.CustomerRoles
                        from c in cr.SCustomerRoleStaffPrivileges
                        join cInfo in this._context.CustomerInfoes on c.CustomerID equals cInfo.CustomerID
                        where !cr.Deleted &&
                            cr.CustomerRoleID == customerRoleId
                        orderby cInfo.FullName descending
                        select cInfo;

            var customers = query.ToList();
            return customers;
        }
        #endregion

        #region Customer attributes

        /// <summary>
        /// Deletes a customer attribute
        /// </summary>
        /// <param name="customerAttributeId">Customer attribute identifier</param>
        public void DeleteCustomerAttribute(int customerAttributeId)
        {
            var customerAttribute = GetCustomerAttributeById(customerAttributeId);
            if (customerAttribute == null)
                return;


            if (!_context.IsAttached(customerAttribute))
                _context.CustomerAttributes.Attach(customerAttribute);
            _context.DeleteObject(customerAttribute);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets a customer attribute
        /// </summary>
        /// <param name="customerAttributeId">Customer attribute identifier</param>
        /// <returns>A customer attribute</returns>
        public CustomerAttribute GetCustomerAttributeById(int customerAttributeId)
        {
            if (customerAttributeId == 0)
                return null;


            var query = from ca in _context.CustomerAttributes
                        where ca.CustomerAttributeId == customerAttributeId
                        select ca;
            var customerAttribute = query.SingleOrDefault();

            return customerAttribute;
        }

        /// <summary>
        /// Gets a collection of customer attributes by customer identifier
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>Customer attributes</returns>
        public List<CustomerAttribute> GetCustomerAttributesByCustomerId(int customerId)
        {

            var query = from ca in _context.CustomerAttributes
                        where ca.CustomerId == customerId
                        select ca;
            var customerAttributes = query.ToList();
            return customerAttributes;
        }

        /// <summary>
        /// Inserts a customer attribute
        /// </summary>
        /// <param name="customerAttribute">Customer attribute</param>
        public void InsertCustomerAttribute(CustomerAttribute customerAttribute)
        {
            if (customerAttribute == null)
                throw new ArgumentNullException("customerAttribute");

            if (customerAttribute.CustomerId == 0)
                throw new CRMException("Cannot insert attribute for non existing customer");

            if (customerAttribute.Value == null)
                customerAttribute.Value = string.Empty;

            customerAttribute.Key = CommonHelper.EnsureNotNull(customerAttribute.Key);
            customerAttribute.Key = CommonHelper.EnsureMaximumLength(customerAttribute.Key, 100);
            customerAttribute.Value = CommonHelper.EnsureNotNull(customerAttribute.Value);
            customerAttribute.Value = CommonHelper.EnsureMaximumLength(customerAttribute.Value, 1000);



            _context.CustomerAttributes.AddObject(customerAttribute);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the customer attribute
        /// </summary>
        /// <param name="customerAttribute">Customer attribute</param>
        public void UpdateCustomerAttribute(CustomerAttribute customerAttribute)
        {
            if (customerAttribute == null)
                throw new ArgumentNullException("customerAttribute");

            if (customerAttribute.CustomerId == 0)
                throw new CRMException("Cannot insert attribute for non existing customer");

            customerAttribute.Key = CommonHelper.EnsureNotNull(customerAttribute.Key);
            customerAttribute.Key = CommonHelper.EnsureMaximumLength(customerAttribute.Key, 100);
            customerAttribute.Value = CommonHelper.EnsureNotNull(customerAttribute.Value);
            customerAttribute.Value = CommonHelper.EnsureMaximumLength(customerAttribute.Value, 1000);


            if (!_context.IsAttached(customerAttribute))
                _context.CustomerAttributes.Attach(customerAttribute);

            _context.SaveChanges();
        }

        #endregion

        /// <summary>
        /// Reset data required for checkout
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="clearCouponCodes">A value indicating whether to clear coupon code</param>
        public void ResetCheckoutData(int customerId, bool clearCouponCodes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets a customer email
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="newEmail">New email</param>
        /// <returns>Customer</returns>
        public Customer SetEmail(int customerId, string newEmail)
        {
            if (newEmail == null)
                newEmail = string.Empty;
            newEmail = newEmail.Trim();

            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                if (!CommonHelper.IsValidEmail(newEmail))
                {
                    throw new CRMException("New email is not valid");
                }

                if (customer.IsGuest)
                {
                    throw new CRMException("You cannot change email for guest customer");
                }

                var cust2 = GetCustomerByEmail(newEmail);
                if (cust2 != null && customer.CustomerID != cust2.CustomerID)
                {
                    throw new CRMException("The e-mail address is already in use.");
                }

                if (newEmail.Length > 100)
                {
                    throw new CRMException("E-mail address is too long.");
                }

                customer.Email = newEmail;
                UpdateCustomer(customer);
            }
            return customer;
        }

        /// <summary>
        /// Sets a customer username
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="newUsername">New Username</param>
        /// <returns>Customer</returns>
        public Customer ChangeCustomerUsername(int customerId, string newUsername)
        {
            if (!this.UsernamesEnabled)
                throw new CRMException("Usernames are disabled");

            if (!this.AllowCustomersToChangeUsernames)
                throw new CRMException("Changing usernames is not allowed");

            if (newUsername == null)
                newUsername = string.Empty;
            newUsername = newUsername.Trim();

            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                if (customer.IsGuest)
                {
                    throw new CRMException("You cannot change username for guest customer");
                }

                var cust2 = GetCustomerByUsername(newUsername);
                if (cust2 != null && customer.CustomerID != cust2.CustomerID)
                {
                    throw new CRMException("This username is already in use.");
                }

                if (newUsername.Length > 100)
                {
                    throw new CRMException("Username is too long.");
                }

                customer.Username = newUsername;
                UpdateCustomer(customer);
            }
            return customer;
        }
        /// <summary>
        /// Gets a DepartMent
        /// </summary>
        /// <param name="customerId">Department identifier</param>
        /// <returns>A Department</returns>
        public Department GetDepartmentByCustomerID(int customerID)
        {
            if (customerID == 0)
                return null;
            var query = from cr in _context.Departments
                        join cu in _context.CustomerInfoes on cr.DepartmentID equals cu.DepartmentID 
                        where cu.CustomerID == customerID && !cr.Deleted 
                        select cr;
            var department = query.SingleOrDefault();
            return department; 


         }
     
        /// <summary>
        /// Sets a customer sugnature
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="signature">Signature</param>
        /// <returns>Customer</returns>
        public Customer SetCustomerSignature(int customerId, string signature)
        {
            if (signature == null)
                signature = string.Empty;
            signature = signature.Trim();

            int maxLength = 300;
            if (signature.Length > maxLength)
                signature = signature.Substring(0, maxLength);

            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                customer.Signature = signature;
                UpdateCustomer(customer);
            }
            return customer;
        }

        /// <summary>
        /// Create anonymous user for current user
        /// </summary>
        /// <returns>Guest user</returns>
        public void CreateAnonymousUser()
        {
            //create anonymous record
            string email = "anonymous@anonymous.com";
            string password = string.Empty;
            MembershipCreateStatus status = MembershipCreateStatus.UserRejected;
            var guestCustomer = AddCustomer(email, email, password, false, true, true, out status);
            if (guestCustomer != null && status == MembershipCreateStatus.Success)
            {
                HozestERPContext.Current.User = guestCustomer;

                if (HozestERPContext.Current.Session == null)
                {
                    HozestERPContext.Current.Session = HozestERPContext.Current.GetSession(true);
                }

                DateTime lastAccessed = DateTime.UtcNow;

                var customerSession = HozestERPContext.Current.Session;
                customerSession.CustomerID = guestCustomer.CustomerID;
                customerSession.LastAccessed = lastAccessed;
                UpdateCustomerSession(customerSession);
                HozestERPContext.Current.Session = customerSession;
            }
        }

        /// <summary>
        /// Updates the customer session
        /// </summary>
        /// <param name="customerSession">Customer session</param>
        protected void UpdateCustomerSession(CustomerSession customerSession)
        {
            if (customerSession == null)
                throw new ArgumentNullException("customerSession");


            if (!_context.IsAttached(customerSession))
                _context.CustomerSessions.Attach(customerSession);

            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>Customer collection</returns>
        public Common.PagedList<Customer> GetAllCustomers()
        {
            return GetAllCustomers(null, null, null, string.Empty, false,
                int.MaxValue, 0);
        }

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
        public Common.PagedList<Customer> GetAllCustomers(DateTime? registrationFrom, DateTime? registrationTo, string email, string username, bool dontLoadGuestCustomers, int pageSize, int pageIndex)
        {
            return GetAllCustomers(registrationFrom, registrationTo,
                email, username, dontLoadGuestCustomers, 0, 0,
                pageSize, pageIndex);
        }

         /// <summary>
        /// Gets all customers
        /// </summary>
        /// <param name="email">Customer Email</param>
        /// <param name="username">Customer username</param>
        /// <param name="active">Customer Active</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <returns>Customer collection</returns>
        public PagedList<Customer> GetAllCustomers(string email, string username, bool active, int pageSize, int pageIndex)
        {
            if (email == null)
                email = string.Empty;

            if (username == null)
                username = string.Empty;

            var query = from c in _context.Customers
                        where (String.IsNullOrEmpty(email) || c.Email.Contains(email)) &&
                        (String.IsNullOrEmpty(username) || c.Username.Contains(username)) &&
                        (!active || !c.Active) &&
                        (!c.Deleted)
                        orderby c.RegistrationDate descending
                        select c;

            var customers = new PagedList<Customer>(query, pageIndex, pageSize);

            return customers;
        }

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
        public Common.PagedList<Customer> GetAllCustomers(DateTime? registrationFrom, DateTime? registrationTo, string email, string username, bool dontLoadGuestCustomers, int dateOfBirthMonth, int dateOfBirthDay, int pageSize, int pageIndex)
        {
            if (email == null)
                email = string.Empty;

            if (username == null)
                username = string.Empty;

            var query = from c in _context.Customers
                        where
                        (!registrationFrom.HasValue || registrationFrom.Value <= c.RegistrationDate) &&
                        (!registrationTo.HasValue || registrationTo.Value >= c.RegistrationDate) &&
                        (String.IsNullOrEmpty(email) || c.Email.Contains(email)) &&
                        (String.IsNullOrEmpty(username) || c.Username.Contains(username)) &&
                        (!dontLoadGuestCustomers || !c.IsGuest) &&
                        (dateOfBirthMonth == 0 || (c.DateOfBirth.HasValue && c.DateOfBirth.Value.Month == dateOfBirthMonth)) &&
                        (dateOfBirthDay == 0 || (c.DateOfBirth.HasValue && c.DateOfBirth.Value.Day == dateOfBirthDay)) &&
                        (!c.Deleted)
                        orderby c.RegistrationDate descending
                        select c;
            var customers = new PagedList<Customer>(query, pageIndex, pageSize);

            return customers;
        }

        /// <summary>
        /// Gets all customers by customer role id
        /// </summary>
        /// <param name="customerRoleId">Customer role identifier</param>
        /// <returns>Customer collection</returns>
        public List<Customer> GetCustomersByCustomerRoleId(int customerRoleId)
        {
            bool showHidden = HozestERPContext.Current.IsAdmin;


            var query = from c in _context.Customers
                        from cr in c.SCustomerRoles
                        where (showHidden || c.Active) &&
                            !c.Deleted &&
                            cr.CustomerRoleID == customerRoleId&&!cr.Deleted
                        orderby c.RegistrationDate descending
                        select c;

            //var query = from c in _context.Customers
            //            where (showHidden || c.Active) && !c.Deleted
            //            && c.SCustomerRoles.Any(cr => cr.CustomerRoleId == customerRoleId)
            //            orderby c.RegistrationDate descending
            //            select c;


            //var query = _context.CustomerRoles.Where(cr => cr.CustomerRoleId == customerRoleId)
            //    .SelectMany(cr => cr.SCustomers);
            //if (!showHidden)
            //    query = query.Where(c => c.Active);
            //query = query.Where(c => !c.Deleted);
            //query = query.OrderByDescending(c => c.RegistrationDate);
            //var customers = query.ToList();

            var customers = query.ToList();
            return customers;
        }

        /// <summary>
        /// Marks customer as deleted
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        public void MarkCustomerAsDeleted(int customerId)
        {
            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                customer.Deleted = true;
                UpdateCustomer(customer);
            }
        }

        /// <summary>
        /// Gets a customer by email
        /// </summary>
        /// <param name="email">Customer Email</param>
        /// <returns>A customer</returns>
        public Customer GetCustomerByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;


            var query = from c in _context.Customers
                        orderby c.CustomerID
                        where c.Email == email&&!c.Deleted
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }


        /// <summary>
        /// Gets a customer by Username
        /// </summary>
        /// <param name="username">Customer username</param>
        /// <returns>A customer</returns>
        public List<Customer> GetCustomerByUsernameList(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;


            var query = from c in _context.Customers
                        orderby c.CustomerID
                        where c.Username == username && !c.Deleted
                        select c;
            var customer = query.ToList();

            return customer;
        }

        /// <summary>
        /// Gets a customer by Username
        /// </summary>
        /// <param name="username">Customer username</param>
        /// <returns>A customer</returns>
        public Customer GetCustomerByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;


            var query = from c in _context.Customers
                        orderby c.CustomerID
                        where c.Username == username &&!c.Deleted
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }

        /// <summary>
        /// Gets customers by Username
        /// </summary>
        /// <param name="username">Customer username</param>
        /// <returns>A customer</returns>
        public List<Customer> GetCustomerByLikeUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return GetAllCustomers();


            var query = from c in _context.Customers
                        orderby c.CustomerID
                        where c.Username.Contains(username)&&!c.Deleted
                        select c;

            var customer = query.ToList();
            return customer;
        }

        /// <summary>
        /// Gets customers by email
        /// </summary>
        /// <param name="email">Customer Email</param>
        /// <returns>A customer</returns>
        public List<Customer> GetCustomerByLikeEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return GetAllCustomers();


            var query = from c in _context.Customers
                        orderby c.CustomerID
                        where c.Email.Contains(email)&&!c.Deleted
                        select c;

            var customer = query.ToList();
            return customer;
        }

        /// <summary>
        /// Gets a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>A customer</returns>
        public Customer GetCustomerById(int customerId)
        {
            if (customerId == 0)
                return null;


            var query = from c in _context.Customers
                        where c.CustomerID == customerId&&!c.Deleted
                        select c;
            var customer = query.SingleOrDefault();
            return customer;
        }




        /// <summary>
        /// delete 人事基本信息 by Id
        /// </summary>
        /// <param name="Id"> Id</param>
        public void DeleteCustomer(int id)
        {
            var custome = this.GetCustomerById(id);
            if (custome == null)
                return;

            // 管理员数据不可删除
            if (id != 7)
            {
                if (!this._context.IsAttached(custome))
                    this._context.Customers.Attach(custome);
                this._context.DeleteObject(custome);
                this._context.SaveChanges();
            }
        }

        /// <summary>
        /// Batch delete CustomerInfoes by CustomerID
        /// </summary>
        /// <param name="Ids">CustomerInfoes CustomerID</param>
        public void BatchDeleteCustomer(List<int> ids)
        {
            var query = from q in _context.Customers
                        where ids.Contains(q.CustomerID)
                        select q;
            var customers = query.ToList();
            foreach (var item in customers)
            {
                // 管理员数据不可删除
                if (item.CustomerID != 7)
                {
                    if (!_context.IsAttached(item))
                        _context.Customers.Attach(item);
                    _context.Customers.DeleteObject(item);
                }
            }
            _context.SaveChanges();
        }
         
        /// <summary>
        /// 清空数据
        /// </summary>
        public int DeleteDataEmptyCustomer()
        {
            // 管理员数据不可删除
            string strSql = "delete from dbo.Sys_Customer  where  CustomerID<>7 ";
            strSql = string.Format(strSql);
            return SqlDataHelper.ExcuteBySql(strSql);

        } 


        /// <summary>
        /// Gets a department
        /// </summary>
        /// <param name="departmentId">Department identifier</param>
        /// <returns>A Department</returns>
        public Department GetDepartmentById(int departmentId)
        {
            if (departmentId == 0)
                return null;


            var query = from c in _context.Departments
                        where c.DepartmentID == departmentId && !c.Deleted
                        select c;
            var department = query.SingleOrDefault();
            return department;
        }

        /// <summary>
        /// Gets a customer by GUID
        /// </summary>
        /// <param name="customerGuid">Customer GUID</param>
        /// <returns>A customer</returns>
        public Customer GetCustomerByGuid(Guid customerGuid)
        {
            if (customerGuid == Guid.Empty)
                return null;


            var query = from c in _context.Customers
                        where c.CustomerGUID == customerGuid&&!c.Deleted
                        orderby c.CustomerID
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }

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
        public Customer AddCustomer(string email, string username, string password, bool isAdmin, bool isGuest, bool active, out System.Web.Security.MembershipCreateStatus status)
        {
            var customer = AddCustomer(Guid.NewGuid(), email, username, password, isAdmin, isGuest, string.Empty, string.Empty, active,
                false, DateTime.UtcNow, string.Empty, 0, null, out status);

            

            return customer;
        }

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
        public Customer AddCustomer(Guid customerGuid, string email, string username, string password
            , bool isAdmin, bool isGuest, string signature, string adminComment
            , bool active, bool deleted, DateTime registrationDate, string timeZoneId, int avatarId
            , DateTime? dateOfBirth, out System.Web.Security.MembershipCreateStatus status)
        {
            Customer customer = null;

            if (username == null)
                username = string.Empty;
            username = username.Trim();

            if (email == null)
                email = string.Empty;
            email = email.Trim();

            if (signature == null)
                signature = string.Empty;
            signature = signature.Trim();

            string saltKey = string.Empty;
            string passwordHash = string.Empty;

            status = MembershipCreateStatus.UserRejected;
            if (!isGuest)
            {
                if (!HozestERPContext.Current.IsAdmin)
                {
                    if (this.CustomerRegistrationType == CustomerRegistrationTypeEnum.Disabled)
                    {
                        status = MembershipCreateStatus.ProviderError;
                        return customer;
                    }
                }

                if (this.UsernamesEnabled)
                {
                    if (GetCustomerByUsername(username) != null)
                    {
                        status = MembershipCreateStatus.DuplicateUserName;
                        return customer;
                    }

                    if (username.Length > 100)
                    {
                        status = MembershipCreateStatus.InvalidUserName;
                        return customer;
                    }
                }

                if (GetCustomerByEmail(email) != null)
                {
                    status = MembershipCreateStatus.DuplicateEmail;
                    return customer;
                }

                //if (!CommonHelper.IsValidEmail(email))
                //{
                //    status = MembershipCreateStatus.InvalidEmail;
                //    return customer;
                //}

                if (email.Length > 100)
                {
                    status = MembershipCreateStatus.InvalidEmail;
                    return customer;
                }

                if (!HozestERPContext.Current.IsAdmin)
                {
                    if (this.CustomerRegistrationType == CustomerRegistrationTypeEnum.EmailValidation ||
                        this.CustomerRegistrationType == CustomerRegistrationTypeEnum.AdminApproval)
                    {
                        active = false;
                    }
                }
                saltKey = CreateSalt(5);
                passwordHash = CreatePasswordHash(password, saltKey);
            }

            customer = AddCustomerForced(customerGuid, email, username,
                passwordHash, saltKey,isAdmin, isGuest, signature, adminComment, active,
                deleted, registrationDate, timeZoneId, avatarId, dateOfBirth);

            if (!isGuest)
            {
                DateTime lastAccessed = DateTime.UtcNow;
                SaveCustomerSession(Guid.NewGuid(), customer.CustomerID, lastAccessed, false);
            }

            status = MembershipCreateStatus.Success;

            return customer;
        }

        /// <summary>
        /// Creates a password hash
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="salt">Salt</param>
        /// <returns>Password hash</returns>
        private string CreatePasswordHash(string password, string salt)
        {
            //MD5, SHA1
            string passwordFormat = IoC.Resolve<ISettingManager>().GetSettingValue("Security.PasswordFormat");
            if (String.IsNullOrEmpty(passwordFormat))
                passwordFormat = "SHA1";

            return FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, passwordFormat);
        }  
        /// <summary>
        /// Creates a salt
        /// </summary>
        /// <param name="size">A salt size</param>
        /// <returns>A salt</returns>
        private string CreateSalt(int size)
        {
            var provider = new RNGCryptoServiceProvider();
            byte[] data = new byte[size];
            provider.GetBytes(data);
            return Convert.ToBase64String(data);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string PublicPasswordHash(string password, string salt)
        {
            //MD5, SHA1
            string passwordFormat = IoC.Resolve<ISettingManager>().GetSettingValue("Security.PasswordFormat");
            if (String.IsNullOrEmpty(passwordFormat))
                passwordFormat = "SHA1";

            return FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, passwordFormat);
        }
         
        /// <summary>
        /// Public a salt
        /// </summary>
        /// <param name="size">A salt size</param>
        /// <returns>A salt</returns>
        public string PublicSalt(int size)
        {
            var provider = new RNGCryptoServiceProvider();
            byte[] data = new byte[size];
            provider.GetBytes(data);
            return Convert.ToBase64String(data);
        }


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
        public Customer AddCustomerForced(Guid customerGuid, string email, string username, string passwordHash
            , string saltKey, bool isAdmin, bool isGuest
            , string signature, string adminComment, bool active, bool deleted, DateTime registrationDate, string timeZoneId
            , int avatarId, DateTime? dateOfBirth)
        {
            email = CommonHelper.EnsureNotNull(email);
            email = email.Trim();
            email = CommonHelper.EnsureMaximumLength(email, 255);
            username = CommonHelper.EnsureNotNull(username);
            username = username.Trim();
            username = CommonHelper.EnsureMaximumLength(username, 100);
            passwordHash = CommonHelper.EnsureNotNull(passwordHash);
            passwordHash = CommonHelper.EnsureMaximumLength(passwordHash, 255);
            saltKey = CommonHelper.EnsureNotNull(saltKey);
            saltKey = CommonHelper.EnsureMaximumLength(saltKey, 255);
            signature = CommonHelper.EnsureNotNull(signature);
            signature = CommonHelper.EnsureMaximumLength(signature, 300);
            adminComment = CommonHelper.EnsureNotNull(adminComment);
            adminComment = CommonHelper.EnsureMaximumLength(adminComment, 4000);
            timeZoneId = CommonHelper.EnsureNotNull(timeZoneId);
            timeZoneId = CommonHelper.EnsureMaximumLength(timeZoneId, 200);



            var customer = _context.Customers.CreateObject();
            customer.CustomerGUID = customerGuid;
            customer.Email = email;
            customer.Username = username;
            customer.PasswordHash = passwordHash;
            customer.SaltKey = saltKey;
            customer.IsAdmin = isAdmin;
            customer.IsGuest = isGuest;
            customer.Signature = signature;
            customer.AdminComment = adminComment;
            customer.Active = active;
            customer.Deleted = deleted;
            customer.RegistrationDate = registrationDate;
            customer.TimeZoneID = timeZoneId;
            customer.AvatarID = avatarId;
            customer.DateOfBirth = dateOfBirth;

            _context.Customers.AddObject(customer);
            _context.SaveChanges();

      

            //raise event             
            EventContext.Current.OnCustomerCreated(null,
                new CustomerEventArgs() { Customer = customer });

            return customer;
        }

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            customer.Email = CommonHelper.EnsureNotNull(customer.Email);
            customer.Email = customer.Email.Trim();
            customer.Email = CommonHelper.EnsureMaximumLength(customer.Email, 255);
            customer.Username = CommonHelper.EnsureNotNull(customer.Username);
            customer.Username = customer.Username.Trim();
            customer.Username = CommonHelper.EnsureMaximumLength(customer.Username, 100);
            customer.PasswordHash = CommonHelper.EnsureNotNull(customer.PasswordHash);
            customer.PasswordHash = CommonHelper.EnsureMaximumLength(customer.PasswordHash, 255);
            customer.SaltKey = CommonHelper.EnsureNotNull(customer.SaltKey);
            customer.SaltKey = CommonHelper.EnsureMaximumLength(customer.SaltKey, 255);
            customer.Signature = CommonHelper.EnsureNotNull(customer.Signature);
            customer.Signature = customer.Signature.Trim();
            customer.Signature = CommonHelper.EnsureMaximumLength(customer.Signature, 300);
            customer.AdminComment = CommonHelper.EnsureNotNull(customer.AdminComment);
            customer.AdminComment = CommonHelper.EnsureMaximumLength(customer.AdminComment, 4000);
            customer.TimeZoneID = CommonHelper.EnsureNotNull(customer.TimeZoneID);
            customer.TimeZoneID = CommonHelper.EnsureMaximumLength(customer.TimeZoneID, 200);



            if (!_context.IsAttached(customer))
                _context.Customers.Attach(customer);
            _context.SaveChanges();


            //raise event             
            EventContext.Current.OnCustomerUpdated(null,
                new CustomerEventArgs() { Customer = customer });
        }

        /// <summary>
        /// Modifies password
        /// </summary>
        /// <param name="email">Customer email</param>
        /// <param name="oldPassword">Old password</param>
        /// <param name="password">Password</param>
        public void ModifyPassword(string email, string oldPassword, string password)
        {
            var customer = GetCustomerByEmail(email);
            if (customer != null)
            {
                string oldPasswordHash = CreatePasswordHash(oldPassword, customer.SaltKey);
                if (!customer.PasswordHash.Equals(oldPasswordHash))
                    throw new CRMException("原密码不匹配");

                ModifyPassword(customer.CustomerID, password);
            }
        }

        /// <summary>
        /// Modifies password
        /// </summary>
        /// <param name="email">Customer email</param>
        /// <param name="newPassword">New password</param>
        public void ModifyPassword(string email, string newPassword)
        {
            var customer = GetCustomerByEmail(email);
            if (customer != null)
            {
                ModifyPassword(customer.CustomerID, newPassword);
            }
        }

        /// <summary>
        /// Modifies password
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="newPassword">New password</param>
        public string  ModifyPassword(int customerId,string oldPassword,string newPassword)
        {
            string msg="";
            if (String.IsNullOrWhiteSpace(newPassword))
               msg = "新密码不能为空";
            newPassword = newPassword.Trim();

            if (String.IsNullOrWhiteSpace(oldPassword))
               msg = "当前密码不能为空";
            oldPassword = oldPassword.Trim();

            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                string oldPasswordHash = CreatePasswordHash(oldPassword, customer.SaltKey);
                if (!customer.PasswordHash.Equals(oldPasswordHash))
                {
                    msg = "当前密码输入错误";
                }
                else
                {
                    string newPasswordSalt = CreateSalt(5);
                    string newPasswordHash = CreatePasswordHash(newPassword, newPasswordSalt);

                    customer.PasswordHash = newPasswordHash;
                    customer.SaltKey = newPasswordSalt;
                    UpdateCustomer(customer);
                    msg = "密码更改成功!";
                }
            }
            return msg;
        }

        /// <summary>
        /// Modifies password
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="newPassword">New password</param>
        public void ModifyPassword(int customerId, string newPassword)
        {
            if (String.IsNullOrWhiteSpace(newPassword))
                throw new CRMException("密码不能为空");
            newPassword = newPassword.Trim();

            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                string newPasswordSalt = CreateSalt(5);
                string newPasswordHash = CreatePasswordHash(newPassword, newPasswordSalt);

                customer.PasswordHash = newPasswordHash;
                customer.SaltKey = newPasswordSalt;
                UpdateCustomer(customer);
            }
        }

        /// <summary>
        /// Activates a customer
        /// </summary>
        /// <param name="customerGuid">Customer identifier</param>
        public void Activate(Guid customerGuid)
        {
            var customer = GetCustomerByGuid(customerGuid);
            if (customer != null)
            {
                Activate(customer.CustomerID);
            }
        }

        /// <summary>
        /// Activates a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        public void Activate(int customerId)
        {
            Activate(customerId, false);
        }

        /// <summary>
        /// Activates a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="sendCustomerWelcomeMessage">A value indivating whether to send customer welcome message</param>
        public void Activate(int customerId, bool sendCustomerWelcomeMessage)
        {
            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                customer.Active = true;
                UpdateCustomer(customer);
            }
        }

        /// <summary>
        /// Deactivates a customer
        /// </summary>
        /// <param name="customerGuid">Customer identifier</param>
        public void Deactivate(Guid customerGuid)
        {
            var customer = GetCustomerByGuid(customerGuid);
            if (customer != null)
            {
                Deactivate(customer.CustomerID);
            }
        }

        /// <summary>
        /// Deactivates a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        public void Deactivate(int customerId)
        {
            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                customer.Active = false;
                UpdateCustomer(customer);
            }
        }

        /// <summary>
        /// Login a customer
        /// </summary>
        /// <param name="userName">A customer userName</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        public bool Login(string userName, string password)
        {
            if (userName == null)
                userName = string.Empty;
            userName = userName.Trim();

            var customer = GetCustomerByUsername(userName);

            if (customer == null)
                return false;

            if (!customer.Active)
                return false;

            if (customer.Deleted)
                return false;

            if (customer.IsGuest)
                return false;

            string passwordHash = CreatePasswordHash(password, customer.SaltKey);
            bool result = customer.PasswordHash.Equals(passwordHash);
            if (result)
            {
                var registeredCustomerSession = GetCustomerSessionByCustomerId(customer.CustomerID);
          
                if (HozestERPContext.Current.Session == null)
                    HozestERPContext.Current.Session = HozestERPContext.Current.GetSession(true);
                HozestERPContext.Current.Session.IsExpired = false;
                HozestERPContext.Current.Session.LastAccessed = DateTime.UtcNow;
                HozestERPContext.Current.Session.CustomerID = customer.CustomerID;
                HozestERPContext.Current.Session = SaveCustomerSession(HozestERPContext.Current.Session.CustomerSessionGUID, HozestERPContext.Current.Session.CustomerID, HozestERPContext.Current.Session.LastAccessed, HozestERPContext.Current.Session.IsExpired);
            }
            return result;
        }

        /// <summary>
        /// Logout customer
        /// </summary>
        public void Logout()
        {
            if (HozestERPContext.Current != null)
            {
                HozestERPContext.Current.ResetSession();
            }

            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session.Abandon();
            }
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// Gets a customer session
        /// </summary>
        /// <param name="customerSessionGuid">Customer session GUID</param>
        /// <returns>Customer session</returns>
        public CustomerSession GetCustomerSessionByGuid(Guid customerSessionGuid)
        {
            if (customerSessionGuid == Guid.Empty)
                return null;


            var query = from cs in _context.CustomerSessions
                        where cs.CustomerSessionGUID == customerSessionGuid
                        orderby cs.LastAccessed descending
                        select cs;
            var customerSession = query.FirstOrDefault();
            return customerSession;
        }

        /// <summary>
        /// Gets a customer session by customer identifier
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>Customer session</returns>
        public CustomerSession GetCustomerSessionByCustomerId(int customerId)
        {
            if (customerId == 0)
                return null;


            var query = from cs in _context.CustomerSessions
                        where cs.CustomerID == customerId
                        orderby cs.LastAccessed descending
                        select cs;
            var customerSession = query.FirstOrDefault();
            return customerSession;
        }

        /// <summary>
        /// Deletes a customer session
        /// </summary>
        /// <param name="customerSessionGuid">Customer session GUID</param>
        public void DeleteCustomerSession(Guid customerSessionGuid)
        {
            var customerSession = GetCustomerSessionByGuid(customerSessionGuid);
            if (customerSession == null)
                return;

            if (!_context.IsAttached(customerSession))
                _context.CustomerSessions.Attach(customerSession);
            _context.DeleteObject(customerSession);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all customer sessions
        /// </summary>
        /// <returns>Customer session collection</returns>
        public List<CustomerSession> GetAllCustomerSessions()
        {
            var query = from cs in _context.CustomerSessions
                        orderby cs.LastAccessed descending
                        select cs;
            var customerSessions = query.ToList();
            return customerSessions;
        }

        /// <summary>
        /// Gets all customer sessions
        /// </summary>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>Customer session collection</returns>
        public PagedList<CustomerSession> GetAllCustomerSessions(int pageIndex, int pageSize)
        {
            var query = from cs in _context.CustomerSessions
                        orderby cs.LastAccessed descending
                        select cs;
            var customerSessions = new PagedList<CustomerSession>(query, pageIndex, pageSize);
            return customerSessions;
        }

        /// <summary>
        /// Deletes all expired customer sessions
        /// </summary>
        /// <param name="olderThan">Older than date and time</param>
        public void DeleteExpiredCustomerSessions(DateTime olderThan)
        {
            var scQuery = from sc in _context.CustomerSessions
                          where sc.LastAccessed < olderThan
                          select sc;

            var customerSessions = scQuery.ToList();
            foreach (var customerSession in customerSessions)
            {
                _context.DeleteObject(customerSession);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Saves a customer session to the data storage if it exists or creates new one
        /// </summary>
        /// <param name="customerSessionGuid">Customer session GUID</param>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="lastAccessed">The last accessed date and time</param>
        /// <param name="isExpired">A value indicating whether the customer session is expired</param>
        /// <returns>Customer session</returns>
        public CustomerSession SaveCustomerSession(Guid customerSessionGuid, int customerId, DateTime lastAccessed, bool isExpired)
        {
            var customerSession = GetCustomerSessionByGuid(customerSessionGuid);
            if (customerSession == null)
            {
                customerSession = new CustomerSession()
                {
                    CustomerSessionGUID = customerSessionGuid,
                    CustomerID = customerId,
                    LogTime = DateTime.Now,
                    LastAccessed = lastAccessed,
                    IsExpired = isExpired
                };
                InsertCustomerSession(customerSession);
            }
            else
            {
                customerSession.CustomerSessionGUID = customerSessionGuid;
                customerSession.CustomerID = customerId;
                customerSession.LastAccessed = lastAccessed;
                customerSession.IsExpired = isExpired;
                UpdateCustomerSession(customerSession);
            }
            return customerSession;
        }
        /// <summary>
        /// Inserts a customer session
        /// </summary>
        /// <param name="customerSession">Customer session</param>
        protected void InsertCustomerSession(CustomerSession customerSession)
        {
            if (customerSession == null)
                throw new ArgumentNullException("customerSession");



            _context.CustomerSessions.AddObject(customerSession);
            _context.SaveChanges();
        }

        /// <summary>
        /// 将密码进行加密
        /// </summary>
        public void ChangePassWordHash()
        {
            var query = from c in _context.Customers
                        where c.CustomerID != 7
                        orderby c.CustomerID
                        select c;
            foreach (var customer in query.ToList())
            {  
               string newPassword = customer.PasswordHash;

               if (String.IsNullOrWhiteSpace(newPassword))
                   newPassword = "1";
                string newPasswordSalt = CreateSalt(5);
                string newPasswordHash = CreatePasswordHash(newPassword, newPasswordSalt);

                customer.PasswordHash = newPasswordHash;
                customer.SaltKey = newPasswordSalt;

                if (!_context.IsAttached(customer))
                    _context.Customers.Attach(customer);
            }
            _context.SaveChanges();
        }


        /// <summary>
        /// WebService登录信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>WebServiceUserInfo</returns>
        public WebServiceUserInfo WebServiceLogin(string userName, string password)
        {
            if (userName == null)
                userName = string.Empty;
            userName = userName.Trim();

            var customer = GetCustomerByUsername(userName);

            if (customer == null)
                return null;

            if (!customer.Active)
                return null;

            if (customer.Deleted)
                return null;

            if (customer.IsGuest)
                return null;

            string passwordHash = CreatePasswordHash(password, customer.SaltKey);
            bool result = customer.PasswordHash.Equals(passwordHash);
            if (result)
            {
                return new WebServiceUserInfo() { 
                    EmpID = customer.CustomerID,
                    EmpName = customer.SCustomerInfo == null ? "" : customer.SCustomerInfo.FullName,
                    LoginName = customer.Username,
                    PassWord = customer.PasswordHash
                };
            }
                return null;
        }

        /// <summary>
        /// 身份验证，分配权限
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public int testIdentity(int CustomerID)
        {
            string strSql = @"select * from Sys_Department_CustomerRole_Mapping where DepartmentID in
                        (select DepartmentID from Sys_CustomerInfo where CustomerID={0})
                        and CustomerRoleID in
                        (select CustomerRoleID from Sys_Customer_CustomerRole_Mapping where CustomerID={0})";
            strSql = string.Format(strSql,CustomerID);
            DataTable dt = SqlDataHelper.GetDatatableBySql(strSql);
            return dt.Rows.Count;
        }

        #region Properties

        /// <summary>
        /// Gets a value indicating whether cache is enabled
        /// </summary>
        public bool CacheEnabled
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Cache.CustomerManager.CacheEnabled");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether anonymous checkout allowed
        /// </summary>
        public bool AnonymousCheckoutAllowed
        {
            get
            {
                bool allowed = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Checkout.AnonymousCheckoutAllowed", false);
                return allowed;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Checkout.AnonymousCheckoutAllowed", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether usernames are used instead of emails
        /// </summary>
        public bool UsernamesEnabled
        {
            get
            {
                bool usernamesEnabled = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Customer.UsernamesEnabled");
                return usernamesEnabled;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Customer.UsernamesEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to change their usernames
        /// </summary>
        public bool AllowCustomersToChangeUsernames
        {
            get
            {
                bool result = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Customer.AllowCustomersToChangeUsernames");
                return result;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Customer.AllowCustomersToChangeUsernames", value.ToString());
            }
        }

        /// <summary>
        /// Customer name formatting
        /// </summary>
        public CustomerNameFormatEnum CustomerNameFormatting
        {
            get
            {
                int customerNameFormatting = IoC.Resolve<ISettingManager>().GetSettingValueInteger("Customer.CustomerNameFormatting");
                return (CustomerNameFormatEnum)customerNameFormatting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Customer.CustomerNameFormatting", ((int)value).ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to upload avatars.
        /// </summary>
        public bool AllowCustomersToUploadAvatars
        {
            get
            {
                bool allowCustomersToUploadAvatars = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Customer.CustomersAllowedToUploadAvatars");
                return allowCustomersToUploadAvatars;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Customer.CustomersAllowedToUploadAvatars", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display default user avatar.
        /// </summary>
        public bool DefaultAvatarEnabled
        {
            get
            {
                bool defaultAvatarEnabled = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Customer.DefaultAvatarEnabled");
                return defaultAvatarEnabled;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Customer.DefaultAvatarEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether customers location is shown
        /// </summary>
        public bool ShowCustomersLocation
        {
            get
            {
                bool showCustomersLocation = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Customer.ShowCustomersLocation");
                return showCustomersLocation;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Customer.ShowCustomersLocation", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show customers join date
        /// </summary>
        public bool ShowCustomersJoinDate
        {
            get
            {
                bool showCustomersJoinDate = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Customer.ShowCustomersJoinDate");
                return showCustomersJoinDate;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Customer.ShowCustomersJoinDate", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to view profiles of other customers
        /// </summary>
        public bool AllowViewingProfiles
        {
            get
            {
                bool allowViewingProfiles = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Customer.AllowViewingProfiles");
                return allowViewingProfiles;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Customer.AllowViewingProfiles", value.ToString());
            }
        }

        /// <summary>
        /// Tax display type
        /// </summary>
        public CustomerRegistrationTypeEnum CustomerRegistrationType
        {
            get
            {
                int customerRegistrationType = IoC.Resolve<ISettingManager>().GetSettingValueInteger("Common.CustomerRegistrationType", (int)CustomerRegistrationTypeEnum.Standard);
                return (CustomerRegistrationTypeEnum)customerRegistrationType;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Common.CustomerRegistrationType", ((int)value).ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to allow navigation only for registered users.
        /// </summary>
        public bool AllowNavigationOnlyRegisteredCustomers
        {
            get
            {
                bool allowOnlyRegisteredCustomers = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Common.AllowNavigationOnlyRegisteredCustomers");
                return allowOnlyRegisteredCustomers;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Common.AllowNavigationOnlyRegisteredCustomers", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether product reviews must be approved by administrator.
        /// </summary>
        public bool ProductReviewsMustBeApproved
        {
            get
            {
                bool productReviewsMustBeApproved = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Common.ProductReviewsMustBeApproved");
                return productReviewsMustBeApproved;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Common.ProductReviewsMustBeApproved", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to allow anonymous users write product reviews.
        /// </summary>
        public bool AllowAnonymousUsersToReviewProduct
        {
            get
            {
                bool allowAnonymousUsersToReviewProduct = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Common.AllowAnonymousUsersToReviewProduct");
                return allowAnonymousUsersToReviewProduct;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Common.AllowAnonymousUsersToReviewProduct", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to allow anonymous users to email a friend.
        /// </summary>
        public bool AllowAnonymousUsersToEmailAFriend
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Common.AllowAnonymousUsersToEmailAFriend", false);
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Common.AllowAnonymousUsersToEmailAFriend", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to allow anonymous users to set product ratings.
        /// </summary>
        public bool AllowAnonymousUsersToSetProductRatings
        {
            get
            {
                bool allowAnonymousUsersToSetProductRatings = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Common.AllowAnonymousUsersToSetProductRatings");
                return allowAnonymousUsersToSetProductRatings;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Common.AllowAnonymousUsersToSetProductRatings", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'New customer' notification message should be sent to a store owner
        /// </summary>
        public bool NotifyNewCustomerRegistration
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Common.NotifyNewCustomerRegistration", false);
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Common.NotifyNewCustomerRegistration", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Gender' is enabled
        /// </summary>
        public bool FormFieldGenderEnabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.GenderEnabled", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.GenderEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Date of Birth' is enabled
        /// </summary>
        public bool FormFieldDateOfBirthEnabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.DateOfBirthEnabled", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.DateOfBirthEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Company' is enabled
        /// </summary>
        public bool FormFieldCompanyEnabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.CompanyEnabled", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.CompanyEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Company' is required
        /// </summary>
        public bool FormFieldCompanyRequired
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.CompanyRequired", false);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.CompanyRequired", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Street Address' is enabled
        /// </summary>
        public bool FormFieldStreetAddressEnabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.StreetAddressEnabled", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.StreetAddressEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Street Address' is required
        /// </summary>
        public bool FormFieldStreetAddressRequired
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.StreetAddressRequired", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.StreetAddressRequired", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Street Address 2' is enabled
        /// </summary>
        public bool FormFieldStreetAddress2Enabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.StreetAddress2Enabled", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.StreetAddress2Enabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Street Address 2' is required
        /// </summary>
        public bool FormFieldStreetAddress2Required
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.StreetAddress2Required", false);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.StreetAddress2Required", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Post Code' is enabled
        /// </summary>
        public bool FormFieldPostCodeEnabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.PostCodeEnabled", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.PostCodeEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Post Code' is required
        /// </summary>
        public bool FormFieldPostCodeRequired
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.PostCodeRequired", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.PostCodeRequired", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'City' is enabled
        /// </summary>
        public bool FormFieldCityEnabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.CityEnabled", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.CityEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'City' is required
        /// </summary>
        public bool FormFieldCityRequired
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.CityRequired", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.CityRequired", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Country' is enabled
        /// </summary>
        public bool FormFieldCountryEnabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.CountryEnabled", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.CountryEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'State' is enabled
        /// </summary>
        public bool FormFieldStateEnabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.StateEnabled", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.StateEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Phone' is enabled
        /// </summary>
        public bool FormFieldPhoneEnabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.PhoneEnabled", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.PhoneEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Phone' is required
        /// </summary>
        public bool FormFieldPhoneRequired
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.PhoneRequired", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.PhoneRequired", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Fax' is enabled
        /// </summary>
        public bool FormFieldFaxEnabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.FaxEnabled", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.FaxEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Fax' is required
        /// </summary>
        public bool FormFieldFaxRequired
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.FaxRequired", false);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.FaxRequired", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Newsletter' is enabled
        /// </summary>
        public bool FormFieldNewsletterEnabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.NewsletterEnabled", true);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.NewsletterEnabled", value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 'Time Zone' is enabled
        /// </summary>
        public bool FormFieldTimeZoneEnabled
        {
            get
            {
                bool setting = IoC.Resolve<ISettingManager>().GetSettingValueBoolean("FormField.TimeZoneEnabled", false);
                return setting;
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("FormField.TimeZoneEnabled", value.ToString());
            }
        }

        #endregion
    }
}
