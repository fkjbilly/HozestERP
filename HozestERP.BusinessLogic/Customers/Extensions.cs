

using System;
using System.Collections.Generic;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {

        /// <summary>
        /// Returns a customer attribute that has the specified attribute value
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="key">Customer attribute key</param>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>A customer attribute that has the specified attribute value; otherwise null</returns>
        public static CustomerAttribute FindAttribute(this List<CustomerAttribute> source,
            string key, int customerId)
        {
            foreach (CustomerAttribute customerAttribute in source)
            {
                if (customerAttribute.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase) &&
                    customerAttribute.CustomerId == customerId)
                    return customerAttribute;
            }
            return null;
        }
    }
}
