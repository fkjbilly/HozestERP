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
    public partial class CustomerRoleCustomerMapping : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SelectCustomers = base.CustomerService.GetCustomerInfosByCustomerRoleId(this.CustomerRoleID);
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
                base.CustomerService.AddCustomerToRole(customerInfo.CustomerID, this.CustomerRoleID);
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
           // List<CustomerInfo> CustomerInfoAll = base.CustomerService.GetCustomerInfosByCustomerRoleId(this.CustomerRoleID); 
            List<int> CustomerIDList = this.SelectCustomers.Select(p => p.CustomerID).ToList();
            if (CustomerIDList.Count > 0) { 
                foreach (var CustomerID in CustomerIDList)
                {
                    base.CustomerService.RemoveCustomerFromRole(CustomerID, this.CustomerRoleID);
                    var customerInfo = this.SelectCustomers.Where(p => p.CustomerID.Equals(CustomerID)).SingleOrDefault();
                    this.SelectCustomers.Remove(customerInfo); 
                }
            
            }
            this.BindData(); 
            X.MessageBox.Show(new MessageBoxConfig()
            {
                Title = "提示信息",
                Message = "人员删除成功!",
                Icon = MessageBox.Icon.INFO,
                Buttons = MessageBox.Button.OK,
            });
        }

        public List<CustomerInfo> SelectCustomers
        {
            get
            {
                try
                {
                    return (Session["CustomerRoleCustomerMappingSelectCustomer"] as List<CustomerInfo>);
                }
                catch
                {
                }
                return new List<CustomerInfo>();
            }
            set
            {
                Session["CustomerRoleCustomerMappingSelectCustomer"] = value;
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
                base.CustomerService.RemoveCustomerFromRole(customerID, this.CustomerRoleID);
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