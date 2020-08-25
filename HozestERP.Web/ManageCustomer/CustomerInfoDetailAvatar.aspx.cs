using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using System.Text;

using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageCustomer
{
    public partial class CustomerInfoDetailAvatar : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var customer = base.CustomerService.GetCustomerById(this.CustomerID);
            this.imgUpload.PictureID = customer.AvatarID;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var customer = base.CustomerService.GetCustomerById(this.CustomerID);
            if (this.imgUpload.SelectPicture != null)
                customer.AvatarID = this.imgUpload.SelectPicture.PictureID;
            base.CustomerService.UpdateCustomer(customer);

            StringBuilder editButtonJs = new StringBuilder();
            editButtonJs.AppendLine("<script type=\"text/javascript\">");
            editButtonJs.AppendLine(" alert('保存成功.');window.close(); ");
            editButtonJs.AppendLine("</script>");
            Page.ClientScript.RegisterStartupScript(GetType(), "key", editButtonJs.ToString());
        }

        public int CustomerID
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerID");
            }
        }
    }
}