using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Top.Api.Domain;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.Common;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Codes;
using System.Text.RegularExpressions;
using JdSdk.Domains;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using JdSdk.Domain;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using System.Security.Cryptography;

using Yhd.Api.Object;
using Yhd.Api;
using Yhd.Api.Request;
using Yhd.Api.Response;
using System.Reflection;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMCustomerServiceLevelList : BaseAdministrationPage, ISearchPage
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
            //this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnSynchronousOrderData.UniqueID, this.Page);
        }
        public void Face_Init()
        {
            this.btnAdd.OnClientClick = "return ShowWindowDetail('客服等级添加','" + CommonHelper.GetStoreLocation()
           + "ManageCustomerService/XMCustomerServiceLevelAdd.aspx?XMCustomerServiceLevelId=-1',500, 300, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";
        }
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            //等级名称
            string rank_name = this.RankName.Text;

            //根据等级名称查询
            var xMProjectList = base.XMCustomerServiceLevelService.GetXMCustomerServiceLevelList(rank_name);
            //分页
            var xMProjectPageList = new PagedList<XMCustomerServiceLevel>(xMProjectList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            //this.gvXMProjectList.EditIndex = xMProjectPageList.Count();
            // xMProjectPageList.Add(new XMProject());
            this.Master.BindData(this.grdvClients, xMProjectPageList, paramPageSize + 1);
        }
        #endregion

        /// <summary>
        /// 条件查询
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
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var xMScalpingApplication = e.Row.DataItem as XMCustomerServiceLevel;

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('客服等级编辑','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomerService/XMCustomerServiceLevelAdd.aspx?XMCustomerServiceLevelId=" + xMScalpingApplication.Id + "',500, 300, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";

                }

            }
        }
        /// <summary>
        /// 删除行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Delete"))
            {
                var orderinfoapp = base.XMCustomerServiceLevelService.GetXMCustomerServiceLevelById(Convert.ToInt32(e.CommandArgument));
                var customerServiceLevelList = base.XMCustomerRankService.GetXMCustomerRankByID(Convert.ToInt32(e.CommandArgument));
                if (orderinfoapp != null)//删除
                {
                    orderinfoapp.IsEnabled = true;
                    orderinfoapp.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.UpdateTime = DateTime.Now;
                    base.XMCustomerServiceLevelService.UpdateXMCustomerServiceLevel(orderinfoapp);

                    //等级名称
                    string rank_name = this.RankName.Text;

                    //根据等级名称查询。
                    var xMProjectList = base.XMCustomerServiceLevelService.GetXMCustomerServiceLevelList(rank_name);
                    int rowscount = xMProjectList.Count();//获取行数;
                    if (rowscount % this.Master.PageSize == 0)
                    { this.BindGrid(this.Master.PageIndex - 1, this.Master.PageSize); }
                    else
                    { this.BindGrid(this.Master.PageIndex, this.Master.PageSize); }
                    if (customerServiceLevelList != null)
                    {
                        for (int i = 0; i < customerServiceLevelList.Count;i++)
                        {
                            XMCustomerRank customerWangNo = customerServiceLevelList[i];
                            customerWangNo.IsEnabled = true;
                            customerWangNo.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            customerWangNo.UpdateTime = DateTime.Now;
                            base.XMCustomerRankService.UpdateXMCustomerRank(customerWangNo);
                        }
                    }
                    base.ShowMessage("操作成功.");
                }

            }
            #endregion
        }
        /// <summary>
        /// 删除行数据之前执行的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}