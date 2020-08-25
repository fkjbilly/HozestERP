using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using HozestERP.Common.Utils;
using System.Web;

namespace HozestERP.BusinessLogic.SEO
{
    public partial class SEOHelper
    {
        /// <summary>
        /// Gets login page URL of admin area
        /// </summary>
        /// <returns>Login page URL</returns>
        public static string GetAdminAreaLoginPageUrl()
        {
            string url = string.Format(CultureInfo.InvariantCulture, "{0}Login.aspx",
                      CommonHelper.GetStoreAdminLocation());
            return url.ToLowerInvariant();
        }

        /// <summary>
        /// Gets login page URL of admin area
        /// </summary>
        /// <returns>Login page URL</returns>
        public static string GetAdminTopLoginPageUrl()
        {
            string url = string.Format(CultureInfo.InvariantCulture, "{0}TopTaobao/TopLogin.aspx",
                      CommonHelper.GetStoreAdminLocation());
            return url.ToLowerInvariant();
        }


        /// <summary>
        /// Gets access denied page URL for admin area
        /// </summary>
        /// <returns>Result URL</returns>
        public static string GetAdminAreaAccessDeniedUrl()
        {
            string url = CommonHelper.GetStoreAdminLocation() + "AccessDenied.aspx";
            return url.ToLowerInvariant();
        }

        /// <summary>
        /// Gets login page URL
        /// </summary>
        /// <returns>Login page URL</returns>
        public static string GetLoginPageUrl()
        {
            return GetLoginPageUrl(string.Empty);
        }

        /// <summary>
        /// Gets login page URL
        /// </summary>
        /// <param name="returnUrl">Return url</param>
        /// <returns>Login page URL</returns>
        public static string GetLoginPageUrl(string returnUrl)
        {
            string loginUrl = string.Empty;
            if (!string.IsNullOrEmpty(returnUrl))
            {
                loginUrl = string.Format(CultureInfo.InvariantCulture, "{0}Login.aspx?ReturnUrl={1}",
                    CommonHelper.GetStoreLocation(),
                    HttpUtility.UrlEncode(returnUrl));
            }
            else
            {
                loginUrl = string.Format(CultureInfo.InvariantCulture, "{0}Login.aspx",
                    CommonHelper.GetStoreLocation());
            }
            return loginUrl.ToLowerInvariant();
        }
    }
}
