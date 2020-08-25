using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Codes;
using HozestERP.Common.Utils;
using HozestERP.Common;

namespace HozestERP.Web.ManageCustomer
{
    public partial class CustomerSearch : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonMethod.DropDownListDepartment(this.ddlDepartment, true);
                this.btnAdd.OnClientClick = "return ShowNewTabDetail('" + HozestERP.Common.Utils.CommonHelper.GetStoreLocation() + "ManageCustomer/customerinfoquickadd.aspx','','用户新增')";
                //this.BindGrid();
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnAdd.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnDelete.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitle("用户查询");
            this.btnDelete.Attributes.Add("onclick", "return CheckSelect(this,99);");
            this.btnAdd.OnClientClick = "return ShowDetail('" + CommonHelper.GetStoreLocation() + "ManageCustomer/CustomerInfoQuickAdd.aspx', '242', '用户基本资料新增');";
        }


        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
                //this.Master.BindData<CustomerInfo>(this.grdvMessage
                //    , base.CustomerInfoService.GetCustomerInfo( this.txtFullName.Text.Trim()
                //    , this.ddlDepartment.SelectedValue, this.chkChildDepartment.Checked, true
                //    , this.ddlGender.SelectedValue,this.chkDelete.Checked
                //    , paramPageIndex, paramPageSize));
            string DepartmentID = this.ddlDepartment.SelectedValue;//部门
            string FullName = this.txtFullName.Text.Trim();//姓名
            int Gender = this.ddlGender.SelectedValue;//性别
            bool Deleted = this.chkDelete.Checked;//是否已删除
            List<string> DepIdList = new List<string>();
            List<CustomerInfo> List = new List<CustomerInfo>();
            if (DepartmentID != "-1")
            {
                DepIdList = DepartmentIdList(int.Parse(DepartmentID), DepIdList);
                foreach (string one in DepIdList)
                {
                    var list = base.CustomerInfoService.GetCustomerInfoListInSearch(int.Parse(one), FullName, Gender, Deleted);
                    foreach (CustomerInfo two in list)
                    {
                        List.Add(two);
                    }
                }
            }
            else
            {
                List = base.CustomerInfoService.GetCustomerInfoListInSearch(int.Parse(DepartmentID), FullName, Gender, Deleted);
            }
            var pageList = new PagedList<CustomerInfo>(List, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            this.Master.BindData(this.grdvMessage, pageList);
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

        //private void BindGrid()
        //{
        //    this.BindGrid(1, this.Master.PageSize);
        //}
        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvMessage);
            if (customerInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            base.CustomerInfoService.MarkCustomerInfoAsDeleted(customerInfoIDs);
            base.ShowMessage("删除成功.");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        protected void grdvMessage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }

        protected void grdvMessage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var customer = e.Row.DataItem as CustomerInfo;
                ImageButton imgbtnDetail = e.Row.FindControl("imgbtnDetail") as ImageButton;
                if (imgbtnDetail != null)
                {
                    imgbtnDetail.OnClientClick = "return ShowNewTabDetail('" + HozestERP.Common.Utils.CommonHelper.GetStoreLocation() + "ManageCustomer/CustomerInfoDetail.aspx?CustomerID=" + imgbtnDetail.CommandArgument.ToString() 
                        + "','CustomerInfo" + imgbtnDetail.CommandArgument.ToString() + "','" + customer.FullName + " 详细基本资料修改')";
                }
            }
        }


        /// <summary>
        /// 清空数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDataEmpty_Click(object sender, EventArgs e)
        {
           
        }

        //protected void btnOppositeDelete_Click(object sender, EventArgs e)
        //{
        //    List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvMessage);
        //    if (customerInfoIDs.Count <= 0)
        //    {
        //        base.ShowError("您没有选择任何记录!");
        //        return;
        //    }
        //    base.CustomerInfoService.MarkCustomerInfoAsOppositeDeleted(customerInfoIDs);
        //    base.ShowMessage("反删除成功.");
        //    this.BindGrid();
        //}
    }
}