using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using HozestERP.Common;
using System.Web.UI.WebControls;
using Ext.Net;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageProject;


namespace HozestERP.Web.ManageProject
{
    public partial class ProjectCustomerDistribution : BaseAdministrationPage, ISearchPage
    {

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
        }


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

        private void BindData()
        {
            var store = this.GridPanel1.GetStore();
            var xMPostList = base.XMNickCustomerMappingService.GetXMNickCustomerMappingList(this.NickId);
            store.DataSource = xMPostList;
            store.DataBind();
        }

        protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.BindData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            List<int> NickIds = new List<int>();
            NickIds.Add(this.NickId);
            if (this.SelectCustomers != null)
            {
                foreach (var customerInfo in this.SelectCustomers)
                {
                    var NickCustomer = base.XMNickCustomerMappingService.GetProjectXMNickCustomerMapping(this.NickId, Convert.ToInt16(customerInfo.DepartmentID), (int)customerInfo.CustomerID);
                    if (NickCustomer == null)
                    {
                        base.XMNickCustomerMappingService.BatchMarkXMNickCustomerMappingsInsert(NickIds, (int)customerInfo.CustomerID, Convert.ToInt16(customerInfo.DepartmentID));
                    }
                }
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

        /// <summary>
        /// 清空搜有人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> IDs = base.XMNickCustomerMappingService.GetNickCustomerIDs(this.NickId);
            try
            {
                if (IDs != null)
                {
                    foreach (var id in IDs)
                    {
                        var xMScalpingApplication = base.XMNickCustomerMappingService.GetXMNickCustomerMappingByNickCustomerID(id);
                        if (xMScalpingApplication != null)//删除
                        {
                            base.XMNickCustomerMappingService.DeleteXMNickCustomerMapping(id);
                        }
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
            catch (Exception err)
            {
                base.ProcessException(err);
            }
        }

        [DirectMethod(Namespace = "CompanyX")]
        public void DeleteCustomer(int nickCustomerID)
        {
            try
            {
                var xMScalpingApplication = base.XMNickCustomerMappingService.GetXMNickCustomerMappingByNickCustomerID(nickCustomerID);
                if (xMScalpingApplication != null)//删除
                {
                    base.XMNickCustomerMappingService.DeleteXMNickCustomerMapping(nickCustomerID);
                }
                //var customerInfo = this.SelectCustomers.Where(p => p.CustomerID.Equals(customerID)).SingleOrDefault();
                //this.SelectCustomers.Remove(customerInfo);
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

        public int NickId
        {
            get
            {
                return CommonHelper.QueryStringInt("nick_id");
            }
        }

        public List<CustomerInfo> SelectCustomers
        {
            get
            {
                try
                {
                    return (Session["ProjectCustomerDistributionSelectCustomer"] as List<CustomerInfo>);
                }
                catch
                {
                }
                return new List<CustomerInfo>();
            }
            set
            {
                Session["ProjectCustomerDistributionSelectCustomer"] = value;
            }
        }

        private int CustomerRoleID
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerRoleID");
            }
        }

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

    }
}