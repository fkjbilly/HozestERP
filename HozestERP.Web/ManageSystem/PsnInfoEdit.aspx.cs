using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using System.Text;

using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageSystem
{
    public partial class PsnInfoEdit : BaseAdministrationPage,IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInfo();
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitleTabPanelVisible = false;
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSave.UniqueID, this.Page);
        }

        #endregion
        /// <summary>
        /// 绑定信息
        /// </summary>
        protected void BindInfo()
        {
            var customer = HozestERPContext.Current.User;
            if (customer == null)
                return;
            var customerInfo = customer.SCustomerInfo;
            this.txtName.Text = customerInfo.FullName;
            //CommonHelper.SelectListItem(this.ddlGender, customerInfo.GenderID);
            this.txtDate.SelectedDate = customerInfo.Birthday;
            this.txtEmail.Text = customer.Email;
            this.ddlGender.SelectedValue = customerInfo.GenderID;
            this.btnIDNumber.Text = customerInfo.IDNumber;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var customerInfo = base.CustomerInfoService.GetCustomerInfoByID(HozestERPContext.Current.User.CustomerID);
                if (customerInfo == null)
                    return;
                customerInfo.GenderID = ddlGender.SelectedValue;
                customerInfo.Birthday = txtDate.SelectedDate;
                customerInfo.IDNumber = this.btnIDNumber.Text.Trim();
                base.CustomerInfoService.UpdateCustomerInfo(customerInfo);

                var customer = HozestERPContext.Current.User;
                if (customer == null)
                    return;
                customer.Email = txtEmail.Text;
                base.CustomerService.UpdateCustomer(customer);
                base.ShowMessage("保存成功。");

            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }
        }
    }
}