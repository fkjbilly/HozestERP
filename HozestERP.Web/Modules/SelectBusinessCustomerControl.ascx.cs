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
      
    public partial class SelectBusinessCustomerControl : BaseAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblScript.Text = this.SessionPageID;
                this.iBtnSelect.OnClientClick = "return Show" + this.SessionPageID + "CustomerDetail('" + CommonHelper.GetStoreLocation() + "Modules/SelectBusinessCustomer.aspx?SessionPageID=" + this.SessionPageID +"&DepartmentID="+this.DepartmentID+ "');";
            
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.lblScript.Text = this.SessionPageID;
            this.iBtnSelect.OnClientClick = "return Show" + this.SessionPageID + "CustomerDetail('" + CommonHelper.GetStoreLocation() + "Modules/SelectBusinessCustomer.aspx?SessionPageID=" + this.SessionPageID +"&DepartmentID="+this.DepartmentID+  "');";

            base.OnInit(e);
        }

        public string SessionPageID
        {
            get;
            set;
        }


        public string DepartmentID
        {
            get;
            set;

        }

        public CustomerInfo SelectSingleCustomerInfo
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
                return this.txtFullName.Text.Trim();
            }
            set
            {
                this.txtFullName.Text = value;
            }
        }

        protected void iBtnSelect_Click(object sender, ImageClickEventArgs e)
        {
            if (this.SelectSingleCustomerInfo == null)
            {
                return;
            }
            this.txtFullName.Text = string.Empty;
            this.txtFullName.Text = this.SelectSingleCustomerInfo.FullName;

            if (this.SelectedCustomer != null)
            {
                this.SelectedCustomer(sender, new SelectSingleCustomerInfoEventArgs() { SelectSingleCustomerInfo = this.SelectSingleCustomerInfo });
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
                this.txtFullName.ValidationGroup = value;
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
                return txtFullName.TextMode;
            }
            set
            {
                txtFullName.TextMode = value;
            }
        }

        public Unit Width
        {
            get
            {
                return txtFullName.Width;
            }
            set
            {
                txtFullName.Width = value;
            }
        }

        public Unit Height
        {
            get
            {
                return txtFullName.Height;
            }
            set
            {
                txtFullName.Height = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return txtFullName.Enabled;
            }
            set
            {
                txtFullName.Enabled = value;
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
        public delegate void SelectSingleCustomerInfoHandler(object sender, SelectSingleCustomerInfoEventArgs e);


        /// <summary>
        /// Customer created event
        /// </summary>
        public event SelectSingleCustomerInfoHandler SelectedCustomer;
    }

    public partial class SelectSingleCustomerInfoEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public CustomerInfo SelectSingleCustomerInfo { get; set; }
    }
}