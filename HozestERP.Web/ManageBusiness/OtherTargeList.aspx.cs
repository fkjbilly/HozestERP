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
using HozestERP.BusinessLogic.ManageBusiness;

namespace HozestERP.Web.ManageBusiness
{
    public partial class OtherTargeList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                this.btnNickMonthlyTargetAdd.OnClientClick = "return ShowWindowDetail('月度目标录入','" + CommonHelper.GetStoreLocation() +
            "ManageBusiness/OtherTargeAdd.aspx?DepId=" + this.DepartmentId + "&&Type=0"

            + "',600,350, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                BindGrid(1, Master.PageSize);

                //dpDepartment.SelectedValue = this.DepartmentId.ToString();
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string year = this.ddlYear.SelectedValue;//年

            var list = base.XMOtherMonthlyTargetService.GetXMOtherMonthlyTargetListByParm(this.DepartmentId, Convert.ToInt16(year));
            var pageList = new PagedList<XMOtherMonthlyTarget>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            this.Master.BindData(this.grdvClients, pageList);
        }

        public bool getIsAudit(int id)
        {
            bool isAudit = false;
            var Info = base.XMOtherMonthlyTargetService.GetXMOtherMonthlyTargetByID(id);
            if (Info != null)
            {
                isAudit = (bool)Info.IsAudit;
            }
            return isAudit;
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


        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAudit_Click(object sender, EventArgs e)
        {

            List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);
            if (customerInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in customerInfoIDs)
                {

                    var otherMonthlyTaget = base.XMOtherMonthlyTargetService.GetXMOtherMonthlyTargetByID(Convert.ToInt32(ID));
                    if (otherMonthlyTaget != null)
                    {
                        otherMonthlyTaget.IsAudit = true;
                        otherMonthlyTaget.Updater = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        otherMonthlyTaget.UpdateDate = DateTime.Now;
                        base.XMOtherMonthlyTargetService.UpdateXMOtherMonthlyTarget(otherMonthlyTaget);
                    }

                }

                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功成功.");
            }
        }

        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAuditFalse_Click(object sender, EventArgs e)
        {
            List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);
            if (customerInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in customerInfoIDs)
                {

                    var otherMonthlyTaget = base.XMOtherMonthlyTargetService.GetXMOtherMonthlyTargetByID(Convert.ToInt32(ID));
                    if (otherMonthlyTaget != null)
                    {
                        otherMonthlyTaget.IsAudit = false;
                        otherMonthlyTaget.Updater = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        otherMonthlyTaget.UpdateDate = DateTime.Now;
                        base.XMOtherMonthlyTargetService.UpdateXMOtherMonthlyTarget(otherMonthlyTaget);
                    }

                }

                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功成功.");
            }
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
                var info = e.Row.DataItem as XMOtherMonthlyTarget;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;

                if (imgBtnEdit != null)
                {

                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('月度目标值修改','" + CommonHelper.GetStoreLocation() +
              "ManageBusiness/OtherTargeAdd.aspx?DepId=" + info.DepartmentID + "&&Type=1&&Id=" + info.ID
              + "',600,350, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";


                }
            }
        }


        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    var Info = base.XMOtherMonthlyTargetService.GetXMOtherMonthlyTargetByID(Convert.ToInt16(id));
                    if ((bool)!Info.IsAudit)
                    {
                        if (Info != null)
                        {
                            Info.IsEnable = true;
                            Info.Updater = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.XMOtherMonthlyTargetService.UpdateXMOtherMonthlyTarget(Info);
                            base.ShowMessage("操作成功！");
                        }
                        else
                        {
                            base.ShowMessage("未查到该数据！");
                        }
                    }
                    else
                    {
                        base.ShowMessage("已审核，不能删除！");
                    }
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);


                }
            }
            #endregion
        }






        public void SetTrigger()
        {
            //this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnIsAudit.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnIsAuditFalse.UniqueID, this.Page);
        }

        public void Face_Init()
        {

        }


        /// <summary>
        /// 部门id
        /// </summary>
        public int DepartmentId
        {
            get
            {
                return CommonHelper.QueryStringInt("depid");
            }
        }
    }
}