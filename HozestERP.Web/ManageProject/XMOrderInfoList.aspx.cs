using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageProductionOrder;
using HozestERP.Common;
using HozestERP.Common.Utils;
using JdSdk.Domain;
using JdSdk.Domains;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Top.Api.Domain;
using Yhd.Api;
using Yhd.Api.Object;
using Yhd.Api.Request;
using Yhd.Api.Response;

namespace HozestERP.Web.ManageProject
{
    extern alias suning;
    using System.Transactions;
    using System.Text;
    public partial class XMOrderInfoList : BaseAdministrationPage, ISearchPage
    {
        public string ManufacturersCodeRecord = "";
        public List<HozestERP.BusinessLogic.ManageProject.XMDelivery> DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
        public List<XMXLMInventory> XLMInventoryList = new List<XMXLMInventory>();
        public List<int> InventoryList = new List<int>();

        //同一个用户多个订单的备份
        public List<HozestERP.BusinessLogic.ManageProject.XMDelivery> SpareDeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
        public List<XMOrderInfoProductDetails> SpareOrderInfoProductList = new List<XMOrderInfoProductDetails>();
        public List<XMXLMInventory> SpareXLMInventoryList = new List<XMXLMInventory>();
        public List<XMOrderInfoOperatingRecord> SpareRecordList = new List<XMOrderInfoOperatingRecord>();
        public bool MultipleUpdate;//同一个用户多个订单是否更新

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnSearch", "ManageProject.XMOrderInfoList.Search");//查询
                buttons.Add("imgbtnOrderInfoDetail", "ManageProject.XMOrderInfoList.SeeXMOrderInfoDetail");//详情
                buttons.Add("btnImportingPage", "ManageProject.XMOrderInfoList.ImportingPage");//导入数据
                buttons.Add("imgBtnDelete", "ManageProject.XMOrderInfoList.XMOrderInfoDelete");//删除
                buttons.Add("btnAllIsAudit", "ManageProject.XMOrderInfoList.AllIsAudit"); //批量审单
                buttons.Add("btnSynchronousOrderData", "ManageProject.XMOrderInfoList.SynchronousOrderData"); //数据同步
                buttons.Add("imgbtnOperatingRecords", "ManageProject.XMOrderInfoList.OperatingRecords"); //操作记录
                buttons.Add("btnScalpingAudit", "ManageProject.XMOrderInfoList.ScalpingAudit"); //刷单审单   
                buttons.Add("btnImportOrderAscription", "ManageProject.XMOrderInfoList.ImportOrderAscription"); //刷单审单     
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //付款开始时间
                this.txtPayDateStart.Value = Convert.ToDateTime(DateTime.Now).AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
                //付款结束时间
                this.txtPayDateEnd.Value = Convert.ToDateTime(DateTime.Now).AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:ss");

                //弹出导入订单窗口
                this.btnImportingPage.OnClientClick = "return ShowWindowDetail('导入订单','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportOrder.aspx',880,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //弹出亚马逊对账导入窗口
                this.btnReconciliation.OnClientClick = "return ShowWindowDetail('亚马逊对账导入','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportReconciliation.aspx',750,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //唯品会运单承运商导入
                this.btnVPHLogistics.OnClientClick = "return ShowWindowDetail('亚马逊对账导入','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportVPHLogistics.aspx',500,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //生成出库单
                this.btnAddSaleDelivery.OnClientClick = "return CkeckShowWindowDetail(SaveOrderInfoIDs(),'出库仓库','" + CommonHelper.GetStoreLocation() +
            "ManageProject/XMOrderInfoSaleDelivery.aspx',300,170, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //批量手动排单
                this.btnManualPlanBill.OnClientClick = "return CkeckShowWindowDetail(SaveOrderInfoIDs(),'手动排单','" + CommonHelper.GetStoreLocation() +
            "ManageProject/XMOrderInfoManualPlanBill.aspx',300,190, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //弹出订单归属导入窗口
                this.btnImportOrderAscription.OnClientClick = "return ShowWindowDetail('订单归属导入','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportOrderAscription.aspx',750,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //手动创建订单数据
                this.btnAddOrder.OnClientClick = "return ShowWindowDetail('单个订单手工添加','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportOrderAscription.aspx',750,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
                {
                    List<XMProject> XMProjectList = base.XMOrderInfoAPIService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                    if (XMProjectList.Count > 0)
                    {
                        this.ddXMProject.Items.Clear();
                        this.ddXMProject.Items.Clear();
                        this.ddXMProject.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                    }
                    this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
                    this.ddXMProject.Items[0].Selected = true;
                }
                else
                {
                    this.BindddXMProject();//项目
                }

                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
            //  this.Master.SetTrigger(this.btnSynchronousOrderData.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitleVisible = false;

