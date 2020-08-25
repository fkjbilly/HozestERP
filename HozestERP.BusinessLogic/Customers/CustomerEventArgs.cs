using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public partial class CustomerEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public Customer Customer { get; set; }
    }
}
