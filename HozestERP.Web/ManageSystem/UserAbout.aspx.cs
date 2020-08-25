using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.Web
{
    public partial class UserAbout : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.CustomerID > 0)
            {
                var customerinfo = base.CustomerInfoService.GetCustomerInfoByID(this.CustomerID);
                if (customerinfo != null)
                {
                    int avatarpictureid = 0;
                    if (customerinfo.SCustomer != null)
                    {
                        this.lblEmail.Text = customerinfo.SCustomer.Email;
                        avatarpictureid = customerinfo.SCustomer.AvatarID;
                    }
                    else
                    {
                        if (customerinfo.Gender.CodeName == "男")
                        {
                            avatarpictureid = base.SettingManager.GetSettingValueInteger("Media.DefaultImageName.Man");
                        }
                        else
                        {
                            avatarpictureid = base.SettingManager.GetSettingValueInteger("Media.DefaultImageName.Woman");
                        }
                    }


                    this.imgProduct.ImageUrl = base.PictureService.GetPictureUrl(avatarpictureid, 100);

                    var department = customerinfo.SDepartment;
                    while (true)
                    {
                        if (department == null)
                            break;
                        if (department.DepManagerID == this.CustomerID)
                        {
                            this.lblDepartment.Text = department.DepName + "（部门负责人）";
                        }
                        else
                        {
                            this.lblDepartment.Text = department.DepName;
                        }
                        department = department.ParentDepartment;
                    }
                    this.lblFullName.Text = customerinfo.FullName;

                    if (customerinfo.Gender != null)
                        this.lblGender.Text = customerinfo.Gender.CodeName;
                    if(customerinfo.Birthday.HasValue)
                        this.lblBirthday.Text = customerinfo.Birthday.Value.ToString("yyyy-MM-dd");                 
                }
            }
        }       

        #region IEditPage 成员

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        #endregion

        public int CustomerID
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerID");
            }
        }

    }
}