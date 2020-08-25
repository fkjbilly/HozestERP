using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ModuleManagement
{
    public partial class ModuleEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the Module
        /// </summary>
        public Module Module { get; set; }
    }
}
