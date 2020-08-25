using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageSystem
{
    public partial class BudgetSettingList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员
        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.btnAdd.OnClientClick = "return ShowWindowDetail('预算科目添加','" + CommonHelper.GetStoreLocation()
           + "ManageSystem/BudgetSettingAdd.aspx?Id=-1',400, 220, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";
        }
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //科目名称
            string Name = this.txtName.Text.Trim();
            //是否为管理费用
            int IsCost = Convert.ToInt32(this.ddlIsCost.SelectedValue);

            var list = base.BudgetSettingService.GetBudgetSettingListByData(Name, IsCost);
            //分页
            var PageList = new PagedList<BudgetSetting>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, PageList, paramPageSize + 1);
        }
        #endregion

        /// <summary>
        /// 条件查询
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var budgetSetting = e.Row.DataItem as BudgetSetting;

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('预算科目编辑','" + CommonHelper.GetStoreLocation()
                       + "ManageSystem/BudgetSettingAdd.aspx?Id=" + budgetSetting.ID + "',400, 220, this, function(){document.getElementById('"
                       + this.btnRefresh.ClientID + "').click();});";
                }
            }
        }

        /// <summary>
        /// 删除行数据
        /// </summary>
        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var Info = base.BudgetSettingService.GetBudgetSettingByID(Convert.ToInt32(e.CommandArgument));
                if (Info != null)//删除
                {
                    Info.IsEnabled = true;
                    Info.Updater = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateDate = DateTime.Now;
                    base.BudgetSettingService.UpdateBudgetSetting(Info);

                    //科目名称
                    string Name = this.txtName.Text.Trim();
                    //是否为管理费用
                    int IsCost = Convert.ToInt32(this.ddlIsCost.SelectedValue);

                    var list = base.BudgetSettingService.GetBudgetSettingListByData(Name, IsCost);

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
        /// 审核
        /// </summary>
        protected void btnAudit_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
                return;
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in IDs)
                {
                    var Info = base.BudgetSettingService.GetBudgetSettingByID(item);
                    if (Info != null)
                    {
                        if ((Info.IsCost == null || Info.IsCost == false) && Info.IsEnabled == false)
                        {
                            Info.IsCost = true;
                            Info.Updater = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.BudgetSettingService.UpdateBudgetSetting(Info);
                        }
                        else
                        {
                            base.ShowMessage("此预算科目已加入管理费用！");
                            return;
                        }
                    }
                }
                scope.Complete();
            }
            base.ShowMessage("加入成功！");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 反审核
        /// </summary>
        protected void btnNoAudit_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
                return;
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in IDs)
                {
                    var Info = base.BudgetSettingService.GetBudgetSettingByID(item);
                    if (Info != null)
                    {
                        if (Info.IsCost == true && Info.IsEnabled == false)
                        {
                            Info.IsCost = false;
                            Info.Updater = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.BudgetSettingService.UpdateBudgetSetting(Info);
                        }
                        else
                        {
                            base.ShowMessage("此预算科目还未加入管理费用！");
                            return;
                        }
                    }
                }
                scope.Complete();
            }
            base.ShowMessage("退出成功！");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

    }

}