using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.Controls;
using HozestERP.Web.Modules;
using JdSdk.Domain;
using Top.Api.Domain;
using HozestERP.BusinessLogic.ManageInventory;
using System.Text;

namespace HozestERP.Web.ManageApplication
{
    public partial class XMApplicationList : BaseAdministrationPage, ISearchPage
    {
        private int childindex = -1;
        public string ManufacturersCodeRecord = "";
        public List<HozestERP.BusinessLogic.ManageProject.XMDelivery> DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
        public List<XMXLMInventory> XLMInventoryList = new List<XMXLMInventory>();
        public List<int> InventoryList = new List<int>();

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnSearch", "ManageApplication.Search");//搜索
                buttons.Add("btnAdd", "ManageApplication.Add");//新增
                buttons.Add("Button1", "ManageApplication.Supervisor");//主管审核
                buttons.Add("Button3", "ManageApplication.NoSupervisor");//主管反审核
                buttons.Add("Button2", "ManageApplication.Financial");//财务审核    
                buttons.Add("Button4", "ManageApplication.NoFinancial");//财务反审核
                buttons.Add("imgBtnDelete", "ManageApplication.Delete");//单条删除 
                buttons.Add("ImgBtnCR", "ManageApplication.Details");//查看详情
                buttons.Add("btnDelete", "ManageApplication.AllDelete");//批量删除
                buttons.Add("btnSendQS", "ManageApplication.SendQS");//推送千胜
                buttons.Add("btnManualPlanBill", "ManageProject.XMOrderInfoList.ManualPlanBill");//批量手动排单
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //批量手动排单
                this.btnManualPlanBill.OnClientClick = "return CkeckShowWindowDetail(SaveApplicationIds(),'手动排单','" + CommonHelper.GetStoreLocation() +
            "ManageProject/XMOrderInfoManualPlanBill.aspx?From=returned',300,170, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                this.btnImportLogisticsFee.OnClientClick = "return ShowWindowDetail('导入物流费用数据','" + CommonHelper.GetStoreLocation() +
"ManageProject/ImportReturnedLogisticsFee.aspx',750,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                if (type == "2")
                {
                    this.Send.SelectedValue = "1";
                    this.Send.Enabled = false;
                    this.Supervisor.SelectedValue = "0";
                    this.Supervisor.Items.RemoveAt(0);
                }
                this.BindGrid(1, Master.PageSize);
                btnManagerAdd_Click(sender, e);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            //this.Master.SetTitleVisible = false;
            //this.btnAdd.OnClientClick = "return ShowWindowDetail('问题新增','" + CommonHelper.GetStoreLocation() + "ManageProject/QuestionEdit.aspx',1100,600, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

            #region 店铺名称绑定

            //店铺数据源 
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 522)
            {
                this.ddlNick.Items.Clear();
                var NickList = base.XMNickService.GetXMNickList();
                var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                if (newNickList.Count() > 0)
                {
                    this.ddlNick.DataSource = newNickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
            }
            else
            {
                //其他
                //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                if (xMNickList.Count() == 0)
                {
                    this.ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                }
                if (xMNickList.Count > 0)
                {
                    this.ddlNick.Items.Clear();
                    this.ddlNick.DataSource = xMNickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-2"));
                }
            }

            #endregion

            //平台类型动态数据绑定
            this.ddlPlatform.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatform.DataSource = codeList;
            this.ddlPlatform.DataTextField = "CodeName";
            this.ddlPlatform.DataValueField = "CodeID";
            this.ddlPlatform.DataBind();
            this.ddlPlatform.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));



        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            this.BindGrid(paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
        }

        public void BindGrid(int paramPageIndex, int paramPageSize, string sortExpression, string sortDirection)
        {
            var ddlPlatform = int.Parse(this.ddlPlatform.SelectedValue);//平台
            var nickid = int.Parse(this.ddlNick.SelectedValue);//店铺
            var timetype = int.Parse(this.timetype.SelectedValue);//时间类型
            var ApplicaType = int.Parse(this.ApplicaType.SelectedValue);//申请类型
            var Supervisor = int.Parse(this.Supervisor.SelectedValue);//客服审核
            var Financial = int.Parse(this.Financial.SelectedValue);//财务审核
            var Send = int.Parse(this.Send.SelectedValue);//财务审核
            var txtSrvAfterCustomerID = this.txtSrvAfterCustomerID.Text.Trim();//订单号
            var tel = txtTel.Text.Trim();//手机号
            var fullName = txtFullName.Text.Trim();//姓名
            var txtBeginDate = this.txtBeginDate.SelectedDate;//开始时间
            var txtEndDate = this.txtEndDate.SelectedDate;//结束时间
            if (txtBeginDate == null)
            {
                var ti = DateTime.Now.AddDays(-7);
                var ti2 = DateTime.Now;
                this.txtBeginDate.SelectedDate = DateTime.Parse(ti.Year + "-" + ti.Month + "-" + ti.Day);
                this.txtEndDate.SelectedDate = DateTime.Parse(ti2.Year + "-" + ti2.Month + "-" + ti2.Day);
                txtBeginDate = DateTime.Parse(ti.Year + "-" + ti.Month + "-" + ti.Day);
                txtEndDate = ti2;
            }
            else
            {
                this.txtBeginDate.SelectedDate = txtBeginDate;
                txtEndDate = txtEndDate.Value.AddDays(+1).AddSeconds(-1);
            }
            var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
            List<int?> a = new List<int?> { };
            if (nickid == -2)
            {
                foreach (var list in xMNickList)
                {
                    a.Add(list.nick_id);
                }
            }

            var xmConsultation = base.XMApplicationService.GetXMConsultationList(ddlPlatform, nickid, timetype, ApplicaType, Supervisor, Financial, Send, txtSrvAfterCustomerID, txtBeginDate, txtEndDate, a, tel, fullName);
            var pageList = new PagedList<XMApplication>(xmConsultation, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            if (this.Master.GridViewSortField == "")
            {
                pageList = new PagedList<XMApplication>(xmConsultation, paramPageIndex, paramPageSize, "CreateDate", "DESC");
            }
            //if (QuestionType == "Feedback")
            //{
            //if (this.RowEditIndex == -1)
            //{
            //    //新增编码行
            //    this.gvQuestion.EditIndex = pageList.Count();
            //    pageList.Add(new XMApplication());
            //}
            //else
            //{
            //    this.gvQuestion.EditIndex = this.RowEditIndex;
            //}
            //}
            this.Master.BindData(this.gvQuestion, pageList, paramPageSize + 1);
        }

        #endregion

        protected void hidBtnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
                {
                    base.ShowMessage("请输入结束日期");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim()))
                {
                    base.ShowMessage("请输入开始日期");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim())
                && !string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
            {
                DateTime dt = new DateTime();
                if (!DateTime.TryParse(txtBeginDate.ctlDateTime.Text.Trim(), out dt))
                {
                    base.ShowMessage("开始日期输入错误");
                    return;
                }
                if (!DateTime.TryParse(txtEndDate.ctlDateTime.Text.Trim(), out dt))
                {
                    base.ShowMessage("结束日期输入错误");
                    return;
                }

                if (DateTime.Parse(txtEndDate.ctlDateTime.Text.Trim()) < DateTime.Parse(txtBeginDate.ctlDateTime.Text.Trim()))
                {
                    base.ShowMessage("结束日期不能小于开始日期");
                    return;
                }
            }

