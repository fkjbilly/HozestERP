using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.Web.ManageCustomer
{
    public partial class CustomerDetail : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.CustomerID > 0)
            {
                var customerinfo = base.CustomerInfoService.GetCustomerInfoByID(this.CustomerID);
                if (customerinfo != null)
                {
                    int avatarpictureid = 0;
                    if (customerinfo.SCustomer.AvatarID > 0)
                    {
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
                        this.lblDepartment.Text = department.DepCode + " " + department.DepName + "&nbsp;\\&nbsp;" + this.lblDepartment.Text;
                        department = department.ParentDepartment;
                    }

                    this.lblCustomerStatus.Text = CommonHelper.GetDescription(customerinfo.CustomerStatus);
                    this.lblJobNumber.Text = customerinfo.JobNumber;
                    this.lblFullName.Text = customerinfo.FullName;

                    if (customerinfo.Gender != null)
                        this.lblGender.Text = customerinfo.Gender.CodeName;
                    if (customerinfo.Nationality != null)
                        this.lblNationality.Text = customerinfo.Nationality.CodeName;
                    if (customerinfo.Animal != null)
                        this.lblAnimal.Text = customerinfo.Animal.CodeName;
                    this.lblRegisteredResidence.Text = customerinfo.RegisteredResidence;
                    if (customerinfo.Birthday.HasValue)
                        this.lblBirthday.Text = customerinfo.Birthday.GetValueOrDefault().ToString("yyyy-MM-dd");
                    if (customerinfo.Marriage != null)
                        this.lblMarriage.Text = customerinfo.Marriage.CodeName;
                    this.lblChildbearing.Text = customerinfo.Childbearing ? "是" : "否";
                    if (customerinfo.BloodType != null)
                        this.lblBloodType.Text = customerinfo.BloodType.CodeName;
                    if (customerinfo.PoliticalStatus != null)
                        this.lblPoliticalStatus.Text = customerinfo.PoliticalStatus.CodeName;
                    this.lblStature.Text = customerinfo.Stature.ToString("F2");
                }
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SettrEditHeadVisible = false;
            this.Master.SetTitle("人员基本信息");
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