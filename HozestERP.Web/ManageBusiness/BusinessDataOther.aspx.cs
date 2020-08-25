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
    public partial class BusinessDataOther : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //弹出业务数据导入
                this.btnAdd.OnClientClick = "return ShowWindowDetail('新增','" + CommonHelper.GetStoreLocation() +
            "ManageBusiness/BusinessDataOtherAdd.aspx?ID=0&DataType=0',650,350, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                if (Type == 1)
                {
                    this.ddlFinancial.SelectedValue = "1";
                    this.ddlFinancial.Enabled = false;
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

        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string StrObject = this.txtObject.Text.Trim();
            //string BelongingDep = this.ddlBelongingDep.SelectedValue;
            int AmountType = this.ddlAmountType.SelectedValue;
            string FinancialStatus = this.ddlFinancial.SelectedValue;
            int BusinessType = this.ddlBusinessType.SelectedValue;
            string ContractlStatus = this.ddlContractl.SelectedValue;

            var list = base.XMBusinessDataOtherService.GetXMBusinessDataOtherListByData(StrObject, -1, AmountType, int.Parse(FinancialStatus), BusinessType, int.Parse(ContractlStatus));

            var pageList = new PagedList<XMBusinessDataOther>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

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
                    if (!Delete(int.Parse(e.CommandArgument.ToString())))
                    {
                        base.ShowMessage("数据库不存在该数据！");
                    }

                    string StrObject = this.txtObject.Text.Trim();
                    //string BelongingDep = this.ddlBelongingDep.SelectedValue;
                    int AmountType = this.ddlAmountType.SelectedValue;
                    string FinancialStatus = this.ddlFinancial.SelectedValue;
                    int BusinessType = this.ddlBusinessType.SelectedValue;
                    string ContractlStatus = this.ddlContractl.SelectedValue;

                    var list = base.XMBusinessDataOtherService.GetXMBusinessDataOtherListByData(StrObject, -1, AmountType, int.Parse(FinancialStatus), BusinessType, int.Parse(ContractlStatus));
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
                var info = e.Row.DataItem as XMBusinessDataOther;

                e.Row.Attributes.Add("ondblclick", "return ShowWindowDetail('查看','" + CommonHelper.GetStoreLocation() +
            "ManageBusiness/BusinessDataOtherAdd.aspx?ID=" + info.ID + "&DataType=0',650,330, this, function(){});");

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑','" + CommonHelper.GetStoreLocation() +
            "ManageBusiness/BusinessDataOtherAdd.aspx?ID=" + info.ID + "&DataType=1',650,350, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
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

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in IDs)
                {
                    if (!Delete(item))
                    {
                        base.ShowMessage("数据库不存在该数据！");
                    }
                }
                scope.Complete();
            }
            base.ShowMessage("操作成功！");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        public bool Delete(int ID)
        {
            var Info = base.XMBusinessDataOtherService.GetXMBusinessDataOtherByID(ID);
            if (Info != null)
            {
                Info.IsEnabled = true;
                Info.Updater = HozestERPContext.Current.User.CustomerID;
                Info.UpdateDate = DateTime.Now;
                base.XMBusinessDataOtherService.UpdateXMBusinessDataOther(Info);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnFinancialStatus_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in IDs)
                {
                    var Info = base.XMBusinessDataOtherService.GetXMBusinessDataOtherByID(item);
                    if (Info != null)
                    {
                        Info.FinancialStatus = true;
                        Info.FAuditPerson = HozestERPContext.Current.User.CustomerID;
                        //Info.Updater = HozestERPContext.Current.User.CustomerID;
                        //Info.UpdateDate = DateTime.Now;
                        base.XMBusinessDataOtherService.UpdateXMBusinessDataOther(Info);
                    }
                    else
                    {
                        base.ShowMessage("数据库不存在该数据！");
                        return;
                    }
                }
                scope.Complete();
            }
            base.ShowMessage("操作成功！");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnContractlStatus_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in IDs)
                {
                    var Info = base.XMBusinessDataOtherService.GetXMBusinessDataOtherByID(item);
                    if (Info != null)
                    {
                        if ((bool)Info.FinancialStatus)
                        {
                            Info.ContractlStatus = true;
                            Info.CAuditPerson = HozestERPContext.Current.User.CustomerID;
                            //Info.Updater = HozestERPContext.Current.User.CustomerID;
                            //Info.UpdateDate = DateTime.Now;
                            base.XMBusinessDataOtherService.UpdateXMBusinessDataOther(Info);
                        }
                        else
                        {
                            base.ShowMessage("财务审核后才能进行公司审核！");
                            return;
                        }
                    }
                    else
                    {
                        base.ShowMessage("数据库不存在该数据！");
                        return;
                    }
                }
                scope.Complete();
            }
            base.ShowMessage("操作成功！");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        public int Type
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }
    }
}