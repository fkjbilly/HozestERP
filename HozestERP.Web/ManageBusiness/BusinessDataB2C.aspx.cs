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
    public partial class BusinessDataB2C : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //弹出业务数据导入
            //    this.btnImportBusinessDataB2C.OnClientClick = "return ShowWindowDetail('B2B业务数据导入','" + CommonHelper.GetStoreLocation() +
            //"ManageBusiness/ImportBusinessDataB2C.aspx',500,280, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                //新增合同信息页面
                this.btnAdd.Attributes.Add("onclick", "return ShowNewTabDetail('"
                                    + CommonHelper.GetStoreLocation()
                                    + "ManageBusiness/BusinessDataB2CDetail.aspx?ID=0&Type=0"
                                    + "','Add" + "','" + "新增合同信息');");

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
            string ContractNumber = this.txtContractNumber.Text.Trim();
            string ClientCompany = this.txtClientCompany.Text.Trim();
            string BelongingPeople = this.txtBelongingPeople.Text.Trim();
            string FinancialStatus = this.ddlFinancialStatus.SelectedValue;

            var list = base.XMBusinessDataService.GetXMBusinessDataListByData(ContractNumber, ClientCompany, BelongingPeople, 63);
            if (FinancialStatus != "-1")
            {
                if (FinancialStatus == "1")
                {
                    list = list.Where(p => p.FinancialStatus == true).ToList<XMBusinessData>();
                }
                else
                {
                    list = list.Where(p => p.FinancialStatus == false).ToList<XMBusinessData>();
                }
            }

            var pageList = new PagedList<XMBusinessData>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

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

                    string ContractNumber = this.txtContractNumber.Text.Trim();
                    string ClientCompany = this.txtClientCompany.Text.Trim();
                    string BelongingPeople = this.txtBelongingPeople.Text.Trim();
                    string FinancialStatus = this.ddlFinancialStatus.SelectedValue;

                    var list = base.XMBusinessDataService.GetXMBusinessDataListByData(ContractNumber, ClientCompany, BelongingPeople, 63);
                    if (FinancialStatus != "-1")
                    {
                        if (FinancialStatus == "1")
                        {
                            list = list.Where(p => p.FinancialStatus == true).ToList<XMBusinessData>();
                        }
                        else
                        {
                            list = list.Where(p => p.FinancialStatus == false).ToList<XMBusinessData>();
                        }
                    }

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
                var info = e.Row.DataItem as XMBusinessData;

                e.Row.Attributes.Add("ondblclick", "return ShowNewTabDetail('"
                                    + CommonHelper.GetStoreLocation()
                                    + "ManageBusiness/BusinessDataB2CDetail.aspx?ID=" + info.ID + "&Type=0"
                                    + "','Search" + info.ID + "','" + "合同信息查看');");

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.Attributes.Add("onclick", "return ShowNewTabDetail('"
                                    + CommonHelper.GetStoreLocation()
                                    + "ManageBusiness/BusinessDataB2CDetail.aspx?ID=" + info.ID + "&Type=1"
                                    + "','Edit" + info.ID + "','" + "合同信息修改');");
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
            List<int> BusinessDataIDs = this.Master.GetSelectedIds(this.grdvClients);
            if (BusinessDataIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in BusinessDataIDs)
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
            var Info = base.XMBusinessDataService.GetXMBusinessDataByID(ID);
            if (Info != null)
            {
                var List = base.XMBusinessDataDetailService.GetXMBusinessDataDetailListByBusinessDataID(Info.ID);
                if (List != null && List.Count > 0)
                {
                    foreach (XMBusinessDataDetail a in List)
                    {
                        a.IsEnabled = true;
                        a.Updater = HozestERPContext.Current.User.CustomerID;
                        a.UpdateDate = DateTime.Now;
                        base.XMBusinessDataDetailService.UpdateXMBusinessDataDetail(a);
                    }
                }
                Info.IsEnabled = true;
                Info.Updater = HozestERPContext.Current.User.CustomerID;
                Info.UpdateDate = DateTime.Now;
                base.XMBusinessDataService.UpdateXMBusinessData(Info);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}