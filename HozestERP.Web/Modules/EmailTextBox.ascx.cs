using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using AjaxControlToolkit;

namespace HozestERP.Web.Modules
{
    public partial class EmailTextBox: BaseAdministrationUserControl
    {
        public string Text
        {
            get
            {
                return txtValue.Text;
            }
            set
            {
                txtValue.Text = value;
            }
        }

        public Unit Width
        {
            get
            {
                return txtValue.Width;
            }
            set
            {
                txtValue.Width = value;
            }
        }

        public string ValidationGroup
        {
            get
            {
                return rfvValue.ValidationGroup;
            }
            set
            {
                txtValue.ValidationGroup = value;
                rfvValue.ValidationGroup = value;
                revValue.ValidationGroup = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return txtValue.Enabled;
            }
            set
            {
                txtValue.Enabled = value;
            }
        }


        public ValidatorCalloutPosition PopupPosition
        {
            set
            {
                this.rfvValueE.PopupPosition = value;
                this.rvValueE.PopupPosition = value;
            }
        }
    }
}
