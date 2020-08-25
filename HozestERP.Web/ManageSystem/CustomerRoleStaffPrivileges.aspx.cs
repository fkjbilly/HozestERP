using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.Web.ManageSystem
{
    public partial class CustomerRoleStaffPrivileges : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SelectCustomers = base.CustomerService.GetCustomerRoleStaffPrivilegesByCustomerId(this.CustomerRoleID);
            }
            if (!X.IsAjaxRequest)
            {
                this.BindData();
            }
        }

        protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.BindData();
        }

        private void BindData()
        {
            var store = this.GridPanel1.GetStore();

            store.DataSource = this.SelectCustomers;
            store.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (var customerInfo in this.SelectCustomers)
            {
                base.CustomerService.AddCustomerToRoleStaffPrivileges(customerInfo.CustomerID, this.CustomerRoleID);
            }

            X.MessageBox.Show(new MessageBoxConfig()
            {
                Title = "提示信息",
                Message = "人员添加成功!",
                Icon = MessageBox.Icon.INFO,
                Buttons = MessageBox.Button.OK,
            });

            this.BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var customerRole = base.CustomerService.GetCustomerRoleById(this.CustomerRoleID);
            customerRole.SCustomerRoleStaffPrivileges.Clear();
            base.CustomerService.UpdateCustomerRole(customerRole);

            X.MessageBox.Show(new MessageBoxConfig()
            {
                Title = "提示信息",
                Message = "清空所有人员成功!",
                Icon = MessageBox.Icon.INFO,
                Buttons = MessageBox.Button.OK,
            });

            this.BindData();
        }

        public List<CustomerInfo> SelectCustomers
        {
            get
            {
                try
                {
                    return (Session["CustomerRoleStaffPrivilegesSelectCustomer"] as List<CustomerInfo>);
                }
                catch
                {
                }
                return new List<CustomerInfo>();
            }
            set
            {
                Session["CustomerRoleStaffPrivilegesSelectCustomer"] = value;
            }
        }

        private int CustomerRoleID
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerRoleID");
            }
        }

        [DirectMethod(Namespace = "CompanyX")]
        public void DeleteCustomer(int customerID)
        {
            try
            {
                base.CustomerService.RemoveCustomerFromRoleStaffPrivileges(customerID, this.CustomerRoleID);
                var customerInfo = this.SelectCustomers.Where(p => p.CustomerID.Equals(customerID)).SingleOrDefault();
                this.SelectCustomers.Remove(customerInfo);
                this.BindData();
                X.MessageBox.Show(new MessageBoxConfig()
                {
                    Title = "提示信息",
                    Message = "人员删除成功!",
                    Icon = MessageBox.Icon.INFO,
                    Buttons = MessageBox.Button.OK,
                });
            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }
        }
    }
}