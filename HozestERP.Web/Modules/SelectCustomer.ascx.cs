using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;

using AjaxControlToolkit;

namespace HozestERP.Web.Modules
{
    public partial class SelectCustomerControl : BaseAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblScript.Text = this.SessionPageID;
                this.iBtnSelect.OnClientClick = "return Show" + this.SessionPageID + "SelectCustomerDetail('" + CommonHelper.GetStoreLocation() + "Modules/SelectCustomer.aspx?SessionID=" + this.SessionPageID + "');";

            }
        }

        public string SessionPageID
        {
            get;
            set;
        }

        public List<CustomerInfo> SelectCustomers
        {
            get
            {
                try
                {
                    return (Session[this.SessionPageID + "SelectCustomerInfos"] as List<CustomerInfo>);
                }
                catch
                {
                }
                return new List<CustomerInfo>();
            }
            set
            {
                Session[this.SessionPageID + "SelectCustomerInfos"] = value;
                this.txtCustomerName.Text = string.Empty;
                foreach (var item in value)
                {
                    if (!string.IsNullOrEmpty(this.txtCustomerName.Text))
                    {
                        this.txtCustomerName.Text += ",";
                    }
                    this.txtCustomerName.Text += item.FullName;
                }
            }
        }

        public string CustomerStatus
        {
            get
            {
                try
                {
                    return (Session[ this.SessionPageID + "SelectCustomersStatus"] as string);
                }
                catch
                {
                }
                return string.Empty;
            }
            set
            {
                Session[this.SessionPageID + "SelectcustomerStatus"] = value;
            }
        }


        public string Value
        {
            get
            {
                return this.txtCustomerName.Text.Trim();
            }
            set
            {
                this.txtCustomerName.Text = value;
            }
        }

        protected void iBtnSelect_Click(object sender, ImageClickEventArgs e)
        {
            this.txtCustomerName.Text = string.Empty;
            foreach (var item in this.SelectCustomers)
            {
                if (!string.IsNullOrEmpty(this.txtCustomerName.Text))
                {
                    this.txtCustomerName.Text += ",";
                }
                this.txtCustomerName.Text += item.FullName;
            }

            if (this.SelectedCustomer != null)
            {
                this.SelectedCustomer(sender, new SelectedMoreCustomerEventArgs() { SelectSingleCustomers = this.SelectCustomers });
            }
        }

        /// <summary>
        /// Customer event handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        public delegate void SelectedCustomerEventHandler(object sender, SelectedMoreCustomerEventArgs e);

        /// <summary>
        /// Customer created event
        /// </summary>
        public event SelectedCustomerEventHandler SelectedCustomer;

        public TextBoxMode TextMode
        {
            get
            {
                return txtCustomerName.TextMode;
            }
            set
            {
                txtCustomerName.TextMode = value;
            }
        }

        public Unit Width
        {
            get
            {
                return txtCustomerName.Width;
            }
            set
            {
                txtCustomerName.Width = value;
            }
        }

        public HtmlTable SelectTable
        {
            get
            {
                return this.selectTable;
            }
        }

        public Unit Height
        {
            get
            {
                return txtCustomerName.Height;
            }
            set
            {
                txtCustomerName.Height = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return txtCustomerName.Enabled;
            }
            set
            {
                txtCustomerName.Enabled = value;
            }
        }

        //public string ValidationGroup
        //{
        //    get
        //    {
        //        return this.rfvValue.ValidationGroup;
        //    }
        //    set
        //    {
        //        this.txtCustomerName.ValidationGroup = value;
        //        this.rfvValue.ValidationGroup = value;
        //    }
        //}

        //public string ErrorMessage
        //{
        //    get
        //    {
        //        return rfvValue.ErrorMessage;
        //    }
        //    set
        //    {
        //        rfvValue.ErrorMessage = value;
        //    }
        //}

        //public ValidatorCalloutPosition PopupPosition
        //{
        //    set
        //    {
        //        this.rfvValueE.PopupPosition = value;
        //    }
        //}
    }




    public partial class SelectedMoreCustomerEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public List<CustomerInfo> SelectSingleCustomers { get; set; }
    }
}