using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public enum CustomerNameFormatEnum:int
    { 
        /// <summary>
        /// Show emails
        /// </summary>
        ShowEmails = 1,
        /// <summary>
        /// Show usernames
        /// </summary>
        ShowUsernames = 2,
        /// <summary>
        /// Show full names
        /// </summary>
        ShowFullNames = 3
    }
}
