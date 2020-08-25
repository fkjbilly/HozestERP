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
    public partial class XMDSRList : BaseAdministrationPage, ISearchPage
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
            this.ddlPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));

            this.ddlNickId.Items.Clear();
            var NickList = base.XMNickService.GetXMNickList();
            var newNickList = NickList.Where(p => p.isEnable == true).ToList();
            this.ddlNickId.DataSource = newNickList;
            this.ddlNickId.DataTextField = "nick";
            this.ddlNickId.DataValueField = "nick_id";
            this.ddlNickId.DataBind();
            this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));

            this.btnAdd.OnClientClick = "return ShowWindowDetail('DSR添加','" + CommonHelper.GetStoreLocation()
           + "ManageCustomerService/XMDSRAdd.aspx?XMDSRId=-1',500, 300, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";
        }
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            //项目名称
            int NickId = Convert.ToInt32(this.ddlNickId.SelectedValue);
            //平台类型
            int PlatformTypeId =Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue);
            //月份
            string Month = this.ddlMonth.Value.ToString();

            //根据项目名称和平台类型查询。
            var xMProjectList = base.XMDSRService.GetXMDSRList(NickId, PlatformTypeId, Month);
            
            //分页
            var xMProjectPageList = new PagedList<XMDSR>(xMProjectList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
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
                var xMScalpingApplication = e.Row.DataItem as XMDSR;

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('DSR编辑','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomerService/XMDSRAdd.aspx?XMDSRId=" + xMScalpingApplication.ID + "',500, 300, this, function(){document.getElementById('"
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
                //var xMScalpingApplication = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(Convert.ToInt32(e.CommandArgument));
                var orderinfoapp = base.XMDSRService.GetXMDSRByID(Convert.ToInt32(e.CommandArgument));
                if (orderinfoapp != null)//删除
                {
                    orderinfoapp.IsEnabled = true;
                    orderinfoapp.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.UpdateTime = DateTime.Now;
                    base.XMDSRService.UpdateXMDSR(orderinfoapp);

                    //项目名称
                    int NickId = Convert.ToInt32(this.ddlNickId.SelectedValue);
                    //平台类型
                    int PlatformTypeId = Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue);
                    //月份
                    string Month = this.ddlMonth.Value.ToString();

                    var xMProjectList = base.XMDSRService.GetXMDSRList(NickId, PlatformTypeId, Month);
                    int rowscount = xMProjectList.Count();//获取行数;
                    if (rowscount % this.Master.PageSize == 0)
                    { 
                        this.BindGrid(this.Master.PageIndex-1, this.Master.PageSize); 
                    }
                    else
                    {
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize); 
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