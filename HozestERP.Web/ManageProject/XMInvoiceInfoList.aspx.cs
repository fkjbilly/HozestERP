using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMInvoiceInfoList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();

                this.btnAdd.OnClientClick = "return ShowWindowDetail('新增发票','" + CommonHelper.GetStoreLocation()
               + "ManageProject/XMInvoiceInfoAdd.aspx?Id=0&Type=0', 800, 450, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";


                this.btnSupplement.OnClientClick = "return CkeckShowWindowDetail(CheckCheckBox(1),'补开发票','" + CommonHelper.GetStoreLocation()
               + "ManageProject/XMInvoiceInfoAdd.aspx?Id=0&Type=1', 800, 450, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";

                this.btnResume.OnClientClick = "return CkeckShowWindowDetail(CheckCheckBox(2),'重开发票','" + CommonHelper.GetStoreLocation()
               + "ManageProject/XMInvoiceInfoAdd.aspx?Id=0&Type=2', 800, 450, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";

                this.BindGrid(1, Master.PageSize);
            }
        }

        private void loadData()
        {
            if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
            {
                List<XMProject> XMProjectList = base.XMOrderInfoAPIService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                if (XMProjectList.Count > 0)
                {
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
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定
            string projectids = "";
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
                    for (int i = 0; i < projectList.ToList().Count; i++)
                    {
                        projectids = projectids + projectList.ToList()[i].Id + ",";
                    }
                    if (projectids.Length > 0)
                    {
                        projectids = projectids.Substring(0, projectids.Length - 1);
                    }
                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                }
            }
            #endregion
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            //控件绑定发票状态
            this.ddlInvoiceStatus.Items.Clear();
            var InvoiceStatusList = base.CodeService.GetCodeListInfoByCodeTypeID(233, false);
            this.ddlInvoiceStatus.DataSource = InvoiceStatusList;
            this.ddlInvoiceStatus.DataTextField = "CodeName";
            this.ddlInvoiceStatus.DataValueField = "CodeID";
            this.ddlInvoiceStatus.DataBind();
            this.ddlInvoiceStatus.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

            //控件绑定发票类型
            this.ddlInvoiceType.Items.Clear();
            var InvoiceTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(235, false);
            this.ddlInvoiceType.DataSource = InvoiceTypeList;
            this.ddlInvoiceType.DataTextField = "CodeName";
            this.ddlInvoiceType.DataValueField = "CodeID";
            this.ddlInvoiceType.DataBind();
            this.ddlInvoiceType.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            if (TabPanelInvoiceInfoType == "ManagerStatusNoEvaluation")
            {
                ddlIsBilling.SelectedValue = "1";
            }
            int InvoiceStatus = int.Parse(this.ddlInvoiceStatus.SelectedValue);
            int InvoiceType = int.Parse(this.ddlInvoiceType.SelectedValue);
            string OrderCode = this.txtOrderCode.Text.Trim();
            string InvoiceHeader = this.txtInvoiceHeader.Text.Trim();
            int SingleRow = int.Parse(this.ddlSingleRow.SelectedValue);
            int bingling = int.Parse(this.ddlIsBilling.SelectedValue);
            int ProjectId = int.Parse(this.ddXMProject.SelectedValue);
            int NickId = int.Parse(this.ddlNick.SelectedValue);
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            DateTime date = DateTime.Now;
            if (Begin != "" || End != "")
            {
                if (Begin == "" || End == "" || !DateTime.TryParse(Begin, out date) || !DateTime.TryParse(End, out date))
                {
                    base.ShowMessage("日期格式不正确！");
                    return;
                }
            }
            if (End != "")
            {
                End = DateTime.Parse(End).AddDays(1).ToString("yyyy-MM-dd");
            }
            var paramOrderState = this.dllOrderState.SelectedValue;//订单状态

            if (paramOrderState == "-1")
            {
                var list = base.XMInvoiceInfoService.GetXMInvoiceInfoListByParm(Begin, End, bingling, InvoiceStatus, InvoiceType, OrderCode, InvoiceHeader, SingleRow, ProjectId, NickId);
                //分页
                var xMXMPremiumsPageList = new PagedList<XMInvoiceInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.grdvClients, xMXMPremiumsPageList, paramPageSize + 1);
            }
            else if (paramOrderState == "1")
            {
                //订单状态：完成
                List<string> OrderStatus = new List<string>();
                OrderStatus.Add("TRADE_FINISHED");
                OrderStatus.Add("FINISHED_L");
                OrderStatus.Add("STATUS_25");
                OrderStatus.Add("ORDER_FINISH");
                OrderStatus.Add("30");
                //确认收货
                var list = base.XMInvoiceInfoService.GetXMInvoiceInfoListByParm(Begin, End, bingling, InvoiceStatus, InvoiceType, OrderCode, InvoiceHeader, SingleRow, ProjectId, NickId, OrderStatus);
                //分页
                var xMXMPremiumsPageList = new PagedList<XMInvoiceInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.grdvClients, xMXMPremiumsPageList, paramPageSize + 1);
            }
            else if (paramOrderState == "2")
            {
                //订单状态：已发货
                List<string> OrderStatus = new List<string>();
                OrderStatus.Add("WAIT_BUYER_CONFIRM_GOODS");
                OrderStatus.Add("WAIT_GOODS_RECEIVE_CONFIRM");
                OrderStatus.Add("STATUS_22");
                OrderStatus.Add("ORDER_OUT_OF_WH");
                OrderStatus.Add("20");
                //确认收货
                var list = base.XMInvoiceInfoService.GetXMInvoiceInfoListByParm(Begin, End, bingling, InvoiceStatus, InvoiceType, OrderCode, InvoiceHeader, SingleRow, ProjectId, NickId, OrderStatus);
                //分页
                var xMXMPremiumsPageList = new PagedList<XMInvoiceInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.grdvClients, xMXMPremiumsPageList, paramPageSize + 1);
            }
        }

        #endregion

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
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
        /// <summary>
        /// 导出发票数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int InvoiceStatus = int.Parse(this.ddlInvoiceStatus.SelectedValue);
                    int InvoiceType = int.Parse(this.ddlInvoiceType.SelectedValue);
                    string OrderCode = this.txtOrderCode.Text.Trim();
                    string InvoiceHeader = this.txtInvoiceHeader.Text.Trim();
                    int SingleRow = int.Parse(this.ddlSingleRow.SelectedValue);
                    int bingling = int.Parse(this.ddlIsBilling.SelectedValue);
                    int ProjectId = int.Parse(this.ddXMProject.SelectedValue);
                    int NickId = int.Parse(this.ddlNick.SelectedValue);
                    //开始日期
                    string Begin = this.txtBeginDate.Value.Trim();
                    //结束日期
                    string End = this.txtEndDate.Value.Trim();
                    DateTime date = DateTime.Now;
                    if (Begin != "" || End != "")
                    {
                        if (Begin == "" || End == "" || !DateTime.TryParse(Begin, out date) || !DateTime.TryParse(End, out date))
                        {
                            base.ShowMessage("日期格式不正确！");
                            return;
                        }
                    }
                    if (End != "")
                    {
                        End = DateTime.Parse(End).AddDays(1).ToString("yyyy-MM-dd");
                    }

                    if (TabPanelInvoiceInfoType == "All"||string.IsNullOrEmpty(TabPanelInvoiceInfoType))
                    {
                        var list = base.XMInvoiceInfoService.GetXMInvoiceInfoListByParm(Begin, End, bingling, InvoiceStatus, InvoiceType, OrderCode, InvoiceHeader, SingleRow, ProjectId, NickId);
                        //导出存放路径
                        string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                        string filePath = string.Format("{0}Upload\\InvoiceInfoExport", HttpContext.Current.Request.PhysicalApplicationPath);
                        if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(filePath);
                        }
                        filePath = filePath + "//" + fileName;
                        base.ExportManager.ExportInvoiceInfoToXls(filePath, list);
                        CommonHelper.WriteResponseXls(filePath, fileName);
                    }
                    else if (TabPanelInvoiceInfoType == "ManagerStatusNoEvaluation")
                    {
                        //订单状态：完成
                        List<string> OrderStatus = new List<string>();
                        OrderStatus.Add("TRADE_FINISHED");
                        OrderStatus.Add("FINISHED_L");
                        OrderStatus.Add("STATUS_25");
                        OrderStatus.Add("ORDER_FINISH");
                        OrderStatus.Add("30");
                        //确认收货
                        var list = base.XMInvoiceInfoService.GetXMInvoiceInfoListByParm(Begin, End, bingling, InvoiceStatus, InvoiceType, OrderCode, InvoiceHeader, SingleRow, ProjectId, NickId, OrderStatus);
                        //导出存放路径
                        string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                        string filePath = string.Format("{0}Upload\\InvoiceInfoExport", HttpContext.Current.Request.PhysicalApplicationPath);
                        if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(filePath);
                        }
                        filePath = filePath + "//" + fileName;
                        base.ExportManager.ExportInvoiceInfoToXls(filePath, list);
                        CommonHelper.WriteResponseXls(filePath, fileName);
                    }
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        protected void btnExportDZFP_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int InvoiceStatus = int.Parse(this.ddlInvoiceStatus.SelectedValue);
                    int InvoiceType = int.Parse(this.ddlInvoiceType.SelectedValue);
                    string OrderCode = this.txtOrderCode.Text.Trim();
                    string InvoiceHeader = this.txtInvoiceHeader.Text.Trim();
                    int SingleRow = int.Parse(this.ddlSingleRow.SelectedValue);
                    int bingling = int.Parse(this.ddlIsBilling.SelectedValue);
                    int ProjectId = int.Parse(this.ddXMProject.SelectedValue);
                    int NickId = int.Parse(this.ddlNick.SelectedValue);
                    //开始日期
                    string Begin = this.txtBeginDate.Value.Trim();
                    //结束日期
                    string End = this.txtEndDate.Value.Trim();
                    DateTime date = DateTime.Now;
                    if (Begin != "" || End != "")
                    {
                        if (Begin == "" || End == "" || !DateTime.TryParse(Begin, out date) || !DateTime.TryParse(End, out date))
                        {
                            base.ShowMessage("日期格式不正确！");
                            return;
                        }
                    }
                    if (End != "")
                    {
                        End = DateTime.Parse(End).AddDays(1).ToString("yyyy-MM-dd");
                    }

                    List<XMInvoiceInfo> list = new List<XMInvoiceInfo>();

                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\InvoiceInfoExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;

                    var paramOrderState = this.dllOrderState.SelectedValue;//订单状态

                    if (paramOrderState == "-1")
                    {
                        list = base.XMInvoiceInfoService.GetXMInvoiceInfoListByParm(Begin, End, bingling, InvoiceStatus, InvoiceType, OrderCode, InvoiceHeader, SingleRow, ProjectId, NickId);
                        base.ExportManager.ExportDzfpInfoToXls(filePath, list);
                        CommonHelper.WriteResponseXls(filePath, fileName);
                    }
                    else if (paramOrderState == "1")
                    {
                        //订单状态：完成
                        List<string> OrderStatus = new List<string>();
                        OrderStatus.Add("TRADE_FINISHED");
                        OrderStatus.Add("FINISHED_L");
                        OrderStatus.Add("STATUS_25");
                        OrderStatus.Add("ORDER_FINISH");
                        OrderStatus.Add("30");
                        //确认收货
                        list = base.XMInvoiceInfoService.GetXMInvoiceInfoListByParm(Begin, End, bingling, InvoiceStatus, InvoiceType, OrderCode, InvoiceHeader, SingleRow, ProjectId, NickId, OrderStatus);
                        base.ExportManager.ExportDzfpInfoToXls(filePath, list);
                        CommonHelper.WriteResponseXls(filePath, fileName);
                    }
                    else if (paramOrderState == "2")
                    {
                        //订单状态：已发货
                        List<string> OrderStatus = new List<string>();
                        OrderStatus.Add("WAIT_BUYER_CONFIRM_GOODS");
                        OrderStatus.Add("WAIT_GOODS_RECEIVE_CONFIRM");
                        OrderStatus.Add("STATUS_22");
                        OrderStatus.Add("ORDER_OUT_OF_WH");
                        OrderStatus.Add("20");
                        //确认收货
                        list = base.XMInvoiceInfoService.GetXMInvoiceInfoListByParm(Begin, End, bingling, InvoiceStatus, InvoiceType, OrderCode, InvoiceHeader, SingleRow, ProjectId, NickId, OrderStatus);
                        base.ExportManager.ExportDzfpInfoToXls(filePath, list);
                        CommonHelper.WriteResponseXls(filePath, fileName);
                    }

                }
                catch (Exception exc)
                {
                    base.ShowMessage(exc.Message);
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = 0;
            if (int.TryParse(this.grdvClients.DataKeys[e.RowIndex].Value.ToString(), out Id))
            {
                var Info = base.XMInvoiceInfoService.GetXMInvoiceInfoByID(Id);
                if (Info != null)
                {
                    Info.IsEnable = true;
                    Info.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    Info.UpdateDate = DateTime.Now;
                    base.XMInvoiceInfoService.UpdateXMInvoiceInfo(Info);
                    var orderinfo = base.XMOrderInfoAPIService.GetXMOrderInfoByOrderCode(Info.OrderCode);
                    if (orderinfo != null)
                    {
                        orderinfo.IsInvoiced = false;//订单信息里是否开票改成false
                        base.XMOrderInfoService.UpdateXMOrderInfo(orderinfo);
                    }
                }

                //grid 绑定
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("删除成功！");
            }
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var Info = (XMInvoiceInfo)e.Row.DataItem;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgBtnSpareAddress = (ImageButton)e.Row.FindControl("imgBtnSpareAddress");
                if (imgBtnSpareAddress != null)
                {
                    imgBtnSpareAddress.OnClientClick = "return ShowWindowDetail('备用地址','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMSpareAddressEdit.aspx?Id=" + Info.ID.ToString() + "&TypeID=721', 400, 420, this, function(){});";
                }

                ImageButton imgBtnEdit = (ImageButton)e.Row.FindControl("imgBtnEdit");
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑发票','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMInvoiceInfoAdd.aspx?Id=" + Info.ID.ToString() + "&Type=0', 800, 450, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";
                }
            }
        }

        protected void btnIsSingleRow_Click(object sender, EventArgs e)
        {
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
                if (IDs.Count <= 0)
                {
                    base.ShowMessage("你没有选择任何记录！");
                    return;
                }
                else
                {
                    //查询所有选中的发票信息
                    var InvoiceInfoList = base.XMInvoiceInfoService.GetXMInvoiceInfoListByIds(IDs);
                    var NotPassList = InvoiceInfoList.Where(a => a.IsScrap == true || a.IsSingleRow == true).ToList();//已排单或已废弃
                    if (NotPassList.Count > 0)
                    {
                        base.ShowMessage("已排单或已废弃的发票不能再参加排单！");
                        return;
                    }

                    var NoTypeList = InvoiceInfoList.Where(a => a.InvoiceType == null).ToList();
                    if (NoTypeList.Count > 0)
                    {
                        base.ShowMessage("发票类型未确定的发票不能再参加排单！");
                        return;
                    }

                    #region 排单
                    foreach (var item in InvoiceInfoList)
                    {
                        if (item != null)
                        {
                            List<XMInvoiceInfoDetail> InvoiceDetailsList = base.XMInvoiceInfoDetailService.GetXMInvoiceInfoDetailListByInvoiceInfoID(item.ID);

                            if (InvoiceDetailsList.Count == 0)
                            {
                                base.ShowMessage("发票明细无数据！");
                                return;
                            }
                            else
                            {
                                #region
                                var DeliveryList = base.XMDeliveryService.GetXMDeliveryByOrderCodeAndDeliveryTypeId(item.OrderCode, 481)
                                    .Where(x => x.IsDelivery == false && x.IsShelve != true).ToList();//赠品

                                if (DeliveryList != null && DeliveryList.Count > 0)
                                {
                                    XMDeliveryDetails deliverDetails = new XMDeliveryDetails();
                                    deliverDetails.OrderNo = item.OrderCode;
                                    deliverDetails.DetailsTypeId = 11;//赠品
                                    deliverDetails.DeliveryId = DeliveryList[0].Id;
                                    deliverDetails.ProductlId = 0;
                                    deliverDetails.PlatformMerchantCode = "";
                                    deliverDetails.PrdouctName = "发票";
                                    deliverDetails.Specifications = "";
                                    deliverDetails.ProductNum = 1;
                                    deliverDetails.InvoiceInfoID = item.ID;
                                    deliverDetails.IsEnabled = false;
                                    deliverDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                    deliverDetails.CreateDate = DateTime.Now;
                                    deliverDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    deliverDetails.UpdateDate = DateTime.Now;
                                    base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliverDetails);
                                }
                                else
                                {
                                    //新增
                                    HozestERP.BusinessLogic.ManageProject.XMDelivery xd = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
                                    xd.DeliveryTypeId = 722;//发票
                                    xd.DeliveryNumber = "ZP" + DateTime.Now.ToString("yyyyMMddHHmmssfff");//赠品发货单号（自动生成）
                                    xd.OrderCode = item.OrderCode;
                                    xd.Price = 0;//运费
                                    //xd.Shipper = Shipper;//发货方
                                    //备用地址
                                    var SpareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(item.ID, 721);
                                    if (SpareAddress != null)
                                    {
                                        xd.FullName = SpareAddress.FullName;
                                        xd.Mobile = SpareAddress.Mobile;
                                        xd.Tel = SpareAddress.Tel;
                                        xd.Province = SpareAddress.Province;
                                        xd.City = SpareAddress.City;
                                        xd.County = SpareAddress.County;
                                        xd.DeliveryAddress = SpareAddress.DeliveryAddress;
                                    }
                                    else
                                    {
                                        var OrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(item.OrderCode);
                                        if (OrderInfo != null)
                                        {
                                            xd.FullName = OrderInfo.FullName;
                                            xd.Mobile = OrderInfo.Mobile;
                                            xd.Tel = OrderInfo.Tel;
                                            xd.Province = OrderInfo.Province;
                                            xd.City = OrderInfo.City;
                                            xd.County = OrderInfo.County;
                                            xd.DeliveryAddress = OrderInfo.DeliveryAddress;
                                        }
                                        else
                                        {
                                            base.ShowMessage("订单号:" + item.OrderCode + "不存在！");
                                            return;
                                        }
                                    }

                                    xd.IsDelivery = false;//是否发货
                                    xd.IsEnabled = false;
                                    xd.CreateId = HozestERPContext.Current.User.CustomerID;
                                    xd.CreateDate = DateTime.Now;
                                    xd.UpdateId = HozestERPContext.Current.User.CustomerID;
                                    xd.UpdateDate = DateTime.Now;
                                    xd.PrintQuantity = 0;//打印次数
                                    xd.PrintBatch = 0;//打印批次
                                    base.XMDeliveryService.InsertXMDelivery(xd);

                                    XMDeliveryDetails deliverDetails = new XMDeliveryDetails();
                                    deliverDetails.OrderNo = item.OrderCode;
                                    deliverDetails.DetailsTypeId = 11;//赠品
                                    deliverDetails.DeliveryId = xd.Id;
                                    deliverDetails.ProductlId = 0;
                                    deliverDetails.PlatformMerchantCode = "";
                                    deliverDetails.PrdouctName = "发票";
                                    deliverDetails.Specifications = "";
                                    deliverDetails.ProductNum = 1;
                                    deliverDetails.InvoiceInfoID = item.ID;
                                    deliverDetails.IsEnabled = false;
                                    deliverDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                    deliverDetails.CreateDate = DateTime.Now;
                                    deliverDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    deliverDetails.UpdateDate = DateTime.Now;
                                    base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliverDetails);
                                }
                                #endregion
                                #region 修改发票排单状态

                                item.IsSingleRow = true;
                                item.UpdateID = HozestERPContext.Current.User.CustomerID;
                                item.UpdateDate = DateTime.Now;
                                base.XMInvoiceInfoService.UpdateXMInvoiceInfo(item);

                                #endregion

                                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                                base.ShowMessage("排单成功！");
                            }
                        }
                    }
                    #endregion
                }
                scope.Complete();
            }
        }

        protected void btnIsScrap_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                foreach (int ID in IDs)
                {
                    var Info = base.XMInvoiceInfoService.GetXMInvoiceInfoByID(ID);
                    if (Info.IsDelivery != true)
                    {
                        base.ShowMessage("订单：" + Info.OrderCode + "，它的发货单还未发货，不可废弃！");
                        return;
                    }
                    if (Info != null)
                    {
                        Info.IsScrap = true;
                        Info.UpdateDate = DateTime.Now;
                        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMInvoiceInfoService.UpdateXMInvoiceInfo(Info);
                    }
                }
                base.ShowMessage("废弃操作成功！");
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }

        protected void btnIsBilling_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                string msg = "";
                foreach (int ID in IDs)
                {
                    var Info = base.XMInvoiceInfoService.GetXMInvoiceInfoByID(ID);
                    if (Info.IsScrap == true)
                    {
                        msg += "订单：" + Info.OrderCode + "，发票已废弃，不可开票！<br/>";
                        continue;
                    }
                    if (Info.InvoiceType == null)
                    {
                        msg += "订单：" + Info.OrderCode + "，发票类型未确定的发票不能开票！<br/>";
                        continue;
                    }
                    if (Info != null)
                    {
                        Info.IsBilling = true;
                        Info.UpdateDate = DateTime.Now;
                        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMInvoiceInfoService.UpdateXMInvoiceInfo(Info);
                    }
                }
                if (msg == "")
                {
                    base.ShowMessage("开票成功！");
                }
                else
                {
                    base.ShowMessage(msg);
                }
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }

        protected void btnIsInvoiceOpen_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                string msg = "";
                foreach (int ID in IDs)
                {
                    var Info = base.XMInvoiceInfoService.GetXMInvoiceInfoByID(ID);
                    if (Info.IsScrap == true)
                    {
                        msg += "订单：" + Info.OrderCode + "，发票已废弃，不可开票！<br/>";
                        continue;
                    }
                    if (Info.InvoiceType == null)
                    {
                        msg += "订单：" + Info.OrderCode + "，发票类型未确定的发票不能开票！<br/>";
                        continue;
                    }
                    if (Info != null)
                    {
                        Info.IsInvoiceOpen = true;
                        Info.UpdateDate = DateTime.Now;
                        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMInvoiceInfoService.UpdateXMInvoiceInfo(Info);
                    }
                }
                if (msg == "")
                {
                    base.ShowMessage("操作成功！");
                }
                else
                {
                    base.ShowMessage(msg);
                }
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }

        protected void btnUnIsBilling_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                string msg = "";
                foreach (int ID in IDs)
                {
                    var Info = base.XMInvoiceInfoService.GetXMInvoiceInfoByID(ID);
                    if (Info.IsScrap == true)
                    {
                        msg += "订单：" + Info.OrderCode + "，发票已废弃，不可取消开票！<br/>";
                        continue;
                    }
                    if (Info.IsDelivery == true)
                    {
                        msg += "订单：" + Info.OrderCode + "，发票已发货，不可取消开票！<br/>";
                        continue;
                    }
                    if (Info != null)
                    {
                        Info.IsBilling = false;
                        Info.UpdateDate = DateTime.Now;
                        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMInvoiceInfoService.UpdateXMInvoiceInfo(Info);
                    }
                }
                if (msg == "")
                {
                    base.ShowMessage("取消开票成功！");
                }
                else
                {
                    base.ShowMessage(msg);
                }
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }

        protected void btnUnIsInvoiceOpen_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                string msg = "";
                foreach (int ID in IDs)
                {
                    var Info = base.XMInvoiceInfoService.GetXMInvoiceInfoByID(ID);
                    if (Info.IsScrap == true)
                    {
                        msg += "订单：" + Info.OrderCode + "，发票已废弃，不可取消开票！<br/>";
                        continue;
                    }
                    if (Info.IsDelivery == true)
                    {
                        msg += "订单：" + Info.OrderCode + "，发票已发货，不可取消开票！<br/>";
                        continue;
                    }
                    if (Info != null)
                    {
                        Info.IsInvoiceOpen = false;
                        Info.UpdateDate = DateTime.Now;
                        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMInvoiceInfoService.UpdateXMInvoiceInfo(Info);
                    }
                }
                if (msg == "")
                {
                    base.ShowMessage("操作成功！");
                }
                else
                {
                    base.ShowMessage(msg);
                }
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
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
            }
        }
        /// <summary>
        /// 发票TabPane 类型
        /// </summary>
        public string TabPanelInvoiceInfoType
        {
            get
            {
                return CommonHelper.QueryString("TabPanelInvoiceInfoType");
            }
        }
    }
}