using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.Audit
{
    /// <summary>
    /// Represents a log item type (need to be synchronize with [CRM_LogType] table)
    /// </summary>
    public enum LogTypeEnum : int
    {
        /// <summary>
        /// Customer error log item type
        /// </summary>
        CustomerError = 1,
        /// <summary>
        /// Mail error log item type
        /// </summary>
        MailError = 2,
        /// <summary>
        /// Order error log item type
        /// </summary>
        OrderError = 3,
        /// <summary>
        /// Administration area log item type
        /// </summary>
        AdministrationArea = 4,
        /// <summary>
        /// Common error log item type
        /// </summary>
        CommonError = 5,
        /// <summary>
        /// Shipping error log item type
        /// </summary>
        ShippingError = 6,
        /// <summary>
        /// Tax error log item type
        /// </summary>
        TaxError = 7,
        /// <summary>
        /// Unknown log item type
        /// </summary>
        Unknown = 20,
    }
}
