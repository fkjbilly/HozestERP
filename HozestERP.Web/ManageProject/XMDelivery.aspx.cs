using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using JdSdk;
using JdSdk.Domain;
using JdSdk.Domains;
using JdSdk.Request;
using JdSdk.Response;
using Newtonsoft.Json.Linq;
using Top.Api.Domain;
using WebSocketSharp;
using System.Collections;
using System.Data.SqlClient;
using HozestERP.Web.SmsServiceReference;
using System.Net;
using System.Data;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HozestERP.Web.ManageProject
{
    public partial class XMDelivery : BaseAdministrationPage, ISearchPage
    {
        public static List<XMDeliveryNew> PostListExportList { get; set; }
        public static List<XMDeliveryNew> PostListExportPageList { get; set; }
        public XLMInterface xLMInterface = new BusinessLogic.ManageProject.XLMInterface();
        public static List<XMDeliveryNew> XMDeliveryNewList { get; set;}

        /// <summary>
        /// 按钮 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgDeliveryDetails", "XMDelivery.DeliveryDetails"); //产品明细 
                buttons.Add("imgBtnLogisticsEdit", "ManageProject.XMDelivery.LogisticsEdit"); //发货单管理—编辑物流编号、公司
                buttons.Add("imgBtnLogisticsUpdate", "ManageProject.XMDelivery.LogisticsUpdate"); //发货单管理—保存物流编号、公司 
                buttons.Add("imgBtnLogisticsCancel", "ManageProject.XMDelivery.LogisticsCancel"); //发货单管理—取消物流编号、公司 
                buttons.Add("btnOrdrInfMerger", "ManageProject.XMDelivery.OrdrInfMerger"); //发货单管理—订单合并
                buttons.Add("btnImportLogisticsNumber", "ManageProject.XMDelivery.ImportLogisticsNumber"); //发货单管理—导入物流单号
                buttons.Add("btnImportDeliver", "ManageProject.XMDelivery.btnImportDeliver"); //发货单管理—导入发货
                buttons.Add("btnImportLogisticsCost", "ManageProject.XMDelivery.ImportLogisticsCost"); //发货单管理—导入物流费用
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //弹出导入物流单号窗口(EXT.NET)
                this.btnImportLogisticsNumber.OnClientClick = "return ShowWindowDetail('导入物流单号','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportLogisticsNumberData.aspx',660,280, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //弹出导入物流单号窗口(EXT.NET)
                //    this.btnImportLogisticsNumber1.OnClientClick= "return ShowWindowDetail('导入物流单号','" + CommonHelper.GetStoreLocation() +
                //"ManageProject/ImportLogisticsNumberData.aspx',660,280, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //弹出导入发货窗口(EXT.NET)
                this.btnImportDeliver.OnClientClick = "return ShowWindowDetail('导入发货','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportDeliver.aspx',750,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //弹出导入发货窗口(EXT.NET)
                //    btnImportDeliver1.OnClientClick= "return ShowWindowDetail('导入发货','" + CommonHelper.GetStoreLocation() +
                //"ManageProject/ImportDeliver.aspx',750,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //弹出导入物流费用窗口(EXT.NET)
                this.btnImportLogisticsCost.OnClientClick = "return ShowWindowDetail('导入物流费用数据','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportLogisticsCostData.aspx',750,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //弹出导入物流费用窗口(EXT.NET)
                //    btnImportLogisticsCost1.OnClientClick= "return ShowWindowDetail('导入物流费用数据','" + CommonHelper.GetStoreLocation() +
                //"ManageProject/ImportLogisticsCostData.aspx',750,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //选择快递公司
                //    this.btnDirectThermalPrint.OnClientClick = "return CkeckShowWindowDetail(SaveDeliveryIDs(),'快递公司','" + CommonHelper.GetStoreLocation() +
                //"ManageCustomer/XMChoseExpress.aspx?type=1',300,170, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //选择快递公司(EXT.NET)
                btnDirectThermalPrint.OnClientClick= "return CkeckShowWindowDetail(GetDeliveryIDs(#{GridPaneltest}.getRowsValues({selectedOnly:true})),'快递公司','" + CommonHelper.GetStoreLocation() +
            "ManageCustomer/XMChoseExpress.aspx?type=1',300,170, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                cbIsPrint.Value = -1;

                this.BindddXMProject();//项目
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
            //发货单类型
            this.ddDeliveryTypeId.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(204, false);
            this.ddDeliveryTypeId.DataSource = codeList;
            this.ddDeliveryTypeId.DataTextField = "CodeName";
            this.ddDeliveryTypeId.DataValueField = "CodeID";
            this.ddDeliveryTypeId.DataBind();
            this.ddDeliveryTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));

            //发货方
            this.ddlShipper.Items.Clear();
            var ShipperList = base.CodeService.GetCodeListInfoByCodeTypeID(226, false);
            this.ddlShipper.DataSource = ShipperList;
            this.ddlShipper.DataTextField = "CodeName";
            this.ddlShipper.DataValueField = "CodeID";
            this.ddlShipper.DataBind();
            this.ddlShipper.Items.Insert(0, new ListItem("---所有---", "-1"));

            //发货单状态
            this.ddVerification.Items.Clear();
            var VerificationList = base.CodeService.GetCodeListInfoByCodeTypeID(247, false);
            VerificationList = VerificationList.Where(m => m.CodeName != "异常").OrderBy(m => m.CodeNO).ToList();
            this.ddVerification.DataSource = VerificationList;
            this.ddVerification.DataTextField = "CodeName";
            this.ddVerification.DataValueField = "CodeNo";
            this.ddVerification.DataBind();
            this.ddVerification.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string logisticsNumber = this.txtLogisticsNumber.Text.Trim();     //物流单号
            string logisticsCompany = txtLogisticsCompany.Text.Trim();      //物流公司
            string ordercode = this.txtOrderCode.Text.Trim();//订单编号
            string manufacturersCode = this.txtManufacturersCode1.Text.Trim();//厂家编号
            string deliverynumber = this.txtDeliveryNumber.Text.Trim();//物流单号 
            int ddPrintQuantity = Convert.ToInt32(this.ddPrintQuantity.SelectedValue);//是否打印 
            int ddDeliveryTypeId = Convert.ToInt32(this.ddDeliveryTypeId.SelectedValue);//发货单类型
            string ddlShipper = this.ddlShipper.SelectedValue;//发货方
            string txtFullName = this.txtFullName.Text.Trim();//收货人姓名
            string txtMobileAndTel = this.txtMobileAndTel.Text.Trim();//电话
            string txtDeliveryAddress = this.txtDeliveryAddress.Text.Trim();//收货地址
            string PrintBatch = this.txtPrintBatch.Text.Trim();//打印批次
            int isPrint = int.Parse(cbIsPrint.Value.ToString());
            //项目名称
            int ddXMProject = -1;
            if (this.ddXMProject.Value.ToString() != "")
                ddXMProject = Convert.ToInt32(this.ddXMProject.Value.ToString().Trim());
            int ddlNick = Convert.ToInt32(this.ddlNick.Value.ToString());//店铺
            string nickids = "";//店铺
            if (ddlNick == 99) //某个项目店铺权限，选择有权限的店铺
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", -1, ddXMProject, HozestERPContext.Current.User.CustomerID, 0);
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
                nickids = ddlNick.ToString();
            }

            string PrintBegin = this.txtPrintBegin.Value.Trim();//打印开始时间
            string PrintEnd = this.txtPrintEnd.Value.Trim();//打印结束时间
            string CreateBegin = this.txtCreateDateBegin.Value.Trim();//创单开始时间
            string CreateEnd = this.txtCreateDateEnd.Value.Trim();//创单结束时间
            int IsShelve = int.Parse(this.ddlIsShelve.SelectedValue);//是否挂起
            bool NoOrder = this.chkNoOrder.Checked;//无订单号发货单
            bool packageCheck = chkpackage.Checked;//单礼包
            string verificationStatus = this.ddVerification.SelectedValue;
            //是否发货
            int ddIsDelivery = Convert.ToInt32(this.ddIsDelivery.SelectedValue.Trim());


            if ((PrintBegin != "" && PrintEnd == "") || (PrintBegin == "" && PrintEnd != ""))
            {
                base.ShowMessage("打印开始，结束时间必须同时存在！");
                return;
            }

            if ((CreateBegin != "" && CreateEnd == "") || (CreateBegin == "" && CreateEnd != ""))
            {
                base.ShowMessage("创单开始，结束时间必须同时存在！");
                return;
            }

            var DeliveryList = base.XMDeliveryService.GetXMDeliverySearchList(logisticsNumber, ordercode, manufacturersCode, deliverynumber, ddPrintQuantity, ddDeliveryTypeId
                , txtFullName, txtMobileAndTel, txtDeliveryAddress, ddIsDelivery, ddXMProject, PrintBatch, int.Parse(ddlShipper), nickids, PrintBegin, PrintEnd
                , CreateBegin, CreateEnd, IsShelve, NoOrder, isPrint, verificationStatus, packageCheck, logisticsCompany);//查询物流单list
            PostListExportList = DeliveryList.Distinct().ToList();

            //DeliveryList = DeliveryList.OrderByDescending(x => x.DeliveryNumber).ToList();
            var pageList = new PagedList<XMDeliveryNew>(DeliveryList,this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            //var pageList = new PagedList<XMDeliveryNew>(DeliveryList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            #region 根据发货单号直接分页
            var deliveryNumber = pageList.Select(m => m.DeliveryNumber).Distinct().ToList();
            var deliveryNumberList = deliveryNumber.Skip((paramPageIndex - 1) * paramPageSize).Take(paramPageSize).ToList();
            var list = pageList.Where(m => deliveryNumberList.Contains(m.DeliveryNumber)).ToList();
            pageList = new PagedList<XMDeliveryNew>(list, paramPageIndex, paramPageSize, deliveryNumber.Count);
            #endregion
            PostListExportPageList = PostListExportList;

            this.Master.BindData(this.grdvClients, pageList);

            Ext.Net.Store Store1 = GridPaneltest.GetStore();
            Store1.DataSource= pageList;
            Store1.DataBind();
            
            XMDeliveryNewList = PostListExportPageList;
        }

        #endregion

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //if (e.CommandName.Equals("XMOrderInfoDetail"))
                //{
                //    // this.BindGrid(1, Master.PageSize);
                //    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                //}

                #region 重新排单
                if (e.CommandName.Equals("XMDeliveryChange"))
                {
                    //事务
                    using (TransactionScope scope = new TransactionScope())
                    {
                        string paramMessage = "";

                        //发货单信息
                        var Delivery = base.XMDeliveryService.GetXMDeliveryById(Convert.ToInt32(e.CommandArgument));
                        //订单信息
                        var OrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(Delivery.OrderCode);

                        if (Delivery != null)
                        {
                            if ((bool)Delivery.IsDelivery && (Delivery.IsShelve == null || Delivery.IsShelve == false))
                            {
                                scope.Complete();
                                base.ShowMessage("已发货的发货单不能重新排单！");
                                return;
                            }

                            if (Delivery.DeliveryTypeId == 480 || Delivery.DeliveryTypeId == 708)
                            {
                                #region 正常（订单发货单）<注：需要修改  发货发货单主表中商品编码已取消 （根据发货单明细）>
                                XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                record.PropertyName = "ReSingleRow";
                                record.OldValue = "订单：" + OrderInfo.OrderCode + "  商品：" + Delivery.ProductNo + "  重新排单";
                                record.NewValue = "订单：" + OrderInfo.OrderCode + "  商品：" + Delivery.ProductNo + "  重新排单";
                                record.OrderInfoId = OrderInfo.ID;
                                record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                record.UpdateTime = DateTime.Now;
                                base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);

                                if (Delivery.DeliveryTypeId == 480)
                                {
                                    //选中的明细数据
                                    var xmDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(Delivery.Id);
                                    if (xmDeliveryDetailsList != null && xmDeliveryDetailsList.Count > 0)
                                    {
                                        foreach (var detail in xmDeliveryDetailsList)
                                        {
                                            //修改排单状态、审核状态
                                            var OrderInfoProductList = OrderInfo.XM_OrderInfoProductDetails.Where(p => p.PlatformMerchantCode.Equals(detail.PlatformMerchantCode) && p.ProductNum == detail.ProductNum && p.IsSingleRow == true).ToList();
                                            if (OrderInfoProductList != null && OrderInfoProductList.Count > 0)
                                            {
                                                OrderInfoProductList[0].IsSingleRow = false;
                                                OrderInfoProductList[0].IsAudit = false;
                                                OrderInfoProductList[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                                OrderInfoProductList[0].UpdateDate = DateTime.Now;
                                                base.XMOrderInfoService.UpdateXMOrderInfo(OrderInfo);

                                                if (Delivery.IsShelve == null || Delivery.IsShelve == false)
                                                {
                                                    //喜临门返回库存
                                                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm((int)detail.WarehouseID, OrderInfoProductList[0].TManufacturersCode, "");
                                                    var inventoryNotNickID2 = base.XMInventoryInfoService.GetXMInventoryInfoByParm(OrderInfoProductList[0].TManufacturersCode, (int)detail.WarehouseID);//其他项目判断库存管理里面的可订购数量
                                                    if (exist.Count > 0)
                                                    {
                                                        exist[0].Inventory += detail.ProductNum;
                                                        base.XMXLMInventoryService.UpdateXMXLMInventory(exist[0]);
                                                    }
                                                    if (inventoryNotNickID2 != null) 
                                                    {
                                                        inventoryNotNickID2.CanOrderCount += detail.ProductNum;
                                                        base.XMInventoryInfoService.UpdateXMInventoryInfo(inventoryNotNickID2);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //修改订单审核状态
                                    if (OrderInfo.PlatformTypeId == 376)//亚马逊
                                    {
                                        OrderInfo.OrderStatus = "以接受";
                                    }
                                    OrderInfo.IsAudit = false;
                                    OrderInfo.UpdateDate = DateTime.Now;
                                    OrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    base.XMOrderInfoService.UpdateXMOrderInfo(OrderInfo);

                                    //删除发货信息
                                    Delivery.IsEnabled = true;
                                    Delivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                    Delivery.UpdateDate = DateTime.Now;
                                    base.XMDeliveryService.UpdateXMDelivery(Delivery);
                                }
                                else if (Delivery.DeliveryTypeId == 708)
                                {
                                    var ApplicationList = base.XMApplicationService.GetXMApplicationListByOrderCode(Delivery.OrderCode);
                                    var ApplicationInfo = ApplicationList.Where(x => x.ApplicationType == 6).OrderByDescending(x => x.CreateDate).ToList();//换货
                                    if (ApplicationInfo != null && ApplicationInfo.Count > 0)
                                    {
                                        ApplicationInfo[0].FinancialStatus = false;
                                        ApplicationInfo[0].SupervisorStatus = false;
                                        ApplicationInfo[0].IsSend = false;
                                        ApplicationInfo[0].FinishTime = null;
                                        ApplicationInfo[0].ReturnTime = null;
                                        ApplicationInfo[0].IsSingleRow = false;
                                        ApplicationInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                        ApplicationInfo[0].UpdateDate = DateTime.Now;
                                        base.XMApplicationService.UpdateXMApplication(ApplicationInfo[0]);
                                    }

                                    var DeliveryList = base.XMDeliveryService.GetXMDeliveryByOrderCodeAndDeliveryTypeId(Delivery.OrderCode, 708);
                                    if (DeliveryList != null && DeliveryList.Count > 0)
                                    {
                                        foreach (var item in DeliveryList)
                                        {
                                            //选中的明细数据
                                            var xmDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(item.Id);
                                            foreach (var detail in xmDeliveryDetailsList)
                                            {
                                                var ProductDetailsList = base.XMProductService.GetXMProductListByPlatformMerchantCode(detail.PlatformMerchantCode, -1);
                                                if (ProductDetailsList != null && ProductDetailsList.Count > 0)
                                                {
                                                    var Product = base.XMProductService.GetXMProductById((int)ProductDetailsList[0].ProductId);
                                                    if (Product != null)
                                                    {
                                                        if (Delivery.IsShelve == null || Delivery.IsShelve == false)
                                                        {
                                                            //喜临门返回库存
                                                            var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm((int)detail.WarehouseID, Product.ManufacturersCode, "");
                                                            if (exist.Count > 0)
                                                            {
                                                                exist[0].Inventory += detail.ProductNum;
                                                                base.XMXLMInventoryService.UpdateXMXLMInventory(exist[0]);
                                                            }
                                                            var inventoryNotNickID2 = base.XMInventoryInfoService.GetXMInventoryInfoByParm(Product.ManufacturersCode, (int)detail.WarehouseID);//其他项目判断库存管理里面的可订购数量
                                                            if (inventoryNotNickID2 != null)
                                                            {
                                                                inventoryNotNickID2.CanOrderCount += detail.ProductNum;
                                                                base.XMInventoryInfoService.UpdateXMInventoryInfo(inventoryNotNickID2);
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            //删除发货信息
                                            item.IsEnabled = true;
                                            item.UpdateId = HozestERPContext.Current.User.CustomerID;
                                            item.UpdateDate = DateTime.Now;
                                            base.XMDeliveryService.UpdateXMDelivery(item);
                                        }
                                        paramMessage += "订单号：" + Delivery.OrderCode + "，发货单类型：换货产品，共" + DeliveryList.Count.ToString() + "个发货单已删除！";
                                    }
                                }

                                if (paramMessage == "")
                                {
                                    paramMessage = "操作成功！";
                                }

                                #endregion
                            }
                            else if (Delivery.DeliveryTypeId == 481)
                            {
                                #region 非正常(赠品发货单)
                                if (Delivery.IsDelivery != null)
                                {
                                    //未发货
                                    if (Delivery.IsDelivery.Value == false)
                                    {
                                        var xmDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(Delivery.Id);
                                        {
                                            foreach (var detail in xmDeliveryDetailsList)
                                            {
                                                string ManufacturersCode = "";
                                                if (detail.PlatformMerchantCode != null)
                                                {
                                                    var productDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(detail.PlatformMerchantCode);
                                                    if (productDetail != null && productDetail.Count > 0)
                                                    {
                                                        ManufacturersCode = productDetail[0].ManufacturersCode;
                                                    }
                                                }
                                                XMSaleDeliveryProductDetails saleDeliveryDetail = new XMSaleDeliveryProductDetails();
                                                saleDeliveryDetail.PlatformMerchantCode = ManufacturersCode;
                                                saleDeliveryDetail.SaleCount = detail.ProductNum;
                                                var inventory = base.XMInventoryInfoService.GetXMInventoryInfoByParm(ManufacturersCode, (int)detail.WarehouseID);//其他项目判断库存管理里面的可订购数量
                                                //增加可订购数量
                                                if (inventory != null)
                                                {
                                                    inventory.CanOrderCount += detail.ProductNum;
                                                    base.XMInventoryInfoService.UpdateXMInventoryInfo(inventory);
                                                }
                                            }
                                        }                                        
                                        //根据主表Id 查询明细数据
                                        var DeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(Delivery.Id);

                                        //判断发货明细中的 商品信息是否类型相同  
                                        var DetailsTypeIdListGroupBy = DeliveryDetailsList.GroupBy(p => p.DetailsTypeId.Value).Select(g => g.First()).ToList();//根据类型分组

                                        //明细类型不一致 不可重新排单
                                        if (DetailsTypeIdListGroupBy.Count > 1)
                                        {
                                            paramMessage = "该发货单明细类型不一致,请先拆分再重新排单。";
                                            base.ShowMessage(paramMessage);
                                            return;
                                        }
                                        else if (DetailsTypeIdListGroupBy.Count == 1)
                                        {
                                            #region 累加明细订单号

                                            // 去掉重复的订单号 集合
                                            List<string> CodeNODistinct = new List<string>();

                                            if (DeliveryDetailsList.Count > 0)
                                            {
                                                //取发货单明细 订单编码列
                                                List<string> CodeNoList = DeliveryDetailsList.Select(a => a.OrderNo).ToList();

                                                //定义一个新的List<stirng> 
                                                List<string> CodeNoListNow = new List<string>();

                                                //取所有发货单明细 订单号 组成字符串
                                                string str = "";
                                                foreach (var item in CodeNoList)
                                                {
                                                    str += item + ",";
                                                }

                                                if (!string.IsNullOrEmpty(str))
                                                {
                                                    str = str.Substring(0, str.Length - 1);
                                                }
                                                //字符串串数组
                                                string[] OrderCodestr = str.Split(',');

                                                //把数组转成List<string>
                                                CodeNoListNow = new List<string>(OrderCodestr);

                                                //去掉重复的订单号
                                                CodeNODistinct = CodeNoListNow.Distinct().ToList();
                                            }

                                            #endregion

                                            //返回一个订单号
                                            if (CodeNODistinct.Count == 1)
                                            {
                                                #region 发货单重新排单

                                                // 根据商品编辑统计 明细商品数量    
                                                var GroupByMerchantCode = (from p in DeliveryDetailsList
                                                                           group p by new
                                                                           {
                                                                               PlatformMerchantCode = p.PlatformMerchantCode,
                                                                               DetailsTypeId = p.DetailsTypeId
                                                                           } into g
                                                                           select new XMDeliveryDetails
                                                                           {
                                                                               PlatformMerchantCode = g.Key.PlatformMerchantCode,
                                                                               DetailsTypeId = g.Key.DetailsTypeId,
                                                                               ProductNum = g.Sum(c => c.ProductNum)
                                                                           }).ToList();

                                                if (GroupByMerchantCode.Count > 0)
                                                {
                                                    #region 修改商品管理中 对应的商品厂家库存数量
                                                    for (int i = 0; i < GroupByMerchantCode.Count; i++)
                                                    {
                                                        //根据商品编码查询 产品信息 并修改库存
                                                        var productList = base.XMProductService.getXMProductListByEqusManufacturersCode(GroupByMerchantCode[i].PlatformMerchantCode);
                                                        if (productList.Count > 0)
                                                        {
                                                            XMProduct product = productList[0];
                                                            //厂家库存=原库存+发货单明细库存
                                                            int ManufacturersInventory = product.ManufacturersInventory.Value + GroupByMerchantCode[i].ProductNum.Value;

                                                            product.ManufacturersInventory = ManufacturersInventory;
                                                            product.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                            product.UpdateDate = DateTime.Now;
                                                            base.XMProductService.UpdateXMProduct(product);
                                                        }
                                                    }
                                                    #endregion

                                                    #region 修改 赠品管理中 赠品状态：未排单、 是否排单：否

                                                    //根据发货单明细订单号、类型查询赠品信息
                                                    List<XMPremiums> XMPremiumsList = base.XMPremiumsService.GetXMPremiumsListByOrderCode(CodeNODistinct[0], DetailsTypeIdListGroupBy[0].DetailsTypeId.Value);

                                                    if (XMPremiumsList.Count > 0)
                                                    {
                                                        XMPremiums premiums = XMPremiumsList[0];
                                                        premiums.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsNoHair);
                                                        premiums.IsSingleRow = false;
                                                        premiums.IsEvaluation = false;
                                                        premiums.EvaluationID = null;
                                                        premiums.EvaluationDate = null;
                                                        premiums.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                                                        premiums.ManagerPeople = null;
                                                        premiums.ManagerTime = null;
                                                        premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                                        premiums.UpdateTime = DateTime.Now;
                                                        base.XMPremiumsService.UpdateXMPremiums(premiums);
                                                        if (premiums != null)
                                                        {
                                                            var xMPremiumsDetail = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(premiums.Id);
                                                            if (xMPremiumsDetail != null && xMPremiumsDetail.Count > 0)
                                                            {
                                                                foreach (var parm in xMPremiumsDetail)
                                                                {
                                                                    parm.IsSingleRow = false;
                                                                    parm.UpdateDate = DateTime.Now;
                                                                    parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                                    base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(parm);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    #endregion

                                                    //明细 Id 
                                                    List<int> DeliveryIdList = DeliveryDetailsList.Select(a => a.Id).ToList();
                                                    //删除发货单明细数据
                                                    base.XMDeliveryDetailsService.BatchDeleteXMDeliveryDetails(DeliveryIdList);
                                                    //删除发货单主表信息 
                                                    base.XMDeliveryService.DeleteXMDelivery(Delivery.Id);
                                                }

                                                #region 修改赠品中发票对应的发票管理的状态

                                                var InvoiceInfoIDs = DeliveryDetailsList.Where(x => x.InvoiceInfoID != null).Select(x => x.InvoiceInfoID).ToList();
                                                if (InvoiceInfoIDs != null && InvoiceInfoIDs.Count > 0)
                                                {
                                                    foreach (var id in InvoiceInfoIDs)
                                                    {
                                                        var InvoiceInfo = base.XMInvoiceInfoService.GetXMInvoiceInfoByID((int)id);
                                                        if (InvoiceInfo != null)
                                                        {
                                                            InvoiceInfo.IsSingleRow = false;
                                                            InvoiceInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                            InvoiceInfo.UpdateDate = DateTime.Now;
                                                            base.XMInvoiceInfoService.UpdateXMInvoiceInfo(InvoiceInfo);
                                                        }
                                                    }
                                                }

                                                #endregion

                                                #endregion
                                            }
                                            //返回多个订单号
                                            else if (CodeNODistinct.Count > 1)
                                            {
                                                paramMessage = "该发货单有多个订单号,请先拆分再重新排单！";
                                                base.ShowMessage(paramMessage);
                                                return;
                                            }
                                        }
                                    }
                                    //已发货
                                    else
                                    {
                                        paramMessage = "请选择未发货的发货单！";
                                        base.ShowMessage(paramMessage);
                                        return;
                                    }
                                }
                                #endregion
                            }
                            else if (Delivery.DeliveryTypeId == 722)
                            {
                                //根据主表Id 查询明细数据
                                var DeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(Delivery.Id);

                                var InvoiceInfoIDs = DeliveryDetailsList.Where(x => x.InvoiceInfoID != null).Select(x => x.InvoiceInfoID).ToList();
                                if (InvoiceInfoIDs != null && InvoiceInfoIDs.Count > 0)
                                {
                                    foreach (var id in InvoiceInfoIDs)
                                    {
                                        var InvoiceInfo = base.XMInvoiceInfoService.GetXMInvoiceInfoByID((int)id);
                                        if (InvoiceInfo != null)
                                        {
                                            InvoiceInfo.IsSingleRow = false;
                                            InvoiceInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            InvoiceInfo.UpdateDate = DateTime.Now;
                                            base.XMInvoiceInfoService.UpdateXMInvoiceInfo(InvoiceInfo);
                                        }
                                    }
                                    //删除发货信息
                                    Delivery.IsEnabled = true;
                                    Delivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                    Delivery.UpdateDate = DateTime.Now;
                                    base.XMDeliveryService.UpdateXMDelivery(Delivery);
                                    paramMessage = "操作成功！";
                                }
                            }

                            //删除对应的出库单记录（状态为待出库状态）
                            var saleDeliveries = base.XMSaleDeliveryService.GetXMSaleDeliveryListByParm(Delivery.Id);
                            if (saleDeliveries != null && saleDeliveries.Count > 0)
                            {
                                foreach (XMSaleDelivery parm in saleDeliveries)
                                {
                                    parm.IsEnable = true;
                                    parm.UpdateDate = DateTime.Now;
                                    parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    base.XMSaleDeliveryService.UpdateXMSaleDelivery(parm);
                                    var saleDeliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(parm.Id);
                                    if (saleDeliveryProductDetails != null && saleDeliveryProductDetails.Count > 0)
                                    {
                                        foreach (XMSaleDeliveryProductDetails p in saleDeliveryProductDetails)
                                        {
                                            p.IsEnable = true;
                                            p.UpdateDate = DateTime.Now;
                                            p.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            base.XMSaleDeliveryProductDetailsService.UpdateXMSaleDeliveryProductDetails(p);
                                        }
                                    }
                                }
                            }
                        }

                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                        scope.Complete();
                        if (paramMessage != "")
                        {
                            base.ShowMessage(paramMessage);
                        }
                    }
                }
                #endregion

                #region 订单拆分
                if (e.CommandName.Equals("XMDeliverySplit"))
                {
                    GridView Agrid = (GridView)sender;//父级 grid  

                    //当前行 索引
                    int rowInt = int.Parse(e.CommandArgument.ToString());
                    //明细grid
                    var Bgrid = (GridView)Agrid.Rows[rowInt].FindControl("grdXMDeliveryDetailsManage");

                    ////获取父级Id 
                    //var hdId = (HiddenField)(Bgrid.Rows[rowInt].FindControl("hdId"));
                    ////主表Id
                    //int Id = Convert.ToInt32(hdId.Value); 
                    ////明细Id
                    //var hdDId = (HiddenField)(Bgrid.Rows[rowInt].FindControl("hdDeliveryId"));

                    List<int> DeliveryDetailsIDs = this.Master.GetSelectedIds(Bgrid);
                    if (DeliveryDetailsIDs.Count <= 0)
                    {
                        base.ShowMessage("你没有选择任何记录");
                        return;
                    }
                    else
                    {
                        //事务
                        using (TransactionScope scope = new TransactionScope())
                        {
                            //选中的明细数据
                            var xmDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsById(DeliveryDetailsIDs);

                            //根据Id查询 发货单信息
                            HozestERP.BusinessLogic.ManageProject.XMDelivery Delivery = new BusinessLogic.ManageProject.XMDelivery();

                            //发货单明细 (选中的明细数据)
                            XMDeliveryDetails xMDeliveryDetails = null;

                            string OrderNo = "";
                            int DetailsTypeId = 0;
                            int ProductlId = 0;
                            string PlatformMerchantCode = "";
                            string PrdouctName = "";
                            string Specifications = "";
                            int ProductNum = 0;
                            int WarehouseID = 0;

                            #region
                            if (xmDeliveryDetailsList.Count > 0)
                            {
                                //根据明细主表DeliveryId 查询主表信息
                                Delivery = base.XMDeliveryService.GetXMDeliveryById(xmDeliveryDetailsList[0].DeliveryId.Value);

                                //根据主表Id查询产品记录
                                var XMDeliveryDetailsByDeliveryIdList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(xmDeliveryDetailsList[0].DeliveryId.Value);
                                //当前已选发货单有多条产品明细
                                if (XMDeliveryDetailsByDeliveryIdList.Count > 1)
                                {
                                    #region 多条产品信息 拆分

                                    #region 新增发货单信息
                                    HozestERP.BusinessLogic.ManageProject.XMDelivery xd = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
                                    if (Delivery != null)
                                    {
                                        //新增
                                        #region 生成发货单
                                        xd.DeliveryTypeId = Delivery.DeliveryTypeId;//使用原发货单主表的 发货单类型

                                        if (Delivery.DeliveryTypeId.Value == 481)
                                        {
                                            xd.DeliveryNumber = "ZP" + DateTime.Now.ToString("yyyyMMddHHmmssfff");//赠品发货单号（自动生成）
                                        }
                                        else
                                        {
                                            xd.DeliveryNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");//订单发货单号（自动生成）
                                        }
                                        xd.OrderCode = Delivery.OrderCode;////使用原发货单主表的 订单号
                                        xd.Shipper = Delivery.Shipper;

                                        xd.FullName = Delivery.FullName;
                                        xd.Mobile = Delivery.Mobile;
                                        xd.Tel = Delivery.Tel;
                                        xd.Province = Delivery.Province;
                                        xd.City = Delivery.City;
                                        xd.County = Delivery.County;
                                        xd.DeliveryAddress = Delivery.DeliveryAddress;

                                        xd.Price = 0;//运费
                                        xd.IsDelivery = false;//是否发货
                                        xd.IsEnabled = false;
                                        xd.CreateId = HozestERPContext.Current.User.CustomerID;
                                        xd.CreateDate = DateTime.Now;
                                        xd.UpdateId = HozestERPContext.Current.User.CustomerID;
                                        xd.UpdateDate = DateTime.Now;
                                        xd.PrintQuantity = 0;//打印次数
                                        xd.PrintBatch = 0;//打印批次
                                        base.XMDeliveryService.InsertXMDelivery(xd);
                                        #endregion
                                    }
                                    #endregion

                                    for (int i = 0; i < xmDeliveryDetailsList.Count; i++)
                                    {
                                        xMDeliveryDetails = xmDeliveryDetailsList[i];

                                        OrderNo = xMDeliveryDetails.OrderNo;
                                        DetailsTypeId = xMDeliveryDetails.DetailsTypeId.Value;
                                        ProductlId = xMDeliveryDetails.ProductlId.Value;
                                        PlatformMerchantCode = xMDeliveryDetails.PlatformMerchantCode;
                                        PrdouctName = xMDeliveryDetails.PrdouctName;
                                        Specifications = xMDeliveryDetails.Specifications;
                                        ProductNum = xMDeliveryDetails.ProductNum.Value;
                                        WarehouseID = xMDeliveryDetails.WarehouseID == null ? 0 : xMDeliveryDetails.WarehouseID.Value;

                                        #region 新增发货单明细
                                        if (xd != null)//发货单记录 不未空
                                        {
                                            if (xd.Id != 0)
                                            {
                                                XMDeliveryDetails xmDeliveryDetails = new XMDeliveryDetails();
                                                xmDeliveryDetails.DeliveryId = xd.Id;
                                                xmDeliveryDetails.OrderNo = OrderNo;
                                                xmDeliveryDetails.DetailsTypeId = DetailsTypeId;
                                                xmDeliveryDetails.ProductlId = ProductlId;
                                                xmDeliveryDetails.PlatformMerchantCode = PlatformMerchantCode;
                                                xmDeliveryDetails.PrdouctName = PrdouctName;
                                                xmDeliveryDetails.Specifications = Specifications;
                                                xmDeliveryDetails.ProductNum = ProductNum;
                                                xmDeliveryDetails.WarehouseID = WarehouseID;
                                                xmDeliveryDetails.IsEnabled = false;
                                                xmDeliveryDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                                xmDeliveryDetails.CreateDate = DateTime.Now;
                                                xmDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                xmDeliveryDetails.UpdateDate = DateTime.Now;
                                                base.XMDeliveryDetailsService.InsertXMDeliveryDetails(xmDeliveryDetails);

                                            }
                                        }
                                        #endregion

                                        #region  删除 原发货订单明细
                                        if (xMDeliveryDetails != null)
                                        {
                                            //xMDeliveryDetails.IsEnabled = true;
                                            //xMDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            //xMDeliveryDetails.UpdateDate = DateTime.Now;
                                            base.XMDeliveryDetailsService.DeleteXMDeliveryDetails(xMDeliveryDetails.Id);

                                            //重新给属性 赋空值
                                            OrderNo = "";
                                            DetailsTypeId = 0;
                                            ProductlId = 0;
                                            PlatformMerchantCode = "";
                                            PrdouctName = "";
                                            Specifications = "";
                                            ProductNum = 0;
                                            WarehouseID = 0;
                                        }
                                        #endregion

                                    }
                                    #endregion
                                }
                                else//已选发货单 只有一条产品明细
                                {
                                    int ProductNumSum = xmDeliveryDetailsList.Select(p => p.ProductNum == null ? 0 : p.ProductNum.Value).Sum();

                                    if (ProductNumSum > 1)
                                    {

                                        #region 单条产品信息 拆分 （拆分数量）

                                        #region 新增发货单信息
                                        HozestERP.BusinessLogic.ManageProject.XMDelivery xd = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
                                        if (Delivery != null)
                                        {
                                            //新增
                                            #region 生成发货单
                                            xd.DeliveryTypeId = Delivery.DeliveryTypeId;//使用原发货单主表的 发货单类型

                                            if (Delivery.DeliveryTypeId.Value == 481)
                                            {
                                                xd.DeliveryNumber = "ZP" + DateTime.Now.ToString("yyyyMMddHHmmssfff");//赠品发货单号（自动生成）
                                            }
                                            else
                                            {
                                                xd.DeliveryNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");//订单发货单号（自动生成）
                                            }
                                            xd.OrderCode = Delivery.OrderCode;////使用原发货单主表的 订单号
                                            xd.Shipper = Delivery.Shipper;

                                            xd.FullName = Delivery.FullName;
                                            xd.Mobile = Delivery.Mobile;
                                            xd.Tel = Delivery.Tel;
                                            xd.Province = Delivery.Province;
                                            xd.City = Delivery.City;
                                            xd.County = Delivery.County;
                                            xd.DeliveryAddress = Delivery.DeliveryAddress;

                                            xd.Price = 0;//运费
                                            xd.IsDelivery = false;//是否发货
                                            xd.IsEnabled = false;
                                            xd.CreateId = HozestERPContext.Current.User.CustomerID;
                                            xd.CreateDate = DateTime.Now;
                                            xd.UpdateId = HozestERPContext.Current.User.CustomerID;
                                            xd.UpdateDate = DateTime.Now;
                                            xd.PrintQuantity = 0;//打印次数
                                            xd.PrintBatch = 0;//打印批次
                                            base.XMDeliveryService.InsertXMDelivery(xd);
                                            #endregion
                                        }
                                        #endregion

                                        for (int i = 0; i < 1; i++)
                                        {
                                            xMDeliveryDetails = xmDeliveryDetailsList[0];
                                            OrderNo = xMDeliveryDetails.OrderNo;
                                            DetailsTypeId = xMDeliveryDetails.DetailsTypeId.Value;
                                            ProductlId = xMDeliveryDetails.ProductlId.Value;
                                            PlatformMerchantCode = xMDeliveryDetails.PlatformMerchantCode;
                                            PrdouctName = xMDeliveryDetails.PrdouctName;
                                            Specifications = xMDeliveryDetails.Specifications;
                                            //ProductNum = xMDeliveryDetails.ProductNum.Value;
                                            WarehouseID = xMDeliveryDetails.WarehouseID.Value;

                                            if (ProductlId > 0 && PlatformMerchantCode != "" && PrdouctName != "" && Specifications != "")
                                            {
                                                #region 新增发货单明细
                                                if (xd != null)//发货单记录 不未空
                                                {
                                                    if (xd.Id != 0)
                                                    {
                                                        XMDeliveryDetails xmDeliveryDetails = new XMDeliveryDetails();
                                                        xmDeliveryDetails.DeliveryId = xd.Id;
                                                        xmDeliveryDetails.OrderNo = OrderNo;
                                                        xmDeliveryDetails.DetailsTypeId = DetailsTypeId;
                                                        xmDeliveryDetails.ProductlId = ProductlId;
                                                        xmDeliveryDetails.PlatformMerchantCode = PlatformMerchantCode;
                                                        xmDeliveryDetails.PrdouctName = PrdouctName;
                                                        xmDeliveryDetails.Specifications = Specifications;
                                                        xmDeliveryDetails.ProductNum = 1;
                                                        xmDeliveryDetails.WarehouseID = WarehouseID;
                                                        xmDeliveryDetails.IsEnabled = false;
                                                        xmDeliveryDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                                        xmDeliveryDetails.CreateDate = DateTime.Now;
                                                        xmDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                        xmDeliveryDetails.UpdateDate = DateTime.Now;
                                                        base.XMDeliveryDetailsService.InsertXMDeliveryDetails(xmDeliveryDetails);

                                                    }
                                                }
                                                #endregion

                                                #region  修改 原产品信息数量
                                                if (xMDeliveryDetails != null)
                                                {
                                                    //原产品数量
                                                    int ProductNumOld = xMDeliveryDetails.ProductNum.Value - 1;
                                                    xMDeliveryDetails.ProductNum = ProductNumOld;
                                                    xMDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                    xMDeliveryDetails.UpdateDate = DateTime.Now;
                                                    base.XMDeliveryDetailsService.UpdateXMDeliveryDetails(xMDeliveryDetails);

                                                    //重新给属性 赋空值
                                                    OrderNo = "";
                                                    DetailsTypeId = 0;
                                                    ProductlId = 0;
                                                    PlatformMerchantCode = "";
                                                    PrdouctName = "";
                                                    Specifications = "";
                                                    ProductNum = 0;
                                                    WarehouseID = 0;
                                                }
                                                #endregion
                                            }
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        base.ShowMessage("已选产品不可拆分！");
                                        return;
                                    }
                                }
                            }
                            #endregion

                            base.ShowMessage("保存成功！");
                            this.BindGrid(Master.PageIndex, Master.PageSize);
                            scope.Complete();
                        }
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
            var xMDelivery = (XMDeliveryNew)e.Row.DataItem;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<XMDeliveryDetails> xMDeliveryDetailsList = new List<XMDeliveryDetails>();

                #region 商品信息
                int strProductNum = 0;

                if (xMDelivery != null && xMDelivery.Id > 0)
                {
                    xMDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(xMDelivery.Id);

                    //List<XMDeliveryDetails_Result> deliverDetailsListGroupy =
                    //   xMDeliveryDetailsList.GroupBy(g => new { g.PlatformMerchantCode, g.PrdouctName, g.Specifications }).
                    //   Select(group => new XMDeliveryDetails_Result()
                    //   {
                    //       PlatformMerchantCode = group.Key.PlatformMerchantCode,
                    //       PrdouctName = group.Key.PrdouctName,
                    //       Specifications = group.Key.Specifications,
                    //       ProductNum = group.Sum(l => l.ProductNum)
                    //   }).ToList();

                    if (xMDeliveryDetailsList != null && xMDeliveryDetailsList.Count > 0)
                    {
                        strProductNum += (int)xMDeliveryDetailsList.Sum(x => x.ProductNum);
                        //foreach (var DetailsList in deliverDetailsListGroupy)
                        //{
                        //    strProductNum += Convert.ToInt32(DetailsList.ProductNum);
                        //}
                    }
                }
                #endregion

                #region 电话
                //Label LblMobileAndTel = e.Row.FindControl("LblMobileAndTel") as Label;//电话
                //if (LblMobileAndTel != null)
                //{
                //    if (xMDelivery.Mobile.ToString() != "")
                //    {
                //        LblMobileAndTel.Text = xMDelivery.Mobile.ToString();
                //    }
                //    else
                //    {
                //        if (xMDelivery.Tel != null)
                //        {
                //            LblMobileAndTel.Text = xMDelivery.Tel.ToString();
                //        }
                //    }
                //}
                #endregion

                #region 物流公司
                //Label lblLogisticsId = e.Row.FindControl("lblLogisticsId") as Label;//物流公司
                //if (lblLogisticsId != null)
                //{
                //    if (xMDelivery.LogisticsId != null)
                //    {
                //        lblLogisticsId.Text = GetCompanyCustom(xMDelivery.LogisticsId.Value.ToString());
                //    }
                //    else
                //    {
                //        lblLogisticsId.Text = "";
                //    }
                //}
                #endregion

                #region 赠品信息
                ImageButton imgDeliveryDetails = e.Row.FindControl("imgDeliveryDetails") as ImageButton;
                if (imgDeliveryDetails != null)
                {
                    imgDeliveryDetails.OnClientClick = "return ShowWindowDetail('产品明细','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/XMDeliveryDetailsManage.aspx?DeliveryId=" + xMDelivery.Id + "',800, 450, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }
                
                #endregion

                #region 拆分订单

                Button btnSplit = e.Row.FindControl("btnSplit") as Button;
                if (btnSplit != null)
                {
                    if (xMDeliveryDetailsList.Count > 1 || strProductNum > 1)
                    {
                        btnSplit.Visible = true;
                    }
                    else
                    {
                        btnSplit.Visible = false;
                    }
                }

                #endregion

                #region 发货单管理  产品明细
                if ((GridView)e.Row.FindControl("grdXMDeliveryDetailsManage") != null)
                {
                    GridView grdXMDeliveryDetailsManage = (GridView)e.Row.FindControl("grdXMDeliveryDetailsManage");
                    grdXMDeliveryDetailsManage.DataSource = xMDeliveryDetailsList;
                    grdXMDeliveryDetailsManage.DataBind();
                }
                #endregion

                #region 绑定挂起按钮
                ImageButton imgBtnShelveRemarks = (ImageButton)e.Row.FindControl("imgBtnShelveRemarks");
                if (imgBtnShelveRemarks != null && xMDelivery.Id != 0)
                {
                    imgBtnShelveRemarks.OnClientClick = "return ShowWindowDetail('挂起说明','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMShelveRemarksEdit.aspx?Id=" + xMDelivery.Id.ToString() + "&Type=0', 500, 250, this, function(){});";
                }

                if (xMDelivery.IsShelve == null || xMDelivery.IsShelve == false)
                {
                    imgBtnShelveRemarks.Visible = false;
                }
                else
                {
                    imgBtnShelveRemarks.Visible = true;
                }
                #endregion
            }

            if (e.Row.RowState == DataControlRowState.Edit ||
               e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                DropDownList ddLogisticsId = e.Row.FindControl("ddLogisticsId") as DropDownList;

                if (xMDelivery != null)
                {
                    if (xMDelivery.DeliveryTypeId.Value == 480 || xMDelivery.DeliveryTypeId.Value == 708)//正式产品，换货产品
                    {
                        //根据订单号查询 订单信息
                        var xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xMDelivery.OrderCode);

                        //物流公司信息
                        List<XMCompanyCustom> xMCompanyCustomList = new List<XMCompanyCustom>();
                        if (xMOrderInfo != null)
                        {
                            xMCompanyCustomList = base.XMCompanyCustomService.GetXMCompanyCustomList();//GetXMCompanyCustomByNickIdAndPlatformTypeId(xMOrderInfo.NickID.Value, xMOrderInfo.PlatformTypeId.Value);
                        }

                        if (xMCompanyCustomList.Count > 0)
                        {
                            if (ddLogisticsId != null)
                            {
                                ddLogisticsId.Visible = true;
                                ddLogisticsId.Items.Clear();
                                ddLogisticsId.DataSource = xMCompanyCustomList;
                                ddLogisticsId.DataTextField = "LogisticsName";
                                ddLogisticsId.DataValueField = "LogisticsId";
                                ddLogisticsId.DataBind();
                                ddLogisticsId.Items.Insert(0, new ListItem(" ", "-1"));
                            }
                        }
                    }
                    else
                    {
                        if (ddLogisticsId != null)
                        {
                            ddLogisticsId.Visible = true;
                            ddLogisticsId.Items.Clear();
                            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(205, false);
                            ddLogisticsId.DataSource = codeList;
                            ddLogisticsId.DataTextField = "CodeName";
                            ddLogisticsId.DataValueField = "CodeID";
                            ddLogisticsId.DataBind();
                            ddLogisticsId.Items.Insert(0, new ListItem(" ", "-1"));
                        }
                    }

                    if (ddLogisticsId != null)
                    {
                        ddLogisticsId.SelectedValue = xMDelivery.LogisticsId != null ? xMDelivery.LogisticsId.Value.ToString() : "0";
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ImageButton imgBtnLogisticsEdit = e.Row.FindControl("imgBtnLogisticsEdit") as ImageButton;
                ImageButton imgBtnLogisticsUpdate = e.Row.FindControl("imgBtnLogisticsUpdate") as ImageButton;
                ImageButton imgBtnLogisticsCancel = e.Row.FindControl("imgBtnLogisticsCancel") as ImageButton;

                //隐藏编辑按钮
                if (imgBtnLogisticsEdit != null)
                {
                    imgBtnLogisticsEdit.Visible = true;
                }
                //显示保存按钮
                if (imgBtnLogisticsUpdate != null)
                {
                    imgBtnLogisticsUpdate.Visible = false;
                }
                //显示取消按钮
                if (imgBtnLogisticsCancel != null)
                {
                    imgBtnLogisticsCancel.Visible = false;
                }
            }
        }

        //编辑物流单号、物流公司 列 
        protected void imgBtnLogisticsNumberEdit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow item in grdvClients.Rows)
            {
                if (item.RowIndex != grdvClients.EditIndex)
                {
                    HiddenField hdDId = item.FindControl("hdDId") as HiddenField;

                    // 设置txtInventory 为可编辑控件
                    Label lblLogisticsNumber = item.FindControl("lblLogisticsNumber") as Label;
                    TextBox txtLogisticsNumber = item.FindControl("txtLogisticsNumber") as TextBox;
                    Label lblLogisticsId = item.FindControl("lblLogisticsId") as Label;
                    DropDownList ddLogisticsId = item.FindControl("ddLogisticsId") as DropDownList;

                    if (lblLogisticsNumber != null && txtLogisticsNumber != null && lblLogisticsId != null)
                    {
                        lblLogisticsNumber.Visible = false;
                        txtLogisticsNumber.Visible = true;
                        lblLogisticsId.Visible = false;
                        txtLogisticsNumber.Text = txtLogisticsNumber.Text == "" ? "" : txtLogisticsNumber.Text;
                    }

                    if (hdDId != null)
                    {
                        var xmDelivery = base.XMDeliveryService.GetXMDeliveryById(Convert.ToInt32(hdDId.Value));
                        if (xmDelivery != null)
                        {
                            if (xmDelivery.DeliveryTypeId.Value == 480 || xmDelivery.DeliveryTypeId.Value == 708)
                            {
                                //根据订单号查询 订单信息
                                var xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xmDelivery.OrderCode);

                                //物流公司信息
                                List<XMCompanyCustom> xMCompanyCustomList = new List<XMCompanyCustom>();
                                if (xMOrderInfo != null)
                                {
                                    xMCompanyCustomList = base.XMCompanyCustomService.GetXMCompanyCustomList();//GetXMCompanyCustomByNickIdAndPlatformTypeId(1, xMOrderInfo.PlatformTypeId.Value);
                                }

                                if (xMCompanyCustomList.Count > 0)
                                {
                                    if (ddLogisticsId != null)
                                    {
                                        ddLogisticsId.Visible = true;
                                        ddLogisticsId.Items.Clear();
                                        ddLogisticsId.DataSource = xMCompanyCustomList;
                                        ddLogisticsId.DataTextField = "LogisticsName";
                                        ddLogisticsId.DataValueField = "LogisticsId";
                                        ddLogisticsId.DataBind();
                                        //ddLogisticsId.Items.Insert(0, new ListItem(" ", "-1"));
                                    }
                                }
                            }
                            else
                            {
                                if (ddLogisticsId != null)
                                {
                                    ddLogisticsId.Visible = true;
                                    ddLogisticsId.Items.Clear();
                                    var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(205, false);
                                    ddLogisticsId.DataSource = codeList;
                                    ddLogisticsId.DataTextField = "CodeName";
                                    ddLogisticsId.DataValueField = "CodeID";
                                    ddLogisticsId.DataBind();
                                    //ddLogisticsId.Items.Insert(0, new ListItem(" ", "-1"));
                                }
                            }
                            if (ddLogisticsId != null)
                            {
                                if (xmDelivery.LogisticsId != null)
                                {
                                    ddLogisticsId.SelectedValue = xmDelivery.LogisticsId != null ? xmDelivery.LogisticsId.Value.ToString() : "";
                                }
                            }
                        }
                    }
                }
            }
            if (this.grdvClients.FooterRow.RowType == DataControlRowType.Footer)
            {
                ImageButton imgBtnLogisticsEdit = this.grdvClients.FooterRow.FindControl("imgBtnLogisticsEdit") as ImageButton;
                ImageButton imgBtnLogisticsUpdate = this.grdvClients.FooterRow.FindControl("imgBtnLogisticsUpdate") as ImageButton;
                ImageButton imgBtnLogisticsCancel = this.grdvClients.FooterRow.FindControl("imgBtnLogisticsCancel") as ImageButton;
                //隐藏编辑按钮
                if (imgBtnLogisticsEdit != null)
                {
                    imgBtnLogisticsEdit.Visible = false;
                }
                //显示保存按钮
                if (imgBtnLogisticsUpdate != null)
                {
                    imgBtnLogisticsUpdate.Visible = true;
                }
                //显示取消按钮
                if (imgBtnLogisticsCancel != null)
                {
                    imgBtnLogisticsCancel.Visible = true;
                }
            }

        }

        /// <summary>
        /// 保存物流单号、物流公司 列 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgBtnLogisticsNumberUpdate_Click(object sender, EventArgs e)
        {
            #region 字符验证
            int errorcount = 0;
            //循环所有行
            foreach (GridViewRow msgReach in grdvClients.Rows)
            {
                if (msgReach.RowIndex != grdvClients.EditIndex)
                {
                    TextBox txtLogisticsNumber = msgReach.FindControl("txtLogisticsNumber") as TextBox;
                    Label lblMsgLogisticsNumberVaule = msgReach.FindControl("lblMsgLogisticsNumberVaule") as Label;
                    DropDownList ddLogisticsId = msgReach.FindControl("ddLogisticsId") as DropDownList;
                    Label lblMsgLogisticsIdVaule = msgReach.FindControl("lblMsgLogisticsIdVaule") as Label;

                    if (txtLogisticsNumber.Text.Trim() == "" && Convert.ToInt32(ddLogisticsId.SelectedValue) != -1)
                    {
                        lblMsgLogisticsNumberVaule.Text = "";
                        if (txtLogisticsNumber.Text.Trim() == "")
                        {
                            lblMsgLogisticsNumberVaule.Text = "请输入物流单号";
                            lblMsgLogisticsNumberVaule.Visible = true;
                            errorcount++;
                        }
                    }
                    else if (txtLogisticsNumber.Text.Trim() != "" && Convert.ToInt32(ddLogisticsId.SelectedValue) == -1)
                    {
                        lblMsgLogisticsIdVaule.Text = "";
                        lblMsgLogisticsIdVaule.Text = "请选择物流公司";
                        lblMsgLogisticsIdVaule.Visible = true;
                        errorcount++;

                    }

                }
            }
            if (errorcount > 0)
            {
                return;
            }
            #endregion

            bool isEdit = false;
            //循环grid 每行 
            foreach (GridViewRow item in grdvClients.Rows)
            {
                if (item.RowIndex != grdvClients.EditIndex)
                {
                    //库存控件
                    TextBox txtLogisticsNumber = item.FindControl("txtLogisticsNumber") as TextBox;

                    DropDownList ddLogisticsId = item.FindControl("ddLogisticsId") as DropDownList;

                    if (txtLogisticsNumber.Text.Trim() != "" && Convert.ToInt32(ddLogisticsId.SelectedValue) != -1)
                    {
                        string id = grdvClients.DataKeys[item.RowIndex].Values[0].ToString();
                        if (txtLogisticsNumber.Visible)
                        {
                            isEdit = true;
                            var xMDelivery = base.XMDeliveryService.GetXMDeliveryById(Convert.ToInt32(id));
                            //数据转换
                            if (txtLogisticsNumber.Text.Trim() != "")
                            {
                                xMDelivery.LogisticsNumber = txtLogisticsNumber.Text.Trim();
                            }
                            xMDelivery.LogisticsId = Convert.ToInt32(ddLogisticsId.SelectedValue);
                            xMDelivery.UpdateId = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                            xMDelivery.UpdateDate = DateTime.Now;
                            //数据数据
                            base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
                        }
                    }
                }
            }
            if (isEdit)
                base.ShowMessage("保存成功!");
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        //取消按钮
        protected void imgBtnLogisticsNumberCancel_Click(object sender, EventArgs e)
        {
            BindGrid(this.Master.PageIndex, this.Master.PageSize);

        }

        /// <summary>
        /// 明细绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdXMDeliveryDetailsManage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var item = (XMDeliveryDetails)e.Row.DataItem;

            #region 明细绑定
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //订单号
                //Label lblOrderNo = e.Row.FindControl("lblOrderNo") as Label;

                //类型
                Label lblDetailsTypeId = e.Row.FindControl("lblDetailsTypeId") as Label;

                if (item != null)
                {
                    //if (lblOrderNo != null)
                    //{
                    //    lblOrderNo.Text = item.OrderNo;
                    //}
                    if (lblDetailsTypeId != null)
                    {
                        if (item.DetailsTypeId != null)
                        {
                            if (item.DetailsTypeId.Value == Convert.ToInt32(StatusEnum.ChildPremiums))
                            {
                                lblDetailsTypeId.Text = "赠品";
                            }
                            else if (item.DetailsTypeId.Value == Convert.ToInt32(StatusEnum.ChildPayment))
                            {
                                lblDetailsTypeId.Text = "赔付";
                            }
                            else if (item.DetailsTypeId.Value == Convert.ToInt32(StatusEnum.NormalOrder))
                            {
                                lblDetailsTypeId.Text = "正常订单";
                            }
                        }
                    }
                }

                ////获取父级Id
                //var hdDId = (HiddenField)e.Row.Parent.Parent.Parent.FindControl("hdDId");

                ////明细控件 绑定主表Id
                //HiddenField hdId = e.Row.FindControl("hdId") as HiddenField;

                //if (hdId != null && hdDId!=null)
                //{
                //    hdId.Value = hdDId.Value;
                //}
            }

            //if (e.Row.RowState == DataControlRowState.Edit ||
            //    e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            //{
            //}
            #endregion
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
        /// 导出发货清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPostExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (this.ddXMProject.Value.ToString() != "-1")
                    {
                        //导出存放路径
                        string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                        string filePath = string.Format("{0}Upload\\PostListExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);
                        #region 原来的导出代码
                        ////读取数据
                        //List<XMDeliveryNew> list = new List<XMDeliveryNew>();
                        //List<int> ProductInfoIDs = this.Master.GetSelectedIds(this.grdvClients);

                        //this.BindGrid(1, Master.PageSize);

                        //if (ProductInfoIDs.Count <= 0)
                        //{
                        //    list = PostListExportList;
                        //}
                        //else
                        //{
                        //    foreach (XMDeliveryNew one in PostListExportPageList)
                        //    {
                        //        if (ProductInfoIDs.IndexOf(one.Id) != -1)
                        //        {
                        //            list.Add(one);
                        //        }
                        //    }
                        //}

                        ////去除挂起的发货单
                        //list = list.Where(x => x.IsShelve == null || x.IsShelve == false).OrderBy(x => x.OrderCode).OrderBy(x => x.Mobile).OrderBy(x => x.DeliveryAddress).ToList();

                        ////各平台，待发货状态
                        //string[] DeliveryStatue = { "WAIT_SELLER_SEND_GOODS", "DS_WAIT_SELLER_DELIVERY", "WAIT_SELLER_DELIVERY", "WAIT_SELLER_STOCK_OUT","STATUS_10", 
                        //                              "ORDER_TRUNED_TO_DO", "以接受", "10","已付款" };

                        ////各平台，已发货，完成状态
                        //string[] FinishStatue = { "SELLER_CONSIGNED_PART", "WAIT_BUYER_CONFIRM_GOODS", "TRADE_BUYER_SIGNED","TRADE_FINISHED",
                        //                               "DS_DEAL_END_NORMAL","DS_WAIT_BUYER_RECEIVE","SEND_TO_DISTRIBUTION_CENER","DISTRIBUTION_CENTER_RECEIVED","WAIT_GOODS_RECEIVE_CONFIRM",
                        //                               "RECEIPTS_CONFIRM","FINISHED_L","STATUS_22","STATUS_25","ORDER_OUT_OF_WH","ORDER_RECEIVED","ORDER_FINISH","已发货","20","21","30","已完成"};

                        //for (int i = 0; i < list.Count(); i++)
                        //{
                        //    if (!list[i].OrderCode.StartsWith("NoOrder"))
                        //    {
                        //        //同步订单
                        //        UpdateOrderInfo(list[i].OrderCode);
                        //        var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(list[i].OrderCode);
                        //        if (OrderInfo != null)
                        //        {
                        //            if (!(DeliveryStatue.Contains(OrderInfo.OrderStatus) || FinishStatue.Contains(OrderInfo.OrderStatus)))
                        //            {
                        //                list.Remove(list[i]);
                        //                i--;
                        //            }
                        //        }
                        //    }
                        //}
                        #endregion

                        string logisticsNumber = this.txtLogisticsNumber.Text.Trim();     //物流单号
                        string ordercode = this.txtOrderCode.Text.Trim();//订单编号
                        string manufacturersCode = this.txtManufacturersCode1.Text.Trim();//厂家编号
                        string deliverynumber = this.txtDeliveryNumber.Text.Trim();//物流单号 
                        int ddPrintQuantity = Convert.ToInt32(this.ddPrintQuantity.SelectedValue);//是否打印 
                        int ddDeliveryTypeId = Convert.ToInt32(this.ddDeliveryTypeId.SelectedValue);//发货单类型
                        string ddlShipper = this.ddlShipper.SelectedValue;//发货方
                        string txtFullName = this.txtFullName.Text.Trim();//收货人姓名
                        string txtMobileAndTel = this.txtMobileAndTel.Text.Trim();//电话
                        string txtDeliveryAddress = this.txtDeliveryAddress.Text.Trim();//收货地址
                        string PrintBatch = this.txtPrintBatch.Text.Trim();//打印批次
                        int Nick = Convert.ToInt32(ddlNick.Value);//店铺
                        string PrintBegin = this.txtPrintBegin.Value.Trim();//打印开始时间
                        string PrintEnd = this.txtPrintEnd.Value.Trim();//打印结束时间
                        string CreateBegin = this.txtCreateDateBegin.Value.Trim();//创单开始时间
                        string CreateEnd = this.txtCreateDateEnd.Value.Trim();//创单结束时间
                        int IsShelve = int.Parse(this.ddlIsShelve.SelectedValue);//是否挂起
                        bool NoOrder = this.chkNoOrder.Checked;//无订单号发货单

                        //是否发货
                        int ddIsDelivery = Convert.ToInt32(this.ddIsDelivery.SelectedValue.Trim());
                        //项目名称
                        int ddXMProject = -1;
                        if (!string.IsNullOrEmpty(this.ddXMProject.Value.ToString()))
                            ddXMProject = Convert.ToInt32(this.ddXMProject.Value.ToString().Trim());

                        if ((PrintBegin != "" && PrintEnd == "") || (PrintBegin == "" && PrintEnd != ""))
                        {
                            base.ShowMessage("打印开始，结束时间必须同时存在！");
                            return;
                        }

                        if ((CreateBegin != "" && CreateEnd == "") || (CreateBegin == "" && CreateEnd != ""))
                        {
                            base.ShowMessage("创单开始，结束时间必须同时存在！");
                            return;
                        }

                        var DeliveryList = base.XMDeliveryService.GetXMDeliveryExportList(logisticsNumber, ordercode, manufacturersCode, deliverynumber, ddPrintQuantity, ddDeliveryTypeId
                            , txtFullName, txtMobileAndTel, txtDeliveryAddress, ddIsDelivery, ddXMProject, PrintBatch, int.Parse(ddlShipper), Nick, PrintBegin, PrintEnd
                            , CreateBegin, CreateEnd, IsShelve, NoOrder);//查询物流单list
                        base.ExportManager.ExportPostList(filePath, DeliveryList);
                        CommonHelper.WriteResponseXls(filePath, fileName);
                    }
                    else
                    {
                        Ext.Net.ExtNet.Msg.Alert("提示", "请选择项目名称").Show();
                        //base.ShowMessage("请选择项目名称！");
                        //GridPanelBind();
                    }
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        /// <summary>
        /// 打印物流运单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void But_pldyyd_Click(object sender, EventArgs e)
        {
            List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);
            if (customerInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                //string ids = "";//订单ids
                //foreach (GridViewRow row in grdvClients.Rows)
                //{
                //    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                //    if (chkSelected.Checked)
                //    {
                //        int DeliveryID = 0;
                //        int.TryParse(this.grdvClients.DataKeys[row.RowIndex].Value.ToString(), out DeliveryID);

                //        var deliveryinfo = base.XMDeliveryService.GetXMDeliveryById(DeliveryID);
                //        if (deliveryinfo.OrderCode != null && deliveryinfo.OrderCode != "")
                //        {
                //            var orderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(deliveryinfo.OrderCode);//订单信息
                //            if (orderinfo != null)
                //            {
                //                if (ids != "")
                //                    ids += ",";
                //                ids += orderinfo.ID;
                //            }
                //        }

                //    }
                //}

                //发货单Id
                string deliveryId = string.Join(",", customerInfoIDs);

                string strdiqu = "STO";

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "openscript_yd", "window.open('dyYD.aspx?kd=" + strdiqu
                    + "&ids=" + deliveryId
                    + "&PrintTypeId=Delivery"
                    + "','批量打印运单', 'height=900, width=870, top=0, left=0, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=n o, status=no');", true);
            }


        }

        /// <summary>
        /// 批量发货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnBulkShipments_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int count = 0;
        //        //查询 appkey、appSecret、sessionKey
        //        var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();
        //        XMOrderInfoApp xMorderInfoApp = new XMOrderInfoApp();//appkey、appSecret、sessionKey

        //        List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);
        //        if (customerInfoIDs.Count <= 0)
        //        {
        //            base.ShowMessage("你没有选择任何记录");
        //            return;
        //        }
        //        else
        //        {
        //            foreach (GridViewRow row in grdvClients.Rows)
        //            {
        //                CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //                if (chkSelected.Checked)
        //                {
        //                    int ID = 0;
        //                    int.TryParse(this.grdvClients.DataKeys[row.RowIndex].Value.ToString(), out ID);

        //                    //根据Id 查询 发货单
        //                    var xMDelivery = base.XMDeliveryService.GetXMDeliveryById(ID);

        //                    //根据选中的行数据 Id 管理发货单明细 
        //                    var XMDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsMappingSearchList(Convert.ToInt32(ID));

        //                    if (XMDeliveryDetailsList.Count > 0 && xMDelivery != null)
        //                    {
        //                        var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(XMDeliveryDetailsList[0].OrderNo);

        //                        if (xMOrderInfo.Count > 0)
        //                        {
        //                            var XMOrderInfoAppOne = XMOrderInfoAppList.Where(p => p.PlatformTypeId == xMOrderInfo[0].PlatformTypeId).Where(s => s.NickId == xMOrderInfo[0].NickID);
        //                            if (XMOrderInfoAppOne.Count() > 0)
        //                            {
        //                                //判断物流单号 ，物流公司 不为空
        //                                if (XMDeliveryDetailsList[0].LogisticsNumber != "" && XMDeliveryDetailsList[0].LogisticsNumber != null && XMDeliveryDetailsList[0].LogisticsId != null)
        //                                {
        //                                    xMorderInfoApp = XMOrderInfoAppList.Where(p => p.PlatformTypeId == xMOrderInfo[0].PlatformTypeId).First(s => s.NickId == xMOrderInfo[0].NickID);
        //                                    switch (xMorderInfoApp.PlatformTypeId)
        //                                    {
        //                                        case 251:
        //                                            JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new JDsingleServiceReference.JDsingleOrderGetSoapClient();
        //                                            JDsingleServiceReference.JindingOutstoragePesponse outstorage = webserver.GetOutstorage(xMOrderInfo[0].OrderCode, XMDeliveryDetailsList[0].LogisticsId.ToString(), XMDeliveryDetailsList[0].LogisticsNumber, xMorderInfoApp.AppKey, xMorderInfoApp.AppSecret, xMorderInfoApp.ServerUrl, xMorderInfoApp.AccessToken);

        //                                            if (outstorage != null)
        //                                            {

        //                                                if (outstorage.order_sop_outstorage_response != null)
        //                                                {
        //                                                    xMOrderInfo[0].DeliveryTime = Convert.ToDateTime(outstorage.order_sop_outstorage_response.modified);//修改出库时间
        //                                                    xMOrderInfo[0].OrderStatus = "WAIT_GOODS_RECEIVE_CONFIRM";
        //                                                    xMOrderInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                                    xMOrderInfo[0].UpdateDate = DateTime.Now;
        //                                                    base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo[0]);

        //                                                    //修改发货单 是否发货状态
        //                                                    xMDelivery.IsDelivery = true;//已发货
        //                                                    xMDelivery.UpdateDate = DateTime.Now;
        //                                                    xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
        //                                                    base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
        //                                                    count++;
        //                                                }
        //                                            }
        //                                            break;
        //                                        case 250:
        //                                            bool returnbool = base.XMOrderInfoAPIService.SendTM(xMOrderInfo[0].OrderCode, XMDeliveryDetailsList[0].LogisticsId.ToString(), XMDeliveryDetailsList[0].LogisticsNumber, xMorderInfoApp);
        //                                            if (returnbool == true)
        //                                            {
        //                                                xMOrderInfo[0].DeliveryTime = Convert.ToDateTime(DateTime.Now);//修改出库时间
        //                                                xMOrderInfo[0].OrderStatus = "WAIT_BUYER_CONFIRM_GOODS";
        //                                                xMOrderInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                                xMOrderInfo[0].UpdateDate = DateTime.Now;
        //                                                base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo[0]);

        //                                                //修改发货单 是否发货状态
        //                                                xMDelivery.IsDelivery = true;//已发货
        //                                                xMDelivery.UpdateDate = DateTime.Now;
        //                                                xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
        //                                                base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
        //                                                count++;
        //                                            }
        //                                            break;
        //                                        case 376:
        //                                            xMOrderInfo[0].DeliveryTime = Convert.ToDateTime(DateTime.Now);//修改出库时间
        //                                            xMOrderInfo[0].OrderStatus = "已发货";
        //                                            xMOrderInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                            xMOrderInfo[0].UpdateDate = DateTime.Now;
        //                                            base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo[0]);
        //                                            break;
        //                                        case 765:
        //                                            xMOrderInfo[0].DeliveryTime = Convert.ToDateTime(DateTime.Now);//修改出库时间
        //                                            xMOrderInfo[0].OrderStatus = "已发货";
        //                                            xMOrderInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                            xMOrderInfo[0].UpdateDate = DateTime.Now;
        //                                            base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo[0]);
        //                                            break;
        //                                    }
        //                                    #region 点批量发货，修改销售出库单出库状态和库存扣减
        //                                    //根据发货单ID  查询进销存系统销售出库单记录  更新出库状态  更新库存信息
        //                                    bool isInventLess = false;
        //                                    string errMessage = "";
        //                                    List<SaleDeliveryProduct> List = new List<SaleDeliveryProduct>();
        //                                    var saleDeliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryListByParm(ID);
        //                                    if (saleDeliveryInfo != null && saleDeliveryInfo.Count > 0)
        //                                    {
        //                                        foreach (var info in saleDeliveryInfo)
        //                                        {
        //                                            var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(ID);
        //                                            if (saleDelivery != null)
        //                                            {
        //                                                var saleDeliveryDetail = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(saleDelivery.Id);
        //                                                if (saleDeliveryDetail != null && saleDeliveryDetail.Count > 0)
        //                                                {
        //                                                    foreach (XMSaleDeliveryProductDetails parm in saleDeliveryDetail)
        //                                                    {
        //                                                        SaleDeliveryProduct list2 = new SaleDeliveryProduct();
        //                                                        list2.pcode = parm.PlatformMerchantCode;
        //                                                        list2.saleDeliveryCount = parm.SaleCount.Value;
        //                                                        list2.wareHoueseID = saleDelivery.WareHouseId;
        //                                                        List.Add(list2);
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                    }
        //                                    if (List != null && List.Count > 0)
        //                                    {
        //                                        var List2 = from l in List
        //                                                    group l by new { l.pcode, l.wareHoueseID } into g
        //                                                    select new
        //                                                    {
        //                                                        pcode = g.Key.pcode,
        //                                                        wareHoueseID = g.Key.wareHoueseID,
        //                                                        saleDeliveryCount = g.Sum(a => a.saleDeliveryCount)
        //                                                    };

        //                                        if (List2 != null && List2.Count() > 0)
        //                                        {
        //                                            foreach (var parm in List2)
        //                                            {
        //                                                var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(parm.pcode, parm.wareHoueseID);
        //                                                if (inventInfo == null)
        //                                                {
        //                                                    isInventLess = true;      //库存不足
        //                                                    errMessage = errMessage + parm.pcode + ";";
        //                                                    break;
        //                                                }
        //                                                else
        //                                                {
        //                                                    if (inventInfo.StockNumber == null)
        //                                                    {
        //                                                        isInventLess = true;      //库存不足
        //                                                        errMessage = errMessage + parm.pcode + ";";
        //                                                        break;
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        if (inventInfo.StockNumber == 0 || inventInfo.StockNumber < 0 || (inventInfo.StockNumber > 0 && inventInfo.StockNumber < parm.saleDeliveryCount))
        //                                                        {
        //                                                            isInventLess = true;      //库存不足
        //                                                            errMessage = errMessage + parm.pcode + ";";
        //                                                            break;
        //                                                        }
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                    }


        //                                    if (isInventLess)                //库存不足
        //                                    {
        //                                        base.ShowMessage("出库单号为：" + errMessage + "库存不足，无法出库！");
        //                                        return;
        //                                    }
        //                                    else                          //库存充足  减掉库存
        //                                    {
        //                                        if (saleDeliveryInfo != null && saleDeliveryInfo.Count > 0)
        //                                        {
        //                                            foreach (var info in saleDeliveryInfo)
        //                                            {
        //                                                if (info.BillStatus == 0)
        //                                                {
        //                                                    info.IsAudit = true;
        //                                                    info.BillStatus = 1000;
        //                                                    info.UpdateDate = DateTime.Now;
        //                                                    info.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                                    base.XMSaleDeliveryService.UpdateXMSaleDelivery(info);
        //                                                    //更新产品库存表（减掉出库数量）
        //                                                    var deliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(info.Id);
        //                                                    if (deliveryProductDetails != null && deliveryProductDetails.Count > 0)
        //                                                    {
        //                                                        foreach (XMSaleDeliveryProductDetails parm in deliveryProductDetails)
        //                                                        {
        //                                                            string code = parm.PlatformMerchantCode;              //商品编码
        //                                                            int wfID = info.WareHouseId;                              //出库仓库ID
        //                                                            var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(code, wfID);
        //                                                            if (InventoryInfo != null)                             //商品编码为code的产品在库存表中已经存在 更新库存数量
        //                                                            {
        //                                                                InventoryInfo.StockNumber = InventoryInfo.StockNumber - parm.SaleCount;             //库存减掉出库量
        //                                                                InventoryInfo.UpdateDate = DateTime.Now;
        //                                                                InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                                                base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);

        //                                                            }
        //                                                            //更新库存总账主表数据   从表添加一条记录
        //                                                            UpdateInventoryLederInfo(info.WareHouseId, parm);
        //                                                        }
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                    }
        //                                    #endregion
        //                                }
        //                            }
        //                            else
        //                            {
        //                                base.ShowMessage("京东appkey、appSecret、sessionKey 不能为空.");
        //                                return;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //        base.ShowMessage("操作成功！影响行数：" + count);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.ShowMessage("错误信息：" + ex.Message);
        //    }
        //}

        /// <summary>
        /// 更新库存总账主表数据
        /// </summary>
        /// <param name="wareHousesId"></param>
        /// <param name="info"></param>
        private void UpdateInventoryLederInfo(int wareHousesId, SaleDeliveryProduct info)
        {
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, info.pcode);
            if (inventoryLeder != null)//更新数据
            {
                //更新出库数量
                inventoryLeder.OutCount = (inventoryLeder.OutCount == null ? 0 : inventoryLeder.OutCount) + info.saleDeliveryCount;
                inventoryLeder.OutPrice = 0;
                inventoryLeder.OutMoney = 0;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
            else
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.WarehouseId = wareHousesId;
                inventoryLederInfo.ProductId = info.ProductID;
                inventoryLederInfo.PlatformMerchantCode = info.pcode;
                inventoryLederInfo.OutCount = info.saleDeliveryCount;
                inventoryLederInfo.OutPrice = 0;
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.InCount = 0;
                inventoryLederInfo.InPrice = info.ProductPrice;
                inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                inventoryLederInfo.AfloatCount = 0;
                inventoryLederInfo.AfloatPrice = info.ProductPrice;
                inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                inventoryLederInfo.CreateDate = DateTime.Now;
                inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
            }
            //新增库存总账明细(出库)
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, info.pcode);
            decimal price = 0;
            decimal money = 0;
            XMInventoryLedgerDetail details = new XMInventoryLedgerDetail();
            details.WarehouseId = wareHousesId;
            details.ProductId = info.ProductID;
            details.PlatformMerchantCode = info.pcode;
            details.OutCount = info.saleDeliveryCount;
            details.OutPrice = 0;
            details.OutMoney = info.saleDeliveryCount * info.ProductPrice;
            details.InCount = 0;
            details.InPrice = price;
            details.InMoney = money;
            //if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            //{
            //    //默认最后一条（余量）
            //    int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
            //    details.BalanceCount = BalanceCount - details.OutCount;
            //}
            //else
            //{
            //    details.BalanceCount = 0;
            //}
            details.BalanceCount = info.StockNumber;
            details.BalancePrice = info.ProductPrice;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            //var saleDeliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryById(info.SaleDeliveryId);
            //if (saleDeliveryInfo != null)
            //{
            //    details.RefNumber = saleDeliveryInfo.Ref;
            //}
            details.RefNumber = info.DeliveryNo;
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1002; //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            details.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
        }

        /// <summary>
        /// 订单合并
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOrdrInfMerger_Click(object sender, EventArgs e)
        {

            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 1)
            {
                base.ShowMessage("请选择多条发货单合并！");
                return;
            }
            else
            {
                //选中的发货单信息
                var xmDeliveryList = base.XMDeliveryService.GetXMDeliverySearchListById(IDs);

                #region  判断所选数据是否是相同订单 、是否是未发货

                var IsDeliveryOKList = xmDeliveryList.Where(a => a.IsDelivery.Value == true).ToList();//是否发货：是 
                var xmDeliveryListGroupBy = xmDeliveryList.GroupBy(p => p.DeliveryAddress.Trim()).Select(g => g.First()).ToList();//根据收货地址分组
                var PrintQuantity = xmDeliveryList.Where(a => a.PrintQuantity.Value > 0).ToList();//打印过的发货单

                bool IsShipper = false;
                if (xmDeliveryList.Count > 0)
                {
                    for (int i = 0; i < xmDeliveryList.Count; i++)
                    {
                        if (i > 0)
                        {
                            if (xmDeliveryList[i].Shipper != xmDeliveryList[i - 1].Shipper)
                            {
                                IsShipper = true;
                                break;
                            }
                        }
                    }
                }

                if (IsDeliveryOKList.Count > 0 || xmDeliveryListGroupBy.Count > 1 || PrintQuantity.Count > 0 || IsShipper)
                {
                    base.ShowMessage("请选择未发货、相同收货地址、未打印、发货方相同的数据合并！");
                    return;
                }
                #endregion
                //事务
                using (TransactionScope scope = new TransactionScope())
                {
                    //取选择发货单列表中倒序 第一条数据。
                    XMDeliveryNew XMDeliveryNewTow = new XMDeliveryNew();

                    //存选择发货单列表中倒序 第一条数据。
                    //HozestERP.BusinessLogic.ManageProject.XMDelivery DeliveryTow = new BusinessLogic.ManageProject.XMDelivery();
                    //取选择发货单列表中倒序 第一条数据明细数据。
                    List<XMDeliveryDetails> xMDeliveryDetailsTowList = null;
                    XMDeliveryDetails xMDeliveryDetailsTow = null;
                    //发货单明细 (选中的明细数据)
                    List<XMDeliveryDetails> xMDeliveryDetailsList = null;

                    #region
                    if (xmDeliveryList.Count > 0)
                    {
                        //取选择发货单列表中倒序 除第一条数据。
                        // HozestERP.BusinessLogic.ManageProject.XMDelivery Deliverys = new BusinessLogic.ManageProject.XMDelivery();

                        //存选择发货单列表中倒序 除第一条数据。
                        XMDeliveryNew XMDeliveryNew = new XMDeliveryNew();

                        //循环选中的发货单信息
                        for (int i = 0; i < xmDeliveryList.Count; i++)
                        {
                            if (i == 0)
                            {
                                XMDeliveryNewTow = xmDeliveryList[i];//取选择中倒序 第一条数据。
                                xMDeliveryDetailsTowList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(XMDeliveryNewTow.Id);
                            }
                            else
                            {
                                XMDeliveryNew = xmDeliveryList[i];//除第一条以外的其他数据
                                if (XMDeliveryNew != null)
                                {
                                    xMDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(XMDeliveryNew.Id);

                                    if (xMDeliveryDetailsList.Count > 0)
                                    {
                                        XMDeliveryDetails xMDeliveryDetails = new XMDeliveryDetails();
                                        for (int j = 0; j < xMDeliveryDetailsList.Count; j++)
                                        {
                                            xMDeliveryDetails = xMDeliveryDetailsList[j];

                                            var xMDeliveryDetailsTowListbyPlatformMerchantCode = new List<XMDeliveryDetails>();

                                            ////明细的订单号是多个
                                            // if (xMDeliveryDetails.OrderNo.IndexOf(",") > -1)
                                            // {
                                            //     string[] OrderCodestr = xMDeliveryDetails.OrderNo.Split(',');
                                            //     List<string> OrderCodeList = new List<string>(OrderCodestr);
                                            //     //根据订单号查询发货单明细 
                                            //      var  OrderNoList =  xMDeliveryDetailsTowList.Where(a => OrderCodeList.Contains(a.OrderNo)).ToList();
                                            //     //根据商品编码 发货单明细 查询
                                            //     xMDeliveryDetailsTowListbyPlatformMerchantCode = xMDeliveryDetailsTowList.Where(a => OrderCodeList.Contains(a.PlatformMerchantCode)).ToList();   
                                            // }
                                            // else { 
                                            //根据商品编码 发货单明细 查询
                                            xMDeliveryDetailsTowListbyPlatformMerchantCode = xMDeliveryDetailsTowList.Where(a => a.PlatformMerchantCode.Equals(xMDeliveryDetails.PlatformMerchantCode)).ToList();
                                            //}

                                            //有相同商品编码 的产品
                                            if (xMDeliveryDetailsTowListbyPlatformMerchantCode.Count > 0)
                                            {
                                                xMDeliveryDetailsTow = xMDeliveryDetailsTowListbyPlatformMerchantCode[0];

                                                if (xMDeliveryDetailsTow.DetailsTypeId != null && xMDeliveryDetails.DetailsTypeId != null)
                                                {
                                                    //类型 不同不合并明细数据（明细新增）
                                                    if (xMDeliveryDetailsTow.DetailsTypeId.Value != xMDeliveryDetails.DetailsTypeId.Value)
                                                    {
                                                        xMDeliveryDetails.DeliveryId = XMDeliveryNewTow.Id;
                                                        xMDeliveryDetails.UpdateDate = DateTime.Now;
                                                        xMDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                        base.XMDeliveryDetailsService.UpdateXMDeliveryDetails(xMDeliveryDetails); //修改发货单明细（把发货单Id修改成选中发货单列表中的第一条发货单Id）
                                                    }
                                                    //类型相同合并明细数据 （数量累加，订单号累计）
                                                    else
                                                    {
                                                        //订单号累加
                                                        string strOrderCode = "";

                                                        List<string> OrderCodeListNew = new List<string>();
                                                        List<string> OrderCodeListOld = new List<string>();
                                                        if (xMDeliveryDetails.OrderNo.IndexOf(",") > -1 && xMDeliveryDetailsTow.OrderNo.IndexOf(",") > -1)
                                                        {
                                                            ////明细的订单号是多个（合并订单明细）
                                                            if (xMDeliveryDetails.OrderNo.IndexOf(",") > -1)
                                                            {
                                                                string[] OrderCodestr = xMDeliveryDetails.OrderNo.Split(',');
                                                                OrderCodeListNew = new List<string>(OrderCodestr);
                                                            }
                                                            else
                                                            {
                                                                OrderCodeListNew.Add(xMDeliveryDetails.OrderNo);
                                                            }
                                                            ////明细的订单号是多个（合并订单明细）原
                                                            if (xMDeliveryDetailsTow.OrderNo.IndexOf(",") > -1)
                                                            {
                                                                string[] OrderCodestrTow = xMDeliveryDetailsTow.OrderNo.Split(',');
                                                                OrderCodeListOld = new List<string>(OrderCodestrTow);
                                                            }
                                                            else
                                                            {
                                                                OrderCodeListOld.Add(xMDeliveryDetailsTow.OrderNo);
                                                            }

                                                            for (int k = 0; k < OrderCodeListOld.Count; k++)
                                                            {
                                                                if (!OrderCodeListNew.Contains(OrderCodeListOld[k]))
                                                                    OrderCodeListNew.Add(OrderCodeListOld[k]);
                                                            }

                                                            strOrderCode = string.Join(",", OrderCodeListNew);

                                                        }
                                                        else if (xMDeliveryDetailsTow.OrderNo.IndexOf(",") > -1)
                                                        {
                                                            #region 订单号不相同 累加订单号
                                                            if (xMDeliveryDetailsTow.OrderNo.IndexOf(",") > -1)
                                                            {
                                                                string[] OrderCodestr = xMDeliveryDetailsTow.OrderNo.Split(',');
                                                                List<string> OrderCodeList = new List<string>(OrderCodestr);
                                                                var OCList = from p in OrderCodeList
                                                                             where xMDeliveryDetails.OrderNo.Contains(p)
                                                                             select p;

                                                                if (OCList.ToList().Count == 0)
                                                                {
                                                                    //原订单号+ 新的订单号
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo + "," + xMDeliveryDetails.OrderNo;
                                                                }
                                                                else
                                                                {
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (xMDeliveryDetailsTow.OrderNo != xMDeliveryDetails.OrderNo)
                                                                {
                                                                    //原订单号+ 新的订单号
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo + "," + xMDeliveryDetails.OrderNo;
                                                                }
                                                                else
                                                                {
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo;
                                                                }
                                                            }
                                                            #endregion
                                                        }
                                                        else if (xMDeliveryDetails.OrderNo.IndexOf(",") > -1)
                                                        {
                                                            #region 订单号不相同 累加订单号
                                                            if (xMDeliveryDetails.OrderNo.IndexOf(",") > -1)
                                                            {
                                                                string[] OrderCodestr = xMDeliveryDetails.OrderNo.Split(',');
                                                                List<string> OrderCodeList = new List<string>(OrderCodestr);
                                                                var OCList = from p in OrderCodeList
                                                                             where xMDeliveryDetailsTow.OrderNo.Contains(p)
                                                                             select p;

                                                                if (OCList.ToList().Count == 0)
                                                                {
                                                                    //原订单号+ 新的订单号
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo + "," + xMDeliveryDetails.OrderNo;
                                                                }
                                                                else
                                                                {
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (xMDeliveryDetailsTow.OrderNo != xMDeliveryDetails.OrderNo)
                                                                {
                                                                    //原订单号+ 新的订单号
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo + "," + xMDeliveryDetails.OrderNo;
                                                                }
                                                                else
                                                                {
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo;
                                                                }
                                                            }
                                                            #endregion
                                                        }


                                                        //新的数量
                                                        int ProductNum = xMDeliveryDetailsTow.ProductNum.Value + xMDeliveryDetails.ProductNum.Value;

                                                        xMDeliveryDetailsTow.OrderNo = strOrderCode;
                                                        xMDeliveryDetailsTow.ProductNum = ProductNum;
                                                        xMDeliveryDetailsTow.UpdateDate = DateTime.Now;
                                                        xMDeliveryDetailsTow.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                        base.XMDeliveryDetailsService.UpdateXMDeliveryDetails(xMDeliveryDetailsTow); //修改发货单明细（把发货单Id修改成选中发货单列表中的第一条发货单Id）

                                                        //删除原明细
                                                        base.XMDeliveryDetailsService.DeleteXMDeliveryDetails(xMDeliveryDetails.Id);
                                                    }
                                                }
                                                //新增明细
                                                else
                                                {
                                                    xMDeliveryDetails.DeliveryId = XMDeliveryNewTow.Id;
                                                    xMDeliveryDetails.UpdateDate = DateTime.Now;
                                                    xMDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                    base.XMDeliveryDetailsService.UpdateXMDeliveryDetails(xMDeliveryDetails); //修改发货单明细（把发货单Id修改成选中发货单列表中的第一条发货单Id）
                                                }
                                            }
                                            else
                                            {


                                                xMDeliveryDetails.DeliveryId = XMDeliveryNewTow.Id;
                                                xMDeliveryDetails.UpdateDate = DateTime.Now;
                                                xMDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                base.XMDeliveryDetailsService.UpdateXMDeliveryDetails(xMDeliveryDetails); //修改发货单明细（把发货单Id修改成选中发货单列表中的第一条发货单Id）
                                            }
                                        }
                                    }
                                    base.XMDeliveryService.DeleteXMDelivery(XMDeliveryNew.Id);//删除发货单主表信息 
                                }
                            }
                        }
                    }
                    #endregion

                    base.ShowMessage("保存成功！");
                    this.BindGrid(Master.PageIndex, Master.PageSize);
                    scope.Complete();
                }

            }

        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 682 || HozestERPContext.Current.User.CustomerID == 670)
            {
                //this.ddXMProject.Items.Clear();
                ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                //.Where(c => c.ProjectTypeId == 362)

                //this.ddXMProject.DataSource = projectList;
                //this.ddXMProject.DataTextField = "ProjectName";
                //this.ddXMProject.DataValueField = "Id";
                //this.ddXMProject.DataBind();
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
                Ext.Net.Store Store = ddXMProject.GetStore();
                projectList.Add(new XMProject()
                {
                    ProjectName= "---所有---",
                    Id=-1,
                });
                Store.DataSource = projectList.OrderBy(a=>a.Id);
                Store.DataBind();
                ddXMProject.SelectedIndex = 0;
                ddXMProject.Value = "-1";
            }
            else
            {
                //this.ddXMProject.Items.Clear();
                ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    //this.ddXMProject.Items.Insert(0, new ListItem("---无项目权限---", "0"));
                    //projectList.ToList().Add(new
                    //{
                    //    Id = 0,
                    //    ProjectName = "---无项目权限---"
                    //});
                    Ext.Net.ListItem liProject = new Ext.Net.ListItem();
                    liProject.Text = "---无项目权限---";
                    liProject.Value = "0";
                    ddXMProject.Items.Add(liProject);
                    ddXMProject.Value = 0;
                }
                else
                {
                    Ext.Net.Store Store = ddXMProject.GetStore();
                    Store.DataSource = projectList;
                    Store.DataBind();
                    ddXMProject.SelectedIndex = 0;
                    ddXMProject.Value = projectList.ToList()[0].Id;
                }
                //if (projectList.Count() > 0)
                //{
                //    this.ddXMProject.DataSource = projectList;
                //    this.ddXMProject.DataTextField = "ProjectName";
                //    this.ddXMProject.DataValueField = "Id";
                //    this.ddXMProject.DataBind();
                //}
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "99"));
                Ext.Net.ListItem liProject1 = new Ext.Net.ListItem();
                liProject1.Text = "---所有---";
                liProject1.Value = "99";
                ddXMProject.Items.Add(liProject1);
                ddXMProject.Value = 99;
            }
            #endregion

            this.ddXMProject_SelectedIndexChanged(null, null);//店铺

            #region
            //this.ddXMProject.Items.Clear();
            //var projectList = base.XMProjectService.GetXMProjectList();
            //this.ddXMProject.DataSource = projectList;
            //this.ddXMProject.DataTextField = "ProjectName";
            //this.ddXMProject.DataValueField = "Id";
            //this.ddXMProject.DataBind();
            //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            #endregion
        }

        ///// <summary>
        ///// 物流公司
        ///// </summary>
        ///// <param name="loginsiticId"></param>
        ///// <returns></returns>
        //protected string GetCompanyCustom(string loginsiticId)
        //{
        //    try
        //    {
        //        var Logistic = base.XMCompanyCustomService.GetXMCompanyCustomByLogisticId(loginsiticId);
        //        if (loginsiticId != null)
        //        {
        //            return Logistic.LogisticsName;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}

        //手动发货导出
        protected void btnDeliverExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //导出存放路径
                    string fileName = string.Format("DeliverExport_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\DeliverExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;

                    //读取数据
                    List<XMDeliveryNew> list = new List<XMDeliveryNew>();
                    List<int> ProductInfoIDs = this.Master.GetSelectedIds(this.grdvClients);

                    //this.BindGrid(1, Master.PageSize);

                    if (ProductInfoIDs.Count <= 0)
                    {
                        list = PostListExportList;
                    }
                    else
                    {
                        foreach (XMDeliveryNew one in PostListExportPageList)
                        {
                            if (ProductInfoIDs.IndexOf(one.Id) != -1)
                            {
                                list.Add(one);
                            }
                        }
                    }

                    base.ExportManager.DeliverExportList(filePath, list);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdateOrderInfo(string orderCode)
        {
            //订单号查询
            var xmorderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(orderCode);

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

            #region 各平台单个订单同步

            var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();

            switch (xmorderinfo.PlatformTypeId)
            {
                //天猫
                case 250:
                    XMOrderInfoApp xMorderInfoAppTMNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 250 && q.NickId == xmorderinfo.NickID).FirstOrDefault();
                    if (xMorderInfoAppTMNew != null)
                    {

                        Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(xmorderinfo.OrderCode), xMorderInfoAppTMNew);

                        if (trade != null)
                        {
                            base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoAppTMNew);
                        }
                    }
                    break;
                //京东 (喜临门、嘟丽)
                case 251:
                    List<XMOrderInfoApp> xMorderInfoAppJDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 251 && q.NickId == xmorderinfo.NickID).ToList();
                    if (xMorderInfoAppJDNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoAppJDNew.Count; j++)
                        {
                            HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                            HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xmorderinfo.OrderCode, xMorderInfoAppJDNew[j].AppKey, xMorderInfoAppJDNew[j].AppSecret, xMorderInfoAppJDNew[j].ServerUrl, xMorderInfoAppJDNew[j].AccessToken);
                            if (orderInfo != null)
                            {
                                base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDNew[j]);

                            }
                        }
                    }
                    break;

                //京东闪购
                case 382:
                    List<XMOrderInfoApp> xMorderInfoAppJDSJNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 382 && q.NickId == xmorderinfo.NickID).ToList();
                    if (xMorderInfoAppJDSJNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoAppJDSJNew.Count; j++)
                        {
                            HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                            HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xmorderinfo.OrderCode, xMorderInfoAppJDSJNew[j].AppKey, xMorderInfoAppJDSJNew[j].AppSecret, xMorderInfoAppJDSJNew[j].ServerUrl, xMorderInfoAppJDSJNew[j].AccessToken);
                            if (orderInfo != null)
                            {
                                base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDSJNew[j]);

                            }
                        }
                    }
                    break;
                //淘宝集市店
                case 381:
                    List<XMOrderInfoApp> xMorderInfoAppTMCDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 381 && q.NickId == xmorderinfo.NickID).ToList();
                    if (xMorderInfoAppTMCDNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoAppTMCDNew.Count; j++)
                        {
                            Trade trade = base.XMOrderInfoAPIService.GetTrade(long.Parse(xmorderinfo.OrderCode), xMorderInfoAppTMCDNew[j]);
                            if (trade != null)
                            {
                                base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMCDInsertCount, ref  TMCDUpdateCount, xMorderInfoAppTMCDNew[j]);
                            }
                        }
                    }
                    break;
                //唯品会
                case 259:
                    List<XMOrderInfoApp> xMorderInfoVPHNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 259 && q.NickId == xmorderinfo.NickID).ToList();
                    if (xMorderInfoVPHNew.Count > 0)
                    {
                        base.XMOrderInfoAPIService.getOrderVPH(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd  HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss"), xmorderinfo.OrderCode, ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoVPHNew[0]);
                    }
                    break;
                //一号店
                case 375:
                    List<XMOrderInfoApp> xMorderInfoYHDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 375 && q.NickId == xmorderinfo.NickID).ToList();
                    if (xMorderInfoYHDNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoYHDNew.Count; j++)
                        {
                            base.XMOrderInfoAPIService.getOrderYHD(xmorderinfo.OrderCode, ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoYHDNew[j]);
                        }
                    }
                    break;
                //苏宁易购
                case 383:
                    List<XMOrderInfoApp> xMorderInfoSuningNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 383 && q.NickId == xmorderinfo.NickID).ToList();
                    if (xMorderInfoSuningNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoSuningNew.Count; j++)
                        {
                            base.XMOrderInfoAPIService.getOrderSuning(xmorderinfo.OrderCode, ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoSuningNew[j]);
                        }
                    }
                    break;
            }

            int count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;

            if (count > 0)
            {
                //修改公公参数
                base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");
                #region 订单单个同步记录操作

                int UpsatorID1 = 0;
                if (HozestERPContext.Current.User != null)
                {
                    UpsatorID1 = HozestERPContext.Current.User.CustomerID;

                }
                else
                {
                    string UserName = "admin";
                    List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                    if (customer.Count > 0)
                    {
                        UpsatorID1 = customer[0].CustomerID;
                    }
                }

                XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                record1.OrderInfoId = xmorderinfo.ID;
                record1.PropertyName = "订单单个同步";
                record1.OldValue = "同步成功";
                record1.NewValue = "同步成功";
                record1.UpdatorID = UpsatorID1;
                record1.UpdateTime = DateTime.Now;
                IoC.Resolve<XMOrderInfoOperatingRecordService>().InsertXMOrderInfoOperatingRecord(record1);// base.ProjectService.InsertXMOrderInfoOperatingRecord(record);

                #endregion
            }
            else
            {
                //修改公共参数
                base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");

                #region 订单单个同步记录操作

                int UpsatorID1 = 0;
                if (HozestERPContext.Current.User != null)
                {
                    UpsatorID1 = HozestERPContext.Current.User.CustomerID;

                }
                else
                {
                    string UserName = "admin";
                    List<Customer> customer = base.CustomerService.GetCustomerByUsernameList(UserName);

                    if (customer.Count > 0)
                    {
                        UpsatorID1 = customer[0].CustomerID;
                    }
                }

                XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                record1.OrderInfoId = xmorderinfo.ID;
                record1.PropertyName = "订单单个同步";
                record1.OldValue = "同步失败";
                record1.NewValue = "同步失败";
                record1.UpdatorID = UpsatorID1;
                record1.UpdateTime = DateTime.Now;
                base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record1);

                #endregion
            }

            #endregion
        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddXMProject.Value.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(ddXMProject.Value));
                    ddlNick.Items.Clear();
                    Ext.Net.Store Store = ddlNick.GetStore();
                    nickList.Add(new XMNick()
                    {
                        nick= "---所有---",
                        nick_id=-1,
                    });
                    Store.DataSource = nickList.OrderBy(a => a.nick_id);
                    Store.DataBind();
                    ddlNick.SelectedIndex = 0;
                    if(!Page.IsPostBack)
                    {
                        ddlNick.Value = "-1";
                    }
                }
                else
                {
                    //其他
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(ddXMProject.Value), HozestERPContext.Current.User.CustomerID, 0);
                    ddlNick.Items.Clear();
                    if (nickList.Count() == 0)
                    {
                        nickList.Add(new XMNick()
                        {
                            nick= "---无店铺权限---",
                            nick_id=0,
                        });
                        Ext.Net.Store Store = ddlNick.GetStore();
                        Store.DataSource = nickList;
                        Store.DataBind();
                        ddlNick.SelectedIndex = 0;
                        if (!Page.IsPostBack)
                        {
                            ddlNick.Value = "0";
                        }
                    }
                    else
                    {
                        if (nickList.Count() > 0)
                        {
                            nickList.Insert(0, new XMNick()
                            {
                                nick = "---所有---",
                                nick_id = 99,
                            });
                            Ext.Net.Store Store = ddlNick.GetStore();
                            Store.DataSource = nickList;
                            Store.DataBind();
                            ddlNick.SelectedIndex = 0;
                            if (!Page.IsPostBack)
                            {
                                ddlNick.Value = "99";
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 赠品取消面单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelWaybill_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                List<HozestERP.BusinessLogic.ManageProject.XMDelivery> list = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
                foreach (int ID in IDs)
                {
                    var delivery = base.XMDeliveryService.GetXMDeliveryById(ID);
                    if (delivery != null)
                    {
                        if (delivery.IsDelivery == false)
                        {
                            base.ShowMessage("发货单号：" + delivery.DeliveryNumber + "，的发货单未发货！");
                            return;
                        }
                        if (delivery.LogisticsId == null || string.IsNullOrEmpty(delivery.LogisticsNumber))
                        {
                            base.ShowMessage("发货单号：" + delivery.DeliveryNumber + "，的发货单没有物流公司或物流单号！");
                            return;
                        }
                        //if (delivery.DeliveryTypeId != 481)
                        //{
                        //    base.ShowMessage("发货单号：" + delivery.DeliveryNumber + "，的发货单类型不是赠送产品！");
                        //    return;
                        //}
                        list.Add(delivery);
                    }
                }

                string str = base.XMOrderInfoAPIService.CancelWaybill(list);
                if (str == "")
                {
                    //更新出库单库存
                    foreach (HozestERP.BusinessLogic.ManageProject.XMDelivery Info in list)
                    {
                        if (Info.DeliveryTypeId == 481)                       //判断是否是赠品 如是赠品 更新销售出库单状态 更新库存
                        {
                            //根据发货单ID  查询进销存系统销售出库单记录  更新出库状态  更新库存信息
                            var saleDeliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryListByParm(Info.Id);
                            if (saleDeliveryInfo != null && saleDeliveryInfo.Count > 0)
                            {
                                foreach (var info in saleDeliveryInfo)
                                {
                                    using (TransactionScope scope = new TransactionScope())
                                    {
                                        info.BillStatus = 0;   //更新为待入库状态
                                        info.UpdateDate = DateTime.Now;
                                        info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMSaleDeliveryService.UpdateXMSaleDelivery(info);
                                        var deliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(info.Id);
                                        if (deliveryProductDetails != null && deliveryProductDetails.Count > 0)
                                        {
                                            foreach (XMSaleDeliveryProductDetails parm in deliveryProductDetails)
                                            {
                                                string code = parm.PlatformMerchantCode;              //商品编码
                                                int wfID = info.WareHouseId;                              //出库仓库ID
                                                var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(code, wfID);
                                                if (InventoryInfo != null)                             //商品编码为code的产品在库存表中已经存在 更新库存数量
                                                {
                                                    InventoryInfo.StockNumber = InventoryInfo.StockNumber + parm.SaleCount;             //库存加上出库量
                                                    InventoryInfo.CanOrderCount = InventoryInfo.StockNumber;
                                                    InventoryInfo.UpdateDate = DateTime.Now;
                                                    InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                    base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);
                                                }
                                            }
                                        }
                                        scope.Complete();
                                    }
                                }
                            }

                        }
                    }
                    base.ShowMessage("取消电子面单号成功！");
                }
                else
                {
                    base.ShowMessage(str);
                }
            }

            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnShelveDelivery_Click(object sender, EventArgs e)
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
                    var delivery = base.XMDeliveryService.GetXMDeliveryById(ID);
                    if (delivery != null)
                    {
                        delivery.IsShelve = true;
                        delivery.UpdateDate = DateTime.Now;
                        delivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                        base.XMDeliveryService.UpdateXMDelivery(delivery);
                    }
                }
                base.ShowMessage("挂起成功！");
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }

        protected void btnUnShelveDelivery_Click(object sender, EventArgs e)
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
                    var delivery = base.XMDeliveryService.GetXMDeliveryById(ID);
                    if (delivery != null)
                    {
                        delivery.IsShelve = false;
                        delivery.UpdateDate = DateTime.Now;
                        delivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                        base.XMDeliveryService.UpdateXMDelivery(delivery);
                    }
                }
                base.ShowMessage("取消挂起成功！");
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }

        /// <summary>
        /// 生成喜临门订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnXLMOrderInfo_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                var DeliveryList = base.XMDeliveryService.GetXMDeliveryByListIds(IDs);
                foreach (var Info in DeliveryList)
                {
                    if (Info.DeliveryTypeId != 480 && Info.DeliveryTypeId != 708)
                    {
                        base.ShowMessage("发货单类型必须为正式产品或换货产品！");
                        return;
                    }
                    if (Info.IsDelivery == true || Info.PrintQuantity != 0)
                    {
                        base.ShowMessage("已发货或已打印的订单不能生成生成喜临门订单！");
                        return;
                    }
                    if (string.IsNullOrEmpty(Info.OrderCode))
                    {
                        base.ShowMessage("发货单号：" + Info.DeliveryNumber + "，不存在订单号！");
                        return;
                    }
                    else
                    {
                        var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(Info.OrderCode);
                        if (OrderInfo == null)
                        {
                            base.ShowMessage("订单号：" + Info.OrderCode + "，在订单表中不存在！");
                            return;
                        }
                    }
                }

                string msg = "";
                string method = "qs.order.put";

                foreach (var Info in DeliveryList)
                {
                    StringBuilder body = new StringBuilder();
                    body = GetOrderPutJson(body, Info, ref msg);
                    if (body == null)
                    {
                        //msg += "发货单号：" + Info.DeliveryNumber + "，转换Json格式错误！";
                        continue;
                    }

                    //string url = xLMInterface.GetUrl(method, body.ToString());//喜临门老系统
                    string paramtoken = "";
                    # region 获取喜临门新系统token
                    XMOrderInfoApp orderinfoapp = base.XMOrderInfoAppService.GetXMOrderInfoAppByID(68);
                    if (orderinfoapp != null)
                        paramtoken = orderinfoapp.AccessToken;
                    #endregion
                    string url = xLMInterface.NewApiUrl + "sleemonecwebservices/sleemonOrder/createOrder?access_token=" + paramtoken;//喜临门新系统
                    string josnStr = xLMInterface.GetResponseData(body.ToString(), url);//GetInfo(url);
                    if (josnStr == "error")
                    {
                        msg += "网络连接错误，请稍后再试！";
                        break;
                    }

                    Dictionary<string, object> data = xLMInterface.JsonToDictionary(josnStr);
                    if (data.ContainsKey("flag"))
                    {
                        msg += "发货单号：" + Info.DeliveryNumber + "，" + data["message"] + "！<br/>";
                    }
                    else
                    {
                        if (data["success"].ToString() != "True")
                        {
                            msg += "发货单号：" + Info.DeliveryNumber + "，" + data["message"] + "！<br/>";
                        }
                        else
                        {
                            Info.PrintQuantity = Info.PrintQuantity == null ? 0 : Info.PrintQuantity;
                            Info.PrintBatch = Info.PrintBatch == null ? 0 : Info.PrintBatch;
                            Info.PrintQuantity += 1;//打印次数

                            //取发货单表中 打印批次倒序最后条
                            var xMDeliveryListByPrintBatch = IoC.Resolve<IXMDeliveryService>().GetXMDeliveryList().OrderByDescending(p => p.PrintBatch).FirstOrDefault();
                            if (xMDeliveryListByPrintBatch != null)
                            {
                                if (xMDeliveryListByPrintBatch.PrintBatch != null)
                                {
                                    Info.PrintBatch = xMDeliveryListByPrintBatch.PrintBatch.Value + 1;
                                }
                            }
                            Info.PrintDateTime = DateTime.Now;//打印时间
                            Info.UpdateId = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.XMDeliveryService.UpdateXMDelivery(Info);
                        }
                    }
                }

                if (msg != "")
                {
                    base.ShowMessage(msg);
                }
                else
                {
                    base.ShowMessage("喜临门订单创建成功！");

                    this.BindGrid(1, Master.PageSize);
                }
            }
        }

        public StringBuilder GetOrderPutJson(StringBuilder body, BusinessLogic.ManageProject.XMDelivery delivery, ref string msg)
        {
            try
            {
                int a = 0;
                string Zip = "000000";
                string remark = "";
                string shopName = "城市爱情";
                string WantID = "";
                string Province = "";
                string City = "";
                string County = "";
                string Address = "";

                if (!string.IsNullOrEmpty(delivery.DeliveryAddress) && delivery.DeliveryAddress.Length >= 8)
                {
                    string ybs = delivery.DeliveryAddress.Substring(delivery.DeliveryAddress.Length - 8).Replace("(", "").Replace(")", "").Replace("（", "").Replace("）", "");

                    if (ybs.Length == 6 && int.TryParse(ybs, out  a))
                    {
                        Zip = ybs;
                    }
                }

                var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(delivery.OrderCode);

                if (string.IsNullOrEmpty(OrderInfo.WantID))
                {
                    WantID = OrderInfo.PlatformName;//"匿名";
                }
                else
                {
                    WantID = OrderInfo.WantID;
                }

                //platOrderHeader
                //body.Append("{").Append("\"platOrderHeader\":{").Append("");//喜临门老系统
                body.Append("{");
                body.Append("\"shopName\":").Append("\"" + shopName + "\",");
                body.Append("\"status\":").Append("\"WAIT_SELLER_SEND_GOODS\",");

                #region 修改卖家备注

                if (!string.IsNullOrEmpty(delivery.OrderRemarks))
                {
                    remark = delivery.OrderRemarks;
                }
                else
                {
                    remark = OrderInfo.CustomerServiceRemark == null ? "" : OrderInfo.CustomerServiceRemark;
                }

                if (remark.IndexOf("//赠品") != -1)
                {
                    remark = remark.Substring(0, remark.IndexOf("//赠品"));
                }
                if (remark.IndexOf("//更改尺寸为") > -1)
                {
                    remark = remark.Substring(0, remark.IndexOf("//更改尺寸为"));
                }
                else if (remark.IndexOf("//更改床垫地址") > -1)
                {
                    remark = remark.Substring(0, remark.IndexOf("//更改床垫地址"));
                }

                var exist = delivery.XM_Delivery_Details.Where(x => x.PrdouctName.Contains("乳胶枕") || x.PrdouctName.Contains("喜米") || x.PrdouctName.Contains("U型枕")).ToList();
                if (exist != null && exist.Count > 0)
                {
                    remark = "中通速递/能发就发/小城///送货上门";
                }

                #endregion
                body.Append("\"buyerMemo\":").Append("\"|" + delivery.OrderCode + "|\",");
                body.Append("\"sellerMemo\":").Append("\"" + remark + "\",");
                body.Append("\"modified\":").Append("\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\",");
                body.Append("\"buyerNick\":").Append("\"" + WantID + "\",");
                body.Append("\"created\":").Append("\"" + ((DateTime)OrderInfo.OrderInfoCreateDate).ToString("yyyy-MM-dd HH:mm:ss") + "\",");
                body.Append("\"num\":").Append(OrderInfo.XM_OrderInfoProductDetails.Sum(x => x.ProductNum) + ",");
                body.Append("\"tid\":").Append("\"" + delivery.DeliveryNumber + "\",");
                body.Append("\"payment\":").Append((OrderInfo.OrderPrice == null ? 0 : OrderInfo.OrderPrice) + ",");
                body.Append("\"payTime\":").Append("\"" + ((DateTime)OrderInfo.PayDate).ToString("yyyy-MM-dd HH:mm:ss") + "\",");
                body.Append("\"totalFee\":").Append((OrderInfo.ProductPrice == null ? 0 : OrderInfo.ProductPrice) + ",");
                body.Append("\"postFee\":").Append("0,");
                body.Append("\"receiverName\":").Append("\"" + delivery.FullName + "\",");

                #region 省市区处理

                bool IsChange = false;
                if (delivery.Province.IndexOf("上海") != -1 || delivery.Province.IndexOf("北京") != -1
                    || delivery.Province.IndexOf("天津") != -1 || delivery.Province.IndexOf("重庆") != -1)
                {
                    Province = delivery.Province.Replace("市", "");
                    City = Province + "市";

                    List<AreaCode> CountyList = new List<AreaCode>();
                    if (delivery.Province.IndexOf("北京") != -1)
                    {
                        CountyList = IoC.Resolve<IAreaCodeService>().GetAreaCodeByCity(3, Province);
                    }
                    else
                    {
                        CountyList = IoC.Resolve<IAreaCodeService>().GetAreaCodeByCity(4, Province);
                    }

                    if (CountyList.Count > 0)
                    {
                        foreach (var item in CountyList)
                        {
                            if (delivery.County.IndexOf(item.City) != -1)
                            {
                                County = delivery.County;
                                IsChange = true;
                                break;
                            }
                            else if (delivery.City.IndexOf(item.City) != -1)
                            {
                                County = delivery.City;
                                IsChange = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (delivery.Province.IndexOf("省") != -1 || delivery.Province.IndexOf("自治区") != -1 || delivery.Province.IndexOf("特别行政区") != -1)
                    {
                        Province = delivery.Province;
                    }
                    else
                    {
                        if (delivery.Province != null && delivery.Province.Length > 1)
                        {
                            string province = delivery.Province.Substring(0, 2);
                            var ProvinceList = IoC.Resolve<IAreaCodeService>().GetAreaCodeByCity(2, province);
                            if (ProvinceList != null && ProvinceList.Count > 0)
                            {
                                Province = ProvinceList[0].City + ProvinceList[0].CityType;
                            }
                            else
                            {
                                Province = delivery.Province;
                            }
                        }
                    }
                }

                if (!IsChange)
                {
                    City = delivery.City == null ? "" : delivery.City;
                    if (string.IsNullOrEmpty(delivery.County))
                    {
                        string address = delivery.DeliveryAddress.Replace(".", "");
                        int CityIndex = address.IndexOf('市');
                        if (CityIndex != -1)
                        {
                            int CountyIndex = address.Substring(CityIndex, address.Length - CityIndex).IndexOf('区');

                            if (CityIndex != -1 && CountyIndex != -1 && CityIndex + 1 < address.Length)
                            {
                                string county = address.Substring(CityIndex + 1, CountyIndex);
                                if (county.Length > 0)
                                {
                                    County = county;
                                }
                            }
                            else
                            {
                                CountyIndex = address.Substring(CityIndex, address.Length - CityIndex).IndexOf('县');
                                if (CityIndex != -1 && CountyIndex != -1 && CityIndex + 1 < address.Length)
                                {
                                    string county = address.Substring(CityIndex + 1, CountyIndex);
                                    if (county.Length > 0)
                                    {
                                        County = county;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        County = delivery.County;
                    }
                }

                #endregion

                body.Append("\"receiverState\":").Append("\"" + Province + "\",");
                body.Append("\"receiverCity\":").Append("\"" + City + "\",");
                body.Append("\"receiverDistrict\":").Append("\"" + County + "\",");

                #region 详细地址

                Address = delivery.DeliveryAddress.Replace("\r", "").Replace("\n", "");
                if (!Address.Contains(County))
                {
                    Address = County + Address;
                }

                #endregion

                body.Append("\"receiverAddress\":").Append("\"" + Address + "\",");

                body.Append("\"receiverZip\":").Append("\"" + Zip + "\",");
                body.Append("\"receiverMobile\":").Append("\"" + delivery.Mobile + "\",");
                body.Append("\"receiverPhone\":").Append("\"" + (delivery.Tel == null ? "" : (delivery.Tel == "" ? "0000-00000000" : delivery.Tel)) + "\",");
                body.Append("\"hasPostFee\":").Append("true,");

                //platOrderDetails
                body.Append("\"platOrderDetails\":[");

                var detailList = delivery.XM_Delivery_Details.ToList();
                for (int i = 0; i < detailList.Count; i++)
                {
                    decimal Price = 0;
                    string ManufacturersCode = "";
                    body.Append("{");
                    var detail = detailList[i];
                    var Product = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(detail.PlatformMerchantCode, (int)OrderInfo.PlatformTypeId);
                    if (Product != null && Product.Count > 0)
                    {
                        var product = IoC.Resolve<IXMProductService>().GetXMProductById((int)Product[0].ProductId);
                        if (product != null)
                        {
                            Price = Product[0].Saleprice == null ? 0 : (decimal)Product[0].Saleprice;
                            ManufacturersCode = Product[0].ManufacturersCode;
                        }
                    }
                    if (ManufacturersCode == "")
                    {
                        msg += "商品编码：" + detail.PlatformMerchantCode + "，不存在！<br/>";
                        return null;
                    }

                    body.Append("\"totalFee\":").Append(Price * detail.ProductNum + ",");
                    body.Append("\"payment\":").Append(Price * detail.ProductNum + ",");
                    body.Append("\"modified\":").Append("\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\",");
                    body.Append("\"num\":").Append(detail.ProductNum + ",");
                    body.Append("\"price\":").Append(Price + ",");
                    body.Append("\"outerSkuId\":").Append("\"" + ManufacturersCode + "\",");
                    body.Append("\"taxRate\":").Append("\"0.06\"}");
                    if (i != detailList.Count - 1)
                    {
                        body.Append(",");
                    }
                }
                body.Append("],");

                //platOrderPayTypes
                body.Append("\"platOrderPayTypes\":[{");
                body.Append("\"amount\":").Append((OrderInfo.PayPrice == null ? 0 : OrderInfo.PayPrice) + ",");
                //body.Append("\"payType\":").Append("\"001\"}]}");//喜临门老系统
                body.Append("\"payType\":").Append("\"alipay\"}]");
                body.Append("}");
                return body;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 行展开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Unnamed_Event(object sender, Ext.Net.DirectEventArgs e)
        {
            List<XMDeliveryDetails> xMDeliveryDetailsList = new List<XMDeliveryDetails>();
            int ID =int.Parse(e.ExtraParams["ID"]);
            string FullName = e.ExtraParams["FullName"];
            string Province = e.ExtraParams["Province"];
            string DeliveryAddress = e.ExtraParams["DeliveryAddress"];
            string Mobile = e.ExtraParams["Mobile"];
            string City = e.ExtraParams["City"];
            string DeliveryAddressSpare = e.ExtraParams["DeliveryAddressSpare"];
            string Tel = e.ExtraParams["Tel"];
            string County = e.ExtraParams["County"];
            string OrderRemarks = e.ExtraParams["OrderRemarks"];
            string PrintQuantity = e.ExtraParams["PrintQuantity"];
            string PrintBatch = e.ExtraParams["PrintBatch"];
            string PrintDateTime = e.ExtraParams["PrintDateTime"];
            int rowIndex = int.Parse(e.ExtraParams["rowIndex"]);

            int strProductNum = 0;

            xMDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(ID);

            if (xMDeliveryDetailsList != null && xMDeliveryDetailsList.Count > 0)
            {
                strProductNum += (int)xMDeliveryDetailsList.Sum(x => x.ProductNum);
            }

            Ext.Net.Store Store = Store2;
            Store.DataSource = xMDeliveryDetailsList;
            Store.DataBind();

            if (xMDeliveryDetailsList.Count > 1 || strProductNum > 1)
            {
                cell_button_2.Hidden = false;
            }
            else
            {
                cell_button_2.Hidden = true;
            }

            var tpl = new Ext.Net.XTemplate { ID = "Template1" };

            //tpl.Html = @"<p>Name: {Name}</p>
            //       <p>Company: {Company}</p>
            //       <p>Location: {City}, {State}</p>
            //       <p>Kids:
            //       <tpl for=""Kids"" if=""Name=='Jack Slocum'"">
            //       <tpl if=""Age &gt; 1""><p>{#}. {parent.Name}'s kid - {Name}</p></tpl>
            //       </tpl></p>";

            tpl.Html = @"<table>
                                      <tr>
                                            <td colspan='100 %' style='text-align: left;'><span style='font-size: 18px; font-family: 隶书; '>收货信息</span></td>
                                       </tr>
                                       <tr>
                                            <td style='text-align: right; width: 90px; '>
                                                       <b> 收货人姓名：</b>    
                                            </td>      
                                            <td style = 'text-align: left; width: 100px;' > {FullName} </td>          
                                            <td style = 'display:none' >{Id}</td>               
                                             <td style = 'text-align: right; width: 90px;'>
                                                        <b> 省：</b>                    
                                             </td>                    
                                              <td style = 'text-align: left; width: 100px;' > {Province} </td>                         
                                              <td style = 'text-align: right; width: 90px;' >                          
                                               <b> 收货地址：</b>                             
                                              </td>                             
                                              <td colspan = '5' style = 'text-align: left; width: 710px;' > {DeliveryAddress} </td>                                    
                                        </tr>
                                        <tr>
                                              <td style='text-align: right; width: 90px; '>
                                                      <b> 手机：</b>     
                                               </td>      
                                               <td style = 'text-align: left; width: 100px;' >
                                                         {Mobile}
                                                </td>
                                                <td style = 'text-align: right; width: 90px;' > 
                                                 <b> 市：</b> 
                                                 </td>    
                                                 <td style = 'text-align: left; width: 100px;' >
                                                                {City}
                                                  </td>
                                                  <td style = 'text-align: right; width: 90px;' > 
                                                  <b> 备用收货地址：</b>   
                                                   </td>    
                                                   <td colspan = '5' style = 'text-align: left; width: 710px;' >
                                                                {DeliveryAddressSpare}
                                                    </td>
                                         </tr>
                                          <tr>
                                                    <td style='text-align: right; width: 90px; '>
                                                                   <b> 电话：</b>     
                                                     </ td >      
                                                      <td style = 'text-align: left; width: 100px;' >
                                                                {Tel}
                                                      </td>
                                                       <td style = 'text-align: right; width: 90px;' > 
                                                                 <b> 区 / 县：</b>      
                                                        </td>      
                                                        <td style = 'text-align: left; width: 100px;' >
                                                                {County}
                                                         </td>
                                                         <td style = 'text-align: right; width: 90px;' >
                                                                 <b> 备注：</b>    
                                                          </td>   
                                                           <td colspan = '5' style = 'text-align: left; width: 710px;' >
                                                                {OrderRemarks}
                                                           </td>
                                          </tr>    
                                            <tr>
                                                    <td style='text-align: right; width: 90px; '>
                                                                   <b> 打印次数：</b>     
                                                     </ td >      
                                                      <td style = 'text-align: left; width: 100px;' >
                                                                {PrintQuantity}
                                                      </td>
                                                       <td style = 'text-align: right; width: 90px;' > 
                                                                 <b> 打印批次：</b>      
                                                        </td>      
                                                        <td style = 'text-align: left; width: 100px;' >
                                                                {PrintBatch}
                                                         </td>
                                                         <td style = 'text-align: right; width: 90px;' >
                                                                 <b> 打印时间：</b>    
                                                          </td>   
                                                           <td colspan = '5' style = 'text-align: left; width: 710px;' >
                                                                {PrintDateTime}
                                                           </td>
                                          </tr>                                    
                                              </table>";

            tpl.Overwrite(this.Panel1, new
            {
                FullName = FullName,
                Id = ID,
                Province = Province,
                DeliveryAddress = DeliveryAddress,
                Mobile = Mobile,
                City = City,
                DeliveryAddressSpare = DeliveryAddressSpare,
                Tel = Tel,
                County = County,
                OrderRemarks = OrderRemarks,
                PrintQuantity = PrintQuantity == "0" ? "未打印" : PrintQuantity,
                PrintBatch = PrintBatch,
                PrintDateTime = string.IsNullOrWhiteSpace(PrintDateTime) ? "" : Convert.ToDateTime(PrintDateTime).ToString("yyyy-MM-dd HH:mm:ss")
            });

            tpl.Render();

            CheckboxSelectionModel1.SelectRow(rowIndex);
            //cell_button_1.ID = "1234567890";
            //this.Panel1.BodyElement.Highlight("#c3daf9", new Ext.Net.HighlightConfig { Block = true });

        }

        /// <summary>
        /// 重新排单按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cell_button_1_click(object sender, Ext.Net.DirectEventArgs e)
        {
            try
            {
                string data = e.ExtraParams["data"];
                System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<XMDeliveryNew> list = Serializer.Deserialize<List<XMDeliveryNew>>(data);
                if (list.Count <= 0)
                {
                    Ext.Net.ExtNet.Msg.Alert("提示", "请选择一条数据").Show();
                }
                else if (list.Count > 1)
                {
                    Ext.Net.ExtNet.Msg.Alert("提示", "请不要选择多条数据").Show();
                }
                //除了喜临门
                else if ((bool)list[0].IsDelivery && list[0].projectId != 2)
                {
                    Ext.Net.ExtNet.Msg.Alert("提示", "已发货，不允许操作！").Show();
                }
                else
                {
                    if (!string.IsNullOrEmpty(list[0].LogisticsCompany) || !string.IsNullOrEmpty(list[0].LogisticsNumber))
                    {
                        Ext.Net.ExtNet.Msg.Alert("提示", "请先取消面单号！").Show();
                    }
                    #region 重新排单逻辑

                    string paramMessage = string.Empty;
                    //事务
                    using (TransactionScope scope = new TransactionScope())
                    {

                        //发货单信息
                        var Delivery = base.XMDeliveryService.GetXMDeliveryById(list[0].Id);
                        //订单信息
                        var OrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(Delivery.OrderCode);

                        if (Delivery != null)
                        {
                            //if ((bool)Delivery.IsDelivery && (Delivery.IsShelve == null || Delivery.IsShelve == false))
                            //{
                            //    scope.Complete();
                            //    //base.ShowMessage("已发货的发货单不能重新排单！");
                            //    Ext.Net.ExtNet.Msg.Alert("提示", "已发货的发货单不能重新排单！").Show();
                            //    return;
                            //}

                            if (Delivery.DeliveryTypeId == 480 || Delivery.DeliveryTypeId == 708)
                            {
                                #region 正常（订单发货单）<注：需要修改  发货发货单主表中商品编码已取消 （根据发货单明细）>
                                if(OrderInfo!=null)
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.PropertyName = "ReSingleRow";
                                    record.OldValue = "订单：" + OrderInfo.OrderCode + "  商品：" + Delivery.ProductNo + "  重新排单";
                                    record.NewValue = "订单：" + OrderInfo.OrderCode + "  商品：" + Delivery.ProductNo + "  重新排单";
                                    record.OrderInfoId = OrderInfo.ID;
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }

                                if (Delivery.DeliveryTypeId == 480)
                                {
                                    //选中的明细数据
                                    var xmDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(Delivery.Id);
                                    //判断发货明细中的 商品信息是否类型相同  
                                    var DetailsTypeIdListGroupBy = xmDeliveryDetailsList.GroupBy(p => p.DetailsTypeId.Value).Select(g => g.First()).ToList();//根据类型分组                                                                                                                       
                                    if (DetailsTypeIdListGroupBy.Count > 1)//明细类型不一致 不可重新排单
                                    {
                                        paramMessage = "该发货单明细类型不一致,请先拆分再重新排单。";
                                        //base.ShowMessage(paramMessage);
                                        Ext.Net.ExtNet.Msg.Alert("提示", paramMessage).Show();
                                        return;
                                    }

                                    if (xmDeliveryDetailsList != null && xmDeliveryDetailsList.Count > 0)
                                    {
                                        foreach (var detail in xmDeliveryDetailsList)
                                        {
                                            //修改排单状态、审核状态
                                            var OrderInfoProductList = OrderInfo.XM_OrderInfoProductDetails.Where(p => p.PlatformMerchantCode.Equals(detail.PlatformMerchantCode) && p.ProductNum == detail.ProductNum && p.IsSingleRow == true).ToList();

                                            if (OrderInfoProductList != null && OrderInfoProductList.Count > 0)
                                            {
                                                OrderInfoProductList[0].IsSingleRow = false;
                                                OrderInfoProductList[0].IsAudit = false;
                                                OrderInfoProductList[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                                OrderInfoProductList[0].UpdateDate = DateTime.Now;
                                                base.XMOrderInfoService.UpdateXMOrderInfo(OrderInfo);

                                                if (Delivery.IsShelve == null || Delivery.IsShelve == false)
                                                {
                                                    //喜临门返回库存
                                                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm((int)detail.WarehouseID, OrderInfoProductList[0].TManufacturersCode, "");
                                                    var inventoryNotNickID2 = base.XMInventoryInfoService.GetXMInventoryInfoByParm(OrderInfoProductList[0].TManufacturersCode, (int)detail.WarehouseID);//其他项目判断库存管理里面的可订购数量
                                                    if (exist.Count > 0)
                                                    {
                                                        exist[0].Inventory += detail.ProductNum;
                                                        base.XMXLMInventoryService.UpdateXMXLMInventory(exist[0]);
                                                    }
                                                    if (inventoryNotNickID2 != null&& OrderInfo.ProjectId!=2)
                                                    {
                                                        inventoryNotNickID2.CanOrderCount += detail.ProductNum;
                                                        base.XMInventoryInfoService.UpdateXMInventoryInfo(inventoryNotNickID2);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //修改订单审核状态
                                    if (OrderInfo.PlatformTypeId == 376)//亚马逊
                                    {
                                        OrderInfo.OrderStatus = "以接受";
                                    }
                                    OrderInfo.IsAudit = false;
                                    OrderInfo.UpdateDate = DateTime.Now;
                                    OrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    base.XMOrderInfoService.UpdateXMOrderInfo(OrderInfo);

                                    //删除发货信息
                                    Delivery.IsEnabled = true;
                                    Delivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                    Delivery.UpdateDate = DateTime.Now;
                                    base.XMDeliveryService.UpdateXMDelivery(Delivery);
                                }
                                else if (Delivery.DeliveryTypeId == 708)
                                {
                                    var ApplicationList = base.XMApplicationService.GetXMApplicationListByOrderCode(Delivery.OrderCode);
                                    var ApplicationInfo = ApplicationList.Where(x => x.ApplicationType == 6).OrderByDescending(x => x.CreateDate).ToList();//换货
                                    if (ApplicationInfo != null && ApplicationInfo.Count > 0)
                                    {
                                        ApplicationInfo[0].FinancialStatus = false;
                                        ApplicationInfo[0].SupervisorStatus = false;
                                        ApplicationInfo[0].IsSend = false;
                                        ApplicationInfo[0].FinishTime = null;
                                        ApplicationInfo[0].ReturnTime = null;
                                        ApplicationInfo[0].IsSingleRow = false;
                                        ApplicationInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                        ApplicationInfo[0].UpdateDate = DateTime.Now;
                                        base.XMApplicationService.UpdateXMApplication(ApplicationInfo[0]);
                                    }

                                    var ProjectEntity = XMNickService.GetProjectNameByID((int)ApplicationInfo[0].NickId);

                                    var DeliveryList = base.XMDeliveryService.GetXMDeliveryByOrderCodeAndDeliveryTypeId(Delivery.OrderCode, 708);
                                    if (DeliveryList != null && DeliveryList.Count > 0)
                                    {
                                        foreach (var item in DeliveryList)
                                        {
                                            //选中的明细数据
                                            var xmDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(item.Id);
                                            foreach (var detail in xmDeliveryDetailsList)
                                            {
                                                var ProductDetailsList = base.XMProductService.GetXMProductListByPlatformMerchantCode(detail.PlatformMerchantCode, -1);
                                                if (ProductDetailsList != null && ProductDetailsList.Count > 0)
                                                {
                                                    var Product = base.XMProductService.GetXMProductById((int)ProductDetailsList[0].ProductId);
                                                    if (Product != null)
                                                    {
                                                        if (Delivery.IsShelve == null || Delivery.IsShelve == false)
                                                        {
                                                            //喜临门返回库存
                                                            var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm((int)detail.WarehouseID, Product.ManufacturersCode, "");
                                                            if (exist.Count > 0)
                                                            {
                                                                exist[0].Inventory += detail.ProductNum;
                                                                base.XMXLMInventoryService.UpdateXMXLMInventory(exist[0]);
                                                            }
                                                            var inventoryNotNickID2 = base.XMInventoryInfoService.GetXMInventoryInfoByParm(Product.ManufacturersCode, (int)detail.WarehouseID);//其他项目判断库存管理里面的可订购数量
                                                            if (inventoryNotNickID2 != null&& ProjectEntity.Id!=2)
                                                            {
                                                                inventoryNotNickID2.CanOrderCount += detail.ProductNum;
                                                                base.XMInventoryInfoService.UpdateXMInventoryInfo(inventoryNotNickID2);
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            //删除发货信息
                                            item.IsEnabled = true;
                                            item.UpdateId = HozestERPContext.Current.User.CustomerID;
                                            item.UpdateDate = DateTime.Now;
                                            base.XMDeliveryService.UpdateXMDelivery(item);
                                        }
                                        paramMessage += "订单号：" + Delivery.OrderCode + "，发货单类型：换货产品，共" + DeliveryList.Count.ToString() + "个发货单已删除！";
                                    }

                                    //if(ProjectEntity.Id != 2&& ApplicationInfo[0].OrderCode.StartsWith("NoOrder"))
                                    //{
                                    //    //删除对应的出库单记录（状态为待出库状态）
                                    //    var saleDeliveries = base.XMSaleDeliveryService.GetXMSaleDeliveryListByParm(Delivery.Id);

                                    //    if (saleDeliveries != null && saleDeliveries.Count > 0)
                                    //    {
                                    //        foreach (XMSaleDelivery parm in saleDeliveries)
                                    //        {
                                    //            parm.IsEnable = true;
                                    //            parm.UpdateDate = DateTime.Now;
                                    //            parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    //            base.XMSaleDeliveryService.UpdateXMSaleDelivery(parm);
                                    //            var saleDeliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(parm.Id);
                                    //            if (saleDeliveryProductDetails != null && saleDeliveryProductDetails.Count > 0)
                                    //            {
                                    //                foreach (XMSaleDeliveryProductDetails p in saleDeliveryProductDetails)
                                    //                {
                                    //                    p.IsEnable = true;
                                    //                    p.UpdateDate = DateTime.Now;
                                    //                    p.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    //                    base.XMSaleDeliveryProductDetailsService.UpdateXMSaleDeliveryProductDetails(p);
                                    //                }
                                    //            }
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        throw new Exception("找不到对应出库单记录！");
                                    //    }
                                    //}

                                }

                                if (paramMessage == "")
                                {
                                    paramMessage = "操作成功！";
                                }

                                #endregion
                            }
                            else if (Delivery.DeliveryTypeId == 481)
                            {
                                #region 非正常(赠品发货单)
                                if (Delivery.IsDelivery != null)
                                {
                                    //未发货
                                    //if (Delivery.IsDelivery.Value == false)
                                    //{
                                    var xmDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(Delivery.Id);
                                    {
                                        foreach (var detail in xmDeliveryDetailsList)
                                        {
                                            string ManufacturersCode = "";
                                            if (detail.PlatformMerchantCode != null)
                                            {
                                                var productDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(detail.PlatformMerchantCode);
                                                if (productDetail != null && productDetail.Count > 0)
                                                {
                                                    ManufacturersCode = productDetail[0].ManufacturersCode;
                                                }
                                            }
                                            XMSaleDeliveryProductDetails saleDeliveryDetail = new XMSaleDeliveryProductDetails();
                                            saleDeliveryDetail.PlatformMerchantCode = ManufacturersCode;
                                            saleDeliveryDetail.SaleCount = detail.ProductNum;
                                            if (detail.WarehouseID != null)
                                            {
                                                var inventory = base.XMInventoryInfoService.GetXMInventoryInfoByParm(ManufacturersCode, (int)detail.WarehouseID);//其他项目判断库存管理里面的可订购数量
                                                //增加可订购数量
                                                if (inventory != null)
                                                {
                                                    inventory.CanOrderCount += detail.ProductNum;
                                                    base.XMInventoryInfoService.UpdateXMInventoryInfo(inventory);
                                                }
                                            }
                                        }
                                    }
                                    //根据主表Id 查询明细数据
                                    var DeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(Delivery.Id);

                                    //判断发货明细中的 商品信息是否类型相同  
                                    var DetailsTypeIdListGroupBy = DeliveryDetailsList.GroupBy(p => p.DetailsTypeId.Value).Select(g => g.First()).ToList();//根据类型分组

                                    //明细类型不一致 不可重新排单
                                    if (DetailsTypeIdListGroupBy.Count > 1)
                                    {
                                        paramMessage = "该发货单明细类型不一致,请先拆分再重新排单。";
                                        //base.ShowMessage(paramMessage);
                                        Ext.Net.ExtNet.Msg.Alert("提示", paramMessage).Show();
                                        return;
                                    }
                                    else if (DetailsTypeIdListGroupBy.Count == 1)
                                    {
                                        #region 累加明细订单号

                                        // 去掉重复的订单号 集合
                                        List<string> CodeNODistinct = new List<string>();

                                        if (DeliveryDetailsList.Count > 0)
                                        {
                                            //取发货单明细 订单编码列
                                            List<string> CodeNoList = DeliveryDetailsList.Select(a => a.OrderNo).ToList();

                                            //定义一个新的List<stirng> 
                                            List<string> CodeNoListNow = new List<string>();

                                            //取所有发货单明细 订单号 组成字符串
                                            string str = "";
                                            foreach (var item in CodeNoList)
                                            {
                                                str += item + ",";
                                            }

                                            if (!string.IsNullOrEmpty(str))
                                            {
                                                str = str.Substring(0, str.Length - 1);
                                            }
                                            //字符串串数组
                                            string[] OrderCodestr = str.Split(',');

                                            //把数组转成List<string>
                                            CodeNoListNow = new List<string>(OrderCodestr);

                                            //去掉重复的订单号
                                            CodeNODistinct = CodeNoListNow.Distinct().ToList();
                                        }

                                        #endregion

                                        //返回一个订单号
                                        if (CodeNODistinct.Count == 1)
                                        {
                                            #region 发货单重新排单

                                            // 根据商品编辑统计 明细商品数量    
                                            var GroupByMerchantCode = (from p in DeliveryDetailsList
                                                                       group p by new
                                                                       {
                                                                           PlatformMerchantCode = p.PlatformMerchantCode,
                                                                           DetailsTypeId = p.DetailsTypeId
                                                                       } into g
                                                                       select new XMDeliveryDetails
                                                                       {
                                                                           PlatformMerchantCode = g.Key.PlatformMerchantCode,
                                                                           DetailsTypeId = g.Key.DetailsTypeId,
                                                                           ProductNum = g.Sum(c => c.ProductNum)
                                                                       }).ToList();

                                            if (GroupByMerchantCode.Count > 0)
                                            {
                                                #region 修改商品管理中 对应的商品厂家库存数量
                                                for (int i = 0; i < GroupByMerchantCode.Count; i++)
                                                {
                                                    //根据商品编码查询 产品信息 并修改库存
                                                    var productList = base.XMProductService.getXMProductListByEqusManufacturersCode(GroupByMerchantCode[i].PlatformMerchantCode);
                                                    if (productList.Count > 0)
                                                    {
                                                        XMProduct product = productList[0];
                                                        //厂家库存=原库存+发货单明细库存
                                                        int ManufacturersInventory = product.ManufacturersInventory.Value + GroupByMerchantCode[i].ProductNum.Value;

                                                        product.ManufacturersInventory = ManufacturersInventory;
                                                        product.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                        product.UpdateDate = DateTime.Now;
                                                        base.XMProductService.UpdateXMProduct(product);
                                                    }
                                                }
                                                #endregion



                                                #region 修改 赠品管理中 赠品状态：未排单、 是否排单：否

                                                //根据发货单明细订单号、类型查询赠品信息
                                                //List<XMPremiums> XMPremiumsList = base.XMPremiumsService.GetXMPremiumsListByOrderCode(CodeNODistinct[0], DetailsTypeIdListGroupBy[0].DetailsTypeId.Value);

                                                //根据发货单明细sourceid，进行
                                                foreach (XMDeliveryDetails entity in DeliveryDetailsList)
                                                {
                                                    var xMPremiumsDetail = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById((int)entity.SourceID);
                                                    xMPremiumsDetail.IsSingleRow = false;
                                                    xMPremiumsDetail.UpdateDate = DateTime.Now;
                                                    xMPremiumsDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                    base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(xMPremiumsDetail);

                                                    var premiums = base.XMPremiumsService.GetXMPremiumsById((int)xMPremiumsDetail.PremiumsId);
                                                    premiums.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsNoHair);
                                                    premiums.IsSingleRow = false;
                                                    premiums.IsEvaluation = false;
                                                    premiums.EvaluationID = null;
                                                    premiums.EvaluationDate = null;
                                                    premiums.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                                                    premiums.ManagerPeople = null;
                                                    premiums.ManagerTime = null;
                                                    premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                                    premiums.UpdateTime = DateTime.Now;
                                                    base.XMPremiumsService.UpdateXMPremiums(premiums);
                                                }
                                                //if (XMPremiumsList.Count > 0)
                                                //{
                                                //    XMPremiums premiums = XMPremiumsList[0];
                                                //    premiums.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsNoHair);
                                                //    premiums.IsSingleRow = false;
                                                //    premiums.IsEvaluation = false;
                                                //    premiums.EvaluationID = null;
                                                //    premiums.EvaluationDate = null;
                                                //    premiums.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                                                //    premiums.ManagerPeople = null;
                                                //    premiums.ManagerTime = null;
                                                //    premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                                //    premiums.UpdateTime = DateTime.Now;
                                                //    base.XMPremiumsService.UpdateXMPremiums(premiums);
                                                //    if (premiums != null)
                                                //    {
                                                //        var xMPremiumsDetail = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(premiums.Id);
                                                //        if (xMPremiumsDetail != null && xMPremiumsDetail.Count > 0)
                                                //        {
                                                //            foreach (var parm in xMPremiumsDetail)
                                                //            {
                                                //                parm.IsSingleRow = false;
                                                //                parm.UpdateDate = DateTime.Now;
                                                //                parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                //                base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(parm);
                                                //            }
                                                //        }
                                                //    }
                                                //}
                                                #endregion

                                                //明细 Id 
                                                List<int> DeliveryIdList = DeliveryDetailsList.Select(a => a.Id).ToList();
                                                //删除发货单明细数据
                                                base.XMDeliveryDetailsService.BatchDeleteXMDeliveryDetails(DeliveryIdList);
                                                //删除发货单主表信息 
                                                base.XMDeliveryService.DeleteXMDelivery(Delivery.Id);
                                            }

                                            #region 修改赠品中发票对应的发票管理的状态

                                            var InvoiceInfoIDs = DeliveryDetailsList.Where(x => x.InvoiceInfoID != null).Select(x => x.InvoiceInfoID).ToList();
                                            if (InvoiceInfoIDs != null && InvoiceInfoIDs.Count > 0)
                                            {
                                                foreach (var id in InvoiceInfoIDs)
                                                {
                                                    var InvoiceInfo = base.XMInvoiceInfoService.GetXMInvoiceInfoByID((int)id);
                                                    if (InvoiceInfo != null)
                                                    {
                                                        InvoiceInfo.IsSingleRow = false;
                                                        InvoiceInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                        InvoiceInfo.UpdateDate = DateTime.Now;
                                                        base.XMInvoiceInfoService.UpdateXMInvoiceInfo(InvoiceInfo);
                                                    }
                                                }
                                            }

                                            #endregion

                                            #endregion
                                        }
                                        //返回多个订单号
                                        else if (CodeNODistinct.Count > 1)
                                        {
                                            paramMessage = "该发货单有多个订单号,请先拆分再重新排单！";
                                            //base.ShowMessage(paramMessage);
                                            Ext.Net.ExtNet.Msg.Alert("提示", paramMessage).Show();
                                            return;
                                        }
                                    }
                                    //}
                                    //已发货
                                    //else
                                    //{
                                    //    paramMessage = "请选择未发货的发货单！";
                                    //    //base.ShowMessage(paramMessage);
                                    //    Ext.Net.ExtNet.Msg.Alert("提示", paramMessage).Show();
                                    //    return;
                                    //}
                                }
                                #endregion
                            }
                            else if (Delivery.DeliveryTypeId == 722)
                            {
                                //根据主表Id 查询明细数据
                                var DeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(Delivery.Id);

                                //判断发货明细中的 商品信息是否类型相同  
                                var DetailsTypeIdListGroupBy = DeliveryDetailsList.GroupBy(p => p.DetailsTypeId.Value).Select(g => g.First()).ToList();//根据类型分组
                                if (DetailsTypeIdListGroupBy.Count > 1)//明细类型不一致 不可重新排单
                                {
                                    paramMessage = "该发货单明细类型不一致,请先拆分再重新排单。";
                                    //base.ShowMessage(paramMessage);
                                    Ext.Net.ExtNet.Msg.Alert("提示", paramMessage).Show();
                                    return;
                                }

                                var InvoiceInfoIDs = DeliveryDetailsList.Where(x => x.InvoiceInfoID != null).Select(x => x.InvoiceInfoID).ToList();
                                if (InvoiceInfoIDs != null && InvoiceInfoIDs.Count > 0)
                                {
                                    foreach (var id in InvoiceInfoIDs)
                                    {
                                        var InvoiceInfo = base.XMInvoiceInfoService.GetXMInvoiceInfoByID((int)id);
                                        if (InvoiceInfo != null)
                                        {
                                            InvoiceInfo.IsSingleRow = false;
                                            InvoiceInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            InvoiceInfo.UpdateDate = DateTime.Now;
                                            base.XMInvoiceInfoService.UpdateXMInvoiceInfo(InvoiceInfo);
                                        }
                                    }
                                    //删除发货信息
                                    Delivery.IsEnabled = true;
                                    Delivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                    Delivery.UpdateDate = DateTime.Now;
                                    base.XMDeliveryService.UpdateXMDelivery(Delivery);
                                    paramMessage = "操作成功！";
                                }
                            }

                            //if(OrderInfo!=null&&OrderInfo.ProjectId!=2)
                            //{
                            //    //删除对应的出库单记录（状态为待出库状态）
                            //    var saleDeliveries = base.XMSaleDeliveryService.GetXMSaleDeliveryListByParm(Delivery.Id);

                            //    if (saleDeliveries != null && saleDeliveries.Count > 0)
                            //    {
                            //        foreach (XMSaleDelivery parm in saleDeliveries)
                            //        {
                            //            parm.IsEnable = true;
                            //            parm.UpdateDate = DateTime.Now;
                            //            parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                            //            base.XMSaleDeliveryService.UpdateXMSaleDelivery(parm);
                            //            var saleDeliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(parm.Id);
                            //            if (saleDeliveryProductDetails != null && saleDeliveryProductDetails.Count > 0)
                            //            {
                            //                foreach (XMSaleDeliveryProductDetails p in saleDeliveryProductDetails)
                            //                {
                            //                    p.IsEnable = true;
                            //                    p.UpdateDate = DateTime.Now;
                            //                    p.UpdateID = HozestERPContext.Current.User.CustomerID;
                            //                    //string code = p.PlatformMerchantCode;              //商品编码
                            //                    //int wfID = parm.WareHouseId;                              //出库仓库ID
                            //                    //var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(code, wfID);
                            //                    //if (InventoryInfo != null)                             //商品编码为code的产品在库存表中已经存在 更新库存数量
                            //                    //{
                            //                    //    InventoryInfo.StockNumber = InventoryInfo.StockNumber + p.SaleCount;             //库存加上出库量
                            //                    //    InventoryInfo.CanOrderCount = InventoryInfo.CanOrderCount+ p.SaleCount;    //可订购数量在上面已经增加
                            //                    //    InventoryInfo.UpdateDate = DateTime.Now;
                            //                    //    InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            //                    //    base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);
                            //                    //}
                            //                    base.XMSaleDeliveryProductDetailsService.UpdateXMSaleDeliveryProductDetails(p);
                            //                }
                            //            }
                            //        }
                            //    }
                            //    else
                            //    {
                            //        throw new Exception("找不到对应出库单记录！");
                            //    }
                            //}


                        }

                        scope.Complete();

                        //this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                        //if (paramMessage != "")
                        //{
                        //    //base.ShowMessage(paramMessage);
                        //    Ext.Net.ExtNet.Msg.Alert("提示", paramMessage).Show();
                        //}
                    }

                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

                    if (!string.IsNullOrEmpty(paramMessage))
                    {
                        Ext.Net.ExtNet.Msg.Alert("提示", paramMessage).Show();
                    }
                    else
                    {
                        Ext.Net.ExtNet.Msg.Alert("提示", "重新排单成功").Show();
                    }
                    #endregion

                }
            }
            catch(Exception ex)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", ex.Message).Show();
            }
        }


        /// <summary>
        /// 订单拆分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cell_button_2_click(object sender, Ext.Net.DirectEventArgs e)
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<XMDeliveryDetails> list = Serializer.Deserialize<List<XMDeliveryDetails>>(data);
            if (list.Count <= 0)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录!").Show();
            }
            else
            {
                #region 订单拆分逻辑
                //List<int> DeliveryDetailsIDs = this.Master.GetSelectedIds(Bgrid);
                List<int> DeliveryDetailsIDs = new List<int>();
                foreach (XMDeliveryDetails entity in list)
                {
                    DeliveryDetailsIDs.Add(entity.Id);
                }
                if (DeliveryDetailsIDs.Count <= 0)
                {
                    //base.ShowMessage("你没有选择任何记录");
                    Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录!").Show();
                    return;
                }
                else
                {
                    //事务
                    using (TransactionScope scope = new TransactionScope())
                    {
                        //选中的明细数据
                        var xmDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsById(DeliveryDetailsIDs);

                        //根据Id查询 发货单信息
                        HozestERP.BusinessLogic.ManageProject.XMDelivery Delivery = new BusinessLogic.ManageProject.XMDelivery();

                        //发货单明细 (选中的明细数据)
                        XMDeliveryDetails xMDeliveryDetails = null;

                        string OrderNo = "";
                        int DetailsTypeId = 0;
                        int ProductlId = 0;
                        string PlatformMerchantCode = "";
                        string PrdouctName = "";
                        string Specifications = "";
                        int ProductNum = 0;
                        int WarehouseID = 0;
                        int? sourceID = 0;

                        #region
                        if (xmDeliveryDetailsList.Count > 0)
                        {
                            //根据明细主表DeliveryId 查询主表信息
                            Delivery = base.XMDeliveryService.GetXMDeliveryById(xmDeliveryDetailsList[0].DeliveryId.Value);

                            if((bool)Delivery.IsDelivery)
                            {
                                Ext.Net.ExtNet.Msg.Alert("提示", "已发货，不允许操作！").Show();
                                return;
                            }

                            //根据主表Id查询产品记录
                            var XMDeliveryDetailsByDeliveryIdList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(xmDeliveryDetailsList[0].DeliveryId.Value);
                            //当前已选发货单有多条产品明细
                            if (XMDeliveryDetailsByDeliveryIdList.Count > 1)
                            {
                                #region 多条产品信息 拆分

                                #region 新增发货单信息
                                HozestERP.BusinessLogic.ManageProject.XMDelivery xd = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
                                if (Delivery != null)
                                {
                                    //新增
                                    #region 生成发货单
                                    //xd.DeliveryTypeId = Delivery.DeliveryTypeId;//使用原发货单主表的 发货单类型
                                    if(xmDeliveryDetailsList.Where(a=>a.DetailsTypeId==13).Count()>0)
                                    {
                                        xd.DeliveryTypeId = 480;
                                    }
                                    else if(xmDeliveryDetailsList.Where(a => a.DetailsTypeId == 10).Count()>0)
                                    {
                                        xd.DeliveryTypeId = 708;
                                    }
                                    else if(xmDeliveryDetailsList.Where(a => a.DetailsTypeId == 14).Count() > 0)
                                    {
                                        xd.DeliveryTypeId = 708;
                                    }
                                    else if(xmDeliveryDetailsList.Where(a => a.DetailsTypeId == 11).Count()>0)
                                    {
                                        xd.DeliveryTypeId = 481;
                                    }
                                    else if(xmDeliveryDetailsList.Where(a => a.DetailsTypeId == 15).Count() > 0)
                                    {
                                        xd.DeliveryTypeId = 722;
                                    }
                                    else
                                    {
                                        xd.DeliveryTypeId = Delivery.DeliveryTypeId;//使用原发货单主表的 发货单类型
                                    }

                                    if (Delivery.DeliveryTypeId.Value == 481)
                                    {
                                        xd.DeliveryNumber = "ZP" + DateTime.Now.ToString("yyyyMMddHHmmssfff");//赠品发货单号（自动生成）
                                    }
                                    else
                                    {
                                        xd.DeliveryNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");//订单发货单号（自动生成）
                                    }
                                    xd.OrderCode = Delivery.OrderCode;////使用原发货单主表的 订单号
                                    xd.Shipper = Delivery.Shipper;

                                    xd.FullName = Delivery.FullName;
                                    xd.Mobile = Delivery.Mobile;
                                    xd.Tel = Delivery.Tel;
                                    xd.Province = Delivery.Province;
                                    xd.City = Delivery.City;
                                    xd.County = Delivery.County;
                                    xd.DeliveryAddress = Delivery.DeliveryAddress;

                                    xd.Price = 0;//运费
                                    xd.IsDelivery = false;//是否发货
                                    xd.IsEnabled = false;
                                    xd.CreateId = HozestERPContext.Current.User.CustomerID;
                                    xd.CreateDate = DateTime.Now;
                                    xd.UpdateId = HozestERPContext.Current.User.CustomerID;
                                    xd.UpdateDate = DateTime.Now;
                                    xd.PrintQuantity = 0;//打印次数
                                    xd.PrintBatch = 0;//打印批次
                                    base.XMDeliveryService.InsertXMDelivery(xd);
                                    #endregion
                                }
                                #endregion

                                for (int i = 0; i < xmDeliveryDetailsList.Count; i++)
                                {
                                    xMDeliveryDetails = xmDeliveryDetailsList[i];

                                    OrderNo = xMDeliveryDetails.OrderNo;
                                    DetailsTypeId = xMDeliveryDetails.DetailsTypeId.Value;
                                    ProductlId = xMDeliveryDetails.ProductlId.Value;
                                    PlatformMerchantCode = xMDeliveryDetails.PlatformMerchantCode;
                                    PrdouctName = xMDeliveryDetails.PrdouctName;
                                    Specifications = xMDeliveryDetails.Specifications;
                                    ProductNum = xMDeliveryDetails.ProductNum.Value;
                                    WarehouseID = xMDeliveryDetails.WarehouseID == null ? 0 : xMDeliveryDetails.WarehouseID.Value;
                                    sourceID = xMDeliveryDetails.SourceID;

                                    #region 新增发货单明细
                                    if (xd != null)//发货单记录 不未空
                                    {
                                        if (xd.Id != 0)
                                        {
                                            XMDeliveryDetails xmDeliveryDetails = new XMDeliveryDetails();
                                            xmDeliveryDetails.DeliveryId = xd.Id;
                                            xmDeliveryDetails.OrderNo = OrderNo;
                                            xmDeliveryDetails.DetailsTypeId = DetailsTypeId;
                                            xmDeliveryDetails.ProductlId = ProductlId;
                                            xmDeliveryDetails.PlatformMerchantCode = PlatformMerchantCode;
                                            xmDeliveryDetails.PrdouctName = PrdouctName;
                                            xmDeliveryDetails.Specifications = Specifications;
                                            xmDeliveryDetails.ProductNum = ProductNum;
                                            xmDeliveryDetails.WarehouseID = WarehouseID;
                                            xmDeliveryDetails.SourceID = sourceID;
                                            xmDeliveryDetails.IsEnabled = false;
                                            xmDeliveryDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                            xmDeliveryDetails.CreateDate = DateTime.Now;
                                            xmDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            xmDeliveryDetails.UpdateDate = DateTime.Now;
                                            base.XMDeliveryDetailsService.InsertXMDeliveryDetails(xmDeliveryDetails);

                                        }
                                    }
                                    #endregion

                                    #region  删除 原发货订单明细
                                    if (xMDeliveryDetails != null)
                                    {
                                        //xMDeliveryDetails.IsEnabled = true;
                                        //xMDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        //xMDeliveryDetails.UpdateDate = DateTime.Now;
                                        base.XMDeliveryDetailsService.DeleteXMDeliveryDetails(xMDeliveryDetails.Id);

                                        //重新给属性 赋空值
                                        OrderNo = "";
                                        DetailsTypeId = 0;
                                        ProductlId = 0;
                                        PlatformMerchantCode = "";
                                        PrdouctName = "";
                                        Specifications = "";
                                        ProductNum = 0;
                                        WarehouseID = 0;
                                        sourceID = 0;
                                    }
                                    #endregion

                                }

                                var DeliveryDetailsList = XMDeliveryDetailsByDeliveryIdList.Where(a => !DeliveryDetailsIDs.Contains(a.Id)).ToList();
                                if (DeliveryDetailsList.Count()>0)
                                {
                                    if (DeliveryDetailsList.Where(a => a.DetailsTypeId == 13).Count() > 0)
                                    {
                                        Delivery.DeliveryTypeId = 480;
                                    }
                                    else if (DeliveryDetailsList.Where(a => a.DetailsTypeId == 10).Count() > 0)
                                    {
                                        Delivery.DeliveryTypeId = 708;
                                    }
                                    else if (xmDeliveryDetailsList.Where(a => a.DetailsTypeId == 14).Count() > 0)
                                    {
                                        xd.DeliveryTypeId = 708;
                                    }
                                    else if (DeliveryDetailsList.Where(a => a.DetailsTypeId == 11).Count() > 0)
                                    {
                                        Delivery.DeliveryTypeId = 481;
                                    }
                                    else if (xmDeliveryDetailsList.Where(a => a.DetailsTypeId == 15).Count() > 0)
                                    {
                                        xd.DeliveryTypeId = 722;
                                    }
                                    else
                                    {
                                        Delivery.DeliveryTypeId = Delivery.DeliveryTypeId;//使用原发货单主表的 发货单类型
                                    }
                                    XMDeliveryService.UpdateXMDelivery(Delivery);
                                }
                                #endregion
                            }
                            else//已选发货单 只有一条产品明细
                            {
                                int ProductNumSum = xmDeliveryDetailsList.Select(p => p.ProductNum == null ? 0 : p.ProductNum.Value).Sum();

                                if (ProductNumSum > 1)
                                {

                                    #region 单条产品信息 拆分 （拆分数量）

                                    #region 新增发货单信息
                                    HozestERP.BusinessLogic.ManageProject.XMDelivery xd = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
                                    if (Delivery != null)
                                    {
                                        //新增
                                        #region 生成发货单
                                        //xd.DeliveryTypeId = Delivery.DeliveryTypeId;//使用原发货单主表的 发货单类型
                                        if (xmDeliveryDetailsList.Where(a => a.DetailsTypeId == 13).Count() > 0)
                                        {
                                            xd.DeliveryTypeId = 480;
                                        }
                                        else if (xmDeliveryDetailsList.Where(a => a.DetailsTypeId == 10).Count() > 0)
                                        {
                                            xd.DeliveryTypeId = 708;
                                        }
                                        else if (xmDeliveryDetailsList.Where(a => a.DetailsTypeId == 14).Count() > 0)
                                        {
                                            xd.DeliveryTypeId = 708;
                                        }
                                        else if (xmDeliveryDetailsList.Where(a => a.DetailsTypeId == 11).Count() > 0)
                                        {
                                            xd.DeliveryTypeId = 481;
                                        }
                                        else if (xmDeliveryDetailsList.Where(a => a.DetailsTypeId == 15).Count() > 0)
                                        {
                                            xd.DeliveryTypeId = 722;
                                        }
                                        else
                                        {
                                            xd.DeliveryTypeId = Delivery.DeliveryTypeId;//使用原发货单主表的 发货单类型
                                        }

                                        if (Delivery.DeliveryTypeId.Value == 481)
                                        {
                                            xd.DeliveryNumber = "ZP" + DateTime.Now.ToString("yyyyMMddHHmmssfff");//赠品发货单号（自动生成）
                                        }
                                        else
                                        {
                                            xd.DeliveryNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");//订单发货单号（自动生成）
                                        }
                                        xd.OrderCode = Delivery.OrderCode;////使用原发货单主表的 订单号
                                        xd.Shipper = Delivery.Shipper;

                                        xd.FullName = Delivery.FullName;
                                        xd.Mobile = Delivery.Mobile;
                                        xd.Tel = Delivery.Tel;
                                        xd.Province = Delivery.Province;
                                        xd.City = Delivery.City;
                                        xd.County = Delivery.County;
                                        xd.DeliveryAddress = Delivery.DeliveryAddress;

                                        xd.Price = 0;//运费
                                        xd.IsDelivery = false;//是否发货
                                        xd.IsEnabled = false;
                                        xd.CreateId = HozestERPContext.Current.User.CustomerID;
                                        xd.CreateDate = DateTime.Now;
                                        xd.UpdateId = HozestERPContext.Current.User.CustomerID;
                                        xd.UpdateDate = DateTime.Now;
                                        xd.PrintQuantity = 0;//打印次数
                                        xd.PrintBatch = 0;//打印批次
                                        base.XMDeliveryService.InsertXMDelivery(xd);
                                        #endregion
                                    }
                                    #endregion

                                    for (int i = 0; i < 1; i++)
                                    {
                                        xMDeliveryDetails = xmDeliveryDetailsList[0];
                                        OrderNo = xMDeliveryDetails.OrderNo;
                                        DetailsTypeId = xMDeliveryDetails.DetailsTypeId.Value;
                                        ProductlId = xMDeliveryDetails.ProductlId.Value;
                                        PlatformMerchantCode = xMDeliveryDetails.PlatformMerchantCode;
                                        PrdouctName = xMDeliveryDetails.PrdouctName;
                                        Specifications = xMDeliveryDetails.Specifications;
                                        //ProductNum = xMDeliveryDetails.ProductNum.Value;
                                        WarehouseID = xMDeliveryDetails.WarehouseID.Value;
                                        sourceID = xMDeliveryDetails.SourceID;

                                        if (ProductlId > 0 && PlatformMerchantCode != "" && PrdouctName != "" && Specifications != "")
                                        {
                                            #region 新增发货单明细
                                            if (xd != null)//发货单记录 不未空
                                            {
                                                if (xd.Id != 0)
                                                {
                                                    XMDeliveryDetails xmDeliveryDetails = new XMDeliveryDetails();
                                                    xmDeliveryDetails.DeliveryId = xd.Id;
                                                    xmDeliveryDetails.OrderNo = OrderNo;
                                                    xmDeliveryDetails.DetailsTypeId = DetailsTypeId;
                                                    xmDeliveryDetails.ProductlId = ProductlId;
                                                    xmDeliveryDetails.PlatformMerchantCode = PlatformMerchantCode;
                                                    xmDeliveryDetails.PrdouctName = PrdouctName;
                                                    xmDeliveryDetails.Specifications = Specifications;
                                                    xmDeliveryDetails.ProductNum = 1;
                                                    xmDeliveryDetails.WarehouseID = WarehouseID;
                                                    xmDeliveryDetails.SourceID = sourceID;
                                                    xmDeliveryDetails.IsEnabled = false;
                                                    xmDeliveryDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                                    xmDeliveryDetails.CreateDate = DateTime.Now;
                                                    xmDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                    xmDeliveryDetails.UpdateDate = DateTime.Now;
                                                    base.XMDeliveryDetailsService.InsertXMDeliveryDetails(xmDeliveryDetails);

                                                }
                                            }
                                            #endregion

                                            #region  修改 原产品信息数量
                                            if (xMDeliveryDetails != null)
                                            {
                                                //原产品数量
                                                int ProductNumOld = xMDeliveryDetails.ProductNum.Value - 1;
                                                xMDeliveryDetails.ProductNum = ProductNumOld;
                                                xMDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                xMDeliveryDetails.UpdateDate = DateTime.Now;
                                                base.XMDeliveryDetailsService.UpdateXMDeliveryDetails(xMDeliveryDetails);

                                                //重新给属性 赋空值
                                                OrderNo = "";
                                                DetailsTypeId = 0;
                                                ProductlId = 0;
                                                PlatformMerchantCode = "";
                                                PrdouctName = "";
                                                Specifications = "";
                                                ProductNum = 0;
                                                WarehouseID = 0;
                                                sourceID = 0;
                                            }
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    //base.ShowMessage("已选产品不可拆分！");
                                    Ext.Net.ExtNet.Msg.Alert("提示", "已选产品不可拆分！").Show();
                                    return;
                                }
                            }
                        }
                        #endregion

                        //base.ShowMessage("保存成功！");
                        Ext.Net.ExtNet.Msg.Alert("提示", "保存成功！").Show();
                        this.BindGrid(Master.PageIndex, Master.PageSize);
                        //int strProductNum = 0;
                        //List<XMDeliveryDetails> xMDeliveryDetailsList= base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId((int)list[0].DeliveryId);
                        //if (xMDeliveryDetailsList != null && xMDeliveryDetailsList.Count > 0)
                        //{
                        //    strProductNum += (int)xMDeliveryDetailsList.Sum(x => x.ProductNum);
                        //}

                        //Ext.Net.Store Store = Store2;
                        //Store.DataSource = xMDeliveryDetailsList;
                        //Store.DataBind();

                        //if (xMDeliveryDetailsList.Count > 1 || strProductNum > 1)
                        //{
                        //    cell_button_2.Hidden = false;
                        //}
                        //else
                        //{
                        //    cell_button_2.Hidden = true;
                        //}
                        scope.Complete();
                    }
                }
                #endregion
            }
        }

        private void GridPanelBind()
        {
            if (XMDeliveryNewList != null)
            {
                Ext.Net.Store Store1 = GridPaneltest.GetStore();
                Store1.DataSource = XMDeliveryNewList;
                Store1.DataBind();
            }
        }

        /// <summary>
        /// 导出发货单(EXT.NET)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PostExport_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            try
            {
                if (this.ddXMProject.Value.ToString() != "-1")
                {
                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\PostListExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                    string logisticsNumber = this.txtLogisticsNumber.Text.Trim();     //物流单号
                    string ordercode = this.txtOrderCode.Text.Trim();//订单编号
                    string manufacturersCode = this.txtManufacturersCode1.Text.Trim();//厂家编号
                    string deliverynumber = this.txtDeliveryNumber.Text.Trim();//物流单号 
                    int ddPrintQuantity = Convert.ToInt32(this.ddPrintQuantity.SelectedValue);//是否打印 
                    int ddDeliveryTypeId = Convert.ToInt32(this.ddDeliveryTypeId.SelectedValue);//发货单类型
                    string ddlShipper = this.ddlShipper.SelectedValue;//发货方
                    string txtFullName = this.txtFullName.Text.Trim();//收货人姓名
                    string txtMobileAndTel = this.txtMobileAndTel.Text.Trim();//电话
                    string txtDeliveryAddress = this.txtDeliveryAddress.Text.Trim();//收货地址
                    string PrintBatch = this.txtPrintBatch.Text.Trim();//打印批次
                    int ddXMProject = -1;
                    if (this.ddXMProject.Value.ToString() != "")
                        ddXMProject = Convert.ToInt32(this.ddXMProject.Value.ToString().Trim());
                    int ddlNick = Convert.ToInt32(this.ddlNick.Value.ToString());//店铺
                    string nickids = "";//店铺
                    if (ddlNick == 99) //某个项目店铺权限，选择有权限的店铺
                    {
                        var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", -1, ddXMProject, HozestERPContext.Current.User.CustomerID, 0);
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
                        nickids = ddlNick.ToString();
                    }
                    int isPrint = int.Parse(cbIsPrint.Value.ToString());
                    bool packageCheck = chkpackage.Checked;//单礼包
                    string logisticsCompany = txtLogisticsCompany.Text.Trim();      //物流公司
                    string PrintBegin = this.txtPrintBegin.Value.Trim();//打印开始时间
                    string PrintEnd = this.txtPrintEnd.Value.Trim();//打印结束时间
                    string CreateBegin = this.txtCreateDateBegin.Value.Trim();//创单开始时间
                    string CreateEnd = this.txtCreateDateEnd.Value.Trim();//创单结束时间
                    int IsShelve = int.Parse(this.ddlIsShelve.SelectedValue);//是否挂起
                    bool NoOrder = this.chkNoOrder.Checked;//无订单号发货单
                    string verificationStatus = this.ddVerification.SelectedValue;//选择的发货单状态
                    //是否发货
                    int ddIsDelivery = Convert.ToInt32(this.ddIsDelivery.SelectedValue.Trim());
                    //项目名称
                    //int ddXMProject = -1;
                    //if (!string.IsNullOrEmpty(this.ddXMProject.Value.ToString()))
                    //    ddXMProject = Convert.ToInt32(this.ddXMProject.Value.ToString().Trim());

                    if ((PrintBegin != "" && PrintEnd == "") || (PrintBegin == "" && PrintEnd != ""))
                    {
                        //base.ShowMessage("打印开始，结束时间必须同时存在！");
                        Ext.Net.ExtNet.Msg.Alert("提示", "打印开始，结束时间必须同时存在！").Show();
                        return;
                    }

                    if ((CreateBegin != "" && CreateEnd == "") || (CreateBegin == "" && CreateEnd != ""))
                    {
                        //base.ShowMessage("创单开始，结束时间必须同时存在！");
                        Ext.Net.ExtNet.Msg.Alert("提示", "创单开始，结束时间必须同时存在！").Show();
                        return;
                    }

                    /*var DeliveryList = base.XMDeliveryService.GetXMDeliveryExportList(logisticsNumber, ordercode, manufacturersCode, deliverynumber, ddPrintQuantity, ddDeliveryTypeId
                        , txtFullName, txtMobileAndTel, txtDeliveryAddress, ddIsDelivery, ddXMProject, PrintBatch, int.Parse(ddlShipper), Nick, PrintBegin, PrintEnd
                        , CreateBegin, CreateEnd, IsShelve, NoOrder);//查询物流单list*/

                    var DeliveryList = base.XMDeliveryService.GetXMDeliverySearchList(logisticsNumber, ordercode, manufacturersCode, deliverynumber, ddPrintQuantity, ddDeliveryTypeId
             , txtFullName, txtMobileAndTel, txtDeliveryAddress, ddIsDelivery, ddXMProject, PrintBatch, int.Parse(ddlShipper), nickids, PrintBegin, PrintEnd
             , CreateBegin, CreateEnd, IsShelve, NoOrder, isPrint,verificationStatus, packageCheck, logisticsCompany);//查询物流单list
                    var task = System.Threading.Tasks.Task.Factory.StartNew(()=> {
                        setPrintDateTime(DeliveryList);
                    });
                   

                    DataTable exceldb = new DataTable();
                    if (ddXMProject == 26)//迪士尼
                    {
                        exceldb = base.ExportManager.ExportPostListFromNSN(DeliveryList);
                        //base.ExportManager.ExportPostListFromNSN(filePath, DeliveryList);
                    }
                    else if (ddXMProject == 25)//智曼
                    {
                        exceldb = base.ExportManager.ExportPostListFromZM(DeliveryList);
                        //base.ExportManager.ExportPostListFromZM(filePath, DeliveryList);
                    }
                    else if (ddXMProject == 5)//曲美
                    {
                        exceldb = base.ExportManager.ExportPostListFromQM(DeliveryList);
                        //base.ExportManager.ExportPostListFromQM(filePath, DeliveryList);
                    }
                    else if (ddXMProject == 22)//伊丽丝
                    {
                        exceldb = base.ExportManager.ExportPostListFromLYS(DeliveryList);
                        //base.ExportManager.ExportPostListFromLYS(filePath, DeliveryList);
                    }

                    else
                    {
                        //base.ExportManager.ExportPostList(filePath, DeliveryList);
                        exceldb = base.ExportManager.ExportPostList(DeliveryList);

                    }
                    task.Wait();
                    NPOIHelper.NPOIExcelHepler.ExportExcel(filePath, fileName, exceldb);

                    //CommonHelper.WriteResponseXls(filePath, fileName);
                }
                else
                {
                    Ext.Net.ExtNet.Msg.Alert("提示", "请选择项目名称").Show();
                    //base.ShowMessage("请选择项目名称！");
                    //GridPanelBind();
                }
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }
        /// <summary>
        /// 打印时间没有的发货单号赋值当前时间并保存
        /// </summary>
        /// <param name="DeliveryList"></param>
        public void setPrintDateTime(List<XMDeliveryNew> DeliveryList)
        {
            var DeliveryIDList = new List<int>();
            foreach (var elem in DeliveryList)
            {
                if (elem.PrintDateTime == null)
                {
                    DeliveryIDList.Add(elem.Id);
                }
            }
            var updateDelivery = base.XMDeliveryService.GetXMDeliveryByListIds(DeliveryIDList);
            foreach (var elem in updateDelivery)
            {
                elem.PrintDateTime = DateTime.Now;
            }
            base.XMDeliveryService.UpdateXMDelivery(updateDelivery);
        }
     
        /// <summary>
        /// 批量打印运单(有点问题)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void pldyyd_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            //List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);
            List<int> customerInfoIDs = new List<int>();

            Ext.Net.RowSelectionModel sm = GridPaneltest.SelectionModel.Primary as Ext.Net.RowSelectionModel;

            foreach (Ext.Net.SelectedRow item in sm.SelectedRows)
            {
                customerInfoIDs.Add(int.Parse(item.RecordID));
            }

            if (customerInfoIDs.Count <= 0)
            {
                //base.ShowMessage("你没有选择任何记录");
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录").Show();
                return;
            }
            else
            {
                //string ids = "";//订单ids
                //foreach (GridViewRow row in grdvClients.Rows)
                //{
                //    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                //    if (chkSelected.Checked)
                //    {
                //        int DeliveryID = 0;
                //        int.TryParse(this.grdvClients.DataKeys[row.RowIndex].Value.ToString(), out DeliveryID);

                //        var deliveryinfo = base.XMDeliveryService.GetXMDeliveryById(DeliveryID);
                //        if (deliveryinfo.OrderCode != null && deliveryinfo.OrderCode != "")
                //        {
                //            var orderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(deliveryinfo.OrderCode);//订单信息
                //            if (orderinfo != null)
                //            {
                //                if (ids != "")
                //                    ids += ",";
                //                ids += orderinfo.ID;
                //            }
                //        }

                //    }
                //}

                //发货单Id
                string deliveryId = string.Join(",", customerInfoIDs);

                string strdiqu = "STO";

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "openscript_yd", "window.open('dyYD.aspx?kd=" + strdiqu
                    + "&ids=" + deliveryId
                    + "&PrintTypeId=Delivery"
                    + "','批量打印运单', 'height=900, width=870, top=0, left=0, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=n o, status=no');", true);
            }
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="paraSign"></param>
        /// <param name="paramWantId"></param>
        /// <param name="paramMobile"></param>
        /// <param name="paramLogisticsName"></param>
        /// <param name="paramLogisticsNumber"></param>
        /// <param name="paramContent"></param>
        /// <returns></returns>
        public bool UseSensSms(string paraSign, string paramWantId, string paramMobile, string paramLogisticsName, string paramLogisticsNumber, string paramContent) 
        {
            bool SensSuss = false;
            HozestERP.Web.SmsServiceReference.SmsServicesClient UseSmsServicesClient = new SmsServicesClient();
            HozestERP.Web.SmsServiceReference.smsResult UsesmsResult = UseSmsServicesClient.sendSms("bjanyx3_v2", "666666", paramWantId + "亲，您的包裹：" + paramContent + "已由" + paramLogisticsName + "发出，快递单号：" + paramLogisticsNumber, paraSign, paramMobile, "");
            int paranReturn = UsesmsResult.result;
            if (paranReturn == 0) 
            {
                SensSuss = true;
            }
            return SensSuss;
        }

        /// <summary>
        /// 批量发货(EXT.NET)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BulkShipments_click1(object sender, Ext.Net.DirectEventArgs e)
        {
            try
            {
                string paramSign="";//项目名称
                string paramWantId = "";//网名
                string paramMobile ="";//接收手机
                string paramLogisticsName ="";//快递名称
                string paramLogisticsNumber="";//物流单号
                string paramContent="";//包裹内容
                int paramMDeliveryDype = 0;
                int count = 0;
                string sensreturn = "";
                //查询 appkey、appSecret、sessionKey
                var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();
                XMOrderInfoApp xMorderInfoApp = new XMOrderInfoApp();//appkey、appSecret、sessionKey

                string data = e.ExtraParams["data"];
                System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<XMDeliveryNew> list = Serializer.Deserialize<List<XMDeliveryNew>>(data);

                //List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);

                if (list.Count <= 0)
                {
                    //base.ShowMessage("你没有选择任何记录");
                    Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录").Show();
                    return;
                }
                else
                {
                    //事务
                    using (TransactionScope scope = new TransactionScope())
                    {
                        foreach (XMDeliveryNew entity in list)
                        {
                            bool DeliverySess = false;

                            //根据Id 查询 发货单
                            var xMDelivery = base.XMDeliveryService.GetXMDeliveryById(entity.Id);

                            if(xMDelivery.IsDelivery==true)
                            {
                                throw new Exception("发货单："+ xMDelivery .DeliveryNumber+"已经发货！");
                            }

                            //根据选中的行数据 Id 管理发货单明细 
                            var XMDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsMappingSearchList(Convert.ToInt32(entity.Id));

                            if (XMDeliveryDetailsList.Count > 0 && xMDelivery != null)
                            {
                                var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(XMDeliveryDetailsList[0].OrderNo);

                                if (xMOrderInfo.Count > 0)
                                {
                                    #region 判断是否是赠品
                                    bool IsPremiums = false;
                                    var product = base.XMProductService.getXMProductListByPlatformMerchantCode(XMDeliveryDetailsList[0].PlatformMerchantCode);
                                    if (product != null && product.Count > 0)
                                    {
                                        IsPremiums = product[0].IsPremiums.GetValueOrDefault(false);
                                    }
                                    #endregion
                                    //var XMOrderInfoAppOne = XMOrderInfoAppList.Where(p => p.PlatformTypeId == xMOrderInfo[0].PlatformTypeId).Where(s => s.NickId == xMOrderInfo[0].NickID);
                                    //if (XMOrderInfoAppOne.Count() > 0 || xMOrderInfo[0].PlatformTypeId == 376 || xMOrderInfo[0].PlatformTypeId == 765 || xMOrderInfo[0].PlatformTypeId == 767
                                    //            || xMOrderInfo[0].PlatformTypeId == 769)
                                    //{
                                    //判断物流单号 ，物流公司 不为空
                                    if (XMDeliveryDetailsList[0].LogisticsNumber != "" && XMDeliveryDetailsList[0].LogisticsNumber != null && XMDeliveryDetailsList[0].LogisticsId != null)
                                        {
                                            paramLogisticsName=xMDelivery.ExpressName;
                                            paramLogisticsNumber=xMDelivery.LogisticsNumber;
                                            paramSign=xMDelivery.NickName;
                                            paramWantId=xMDelivery.WantID;
                                            paramMobile = xMDelivery.Mobile;
                                            paramMDeliveryDype = int.Parse(xMDelivery.DeliveryTypeId.ToString());
                                        if (xMDelivery.IsDelivery == true )//判断发货单的发货状态
                                        {
                                            throw new Exception("操作失败！订单号：" + XMDeliveryDetailsList[0].OrderNo + " 已经发货不允许多次发货！");
                                        }
                                            

                                        if (xMOrderInfo[0].PlatformTypeId == 250)
                                        {
                                            if(!IsPremiums)
                                                xMOrderInfo[0].DeliveryTime = Convert.ToDateTime(DateTime.Now);//修改出库时间
                                            xMOrderInfo[0].OrderStatus = "WAIT_GOODS_RECEIVE_CONFIRM";
                                            xMOrderInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                            xMOrderInfo[0].UpdateDate = DateTime.Now;
                                            base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo[0]);

                                            //修改发货单 是否发货状态
                                            xMDelivery.IsDelivery = true;//已发货
                                            xMDelivery.UpdateDate = DateTime.Now;
                                            xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                            base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
                                            DeliverySess = true;//发货单发货成功
                                            count++;
                                        }
                                        else if(xMOrderInfo[0].PlatformTypeId == 251)
                                        {
                                            if (!IsPremiums)
                                                xMOrderInfo[0].DeliveryTime = DateTime.Now;//修改出库时间
                                            xMOrderInfo[0].OrderStatus = "WAIT_GOODS_RECEIVE_CONFIRM";
                                            xMOrderInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                            xMOrderInfo[0].UpdateDate = DateTime.Now;
                                            base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo[0]);

                                            //修改发货单 是否发货状态
                                            xMDelivery.IsDelivery = true;//已发货
                                            xMDelivery.UpdateDate = DateTime.Now;
                                            xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                            base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
                                            DeliverySess = true;//发货单发货成功
                                            count++;
                                        }
                                      
                                        else
                                        {
                                            if (!IsPremiums)
                                                xMOrderInfo[0].DeliveryTime = DateTime.Now;//修改出库时间
                                            if (xMOrderInfo[0].PlatformTypeId == 259 || xMOrderInfo[0].PlatformTypeId == 803)
                                                xMOrderInfo[0].OrderStatus = "22";
                                            else 
                                                xMOrderInfo[0].OrderStatus = "已发货";
                                            xMOrderInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                            xMOrderInfo[0].UpdateDate = DateTime.Now;
                                            base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo[0]);

                                            //修改发货单 是否发货状态
                                            xMDelivery.IsDelivery = true;//已发货
                                            xMDelivery.UpdateDate = DateTime.Now;
                                            xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                            base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
                                            DeliverySess = true;//发货单发货成功
                                            count++;
                                        }

                                            //if (xMOrderInfo[0].PlatformTypeId == 376 || xMOrderInfo[0].PlatformTypeId == 765 || xMOrderInfo[0].PlatformTypeId == 767
                                            //    || xMOrderInfo[0].PlatformTypeId == 769|| xMOrderInfo[0].PlatformTypeId==508 || xMOrderInfo[0].PlatformTypeId == 259
                                            //    || xMOrderInfo[0].PlatformTypeId == 375 || xMOrderInfo[0].PlatformTypeId == 381 || xMOrderInfo[0].PlatformTypeId == 382
                                            //    || xMOrderInfo[0].PlatformTypeId == 383 || xMOrderInfo[0].PlatformTypeId == 511 || xMOrderInfo[0].PlatformTypeId == 537
                                            //    || xMOrderInfo[0].PlatformTypeId == 585 || xMOrderInfo[0].PlatformTypeId == 691 || xMOrderInfo[0].PlatformTypeId == 736
                                            //    || xMDelivery.DeliveryTypeId == 481 || xMDelivery.DeliveryTypeId == 708)
                                            //{
                                            //    xMOrderInfo[0].DeliveryTime = Convert.ToDateTime(DateTime.Now);//修改出库时间
                                            //    xMOrderInfo[0].OrderStatus = "已发货";
                                            //    xMOrderInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                            //    xMOrderInfo[0].UpdateDate = DateTime.Now;
                                            //    base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo[0]);

                                            //    //修改发货单 是否发货状态
                                            //    xMDelivery.IsDelivery = true;//已发货
                                            //    xMDelivery.UpdateDate = DateTime.Now;
                                            //    xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                            //    base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
                                            //    DeliverySess = true;//发货单发货成功
                                            //    count++;
                                            //}
                                            //else
                                            //{
                                            //    xMorderInfoApp = XMOrderInfoAppList.Where(p => p.PlatformTypeId == xMOrderInfo[0].PlatformTypeId).First(s => s.NickId == xMOrderInfo[0].NickID);
                                            //    switch (xMorderInfoApp.PlatformTypeId)
                                            //    {
                                            //        case 251:
                                            //            xMOrderInfo[0].DeliveryTime = DateTime.Now;//修改出库时间
                                            //            xMOrderInfo[0].OrderStatus = "WAIT_GOODS_RECEIVE_CONFIRM";
                                            //            xMOrderInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                            //            xMOrderInfo[0].UpdateDate = DateTime.Now;
                                            //            base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo[0]);

                                            //            //修改发货单 是否发货状态
                                            //            xMDelivery.IsDelivery = true;//已发货
                                            //            xMDelivery.UpdateDate = DateTime.Now;
                                            //            xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                            //            base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
                                            //            DeliverySess = true;//发货单发货成功
                                            //            count++;
                                            //            //JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                            //            //int paramLogisticsId = -1;
                                            //            //if (XMDeliveryDetailsList[0].LogisticsId == 1)
                                            //            //{
                                            //            //    paramLogisticsId = 2170;
                                            //            //}
                                            //            //if (XMDeliveryDetailsList[0].LogisticsId == 500) //中通速递
                                            //            //{
                                            //            //    paramLogisticsId = 1499;
                                            //            //}
                                            //            //JDsingleServiceReference.JindingOutstoragePesponse outstorage = webserver.GetOutstorage(xMOrderInfo[0].OrderCode, paramLogisticsId.ToString(), XMDeliveryDetailsList[0].LogisticsNumber, xMorderInfoApp.AppKey, xMorderInfoApp.AppSecret, xMorderInfoApp.ServerUrl, xMorderInfoApp.AccessToken);

                                            //            //if (outstorage != null)
                                            //            //{

                                            //            //    if (outstorage.order_sop_outstorage_response != null)
                                            //            //    {
                                            //            //        xMOrderInfo[0].DeliveryTime = Convert.ToDateTime(outstorage.order_sop_outstorage_response.modified);//修改出库时间
                                            //            //        xMOrderInfo[0].OrderStatus = "WAIT_GOODS_RECEIVE_CONFIRM";
                                            //            //        xMOrderInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                            //            //        xMOrderInfo[0].UpdateDate = DateTime.Now;
                                            //            //        base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo[0]);

                                            //            //        //修改发货单 是否发货状态
                                            //            //        xMDelivery.IsDelivery = true;//已发货
                                            //            //        xMDelivery.UpdateDate = DateTime.Now;
                                            //            //        xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                            //            //        base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
                                            //            //        DeliverySess = true;//发货单发货成功
                                            //            //        count++;
                                            //            //    }
                                            //            //}
                                            //            break;
                                            //        case 250:
                                            //            xMOrderInfo[0].DeliveryTime = Convert.ToDateTime(DateTime.Now);//修改出库时间
                                            //            xMOrderInfo[0].OrderStatus = "WAIT_GOODS_RECEIVE_CONFIRM";
                                            //            xMOrderInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                            //            xMOrderInfo[0].UpdateDate = DateTime.Now;
                                            //            base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo[0]);

                                            //            //修改发货单 是否发货状态
                                            //            xMDelivery.IsDelivery = true;//已发货
                                            //            xMDelivery.UpdateDate = DateTime.Now;
                                            //            xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                            //            base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
                                            //            DeliverySess = true;//发货单发货成功
                                            //            count++;
                                            //            //bool returnbool = base.XMOrderInfoAPIService.SendTM(xMOrderInfo[0].OrderCode, XMDeliveryDetailsList[0].LogisticsId.ToString(), XMDeliveryDetailsList[0].LogisticsNumber, xMorderInfoApp);
                                            //            //if (returnbool == true)
                                            //            //{
                                            //            //    xMOrderInfo[0].DeliveryTime = Convert.ToDateTime(DateTime.Now);//修改出库时间
                                            //            //    xMOrderInfo[0].OrderStatus = "WAIT_GOODS_RECEIVE_CONFIRM";
                                            //            //    xMOrderInfo[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                            //            //    xMOrderInfo[0].UpdateDate = DateTime.Now;
                                            //            //    base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo[0]);

                                            //            //    //修改发货单 是否发货状态
                                            //            //    xMDelivery.IsDelivery = true;//已发货
                                            //            //    xMDelivery.UpdateDate = DateTime.Now;
                                            //            //    xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                            //            //    base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
                                            //            //    DeliverySess = true;//发货单发货成功
                                            //            //    count++;
                                            //            //}
                                            //            break;
                                            //    }
                                            //}

                                        }
                                        else
                                        {
                                            throw new Exception("操作失败！订单号：" + XMDeliveryDetailsList[0].OrderNo + " 物流单号或物流公司不存在！");
                                        }
                                    //}
                                    //else
                                    //{
                                    //    //base.ShowMessage("京东appkey、appSecret、sessionKey 不能为空.");
                                    //    Ext.Net.ExtNet.Msg.Alert("提示", "京东appkey、appSecret、sessionKey 不能为空.").Show();
                                    //    return;
                                    //}
                                }
                                else
                                {
                                    //判断物流单号 ，物流公司 不为空
                                    if (XMDeliveryDetailsList[0].LogisticsNumber != "" && XMDeliveryDetailsList[0].LogisticsNumber != null && XMDeliveryDetailsList[0].LogisticsId != null)
                                    {
                                        paramLogisticsName = xMDelivery.ExpressName;
                                        paramLogisticsNumber = xMDelivery.LogisticsNumber;
                                        paramSign = xMDelivery.NickName;
                                        paramWantId = xMDelivery.WantID;
                                        paramMobile = xMDelivery.Mobile;
                                        paramMDeliveryDype = int.Parse(xMDelivery.DeliveryTypeId.ToString());
                                    }
                                    else
                                    {
                                        throw new Exception("操作失败！订单号：" + XMDeliveryDetailsList[0].OrderNo + " 物流单号或物流公司不存在！");
                                    }
                                    if (xMDelivery.OrderCode.StartsWith("NoOrder"))
                                    {
                                        //修改发货单 是否发货状态
                                        xMDelivery.IsDelivery = true;//已发货
                                        xMDelivery.UpdateDate = DateTime.Now;
                                        xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                        base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
                                        DeliverySess = true;//发货单发货成功
                                        count++;
                                    }
                                }

                                if (DeliverySess == true)
                                {
                                    bool isInventLess = false;
                                    string errMessage = "";
                                    List<SaleDeliveryProduct> List = new List<SaleDeliveryProduct>();

                                    int platformTypeId = 0;
                                    int projectID = 0;
                                    if(xMOrderInfo.Count>0)
                                    {
                                        platformTypeId = (int)xMOrderInfo[0].PlatformTypeId;
                                        projectID = xMOrderInfo[0].ProjectId;
                                    }
                                    else
                                    {
                                        if(xMDelivery.OrderCode.StartsWith("NoOrder"))
                                        {
                                            XMNick xmNick = XMDeliveryService.getNoOrderNickInfo(xMDelivery.OrderCode);
                                            platformTypeId = (int)xmNick.PlatformTypeId;
                                            projectID = (int)xmNick.ProjectId;
                                        }
                                    }

                                    foreach (var item in XMDeliveryDetailsList)
                                    {
                                        //发票跳过
                                        if (item.PrdouctName == "发票")
                                        {
                                            continue;
                                        }
                                        var productDetail = XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(item.PlatformMerchantCode, platformTypeId);
                                        if (productDetail.Count <= 0)
                                        {
                                            throw new Exception("商品编码为：" + item.PlatformMerchantCode + "商品不存在！");
                                        }
                                        SaleDeliveryProduct list2 = new SaleDeliveryProduct();
                                        list2.pcode = productDetail[0].ManufacturersCode;
                                        list2.saleDeliveryCount = (int)item.ProductNum;
                                        list2.wareHoueseID = (int)item.WarehouseID;
                                        list2.ProductName = item.PrdouctName;
                                        list2.ProductPrice = (decimal)productDetail[0].Saleprice;
                                        list2.ProductID = (int)productDetail[0].ProductId;
                                        list2.DeliveryNo = xMDelivery.DeliveryNumber;
                                        List.Add(list2);
                                    }

                                    if (List != null && List.Count > 0)
                                    {
                                        var List2 = from l in List
                                                    group l by new { l.pcode, l.wareHoueseID } into g
                                                    select new
                                                    {
                                                        pcode = g.Key.pcode,
                                                        wareHoueseID = g.Key.wareHoueseID,
                                                        saleDeliveryCount = g.Sum(a => a.saleDeliveryCount)
                                                    };

                                        if (List2 != null && List2.Count() > 0)
                                        {
                                            foreach (var parm in List2)
                                            {
                                                var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(parm.pcode, parm.wareHoueseID);
                                                if (inventInfo == null)
                                                {
                                                    isInventLess = true;      //库存不足
                                                    errMessage = errMessage + parm.pcode + ";";
                                                    break;
                                                }
                                                else
                                                {
                                                    if (inventInfo.StockNumber == null)
                                                    {
                                                        isInventLess = true;      //库存不足
                                                        errMessage = errMessage + parm.pcode + ";";
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        if (inventInfo.StockNumber == 0 || inventInfo.StockNumber < 0 || (inventInfo.StockNumber > 0 && inventInfo.StockNumber < parm.saleDeliveryCount))
                                                        {
                                                            isInventLess = true;      //库存不足
                                                            errMessage = errMessage + parm.pcode + ";";
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    if (isInventLess)                //库存不足
                                    {
                                        //base.ShowMessage("出库单号为：" + errMessage + "库存不足，无法出库！");
                                        Ext.Net.ExtNet.Msg.Alert("提示", "厂家编码为：" + errMessage + "库存不足，无法出库！").Show();
                                        return;
                                    }
                                    else
                                    {
                                        //更新产品库存表（减掉出库数量）
                                        paramContent = "";
                                        foreach (var item in List)
                                        {
                                            var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(item.pcode, item.wareHoueseID);
                                            if (InventoryInfo != null)                             //商品编码为code的产品在库存表中已经存在 更新库存数量
                                            {
                                                InventoryInfo.StockNumber = InventoryInfo.StockNumber - item.saleDeliveryCount;             //库存减掉出库量
                                                InventoryInfo.UpdateDate = DateTime.Now;
                                                InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);
                                                item.StockNumber = (int)InventoryInfo.StockNumber;
                                                paramContent += item.ProductName + "+";
                                            }
                                            //更新库存总账主表数据   从表添加一条记录
                                            UpdateInventoryLederInfo(item.wareHoueseID, item);
                                        }

                                        if ((projectID == 5|| projectID == 2) && paramMDeliveryDype == 481)//曲美项目
                                        {
                                            if (paramContent.Length > 0)
                                            {
                                                paramContent = paramContent.Substring(0, paramContent.Length - 1);
                                            }
                                            bool SendReturn = this.UseSensSms(paramSign, paramWantId, paramMobile, paramLogisticsName, paramLogisticsNumber, paramContent);
                                            if (!SendReturn)
                                            {
                                                sensreturn += paramMobile + "短信发送失败!";
                                                //throw new Exception("短信发送失败,物流单号：" + paramLogisticsNumber + "，请联系管理员");
                                            }
                                        }
                                    }

                                    #region 点批量发货，修改销售出库单出库状态和库存扣减
                                    //根据发货单ID  查询进销存系统销售出库单记录  更新出库状态  更新库存信息
                                    //var saleDeliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryListByParm(entity.Id);
                                    //if (saleDeliveryInfo != null && saleDeliveryInfo.Count > 0)
                                    //{
                                    //    foreach (var info in saleDeliveryInfo)
                                    //    {
                                    //        var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(entity.Id);
                                    //        if (saleDelivery != null)
                                    //        {
                                    //            var saleDeliveryDetail = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(saleDelivery.Id);
                                    //            if (saleDeliveryDetail != null && saleDeliveryDetail.Count > 0)
                                    //            {
                                    //                foreach (XMSaleDeliveryProductDetails parm in saleDeliveryDetail)
                                    //                {
                                    //                    SaleDeliveryProduct list2 = new SaleDeliveryProduct();
                                    //                    list2.pcode = parm.PlatformMerchantCode;
                                    //                    list2.saleDeliveryCount = parm.SaleCount.Value;
                                    //                    list2.wareHoueseID = saleDelivery.WareHouseId;
                                    //                    List.Add(list2);
                                    //                }
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    //if (List != null && List.Count > 0)
                                    //{
                                    //    var List2 = from l in List
                                    //                group l by new { l.pcode, l.wareHoueseID } into g
                                    //                select new
                                    //                {
                                    //                    pcode = g.Key.pcode,
                                    //                    wareHoueseID = g.Key.wareHoueseID,
                                    //                    saleDeliveryCount = g.Sum(a => a.saleDeliveryCount)
                                    //                };

                                    //    if (List2 != null && List2.Count() > 0)
                                    //    {
                                    //        foreach (var parm in List2)
                                    //        {
                                    //            var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(parm.pcode, parm.wareHoueseID);
                                    //            if (inventInfo == null)
                                    //            {
                                    //                isInventLess = true;      //库存不足
                                    //                errMessage = errMessage + parm.pcode + ";";
                                    //                break;
                                    //            }
                                    //            else
                                    //            {
                                    //                if (inventInfo.StockNumber == null)
                                    //                {
                                    //                    isInventLess = true;      //库存不足
                                    //                    errMessage = errMessage + parm.pcode + ";";
                                    //                    break;
                                    //                }
                                    //                else
                                    //                {
                                    //                    if (inventInfo.StockNumber == 0 || inventInfo.StockNumber < 0 || (inventInfo.StockNumber > 0 && inventInfo.StockNumber < parm.saleDeliveryCount))
                                    //                    {
                                    //                        isInventLess = true;      //库存不足
                                    //                        errMessage = errMessage + parm.pcode + ";";
                                    //                        break;
                                    //                    }
                                    //                }
                                    //            }
                                    //        }
                                    //    }
                                    //}


                                    //if (isInventLess)                //库存不足
                                    //{
                                    //    //base.ShowMessage("出库单号为：" + errMessage + "库存不足，无法出库！");
                                    //    Ext.Net.ExtNet.Msg.Alert("提示", "出库单号为：" + errMessage + "库存不足，无法出库！").Show();
                                    //    return;
                                    //}
                                    //else                          //库存充足  减掉库存
                                    //{
                                    //    if (saleDeliveryInfo != null && saleDeliveryInfo.Count > 0)
                                    //    {
                                    //        foreach (var info in saleDeliveryInfo)
                                    //        {
                                    //            if (info.BillStatus == 0)
                                    //            {
                                    //                info.IsAudit = true;
                                    //                info.BillStatus = 1000;
                                    //                info.UpdateDate = DateTime.Now;
                                    //                info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    //                base.XMSaleDeliveryService.UpdateXMSaleDelivery(info);
                                    //                //更新产品库存表（减掉出库数量）
                                    //                var deliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(info.Id);
                                    //                if (deliveryProductDetails != null && deliveryProductDetails.Count > 0)
                                    //                {
                                    //                    foreach (XMSaleDeliveryProductDetails parm in deliveryProductDetails)
                                    //                    {
                                    //                        string code = parm.PlatformMerchantCode;              //商品编码
                                    //                        int wfID = info.WareHouseId;                              //出库仓库ID
                                    //                        var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(code, wfID);
                                    //                        if (InventoryInfo != null)                             //商品编码为code的产品在库存表中已经存在 更新库存数量
                                    //                        {
                                    //                            InventoryInfo.StockNumber = InventoryInfo.StockNumber - parm.SaleCount;             //库存减掉出库量
                                    //                            InventoryInfo.UpdateDate = DateTime.Now;
                                    //                            InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    //                            base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);
                                    //                            paramContent += parm.ProductName + "+";
                                    //                        }
                                    //                        //更新库存总账主表数据   从表添加一条记录
                                    //                        UpdateInventoryLederInfo(info.WareHouseId, parm);
                                    //                    }
                                    //                }
                                    //            }
                                    //        }
                                    //        if (xMOrderInfo[0].ProjectId == 5 && paramMDeliveryDype == 481)//曲美项目
                                    //        {
                                    //            if (paramContent.Length > 0)
                                    //            {
                                    //                paramContent = paramContent.Substring(0, paramContent.Length - 1);
                                    //            }
                                    //            bool SendReturn = this.UseSensSms(paramSign, paramWantId, paramMobile, paramLogisticsName, paramLogisticsNumber, paramContent);
                                    //            if (!SendReturn)
                                    //            {
                                    //                throw new Exception("短信发送失败,物流单号：" + paramLogisticsNumber + "，请联系管理员");
                                    //            }
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        throw new Exception("销售出库单不存在，请联系管理员");
                                    //    }
                                    //}
                                }
                                else
                                {
                                    throw new Exception("发货单发货失败，请联系管理员");
                                }
                                #endregion
                            }

                        }
                        scope.Complete();
                    }
                        
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                //base.ShowMessage("操作成功！影响行数：" + count);
                Ext.Net.ExtNet.Msg.Alert("提示", "操作成功！" + sensreturn + "影响行数：" + count).Show();
            }
            catch (Exception ex)
            {
                //base.ShowMessage("错误信息：" + ex.Message);
                Ext.Net.ExtNet.Msg.Alert("提示", "错误信息：" + ex.Message).Show();
            }
        }

        /// <summary>
        /// 订单合并(EXT.NET)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OrdrInfMerger_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<XMDeliveryNew> list = Serializer.Deserialize<List<XMDeliveryNew>>(data);

            //List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            List<int> IDs = new List<int>();
            foreach(XMDeliveryNew entity in list)
            {
                IDs.Add(entity.Id);
            }

            if (IDs.Count <= 1)
            {
                //base.ShowMessage("请选择多条发货单合并！");
                Ext.Net.ExtNet.Msg.Alert("提示", "请选择多条发货单合并！").Show();
                return;
            }
            else
            {
                //选中的发货单信息
                var xmDeliveryList = base.XMDeliveryService.GetXMDeliverySearchListById(IDs);

                #region  判断所选数据是否是相同订单 、是否是未发货

                var IsDeliveryOKList = xmDeliveryList.Where(a => a.IsDelivery.Value == true).ToList();//是否发货：是 
                var xmDeliveryListGroupBy = xmDeliveryList.GroupBy(p => p.DeliveryAddress.Trim()).Select(g => g.First()).ToList();//根据收货地址分组
                var PrintQuantity = xmDeliveryList.Where(a => a.PrintQuantity.Value > 0).ToList();//打印过的发货单

                bool IsShipper = false;
                if (xmDeliveryList.Count > 0)
                {
                    for (int i = 0; i < xmDeliveryList.Count; i++)
                    {
                        if (i > 0)
                        {
                            if (xmDeliveryList[i].Shipper != xmDeliveryList[i - 1].Shipper)
                            {
                                IsShipper = true;
                                break;
                            }
                        }
                    }
                }

                if (IsDeliveryOKList.Count > 0 || xmDeliveryListGroupBy.Count > 1 || PrintQuantity.Count > 0 || IsShipper)
                {
                    //base.ShowMessage("请选择未发货、相同收货地址、未打印、发货方相同的数据合并！");
                    Ext.Net.ExtNet.Msg.Alert("提示", "请选择未发货、相同收货地址、未打印、发货方相同的数据合并！").Show();
                    return;
                }
                #endregion
                //事务
                using (TransactionScope scope = new TransactionScope())
                {
                    //取选择发货单列表中倒序 第一条数据。
                    XMDeliveryNew XMDeliveryNewTow = new XMDeliveryNew();

                    //存选择发货单列表中倒序 第一条数据。
                    //HozestERP.BusinessLogic.ManageProject.XMDelivery DeliveryTow = new BusinessLogic.ManageProject.XMDelivery();
                    //取选择发货单列表中倒序 第一条数据明细数据。
                    List<XMDeliveryDetails> xMDeliveryDetailsTowList = null;
                    XMDeliveryDetails xMDeliveryDetailsTow = null;
                    //发货单明细 (选中的明细数据)
                    List<XMDeliveryDetails> xMDeliveryDetailsList = null;

                    #region
                    if (xmDeliveryList.Count > 0)
                    {
                        //取选择发货单列表中倒序 除第一条数据。
                        // HozestERP.BusinessLogic.ManageProject.XMDelivery Deliverys = new BusinessLogic.ManageProject.XMDelivery();

                        //存选择发货单列表中倒序 除第一条数据。
                        XMDeliveryNew XMDeliveryNew = new XMDeliveryNew();

                        //循环选中的发货单信息
                        for (int i = 0; i < xmDeliveryList.Count; i++)
                        {
                            if (i == 0)
                            {
                                XMDeliveryNewTow = xmDeliveryList[i];//取选择中倒序 第一条数据。
                                xMDeliveryDetailsTowList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(XMDeliveryNewTow.Id);
                            }
                            else
                            {
                                XMDeliveryNew = xmDeliveryList[i];//除第一条以外的其他数据
                                if (XMDeliveryNew != null)
                                {
                                    xMDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(XMDeliveryNew.Id);

                                    if (xMDeliveryDetailsList.Count > 0)
                                    {
                                        XMDeliveryDetails xMDeliveryDetails = new XMDeliveryDetails();
                                        for (int j = 0; j < xMDeliveryDetailsList.Count; j++)
                                        {
                                            xMDeliveryDetails = xMDeliveryDetailsList[j];

                                            var xMDeliveryDetailsTowListbyPlatformMerchantCode = new List<XMDeliveryDetails>();

                                            ////明细的订单号是多个
                                            // if (xMDeliveryDetails.OrderNo.IndexOf(",") > -1)
                                            // {
                                            //     string[] OrderCodestr = xMDeliveryDetails.OrderNo.Split(',');
                                            //     List<string> OrderCodeList = new List<string>(OrderCodestr);
                                            //     //根据订单号查询发货单明细 
                                            //      var  OrderNoList =  xMDeliveryDetailsTowList.Where(a => OrderCodeList.Contains(a.OrderNo)).ToList();
                                            //     //根据商品编码 发货单明细 查询
                                            //     xMDeliveryDetailsTowListbyPlatformMerchantCode = xMDeliveryDetailsTowList.Where(a => OrderCodeList.Contains(a.PlatformMerchantCode)).ToList();   
                                            // }
                                            // else { 
                                            //根据商品编码 发货单明细 查询
                                            xMDeliveryDetailsTowListbyPlatformMerchantCode = xMDeliveryDetailsTowList.Where(a => a.PlatformMerchantCode.Equals(xMDeliveryDetails.PlatformMerchantCode)).ToList();
                                            //}

                                            //有相同商品编码 的产品
                                            if (xMDeliveryDetailsTowListbyPlatformMerchantCode.Count > 0)
                                            {
                                                xMDeliveryDetailsTow = xMDeliveryDetailsTowListbyPlatformMerchantCode[0];

                                                if (xMDeliveryDetailsTow.DetailsTypeId != null && xMDeliveryDetails.DetailsTypeId != null)
                                                {
                                                    //类型 不同不合并明细数据（明细新增）
                                                    if (xMDeliveryDetailsTow.DetailsTypeId.Value != xMDeliveryDetails.DetailsTypeId.Value)
                                                    {
                                                        xMDeliveryDetails.DeliveryId = XMDeliveryNewTow.Id;
                                                        xMDeliveryDetails.UpdateDate = DateTime.Now;
                                                        xMDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                        base.XMDeliveryDetailsService.UpdateXMDeliveryDetails(xMDeliveryDetails); //修改发货单明细（把发货单Id修改成选中发货单列表中的第一条发货单Id）
                                                    }
                                                    //类型相同合并明细数据 （数量累加，订单号累计）
                                                    else
                                                    {
                                                        //订单号累加
                                                        string strOrderCode = "";

                                                        List<string> OrderCodeListNew = new List<string>();
                                                        List<string> OrderCodeListOld = new List<string>();
                                                        if (xMDeliveryDetails.OrderNo.IndexOf(",") > -1 && xMDeliveryDetailsTow.OrderNo.IndexOf(",") > -1)
                                                        {
                                                            ////明细的订单号是多个（合并订单明细）
                                                            if (xMDeliveryDetails.OrderNo.IndexOf(",") > -1)
                                                            {
                                                                string[] OrderCodestr = xMDeliveryDetails.OrderNo.Split(',');
                                                                OrderCodeListNew = new List<string>(OrderCodestr);
                                                            }
                                                            else
                                                            {
                                                                OrderCodeListNew.Add(xMDeliveryDetails.OrderNo);
                                                            }
                                                            ////明细的订单号是多个（合并订单明细）原
                                                            if (xMDeliveryDetailsTow.OrderNo.IndexOf(",") > -1)
                                                            {
                                                                string[] OrderCodestrTow = xMDeliveryDetailsTow.OrderNo.Split(',');
                                                                OrderCodeListOld = new List<string>(OrderCodestrTow);
                                                            }
                                                            else
                                                            {
                                                                OrderCodeListOld.Add(xMDeliveryDetailsTow.OrderNo);
                                                            }

                                                            for (int k = 0; k < OrderCodeListOld.Count; k++)
                                                            {
                                                                if (!OrderCodeListNew.Contains(OrderCodeListOld[k]))
                                                                    OrderCodeListNew.Add(OrderCodeListOld[k]);
                                                            }

                                                            strOrderCode = string.Join(",", OrderCodeListNew);

                                                        }
                                                        else if (xMDeliveryDetailsTow.OrderNo.IndexOf(",") > -1)
                                                        {
                                                            #region 订单号不相同 累加订单号
                                                            if (xMDeliveryDetailsTow.OrderNo.IndexOf(",") > -1)
                                                            {
                                                                string[] OrderCodestr = xMDeliveryDetailsTow.OrderNo.Split(',');
                                                                List<string> OrderCodeList = new List<string>(OrderCodestr);
                                                                var OCList = from p in OrderCodeList
                                                                             where xMDeliveryDetails.OrderNo.Contains(p)
                                                                             select p;

                                                                if (OCList.ToList().Count == 0)
                                                                {
                                                                    //原订单号+ 新的订单号
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo + "," + xMDeliveryDetails.OrderNo;
                                                                }
                                                                else
                                                                {
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (xMDeliveryDetailsTow.OrderNo != xMDeliveryDetails.OrderNo)
                                                                {
                                                                    //原订单号+ 新的订单号
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo + "," + xMDeliveryDetails.OrderNo;
                                                                }
                                                                else
                                                                {
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo;
                                                                }
                                                            }
                                                            #endregion
                                                        }
                                                        else if (xMDeliveryDetails.OrderNo.IndexOf(",") > -1)
                                                        {
                                                            #region 订单号不相同 累加订单号
                                                            if (xMDeliveryDetails.OrderNo.IndexOf(",") > -1)
                                                            {
                                                                string[] OrderCodestr = xMDeliveryDetails.OrderNo.Split(',');
                                                                List<string> OrderCodeList = new List<string>(OrderCodestr);
                                                                var OCList = from p in OrderCodeList
                                                                             where xMDeliveryDetailsTow.OrderNo.Contains(p)
                                                                             select p;

                                                                if (OCList.ToList().Count == 0)
                                                                {
                                                                    //原订单号+ 新的订单号
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo + "," + xMDeliveryDetails.OrderNo;
                                                                }
                                                                else
                                                                {
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (xMDeliveryDetailsTow.OrderNo != xMDeliveryDetails.OrderNo)
                                                                {
                                                                    //原订单号+ 新的订单号
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo + "," + xMDeliveryDetails.OrderNo;
                                                                }
                                                                else
                                                                {
                                                                    strOrderCode = xMDeliveryDetailsTow.OrderNo;
                                                                }
                                                            }
                                                            #endregion
                                                        }


                                                        //新的数量
                                                        int ProductNum = xMDeliveryDetailsTow.ProductNum.Value + xMDeliveryDetails.ProductNum.Value;

                                                        xMDeliveryDetailsTow.OrderNo = strOrderCode;
                                                        xMDeliveryDetailsTow.ProductNum = ProductNum;
                                                        xMDeliveryDetailsTow.UpdateDate = DateTime.Now;
                                                        xMDeliveryDetailsTow.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                        base.XMDeliveryDetailsService.UpdateXMDeliveryDetails(xMDeliveryDetailsTow); //修改发货单明细（把发货单Id修改成选中发货单列表中的第一条发货单Id）

                                                        //删除原明细
                                                        base.XMDeliveryDetailsService.DeleteXMDeliveryDetails(xMDeliveryDetails.Id);
                                                    }
                                                }
                                                //新增明细
                                                else
                                                {
                                                    xMDeliveryDetails.DeliveryId = XMDeliveryNewTow.Id;
                                                    xMDeliveryDetails.UpdateDate = DateTime.Now;
                                                    xMDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                    base.XMDeliveryDetailsService.UpdateXMDeliveryDetails(xMDeliveryDetails); //修改发货单明细（把发货单Id修改成选中发货单列表中的第一条发货单Id）
                                                }
                                            }
                                            else
                                            {


                                                xMDeliveryDetails.DeliveryId = XMDeliveryNewTow.Id;
                                                xMDeliveryDetails.UpdateDate = DateTime.Now;
                                                xMDeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                base.XMDeliveryDetailsService.UpdateXMDeliveryDetails(xMDeliveryDetails); //修改发货单明细（把发货单Id修改成选中发货单列表中的第一条发货单Id）
                                            }
                                        }
                                    }
                                    base.XMDeliveryService.DeleteXMDelivery(XMDeliveryNew.Id);//删除发货单主表信息 
                                }
                            }
                        }
                    }
                    #endregion

                    //base.ShowMessage("保存成功！");
                    Ext.Net.ExtNet.Msg.Alert("提示", "保存成功！").Show();
                    this.BindGrid(Master.PageIndex, Master.PageSize);
                    scope.Complete();
                }

            }
        }

        /// <summary>
        /// 手动发货导出(EXT.NET)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeliverExport_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            try
            {
                //导出存放路径
                string fileName = string.Format("DeliverExport_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                string filePath = string.Format("{0}Upload\\DeliverExport", HttpContext.Current.Request.PhysicalApplicationPath);
                if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = filePath + "//" + fileName;

                //读取数据
                List<XMDeliveryNew> list = new List<XMDeliveryNew>();
                //List<int> ProductInfoIDs = this.Master.GetSelectedIds(this.grdvClients);
                List<int> ProductInfoIDs = new List<int>();

                string data = e.ExtraParams["data"];
                System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<XMDeliveryNew> list_XMDeliveryNew = Serializer.Deserialize<List<XMDeliveryNew>>(data);

                foreach(XMDeliveryNew entity in list_XMDeliveryNew)
                {
                    ProductInfoIDs.Add(entity.Id);
                }

                //this.BindGrid(1, Master.PageSize);

                if (ProductInfoIDs.Count <= 0)
                {
                    list = PostListExportList;
                }
                else
                {
                    foreach (XMDeliveryNew one in PostListExportPageList)
                    {
                        if (ProductInfoIDs.IndexOf(one.Id) != -1)
                        {
                            list.Add(one);
                        }
                    }
                }

                base.ExportManager.DeliverExportList(filePath, list);
                CommonHelper.WriteResponseXls(filePath, fileName);
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }

        /// <summary>
        /// 赠品取消面单号(EXT.NET)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancelWaybill_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<XMDeliveryNew> list_XMDeliveryNew = Serializer.Deserialize<List<XMDeliveryNew>>(data);

            //List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            List<int> IDs = new List<int>();
            foreach(XMDeliveryNew entity in list_XMDeliveryNew)
            {
                IDs.Add(entity.Id);
            }

            if (IDs.Count <= 0)
            {
                //base.ShowMessage("你没有选择任何记录！");
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录！").Show();
                return;
            }
            else
            {
                List<HozestERP.BusinessLogic.ManageProject.XMDelivery> list = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
                foreach (int ID in IDs)
                {
                    var delivery = base.XMDeliveryService.GetXMDeliveryById(ID);
                    if (delivery != null)
                    {
                        //if (delivery.IsDelivery == false)
                        //{
                        //    //base.ShowMessage("发货单号：" + delivery.DeliveryNumber + "，的发货单未发货！");
                        //    Ext.Net.ExtNet.Msg.Alert("提示", "发货单号：" + delivery.DeliveryNumber + "，的发货单未发货！").Show();
                        //    return;
                        //}
                        if (delivery.LogisticsId == null || string.IsNullOrEmpty(delivery.LogisticsNumber))
                        {
                            //base.ShowMessage("发货单号：" + delivery.DeliveryNumber + "，的发货单没有物流公司或物流单号！");
                            Ext.Net.ExtNet.Msg.Alert("提示", "发货单号：" + delivery.DeliveryNumber + "，的发货单没有物流公司或物流单号！").Show();
                            return;
                        }
                        //if (delivery.DeliveryTypeId != 481)
                        //{
                        //    base.ShowMessage("发货单号：" + delivery.DeliveryNumber + "，的发货单类型不是赠送产品！");
                        //    return;
                        //}
                        list.Add(delivery);
                    }
                }

                string str = base.XMOrderInfoAPIService.CancelWaybill(list);
                if (string.IsNullOrEmpty(str))
                {
                        //
                        //foreach (HozestERP.BusinessLogic.ManageProject.XMDelivery Info in list)
                        //{
                        //if (Info.DeliveryTypeId == 481)                       //判断是否是赠品 如是赠品 更新销售出库单状态 更新库存
                        //{
                        //    //根据发货单ID  查询进销存系统销售出库单记录  更新出库状态  更新库存信息
                        //    var saleDeliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryListByParm(Info.Id);
                        //    if (saleDeliveryInfo != null && saleDeliveryInfo.Count > 0)
                        //    {
                        //        foreach (var info in saleDeliveryInfo)
                        //        {
                        //            using (TransactionScope scope = new TransactionScope())
                        //            {
                        //                info.BillStatus = 0;   //更新为待入库状态
                        //                info.UpdateDate = DateTime.Now;
                        //                info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        //                base.XMSaleDeliveryService.UpdateXMSaleDelivery(info);
                        //                var deliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(info.Id);
                        //                if (deliveryProductDetails != null && deliveryProductDetails.Count > 0)
                        //                {
                        //                    foreach (XMSaleDeliveryProductDetails parm in deliveryProductDetails)
                        //                    {
                        //                        string code = parm.PlatformMerchantCode;              //商品编码
                        //                        int wfID = info.WareHouseId;                              //出库仓库ID
                        //                        var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(code, wfID);
                        //                        if (InventoryInfo != null)                             //商品编码为code的产品在库存表中已经存在 更新库存数量
                        //                        {
                        //                            InventoryInfo.StockNumber = InventoryInfo.StockNumber + parm.SaleCount;             //库存加上出库量
                        //                            InventoryInfo.CanOrderCount = InventoryInfo.StockNumber;
                        //                            InventoryInfo.UpdateDate = DateTime.Now;
                        //                            InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        //                            base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);
                        //                        }
                        //                    }
                        //                }
                        //                scope.Complete();
                        //            }
                        //        }
                        //    }

                        //}
                        //}
                        //base.ShowMessage("取消电子面单号成功！");
                        Ext.Net.ExtNet.Msg.Alert("提示", "取消电子面单号成功！").Show();
                }
                else
                {
                    //base.ShowMessage(str);
                    Ext.Net.ExtNet.Msg.Alert("提示", str).Show();
                }
            }
        }

        /// <summary>
        /// 挂起发货单(EXT.NET)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ShelveDelivery_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<XMDeliveryNew> list_XMDeliveryNew = Serializer.Deserialize<List<XMDeliveryNew>>(data);

            //List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            List<int> IDs = new List<int>();
            foreach (XMDeliveryNew entity in list_XMDeliveryNew)
            {
                IDs.Add(entity.Id);
            }

            if (IDs.Count <= 0)
            {
                //base.ShowMessage("你没有选择任何记录！");
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录！").Show();
                return;
            }
            else
            {
                foreach (int ID in IDs)
                {
                    var delivery = base.XMDeliveryService.GetXMDeliveryById(ID);
                    if (delivery != null)
                    {
                        delivery.IsShelve = true;
                        delivery.UpdateDate = DateTime.Now;
                        delivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                        base.XMDeliveryService.UpdateXMDelivery(delivery);
                    }
                }
                //base.ShowMessage("挂起成功！");
                Ext.Net.ExtNet.Msg.Alert("提示", "挂起成功！").Show();
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }

        /// <summary>
        /// 导入物流费用(EXT.NET)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UnShelveDelivery_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<XMDeliveryNew> list_XMDeliveryNew = Serializer.Deserialize<List<XMDeliveryNew>>(data);

            //List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            List<int> IDs = new List<int>();
            foreach (XMDeliveryNew entity in list_XMDeliveryNew)
            {
                IDs.Add(entity.Id);
            }

            if (IDs.Count <= 0)
            {
                //base.ShowMessage("你没有选择任何记录！");
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录！").Show();
                return;
            }
            else
            {
                foreach (int ID in IDs)
                {
                    var delivery = base.XMDeliveryService.GetXMDeliveryById(ID);
                    if (delivery != null)
                    {
                        delivery.IsShelve = false;
                        delivery.UpdateDate = DateTime.Now;
                        delivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                        base.XMDeliveryService.UpdateXMDelivery(delivery);
                    }
                }
                //base.ShowMessage("取消挂起成功！");
                Ext.Net.ExtNet.Msg.Alert("提示", "取消挂起成功！").Show();
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }

        /// <summary>
        /// 生成喜临门订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void XLMOrderInfo_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            string data_Direct = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<XMDeliveryNew> list_XMDeliveryNew = Serializer.Deserialize<List<XMDeliveryNew>>(data_Direct);

            //List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            List<int> IDs = new List<int>();
            foreach (XMDeliveryNew entity in list_XMDeliveryNew)
            {
                IDs.Add(entity.Id);
            }

            if (IDs.Count <= 0)
            {
                //base.ShowMessage("你没有选择任何记录！");
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录！").Show();
                return;
            }
            else
            {
                var DeliveryList = base.XMDeliveryService.GetXMDeliveryByListIds(IDs);
                foreach (var Info in DeliveryList)
                {
                    if (Info.DeliveryTypeId != 480 && Info.DeliveryTypeId != 708)
                    {
                        //base.ShowMessage("发货单类型必须为正式产品或换货产品！");
                        Ext.Net.ExtNet.Msg.Alert("提示", "发货单类型必须为正式产品或换货产品！").Show();
                        return;
                    }
                    if (Info.IsDelivery == true || Info.PrintQuantity != 0)
                    {
                        //base.ShowMessage("已发货或已打印的订单不能生成生成喜临门订单！");
                        Ext.Net.ExtNet.Msg.Alert("提示", "已发货或已打印的订单不能生成生成喜临门订单！").Show();
                        return;
                    }
                    if (string.IsNullOrEmpty(Info.OrderCode))
                    {
                        //base.ShowMessage("发货单号：" + Info.DeliveryNumber + "，不存在订单号！");
                        Ext.Net.ExtNet.Msg.Alert("提示", "发货单号：" + Info.DeliveryNumber + "，不存在订单号！").Show();
                        return;
                    }
                    else
                    {
                        var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(Info.OrderCode);
                        if (OrderInfo == null)
                        {
                            //base.ShowMessage("订单号：" + Info.OrderCode + "，在订单表中不存在！");
                            Ext.Net.ExtNet.Msg.Alert("提示", "订单号：" + Info.OrderCode + "，在订单表中不存在！").Show();
                            return;
                        }
                    }
                }

                string msg = "";
                string method = "qs.order.put";

                foreach (var Info in DeliveryList)
                {
                    StringBuilder body = new StringBuilder();
                    body = GetOrderPutJson(body, Info, ref msg);
                    if (body == null)
                    {
                        //msg += "发货单号：" + Info.DeliveryNumber + "，转换Json格式错误！";
                        continue;
                    }

                    //string url = xLMInterface.GetUrl(method, body.ToString());//喜临门老系统接口
                    string paramtoken = "";
                    # region 获取喜临门新系统接口token
                    XMOrderInfoApp orderinfoapp = base.XMOrderInfoAppService.GetXMOrderInfoAppByID(68);
                    if (orderinfoapp != null)
                        paramtoken = orderinfoapp.AccessToken;
                    #endregion
                    paramtoken = xLMInterface.Gettoken();
                    string url = xLMInterface.NewApiUrl + "sleemonecwebservices/sleemonOrder/createOrder?access_token=" + paramtoken;//喜临门新系统接口
                    string josnStr = xLMInterface.GetResponseData(body.ToString(), url);//GetInfo(url);
                    JObject jo = (JObject)JsonConvert.DeserializeObject(josnStr);
                    if (josnStr == "error")
                    {
                        paramtoken = xLMInterface.Gettoken();
                        orderinfoapp.AccessToken = paramtoken;
                        base.XMOrderInfoAppService.UpdateXMOrderInfoApp(orderinfoapp);
                        url = xLMInterface.NewApiUrl + "sleemonecwebservices/sleemonOrder/createOrder?access_token=" + paramtoken;//喜临门新系统接口
                        josnStr = xLMInterface.GetResponseData(body.ToString(), url);//GetInfo(url);
                        if (josnStr == "error")
                        {
                            msg += "推送失败!请检查推送地址！";
                            break;
                        }
                    }
                    Dictionary<string, object> data = xLMInterface.JsonToDictionary(josnStr);
                    if (data.ContainsKey("flag"))
                    {
                        msg += "发货单号：" + Info.DeliveryNumber + "，" + data["message"] + "！<br/>";
                    }
                    else
                    {
                        if (data["success"].ToString() != "True")
                        {
                            msg += "发货单号：" + Info.DeliveryNumber + "，" + data["message"] + "！<br/>";
                        }
                        else
                        {
                            Info.PrintQuantity = Info.PrintQuantity == null ? 0 : Info.PrintQuantity;
                            Info.PrintBatch = Info.PrintBatch == null ? 0 : Info.PrintBatch;
                            Info.PrintQuantity += 1;//打印次数

                            //取发货单表中 打印批次倒序最后条
                            var xMDeliveryListByPrintBatch = IoC.Resolve<IXMDeliveryService>().GetXMDeliveryList().OrderByDescending(p => p.PrintBatch).FirstOrDefault();
                            if (xMDeliveryListByPrintBatch != null)
                            {
                                if (xMDeliveryListByPrintBatch.PrintBatch != null)
                                {
                                    Info.PrintBatch = xMDeliveryListByPrintBatch.PrintBatch.Value + 1;
                                }
                            }
                            Info.PrintDateTime = DateTime.Now;//打印时间
                            Info.UpdateId = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.XMDeliveryService.UpdateXMDelivery(Info);
                        }
                    }
                }

                if (msg != "")
                {
                    //base.ShowMessage(msg);
                    Ext.Net.ExtNet.Msg.Alert("提示", msg).Show();
                }
                else
                {
                    //base.ShowMessage("喜临门订单创建成功！");
                    Ext.Net.ExtNet.Msg.Alert("提示", "喜临门订单创建成功！").Show();
                    this.BindGrid(1, Master.PageSize);
                }
            }
        }

        /// <summary>
        /// 行编辑前事件，加载物流公司
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RowBeforeEdit(object sender, Ext.Net.DirectEventArgs e)
        {
            int DeliveryId =int.Parse(e.ExtraParams["DeliveryId"]);
            var xmDelivery = base.XMDeliveryService.GetXMDeliveryById(DeliveryId);
            if (xmDelivery != null)
            {
                //if (xmDelivery.DeliveryTypeId.Value == 480 || xmDelivery.DeliveryTypeId.Value == 708)
                //{
                    //根据订单号查询 订单信息
                    var xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xmDelivery.OrderCode);

                    //物流公司信息
                    List<XMCompanyCustom> xMCompanyCustomList = new List<XMCompanyCustom>();
                    if (xMOrderInfo != null)
                    {
                        xMCompanyCustomList = base.XMCompanyCustomService.GetXMCompanyCustomList();//GetXMCompanyCustomByNickIdAndPlatformTypeId(1, xMOrderInfo.PlatformTypeId.Value);
                    }

                    if (xMCompanyCustomList.Count > 0)
                    {
                        if (CompanyCheck != null)
                        {
                            CompanyCheck.Visible = true;
                            CompanyCheck.Items.Clear();
                            LogisticsCompanyStore.DataSource = xMCompanyCustomList;
                            LogisticsCompanyStore.DataBind();
                            CompanyCheck.Value = xmDelivery.LogisticsId;
                            //ddLogisticsId.Items.Insert(0, new ListItem(" ", "-1"));
                        }
                    }
                //}

                //if (ddLogisticsId != null)
                //{
                //    if (xmDelivery.LogisticsId != null)
                //    {
                //        ddLogisticsId.SelectedValue = xmDelivery.LogisticsId != null ? xmDelivery.LogisticsId.Value.ToString() : "";
                //    }
                //}
            }
        }

        /// <summary>
        /// 保存修改的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RowAfterEdit(object sender, Ext.Net.DirectEventArgs e)
        {
            string LogisticsNumber = e.ExtraParams["LogisticsNumber"];
            int DeliveryId = int.Parse(e.ExtraParams["DeliveryId"]);
            string LogisticsFee= e.ExtraParams["LogisticsFee"];
            string SelectedValue = CompanyCheck.Value.ToString() ;

            if(string.IsNullOrEmpty(LogisticsNumber))
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "请输入物流单号！").Show();
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                return;
            }
            if(string.IsNullOrEmpty(SelectedValue))
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "请输入物流公司！").Show();
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                return;
            }


            //CompanyCheck
            try
            {
                var xMDelivery = base.XMDeliveryService.GetXMDeliveryById(DeliveryId);

                xMDelivery.LogisticsNumber = LogisticsNumber;
                xMDelivery.LogisticsId = int.Parse(SelectedValue);
                xMDelivery.Price = string.IsNullOrEmpty(LogisticsFee) ? 0 : decimal.Parse(LogisticsFee);

                xMDelivery.UpdateId = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                xMDelivery.UpdateDate = DateTime.Now;
                //保存数据
                base.XMDeliveryService.UpdateXMDelivery(xMDelivery);

                Ext.Net.ExtNet.Msg.Alert("提示", "保存成功！").Show();

                BindGrid(this.Master.PageIndex, this.Master.PageSize);
            }
            catch(Exception ex)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", ex.Message).Show();
            }


        }

        /// <summary>
        /// 加载挂起说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RowCommand(object sender, Ext.Net.DirectEventArgs e)
        {
            int DeliveryID = int.Parse(e.ExtraParams["ID"]);
            string Name = e.ExtraParams["Name"];

            if(Name== "Remark")
            {
                var Info = base.XMDeliveryService.GetXMDeliveryById(DeliveryID);
                if (Info != null)
                {
                    tRemark.Text = Info.ShelveRemarks;
                }

                FormPanel1.SetValues(new { DeliveryID });
                Window2.Show();
            }
            else if(Name == "Logistics")
            {
                string url = "https://www.kuaidi100.com/chaxun?";
                var xmDelivery = XMDeliveryService.GetXMDeliveryById(DeliveryID);

                if(!string.IsNullOrEmpty(xmDelivery.LogisticsNumber) && xmDelivery.LogisticsId!=null)
                {
                    var xmCompanyCustom = XMCompanyCustomService.GetXMCompanyCustomByLogisticId(xmDelivery.LogisticsId.ToString());
                    if(xmCompanyCustom!=null)
                    {
                        url = url + "com=" + xmCompanyCustom.Code+ "&nu="+ xmDelivery.LogisticsNumber;
                    }
                }
                //源地址 https://www.kuaidi100.com/chaxun?com=yunda&nu=1500066330925

                Window1.AutoLoad.Url = url;
                Window1.AutoLoad.Mode = Ext.Net.LoadMode.IFrame;
                Window1.AutoLoad.ShowMask = true;
                Window1.AutoLoad.MaskMsg = "正在加载中...";
                Window1.Render();
                Window1.Show();
            }
        }


        /// <summary>
        /// 保存挂起说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void WindowSave(object sender, Ext.Net.DirectEventArgs e)
        {
           
            int DeliveryID = int.Parse(HiddenID.Value.ToString());
            string Remark = tRemark.Value.ToString();

            if(string.IsNullOrEmpty(Remark))
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "请输入内容!").Show();
            }

            try
            {
                var Info = base.XMDeliveryService.GetXMDeliveryById(DeliveryID);
                if (Info != null)
                {
                    Info.ShelveRemarks = Remark;
                    Info.UpdateId = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateDate = DateTime.Now;
                    base.XMDeliveryService.UpdateXMDelivery(Info);

                }
                else
                {
                    //base.ShowMessage("该发货单不存在！");
                    Ext.Net.ExtNet.Msg.Alert("提示", "该发货单不存在!").Show();
                    return;
                }
                //base.ShowMessage("保存成功！");
                Ext.Net.ExtNet.Msg.Alert("提示", "保存成功！").Show();
                Window2.Hidden = true;
            }
            catch (Exception err)
            {
                this.ProcessException(err);
            }
        }

        /// <summary>
        /// 批量打印发货单
        /// </summary>
        protected void PrintDelivery(object sender, Ext.Net.DirectEventArgs e) 
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<XMDeliveryNew> list = Serializer.Deserialize<List<XMDeliveryNew>>(data);

            List<int> IDs = new List<int>();
            foreach (XMDeliveryNew entity in list)
            {
                IDs.Add(entity.Id);
            }

            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                //string ids = "";//订单ids
                //foreach (GridViewRow row in grdvClients.Rows)
                //{
                //    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                //    if (chkSelected.Checked)
                //    {
                //        int DeliveryID = 0;
                //        int.TryParse(this.grdvClients.DataKeys[row.RowIndex].Value.ToString(), out DeliveryID);

                //        var deliveryinfo = base.XMDeliveryService.GetXMDeliveryById(DeliveryID);
                //        if (deliveryinfo.OrderCode != null && deliveryinfo.OrderCode != "")
                //        {
                //            var orderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(deliveryinfo.OrderCode);//订单信息
                //            if (orderinfo != null)
                //            {
                //                if (ids != "")
                //                    ids += ",";
                //                ids += orderinfo.ID;
                //            }
                //        }

                //    }
                //}

                //订单Id
                string orderinfoId = string.Join(",", IDs);

                string strdiqu = "STO";
                Ext.Net.X.WindowManager.AddScript("window.open('dyFHD.aspx?kd=" + strdiqu
                    + "&ids=" + orderinfoId
                    + "&PrintTypeId=Delivery"
                    + "','批量打印发货单', 'height=800, width=911, top=0, left=0, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=n o, status=no');");
            }
        }

        protected void btnPlatformDeliver_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            try
            {
                string paramSign = "";//项目名称
                string paramWantId = "";//网名
                string paramMobile = "";//接收手机
                string paramLogisticsName = "";//快递名称
                string paramLogisticsNumber = "";//物流单号
                int paramMDeliveryDype = 0;
                //查询 appkey、appSecret、sessionKey
                var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();
                XMOrderInfoApp xMorderInfoApp = new XMOrderInfoApp();//appkey、appSecret、sessionKey

                string data = e.ExtraParams["data"];
                System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<XMDeliveryNew> list = Serializer.Deserialize<List<XMDeliveryNew>>(data);

                //List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);

                if (list.Count <= 0)
                {
                    //base.ShowMessage("你没有选择任何记录");
                    Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录").Show();
                    return;
                }
                else
                {
                    foreach (XMDeliveryNew entity in list)
                    {
                        //根据Id 查询 发货单
                        var xMDelivery = base.XMDeliveryService.GetXMDeliveryById(entity.Id);

                        if(xMDelivery.IsPlatformDeliver==true)
                        {
                            throw new Exception("发货单号：" + xMDelivery.DeliveryNumber + "已经平台发货，不允许再次发货！");
                        }

                        //根据选中的行数据 Id 管理发货单明细 
                        var XMDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsMappingSearchList(Convert.ToInt32(entity.Id));

                        if (XMDeliveryDetailsList.Count > 0 && xMDelivery != null)
                        {
                            var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(XMDeliveryDetailsList[0].OrderNo);

                            if (xMOrderInfo.Count > 0)
                            {
                                var XMOrderInfoAppOne = XMOrderInfoAppList.Where(p => p.PlatformTypeId == xMOrderInfo[0].PlatformTypeId).Where(s => s.NickId == xMOrderInfo[0].NickID);
                                if (XMOrderInfoAppOne.Count() > 0 || xMOrderInfo[0].PlatformTypeId == 376 || xMOrderInfo[0].PlatformTypeId == 765 || xMOrderInfo[0].PlatformTypeId == 767
                                            || xMOrderInfo[0].PlatformTypeId == 769)
                                {
                                    //判断物流单号 ，物流公司 不为空
                                    if (XMDeliveryDetailsList[0].LogisticsNumber != "" && XMDeliveryDetailsList[0].LogisticsNumber != null && XMDeliveryDetailsList[0].LogisticsId != null)
                                    {
                                        paramLogisticsName = xMDelivery.ExpressName;
                                        paramLogisticsNumber = xMDelivery.LogisticsNumber;
                                        paramSign = xMDelivery.NickName;
                                        paramWantId = xMDelivery.WantID;
                                        paramMobile = xMDelivery.Mobile;
                                        paramMDeliveryDype = int.Parse(xMDelivery.DeliveryTypeId.ToString());
                                        if (xMOrderInfo[0].PlatformTypeId == 376 || xMOrderInfo[0].PlatformTypeId == 765 || xMOrderInfo[0].PlatformTypeId == 767
                                            || xMOrderInfo[0].PlatformTypeId == 769 || xMDelivery.DeliveryTypeId == 481 || xMDelivery.DeliveryTypeId == 708)
                                        {
                                            throw new Exception("发货单号：" + xMDelivery.DeliveryNumber + "不允许平台发货！");
                                        }
                                        else
                                        {
                                            xMorderInfoApp = XMOrderInfoAppList.Where(p => p.PlatformTypeId == xMOrderInfo[0].PlatformTypeId).First(s => s.NickId == xMOrderInfo[0].NickID);
                                            switch (xMorderInfoApp.PlatformTypeId)
                                            {
                                                case 251:
                                                    JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                                    int paramLogisticsId = -1;
                                                    if (XMDeliveryDetailsList[0].LogisticsId == 1)
                                                    {
                                                        paramLogisticsId = 2170;
                                                    }
                                                    if (XMDeliveryDetailsList[0].LogisticsId == 500) //中通速递
                                                    {
                                                        paramLogisticsId = 1499;
                                                    }
                                                    JDsingleServiceReference.JindingOutstoragePesponse outstorage = webserver.GetOutstorage(xMOrderInfo[0].OrderCode, paramLogisticsId.ToString(), XMDeliveryDetailsList[0].LogisticsNumber, xMorderInfoApp.AppKey, xMorderInfoApp.AppSecret, xMorderInfoApp.ServerUrl, xMorderInfoApp.AccessToken);

                                                    if (outstorage != null)
                                                    {
                                                        if(!string.IsNullOrEmpty(outstorage.ErrMsg))
                                                        {
                                                            throw new Exception("发货单号：" + xMDelivery.DeliveryNumber + "平台发货失败！,错误原因："+ outstorage.ErrMsg);
                                                        }
                                                        //修改发货单 平台发货
                                                        xMDelivery.IsPlatformDeliver = true;//已发货
                                                        xMDelivery.UpdateDate = DateTime.Now;
                                                        xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                                        base.XMDeliveryService.UpdateXMDelivery(xMDelivery);
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("发货单号：" + xMDelivery.DeliveryNumber + "平台发货失败，请检查相关配置！");
                                                    }
                                                    break;
                                                case 250:
                                                    bool returnbool = base.XMOrderInfoAPIService.SendTM(xMOrderInfo[0].OrderCode, XMDeliveryDetailsList[0].LogisticsId.ToString(), XMDeliveryDetailsList[0].LogisticsNumber, xMorderInfoApp);
                                                    if(!returnbool)
                                                    {
                                                        throw new Exception("发货单号：" + xMDelivery.DeliveryNumber + "平台发货失败！");
                                                    }

                                                    //修改发货单 平台发货
                                                    xMDelivery.IsPlatformDeliver = true;//已发货
                                                    xMDelivery.UpdateDate = DateTime.Now;
                                                    xMDelivery.UpdateId = HozestERPContext.Current.User.CustomerID;
                                                    base.XMDeliveryService.UpdateXMDelivery(xMDelivery);

                                                    break;

                                                default:
                                                    throw new Exception("发货单号：" + xMDelivery.DeliveryNumber + "找不到适合的发货方式，发货失败！");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("操作失败！订单号：" + XMDeliveryDetailsList[0].OrderNo + " 物流单号或物流公司不存在！");
                                    }
                                }
                                else
                                {
                                    Ext.Net.ExtNet.Msg.Alert("提示", "京东appkey、appSecret、sessionKey 不能为空.").Show();
                                    return;
                                }
                            }
                            else
                            {
                                throw new Exception("找不到订单：" + XMDeliveryDetailsList[0].OrderNo);
                            }
                        }
                        else
                        {
                            throw new Exception("发货单不存在或无发货单明细！");
                        }
                    }
                    BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    Ext.Net.ExtNet.Msg.Alert("提示", "操作成功！").Show();
                }
            }
            catch(Exception ex)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "错误信息：" + ex.Message).Show();
            }
        }
    }
}