            this.BindGrid(1, Master.PageSize);
            ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        protected void gvQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var mXMQuestion = (XMApplication)e.Row.DataItem;
            LinkButton lbtnOrderNo = e.Row.FindControl("lbtnOrderNo") as LinkButton;
            ImageButton ImgBtnCR = e.Row.FindControl("ImgBtnCR") as ImageButton;
            Label lblApplicationType = e.Row.FindControl("lblApplicationType") as Label;
            HtmlInputCheckBox chkAll = e.Row.FindControl("chkAll") as HtmlInputCheckBox;
            ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
            CheckBox chkSelected = e.Row.FindControl("chkSelected") as CheckBox;

            //Label SupervisorStatus = e.Row.FindControl("SupervisorStatus") as Label;
            //Label FinancialStatus = e.Row.FindControl("FinancialStatus") as Label;  
            LinkButton lbtnReservepriceOrder = e.Row.FindControl("lbtnReservepriceOrder") as LinkButton;
            if (lbtnOrderNo != null)
            {
                lbtnOrderNo.Text = mXMQuestion.OrderCode;
                lbtnOrderNo.OnClientClick = "return ShowWindowDetail('订单详情','" + CommonHelper.GetStoreLocation()
                                            + "ManageProject/XMOrderUpdate.aspx?XMApplicationOrderCode=" + lbtnOrderNo.CommandArgument.ToString()
                                            + "&XMOrderType=Application"
                                            + "', 1000, 750, this, function(){document.getElementById('" + this.hidBtnSearch.ClientID + "').click();});";
            }

            if (lbtnReservepriceOrder != null)
            {
                lbtnReservepriceOrder.Text = mXMQuestion.ReservepriceOrder;
                lbtnReservepriceOrder.OnClientClick = "return ShowWindowDetail('补价订单详情','" + CommonHelper.GetStoreLocation()
                                            + "ManageProject/XMOrderUpdate.aspx?XMApplicationOrderCode=" + lbtnReservepriceOrder.CommandArgument.ToString()
                                            + "&XMOrderType=Application"
                                            + "', 1000, 750, this, function(){document.getElementById('" + this.hidBtnSearch.ClientID + "').click();});";
            }

