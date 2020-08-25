
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
    public partial class SimpleTextBox : BaseUserControl
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

        public string ErrorMessage
        {
            get
            {
                return rfvValue.ErrorMessage;
            }
            set
            {
                rfvValue.ErrorMessage = value;
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

        public Unit Height
        {
            get
            {
                return txtValue.Height;
            }
            set
            {
                txtValue.Height = value;
            }
        }

        public TextBoxMode TextMode
        {
            get
            {
                return txtValue.TextMode;
            }
            set
            {
                txtValue.TextMode = value;
            }
        }

        public ValidatorCalloutPosition PopupPosition
        {
            set
            {
                this.rfvValueE.PopupPosition = value;
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
            }
        }

        /// <summary>
        ///  Gets or sets the skin to apply to the control.
        /// </summary>
        public string SkinID
        {
            get
            {
                return txtValue.SkinID;
            }
            set
            {
                txtValue.SkinID = value;
            }
        }

        public AutoCompleteType AutoCompleteType
        {
            get
            {
                return txtValue.AutoCompleteType;
            }
            set
            {
                txtValue.AutoCompleteType = value;
            }
        }

        public bool ValidatorEnabled
        {
            get
            {
                return this.rfvValue.Enabled;
            }
            set
            {
                this.rfvValue.Enabled = value;
            }
        }


    }
}
