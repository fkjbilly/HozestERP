using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using System.Transactions;
using HozestERP.BusinessLogic.Customers;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.Web.ManageCustomer
{
    public partial class CustomerSalary : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //弹出人员薪资导入页面
                this.btnImportCustomerSalary.OnClientClick = "return ShowWindowDetail('人员薪资导入','" + CommonHelper.GetStoreLocation() +
            "ManageCustomer/ImportCustomerSalary.aspx',500,280, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                if (DateTime.Now.Month == 1)
                {
                    this.ddlYear.SelectedValue = (DateTime.Now.Year - 1).ToString();
                    this.ddlMonth.SelectedValue = "12";
                }
                else
                {
                    this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                    this.ddlMonth.SelectedValue = (DateTime.Now.Month - 1).ToString();
                }

                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            //部门
            CommonMethod.DropDownListDepartment(this.ddlDepartment, true);
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string DepartmentID = this.ddlDepartment.SelectedValue;//部门
            string FullName = this.ddlFullName.Text.Trim();//姓名
            string Year = this.ddlYear.SelectedValue;//年
            string Month = this.ddlMonth.SelectedValue;//月
            List<string> DepIdList = new List<string>();
            List<CustomerSalaryAll> List = new List<CustomerSalaryAll>();
            List<CustomerSalaryAll> RealList = new List<CustomerSalaryAll>();
            if (DepartmentID != "-1")
            {
                DepIdList = DepartmentIdList(int.Parse(DepartmentID), DepIdList);
                foreach (string one in DepIdList)
                {
                    var list = base.CustomerSalaryService.GetCustomerSalaryListByData(int.Parse(one), FullName, int.Parse(Year), int.Parse(Month));
                    foreach (CustomerSalaryAll two in list)
                    {
                        List.Add(two);
                    }
                }
            }
            else
            {
                List = base.CustomerSalaryService.GetCustomerSalaryListByData(int.Parse(DepartmentID), FullName, int.Parse(Year), int.Parse(Month));
            }

            List<int> CustomerIDList = new List<int>();
            int CustomerID = HozestERPContext.Current.User.CustomerID;
            var RoleList = base.CustomerService.GetRolesByCustomerId(CustomerID);

            int[] IntList = { 10000068 };//薪资专员
            List<CustomerRole> RoleIDList = new List<CustomerRole>();
            foreach (int one in IntList)
            {
                if (RoleList != null && RoleList.Count > 0)
                {
                    foreach (CustomerRole two in RoleList)
                    {
                        if (one == two.CustomerRoleID)
                        {
                            CustomerRole role = new CustomerRole();
                            role.CustomerRoleID = one;
                            RoleIDList.Add(role);
                        }
                    }
                }
            }

            if (RoleIDList != null && RoleIDList.Count > 0)
            {
                List<string> DepId = new List<string>();
                foreach (CustomerRole one in RoleIDList)
                {
                    List<string> RoleId = new List<string>();
                    RoleId = CustomerRoleIdList(one.CustomerRoleID, RoleId);
                    foreach (string two in RoleId)
                    {
                        var DepList = base.EnterpriseService.GetDepartmentListByRoleID(int.Parse(two));
                        if (DepList != null && DepList.Count > 0)
                        {
                            foreach (Department three in DepList)
                            {
                                List<string> dep = new List<string>();
                                dep = DepartmentIdList(three.DepartmentID, dep);
                                if (dep != null && dep.Count > 0)
                                {
                                    foreach (string four in dep)
                                    {
                                        DepId.Add(four);
                                    }
                                }
                            }
                        }

                        var customerlist = base.CustomerService.GetCustomerInfosByRoleID(int.Parse(two));
                        if (customerlist != null && customerlist.Count > 0)
                        {
                            foreach (CustomerInfo customerId in customerlist)
                            {
                                CustomerIDList.Add(customerId.CustomerID);
                            }
                        }
                    }
                }
                DepId = DepId.Distinct().ToList();
                foreach (string one in DepId)
                {
                    var CustomerIDAll = base.CustomerInfoService.GetCustomerInfoListByDepId(int.Parse(one));
                    if (CustomerIDAll != null && CustomerIDAll.Count > 0)
                    {
                        foreach (CustomerInfo two in CustomerIDAll)
                        {
                            CustomerIDList.Add(two.CustomerID);
                        }
                    }
                }
                CustomerIDList = CustomerIDList.Distinct().ToList();
            }

            if (List != null && List.Count > 0)
            {
                foreach (CustomerSalaryAll info in List)
                {
                    if (CustomerIDList.IndexOf((int)info.CustomerInfoID) != -1 || info.CustomerInfoID == CustomerID)
                    {
                        RealList.Add(info);
                    }
                }
            }

            var pageList = new PagedList<CustomerSalaryAll>(RealList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            this.Master.BindData(this.grdvClients, pageList);
        }

        #endregion

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))//删除
                {
                    base.CustomerSalaryService.DeleteCustomerSalary(Convert.ToInt32(e.CommandArgument));

                    string DepartmentID = this.ddlDepartment.SelectedValue;//部门
                    string FullName = this.ddlFullName.Text.Trim();//姓名
                    string Year = this.ddlYear.SelectedValue;//年
                    string Month = this.ddlMonth.SelectedValue;//月

                    var list = base.CustomerSalaryService.GetCustomerSalaryListByData(int.Parse(DepartmentID), FullName, int.Parse(Year), int.Parse(Month));
                    int rowscount = list.Count();//获取行数;

                    if (rowscount % this.Master.PageSize == 0)
                    {
                        this.BindGrid(this.Master.PageIndex - 1, this.Master.PageSize);
                    }
                    else
                    {
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    }

                    base.ShowMessage("操作成功！");
                }
            }
            #endregion
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as CustomerSalaryAll;


                e.Row.Attributes.Add("ondblclick", "return ShowWindowDetail('人员薪资查看','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomer/CustomerSalaryDetail.aspx?ID=" + info.ID + "&Type=0&Year=" + this.ddlYear.SelectedValue + "&Month=" + this.ddlMonth.SelectedValue + "',750, 525, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});");

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('人员薪资修改','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomer/CustomerSalaryDetail.aspx?ID=" + info.ID + "&Type=1&Year=" + this.ddlYear.SelectedValue + "&Month=" + this.ddlMonth.SelectedValue + "',750, 550, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }

            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        public List<string> DepartmentIdList(int DepartmentID, List<string> DepIdList)
        {
            DepIdList.Add(DepartmentID.ToString());
            var list = base.CustomerSalaryService.GetDepartmentIDByID(DepartmentID);
            if (list != null && list.Count > 0)
            {
                foreach (Department one in list)
                {
                    DepartmentIdList(one.DepartmentID, DepIdList);
                }
            }
            return DepIdList;
        }

        public List<string> CustomerRoleIdList(int CustomerRoleID, List<string> RoleId)
        {
            RoleId.Add(CustomerRoleID.ToString());
            var list = base.CustomerSalaryService.GetCustomerRoleIDByParentsID(CustomerRoleID);
            if (list != null && list.Count > 0)
            {
                foreach (CustomerRole one in list)
                {
                    CustomerRoleIdList(one.CustomerRoleID, RoleId);
                }
            }
            return RoleId;
        }
    }
}