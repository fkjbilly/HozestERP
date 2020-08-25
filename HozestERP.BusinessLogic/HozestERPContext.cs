using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using HozestERP.BusinessLogic.Configuration;

using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Configuration.Settings;

namespace HozestERP.BusinessLogic
{
    public partial class HozestERPContext
    {
        #region Constants
        private const string CONST_CUSTOMERSESSION = "CRM.CustomerSession";
        private const string CONST_CUSTOMERSESSIONCOOKIE = "CRM.CustomerSessionGUIDCookie";
        #endregion

        #region Fields
        private Customer _currentCustomer;
        private bool? _isAdmin;
        private readonly HttpContext _context = HttpContext.Current;
        #endregion        

        #region Ctor
        /// <summary>
        /// Creates a new instance of the NopContext class
        /// </summary>
        private HozestERPContext()
        {
        }
        #endregion

        #region Methods

        /// <summary>
        /// Save customer session to data source
        /// </summary>
        /// <returns>Saved customer ssion</returns>
        private CustomerSession SaveSessionToDatabase()
        {
            var sessionId = Guid.NewGuid();
            while (IoC.Resolve<ICustomerService>().GetCustomerSessionByGuid(sessionId) != null)
                sessionId = Guid.NewGuid();
            var session = new CustomerSession();
            int customerId = 0;
            if (this.User != null)
            {
                customerId = this.User.CustomerID;
            }
            session.CustomerSessionGUID = sessionId;
            session.CustomerID = customerId;
            session.LastAccessed = DateTime.UtcNow;
            session.IsExpired = false;
            session = IoC.Resolve<ICustomerService>().SaveCustomerSession(session.CustomerSessionGUID, session.CustomerID, session.LastAccessed, session.IsExpired);
            return session;
        }

        /// <summary>
        /// Gets customer session
        /// </summary>
        /// <param name="createInDatabase">Create session in database if no one exists</param>
        /// <returns>Customer session</returns>
        public CustomerSession GetSession(bool createInDatabase)
        {
            return this.GetSession(createInDatabase, null);
        }

        /// <summary>
        /// Gets customer session
        /// </summary>
        /// <param name="createInDatabase">Create session in database if no one exists</param>
        /// <param name="sessionId">Session identifier</param>
        /// <returns>Customer session</returns>
        public CustomerSession GetSession(bool createInDatabase, Guid? sessionId)
        {
            CustomerSession byId = null;
            object obj2 = Current[CONST_CUSTOMERSESSION];
            if (obj2 != null)
                byId = (CustomerSession)obj2;
            if ((byId == null) && (sessionId.HasValue))
            {
                byId = IoC.Resolve<ICustomerService>().GetCustomerSessionByGuid(sessionId.Value);
                return byId;
            }
            if (byId == null && createInDatabase)
            {
                byId = SaveSessionToDatabase();
            }
            string customerSessionCookieValue = string.Empty;
            if ((HttpContext.Current.Request.Cookies[CONST_CUSTOMERSESSIONCOOKIE] != null) && (HttpContext.Current.Request.Cookies[CONST_CUSTOMERSESSIONCOOKIE].Value != null))
                customerSessionCookieValue = HttpContext.Current.Request.Cookies[CONST_CUSTOMERSESSIONCOOKIE].Value;
            if ((byId) == null && (!string.IsNullOrEmpty(customerSessionCookieValue)))
            {
                var dbCustomerSession = IoC.Resolve<ICustomerService>().GetCustomerSessionByGuid(new Guid(customerSessionCookieValue));
                byId = dbCustomerSession;
            }
            Current[CONST_CUSTOMERSESSION] = byId;
            return byId;
        }

        /// <summary>
        /// Saves current session to client
        /// </summary>
        public void SessionSaveToClient()
        {
            if (HttpContext.Current != null && this.Session != null)
                SetCookie(HttpContext.Current.ApplicationInstance, CONST_CUSTOMERSESSIONCOOKIE, this.Session.CustomerSessionGUID.ToString());
        }

        /// <summary>
        /// Reset customer session
        /// </summary>
        public void ResetSession()
        {
            if (HttpContext.Current != null)
                SetCookie(HttpContext.Current.ApplicationInstance, CONST_CUSTOMERSESSIONCOOKIE, string.Empty);
            this.Session = null;
            this.User = null;
            this["CRM.SessionReseted"] = true;
        }

