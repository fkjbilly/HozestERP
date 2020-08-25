using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using System.Text;

namespace HozestERP.Web.ManageSystem
{
    public partial class PsnAvatarEdit : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var customer = HozestERPContext.Current.User;
            if (customer.AvatarID > 0)
            {
                this.imgUpload.PictureID = Convert.ToInt32(customer.AvatarID);
            }
            else
            {
                this.imgUpload.PictureID = this.SettingManager.GetSettingValueInteger("Media.Product.DefaultPicture");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var customer = HozestERPContext.Current.User;
            if (this.imgUpload.SelectPicture != null)
                customer.AvatarID = this.imgUpload.SelectPicture.PictureID;
            base.CustomerService.UpdateCustomer(customer);

            StringBuilder editButtonJs = new StringBuilder();
            editButtonJs.AppendLine("<script type=\"text/javascript\">");
            editButtonJs.AppendLine(" alert('保存成功.'); ");
            editButtonJs.AppendLine("</script>");
            Page.ClientScript.RegisterStartupScript(GetType(), "key", editButtonJs.ToString());
        }
    }
}