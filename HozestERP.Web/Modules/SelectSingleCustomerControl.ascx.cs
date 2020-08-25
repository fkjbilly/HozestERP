using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;

using AjaxControlToolkit;


namespace HozestERP.Web.Modules
{
    public partial class SelectSingleCustomerControl : BaseAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblScript.Text = this.SessionPageID;
                this.iBtnSelect.OnClientClick = "return Show" + this.SessionPageID + "CustomerDetail('" + CommonHelper.GetStoreLocation() + "Modules/SelectSingleCustomer.aspx?SessionPageID=" + this.SessionPageID+ "');";
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.lblScript.Text = this.SessionPageID;
            this.iBtnSelect.OnClientClick = "return Show" + this.SessionPageID + "CustomerDetail('" + CommonHelper.GetStoreLocation() + "Modules/SelectSingleCustomer.aspx?SessionPageID=" + this.SessionPageID + "');";
         
            base.OnInit(e);
        }

        public string SessionPageID
        {
            get;
            set;
        }


        public CustomerInfo SelectSingleCustomer
        {
            get
            {
                try
                {
                    return (Session[this.SessionPageID + "CustomerInfos"] as CustomerInfo);
                }
                catch
                {
                }
                return new CustomerInfo();
            }
            set
            {
                Session[this.SessionPageID + "CustomerInfos"] = value;
            }
        }

        public string CustomerStatus
        {
            get
            {
                try
                {
                    return (Session[this.SessionPageID + "CustomerStatus"] as string);
                }
                catch
                {
                }
                return string.Empty;
            }
            set
            {
                Session[this.SessionPageID + "CustomerStatus"] = value;
            }
        }


        public bool BtnVisible
        {
            get
            {
                return this.iBtnSelect.Visible;
            }
            set
            {
                this.iBtnSelect.Visible = value;
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
            if (this.SelectSingleCustomer == null)
            {
                return;
            }
            this.txtCustomerName.Text = string.Empty;
            this.txtCustomerName.Text = this.SelectSingleCustomer.FullName;

            if (this.SelectedCustomer != null)
            {
                this.SelectedCustomer(sender, new SelectedCustomerEventArgs() { SelectSingleCustomer=this.SelectSingleCustomer });
            }
        }


        public string ValidationGroup
        {
            get
            {
                return this.rfvValue.ValidationGroup;
            }
            set
            {
                this.txtCustomerName.ValidationGroup = value;
                this.rfvValue.ValidationGroup = value;
            }
        }

        public ValidatorCalloutPosition PopupPosition
        {
            set
            {
                this.rfvValueE.PopupPosition = value;
            }
        }

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


        /// <summary>
        /// Customer event handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        public delegate void SelectedCustomerEventHandler(object sender, SelectedCustomerEventArgs e);


        /// <summary>
        /// Customer created event
        /// </summary>
        public event SelectedCustomerEventHandler SelectedCustomer;
    }


    public partial class SelectedCustomerEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public CustomerInfo SelectSingleCustomer { get; set; }
    }
}