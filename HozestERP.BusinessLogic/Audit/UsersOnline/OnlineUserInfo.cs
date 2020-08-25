using System;

using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.Audit.UsersOnline
{
    /// <summary>
    /// Represents an online user info
    /// </summary>
    public partial class OnlineUserInfo
    {
        /// <summary>
        /// Gets or sets the unique identifier
        /// </summary>
        public Guid OnlineUserGuid { get; set; }

        /// <summary>
        /// Gets or sets the associated customer identifier (if he exists)
        /// </summary>
        public int? AssociatedCustomerId { get; set; }

        /// <summary>
        /// Gets or sets the IP Address
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the last page visited
        /// </summary>
        public string LastPageVisited { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the last visit date and time
        /// </summary>
        public DateTime LastVisit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Customer AssociatedCustomer
        {
            get 
            {
                return IoC.Resolve<ICustomerService>().GetCustomerById(this.AssociatedCustomerId.GetValueOrDefault());
            }
        }
        /// <summary>
        /// Gets countryName
        /// </summary>
        public string countryName
        {
            get
            {
                return GeoCountryLookup.LookupCountryName(this.IPAddress);
        
           } 
        }
        /// <summary>
        /// Gets Username
        /// </summary>
        public string Username
        {
            get
            {
                return AssociatedCustomer.Username;

            }
        }
    }
}