            this.btnpaidan.OnClientClick = "return CkeckShowWindowDetail(SaveReturnIDs(),'选择出库仓库','" + CommonHelper.GetStoreLocation() +
"ManageApplication/ApplicationSaleDelivery.aspx',300,170, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (mXMQuestion != null)
                {
                    string paramScript1 = "return ShowWindowDetail('进退货申请详细','" + CommonHelper.GetStoreLocation() + "ManageApplication/XMApplicationAdd.aspx?type=2"
                         + "&scid=" + mXMQuestion.ID +
                        "',1000,650, this, function(){document.getElementById('" + this.hidBtnSearch.ClientID + "').click();});";
                    if (ImgBtnCR != null) ImgBtnCR.Attributes.Add("onclick", paramScript1);
                }
            }
            if (mXMQuestion != null)
            {
                if (mXMQuestion.ApplicationType.Value == Convert.ToInt32(AppStatusEnum.tuihuo))
                {
                    lblApplicationType.Text = "先退货后退款";
                }
                else if (mXMQuestion.ApplicationType.Value == Convert.ToInt32(AppStatusEnum.huanhuo))
                {
                    lblApplicationType.Text = "换货";
                }
                else if (mXMQuestion.ApplicationType.Value == Convert.ToInt32(AppStatusEnum.weifahuo))
                {
                    lblApplicationType.Text = "未发货退款";
                }
                else if (mXMQuestion.ApplicationType.Value == Convert.ToInt32(AppStatusEnum.secondtuihuan))
                {
                    lblApplicationType.Text = "先退款后退货";
                }
                else if (mXMQuestion.ApplicationType.Value == Convert.ToInt32(AppStatusEnum.tuiyunfei))
                {
                    lblApplicationType.Text = "退运费";
                }
                else if (mXMQuestion.ApplicationType.Value == Convert.ToInt32(AppStatusEnum.shouhou))
                {
                    lblApplicationType.Text = "售后";
                }
                else if (mXMQuestion.ApplicationType.Value == Convert.ToInt32(AppStatusEnum.shouzhong))
                {
                    lblApplicationType.Text = "售中";
                }

                if (mXMQuestion.SupervisorStatus == true)//mXMQuestion.FinancialStatus == true ||
                {
                    imgBtnDelete.Visible = false;
                }
            }
        }

        /// <summary>
        /// 添加退换货申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnManagerAdd_Click(object sender, EventArgs e)
        {
            btnAdd.OnClientClick = "return ShowWindowDetail('添加退换货申请','" + CommonHelper.GetStoreLocation()
            + "ManageApplication/XMApplicationAdd.aspx?type=" + 1
            + "&orderid=" + 0
            + "', 1000, 650, this,  function(){document.getElementById('" + this.hidBtnSearch.ClientID + "').click();});";

        }

        /// <summary>
        /// 主管审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSup_Click(object sender, EventArgs e)
        {
            List<int> questionIDs = this.Master.GetSelectedIds(this.gvQuestion);
            if (questionIDs.Count <= 0)
            {
                base.ShowMessage("未选择任何记录！");
                return;
            }
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in questionIDs)
                {
                    var xMQuestion = base.XMApplicationService.GetXMApplicationByID(item);
                    if (xMQuestion != null)
                    {

                        xMQuestion.SupervisorStatus = true;
                        xMQuestion.UpdateID = HozestERPContext.Current.User.CustomerID;
                        xMQuestion.UpdateDate = DateTime.Now;
                        base.XMApplicationService.UpdateXMApplication(xMQuestion);
                    }
                }
                scope.Complete();
            }
            base.ShowMessage("主管审核成功.");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 主管反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSupNo_Click(object sender, EventArgs e)
        {
            List<int> questionIDs = this.Master.GetSelectedIds(this.gvQuestion);
            if (questionIDs.Count <= 0)
            {
                base.ShowMessage("未选择任何记录！");
                return;
            }
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in questionIDs)
                {
                    var xMQuestion = base.XMApplicationService.GetXMApplicationByID(item);
                    if (xMQuestion != null)
                    {

                        xMQuestion.SupervisorStatus = false;
                        xMQuestion.UpdateID = HozestERPContext.Current.User.CustomerID;
                        xMQuestion.UpdateDate = DateTime.Now;
                        base.XMApplicationService.UpdateXMApplication(xMQuestion);

                        if (xMQuestion.FinishTime != null)//xMQuestion.FinancialStatus == true && 
                        {
                            base.ShowMessage("退货单已经完成，无法执行主管反审核操作！");
                            return;
                        }
                    }
                }
                scope.Complete();
            }
            base.ShowMessage("主管反审核成功！");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        #region 财务审核与反审核


        #endregion

        protected void btnDeliver_Click(object sender, EventArgs e)
        {
            string msg = "";
            List<int> questionIDs = this.Master.GetSelectedIds(this.gvQuestion);
            if (questionIDs.Count <= 0)
            {
                base.ShowMessage("您没有选择任何记录！");
                return;
            }
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in questionIDs)
                {
                    var ApplicationInfo = base.XMApplicationService.GetXMApplicationByID(item);
                    if (ApplicationInfo != null)
                    {
                        if (ApplicationInfo.ApplicationType == 6)//换货
                        {
                            if (ApplicationInfo.IsSend == true && ApplicationInfo.SupervisorStatus == true && (ApplicationInfo.IsSingleRow == null || ApplicationInfo.IsSingleRow == false))//&& ApplicationInfo.FinancialStatus == true
                            {
                                int OrderInfoProductCount = 0;//有效的订单产品条数
                                int DeliveryProductCount = 0;//能排单的订单产品条数
                                int WarehouseID = 0;
                                int ProvinceWarehouseID = 0;

                                DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
                                XLMInventoryList = new List<XMXLMInventory>();
                                InventoryList = new List<int>();

                                List<XMApplicationExchange> OrderInfoProductUnSpare = new List<XMApplicationExchange>();//无备用地址产品
                                List<XMApplicationExchange> OrderInfoProductSpare = new List<XMApplicationExchange>();//有备用地址产品
                                List<XMApplicationExchange> LatexPillowUnSpare = new List<XMApplicationExchange>();//乳胶枕，U型枕，无备用地址产品
                                List<XMApplicationExchange> LatexPillowSpare = new List<XMApplicationExchange>();//乳胶枕，U型枕，有备用地址产品

                                var Info = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(ApplicationInfo.OrderCode);
                                if (Info != null)
                                {
                                    string Address = Info.Province + Info.City + Info.County + Info.DeliveryAddress;
                                    var warehouse = GetProvinceWarehouse(Address);
                                    if (warehouse == null)
                                    {
                                        msg += "订单" + Info.OrderCode + "的地址不属于任一个仓库！<br/>";
                                        continue;
                                    }
                                    else
                                    {
                                        WarehouseID = (int)warehouse.WarehouseID;
                                        ProvinceWarehouseID = warehouse.ID;
                                    }

                                    var list = base.XMApplicationExchangeService.GetXMApplicationExchangeListByApplicationIDType(ApplicationInfo.ID, 1);
                                    foreach (var info in list)
                                    {
                                        if (info.ProductName.IndexOf("床笠") != -1 || info.ProductName.IndexOf("运费") != -1 || info.ProductName.IndexOf("邮费") != -1 || info.ProductName.IndexOf("无产品") != -1)
                                        {
                                            continue;
                                        }

                                        OrderInfoProductCount++;
                                        var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 710);
                                        if (info.ProductName.IndexOf("乳胶枕") != -1 || info.ProductName.IndexOf("U型枕") != -1)
                                        {
                                            if (spareAddress != null)
                                            {
                                                Address = spareAddress.Province + spareAddress.City + spareAddress.County + spareAddress.DeliveryAddress;
                                                warehouse = GetProvinceWarehouse(Address);
                                                if (warehouse == null)
                                                {
                                                    msg += "订单" + Info.OrderCode + ",产品编码：" + info.Manufacturers + "的备用地址不属于任一个仓库！<br/>";
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
                                                    msg += "订单" + Info.OrderCode + ",产品编码：" + info.Manufacturers + "的备用地址不属于任一个仓库！<br/>";
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

                                    if (OrderInfoProductUnSpare.Count > 0)
                                    {
                                        msg = ToPlanBill(OrderInfoProductUnSpare, Info, ApplicationInfo, WarehouseID, ProvinceWarehouseID, 1, msg);//无备用地址产品
                                    }
                                    if (LatexPillowUnSpare.Count > 0)
                                    {
                                        msg = ToPlanBill(LatexPillowUnSpare, Info, ApplicationInfo, WarehouseID, ProvinceWarehouseID, 3, msg);//乳胶枕，U型枕，无备用地址产品
                                    }
                                    if (OrderInfoProductSpare.Count > 0)
                                    {
                                        msg = ToPlanBill(OrderInfoProductSpare, Info, ApplicationInfo, WarehouseID, ProvinceWarehouseID, 2, msg);//有备用地址产品
                                    }
                                    if (LatexPillowSpare.Count > 0)
                                    {
                                        msg = ToPlanBill(LatexPillowSpare, Info, ApplicationInfo, WarehouseID, ProvinceWarehouseID, 4, msg);//乳胶枕，U型枕，有备用地址产品
                                    }

                                    foreach (var delivery in DeliveryList)
                                    {
                                        if (delivery.XM_Delivery_Details != null && delivery.XM_Delivery_Details.Count > 0)
                                        {
                                            DeliveryProductCount += delivery.XM_Delivery_Details.Count;
                                        }
                                    }

                                    if (OrderInfoProductCount > 0 && OrderInfoProductCount == DeliveryProductCount)
                                    {
                                        foreach (var delivery in DeliveryList)
                                        {
                                            delivery.OrderRemarks = ApplicationInfo.Remarks;//备注
                                            base.XMDeliveryService.InsertXMDelivery(delivery);
                                        }

                                        //换货-排单完成
                                        ApplicationInfo.IsSingleRow = true;
                                        ApplicationInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        ApplicationInfo.UpdateDate = DateTime.Now;
                                        base.XMApplicationService.UpdateXMApplication(ApplicationInfo);

                                        //减喜临门当日库存
                                        for (int i = 0; i < XLMInventoryList.Count; i++)
                                        {
                                            XLMInventoryList[i].Inventory = InventoryList[i];
                                            base.XMXLMInventoryService.UpdateXMXLMInventory(XLMInventoryList[i]);
                                        }
                                        //操作记录
                                        XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                        record.PropertyName = "换货自动排单";
                                        record.OldValue = "";
                                        record.NewValue = "新增";
                                        record.OrderInfoId = Info.ID;
                                        record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                        record.UpdateTime = DateTime.Now;
                                        base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                    }
                                }
                                else
                                {
                                    msg += "订单:" + ApplicationInfo.OrderCode + "不存在！<br/>";
                                }
                            }
                            else
                            {
                                msg += "订单:" + ApplicationInfo.OrderCode + "未审核或已排单！<br/>";
                            }
                        }
                        else
                        {
                            msg += "订单:" + ApplicationInfo.OrderCode + "的申请类型错误！<br/>";
                        }
                    }
                }
                scope.Complete();
            }
            if (msg != "")
            {
                base.ShowMessage(msg);
            }
            else
            {
                base.ShowMessage("生成发货单成功！");
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }

        public string ToPlanBill(List<XMApplicationExchange> list, XMOrderInfo Info, XMApplication ApplicationInfo, int WarehouseID, int ProvinceWarehouseID, int type, string msg)
        {
            if (type == 1 || type == 3)
            {
                bool ProductExist = false;
                if (!GetPlanBillResult(list, Info, null, WarehouseID, type))//排单不成功
                {
                    var MoveCargo = base.XMOrderInfoService.AgreeMoveCargo(null, ApplicationInfo);
                    if (MoveCargo)//允许调货
                    {
                        var SpareList = base.ProvinceWarehouseSpareService.GetProvinceWarehouseSpareByProvinceWarehouseID(ProvinceWarehouseID);
                        if (SpareList != null && SpareList.Count > 0)
                        {
                            foreach (var item in SpareList)
                            {
                                if (GetPlanBillResult(list, Info, null, (int)item.SpareWarehouseID, type))
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
                    msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                }
            }
            else if (type == 2 || type == 4)
            {
                List<int?> Ids = new List<int?>();
                var IDs = list.Select(x => x.ID).ToList();
                var SpareAddressList = base.XMSpareAddressService.GetXMSpareAddressListByIDs(IDs, 710);
                foreach (var info in list)
                {
                    if (Ids.Contains(info.ID))
                    {
                        continue;
                    }
                    int warehouseID = 0;
                    int provinceWarehouseID = 0;
                    var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 710);
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
                            if (!GetPlanBillResult(List, Info, spareAddress, warehouseID, type))//排单不成功
                            {
                                var MoveCargo = base.XMOrderInfoService.AgreeMoveCargo(null, ApplicationInfo);
                                if (MoveCargo)//允许调货
                                {
                                    var SpareList = base.ProvinceWarehouseSpareService.GetProvinceWarehouseSpareByProvinceWarehouseID(provinceWarehouseID);
                                    if (SpareList != null && SpareList.Count > 0)
                                    {
                                        foreach (var item in SpareList)
                                        {
                                            if (GetPlanBillResult(List, Info, spareAddress, (int)item.SpareWarehouseID, type))
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
                                msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                            }
                        }
                    }
                }
            }
            return msg;
        }

        public bool GetPlanBillResult(List<XMApplicationExchange> list, XMOrderInfo Info, XMSpareAddress SpareAddress, int WarehouseID, int type)
        {
            ManufacturersCodeRecord = "";
            bool complete = true;
            HozestERP.BusinessLogic.ManageProject.XMDelivery delivery = ToInsertDelivery(Info, SpareAddress, type);
            delivery.XM_Delivery_Details = new List<XMDeliveryDetails>();

            foreach (var info in list)
            {
                if (type == 1 || type == 2)
                {
                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(WarehouseID, info.Manufacturers, "");
                    if (exist.Count > 0 && exist[0].Inventory >= info.ProductNum)
                    {
                        if (delivery.Shipper == 0)
                        {
                            var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.Manufacturers);
                            if (product != null && product.Count > 0)
                            {
                                delivery.Shipper = product[0].Shipper;
                            }
                        }

                        delivery.XM_Delivery_Details.Add(GetDeliveryDetails(info, Info.OrderCode, WarehouseID, Info.PlatformTypeId.Value));
                        //减喜临门当日库存
                        InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                        XLMInventoryList.Add(exist[0]);
                    }
                    else
                    {
                        complete = false;
                        ManufacturersCodeRecord += "产品编码：" + info.Manufacturers + "，";
                    }
                }

                if (type == 3 || type == 4)//乳胶枕，U型枕，无备用地址
                {
                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(693, info.Manufacturers, "");//南方仓库
                    if (exist.Count > 0 && exist[0].Inventory >= info.ProductNum)
                    {
                        if (delivery.Shipper == 0)
                        {
                            var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.Manufacturers);
                            if (product != null && product.Count > 0)
                            {
                                delivery.Shipper = product[0].Shipper;
                            }
                        }

                        delivery.XM_Delivery_Details.Add(GetDeliveryDetails(info, Info.OrderCode, 693, Info.PlatformTypeId.Value));
                        //减喜临门当日库存
                        InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                        XLMInventoryList.Add(exist[0]);
                    }
                    else
                    {
                        complete = false;
                        ManufacturersCodeRecord += "产品编码：" + info.Manufacturers + "，";
                    }
                }
            }

            if (complete == true && delivery.XM_Delivery_Details != null && delivery.XM_Delivery_Details.Count > 0)
            {
                DeliveryList.Add(delivery);
            }

            return complete;
        }

        public HozestERP.BusinessLogic.ManageProject.XMDelivery ToInsertDelivery(XMOrderInfo Info, XMSpareAddress SpareAddress, int type)
        {
            HozestERP.BusinessLogic.ManageProject.XMDelivery info = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
            info.DeliveryTypeId = 708;//换货
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
            return info;
        }

        public XMDeliveryDetails GetDeliveryDetails(XMApplicationExchange ProductDetails, string OrderCode, int WarehouseID, int PlatformTypeId)
        {
            string PrdouctName = "";
            string Specifications = "";

            XMDeliveryDetails detail = new XMDeliveryDetails();
            //detail.DeliveryId = DeliveryIDType;
            detail.DetailsTypeId = (int)StatusEnum.NormalOrder;//正常订单
            detail.OrderNo = OrderCode;
            var ProductDetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(ProductDetails.PlatformMerchantCode, PlatformTypeId);
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

        protected void gvQuestion_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //this.RowEditIndex = e.NewEditIndex;
            //this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

            //int Id = 0;
            //int index = e.NewEditIndex;
            //int Nindex = index;
            //int.TryParse(this.gvQuestion.DataKeys[Nindex].Value.ToString(), out Id);
            //var row = this.gvQuestion.Rows[Nindex];
            //var product = base.XMConsultationService.GetXMConsultationById(Id);
            //if (product != null)
            //{
            //    var deptId = base.CustomerInfoService.GetCustomerInfoByID(int.Parse(product.CreatorID.ToString()));

            //    var zhuguan = base.EnterpriseService.GetDepartmentById(int.Parse(deptId.DepartmentID.ToString()));
            //    if (HozestERPContext.Current.User.CustomerID == 7)
            //    {

            //    }
            //    else
            //    {
            //        var zgtop = base.EnterpriseService.GetDepartmentById(int.Parse(zhuguan.ParentID.ToString()));
            //        if (product.CreatorID != HozestERPContext.Current.User.CustomerID && zhuguan.DepManagerID != HozestERPContext.Current.User.CustomerID && HozestERPContext.Current.User.CustomerID != 7 && zgtop.DepManagerID != HozestERPContext.Current.User.CustomerID)
            //        {
            //            base.ShowMessage("只有创建人和该组组长和客服总监才能修改此条咨询跟进");
            //            this.RowEditIndex = -1;
            //            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            //            return;
            //        }
            //    }
            //}



            //if (product != null)
            //{
            //    //店铺
            //    DropDownList ddlNick = (DropDownList)row.FindControl("ddlNick");
            //    if (ddlNick != null)
            //    {
            //        ddlNick.SelectedValue = product.NickId.Value.ToString();
            //    }

            //    //平台
            //    DropDownList ddlPlatform = (DropDownList)row.FindControl("Platform");
            //    if (ddlPlatform != null)
            //    {
            //        ddlPlatform.SelectedValue = product.PlatformTypeId.Value.ToString();
            //    }
            //    var LeaderComments = row.FindControl("LeaderComments") as TextBox; //组长点评
            //    var LeaderComments3 = row.FindControl("LeaderComments3") as Label; //组长点评 label
            //    var deptId = base.CustomerInfoService.GetCustomerInfoByID(int.Parse(product.CreatorID.ToString()));
            //    var zhuguan = base.EnterpriseService.GetDepartmentById(int.Parse(deptId.DepartmentID.ToString()));
            //    if (HozestERPContext.Current.User.CustomerID == 7)
            //    {
            //        LeaderComments.ReadOnly = false;
            //        LeaderComments.Visible = true;
            //    }
            //    else
            //    {
            //        var zgtop = base.EnterpriseService.GetDepartmentById(int.Parse(zhuguan.ParentID.ToString()));
            //        if (zhuguan.DepManagerID == HozestERPContext.Current.User.CustomerID || HozestERPContext.Current.User.CustomerID == 7 || zgtop.DepManagerID == HozestERPContext.Current.User.CustomerID)
            //        {
            //            LeaderComments.ReadOnly = false;
            //            LeaderComments.Visible = true;
            //        }
            //        else
            //        {
            //            LeaderComments3.Visible = true;
            //        }
            //    }
            //    //跟进等级
            //    DropDownList FollowGrade = (DropDownList)row.FindControl("FollowGrade");
            //    if (FollowGrade != null)
            //    {
            //        FollowGrade.SelectedValue = product.FollowGrade;
            //    }
            //}

            //ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        protected void gvQuestion_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //this.RowEditIndex = -1;
            //this.BindGrid(Master.PageIndex, Master.PageSize);
            //ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        protected void gvQuestion_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //var row = this.gvQuestion.Rows[e.RowIndex];

            //var hfPlatformId = row.FindControl("Platform") as DropDownList;//平台Id
            //var bqPlatformId = row.FindControl("lblPlatform") as Label;//平台Id 标签
            //var hftxtNickId = row.FindControl("ddlNick") as DropDownList; //店铺Id
            //var hftxtWantID = row.FindControl("txtNickName") as TextBox; //顾客
            //var bqtxtWantID = row.FindControl("lbltxtNickName") as Label; //顾客 biaoqian



            ////var txtOrderNO = row.FindControl("txtPayDateStart") as TextBox; //接待时间
            //var lblOrderNO = row.FindControl("txtWantID2") as TextBox;//未成交类型
            //var txtPlatformName = row.FindControl("txtWantID3") as TextBox;//原因  
            ////var txtNickName = row.FindControl("txtWantID4") as TextBox;//客服  
            //var txtWantID = row.FindControl("NoCause") as DropDownList;//不跟进原因
            //var FollowGrade = row.FindControl("FollowGrade") as DropDownList;//跟进等级
            //var LeaderComments = row.FindControl("LeaderComments") as TextBox; //组长点评
            //var lbltxtNickName = row.FindControl("lbltxtNickName") as Label; //顾客

            //var lbltxtOrderNO = row.FindControl("lbltxtPayDateStart") as Label; //接待时间
            //int QID = Convert.ToInt32(gvQuestion.DataKeys[e.RowIndex].Value.ToString());
            //if (string.IsNullOrEmpty(hftxtWantID.Text.Trim()))
            //{
            //    base.ShowMessage("顾客id不能为空.");
            //    lbltxtNickName.Text = "顾客id不能为空";
            //    lbltxtNickName.ForeColor = System.Drawing.Color.Red;
            //    return;
            //}
            ////if (string.IsNullOrEmpty(txtOrderNO.Text.Trim()))
            ////{
            ////    base.ShowMessage("接待时间不能为空.");
            ////    //lbltxtOrderNO.Text = "接待时间不能为空";
            ////    //lbltxtOrderNO.ForeColor = System.Drawing.Color.Red;
            ////    return;
            ////}
            ////DateTime dt = new DateTime();
            ////if (!DateTime.TryParse(txtOrderNO.Text.Trim(), out dt))
            ////{
            ////    base.ShowMessage("接待时间类型错误.");
            ////    return;
            ////}

            //if (string.IsNullOrEmpty(lblOrderNO.Text.Trim()))
            //{
            //    base.ShowMessage("未成交类型不能为空.");
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtPlatformName.Text.Trim()))
            //{
            //    base.ShowMessage("当日未成交原因不能为空.");
            //    return;
            //}

            ////客服跟进
            //var mXMQuestion = base.XMConsultationService.GetXMConsultationById(QID);
            ////查询平台客户是否重复
            //var iscf = base.XMConsultationService.GetXMConsultationByCx(int.Parse(hfPlatformId.SelectedValue), hftxtWantID.Text.Trim());

            //if (iscf == null && mXMQuestion == null)//新增
            //{
            //    XMConsultation mxmConsultation = new XMConsultation();
            //    mxmConsultation.NickId = Convert.ToInt32(hftxtNickId.SelectedValue);  //店铺id
            //    mxmConsultation.PlatformTypeId = int.Parse(hfPlatformId.SelectedValue);//平台
            //    mxmConsultation.CustomerID = hftxtWantID.Text.Trim();//顾客
            //    mxmConsultation.ReceptionDate = DateTime.Now;  //接待时间
            //    mxmConsultation.NoTurnoverType = lblOrderNO.Text;//未成交类型
            //    mxmConsultation.DateReason = txtPlatformName.Text;//原因
            //    //mxmConsultation.CustomerService = txtNickName.Text;//客服
            //    mxmConsultation.NoCause = int.Parse(txtWantID.SelectedValue);//不跟进原因
            //    mxmConsultation.FollowGrade = FollowGrade.SelectedValue;//跟进等级
            //    mxmConsultation.LeaderComments = LeaderComments.Text;
            //    mxmConsultation.CreatorID = HozestERPContext.Current.User.CustomerID;//创建人
            //    mxmConsultation.Created = DateTime.Now;//创建时间
            //    mxmConsultation.UpdatorID = HozestERPContext.Current.User.CustomerID;//更新人
            //    mxmConsultation.Updated = DateTime.Now;//更新时间
            //    mxmConsultation.IsEnable = false;//是否删除
            //    base.XMConsultationService.InsertXMConsultation(mxmConsultation);
            //    base.ShowMessage("添加成功.");
            //}
            //else if (iscf == null || (hftxtWantID.Text.Trim() == bqtxtWantID.Text.Trim() && int.Parse(hfPlatformId.SelectedValue) == int.Parse(bqPlatformId.Text)))
            //{
            //    if(mXMQuestion!=null) //修改
            //    {
            //        mXMQuestion.NickId = Convert.ToInt32(hftxtNickId.SelectedValue);//店铺id
            //        mXMQuestion.PlatformTypeId = int.Parse(hfPlatformId.SelectedValue);//平台
            //        mXMQuestion.CustomerID = hftxtWantID.Text.Trim();//顾客
            //        //mXMQuestion.ReceptionDate = DateTime.Parse(txtOrderNO.Text);  //接待时间
            //        mXMQuestion.NoTurnoverType = lblOrderNO.Text;//未成交类型
            //        mXMQuestion.DateReason = txtPlatformName.Text;//原因
            //        mXMQuestion.FollowGrade = FollowGrade.SelectedValue;//跟进等级
            //        //mXMQuestion.CustomerService = txtNickName.Text;//客服
            //        mXMQuestion.NoCause = int.Parse(txtWantID.SelectedValue);//不跟进原因
            //        mXMQuestion.LeaderComments = LeaderComments.Text;
            //        mXMQuestion.UpdatorID = HozestERPContext.Current.User.CustomerID;//更新人
            //        mXMQuestion.Updated = DateTime.Now;//更新时间
            //        base.XMConsultationService.UpdateXMConsultation(mXMQuestion);
            //        base.ShowMessage("更新成功.");
            //    }
            //}
            //else 
            //{
            //    base.ShowMessage("平台加客户的数据不能重复.");
            //}

            ////重新绑定
            //this.RowEditIndex = -1;
            //this.BindGrid(Master.PageIndex, Master.PageSize);
            //ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        protected void gvQuestion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = 0;
            if (int.TryParse(this.gvQuestion.DataKeys[e.RowIndex].Value.ToString(), out Id))
            {
                // 问题处理
                var xMQuestion = base.XMApplicationService.GetXMApplicationByID(Id);
                if (xMQuestion != null)
                {
                    xMQuestion.IsEnable = true;
                    xMQuestion.UpdateID = HozestERPContext.Current.User.CustomerID;
                    xMQuestion.UpdateDate = DateTime.Now;
                    base.XMApplicationService.UpdateXMApplication(xMQuestion);

                    var del = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(Id, 0, 0, 0);
                    foreach (var a in del)
                    {
                        base.XMApplicationExchangeService.DeleteXMApplicationExchange(a.ID);
                    }
                }
                //grid 绑定
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("删除成功.");
                ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> questionIDs = this.Master.GetSelectedIds(this.gvQuestion);
            if (questionIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in questionIDs)
                {
                    var xMQuestion = base.XMApplicationService.GetXMApplicationByID(item);
                    if (xMQuestion != null && xMQuestion.SupervisorStatus == false)//&& xMQuestion.FinancialStatus == false
                    {
                        xMQuestion.IsEnable = true;
                        xMQuestion.UpdateID = HozestERPContext.Current.User.CustomerID;
                        xMQuestion.UpdateDate = DateTime.Now;
                        base.XMApplicationService.UpdateXMApplication(xMQuestion);

                        var del = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(item, 0, 0, 0);
                        foreach (var a in del)
                        {
                            base.XMApplicationExchangeService.DeleteXMApplicationExchange(a.ID);
                        }
                    }
                    else
                    {
                        base.ShowMessage("所选项不能删除的项.");
                        return;
                    }

                }
                scope.Complete();
            }
            base.ShowMessage("操作成功.");
            this.BindGrid(Master.PageIndex, Master.PageSize);
            //ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        public int RowEditIndex
        {
            get
            {
                int editIndex = -1;
                try
                {
                    int.TryParse(ViewState["RowEditIndex"].ToString(), out editIndex);
                }
                catch
                {
                }
                return editIndex;
            }
            set
            {
                ViewState["RowEditIndex"] = value;
            }
        }

        public int RowEditIndexDetail
        {
            get
            {
                int editIndex = -1;
                try
                {
                    int.TryParse(ViewState["RowEditIndexDetail"].ToString(), out editIndex);
                }
                catch
                {
                }
                return editIndex;
            }
            set
            {
                ViewState["RowEditIndexDetail"] = value;
            }
        }

        /// <summary>
        /// 获取列表1全部2客服3财务
        /// </summary>
        public string type
        {
            get
            {
                return CommonHelper.QueryString("type");
            }
        }

        /// <summary>
        /// 客户确认发出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGoodsConfirmSendOut_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvQuestion);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                int[] ApplicationTypeList = { 5, 6, 7 };//申请类型（先退货后退款，换货，先退款后退货）
                foreach (var ID in IDs)
                {
                    var Info = base.XMApplicationService.GetXMApplicationByID(ID);
                    if (Info != null)
                    {
                        if (!ApplicationTypeList.Contains((int)Info.ApplicationType))
                        {
                            base.ShowMessage("申请单号：" + Info.ApplicationNo + "，的申请类型不能进行此操作！");
                            return;
                        }

                        if (string.IsNullOrEmpty(Info.ReturnLogisticsNumber))
                        {
                            base.ShowMessage("申请单号：" + Info.ApplicationNo + "，退回物流单号为空！");
                            return;
                        }

                        if (Info.SupervisorStatus == true && Info.GoodsConfirmSendOut != true)
                        {
                            Info.GoodsConfirmSendOut = true;
                            Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.XMApplicationService.UpdateXMApplication(Info);
                        }
                        else
                        {
                            base.ShowMessage("申请单号：" + Info.ApplicationNo + "，主管还未审核或已确认发出！");
                            return;
                        }
                    }
                    else
                    {
                        base.ShowMessage("所选项已不存在！");
                        return;
                    }

                }
                scope.Complete();
            }
            base.ShowMessage("操作成功！");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 货款确认退回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMoneyConfirmReturn_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvQuestion);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                int[] ApplicationTypeList = { 5, 6, 7 };//申请类型（先退货后退款，换货，先退款后退货）
                foreach (var ID in IDs)
                {
                    var Info = base.XMApplicationService.GetXMApplicationByID(ID);
                    if (Info != null)
                    {
                        if (!ApplicationTypeList.Contains((int)Info.ApplicationType))
                        {
                            base.ShowMessage("申请单号：" + Info.ApplicationNo + "，的申请类型不能进行此操作！");
                            return;
                        }

                        if (Info.GoodsConfirmSendOut == true && Info.MoneyConfirmReturn != true)
                        {
                            if ((Info.ApplicationType == 6 && Info.Amount > 0) || Info.ApplicationType != 6)
                            {
                                if (Info.GoodsConfirmReturn == true)
                                {
                                    Info.FinishTime = DateTime.Now;
                                }
                            }

                            Info.MoneyConfirmReturn = true;
                            Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.XMApplicationService.UpdateXMApplication(Info);
                        }
                        else
                        {
                            base.ShowMessage("申请单号：" + Info.ApplicationNo + "，客户还未确认发出或货款已确认退回！");
                            return;
                        }
                    }
                    else
                    {
                        base.ShowMessage("所选项已不存在！");
                        return;
                    }

                }
                scope.Complete();
            }
            base.ShowMessage("操作成功！");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 货物确认退回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGoodsConfirmReturn_Click(object sender, EventArgs e)
        {
            ddlProject.Clear();
            ddlHouse.Clear();
            var projectList = base.XMProjectService.GetXMProjectList();
            projectList.Add(new XMProject()
            {
                Id = -1,
                ProjectName = "所有"
            });
            projectStore.DataSource = projectList.OrderBy(a=>a.Id);
            projectStore.DataBind();
            window1.Show();
        }

        protected void project_Select(object sender, Ext.Net.DirectEventArgs e)
        {
            ddlHouse.Clear();
            var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectId(ddlProject.Value.ToString());
            houseStore.DataSource = wareHouses;
            houseStore.DataBind();
        }

        protected void btnSave_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvQuestion);
            if (IDs.Count <= 0)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录！").Show();
                return;
            }
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                int[] ApplicationTypeList = { 5, 6, 7 };//申请类型（先退货后退款，换货，先退款后退货）
                foreach (var ID in IDs)
                {
                    var Info = base.XMApplicationService.GetXMApplicationByID(ID);
                    if (Info != null)
                    {
                        if(Info.GoodsConfirmReturn==true)
                        {
                            Ext.Net.ExtNet.Msg.Alert("提示", "申请单号：" + Info.ApplicationNo + "货物已经退回！").Show();
                            return;
                        }

                        if (!ApplicationTypeList.Contains((int)Info.ApplicationType))
                        {
                            Ext.Net.ExtNet.Msg.Alert("提示", "申请单号：" + Info.ApplicationNo + "，的申请类型不能进行此操作！").Show();
                            return;
                        }

                        if (Info.GoodsConfirmSendOut == true && Info.GoodsConfirmReturn != true)
                        {
                            if (Info.ApplicationType == 6 && Info.Amount == 0)
                            {
                                Info.FinishTime = DateTime.Now;
                            }
                            else
                            {
                                if (Info.MoneyConfirmReturn == true)
                                {
                                    Info.FinishTime = DateTime.Now;
                                }
                            }

                            var ApplicationExchangeList = XMApplicationExchangeService.GetXMApplicationExchangeByAppID(Info.ID).Where(a => a.IsApplication == 2);

                            DateTime now= DateTime.Now;
                            int CustomerID= HozestERPContext.Current.User.CustomerID;

                            Info.GoodsConfirmReturn = true;
                            Info.ReturnTime = DateTime.Parse(dfReturnTime.Text.ToString());
                            Info.UpdateID = CustomerID;
                            Info.UpdateDate = now;
                            base.XMApplicationService.UpdateXMApplication(Info);

                            string rf = AutoSaleReturnNumber();        //自动生成入库单号
                            XMSaleReturn returnInfo = new XMSaleReturn();
                            returnInfo.Ref = rf;
                            returnInfo.OrderInfoID = 0; //暂时未与订单关联
                            returnInfo.WarehouseId =int.Parse(ddlHouse.Value.ToString());
                            returnInfo.BillStatus = 1000;//状态为已入库
                            returnInfo.RejectionsaleMoney = ApplicationExchangeList.Sum(a=>a.SalesPrice);
                            returnInfo.SaleDeliveryId = Info.ID;
                            returnInfo.PaymentType = 699;
                            returnInfo.Remarks = "";
                            returnInfo.BizUserId = CustomerID;
                            returnInfo.BizDt = now;
                            returnInfo.CreateDate = now;
                            returnInfo.UpdateID = CustomerID;
                            returnInfo.IsEnable = false;
                            base.XMSaleReturnService.InsertXMSaleReturn(returnInfo);

                            int returnInfoID = returnInfo.Id;
                            foreach(var item in ApplicationExchangeList)
                            {
                                XMSaleReturnProductDetails returnDetails = new XMSaleReturnProductDetails();
                                returnDetails.SaleReturnId = returnInfoID;
                                var ProductDetails = XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(item.PlatformMerchantCode, (int)Info.PlatformTypeId);
                                if(ProductDetails.Count<=0)
                                {
                                    Ext.Net.ExtNet.Msg.Alert("提示", "找不到商品编码为："+ item.PlatformMerchantCode + "的商品").Show();
                                    return;
                                }
                                returnDetails.ProductId = ProductDetails[0].ProductId;

                                returnDetails.DeliveryProductsDetailID = item.ID;
                                returnDetails.RejectionProdcutsCount = item.ProductNum;   //退货数量
                                returnDetails.RejectionProductsPrice = item.SalesPrice;  // 退货单价
                                returnDetails.RejectionsaleMoney = item.SalesPrice;  //退货金额
                                returnDetails.CreateDate = now;
                                returnDetails.CreateID = CustomerID;
                                returnDetails.IsEnable = false;
                                base.XMSaleReturnProductDetailsService.InsertXMSaleReturnProductDetails(returnDetails);

                                int warehouseID = int.Parse(ddlHouse.Value.ToString());

                                var inventeryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(ProductDetails[0].ManufacturersCode, warehouseID);
                                if (inventeryInfo != null)                //更新库存
                                {
                                    inventeryInfo.StockNumber += item.ProductNum;
                                    inventeryInfo.CanOrderCount = inventeryInfo.StockNumber;
                                    inventeryInfo.UpdateDate = DateTime.Now;
                                    inventeryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    base.XMInventoryInfoService.UpdateXMInventoryInfo(inventeryInfo);
                                    //更新入库产品条形码
                                    UpdateProductBarCodeList(inventeryInfo.Id, returnDetails.Id);
                                }

                                //更新库存总账主表数据   从表添加一条记录
                                UpdateInventoryLederInfo(warehouseID, returnDetails, ProductDetails[0].ManufacturersCode);
                            }
                        }
                        else
                        {
                            Ext.Net.ExtNet.Msg.Alert("提示", "申请单号：" + Info.ApplicationNo + "，客户还未确认发出或货物已确认退回！").Show();
                            return;
                        }
                    }
                    else
                    {
                        Ext.Net.ExtNet.Msg.Alert("提示", "所选项已不存在！").Show();
                        return;
                    }

                }
                scope.Complete();
            }
            this.BindGrid(Master.PageIndex, Master.PageSize);
            Ext.Net.ExtNet.Msg.Alert("提示", "操作成功！").Show();
            window1.Hide();
        }

        /// <summary>
        /// 提交入库   向库存添加该产品的条形码
        /// </summary>
        /// <param name="inventoryID"></param>
        /// <param name="storageDetailID"></param>
        private void UpdateProductBarCodeList(int inventoryID, int saleReturnProductDetailID)
        {
            //根据产品详情ID 获取入库产品的条形码列表
            var barCodes = base.XMSaleReturnBarCodeDetailService.GetXMSaleReturnBarCodeDetailListBySrdID(saleReturnProductDetailID);
            if (barCodes != null && barCodes.Count > 0)
            {
                //遍历所有条形码
                foreach (XMSaleReturnBarCodeDetail Info in barCodes)
                {
                    //查询该仓库产品条形码是否已经存在
                    var inventoryBarCodes = base.XMInventoryBarcodeDetailService.GetXMInventoryBarcodeDetailListByInventoryIDAndBarCode(inventoryID, Info.BarCode);
                    if (inventoryBarCodes == null)              //该产品条形码不存在  新增
                    {
                        XMInventoryBarcodeDetail inventoryBarCode = new XMInventoryBarcodeDetail();
                        inventoryBarCode.SpdId = inventoryID;
                        inventoryBarCode.PrductId = Info.ProductId;
                        inventoryBarCode.PlatformMerchantCode = Info.PlatformMerchantCode;
                        inventoryBarCode.BarCode = Info.BarCode;
                        inventoryBarCode.CreateDate = inventoryBarCode.UpdateDate = DateTime.Now;
                        inventoryBarCode.UpdateID = inventoryBarCode.CreateID = HozestERPContext.Current.User.CustomerID;
                        inventoryBarCode.IsEnable = false;
                        base.XMInventoryBarcodeDetailService.InsertXMInventoryBarcodeDetail(inventoryBarCode);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHousesId"></param>
        /// <param name="info"></param>
        private void UpdateInventoryLederInfo(int wareHousesId, XMSaleReturnProductDetails info, string platformMerchantCode)
        {
            XMInventoryLedger inventoryLeder = null;
            if (platformMerchantCode != "")
            {
                inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, platformMerchantCode);
                if (inventoryLeder != null)     //更新数据
                {
                    //更新入库数量（加上）
                    inventoryLeder.InCount = (inventoryLeder.InCount == null ? 0 : inventoryLeder.InCount) + info.RejectionProdcutsCount;
                    inventoryLeder.InMoney = info.RejectionProductsPrice * inventoryLeder.InCount;
                    inventoryLeder.UpdateDate = DateTime.Now;
                    inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
                }
                else
                {
                    XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                    inventoryLederInfo.WarehouseId = wareHousesId;
                    inventoryLederInfo.ProductId = info.ProductId;
                    inventoryLederInfo.PlatformMerchantCode = platformMerchantCode;
                    inventoryLederInfo.AfloatCount = 0;
                    inventoryLederInfo.AfloatPrice = info.ProductPrice;
                    inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                    inventoryLederInfo.InCount = info.ProductCount;
                    inventoryLederInfo.InPrice = info.ProductPrice;
                    inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                    inventoryLederInfo.OutCount = 0;
                    inventoryLederInfo.OutPrice = info.ProductPrice;
                    inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                    inventoryLederInfo.CreateDate = DateTime.Now;
                    inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                    base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
                }
                //新增库存总账明细(入库)
                var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, platformMerchantCode);
                decimal price = 0;
                decimal money = 0;
                XMInventoryLedgerDetail details = new XMInventoryLedgerDetail();
                details.WarehouseId = wareHousesId;
                details.ProductId = info.ProductId;
                details.PlatformMerchantCode = platformMerchantCode;
                details.InCount = info.RejectionProdcutsCount;                  //入库数量
                details.InPrice = info.RejectionProductsPrice;                      //入库单价
                details.InMoney = info.RejectionsaleMoney;                      //金额
                details.OutCount = 0;
                details.OutPrice = price;
                details.OutMoney = money;
                if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
                {
                    //默认最后一条（余量）
                    int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                    details.BalanceCount = BalanceCount + details.InCount;
                }
                else
                {
                    details.BalanceCount = details.InCount;
                }
                details.BalancePrice = info.RejectionProductsPrice;
                details.BalanceMoney = details.BalancePrice * details.BalanceCount;
                var saleReturns = base.XMSaleReturnService.GetXMSaleReturnById(info.SaleReturnId);
                if (saleReturns != null)
                {
                    details.RefNumber = saleReturns.Ref;
                }
                details.BizDate = DateTime.Now;
                details.BizUserId = HozestERPContext.Current.User.CustomerID;
                int refType = 1004;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
                details.RefType = refType;
                base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
            }
        }

        private string AutoSaleReturnNumber()
        {
            string SaleReturnCode = "";       //自动生成销售退货单号
            int number = 1;
            var saleReturn = base.XMSaleReturnService.GetXMSaleReturnList();
            if (saleReturn != null && saleReturn.Count > 0)
            {
                number = saleReturn[0].Id + 1;
            }
            SaleReturnCode = "SR" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return SaleReturnCode;
        }

        /// <summary>
        /// 退货推送千胜系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendQS_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvQuestion);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                var ApplicationList = base.XMApplicationService.GetXMApplicationListByIds(IDs);
                foreach (var Info in ApplicationList)
                {
                    if (Info.SupervisorStatus != true)
                    {
                        base.ShowMessage("退货单必须经过审核，才能推送到千胜系统！");
                        return;
                    }
                    if (Info.ApplicationType != 5 && Info.ApplicationType != 6 && Info.ApplicationType != 7)
                    {
                        base.ShowMessage("退换货单号：" + Info.ApplicationNo + "，不能推送千胜系统！");
                        return;
                    }
                }

                string msg = "";
                string method = "qs.returnorder.put";

                foreach (var Info in ApplicationList)
                {
                    StringBuilder body = new StringBuilder();
                    body = GetTHHPutJson(body, Info, ref msg);
                    if (body == null)
                    {
                        //msg += "发货单号：" + Info.DeliveryNumber + "，转换Json格式错误！";
                        continue;
                    }
                    XLMInterface myXLMInterface = new XLMInterface();
                    string url = myXLMInterface.GetUrl(method, body.ToString());
                    string josnStr = myXLMInterface.GetResponseData(body.ToString(), url);//GetInfo(url);
                    if (josnStr == "error")
                    {
                        msg += "网络连接错误，请稍后再试！";
                        break;
                    }

                    Dictionary<string, object> data = myXLMInterface.JsonToDictionary(josnStr);
                    if (data.ContainsKey("flag"))
                    {
                        msg += "退换货单号：" + Info.ApplicationNo + "，" + data["message"] + "！<br/>";
                    }
                    else
                    {
                        if (data["success"].ToString() != "True")
                        {
                            msg += "退换货单号：" + Info.ApplicationNo + "，" + data["message"] + "！<br/>";
                        }
                        else
                        {
                            Info.IsSend = true;//推送成功
                            Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.XMApplicationService.UpdateXMApplication(Info);
                        }
                    }
                }

                if (msg != "")
                {
                    base.ShowMessage(msg);
                }
                else
                {
                    base.ShowMessage("喜临门退货推送成功！");

                    this.BindGrid(1, Master.PageSize);
                }
            }
        }

        public StringBuilder GetTHHPutJson(StringBuilder body, BusinessLogic.ManageApplication.XMApplication myXMApplication, ref string msg)
        {
            try
            {
                var myXMApplicationdetailList = base.XMApplicationExchangeService.GetXMApplicationExchangeListByApplicationIDType(myXMApplication.ID, 2);
                if (myXMApplicationdetailList.Count > 0)
                {
                    var DeliveryList = base.XMDeliveryService.GetXMDeliveryByOrderCodeandPartNo(myXMApplication.OrderCode, myXMApplicationdetailList[0].Manufacturers);
                    if (DeliveryList.Count > 0)
                    {
                        //退回工厂
                        string paraminWarehouseCode = "";
                        if (myXMApplication.FactoryID != null)
                        {
                            var codelist = base.CodeService.GetCodeListInfoByCodeID(int.Parse(myXMApplication.FactoryID.ToString()));
                            if (codelist != null) 
                            {
                                paraminWarehouseCode = codelist.CodeName;
                            }
                        }
                        //退货原因
                        string paramreturnReason = "";
                        if (myXMApplication.ReturnCategoryID != null)
                        {
                            var codelist = base.CodeService.GetCodeListInfoByCodeID(int.Parse(myXMApplication.ReturnCategoryID.ToString()));
                            if (codelist != null)
                            {
                                paramreturnReason = codelist.CodeName;
                            }
                        }

                        //platReturnHeader
                        body.Append("{").Append("\"platReturnHeader\":{").Append("");
                        body.Append("\"inWarehouseCode\":").Append("\"" + paraminWarehouseCode + "\",");//退回仓库
                        body.Append("\"amount\":").Append("\"" + myXMApplication.Amount + "\",");//支付金额
                        body.Append("\"payType\":").Append("\"001\",");//付款方式
                        body.Append("\"refundType\":").Append("\"2\",");//退换货类型
                        body.Append("\"tid\":").Append("\"" + DeliveryList[0].DeliveryNumber + "\",");//销售订单号
                        body.Append("\"outCode\":").Append("\"" + myXMApplication.ApplicationNo + "\",");//外部编号
                        body.Append("\"returnReason\":").Append("\"" + paramreturnReason + "\",");//退换货原因
                        body.Append("\"remark\":").Append("\"" + myXMApplication.Remarks + ",ERP推送" + HozestERPContext.Current.User.CustomerID + "\"},");//备注

                        //platReturnDetails
                        body.Append("\"platReturnDetails\":[");


                        for (int i = 0; i < myXMApplicationdetailList.Count; i++)
                        {
                            body.Append("{");
                            var detail = myXMApplicationdetailList[i];
                            body.Append("\"totalFee\":").Append("\"" + detail.FactoryPrice * detail.ProductNum + "\",");
                            body.Append("\"num\":").Append("\"" + detail.ProductNum + "\",");
                            body.Append("\"outerSkuId\":").Append("\"" + detail.Manufacturers + "\",");
                            body.Append("\"price\":").Append("\"" + detail.FactoryPrice + "\",");
                            body.Append("\"sn\":").Append("\"99919\"}");
                            if (i != myXMApplicationdetailList.Count - 1)
                            {
                                body.Append(",");
                            }
                        }
                        body.Append("]}");

                    }
                    else
                    {
                        msg = "找不到退货商品！";
                    }
                }
                else
                {
                    msg = "没有退货商品！";

                }
                return body;
            }
            catch
            {
                return null;
            }
        }
    }
}
