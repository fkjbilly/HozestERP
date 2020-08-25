using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HozestERP.BusinessLogic.Security;
using HozestERP.BusinessLogic.ModuleManagement;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.Security
{
    public partial class SelectCustomerAction
    {
        public int CustomerActionID { get; set; }
        public int CustomerRoleID { get; set; }
        public string ModuleName { get; set; }
        public int ModuleID { get; set; }
        public string Name { get; set; }

        public bool Allow
        {
            get;
            set;
        }

        public int ACLID { get; set; }

        public Module Module
        {
            get
            {
                return IoC.Resolve<IModuleService>().getModuleByModuleID(this.ModuleID);
            }
        }

        public string FullModuleName
        {
            get
            {
                if (this.Module == null)
                    return string.Empty;
                var module = this.Module;
                string moduleName = module.ModuleName;
                while (true)
                {
                    if (module.ParentID == 0)
                    {
                        break;
                    }
                    module = module.ParentModule;
                    moduleName = module.ModuleName + "\\" + moduleName;
                }
                return moduleName;
            }
        }
    }
}
