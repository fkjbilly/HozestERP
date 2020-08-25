using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Media;
using HozestERP.Common;

namespace HozestERP.Web.Modules
{
    public partial class CustomerAvatarControl : BaseAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }

        private void BindData()
        {
            Customer customer = this.CustomerService.GetCustomerById(this.CustomerId);
            if (customer != null)
            {
                var customerAvatar = customer.Avatar;
                int avatarSize = this.SettingManager.GetSettingValueInteger("Media.Customer.AvatarSize", 85);
                string pictureUrl = string.Empty;
                if (customerAvatar != null)
                {
                    pictureUrl = this.PictureService.GetPictureUrl(customerAvatar, avatarSize, false);
                    this.btnRemoveAvatar.Visible = true;
                }
                else
                {
                    pictureUrl = this.PictureService.GetDefaultPictureUrl(PictureTypeEnum.Avatar, avatarSize);
                    this.btnRemoveAvatar.Visible = false;
                }
                this.imgAvatar.ImageUrl = pictureUrl;
            }
        }

        protected void btnUploadAvatar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Customer customer = this.CustomerService.GetCustomerById(this.CustomerId);
                    if (customer != null)
                    {
                        var customerAvatar = customer.Avatar;
                        var customerPictureFile = uplAvatar.PostedFile;

                        if ((customerPictureFile != null) && (!String.IsNullOrEmpty(customerPictureFile.FileName)))
                        {
                            int avatarMaxSize = this.SettingManager.GetSettingValueInteger("Media.Customer.AvatarMaxSizeBytes", 20000);
                            if (customerPictureFile.ContentLength > avatarMaxSize)
                                throw new CRMException(string.Format("Maximum avatar size is {0} bytes", avatarMaxSize));

                            byte[] customerPictureBinary = customerPictureFile.GetPictureBits();
                            if (customerAvatar != null)
                                customerAvatar = this.PictureService.UpdatePicture(customerAvatar.PictureID, customerPictureBinary, customerPictureFile.ContentType, true);
                            else
                                customerAvatar = this.PictureService.InsertPicture(customerPictureBinary, customerPictureFile.ContentType, true);
                        }
                        int customerAvatarId = 0;
                        if (customerAvatar != null)
                            customerAvatarId = customerAvatar.PictureID;

                        customer.AvatarID = customerAvatarId;
                        this.CustomerService.UpdateCustomer(customer);

                        BindData();
                    }
                }
            }
            catch (Exception exc)
            {
                ShowError(exc.Message);
            }
        }

        protected void btnRemoveAvatar_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = this.CustomerService.GetCustomerById(this.CustomerId);
                if (customer != null)
                {
                    this.PictureService.DeletePicture(customer.AvatarID);
                    customer.AvatarID = 0;
                    this.CustomerService.UpdateCustomer(customer);
                    BindData();
                }
            }
            catch (Exception exc)
            {
                ShowError(exc.Message);
            }
        }

        public int CustomerId
        {
            get
            {
                return HozestERPContext.Current.User.CustomerID;
            }
        }
    }
}