            //平台类型动态数据绑定
            this.ddPlatformTypeId.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            // var newList = codeList.Where(p => p.CodeID != 250).ToList();
            this.ddPlatformTypeId.DataSource = codeList;
            this.ddPlatformTypeId.DataTextField = "CodeName";
            this.ddPlatformTypeId.DataValueField = "CodeID";
            this.ddPlatformTypeId.DataBind();
            this.ddPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));

            //订单状态数据绑定  
            this.ddOrderStatusId.Items.Clear();
            //List<Setting> settingList = base.SettingManager.GetSettingsList();
            //var newSetting = settingList.Where(p => p.Description.Contains("订单状态") && p.Value != "WAIT_SELLER_STOCK_OUT,WAIT_SELLER_SEND_GOODS").ToList();
            //this.ddOrderStatusId.DataSource = newSetting;
            //this.ddOrderStatusId.DataTextField = "Name";
            //this.ddOrderStatusId.DataValueField = "Value";
            //this.ddOrderStatusId.DataBind();
            this.ddOrderStatusId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //this.ddOrderStatusId.Items.Insert(1, new ListItem("等待卖家发货", "WAIT_SELLER_STOCK_OUT,WAIT_SELLER_SEND_GOODS")); 
            //this.ddOrderStatusId.Items[1].Selected = true;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);

            var NickId = Convert.ToInt32(this.ddlNick.SelectedValue);
            string nickids = "";
            if (NickId == 99) //某个项目店铺权限，选择有权限的店铺
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), xMProjectId, HozestERPContext.Current.User.CustomerID, 0);
                for (int i = 0; i < nickList.Count; i++)
                {
                    nickids = nickids + nickList[i].nick_id + ",";
                }
                if (nickids.Length > 0)
                {
                    nickids = nickids.Substring(0, nickids.Length - 1);
                }
            }
            else
            {
                nickids = NickId.ToString();
            }

            //订单状态
            string OrderStatusId = this.ddOrderStatusId.SelectedValue.Trim();
            //时间类型
            int timetype = int.Parse(this.ddlOrderStatus.SelectedValue.Trim());
            //平台类型Id
            int PlatformTypeId = Convert.ToInt32(this.ddPlatformTypeId.SelectedValue.ToString());
            //是否审单
            int IsAudit = Convert.ToInt32(this.ddIsAudit.SelectedValue.Trim());
            //付款时间
            DateTime? PayDateStart = Convert.ToDateTime(txtPayDateStart.Value.Trim());
            DateTime? PayDateEnd = Convert.ToDateTime(txtPayDateEnd.Value.Trim());
            //是否异常
            int IsAbnormal = Convert.ToInt32(this.ddlIsAbnormal.SelectedValue.Trim());
            //异常备注
            bool remarks = this.chkRemarks.Checked;
            //数据来源
            string SourceType = this.ddlSourceType.SelectedValue.Trim();
            //网名
            string WantID = this.txtWantID.Text.Trim();
            //是否为我们的订单
            int IsOurOrder = 1;
            //排单
            int SingleRow = int.Parse(this.ddlSingleRow.SelectedValue);
            //手机号码
            string Mobile = this.txtMobile.Text.Trim();
            //地址
            string Address = this.txtAddress.Text.Trim();
            //产品编码
            string ManufacturersCode = txtManufacturersCode1.Text.Trim();
            //等通知
            int WaitNotice = this.chkWaitNotice.Checked == true ? 1 : 0;
            //加急
            int Urgent = this.chkUrgent.Checked == true ? 1 : 0;
            //能发就发
            int CanDeliver = this.chkCanDeliver.Checked == true ? 1 : 0;
            //厂家编码包含
            int CodeContain = chkCodeContain.Checked ? 1 : 0;
            //预约发货时间
            int AppointDeliveryTime = this.chkAppointDeliveryTime.Checked == true ? 1 : 0;
            string AppointDeliveryBegin = this.txtAppointDeliveryBegin.Value.Trim();
            string AppointDeliveryEnd = this.txtAppointDeliveryEnd.Value.Trim();
            DateTime AppointDeliveryBeginDate = DateTime.Now;
            DateTime AppointDeliveryEndDate = DateTime.Now;
            //客服备注
            string CustomerServiceRemark = this.txtCustomerServiceRemark.Text.Trim();

            if (AppointDeliveryTime == 1 && (AppointDeliveryBegin == "" || AppointDeliveryEnd == ""))
            {
                base.ShowMessage("预约发货开始时间和结束时间不能为空！");
                return;
            }

            if (AppointDeliveryTime == 1)
            {
                AppointDeliveryBeginDate = DateTime.Parse(AppointDeliveryBegin);
                AppointDeliveryEndDate = DateTime.Parse(AppointDeliveryEnd).AddDays(1).AddSeconds(-1);
            }

            List<XMOrderInfo> orderInfoList = new List<XMOrderInfo>();
            orderInfoList = base.XMOrderInfoAPIService.GetXMOrderInfoListSearch(xMProjectId, NickId, this.txtOrderCode.Text.Trim(),
                  this.txtFullName.Text.Trim(), OrderStatusId, PlatformTypeId, PayDateStart, PayDateEnd, IsAudit, remarks,
                  (this.chkIsScalping.Checked == true ? 1 : 0), IsAbnormal, timetype, SourceType, WantID, IsOurOrder, Mobile,
                  Address, WaitNotice, Urgent, CanDeliver, AppointDeliveryTime, AppointDeliveryBeginDate, AppointDeliveryEndDate, CustomerServiceRemark);

            //筛选排单
            orderInfoList = base.XMOrderInfoService.GetXMOrderInfoListBySingleRow(orderInfoList, SingleRow, ManufacturersCode, CodeContain);

            var pageList = new PagedList<XMOrderInfo>(orderInfoList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, pageList);
        }

        #endregion

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                //.Where(c => c.ProjectTypeId == 362)

                this.ddXMProject.DataSource = projectList;
                this.ddXMProject.DataTextField = "ProjectName";
                this.ddXMProject.DataValueField = "Id";
                this.ddXMProject.DataBind();
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    this.ddXMProject.Items.Insert(0, new ListItem("---无项目权限---", "0"));
                }
                if (projectList.Count() > 0)
                {
                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                }
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "99"));
            }
            #endregion

            //this.ddXMProject.Items.Clear();
            //var projectList = base.XMProjectService.GetXMProjectList();
            //this.ddXMProject.DataSource = projectList;
            //this.ddXMProject.DataTextField = "ProjectName";
            //this.ddXMProject.DataValueField = "Id";
            //this.ddXMProject.DataBind();
            //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.SelectedValue.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue));
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    this.ddlNick.DataSource = nickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    //其他
                    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue), HozestERPContext.Current.User.CustomerID, 0);
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    if (nickList.Count() == 0)
                    {
                        this.ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                    }
                    else
                    {
                        if (nickList.Count() > 0)
                        {
                            this.ddlNick.DataSource = nickList;
                            this.ddlNick.DataTextField = "nick";
                            this.ddlNick.DataValueField = "nick_id";
                            this.ddlNick.DataBind();
                        }
                        this.ddlNick.Items.Insert(0, new ListItem("---所有---", "99"));
                    }
                }
                //this.ddlNick.Items.Clear();
                //var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue));
                //this.ddlNick.DataSource = nickList;
                //this.ddlNick.DataTextField = "nick";
                //this.ddlNick.DataValueField = "nick_id";
                //this.ddlNick.DataBind();
                //this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
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
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //if (e.CommandName.Equals("XMOrderInfoDetail"))
                //{
                //    // this.BindGrid(1, Master.PageSize);
                //    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                //}

                #region 删除
                if (e.CommandName.Equals("XMOrderInfoDelete"))
                {

                    var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(e.CommandArgument));

                    if (xMOrderInfo != null)//删除
                    {
                        XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                        record.PropertyName = "IsEnable";
                        record.OldValue = System.Convert.ToString(xMOrderInfo.IsEnable);
                        bool IsEnable = true;
                        record.NewValue = System.Convert.ToString(IsEnable);
                        record.OrderInfoId = Convert.ToInt32(e.CommandArgument);
                        record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        record.UpdateTime = DateTime.Now;
                        base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);

                        xMOrderInfo.IsEnable = true;
                        xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        xMOrderInfo.UpdateDate = DateTime.Now;
                        base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                        var productlist = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderId(xMOrderInfo.ID);
                        foreach (var elem in productlist)
                        {
                            elem.IsEnable = true;
                            base.XMOrderInfoProductDetailsService.UpdateXMOrderInfoProductDetails(elem);
                        }
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                        base.ShowMessage("操作成功.");
                    }

                }
                #endregion
            }
            catch (Exception ex)
            {

                base.ProcessException(ex);
            }

        }

        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var xMOrderInfo = e.Row.DataItem as XMOrderInfo;

                //if (xMOrderInfo.IsAbnormal == true)
                //{
                //    e.Row.BackColor = System.Drawing.Color.Red;
                //}

                //异常行-无产品
                var OrderInfoProductList = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderId(xMOrderInfo.ID);

                if (OrderInfoProductList.Count <= 0)
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }

                if (xMOrderInfo.PlatformTypeId == 259)
                {
                    foreach (var a in OrderInfoProductList)
                    {
                        if (a.PlatformMerchantCode.StartsWith("CM") && a.ProductName.Contains("无产品"))
                        {
                            e.Row.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    }
                }
                else
                {
                    var NoProductList = OrderInfoProductList.Where(x => x.ProductName.Contains("无产品")).ToList();
                    if (NoProductList != null && NoProductList.Count > 0)
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                    }
                }

                //查看详情
                ImageButton imgbtnOrderInfoDetail = e.Row.FindControl("imgbtnOrderInfoDetail") as ImageButton;
                if (imgbtnOrderInfoDetail != null)
                {
                    imgbtnOrderInfoDetail.OnClientClick = "return ShowWindowDetail('基本信息','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/XMOrderInfoOperation.aspx?ID=" + xMOrderInfo.ID + "&IsCM=1',1150, 700, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }

                //操作记录
                ImageButton imgbtnOperatingRecords = e.Row.FindControl("imgbtnOperatingRecords") as ImageButton;
                if (imgbtnOperatingRecords != null)
                {
                    imgbtnOperatingRecords.OnClientClick = "return ShowWindowDetail('操作记录','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/XMOrderInfoOperatingRecords.aspx?ID=" + xMOrderInfo.ID + "&IsCM=1',1000, 550, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }

                //单个订单同步

                #region 平台名称
                Label PlatformTypeId = e.Row.FindControl("PlatformTypeId") as Label;
                List<CodeList> codeList = base.CodeService.GetCodeList(Convert.ToInt32(xMOrderInfo.PlatformTypeId));
                if (codeList.Count > 0)
                    PlatformTypeId.Text = codeList[0].CodeName;
                #endregion

                #region 发货地址
                Label lblDeliveryAddress = e.Row.FindControl("lblDeliveryAddress") as Label;
                string deliveryAddress = xMOrderInfo.DeliveryAddress;
                if (deliveryAddress != null && deliveryAddress != "")
                {
                    //var SdeliveryAddress = CutStr(deliveryAddress, 20);
                    if (deliveryAddress.Length > 6)
                    {
                        string SdeliveryAddress = deliveryAddress.Substring(0, 6);
                        lblDeliveryAddress.Text = SdeliveryAddress + "...";
                    }
                    else
                    {
                        lblDeliveryAddress.Text = deliveryAddress;
                    }
                }
                else
                {
                    lblDeliveryAddress.Text = "";

                }
                #endregion

                #region 备注
                Label lblRemarks = e.Row.FindControl("lblRemarks") as Label;
                string CustomerServiceRemark = xMOrderInfo.CustomerServiceRemark;
                if (CustomerServiceRemark != null && CustomerServiceRemark != "" && CustomerServiceRemark.Length > 8)
                {
                    //var SdeliveryAddress = CutStr(deliveryAddress, 20);
                    string strCRemarks = CustomerServiceRemark.Substring(0, 8);
                    lblRemarks.Text = strCRemarks + "...";
                    lblRemarks.ToolTip = CustomerServiceRemark;
                }
                else
                {
                    lblRemarks.Text = CustomerServiceRemark;
                    lblRemarks.ToolTip = CustomerServiceRemark;

                }
                #endregion

                int paramPlatformTypeId = int.Parse(xMOrderInfo.PlatformTypeId.ToString());
                HyperLink linkWantID = e.Row.FindControl("WantID") as HyperLink;
                linkWantID.Text = xMOrderInfo.WantID;
                if (paramPlatformTypeId == 250)
                {
                    linkWantID.NavigateUrl = "http://amos.im.alisoft.com/msg.aw?v=2&uid=" + xMOrderInfo.WantID + "&site=cntaobao&s=1&charset=utf-8";
                }
            }
        }

        /// <summary>
        /// 截取字符串，不限制字符串长度
        /// </summary>
        /// <param name="str">待截取的字符串</param>
        /// <param name="len">每行的长度，多于这个长度自动换行</param>
        /// <returns></returns>
        public string CutStr(string str, int len)
        {
            string s = "";
            for (int i = 0; i < str.Length; i++)
            {
                int r = i % len;
                int last = (str.Length / len) * len;
                if (i != 0 && i <= last)
                {
                    if (r == 0)
                    {
                        s += str.Substring(i - len, len) + "<br>";
                    }

                }
                else if (i > last)
                {
                    s += str.Substring(i - 1);
                    break;
                }
            }
            return s;
        }


        /// <summary>
        /// 批量提单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLiftBill_Click(object sender, EventArgs e)
        {
            try
            {
                bool isAudit = true;
                List<int> grdProductionOrderIDs = this.Master.GetSelectedIds(this.grdvClients);
                if (grdProductionOrderIDs.Count <= 0)
                {
                    base.ShowMessage("你没有选择任何记录！");
                    return;
                }
                else
                {
                    foreach (int ID in grdProductionOrderIDs)
                    {
                        isAudit = IsAudit(ID.ToString());
                    }
                }
                if (!isAudit)    //订单未审核
                {
                    base.ShowMessage("所选订单未通过审核，无法提单！");
                    BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    return;
                }
                else
                {
                    //订单审核通过，循环提单
                    foreach (int ID in grdProductionOrderIDs)
                    {
                        var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(ID);
                        if (xMOrderInfo != null)
                        {
                            using (TransactionScope scope = new TransactionScope())
                            {
                                var xMProductOrderInfo = base.XMProductionOrderService.GetXMProductionOrderInfoByOrderCode(xMOrderInfo.OrderCode);
                                if (xMProductOrderInfo == null)     //生产单不存在新增
                                {
                                    XMProductionOrder productionOrder = new XMProductionOrder();
                                    productionOrder.NickID = xMOrderInfo.NickID;
                                    productionOrder.PlatformTypeId = xMOrderInfo.PlatformTypeId;
                                    productionOrder.OrderCode = xMOrderInfo.OrderCode;
                                    productionOrder.WantID = xMOrderInfo.WantID;
                                    productionOrder.FullName = xMOrderInfo.FullName;
                                    productionOrder.DeliveryAddress = xMOrderInfo.DeliveryAddress;
                                    productionOrder.CreateID = HozestERPContext.Current.User.CustomerID;
                                    productionOrder.CreateDate = DateTime.Now;
                                    productionOrder.IsEnable = false;
                                    productionOrder.Province = xMOrderInfo.Province;
                                    productionOrder.Mobile = xMOrderInfo.Mobile;
                                    productionOrder.City = xMOrderInfo.City;
                                    productionOrder.County = xMOrderInfo.County;
                                    productionOrder.Remark = xMOrderInfo.Remark;
                                    productionOrder.Status = 1000;   //未入库
                                    productionOrder.SingleRowStatus = 0;  //未排单
                                    base.XMProductionOrderService.InsertXMProductionOrder(productionOrder);
                                    var xMOrderInfoProductDetail = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderId(xMOrderInfo.ID);
                                    if (xMOrderInfoProductDetail != null && xMOrderInfoProductDetail.Count > 0)
                                    {
                                        foreach (XMOrderInfoProductDetails parm in xMOrderInfoProductDetail)
                                        {
                                            XMProductionOrderDetails details = new XMProductionOrderDetails();
                                            details.ProductionOrderID = productionOrder.Id;
                                            details.ManufacturersCode = parm.Manufacturers;
                                            details.ProductName = parm.ProductName;
                                            details.Specifications = parm.Specifications;
                                            details.ProductNum = parm.ProductNum;
                                            details.IsEnable = false;
                                            details.Status = false;  //未入库
                                            details.CreateID = HozestERPContext.Current.User.CustomerID;
                                            details.CreateDate = DateTime.Now;
                                            details.PlatformMerchantCode = parm.PlatformMerchantCode;
                                            details.ProductWeight = parm.ProductWeight;
                                            details.ProductVolume = parm.ProductVolume;
                                            details.IsSingleRow = false;
                                            base.XMProductionOrderDetailsService.InsertXMProductionOrderDetails(details);
                                        }
                                    }
                                }
                                scope.Complete();
                            }
                        }
                    }
                    base.ShowMessage("提单成功！");
                    BindGrid(this.Master.PageIndex, this.Master.PageSize);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.Replace("\r", "").Replace("\n", "");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "btnLiftBill_Click", "<script>alert('" + msg + "');</script>");
            }
        }

        /// <summary>
        /// 批量审单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAllIsAudit_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);
                if (customerInfoIDs.Count <= 0)
                {
                    base.ShowMessage("你没有选择任何记录！");
                    return;
                }
                else
                {
                    foreach (GridViewRow row in grdvClients.Rows)
                    {
                        CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                        if (chkSelected.Checked)
                        {
                            int XMOrderInfoID = 0;
                            int.TryParse(this.grdvClients.DataKeys[row.RowIndex].Value.ToString(), out XMOrderInfoID);
                            //订单信息
                            var xmorderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(XMOrderInfoID);
                            if (xmorderInfo != null)
                            {
                                int TMInsertCount = 0;
                                int TMUpdateCount = 0;

                                int JDInsertCount = 0;
                                int JDUpdateCount = 0;

                                int SNInsertCount = 0;
                                int SNUpdateCount = 0;

                                int YHDInsertCount = 0;
                                int YHDUpdateCount = 0;

                                int VPHInsertCount = 0;
                                int VPHUpdateCount = 0;

                                //同步各平台记录
                                var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppByPlatformTypeId(xmorderInfo.PlatformTypeId.Value).Where(p => p.NickId == xmorderInfo.NickID).FirstOrDefault();
                                if (XMOrderInfoAppList != null)
                                {
                                    switch (xmorderInfo.PlatformTypeId)
                                    {
                                        #region 淘宝/天猫

                                        case 250:
                                            Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(xmorderInfo.OrderCode), XMOrderInfoAppList);
                                            if (trade != null)
                                            {
                                                base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, XMOrderInfoAppList);

                                                if (TMUpdateCount > 0)
                                                {
                                                    var xMOrderInfoTMNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));

                                                    //备注内容  用来判断是否已经提单
                                                    string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;
                                                    //备注内容
                                                    string Remarksstr = "";
                                                    Remarksstr = xMOrderInfoTMNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                                    if (remmarksYTD.IndexOf("已提单") == -1)
                                                    {
                                                        //修改备注
                                                        var tradeMemoUpdate = base.XMOrderInfoAPIService.ReturnTradeMemoUpdate(Convert.ToInt64(xMOrderInfoTMNew.OrderCode), Remarksstr, XMOrderInfoAppList);
                                                        if (tradeMemoUpdate != null)
                                                        {
                                                            xmorderInfo.CustomerServiceRemark = Remarksstr;
                                                            base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        #endregion

                                        #region 集市店

                                        case 381:
                                            Trade trade2 = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(xmorderInfo.OrderCode), XMOrderInfoAppList);
                                            if (trade2 != null)
                                            {
                                                base.XMOrderInfoAPIService.getTradeTM(trade2, ref  TMInsertCount, ref  TMUpdateCount, XMOrderInfoAppList);

                                                if (TMUpdateCount > 0)
                                                {
                                                    var xMOrderInfoTMNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));

                                                    //备注内容  用来判断是否已经提单
                                                    string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;
                                                    //备注内容
                                                    string Remarksstr = "";
                                                    Remarksstr = xMOrderInfoTMNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                                    if (remmarksYTD.IndexOf("已提单") == -1)
                                                    {
                                                        //修改备注
                                                        var tradeMemoUpdate = base.XMOrderInfoAPIService.ReturnTradeMemoUpdate(Convert.ToInt64(xMOrderInfoTMNew.OrderCode), Remarksstr, XMOrderInfoAppList);

                                                        if (tradeMemoUpdate != null)
                                                        {
                                                            xmorderInfo.CustomerServiceRemark = Remarksstr;
                                                            base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        #endregion

                                        #region 京东

                                        case 251:
                                            HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                            HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xmorderInfo.OrderCode, XMOrderInfoAppList.AppKey, XMOrderInfoAppList.AppSecret, XMOrderInfoAppList.ServerUrl, XMOrderInfoAppList.AccessToken);

                                            if (orderInfo != null)
                                            {
                                                base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, XMOrderInfoAppList);

                                                if (JDUpdateCount > 0)
                                                {
                                                    var xMOrderInfoNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));

                                                    //备注内容  用来判断是否已经提单
                                                    string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;

                                                    //备注内容
                                                    string Remarksstr = "";
                                                    Remarksstr = xMOrderInfoNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                                    if (remmarksYTD.IndexOf("已提单") == -1)
                                                    {
                                                        //修改备注
                                                        var orderVenderRemark = base.XMOrderInfoAPIService.SetOrderVenderRemark(xMOrderInfoNew.OrderCode, Remarksstr, "", XMOrderInfoAppList);

                                                        if (orderVenderRemark != null)
                                                        {
                                                            if (orderVenderRemark.OUP != null)
                                                            {
                                                                if (orderVenderRemark.OUP.Code.ToString() == "0")
                                                                {
                                                                    xmorderInfo.CustomerServiceRemark = Remarksstr;
                                                                    base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;

                                        #endregion

                                        #region 京东闪购

                                        case 382:
                                            HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver2 = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                            HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo2 = webserver2.WebGetJDOrderInfo(xmorderInfo.OrderCode, XMOrderInfoAppList.AppKey, XMOrderInfoAppList.AppSecret, XMOrderInfoAppList.ServerUrl, XMOrderInfoAppList.AccessToken);
                                            if (orderInfo2 != null)
                                            {
                                                base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo2, ref JDInsertCount, ref JDUpdateCount, XMOrderInfoAppList);

                                                if (JDUpdateCount > 0)
                                                {
                                                    var xMOrderInfoNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));

                                                    //备注内容  用来判断是否已经提单
                                                    string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;

                                                    //备注内容
                                                    string Remarksstr = "";
                                                    Remarksstr = xMOrderInfoNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                                    if (remmarksYTD.IndexOf("已提单") == -1)
                                                    {
                                                        //修改备注
                                                        //var orderVenderRemark = base.XMOrderInfoAPIService.SetOrderVenderRemark(xMOrderInfoNew.OrderCode, Remarksstr, "", XMOrderInfoAppList);

                                                        //if (orderVenderRemark != null)
                                                        //{
                                                        //    if (orderVenderRemark.OUP != null)
                                                        //    {
                                                        //        if (orderVenderRemark.OUP.Code.ToString() == "0")
                                                        //        {
                                                        xmorderInfo.CustomerServiceRemark = Remarksstr;
                                                        base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                                        //        }
                                                        //    }
                                                        //}

                                                    }
                                                }
                                            }
                                            break;

                                        #endregion

                                        #region 苏宁易购
                                        case 383:
                                            //OrderInfo orderInfoSN = base.XMOrderInfoAPIService.getOrderSuning(xmorderInfo.OrderCode, XMOrderInfoAppList);
                                            //if (orderInfoSN != null)
                                            //{
                                            base.XMOrderInfoAPIService.getOrderSuning(xmorderInfo.OrderCode, ref SNInsertCount, ref SNUpdateCount, XMOrderInfoAppList);

                                            if (SNUpdateCount > 0)
                                            {

                                                var xMOrderInfoNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));

                                                //备注内容  用来判断是否已经提单
                                                string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;

                                                //备注内容
                                                string Remarksstr = "";
                                                Remarksstr = xMOrderInfoNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                                if (remmarksYTD.IndexOf("已提单") == -1)
                                                {
                                                    //修改备注
                                                    var result = base.XMOrderInfoAPIService.OrdernoteModifyUpdate(xMOrderInfoNew.OrderCode, Remarksstr, "4", XMOrderInfoAppList);

                                                    if (result == "Y")//判断平台后台备注是否修改成功
                                                    {
                                                        xmorderInfo.CustomerServiceRemark = Remarksstr;
                                                        base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                                    }
                                                }
                                            }
                                            // }
                                            break;
                                        #endregion

                                        #region 一号店
                                        case 375:
                                            base.XMOrderInfoAPIService.getOrderYHD(xmorderInfo.OrderCode, ref YHDInsertCount, ref YHDUpdateCount, XMOrderInfoAppList);

                                            if (YHDUpdateCount > 0)
                                            {
                                                var xMOrderInfoNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));

                                                //备注内容  用来判断是否已经提单
                                                string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;
                                                //备注内容
                                                string Remarksstr = "";
                                                Remarksstr = xMOrderInfoNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                                if (remmarksYTD.IndexOf("已提单") == -1)
                                                {
                                                    //修改备注 
                                                    int OrderMerchantRemarkUpdateInt = base.XMOrderInfoAPIService.OrderMerchantRemarkUpdate(xMOrderInfoNew.OrderCode, Remarksstr, XMOrderInfoAppList);

                                                    if (OrderMerchantRemarkUpdateInt == 1)
                                                    {
                                                        xmorderInfo.CustomerServiceRemark = Remarksstr;
                                                        base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                                    }
                                                }
                                            }
                                            break;
                                        #endregion

                                        #region 唯品会
                                        //case 259:
                                        //    base.XMOrderInfoAPIService.getOrderVPH("", "", xmorderInfo.OrderCode, ref VPHInsertCount, ref VPHUpdateCount, XMOrderInfoAppList);
                                        //    if (VPHUpdateCount > 0)
                                        //    {
                                        //        var xMOrderInfoNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));
                                        //        //备注内容  用来判断是否已经提单
                                        //        string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;

                                        //        //备注内容
                                        //        string Remarksstr = "";
                                        //        Remarksstr = xMOrderInfoNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                        //        if (remmarksYTD.IndexOf("已提单") == -1)
                                        //        {
                                        //            //修改备注
                                        //            int OrderMerchantRemarkUpdateInt = base.XMOrderInfoAPIService.OrderMerchantRemarkUpdate(xMOrderInfoNew.OrderCode, Remarksstr, XMOrderInfoAppList);

                                        //            if (OrderMerchantRemarkUpdateInt == 1)
                                        //            {
                                        //                xmorderInfo.CustomerServiceRemark = Remarksstr;
                                        //                base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                        //            }
                                        //        }
                                        //    }
                                        //    break;
                                        #endregion
                                    }
                                    if (!IsAllowAudit(xmorderInfo))
                                    {
                                        msg += xmorderInfo.OrderCode + ",<br/>";
                                        continue;
                                    }

                                    //修改审核状态
                                    bool IsAudit = false;
                                    foreach (XMOrderInfoProductDetails xmpd in xmorderInfo.XM_OrderInfoProductDetails)
                                    {
                                        xmpd.IsAudit = true;
                                        xmpd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        xmpd.UpdateDate = DateTime.Now;
                                        if (xmpd.IsAudit == true)
                                        {
                                            IsAudit = true;
                                        }
                                    }
                                    xmorderInfo.IsAudit = true;
                                    xmorderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderInfo.UpdateDate = DateTime.Now;
                                    base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);//修改审核状态

                                    //操作记录
                                    XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                                    record1.PropertyName = "IsAudit";
                                    record1.OldValue = System.Convert.ToString(IsAudit);

                                    record1.NewValue = System.Convert.ToString(true);
                                    record1.OrderInfoId = XMOrderInfoID;
                                    record1.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record1.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record1);
                                }
                                else
                                {
                                    //if (xmorderInfo.PlatformTypeId.Value == 376)
                                    //{

                                    if (!IsAllowAudit(xmorderInfo))
                                    {
                                        msg += xmorderInfo.OrderCode + ",<br/>";
                                        continue;
                                    }

                                    //修改审核状态
                                    bool IsAudit = false;
                                    foreach (XMOrderInfoProductDetails xmpd in xmorderInfo.XM_OrderInfoProductDetails)
                                    {
                                        xmpd.IsAudit = true;
                                        xmpd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        xmpd.UpdateDate = DateTime.Now;
                                        if (xmpd.IsAudit == true)
                                        {
                                            IsAudit = true;
                                        }
                                    }
                                    xmorderInfo.IsAudit = true;
                                    xmorderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderInfo.UpdateDate = DateTime.Now;
                                    base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);//修改 审核状态

                                    //操作记录
                                    XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                                    record1.PropertyName = "IsAudit";
                                    record1.OldValue = System.Convert.ToString(IsAudit);
                                    record1.NewValue = System.Convert.ToString(true);
                                    record1.OrderInfoId = XMOrderInfoID;
                                    record1.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record1.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record1);

                                    //}
                                }
                            }
                        }
                    }
                    BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    if (msg != "")
                    {
                        base.ShowMessage("订单号：" + msg + "的订单状态不正确，不能审核！");
                    }
                    else
                    {
                        base.ShowMessage("操作成功！");
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.Replace("\r", "").Replace("\n", "");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "btnAllIsAudit_Click", "<script>alert('" + msg + "');</script>");
            }
        }



        public bool IsAllowAudit(XMOrderInfo Info)
        {
            bool status = false;
            if (Info.PlatformTypeId == 250 || Info.PlatformTypeId == 381)
            {
                if (Info.OrderStatus == "WAIT_SELLER_SEND_GOODS")
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 511)
            {
                if (Info.OrderStatus == "DS_WAIT_SELLER_DELIVERY")
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 251 || Info.PlatformTypeId == 823 || Info.PlatformTypeId == 537 || Info.PlatformTypeId == 382 || Info.PlatformTypeId == 691)
            {
                if (Info.OrderStatus == "WAIT_SELLER_DELIVERY" || Info.OrderStatus == "WAIT_SELLER_STOCK_OUT")
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 259)
            {
                if (Info.OrderStatus == "STATUS_10")
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 375)
            {
                if (Info.OrderStatus == "ORDER_TRUNED_TO_DO")
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 376 || Info.PlatformTypeId == 824)
            {
                if (Info.OrderStatus == "以接受")
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 383 || Info.PlatformTypeId == 803)//803是唯品会MP
            {
                if (Info.OrderStatus == "10")
                {
                    status = true;
                }
            }

            if (Info.PlatformTypeId == 736 || Info.PlatformTypeId == 508 || Info.PlatformTypeId == 825)//以后通用订单在这里增加
            {
                if (Info.OrderStatus == "已付款")
                {
                    status = true;
                }
            }
            return status;
        }

        /// <summary>
        /// 导出订单数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOrderInfoExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\OrderInfoExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                    var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
                    bool IsAiPu = this.ddXMProject.SelectedValue == "13" ? true : false;//项目名称为艾谱
                    bool IsYingYi = this.ddXMProject.SelectedValue == "17" ? true : false;

                    var NickId = Convert.ToInt32(this.ddlNick.SelectedValue);
                    string nickids = "";
                    if (NickId == 99) //某个项目店铺权限，选择有权限的店铺
                    {
                        var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), xMProjectId, HozestERPContext.Current.User.CustomerID, 0);
                        for (int i = 0; i < nickList.Count; i++)
                        {
                            nickids = nickids + nickList[i].nick_id + ",";
                        }
                        if (nickids.Length > 0)
                        {
                            nickids = nickids.Substring(0, nickids.Length - 1);
                        }
                    }
                    else
                    {
                        nickids = NickId.ToString();
                    }

                    //订单状态
                    string OrderStatusId = this.ddOrderStatusId.SelectedValue.Trim();
                    //时间类型
                    int timetype = int.Parse(this.ddlOrderStatus.SelectedValue.Trim());
                    //平台类型Id
                    int PlatformTypeId = Convert.ToInt32(this.ddPlatformTypeId.SelectedValue.ToString());
                    //是否审单
                    int IsAudit = Convert.ToInt32(this.ddIsAudit.SelectedValue.Trim());
                    //付款时间
                    DateTime? PayDateStart = Convert.ToDateTime(txtPayDateStart.Value.Trim());
                    DateTime? PayDateEnd = Convert.ToDateTime(txtPayDateEnd.Value.Trim());
                    //是否异常
                    int IsAbnormal = Convert.ToInt32(this.ddlIsAbnormal.SelectedValue.Trim());
                    //异常备注
                    bool remarks = this.chkRemarks.Checked;
                    //数据来源
                    string SourceType = this.ddlSourceType.SelectedValue.Trim();
                    //网名
                    string WantID = this.txtWantID.Text.Trim();
                    //是否为我们的订单
                    int IsOurOrder = 1;
                    //手机号码
                    string Mobile = this.txtMobile.Text.Trim();
                    //地址
                    string Address = this.txtAddress.Text.Trim();
                    //等通知
                    int WaitNotice = this.chkWaitNotice.Checked == true ? 1 : 0;
                    //加急
                    int Urgent = this.chkUrgent.Checked == true ? 1 : 0;
                    //能发就发
                    int CanDeliver = this.chkCanDeliver.Checked == true ? 1 : 0;
                    //预约发货时间
                    int AppointDeliveryTime = this.chkAppointDeliveryTime.Checked == true ? 1 : 0;
                    string AppointDeliveryBegin = this.txtAppointDeliveryBegin.Value.Trim();
                    string AppointDeliveryEnd = this.txtAppointDeliveryEnd.Value.Trim();
                    DateTime AppointDeliveryBeginDate = DateTime.Now;
                    DateTime AppointDeliveryEndDate = DateTime.Now;
                    //客服备注
                    string CustomerServiceRemark = this.txtCustomerServiceRemark.Text.Trim();

                    if (AppointDeliveryTime == 1 && (AppointDeliveryBegin == "" || AppointDeliveryEnd == ""))
                    {
                        base.ShowMessage("预约发货开始时间和结束时间不能为空！");
                        return;
                    }

                    if (AppointDeliveryTime == 1)
                    {
                        AppointDeliveryBeginDate = DateTime.Parse(AppointDeliveryBegin);
                        AppointDeliveryEndDate = DateTime.Parse(AppointDeliveryEnd).AddDays(1).AddSeconds(-1);
                    }

                    List<XMOrderInfo> orderInfoList = new List<XMOrderInfo>();
                    orderInfoList = base.XMOrderInfoAPIService.GetXMOrderInfoListSearch(xMProjectId, NickId, this.txtOrderCode.Text.Trim(),
                  this.txtFullName.Text.Trim(), OrderStatusId, PlatformTypeId, PayDateStart, PayDateEnd, IsAudit, remarks,
                  (this.chkIsScalping.Checked == true ? 1 : 0), IsAbnormal, timetype, SourceType, WantID, IsOurOrder, Mobile
                  , Address, WaitNotice, Urgent, CanDeliver, AppointDeliveryTime, AppointDeliveryBeginDate, AppointDeliveryEndDate, CustomerServiceRemark);

                    if (PlatformTypeId == 259)  //唯品会根据下单时间查询
                    {
                        base.ExportManager.ExportXMOrderInfoToXlsOfVPH(filePath, orderInfoList.Distinct().ToList(), xMProjectId, IsAiPu, IsYingYi);
                    }
                    else
                    {
                        if (xMProjectId == 5)//曲美需符合对方导出格式
                        {
                            base.ExportManager.ExportXMOrderInfoToXlsQM(filePath, orderInfoList.Distinct().ToList(), xMProjectId, IsAiPu, IsYingYi);
                        }
                        else
                        {
                            base.ExportManager.ExportXMOrderInfoToXls(filePath, orderInfoList.Distinct().ToList(), xMProjectId, IsAiPu, IsYingYi);
                        }
                    }
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        /// <summary>
        /// 导出日日顺订单数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRiRiShunOrderInfoExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\RiRiShunOrderInfoExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
                    var NickId = Convert.ToInt32(this.ddlNick.SelectedValue);
                    string nickids = "";
                    if (NickId == 99) //某个项目店铺权限，选择有权限的店铺
                    {
                        var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), xMProjectId, HozestERPContext.Current.User.CustomerID, 0);
                        for (int i = 0; i < nickList.Count; i++)
                        {
                            nickids = nickids + nickList[i].nick_id + ",";
                        }
                        if (nickids.Length > 0)
                        {
                            nickids = nickids.Substring(0, nickids.Length - 1);
                        }
                    }
                    else
                    {
                        nickids = NickId.ToString();
                    }
                    //订单状态
                    string OrderStatusId = this.ddOrderStatusId.SelectedValue.Trim();
                    //时间类型
                    int timetype = int.Parse(this.ddlOrderStatus.SelectedValue.Trim());
                    //平台类型Id
                    int PlatformTypeId = Convert.ToInt32(this.ddPlatformTypeId.SelectedValue.ToString());
                    //是否审单
                    int IsAudit = 1;
                    //付款时间
                    DateTime? PayDateStart = Convert.ToDateTime(txtPayDateStart.Value.Trim());
                    DateTime? PayDateEnd = Convert.ToDateTime(txtPayDateEnd.Value.Trim());
                    //是否异常
                    int IsAbnormal = Convert.ToInt32(this.ddlIsAbnormal.SelectedValue.Trim());
                    //异常备注
                    bool remarks = this.chkRemarks.Checked;
                    //数据来源
                    string SourceType = this.ddlSourceType.SelectedValue.Trim();
                    //网名
                    string WantID = this.txtWantID.Text.Trim();
                    //是否为我们的订单
                    int IsOurOrder = 1;
                    //手机号码
                    string Mobile = this.txtMobile.Text.Trim();
                    //地址
                    string Address = this.txtAddress.Text.Trim();
                    //等通知
                    int WaitNotice = this.chkWaitNotice.Checked == true ? 1 : 0;
                    //加急
                    int Urgent = this.chkUrgent.Checked == true ? 1 : 0;
                    //能发就发
                    int CanDeliver = this.chkCanDeliver.Checked == true ? 1 : 0;
                    //预约发货时间
                    int AppointDeliveryTime = this.chkAppointDeliveryTime.Checked == true ? 1 : 0;
                    string AppointDeliveryBegin = this.txtAppointDeliveryBegin.Value.Trim();
                    string AppointDeliveryEnd = this.txtAppointDeliveryEnd.Value.Trim();
                    DateTime AppointDeliveryBeginDate = DateTime.Now;
                    DateTime AppointDeliveryEndDate = DateTime.Now;
                    //客服备注
                    string CustomerServiceRemark = this.txtCustomerServiceRemark.Text.Trim();

                    if (AppointDeliveryTime == 1 && (AppointDeliveryBegin == "" || AppointDeliveryEnd == ""))
                    {
                        base.ShowMessage("预约发货开始时间和结束时间不能为空！");
                        return;
                    }

                    if (AppointDeliveryTime == 1)
                    {
                        AppointDeliveryBeginDate = DateTime.Parse(AppointDeliveryBegin);
                        AppointDeliveryEndDate = DateTime.Parse(AppointDeliveryEnd).AddDays(1).AddSeconds(-1);
                    }

                    List<XMOrderInfo> orderInfoList = new List<XMOrderInfo>();
                    orderInfoList = base.XMOrderInfoAPIService.GetXMOrderInfoListSearch(xMProjectId, NickId, this.txtOrderCode.Text.Trim(),
                  this.txtFullName.Text.Trim(), OrderStatusId, PlatformTypeId, PayDateStart, PayDateEnd, IsAudit, remarks,
                  (this.chkIsScalping.Checked == true ? 1 : 0), IsAbnormal, timetype, SourceType, WantID, IsOurOrder, Mobile
                  , Address, WaitNotice, Urgent, CanDeliver, AppointDeliveryTime, AppointDeliveryBeginDate, AppointDeliveryEndDate, CustomerServiceRemark);


                    base.ExportManager.ExportRiRiShunXMOrderInfoToXls(filePath, orderInfoList.Distinct().ToList(), xMProjectId);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        /// <summary>
        /// 同步数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSynchronousOrderData_Click(object sender, EventArgs e)
        {
            try
            {
                //复选框
                List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);

                //平台类型Id
                int PlatformTypeNameId = Convert.ToInt32(this.ddPlatformTypeId.SelectedValue.ToString());
                //店铺id
                int NickId = Convert.ToInt32(this.ddlNick.SelectedValue.ToString());

                var setting = base.SettingManager.GetSettingByName("XMOrderInfoList.IndexSession");
                if (setting != null)
                {
                    if (setting.Value == "false")
                    {
                        base.ShowMessage("请稍后,数据正在同步中.");
                        return;
                    }
                    else
                    {
                        //修改公共参数
                        base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "false");
                    }
                }

                int TMInsertCount = 0;
                int TMUpdateCount = 0;

                int JDInsertCount = 0;
                int JDUpdateCount = 0;

                int TMCDInsertCount = 0;
                int TMCDUpdateCount = 0;

                int VPHInsertCount = 0;
                int VPHUpdateCount = 0;

                int YHDInsertCount = 0;
                int YHDUpdateCount = 0;

                int SuningInsertCount = 0;
                int SuningUpdateCount = 0;
                // int[] array = new int[] { 250, 251 };  
                //appk
                var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();


                string payDateStart = Convert.ToDateTime(DateTime.Now).AddDays(-10).ToString("yyyy-MM-dd HH:mm:ss");
                string payDateEnd = Convert.ToDateTime(DateTime.Now).AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");

                if (this.txtPayDateStart.Value.Trim() != "" || this.txtPayDateEnd.Value.Trim() != "")
                {
                    payDateStart = DateTime.Parse(this.txtPayDateStart.Value.Trim()).ToString("yyyy-MM-dd HH:mm:ss");
                    payDateEnd = DateTime.Parse(this.txtPayDateEnd.Value.Trim()).ToString("yyyy-MM-dd HH:mm:ss");
                }
                #region 根据选中的订单号 同步订单
                if (customerInfoIDs.Count > 0)
                {

                    //Session.Add("IndexSession", 1);

                    foreach (GridViewRow row in grdvClients.Rows)
                    {
                        CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                        if (chkSelected.Checked)
                        {
                            int XMOrderInfoID = 0;
                            int.TryParse(this.grdvClients.DataKeys[row.RowIndex].Value.ToString(), out XMOrderInfoID);
                            //订单详细数据
                            var xMOrderInfo = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderId(Convert.ToInt32(XMOrderInfoID));
                            //订单关联主表数据
                            foreach (XMOrderInfoProductDetails m in xMOrderInfo)
                            {
                                var xMOrderParentInfo = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(m.OrderInfoID));

                                int switchon = 0;
                                if (xMOrderInfo != null)//修改
                                {

                                    switchon = xMOrderParentInfo.PlatformTypeId.Value;
                                    switch (switchon)
                                    {
                                        //天猫
                                        case 250:
                                            XMOrderInfoApp xMorderInfoAppTMNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 250 && q.NickId == xMOrderParentInfo.NickID.Value).FirstOrDefault();
                                            if (xMorderInfoAppTMNew != null)
                                            {

                                                Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(xMOrderParentInfo.OrderCode), xMorderInfoAppTMNew);

                                                if (trade != null)
                                                {
                                                    base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoAppTMNew);
                                                }
                                            }
                                            break;
                                        //京东 (喜临门、嘟丽)
                                        case 251:

                                            List<XMOrderInfoApp> xMorderInfoAppJDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 251 && q.NickId == xMOrderParentInfo.NickID.Value).ToList();
                                            if (xMorderInfoAppJDNew.Count > 0)
                                            {
                                                for (int j = 0; j < xMorderInfoAppJDNew.Count; j++)
                                                {
                                                    HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                                    HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xMOrderParentInfo.OrderCode, xMorderInfoAppJDNew[j].AppKey, xMorderInfoAppJDNew[j].AppSecret, xMorderInfoAppJDNew[j].ServerUrl, xMorderInfoAppJDNew[j].AccessToken);
                                                    if (orderInfo != null)
                                                    {
                                                        base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDNew[j]);

                                                    }
                                                }
                                            }
                                            break;

                                        //京东闪购
                                        case 382:
                                            List<XMOrderInfoApp> xMorderInfoAppJDSJNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 382 && q.NickId == xMOrderParentInfo.NickID.Value).ToList();
                                            if (xMorderInfoAppJDSJNew.Count > 0)
                                            {
                                                for (int j = 0; j < xMorderInfoAppJDSJNew.Count - 1; j++)
                                                {
                                                    HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                                    HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xMOrderParentInfo.OrderCode, xMorderInfoAppJDSJNew[j].AppKey, xMorderInfoAppJDSJNew[j].AppSecret, xMorderInfoAppJDSJNew[j].ServerUrl, xMorderInfoAppJDSJNew[j].AccessToken);
                                                    if (orderInfo != null)
                                                    {
                                                        base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDSJNew[j]);

                                                    }
                                                }
                                            }
                                            break;
                                        //淘宝集市店
                                        case 381:
                                            List<XMOrderInfoApp> xMorderInfoAppTMCDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 381 && q.NickId == xMOrderParentInfo.NickID).ToList();
                                            if (xMorderInfoAppTMCDNew.Count > 0)
                                            {
                                                for (int j = 0; j < xMorderInfoAppTMCDNew.Count - 1; j++)
                                                {
                                                    Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(xMOrderParentInfo.OrderCode), xMorderInfoAppTMCDNew[j]);
                                                    if (trade != null)
                                                    {
                                                        base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMCDInsertCount, ref  TMCDUpdateCount, xMorderInfoAppTMCDNew[j]);
                                                    }
                                                }
                                            }
                                            break;
                                        //C店
                                        //case 310:
                                        //    List<XMOrderInfoApp> xMorderInfoAppJDCDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 310).ToList();
                                        //    if (xMorderInfoAppJDCDNew.Count > 0)
                                        //    {
                                        //        for (int j = 0; j < xMorderInfoAppJDCDNew.Count - 1; j++)
                                        //        {
                                        //            OrderInfo orderInfo = base.XMOrderInfoAPIService.getOrderInfo(xMOrderParentInfo.OrderCode, xMorderInfoAppJDCDNew[j]);
                                        //            if (orderInfo != null)
                                        //            {
                                        //                base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDCDNew[j]);

                                        //            }
                                        //        }
                                        //    }
                                        //    break;
                                        //唯品会
                                        case 259:
                                            List<XMOrderInfoApp> xMorderInfoVPHNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 259 && q.NickId == xMOrderParentInfo.NickID.Value).ToList();
                                            if (this.ddlNick.SelectedValue.Trim() == "1")
                                            {
                                                xMorderInfoVPHNew = xMorderInfoVPHNew.Where(p => p.NickId == 1).ToList();
                                            }
                                            if (this.ddlNick.SelectedValue.Trim() == "22")
                                            {
                                                xMorderInfoVPHNew = xMorderInfoVPHNew.Where(p => p.NickId == 22).ToList();
                                            }
                                            base.XMOrderInfoAPIService.getOrderVPH(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), xMOrderParentInfo.OrderCode, ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoVPHNew[0]);
                                            break;
                                        //一号店
                                        case 375:
                                            List<XMOrderInfoApp> xMorderInfoYHDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 375 && q.NickId == xMOrderParentInfo.NickID.Value).ToList();
                                            if (xMorderInfoYHDNew.Count > 0)
                                            {
                                                for (int j = 0; j < xMorderInfoYHDNew.Count - 1; j++)
                                                {
                                                    base.XMOrderInfoAPIService.getOrderYHD(xMOrderParentInfo.OrderCode, ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoYHDNew[j]);
                                                }
                                            }
                                            break;
                                        //苏宁易购
                                        case 383:
                                            List<XMOrderInfoApp> xMorderInfoSuningNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 383 && q.NickId == xMOrderParentInfo.NickID.Value).ToList();
                                            if (xMorderInfoSuningNew.Count > 0)
                                            {
                                                for (int j = 0; j < xMorderInfoSuningNew.Count - 1; j++)
                                                {
                                                    base.XMOrderInfoAPIService.getOrderSuning(xMOrderParentInfo.OrderCode, ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoSuningNew[j]);
                                                }
                                            }
                                            break;

                                    }
                                }
                            }
                        }
                    }
                }

                #endregion

                else
                {
                    if (PlatformTypeNameId == -1)
                    {
                        //修改公共参数
                        base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");

                        //Session["IndexSession"] = null;
                        base.ShowMessage("请选择平台类型.");
                        return;

                    }

                    //Session.Add("IndexSession", 1);

                    List<XMOrderInfoApp> xMorderInfoAppNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == PlatformTypeNameId).ToList();

                    //选择店铺
                    if (NickId != -1 && PlatformTypeNameId != -1)
                    {
                        xMorderInfoAppNew = xMorderInfoAppNew.Where(p => p.NickId == NickId && p.PlatformTypeId == PlatformTypeNameId).ToList();
                    }

                    for (int i = 0; i < xMorderInfoAppNew.Count; i++)
                    {
                        //string payDateStart = new DateTime(2013, 10, 20).ToString("yyyy-MM-dd HH:mm:ss");
                        //string payDateEnd = new DateTime(2013, 10, 29).ToString("yyyy-MM-dd HH:mm:ss");
                        //string payDateStart = Convert.ToDateTime(DateTime.Now).AddDays(-10).ToString("yyyy-MM-dd HH:mm:ss");
                        //string payDateEnd = Convert.ToDateTime(DateTime.Now).AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss"); 
                        //if (this.txtPayDateStart.Value.Trim() != "" || this.txtPayDateEnd.Value.Trim() != "")
                        //{
                        //    payDateStart = DateTime.Parse(this.txtPayDateStart.Value.Trim()).ToString("yyyy-MM-dd HH:mm:ss");
                        //    payDateEnd = DateTime.Parse(this.txtPayDateEnd.Value.Trim()).ToString("yyyy-MM-dd HH:mm:ss");
                        //}
                        //京东、京东闪购
                        if (xMorderInfoAppNew[i].PlatformTypeId == 251 || xMorderInfoAppNew[i].PlatformTypeId == 382)// || xMorderInfoAppNew[i].PlatformTypeId == 310)
                        {

                            XMOrderInfoApp xMorderInfoAppJD = xMorderInfoAppNew[i];

                            //1）WAIT_SELLER_STOCK_OUT 等待出库
                            //2）SEND_TO_DISTRIBUTION_CENER 发往配送中心（只适用于LBP，SOPL商家）
                            //3）DISTRIBUTION_CENTER_RECEIVED 配送中心已收货（只适用于LBP，SOPL商家）
                            //4）WAIT_GOODS_RECEIVE_CONFIRM 等待确认收货
                            //5）RECEIPTS_CONFIRM 收款确认（服务完成）（只适用于LBP，SOPL商家）
                            //6）WAIT_SELLER_DELIVERY等待发货（只适用于海外购商家，等待境内发货 标签下的订单）
                            //7）FINISHED_L 完成
                            //8）TRADE_CANCELED 取消（取消的订单不返回收货人基本信息）
                            //9）LOCKED  已锁定（锁定的订单不返回收货人基本信息） 

                            if (this.txtOrderCode.Text.Trim() != "")
                            {
                                HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(this.txtOrderCode.Text.Trim(), xMorderInfoAppNew[i].AppKey, xMorderInfoAppNew[i].AppSecret, xMorderInfoAppNew[i].ServerUrl, xMorderInfoAppNew[i].AccessToken);
                                if (orderInfo != null)
                                {
                                    base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJD);
                                }
                            }
                            else
                            {
                                string newApiOrderStates = "WAIT_SELLER_STOCK_OUT,WAIT_GOODS_RECEIVE_CONFIRM,FINISHED_L,TRADE_CANCELED,LOCKED";// "WAIT_SELLER_STOCK_OUT"; 
                                base.XMOrderInfoAPIService.SynchronousJDOrderData(payDateStart.ToString(), payDateEnd.ToString(), newApiOrderStates, xMorderInfoAppJD);
                                int page = 1;
                                int pageSize = 30;
                                long totalCount = 0;
                                //this.getAfsServiceMessage(page, pageSize, ref totalCount, Convert.ToDateTime(payDateStart), Convert.ToDateTime(payDateEnd), xMorderInfoAppJD);
                            }
                        }
                        //淘宝、淘宝集市店
                        else if (xMorderInfoAppNew[i].PlatformTypeId == 250 || xMorderInfoAppNew[i].PlatformTypeId == 381)
                        {
                            XMOrderInfoApp xMorderInfoAppTM = xMorderInfoAppNew[i];

                            if (this.txtOrderCode.Text.Trim() != "")
                            {
                                Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(this.txtOrderCode.Text.Trim()), xMorderInfoAppTM);

                                if (trade != null)
                                {
                                    if (xMorderInfoAppNew[i].PlatformTypeId == 250)
                                    {
                                        base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoAppTM);
                                    }
                                    else if (xMorderInfoAppNew[i].PlatformTypeId == 381)
                                    {
                                        base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMCDInsertCount, ref  TMCDUpdateCount, xMorderInfoAppTM);
                                    }
                                }
                            }
                            else
                            {

                                if (this.txtPayDateStart.Value != "" && this.txtPayDateEnd.Value != "")
                                {
                                    string Status = "";// "WAIT_SELLER_SEND_GOODS";  
                                    DateTime startdate = DateTime.Parse(this.txtPayDateStart.Value.Trim());
                                    DateTime enddate = DateTime.Parse(this.txtPayDateEnd.Value.Trim());
                                    TimeSpan ts = enddate - startdate;
                                    if (ts.Days > 30)
                                    {
                                        base.ShowMessage("淘宝、淘宝集市店订单同步时间差不能大于30天！");
                                        break;
                                    }
                                    else if (ts.Days == 0)
                                    {
                                        //注：增量接口 只能返回小于1天的数据
                                        //同步天猫数据  taobao.trades.sold.increment.get 查询卖家已卖出的增量交易数据（根据修改时间）
                                        //增量数据查询
                                        base.XMOrderInfoAPIService.SynchronousTMTradesSoldIncrementGetList(payDateStart, payDateEnd, Status, ref TMInsertCount, ref TMUpdateCount, xMorderInfoAppTM);//, TMXMOrderInfoApp

                                    }
                                    else
                                    {
                                        //taobao.trades.sold.get 查询卖家已卖出的交易数据（根据创建时间）
                                        base.XMOrderInfoAPIService.SynchronousTMOrderData(payDateStart, payDateEnd, Status, ref TMInsertCount, ref TMUpdateCount, xMorderInfoAppTM);//, TMXMOrderInfoApp
                                    }
                                }
                                //long PageNo = 1;
                                //long PageSize = 30;
                                //long TotalTesults = 0;
                                //string startDate = Convert.ToDateTime(DateTime.Now).AddHours(-3).ToString("yyyy-MM-dd HH:mm:ss");
                                //string endDate = Convert.ToDateTime(DateTime.Now).AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss"); 
                                //this.getRefundBillTM(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), PageNo, PageSize, ref  TotalTesults);

                            }
                        }
                        //一号店
                        else if (xMorderInfoAppNew[i].PlatformTypeId == 375)
                        {
                            XMOrderInfoApp xMorderInfoAppYHD = xMorderInfoAppNew[i];

                            if (this.txtOrderCode.Text.Trim() != "")
                            {
                                base.XMOrderInfoAPIService.getOrderYHD(this.txtOrderCode.Text.Trim(), ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoAppYHD);
                            }
                            else
                            {
                                if (this.txtPayDateStart.Value != "" && this.txtPayDateEnd.Value != "")
                                {
                                    DateTime startdate = DateTime.Parse(this.txtPayDateStart.Value.Trim());
                                    DateTime enddate = DateTime.Parse(this.txtPayDateEnd.Value.Trim());
                                    TimeSpan ts = enddate - startdate;
                                    if (ts.Days > 30)
                                    {
                                        base.ShowMessage("一号店订单同步时间差不能大于30天！");
                                        break;
                                    }
                                    else if (ts.Days == 0)
                                    {
                                        //注：增量接口 只能返回小于1天的数据
                                        //增量数据查询
                                        base.XMOrderInfoAPIService.SynchronousYHDTradesSoldIncrementData(this.txtPayDateStart.Value.Trim(), this.txtPayDateEnd.Value.Trim(), ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoAppYHD);
                                    }
                                    else
                                    {
                                        base.XMOrderInfoAPIService.SynchronousYHDOrderData(this.txtPayDateStart.Value.Trim(), this.txtPayDateEnd.Value.Trim(), ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoAppYHD);

                                    }
                                }
                            }
                        }
                        //苏宁易购
                        else if (xMorderInfoAppNew[i].PlatformTypeId == 383)
                        {
                            XMOrderInfoApp xMorderInfoAppSuning = xMorderInfoAppNew[i];

                            if (this.txtOrderCode.Text.Trim() != "")
                            {
                                base.XMOrderInfoAPIService.getOrderSuning(this.txtOrderCode.Text.Trim(), ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoAppSuning);
                            }
                            else
                            {
                                if (this.txtPayDateStart.Value != "" && this.txtPayDateEnd.Value != "")
                                {
                                    DateTime startdate = DateTime.Parse(this.txtPayDateStart.Value.Trim());
                                    DateTime enddate = DateTime.Parse(this.txtPayDateEnd.Value.Trim());
                                    TimeSpan ts = enddate - startdate;
                                    if (DateTime.Now.AddMonths(-3) > startdate)
                                    {
                                        base.ShowMessage("苏宁易购订单同步近三个月的数据！");
                                        break;
                                    }
                                    else if (ts.Days > 30)
                                    {
                                        base.ShowMessage("苏宁易购订单同步时间差不能大于30天！");
                                        break;
                                    }
                                    else if (ts.Days == 0)
                                    {
                                        //注：增量接口 只能返回小于1天的数据
                                        //同步苏宁易购数据  根据订单修改时间批量查询订单信息 
                                        base.XMOrderInfoAPIService.SynchronousSuningOrdData(this.txtPayDateStart.Value.Trim(), this.txtPayDateEnd.Value.Trim(), ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoAppSuning);
                                    }
                                    else
                                    {
                                        //同步苏宁易购数据   批量获取订单（三个月内的订单） 
                                        base.XMOrderInfoAPIService.SynchronousSuningOrderData(this.txtPayDateStart.Value.Trim(), this.txtPayDateEnd.Value.Trim(), ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoAppSuning);
                                    }
                                }
                            }
                        }
                    }

                    if (xMorderInfoAppNew.Count > 0 && (xMorderInfoAppNew[0].PlatformTypeId == 259 || xMorderInfoAppNew[0].PlatformTypeId == 803))
                    {
                        //string payDateStart = Convert.ToDateTime(DateTime.Now).AddDays(-10).ToString("yyyy-MM-dd HH:mm:ss");
                        //string payDateEnd = Convert.ToDateTime(DateTime.Now).AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");

                        //XMOrderInfoApp xMorderInfoAppVPH = xMorderInfoAppNew[i];
                        List<XMOrderInfoApp> xMorderInfoVPHNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 259).ToList();
                        if(xMorderInfoAppNew[0].PlatformTypeId == 803)
                            xMorderInfoVPHNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 803).ToList();
                        if (this.ddlNick.SelectedValue.Trim() == "1")
                        {
                            xMorderInfoVPHNew = xMorderInfoVPHNew.Where(p => p.NickId == 1).ToList();
                        }
                        if (this.ddlNick.SelectedValue.Trim() == "22")
                        {
                            xMorderInfoVPHNew = xMorderInfoVPHNew.Where(p => p.NickId == 22).ToList();
                        }
                        //唯品会
                        if (this.txtOrderCode.Text.Trim() != "")
                        {
                            base.XMOrderInfoAPIService.getOrderVPH(payDateStart, payDateEnd, this.txtOrderCode.Text.Trim(), ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoVPHNew[0]);
                        }
                        else
                        {
                            //string startdate = "", enddate = "";
                            //if (this.txtPayDateStart.Value.Trim() == "" || this.txtPayDateEnd.Value.Trim() == "")
                            //{
                            //    startdate = payDateStart;
                            //    enddate = payDateEnd;
                            //}
                            //else
                            //{
                            //    startdate = DateTime.Parse(this.txtPayDateStart.Value.Trim()).ToString("yyyy-MM-dd HH:mm:ss");
                            //    enddate = DateTime.Parse(this.txtPayDateEnd.Value.Trim()).ToString("yyyy-MM-dd HH:mm:ss");
                            //}
                            for (int i = 0; i < xMorderInfoVPHNew.Count; i++)
                            {
                                if (xMorderInfoAppNew[0].PlatformTypeId == 259)
                                    base.XMOrderInfoAPIService.SynchronousVPHOrderData(payDateStart, payDateEnd, ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoVPHNew[i]);
                                if (xMorderInfoAppNew[0].PlatformTypeId == 803)
                                    base.XMOrderInfoAPIService.SynchronousVPHMPOrderData(payDateStart, payDateEnd, ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoVPHNew[i]);
                            }
                        }
                    }
                }

                this.BindGrid(Master.PageIndex, Master.PageSize);

                if (this.txtOrderCode.Text.Trim() != "")
                {
                    int count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;

                    if (count == 0)
                    {

                        //修改公共参数
                        base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");
                        base.ShowMessage("订单编码:" + this.txtOrderCode.Text.Trim() + " 不存在！");
                    }
                    else
                    {
                        //修改公共参数
                        base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");
                        string JD = "共导入" + JDInsertCount + "条," + "共修改" + JDUpdateCount + "条; ";
                        string TM = "共导入" + TMInsertCount + "条," + "共修改" + TMUpdateCount + "条; ";
                        string TMCD = "共导入" + TMCDInsertCount + "条," + "共修改" + TMCDUpdateCount + "条; ";
                        string VPH = "共导入" + VPHInsertCount + "条," + "共修改" + VPHUpdateCount + "条; ";
                        string YHD = "共导入" + YHDInsertCount + "条," + "共修改" + YHDUpdateCount + "条; ";
                        string Suning = "共导入" + SuningInsertCount + "条," + "共修改" + SuningUpdateCount + "条; ";
                        base.ShowMessage("【京东平台】:" + JD + "【天猫平台】:" + TM + "【集市店】：" + TMCD + "【唯品会平台】:" + VPH + "【一号店平台】：" + YHD + "【苏宁易购】：" + Suning);
                    }
                }
                else
                {
                    //修改公共参数
                    base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");
                    string JD = "共导入" + JDInsertCount + "条," + "共修改" + JDUpdateCount + "条; ";
                    string TM = "共导入" + TMInsertCount + "条," + "共修改" + TMUpdateCount + "条; ";
                    string TMCD = "共导入" + TMCDInsertCount + "条," + "共修改" + TMCDUpdateCount + "条; ";
                    string VPH = "共导入" + VPHInsertCount + "条," + "共修改" + VPHUpdateCount + "条; ";
                    string YHD = "共导入" + YHDInsertCount + "条," + "共修改" + YHDUpdateCount + "条; ";
                    string Suning = "共导入" + SuningInsertCount + "条," + "共修改" + SuningUpdateCount + "条; ";
                    base.ShowMessage("【京东平台】:" + JD + "【天猫平台】:" + TM + "【集市店】：" + TMCD + "【唯品会平台】:" + VPH + "【一号店平台】：" + YHD + "【苏宁易购】：" + Suning);
                }
            }
            catch (Exception ex)
            {
                base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");
            }
        }

        /// <summary>
        /// 开始排单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdatePlanBill_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                DateTime begin = DateTime.Parse(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                DateTime end = begin.AddDays(1);
                string appointDeliveryTime1 = begin.Month.ToString() + "月" + begin.Day.ToString() + "日当天发";
                string appointDeliveryTime2 = begin.Month.ToString() + "月" + begin.Day.ToString() + "号当天发";

                //项目
                int ProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
                //店铺
                int NickId = Convert.ToInt32(this.ddlNick.SelectedValue);
                //平台类型Id
                int PlatformTypeId = Convert.ToInt32(this.ddPlatformTypeId.SelectedValue.ToString());

                var orderInfoList = base.XMOrderInfoService.GetXMOrderListByParm(ProjectId, NickId, PlatformTypeId);
                orderInfoList = orderInfoList.OrderByDescending(x => x.CustomerServiceRemark.IndexOf("/能发就发") != -1)
                    .OrderByDescending(x => x.CustomerServiceRemark.IndexOf("/加急") != -1)
                    .OrderByDescending(x => x.CustomerServiceRemark.IndexOf(appointDeliveryTime1) != -1
                                         || x.CustomerServiceRemark.IndexOf(appointDeliveryTime2) != -1).ToList()
                    .OrderByDescending(x => x.AppointDeliveryTime >= begin && x.AppointDeliveryTime < end).ToList();

                var Group = orderInfoList.GroupBy(x => x.Mobile).ToList();
                foreach (var group in Group)
                {
                    bool Multiple = false;//一个用户多个订单
                    if (group.Count() == 1)
                    {
                        XMOrderInfo Info = (group.ToList<XMOrderInfo>())[0];
                        msg = XMOrderInfoGroup(Info, orderInfoList, msg, Multiple);
                    }
                    else if (group.Count() > 1)
                    {
                        Multiple = true;
                        SpareDeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
                        SpareOrderInfoProductList = new List<XMOrderInfoProductDetails>();
                        SpareXLMInventoryList = new List<XMXLMInventory>();
                        SpareRecordList = new List<XMOrderInfoOperatingRecord>();
                        MultipleUpdate = true;

                        List<XMOrderInfo> InfoList = group.ToList<XMOrderInfo>();
                        foreach (XMOrderInfo Info in InfoList)
                        {
                            msg = XMOrderInfoGroup(Info, orderInfoList, msg, Multiple);
                        }
                        if (MultipleUpdate)
                        {
                            #region 同一用户多个订单
                            foreach (var item in SpareDeliveryList)
                            {
                                base.XMDeliveryService.InsertXMDelivery(item);
                            }
                            foreach (var item in SpareOrderInfoProductList)
                            {
                                item.IsSingleRow = true;
                                item.UpdateDate = DateTime.Now;
                                item.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMOrderInfoProductDetailsService.UpdateXMOrderInfoProductDetails(item);
                            }
                            foreach (var item in SpareRecordList)
                            {
                                base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(item);
                            }
                            #endregion
                        }
                        else
                        {
                            foreach (var item in SpareXLMInventoryList)
                            {
                                var info = base.XMXLMInventoryService.GetXMXLMInventoryByID(item.ID);
                                if (info != null)
                                {
                                    info.Inventory += item.Inventory;
                                    base.XMXLMInventoryService.UpdateXMXLMInventory(item);
                                }
                            }
                        }
                    }
                }

                if (msg != "")
                {
                    base.ShowMessage(msg);
                    return;
                }
                else
                {
                    base.ShowMessage("排单成功！");
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);

                #region 原来排单代码
                ////获取grid已选中复选框数据源
                //List<int> orderInfoIds = this.Master.GetSelectedIds(this.grdvClients);
                //if (orderInfoIds.Count > 0)
                //{
                //    #region 根据grid 已选中的数据源 排单
                //    var XmOrderInfoList = base.XMOrderInfoService.GetXMOrderInfoListByIds(orderInfoIds);

                //    List<XMOrderInfo> listxmorder = new List<XMOrderInfo>();

                //    foreach (XMOrderInfo x in XmOrderInfoList)
                //    {
                //        if (x.XM_OrderInfoProductDetails != null && x.XM_OrderInfoProductDetails.Count > 0 && x.XM_OrderInfoProductDetails.FirstOrDefault().IsAudit == true)
                //        {
                //            //判断 （能发就发  加急  几月几号发  等通知）
                //            if (x.CustomerServiceRemark != null && x.CustomerServiceRemark != "" && (x.CustomerServiceRemark.IndexOf("能发就发") > -1 || x.CustomerServiceRemark.IndexOf("加急") > -1 || x.CustomerServiceRemark.IndexOf("日当天发") > -1 || x.CustomerServiceRemark.IndexOf("等通知") > -1))
                //            {
                //                listxmorder.Add(x);
                //                continue;
                //            }
                //            else
                //            {

                //                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                //                base.ShowMessage("订单号：" + x.OrderCode + "  备注格式不正确！请重新排单！");
                //                break;
                //            }
                //        }
                //    }

                //    if (listxmorder.Count > 0)
                //    {

                //        string returnStr = "";
                //        //系统判断成功进行排单
                //        foreach (XMOrderInfo x in listxmorder)
                //        {
                //            var XMOrderInfoProductDetailsList = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderId(x.ID);

                //            if (XMOrderInfoProductDetailsList.Count > 0)
                //            {
                //                foreach (XMOrderInfoProductDetails pd in XMOrderInfoProductDetailsList)
                //                {
                //                    //判断是否已排过单
                //                    if (pd.IsSingleRow == true)
                //                    {
                //                        continue;
                //                    }
                //                    else
                //                    {
                //                        returnStr = IsStock(pd, x.OrderCode);
                //                        if (returnStr != "通过")
                //                        {
                //                            BindGrid(this.Master.PageIndex, this.Master.PageSize);
                //                            base.ShowMessage("订单号：" + x.OrderCode + "  排单失败！请检查重新排单！(" + returnStr + ")");
                //                            break;
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //        if (returnStr == "通过")
                //        {
                //            BindGrid(this.Master.PageIndex, this.Master.PageSize);
                //            base.ShowMessage("排单成功！");
                //        }
                //    }
                //    #endregion
                //}
                //else
                //{
                //    #region  根据条件  项目排单

                //    string projectid = this.ddXMProject.SelectedValue;//项目id
                //    if (projectid != "-1")
                //    {
                //        //项目id查询店铺信息
                //        var xmnickList = base.XMNickService.GetXMNickListByProjectId(int.Parse(projectid));
                //        List<int> listi = new List<int>();
                //        foreach (XMNick xn in xmnickList)
                //        {
                //            listi.Add(xn.nick_id);
                //        }
                //        int istrue = 0;
                //        List<XMOrderInfo> listxmorder = new List<XMOrderInfo>();
                //        //选择项目的已审核的订单排单
                //        //var xmorderinfoList = base.XMOrderInfoService.GetXMOrderInfoList().Where(p => listi.Contains(int.Parse(p.NickID.ToString())));

                //        //选择项目的已审核的订单排单
                //        var xmorderinfoDetailsList = base.XMOrderInfoService.GetXMOrderInfoListByDetails(listi);

                //        //去掉重复订单号
                //        var xmorderinfoList = xmorderinfoDetailsList.Distinct().ToList();


                //        foreach (XMOrderInfo x in xmorderinfoList)
                //        {
                //            if (x.XM_OrderInfoProductDetails != null && x.XM_OrderInfoProductDetails.Count > 0 && x.XM_OrderInfoProductDetails.FirstOrDefault().IsAudit == true)
                //            {
                //                //判断 （能发就发  加急  几月几号发  等通知）
                //                if (x.CustomerServiceRemark != null && x.CustomerServiceRemark != "" && (x.CustomerServiceRemark.IndexOf("能发就发") > -1 || x.CustomerServiceRemark.IndexOf("加急") > -1 || x.CustomerServiceRemark.IndexOf("日当天发") > -1 || x.CustomerServiceRemark.IndexOf("等通知") > -1))
                //                {
                //                    listxmorder.Add(x);
                //                    continue;
                //                }
                //                else
                //                {
                //                    istrue = 1;
                //                    base.ShowMessage("订单号：" + x.OrderCode + "  备注格式不正确！请重新排单！");
                //                    break;
                //                }
                //            }
                //        }
                //        //备注判断正确
                //        if (istrue == 0)
                //        {
                //            List<XMOrderInfo> listdisorderinfo = new List<XMOrderInfo>();
                //            //当天发的优先排单
                //            foreach (XMOrderInfo x in listxmorder)
                //            {
                //                if (x.CustomerServiceRemark.IndexOf("日当天发") > -1)
                //                {
                //                    listdisorderinfo.Add(x);
                //                }
                //            }
                //            if (SingRow(listdisorderinfo) == false)
                //            {
                //                return;
                //            }
                //            //5天以上的能发就发其次
                //            listdisorderinfo.Clear();
                //            foreach (XMOrderInfo x in listxmorder)
                //            {
                //                if (x.CustomerServiceRemark.IndexOf("能发就发") > -1 && x.PayDate != null)
                //                {
                //                    DateTime paydate = DateTime.Parse(x.PayDate.ToString());
                //                    DateTime nowdate = DateTime.Now;
                //                    TimeSpan ts = nowdate - paydate;
                //                    if (ts.Days >= 5)
                //                    {
                //                        listdisorderinfo.Add(x);
                //                    }
                //                }
                //            }
                //            if (SingRow(listdisorderinfo) == false)
                //            {
                //                return;
                //            }
                //            //加急的第三位发
                //            listdisorderinfo.Clear();
                //            foreach (XMOrderInfo x in listxmorder)
                //            {
                //                if (x.CustomerServiceRemark.IndexOf("加急") > -1)
                //                {
                //                    listdisorderinfo.Add(x);
                //                }
                //            }
                //            if (SingRow(listdisorderinfo) == false)
                //            {
                //                return;
                //            }
                //            //其次能发就发
                //            listdisorderinfo.Clear();
                //            foreach (XMOrderInfo x in listxmorder)
                //            {
                //                if (x.CustomerServiceRemark.IndexOf("能发就发") > -1)
                //                {
                //                    listdisorderinfo.Add(x);
                //                }
                //            }
                //            if (SingRow(listdisorderinfo) == false)
                //            {
                //                return;
                //            }
                //            base.ShowMessage("排单成功！");
                //        }
                //    }
                //    else
                //    {
                //        base.ShowMessage("请选择项目名称！");
                //        return;
                //    }
                //    #endregion
                //}
                #endregion
            }
            catch
            {
                base.ShowMessage("更新排单失败，请检查后重新排单！");
                return;
            }
        }

        public string XMOrderInfoGroup(XMOrderInfo Info, List<XMOrderInfo> orderInfoList, string msg, bool Multiple)
        {
            int OrderInfoProductCount = 0;//有效的订单产品条数
            int DeliveryProductCount = 0;//能排单的订单产品条数
            int WarehouseID = 0;
            int ProvinceWarehouseID = 0;

            DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
            XLMInventoryList = new List<XMXLMInventory>();
            InventoryList = new List<int>();

            List<XMOrderInfoProductDetails> OrderInfoProductUnSpare = new List<XMOrderInfoProductDetails>();//无备用地址产品
            List<XMOrderInfoProductDetails> OrderInfoProductSpare = new List<XMOrderInfoProductDetails>();//有备用地址产品
            List<XMOrderInfoProductDetails> LatexPillowUnSpare = new List<XMOrderInfoProductDetails>();//乳胶枕，U型枕，无备用地址产品
            List<XMOrderInfoProductDetails> LatexPillowSpare = new List<XMOrderInfoProductDetails>();//乳胶枕，U型枕，有备用地址产品

            string Address = Info.Province + Info.City + Info.County + Info.DeliveryAddress;
            var warehouse = GetProvinceWarehouse(Address);
            if (warehouse == null)
            {
                msg += "订单" + Info.OrderCode + "的地址不属于任一个仓库！<br/>";
                return msg;
            }
            else
            {
                WarehouseID = (int)warehouse.WarehouseID;
                ProvinceWarehouseID = warehouse.ID;
            }

            foreach (var info in Info.XM_OrderInfoProductDetails)
            {
                if (info.ProductName.IndexOf("床笠") != -1 || info.ProductName.IndexOf("运费") != -1 || info.ProductName.IndexOf("邮费") != -1 || info.ProductName.IndexOf("无产品") != -1)
                {
                    continue;
                }

                if ((bool)info.IsAudit && (info.IsSingleRow == null || !(bool)info.IsSingleRow))
                {
                    OrderInfoProductCount++;
                    var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 709);
                    if (info.ProductName.IndexOf("乳胶枕") != -1 || info.ProductName.IndexOf("U型枕") != -1 || info.ProductName.IndexOf("凝胶枕") != -1)
                    {
                        if (spareAddress != null)
                        {
                            Address = spareAddress.Province + spareAddress.City + spareAddress.County + spareAddress.DeliveryAddress;
                            warehouse = GetProvinceWarehouse(Address);
                            if (warehouse == null)
                            {
                                msg += "订单" + Info.OrderCode + ",产品编码：" + info.TManufacturersCode + "的备用地址不属于任一个仓库！<br/>";
                                continue;
                            }
                            LatexPillowSpare.Add(info);
                        }
                        else
                        {
                            LatexPillowUnSpare.Add(info);
                        }
                    }
                    else
                    {
                        if (spareAddress != null)
                        {
                            Address = spareAddress.Province + spareAddress.City + spareAddress.County + spareAddress.DeliveryAddress;
                            warehouse = GetProvinceWarehouse(Address);
                            if (warehouse == null)
                            {
                                msg += "订单" + Info.OrderCode + ",产品编码：" + info.TManufacturersCode + "的备用地址不属于任一个仓库！<br/>";
                                continue;
                            }
                            OrderInfoProductSpare.Add(info);
                        }
                        else
                        {
                            OrderInfoProductUnSpare.Add(info);
                        }
                    }
                }
                else
                {
                    msg += "订单:" + Info.OrderCode + "，产品编码：" + info.TManufacturersCode + "的产品未审核或已排单！<br/>";
                }
            }

            if (OrderInfoProductUnSpare.Count > 0)
            {
                msg = ToPlanBill(OrderInfoProductUnSpare, Info, WarehouseID, ProvinceWarehouseID, 1, msg, orderInfoList);//无备用地址产品
            }
            if (LatexPillowUnSpare.Count > 0)
            {
                msg = ToPlanBill(LatexPillowUnSpare, Info, WarehouseID, ProvinceWarehouseID, 3, msg, orderInfoList);//乳胶枕，U型枕，无备用地址产品
            }
            if (OrderInfoProductSpare.Count > 0)
            {
                msg = ToPlanBill(OrderInfoProductSpare, Info, WarehouseID, ProvinceWarehouseID, 2, msg, orderInfoList);//有备用地址产品
            }
            if (LatexPillowSpare.Count > 0)
            {
                msg = ToPlanBill(LatexPillowSpare, Info, WarehouseID, ProvinceWarehouseID, 4, msg, orderInfoList);//乳胶枕，U型枕，有备用地址产品
            }

            foreach (var item in DeliveryList)
            {
                if (item.XM_Delivery_Details != null && item.XM_Delivery_Details.Count > 0)
                {
                    DeliveryProductCount += item.XM_Delivery_Details.Count;
                }
            }

            if (OrderInfoProductCount > 0 && OrderInfoProductCount == DeliveryProductCount)
            {
                foreach (var item in DeliveryList)
                {
                    if (!Multiple)
                    {
                        base.XMDeliveryService.InsertXMDelivery(item);
                    }
                    else
                    {
                        SpareDeliveryList.Add(item);
                    }
                }
                //订单产品排单状态变为true
                foreach (var info in Info.XM_OrderInfoProductDetails)
                {
                    if (!Multiple)
                    {
                        info.IsSingleRow = true;
                        info.UpdateDate = DateTime.Now;
                        info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMOrderInfoProductDetailsService.UpdateXMOrderInfoProductDetails(info);
                    }
                    else
                    {
                        SpareOrderInfoProductList.Add(info);
                    }
                }
                //减喜临门当日库存
                for (int i = 0; i < XLMInventoryList.Count; i++)
                {
                    if (Multiple)
                    {
                        XMXLMInventory a = new XMXLMInventory();
                        a.ID = XLMInventoryList[i].ID;
                        a.Inventory = XLMInventoryList[i].Inventory - InventoryList[i];
                        SpareXLMInventoryList.Add(a);
                    }
                    XLMInventoryList[i].Inventory = InventoryList[i];
                    base.XMXLMInventoryService.UpdateXMXLMInventory(XLMInventoryList[i]);
                }
                //操作记录
                XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                record.PropertyName = "自动排单";
                record.OldValue = "IsSingleRow - false";
                record.NewValue = "IsSingleRow - true";
                record.OrderInfoId = Info.ID;
                record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                record.UpdateTime = DateTime.Now;
                if (!Multiple)
                {
                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                }
                else
                {
                    SpareRecordList.Add(record);
                }
            }
            return msg;
        }

        public ProvinceWarehouse GetProvinceWarehouse(string Address)
        {
            var WarehouseList = base.ProvinceWarehouseService.GetProvinceWarehouseList();
            foreach (var item in WarehouseList)
            {
                if (Address.StartsWith(item.ProvinceName))
                {
                    return item;
                }
            }
            return null;
        }

        public string ToPlanBill(List<XMOrderInfoProductDetails> list, XMOrderInfo Info, int WarehouseID, int ProvinceWarehouseID, int type, string msg, List<XMOrderInfo> orderInfoList)
        {
            if (type == 1 || type == 3)
            {
                bool ProductExist = false;
                if (!GetPlanBillResult(list, Info, null, WarehouseID, type, orderInfoList))//排单不成功
                {
                    var MoveCargo = base.XMOrderInfoService.AgreeMoveCargo(list, null);
                    if (MoveCargo)//允许调货
                    {
                        var SpareList = base.ProvinceWarehouseSpareService.GetProvinceWarehouseSpareByProvinceWarehouseID(ProvinceWarehouseID);
                        if (SpareList != null && SpareList.Count > 0)
                        {
                            foreach (var item in SpareList)
                            {
                                if (GetPlanBillResult(list, Info, null, (int)item.SpareWarehouseID, type, orderInfoList))
                                {
                                    ProductExist = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    ProductExist = true;
                }

                if (!ProductExist)
                {
                    MultipleUpdate = false;
                    msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                }
                else
                {
                    if (orderInfoList.Where(x => x.Mobile == Info.Mobile).ToList().Count > 1 && msg.IndexOf("顾客: " + Info.FullName) == -1)
                    {
                        msg += "<—————————— 顾客: " + Info.FullName
                            + "，有多个订单参与排单，请注意！——————————> <br/>";
                    }
                }
            }
            else if (type == 2 || type == 4)
            {
                List<int?> Ids = new List<int?>();
                var IDs = list.Select(x => x.ID).ToList();
                var SpareAddressList = base.XMSpareAddressService.GetXMSpareAddressListByIDs(IDs, 709);
                foreach (var info in list)
                {
                    if (Ids.Contains(info.ID))
                    {
                        continue;
                    }
                    int warehouseID = 0;
                    int provinceWarehouseID = 0;
                    var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 709);
                    if (spareAddress != null)
                    {
                        string address = spareAddress.Province + spareAddress.City + spareAddress.County + spareAddress.DeliveryAddress;
                        var warehouse = GetProvinceWarehouse(address);
                        if (warehouse != null)
                        {
                            warehouseID = (int)warehouse.WarehouseID;
                            provinceWarehouseID = warehouse.ID;

                            //不同产品，相同地址
                            var SpareAddress = SpareAddressList.Where(x => x.FullName == spareAddress.FullName && x.Mobile == spareAddress.Mobile && x.DeliveryAddress == spareAddress.DeliveryAddress).ToList();
                            var OrderInfoProductIds = SpareAddress.Select(x => x.OtherID).ToList();
                            var List = list.Where(x => OrderInfoProductIds.Contains(x.ID)).ToList();
                            Ids.AddRange(OrderInfoProductIds);

                            bool ProductExist = false;
                            if (!GetPlanBillResult(List, Info, spareAddress, warehouseID, type, orderInfoList))//排单不成功
                            {
                                var MoveCargo = base.XMOrderInfoService.AgreeMoveCargo(list, null);
                                if (MoveCargo)//允许调货
                                {
                                    var SpareList = base.ProvinceWarehouseSpareService.GetProvinceWarehouseSpareByProvinceWarehouseID(provinceWarehouseID);
                                    if (SpareList != null && SpareList.Count > 0)
                                    {
                                        foreach (var item in SpareList)
                                        {
                                            if (GetPlanBillResult(List, Info, spareAddress, (int)item.SpareWarehouseID, type, orderInfoList))
                                            {
                                                ProductExist = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ProductExist = true;
                            }

                            if (!ProductExist)
                            {
                                MultipleUpdate = false;
                                msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                            }
                            else
                            {
                                if (orderInfoList.Where(x => x.Mobile == Info.Mobile).ToList().Count > 1 && msg.IndexOf("顾客: " + Info.FullName) == -1)
                                {
                                    msg += "<—————————— 顾客: " + Info.FullName
                                        + "，有多个订单参与排单，请注意！——————————> <br/>";
                                }
                            }
                        }
                    }
                }
            }
            return msg;
        }

        public bool GetPlanBillResult(List<XMOrderInfoProductDetails> list, XMOrderInfo Info, XMSpareAddress SpareAddress, int WarehouseID, int type, List<XMOrderInfo> orderInfoList)
        {
            ManufacturersCodeRecord = "";
            bool complete = true;
            HozestERP.BusinessLogic.ManageProject.XMDelivery delivery = ToInsertDelivery(Info, SpareAddress, type, orderInfoList);
            delivery.XM_Delivery_Details = new List<XMDeliveryDetails>();

            foreach (var info in list)
            {
                if (type == 1 || type == 2)
                {
                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(WarehouseID, info.TManufacturersCode, "");
                    if (exist.Count > 0 && exist[0].Inventory >= info.ProductNum)
                    {
                        if (delivery.Shipper == 0)
                        {
                            var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.TManufacturersCode);
                            if (product != null && product.Count > 0)
                            {
                                delivery.Shipper = product[0].Shipper;
                            }
                        }

                        if (delivery.OrderRemarks == Info.CustomerServiceRemark && !string.IsNullOrEmpty(info.SpareRemarks))
                        {
                            delivery.OrderRemarks = info.SpareRemarks;
                        }

                        delivery.XM_Delivery_Details.Add(GetDeliveryDetails(info, Info.OrderCode, WarehouseID));
                        //减喜临门当日库存
                        InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                        XLMInventoryList.Add(exist[0]);
                    }
                    else
                    {
                        complete = false;
                        ManufacturersCodeRecord += "产品编码：" + info.TManufacturersCode + "，";
                    }
                }

                if (type == 3 || type == 4)//乳胶枕，U型枕，喜米，无备用地址
                {
                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(693, info.TManufacturersCode, "");//南方仓库
                    if (exist.Count > 0 && exist[0].Inventory >= info.ProductNum)
                    {
                        if (delivery.Shipper == 0)
                        {
                            var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.TManufacturersCode);
                            if (product != null && product.Count > 0)
                            {
                                delivery.Shipper = product[0].Shipper;
                            }
                        }

                        if (delivery.OrderRemarks == Info.CustomerServiceRemark && !string.IsNullOrEmpty(info.SpareRemarks))
                        {
                            delivery.OrderRemarks = info.SpareRemarks;
                        }

                        delivery.XM_Delivery_Details.Add(GetDeliveryDetails(info, Info.OrderCode, 693));
                        //减喜临门当日库存
                        InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                        XLMInventoryList.Add(exist[0]);
                    }
                    else
                    {
                        complete = false;
                        ManufacturersCodeRecord += "产品编码：" + info.TManufacturersCode + "，";
                    }
                }
            }

            if (complete == true && delivery.XM_Delivery_Details != null && delivery.XM_Delivery_Details.Count > 0)
            {
                DeliveryList.Add(delivery);
            }

            return complete;
        }

        public HozestERP.BusinessLogic.ManageProject.XMDelivery ToInsertDelivery(XMOrderInfo Info, XMSpareAddress SpareAddress, int type, List<XMOrderInfo> orderInfoList)
        {
            HozestERP.BusinessLogic.ManageProject.XMDelivery info = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
            info.DeliveryTypeId = 480;//正常
            info.DeliveryNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");//发货单号;
            info.OrderCode = Info.OrderCode;

            if (type == 1 || type == 3)
            {
                info.FullName = Info.FullName;
                info.Mobile = Info.Mobile;
                info.Tel = Info.Tel;
                info.Province = Info.Province;
                info.City = Info.City;
                info.County = Info.County;
                info.DeliveryAddress = Info.DeliveryAddress;
            }
            else if (type == 2 || type == 4)
            {
                info.FullName = SpareAddress.FullName;
                info.Mobile = SpareAddress.Mobile;
                info.Tel = SpareAddress.Tel;
                info.Province = SpareAddress.Province;
                info.City = SpareAddress.City;
                info.County = SpareAddress.County;
                info.DeliveryAddress = SpareAddress.DeliveryAddress;
            }

            info.OrderRemarks = Info.CustomerServiceRemark;
            info.Shipper = 0;
            info.Price = 0;
            info.PrintBatch = 0;
            info.PrintQuantity = 0;
            info.IsDelivery = false;
            info.IsEnabled = false;
            info.CreateDate = DateTime.Now;
            info.CreateId = HozestERPContext.Current.User.CustomerID;
            info.UpdateDate = DateTime.Now;
            info.UpdateId = HozestERPContext.Current.User.CustomerID;
            //base.XMDeliveryService.InsertXMDelivery(info);
            return info;
        }

        public XMDeliveryDetails GetDeliveryDetails(XMOrderInfoProductDetails ProductDetails, string OrderCode, int WarehouseID)
        {
            string PrdouctName = "";
            string Specifications = "";

            XMDeliveryDetails detail = new XMDeliveryDetails();
            //detail.DeliveryId = DeliveryIDType;
            detail.DetailsTypeId = (int)StatusEnum.NormalOrder;//正常订单
            detail.OrderNo = OrderCode;

            var ProductDetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(ProductDetails.PlatformMerchantCode, (int)ProductDetails.XM_OrderInfo.PlatformTypeId);
            if (ProductDetail != null && ProductDetail.Count > 0)
            {
                detail.ProductlId = ProductDetail[0].ProductId;
                var product = IoC.Resolve<IXMProductService>().GetXMProductById((int)detail.ProductlId);
                if (product != null)
                {
                    PrdouctName = product.ProductName;
                    Specifications = product.Specifications;
                }
            }

            detail.PlatformMerchantCode = ProductDetails.PlatformMerchantCode;
            detail.PrdouctName = PrdouctName;
            detail.Specifications = Specifications;
            detail.ProductNum = (int)ProductDetails.ProductNum;
            detail.WarehouseID = WarehouseID;
            detail.IsEnabled = false;
            detail.CreateDate = DateTime.Now;
            detail.CreateID = HozestERPContext.Current.User.CustomerID;
            detail.UpdateDate = DateTime.Now;
            detail.UpdateID = HozestERPContext.Current.User.CustomerID;
            //IoC.Resolve<IXMDeliveryDetailsService>().InsertXMDeliveryDetails(detail);
            return detail;
        }

        /// <summary>
        /// 排单
        /// </summary>
        /// <param name="listxmorder"></param>
        /// <returns></returns>
        protected bool SingRow(List<XMOrderInfo> listxmorder)
        {
            //系统判断成功进行排单
            foreach (XMOrderInfo x in listxmorder)
            {
                var XMOrderInfoProductDetailsList = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderId(x.ID);

                if (XMOrderInfoProductDetailsList.Count > 0)
                {
                    foreach (XMOrderInfoProductDetails pd in XMOrderInfoProductDetailsList)
                    {
                        //判断是否已排过单
                        if (pd.IsSingleRow == true)
                        {
                            continue;
                        }
                        else
                        {
                            //日期判断
                            if (x.CustomerServiceRemark.IndexOf("加急") > -1)
                            {
                                string returnStr = IsStock(pd, x.OrderCode);
                                if (returnStr != "通过")
                                {
                                    base.ShowMessage("订单号：" + x.OrderCode + "  排单失败！请检查重新排单！(" + returnStr + ")");
                                    return false;
                                }
                            }
                            else if (x.CustomerServiceRemark.IndexOf("能发就发") > -1)
                            {
                                string returnStr = IsStock(pd, x.OrderCode);
                                if (returnStr != "通过")
                                {
                                    base.ShowMessage("订单号：" + x.OrderCode + "  排单失败！请检查重新排单！(" + returnStr + ")");
                                    return false;
                                }
                            }
                            else if (x.CustomerServiceRemark.IndexOf("日当天发") > -1)
                            {
                                string aa = x.CustomerServiceRemark;

                                string strNew = "";
                                string DT = "";//备注中的发货日期
                                DateTime postdate = new DateTime();//发货日期

                                if (aa.IndexOf("日当天发") > -1)
                                {
                                    strNew = aa.Substring(0, aa.IndexOf("日当天发"));//取出日当天发 前面的内容
                                }
                                int fOld = strNew.IndexOf("/");
                                if (fOld > -1)
                                {
                                    string sNew = strNew.Substring(0, fOld + 1).Trim();//取出日期前面的内容 

                                    if (sNew != "")
                                    {
                                        DT = strNew.Substring(strNew.IndexOf(sNew) + sNew.Length).Trim();//日期
                                    }
                                }
                                if (DT != "")
                                {
                                    string rs = DT.Replace("月", "-");
                                    rs = DateTime.Now.Year.ToString() + "-" + rs;

                                    DateTime dtm = new DateTime();
                                    if (DateTime.TryParse(rs, out dtm))//类型转换
                                    {
                                        postdate = DateTime.Parse(rs);
                                    }
                                }
                                //string rs = x.CustomerServiceRemark.Substring(x.CustomerServiceRemark.IndexOf("买家联系") + 4);
                                //string rt = rs.Substring(rs.IndexOf("日当天发"));
                                //rs = rs.Replace(rt, "").Replace("月", "-");
                                //rs = DateTime.Now.Year.ToString() + "-" + rs;
                                //DateTime postdate = DateTime.Parse(rs); 

                                if (postdate.ToString() != "0001/1/1 0:00:00")
                                {
                                    if (DateTime.Now.ToString("yyyy-MM-dd") == postdate.ToString("yyyy-MM-dd"))
                                    {
                                        //时间匹配成功
                                        string returnStr = IsStock(pd, x.OrderCode);
                                        if (returnStr != "通过")
                                        {
                                            base.ShowMessage("订单号：" + x.OrderCode + "  排单失败！请检查重新排单！(" + returnStr + ")");
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 判断库存并且处理库存
        /// </summary>
        /// <param name="pd"></param>
        /// <returns></returns>
        protected string IsStock(XMOrderInfoProductDetails pd, string OrderCode)
        {
            try
            {
                if (pd != null && pd.PlatformMerchantCode != null && pd.PlatformMerchantCode != "")
                {
                    //订单主表信息
                    var orderinfo = pd.XM_OrderInfo;
                    //商品编码查询产品详细信息
                    var productdetailModel = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(pd.PlatformMerchantCode);
                    if (productdetailModel != null && productdetailModel.Count > 0)
                    {
                        //产品信息
                        var productModel = base.XMProductService.GetXMProductById(int.Parse(productdetailModel.FirstOrDefault().ProductId.ToString()));
                        int? inventory = productModel.ManufacturersInventory;
                        int? num = pd.ProductNum;
                        if (productModel.ManufacturersInventory >= pd.ProductNum)
                        {
                            //添加发货单信息
                            //订单号、商品编码查询发货list
                            //var deliverylist = IoC.Resolve<IXMDeliveryService>().GetXMDeliveryList(orderinfo.OrderCode, pd.PlatformMerchantCode, "");

                            //返回明细数据
                            //根据订单号 、是否发货：否0、未打印:0  查询发货单 
                            var xmDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsSearchByOrderCodeList(orderinfo.OrderCode, 0, 0);

                            if (orderinfo != null && pd != null)
                            {
                                var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductNameList(pd.ProductName);

                                xmProductList = xmProductList.Where(p => p.Specifications.Contains(pd.Specifications)).ToList();

                                HozestERP.BusinessLogic.ManageProject.XMDelivery xd = new HozestERP.BusinessLogic.ManageProject.XMDelivery();

                                if (xmDeliveryDetailsList == null || xmDeliveryDetailsList.Count == 0)
                                {
                                    xd.DeliveryTypeId = 480;//订单
                                    xd.DeliveryNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");//发货单号（自动生成）
                                    xd.OrderCode = orderinfo.OrderCode;//订单号
                                    // xd.ProductNo = pd.PlatformMerchantCode;//商品编号
                                    //xd.LogisticsId = int.Parse(LogisticsId);//物流公司id
                                    //xd.LogisticsNumber = LogisticsNumber;//物流单号
                                    //xd.Price = Price == "" ? 0 : decimal.Parse(Price);//运费
                                    xd.IsDelivery = false;//是否发货
                                    xd.CreateId = HozestERPContext.Current.User.CustomerID;
                                    xd.CreateDate = DateTime.Now;
                                    xd.UpdateId = HozestERPContext.Current.User.CustomerID;
                                    xd.UpdateDate = DateTime.Now;
                                    xd.IsEnabled = false;
                                    xd.PrintQuantity = 0;//打印次数
                                    xd.PrintBatch = 0;//打印批次  
                                    IoC.Resolve<IXMDeliveryService>().InsertXMDelivery(xd);
                                }
                                else
                                {
                                    //返回明细数据 ，根据明细主表Id查询主表信息 
                                    xd = base.XMDeliveryService.GetXMDeliveryById(xmDeliveryDetailsList[0].DeliveryId.Value);
                                }

                                if (xd != null)//发货单记录 不未空
                                {
                                    if (xd.Id != 0)
                                    {
                                        //for (int i = 0; i < orderinfo.XM_OrderInfoProductDetails.Count; i++)
                                        //    {  
                                        #region 发货点明细  新增
                                        XMDeliveryDetails deliverDetails = new XMDeliveryDetails();
                                        deliverDetails.OrderNo = orderinfo.OrderCode;
                                        deliverDetails.DetailsTypeId = (int)StatusEnum.NormalOrder;
                                        deliverDetails.DeliveryId = xd.Id;
                                        if (xmProductList.Count > 0)
                                        {
                                            deliverDetails.ProductlId = xmProductList[0].Id;//产品管理 主表Id
                                        }
                                        deliverDetails.PlatformMerchantCode = pd.PlatformMerchantCode;
                                        deliverDetails.PrdouctName = pd.ProductName;
                                        deliverDetails.Specifications = pd.Specifications;
                                        deliverDetails.ProductNum = pd.ProductNum;
                                        deliverDetails.IsEnabled = false;
                                        deliverDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                        deliverDetails.CreateDate = DateTime.Now;
                                        deliverDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        deliverDetails.UpdateDate = DateTime.Now;
                                        base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliverDetails);
                                        #endregion

                                        #region 修改产品库存数

                                        //有库存,减去产品数量
                                        productModel.ManufacturersInventory = inventory - num;
                                        productModel.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        productModel.UpdateDate = DateTime.Now;
                                        base.XMProductService.UpdateXMProduct(productModel);
                                        //修改排单状态
                                        pd.IsSingleRow = true;
                                        pd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        pd.UpdateDate = DateTime.Now;
                                        base.XMOrderInfoProductDetailsService.UpdateXMOrderInfoProductDetails(pd);

                                        #endregion

                                        //}
                                    }
                                }

                            }
                            //操作记录
                            int UpsatorID = 0;
                            if (HozestERPContext.Current.User != null)
                            {
                                UpsatorID = HozestERPContext.Current.User.CustomerID;

                            }
                            else
                            {
                                string UserName = "admin";
                                List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                                if (customer.Count > 0)
                                {
                                    UpsatorID = customer[0].CustomerID;
                                }
                            }

                            XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                            record.OrderInfoId = pd.OrderInfoID;
                            record.PropertyName = "StockNum";
                            record.OldValue = pd.PlatformMerchantCode + "：" + inventory.ToString();
                            record.NewValue = pd.PlatformMerchantCode + "：" + (inventory - num).ToString();
                            record.UpdatorID = UpsatorID;
                            record.UpdateTime = DateTime.Now;
                            IoC.Resolve<XMOrderInfoOperatingRecordService>().InsertXMOrderInfoOperatingRecord(record);// base.ProjectService.InsertXMOrderInfoOperatingRecord(record);

                            return "通过";
                        }
                        else
                        {
                            return productModel.ManufacturersCode + "  库存不足！";
                        }
                    }
                    else
                    {
                        return "未找到：" + pd.PlatformMerchantCode + "  商品！";
                    }
                }
                else
                {
                    return OrderCode + " 明细商品信息有误！";
                }

            }
            catch (Exception ex)
            {
                return "异常";
            }
        }

        /// <summary>
        /// 刷单审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnScalpingAudit_Click(object sender, EventArgs e)
        {
            List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);
            if (customerInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                foreach (GridViewRow row in grdvClients.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int XMOrderInfoID = 0;
                        int.TryParse(this.grdvClients.DataKeys[row.RowIndex].Value.ToString(), out XMOrderInfoID);
                        //订单信息获取
                        var xmorderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(XMOrderInfoID);
                        if (xmorderInfo != null && (xmorderInfo.IsScalping == null || xmorderInfo.IsScalping == false))
                        {
                            xmorderInfo.IsScalping = true;//是否刷单
                            base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);

                            //添加刷单记录
                            var productList = xmorderInfo.XM_OrderInfoProductDetails.FirstOrDefault();
                            var scalping = new XMScalping();
                            scalping.PlatformTypeId = xmorderInfo.PlatformTypeId;
                            scalping.NickId = xmorderInfo.NickID;
                            scalping.Type = 365;//PC端
                            scalping.OrderCode = xmorderInfo.OrderCode;
                            scalping.WantID = xmorderInfo.WantID;
                            if (productList != null)
                            {
                                scalping.ProductName = productList.ProductName;
                                //scalping.SalePrice = productList.SalesPrice;
                            }
                            else
                            {
                                scalping.ProductName = "无产品";
                                //scalping.SalePrice = 0;
                            }
                            scalping.SalePrice = xmorderInfo.PayPrice.Value;
                            scalping.IsEnable = false;
                            scalping.IsAbnormal = false;
                            scalping.CreateID = HozestERPContext.Current.User.CustomerID;
                            scalping.CreateDate = DateTime.Now;
                            scalping.UpdateID = HozestERPContext.Current.User.CustomerID;
                            scalping.UpdateDate = DateTime.Now;
                            base.XMScalpingService.InsertXMScalping(scalping);

                            //操作记录
                            XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                            record1.PropertyName = "ScalpingRecord";
                            record1.OldValue = System.Convert.ToString(false);

                            record1.NewValue = System.Convert.ToString(true);
                            record1.OrderInfoId = XMOrderInfoID;
                            record1.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            record1.UpdateTime = DateTime.Now;
                            base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record1);
                        }
                    }
                }

                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功.");
            }
        }

        /// <summary>
        /// 财务审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinancialAudit_Click(object sender, EventArgs e)
        {
            List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);
            if (customerInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                foreach (GridViewRow row in grdvClients.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int XMOrderInfoID = 0;
                        int.TryParse(this.grdvClients.DataKeys[row.RowIndex].Value.ToString(), out XMOrderInfoID);
                        //订单信息获取
                        var xmorderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(XMOrderInfoID);
                        if (xmorderInfo != null && xmorderInfo.FinancialAudit == false)
                        {
                            xmorderInfo.FinancialAudit = true;
                            base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);

                            //操作记录
                            XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                            record1.PropertyName = "FinancialAuditRecord";
                            record1.OldValue = System.Convert.ToString(false);
                            record1.NewValue = System.Convert.ToString(true);
                            record1.OrderInfoId = XMOrderInfoID;
                            record1.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            record1.UpdateTime = DateTime.Now;
                            base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record1);
                        }
                    }

                }

                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功.");

            }
        }

        /// <summary>
        /// 平台类型关联订单状态 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddPlatformTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var List = new List<string>() { "824"};///需要替换成通用平台的平台id
            if (this.ddPlatformTypeId.SelectedValue != "-1")
            {
                var PlatformTypeId = this.ddPlatformTypeId.SelectedValue.Trim();
                if (List.Contains(this.ddPlatformTypeId.SelectedValue))
                    PlatformTypeId = "508";
                var codetypeinfo = base.CodeTypeService.GetCodeTypeByPlatFormTypeId(PlatformTypeId).SingleOrDefault();
                if (codetypeinfo != null)
                {
                    var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(codetypeinfo.CodeTypeID);

                    this.ddOrderStatusId.Items.Clear();
                    this.ddOrderStatusId.DataSource = codeList;
                    this.ddOrderStatusId.DataValueField = "CodeNO";
                    this.ddOrderStatusId.DataTextField = "CodeName";
                    this.ddOrderStatusId.DataBind();
                    this.ddOrderStatusId.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
            }
        }

        /// <summary>
        /// 判断是否审核
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        protected bool IsAudit(string ID)
        {
            if (ID != null && ID != "")
            {
                var xmorderinfo = base.XMOrderInfoService.GetXMOrderInfoByID(int.Parse(ID));

                if (xmorderinfo.XM_OrderInfoProductDetails != null && xmorderinfo.XM_OrderInfoProductDetails.Count > 0)
                {
                    var productinfo = xmorderinfo.XM_OrderInfoProductDetails.ToList().Where(p => p.IsAudit == true).ToList();

                    if (productinfo != null && productinfo.Count > 0)
                    {
                        return true;//有审核过
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 判断是否排单
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        protected int IsSingleRow(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                var xmorderinfo = base.XMOrderInfoService.GetXMOrderInfoByID(int.Parse(ID));
                if (xmorderinfo.XM_OrderInfoProductDetails != null && xmorderinfo.XM_OrderInfoProductDetails.Count > 0)
                {
                    if (xmorderinfo.PlatformTypeId != 259)
                    {
                        var productinfo = xmorderinfo.XM_OrderInfoProductDetails.ToList().Where(p => p.IsSingleRow == false || p.IsSingleRow == null).ToList();
                        var productinfo1 = xmorderinfo.XM_OrderInfoProductDetails.ToList().Where(p => p.IsSingleRow == true).ToList();
                        if (productinfo != null && productinfo1 != null)
                        {
                            if (productinfo.Count > 0 && productinfo1.Count > 0)
                            {
                                return 2;
                            }
                            else if (productinfo.Count > 0)
                            {
                                return 0;
                            }
                            else if (productinfo1.Count > 0)
                            {
                                return 1;
                            }
                        }
                    }
                    else
                    {
                        var productinfo = xmorderinfo.XM_OrderInfoProductDetails.ToList().Where(x => x.PlatformMerchantCode.StartsWith("CM")).Where(p => p.IsSingleRow == false || p.IsSingleRow == null).ToList();
                        var productinfo1 = xmorderinfo.XM_OrderInfoProductDetails.ToList().Where(x => x.PlatformMerchantCode.StartsWith("CM")).Where(p => p.IsSingleRow == true).ToList();
                        if (productinfo != null && productinfo1 != null)
                        {
                            if (productinfo.Count > 0 && productinfo1.Count > 0)
                            {
                                return 2;
                            }
                            else if (productinfo.Count > 0)
                            {
                                return 0;
                            }
                            else if (productinfo1.Count > 0)
                            {
                                return 1;
                            }
                        }
                    }
                }
            }

            return 0;//false;
        }

        /// <summary>
        /// 唯品会物流导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVPHLogisticsExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string fileName = string.Format("VPHLogisticsExport_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\VPHLogisticsExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;

                    var list = base.XMLogisticsInfoService.GetXMLogisticsInfoListByParam();
                    if (list.Count > 0)
                    {
                        base.ExportManager.ExportVPHLogisticsToXls(filePath, list);
                        CommonHelper.WriteResponseXls(filePath, fileName);
                    }
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        protected void btnLogisticsFeeExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\OrderInfoWithLogisticsFee\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                    var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
                    bool IsAiPu = this.ddXMProject.SelectedValue == "13" ? true : false;//项目名称为艾谱
                    bool IsYingYi = this.ddXMProject.SelectedValue == "17" ? true : false;

                    var NickId = Convert.ToInt32(this.ddlNick.SelectedValue);
                    string nickids = "";
                    if (NickId == 99) //某个项目店铺权限，选择有权限的店铺
                    {
                        var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), xMProjectId, HozestERPContext.Current.User.CustomerID, 0);
                        for (int i = 0; i < nickList.Count; i++)
                        {
                            nickids = nickids + nickList[i].nick_id + ",";
                        }
                        if (nickids.Length > 0)
                        {
                            nickids = nickids.Substring(0, nickids.Length - 1);
                        }
                    }
                    else
                    {
                        nickids = NickId.ToString();
                    }

                    //订单状态
                    string OrderStatusId = this.ddOrderStatusId.SelectedValue.Trim();
                    //时间类型
                    int timetype = int.Parse(this.ddlOrderStatus.SelectedValue.Trim());
                    //平台类型Id
                    int PlatformTypeId = Convert.ToInt32(this.ddPlatformTypeId.SelectedValue.ToString());
                    //是否审单
                    int IsAudit = Convert.ToInt32(this.ddIsAudit.SelectedValue.Trim());
                    //付款时间
                    DateTime? PayDateStart = Convert.ToDateTime(txtPayDateStart.Value.Trim());
                    DateTime? PayDateEnd = Convert.ToDateTime(txtPayDateEnd.Value.Trim());
                    //是否异常
                    int IsAbnormal = Convert.ToInt32(this.ddlIsAbnormal.SelectedValue.Trim());
                    //异常备注
                    bool remarks = this.chkRemarks.Checked;
                    //数据来源
                    string SourceType = this.ddlSourceType.SelectedValue.Trim();
                    //网名
                    string WantID = this.txtWantID.Text.Trim();
                    //是否为我们的订单
                    int IsOurOrder = 1;
                    //手机号码
                    string Mobile = this.txtMobile.Text.Trim();
                    //地址
                    string Address = this.txtAddress.Text.Trim();
                    //等通知
                    int WaitNotice = this.chkWaitNotice.Checked == true ? 1 : 0;
                    //加急
                    int Urgent = this.chkUrgent.Checked == true ? 1 : 0;
                    //能发就发
                    int CanDeliver = this.chkCanDeliver.Checked == true ? 1 : 0;
                    //预约发货时间
                    int AppointDeliveryTime = this.chkAppointDeliveryTime.Checked == true ? 1 : 0;
                    string AppointDeliveryBegin = this.txtAppointDeliveryBegin.Value.Trim();
                    string AppointDeliveryEnd = this.txtAppointDeliveryEnd.Value.Trim();
                    DateTime AppointDeliveryBeginDate = DateTime.Now;
                    DateTime AppointDeliveryEndDate = DateTime.Now;
                    //客服备注
                    string CustomerServiceRemark = this.txtCustomerServiceRemark.Text.Trim();

                    if (AppointDeliveryTime == 1 && (AppointDeliveryBegin == "" || AppointDeliveryEnd == ""))
                    {
                        base.ShowMessage("预约发货开始时间和结束时间不能为空！");
                        return;
                    }

                    if (AppointDeliveryTime == 1)
                    {
                        AppointDeliveryBeginDate = DateTime.Parse(AppointDeliveryBegin);
                        AppointDeliveryEndDate = DateTime.Parse(AppointDeliveryEnd).AddDays(1).AddSeconds(-1);
                    }

                    List<XMOrderInfo> orderInfoList = new List<XMOrderInfo>();
                    orderInfoList = base.XMOrderInfoAPIService.GetXMOrderInfoListSearch(xMProjectId, NickId, this.txtOrderCode.Text.Trim(),
                  this.txtFullName.Text.Trim(), OrderStatusId, PlatformTypeId, PayDateStart, PayDateEnd, IsAudit, remarks,
                  (this.chkIsScalping.Checked == true ? 1 : 0), IsAbnormal, timetype, SourceType, WantID, IsOurOrder, Mobile
                  , Address, WaitNotice, Urgent, CanDeliver, AppointDeliveryTime, AppointDeliveryBeginDate, AppointDeliveryEndDate, CustomerServiceRemark);

                    ExportManager.ExportOrderInfoWithLogisticsFeeExcel(filePath, orderInfoList);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch(Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }
    }
}