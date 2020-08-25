using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.Web.Modules
{
    public partial class ImageButtonSelectSingleCustomerControl : BaseAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblScript.Text = this.SessionPageID;
            }
        }

        public string OnClientClick
        {
            get
            {
                return "return Show" + this.SessionPageID + "CustomerDetail('" + CommonHelper.GetStoreLocation() + "Modules/SelectSingleCustomer.aspx?SessionPageID=" + this.SessionPageID + "');";

            }
        }

        public string BtnUniqueID
        {
            get
            {
                return this.btnAllocationOfClients.UniqueID;
            }
        }

        public string BtnOnClientClick
        {
            get
            {
                return this.btnAllocationOfClients.OnClientClick;
            }
            set
            {
                this.btnAllocationOfClients.OnClientClick = value;
            }
        }

        public bool BtnVisible
        {
            get
            {
                return this.btnAllocationOfClients.Visible;
            }
            set
            {
                this.btnAllocationOfClients.Visible = value;
            }
        }

        public string BtnToolTip
        {
            get
            {
                return this.btnAllocationOfClients.ToolTip;
            }
            set
            {
                this.btnAllocationOfClients.ToolTip = value;
            }
        }

        public string BtnImageUrl
        {
            get
            {
                return this.btnAllocationOfClients.ImageUrl;
            }
            set
            {
                this.btnAllocationOfClients.ImageUrl = value;
            }
        }
        
        public string BtnSkinID
        {
            get
            {
                return this.btnAllocationOfClients.SkinID;
            }
            set
            {
                this.btnAllocationOfClients.SkinID = value;
            }
        }

        //按钮样式
        public string CssClass
        {
            get
            {
                return this.btnAllocationOfClients.CssClass;
            }
            set
            {
                this.btnAllocationOfClients.CssClass = value;
            }
        }

        //
        public string CommandName
        {
            get
            {
                return this.btnAllocationOfClients.CommandName;
            }
            set
            {
                this.btnAllocationOfClients.CommandName = value;
            }
        }

        public string CommandArgument
        {
            get
            {
                return this.btnAllocationOfClients.CommandArgument;
            }
            set
            {
                this.btnAllocationOfClients.CommandArgument = value;
            }
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

        protected void btnAllocationOfClients_Click(object sender, EventArgs e)
        {
            if (this.SelectSingleCustomer == null)
            {
                return;
            }

            if (this.SelectedCustomer != null)
            {
                this.SelectedCustomer(sender, new SelectedCustomerEventArgs() { SelectSingleCustomer = this.SelectSingleCustomer });
            }
            this.SelectSingleCustomer = null;
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
}