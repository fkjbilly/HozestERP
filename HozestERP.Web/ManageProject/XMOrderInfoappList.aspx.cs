using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Top.Api.Domain;
using HozestERP.BusinessLogic.ManageProject;
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

namespace HozestERP.Web.ManageProject
{
    public partial class XMorderInfoappList : BaseAdministrationPage, ISearchPage
    {
        //private string orderstatus = "";
        //protected override Dictionary<string, string> ButtonSecuritys
        //{
        //    get
        //    {
        //        Dictionary<string, string> buttons = new Dictionary<string, string>();
        //        //buttons.Add("btnSearch", "ManageProject.XMOrderInfoappList.Search");//查询
        //        //buttons.Add("imgbtnOrderInfoDetail", "ManageProject.XMOrderInfoList.SeeXMOrderInfoDetail");//详情
        //        //buttons.Add("btnImportingPage", "ManageProject.XMOrderInfoList.ImportingPage");//导入数据
        //        //buttons.Add("imgBtnDelete", "ManageProject.XMOrderInfoList.XMOrderInfoDelete");//删除
        //        //buttons.Add("btnAllIsAudit", "ManageProject.XMOrderInfoList.AllIsAudit"); //批量审单
        //        //buttons.Add("btnSynchronousOrderData", "ManageProject.XMOrderInfoList.SynchronousOrderData"); //数据同步
        //        //buttons.Add("imgbtnOperatingRecords", "ManageProject.XMOrderInfoList.OperatingRecords"); //操作记录
        //        return buttons;
        //    }
        //}
        
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
            //  this.Master.SetTrigger(this.btnSynchronousOrderData.UniqueID, this.Page);


        }
        public void Face_Init()
        {
            this.ddlPlatformTypeId.Items.Clear();
            var codePlatformTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatformTypeId.DataSource = codePlatformTypeList;
            this.ddlPlatformTypeId.DataTextField = "CodeName";
            this.ddlPlatformTypeId.DataValueField = "CodeID";
            this.ddlPlatformTypeId.DataBind();
            this.ddlPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));

            this.ddlNickId.Items.Clear();
            var NickList = base.XMNickService.GetXMNickList();
            var newNickList = NickList.Where(p => p.isEnable == true).ToList();
            this.ddlNickId.DataSource = newNickList;
            this.ddlNickId.DataTextField = "nick";
            this.ddlNickId.DataValueField = "nick_id";
            this.ddlNickId.DataBind();
            this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));

            this.btnAdd.OnClientClick = "return ShowWindowDetail('AppKey申请','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMOrderInfoappAdd.aspx?XMOrderInfoAppId=-1',1000, 390, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";
        }
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            //店铺名称
            int NickId = Convert.ToInt32(this.ddlNickId.SelectedValue);
            //平台类型
            int PlatformTypeId =Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue);

            //根据 店铺名称和平台类型查询。
            var xMProjectList = base.XMOrderInfoAppService.GetXMProjectList(NickId, PlatformTypeId);
            //var xMProjectList = base.XMProjectService.GetXMProjectList(NickId, PlatformTypeId);
            //分页
            var xMProjectPageList = new PagedList<XMOrderInfoApp>(xMProjectList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
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
                var xMScalpingApplication = e.Row.DataItem as XMOrderInfoApp;

                #region 说明
                //Label lblExplanation = e.Row.FindControl("lblExplanation") as Label;
                //if (xMScalpingApplication.Explanation != null && xMScalpingApplication.Explanation != "")
                //{
                //    if (xMScalpingApplication.Explanation.Length > 8)
                //    {
                //        //var SdeliveryAddress = CutStr(deliveryAddress, 20);
                //        string strExplanation = xMScalpingApplication.Explanation.ToString().Substring(0, 8);
                //        lblExplanation.Text = strExplanation + "...";
                //        lblExplanation.ToolTip = xMScalpingApplication.Explanation.ToString();
                //    }
                //    else
                //    {
                //        lblExplanation.Text = xMScalpingApplication.Explanation.ToString();
                //        lblExplanation.ToolTip = xMScalpingApplication.Explanation.ToString();
                //    }
                //}
                //else
                //{
                //    lblExplanation.Text = "";

                //}
                #endregion

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('AppKey编辑','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/XMOrderInfoappAdd.aspx?XMOrderInfoAppId=" + xMScalpingApplication.ID + "',1000, 415, this, function(){document.getElementById('"
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
                var orderinfoapp = base.XMOrderInfoAppService.GetXMOrderInfoAppByID(Convert.ToInt32(e.CommandArgument));
                if (orderinfoapp != null)//删除
                {
                    orderinfoapp.IsEnabled = true;
                    orderinfoapp.ModifyId = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.ModifyDate = DateTime.Now;
                    base.XMOrderInfoAppService.UpdateXMOrderInfoApp(orderinfoapp);

                    //店铺名称
                    int NickId = Convert.ToInt32(this.ddlNickId.SelectedValue);
                    //平台类型
                    int PlatformTypeId = Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue);
                    var xMProjectList = base.XMOrderInfoAppService.GetXMProjectList(NickId, PlatformTypeId);
                    int rowscount = xMProjectList.Count();//获取行数;
                    if (rowscount % this.Master.PageSize == 0)
                    { this.BindGrid(this.Master.PageIndex-1, this.Master.PageSize); }
                    else
                    {this.BindGrid(this.Master.PageIndex, this.Master.PageSize); }
                   
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