        /// <summary>
        /// Sets cookie
        /// </summary>
        /// <param name="application">Application</param>
        /// <param name="key">Key</param>
        /// <param name="val">Value</param>
        private static void SetCookie(HttpApplication application, string key, string val)
        {
            HttpCookie cookie = new HttpCookie(key);
            cookie.Value = val;
            if (string.IsNullOrEmpty(val))
            {
                cookie.Expires = DateTime.Now.AddMonths(-1);
            }
            else
            {
                cookie.Expires = DateTime.Now.AddHours(HozestERPConfig.CookieExpires);
            }
            application.Response.Cookies.Remove(key);
            application.Response.Cookies.Add(cookie);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the NopContext, which can be used to retrieve information about current context.
        /// </summary>
        public static HozestERPContext Current
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    object data = Thread.GetData(Thread.GetNamedDataSlot("HozestERPContext"));
                    if (data != null)
                    {
                        return (HozestERPContext)data;
                    }
                    HozestERPContext context = new HozestERPContext();
                    Thread.SetData(Thread.GetNamedDataSlot("HozestERPContext"), context);
                    return context;
                }
                if (HttpContext.Current.Items["HozestERPContext"] == null)
                {
                    HozestERPContext context = new HozestERPContext();
                    HttpContext.Current.Items.Add("HozestERPContext", context);
                    return context;
                }
                return (HozestERPContext)HttpContext.Current.Items["HozestERPContext"];
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the context is running in admin-mode
        /// </summary>
        public bool IsAdmin
        {
            get
            {
                if (!_isAdmin.HasValue)
                {
                    _isAdmin = CommonHelper.IsAdmin();
                }
                return _isAdmin.Value;
            }
            set
            {
                _isAdmin = value;
            }
        }

        /// <summary>
        /// Gets or sets an object item in the context by the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public object this[string key]
        {
            get
            {
                if (this._context == null)
                {
                    return null;
                }

                if (this._context.Items[key] != null)
                {
                    return this._context.Items[key];
                }
                return null;
            }
            set
            {
                if (this._context != null)
                {
                    this._context.Items.Remove(key);
                    this._context.Items.Add(key, value);

                }
            }
        }

        /// <summary>
        /// Gets or sets the current session
        /// </summary>
        public CustomerSession Session
        {
            get
            {
                return this.GetSession(false);
            }
            set
            {
                Current[CONST_CUSTOMERSESSION] = value;
            }
        }

        /// <summary>
        /// Gets or sets the current user
        /// </summary>
        public Customer User
        {
            get
            {
                return this._currentCustomer;
            }
            set
            {
                this._currentCustomer = value;
            }
        }

        /// <summary>
        /// Gets an user host address
        /// </summary>
        public string UserHostAddress
        {
            get
            {
                if (HttpContext.Current != null &&
                    HttpContext.Current.Request != null &&
                    HttpContext.Current.Request.UserHostAddress != null)
                    return HttpContext.Current.Request.UserHostAddress;
                else
                    return string.Empty;
            }
        }


        /// <summary>
        /// Get or set current theme (e.g. darkOrange)
        /// </summary>
        public string WorkingTheme
        {
            get
            {
                if (IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Display.AllowCustomerSelectTheme"))
                {
                    string themeCookie = CommonHelper.GetCookieString("Nop.WorkingTheme", false);
                    if (!String.IsNullOrEmpty(themeCookie))
                    {
                        return themeCookie;
                    }

                    if (HozestERPContext.Current != null &&
                    HozestERPContext.Current.User != null &&
                    !HozestERPContext.Current.User.IsGuest)
                    {
                        return HozestERPContext.Current.User.WorkingTheme;
                    }
                }
                string defaultTheme = IoC.Resolve<ISettingManager>().GetSettingValue("Display.PublicStoreTheme");
                if (!String.IsNullOrEmpty(defaultTheme))
                {
                    return defaultTheme;
                }
                return "Blue";
            }
            set
            {
                if (!IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Display.AllowCustomerSelectTheme"))
                    return;

                CommonHelper.SetCookie("Nop.WorkingTheme", value.Trim(), new TimeSpan(365, 0, 0, 0, 0));
            }
        }   
        
        /// <summary>
        /// Get or set current theme (e.g. darkOrange)
        /// </summary>
        public string TopTaobaoTheme
        {
            get
            {
                if (IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Display.AllowCustomerSelectTheme"))
                {
                    string themeCookie = CommonHelper.GetCookieString("Nop.TopTaobaoTheme", false);
                    if (!String.IsNullOrEmpty(themeCookie))
                    {
                        return themeCookie;
                    }

                    if (HozestERPContext.Current != null &&
                    HozestERPContext.Current.User != null &&
                    !HozestERPContext.Current.User.IsGuest)
                    {
                        return HozestERPContext.Current.User.WorkingTheme;
                    }
                }
                string defaultTheme = IoC.Resolve<ISettingManager>().GetSettingValue("Display.TopTaobaoTheme");
                if (!String.IsNullOrEmpty(defaultTheme))
                {
                    return defaultTheme;
                }
                return "TopTaobao";
            }
            set
            {
                if (!IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Display.AllowCustomerSelectTheme"))
                    return;

                CommonHelper.SetCookie("Nop.TopTaobaoTheme", value.Trim(), new TimeSpan(365, 0, 0, 0, 0));
            }
        }

        /// <summary>
        /// Sets the CultureInfo 
        /// </summary>
        /// <param name="culture">Culture</param>
        public void SetCulture(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }

        #endregion
    }
}
