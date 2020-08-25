using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.Codes;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageApplication;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageBusiness
{
    public partial class OperatingCost : BaseAdministrationPage, ISearchPage
    {
        public string TableList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.rblProjectList.Items.Clear();
                var list = base.XMProjectService.GetXMProjectList();
                if (list != null && list.Count > 0)
                {
                    this.rblProjectList.DataSource = list;
                    this.rblProjectList.DataTextField = "ProjectName";
                    this.rblProjectList.DataValueField = "Id";
                    this.rblProjectList.DataBind();
                }
                this.rblProjectList.Items.Add(new ListItem("B2B", "B2B"));
                this.rblProjectList.Items.Add(new ListItem("B2C", "B2C"));
                this.rblProjectList.SelectedIndex = 0;

                //加载页面，默认显示
                string title = this.rblProjectList.SelectedItem.Text.Trim() + "营业成本";
                this.lblTitle.Text = title;

                StringBuilder str = Total();
                TableList = str.ToString();
            }
        }

        protected void rblProjectList_Changed(object sender, EventArgs e)
        {
            string title = this.rblProjectList.SelectedItem.Text.Trim() + "营业成本";
            this.lblTitle.Text = title;

            StringBuilder str = Total();
            TableList = str.ToString();
            ScriptManager.RegisterStartupScript(this.rblProjectList, this.Page.GetType(), "rblProjectList", "dataBind('week')", true);
        }

        public StringBuilder Total()
        {
            var list = GetDataTotal("year", PageType.ToString(), this.rblProjectList.SelectedValue);
            if (list != null && list.Count > 0)
            {
                list = list.OrderBy(x => x.Date).ToList();
            }

            StringBuilder str = new StringBuilder();
            str.Append("<tr><th align='center' style='height:7%;'></th><th align='center' style='height:8%;'>1月</th><th align='center' style='height:8%;'>2月</th>"
                + "<th align='center' style='height:8%;'>3月</th><th align='center' style='height:8%;'>4月</th><th align='center' style='height:8%;'>5月</th>"
                + "<th align='center' style='height:8%;'>6月</th><th align='center' style='height:8%;'>7月</th><th align='center' style='height:8%;'>8月</th>"
                + "<th align='center' style='height:8%;'>9月</th><th align='center' style='height:7%;'>10月</th><th align='center' style='height:7%;'>11月</th>"
                + "<th align='center' style='height:7%;'>12月</th></tr>");

            str.Append("<tr><td align='center'>进货成本</td>");
            str.Append(MonthData("CountMoneySum4", list));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>赠品成本</td>");
            str.Append(MonthData("CountMoneySum24", list));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>刷拍成本</td>");
            str.Append(MonthData("CountMoneySum7", list));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>返现成本</td>");
            str.Append(MonthData("CountMoneySum8", list));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>广告费用</td>");
            str.Append(MonthData("CountMoneySumFEE", list));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>运费</td>");
            str.Append(MonthData("CountMoneySum6", list));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>平台成本</td>");
            str.Append(MonthData("CountMoneySum5", list));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>营业成本</td>");
            str.Append(MonthData("YYCBMonthMoney", list));
            str.Append("</tr>");

            return str;
        }

        public StringBuilder MonthData(string Group, List<OperatingCostData> List)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 1; i < 13; i++)
            {
                bool exist = false;
                foreach (OperatingCostData Info in List)
                {
                    string month = DateTime.Now.Year.ToString() + "/" + i.ToString().PadLeft(2, '0');
                    Type type = Info.GetType();
                    System.Reflection.PropertyInfo[] ps = type.GetProperties();
                    foreach (System.Reflection.PropertyInfo property in ps)
                    {
                        if (property.Name == Group && Info.Date == month)
                        {
                            a.Append("<td>" + property.GetValue(Info, null) + "</td>");
                            exist = true;
                            break;
                        }
                    }
                }
                if (!exist)
                {
                    a.Append("<td>0</td>");
                }
            }
            return a;
        }

        private List<OperatingCostData> GetDataTotal(string DateType, string PageType, string ProjectID)
        {
            List<OperatingCostData> list = new List<OperatingCostData>();
            string now = DateTime.Now.ToLongDateString();
            for (int i = 1; i <= DateTime.Now.Month; i++)
            {
                OperatingCostData Item = new OperatingCostData();
                Item.Date = DateTime.Now.Year + "/" + i.ToString().PadLeft(2, '0');
                list.Add(Item);
            }
            DateTime begin = DateTime.Parse(DateTime.Now.Year + "/01/01");
            DateTime end = DateTime.Parse(now).AddDays(1).AddSeconds(-1);
            if (ProjectID == "B2B" || ProjectID == "B2C")
            {
                list = B2BOrB2C(DateType, ProjectID, begin, end, list);
            }
            else
            {
                list = GetDayTotal(DateType, PageType, ProjectID, begin, end, list);
            }
            return list;
        }

        public List<OperatingCostData> B2BOrB2C(string DateType, string ProjectID, DateTime begin, DateTime end, List<OperatingCostData> List)
        {
            string format = "";
            if (DateType != "year")
            {
                format = "MM/dd";
            }
            else
            {
                format = "yyyy/MM";
            }

            //List<XMBusinessDataAll> list = new List<XMBusinessDataAll>();
            //if (ProjectID == "B2C")
            //{
            //    list = IoC.Resolve<IXMBusinessDataDetailService>().GetXMBusinessDataDetailListByDepID(63, begin, end);
            //}
            //else
            //{
            //    list = IoC.Resolve<IXMBusinessDataDetailService>().GetXMBusinessDataDetailListByDepID(297, begin, end);
            //}

            List<XMFinancialCapitalFlow> list = new List<XMFinancialCapitalFlow>();
            if (ProjectID == "B2B")
            {
                List<int?> BudgetTypeList = new List<int?> { 93, 94, 95, 96, 97, 99, 101, 100, 103, 105 };//营业费用FinancialFieldID
                list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTableB2BCByBudgetType(begin.ToString(), end.ToString(), 6, BudgetTypeList);
            }

            foreach (XMFinancialCapitalFlow info in list)
            {
                foreach (OperatingCostData item in List)
                {
                    if (((DateTime)info.Date).ToString(format) == item.Date)
                    {
                        item.YYCBMonthMoney = item.YYCBMonthMoney + (decimal)info.Amount;//营业成本
                    }
                }
            }
            return List;
        }

        public List<OperatingCostData> AddOfflineData(ref List<OperatingCostData> list, DateTime begin, DateTime end, string format, int project)
        {
            List<JDSelfModel> List = new List<JDSelfModel>();
            List<XMJDSaleRejectedProductDetail> RejectedList = new List<XMJDSaleRejectedProductDetail>();
            List<XMSaleReturnProductDetails> ReturnList = new List<XMSaleReturnProductDetails>();

            var wareHousesList = base.XMWareHousesService.GetXMWarehouseListByProjectId(project);
            List<int> WareHousesList = wareHousesList.Select(x => x.Id).ToList();
            List<int?> WarehousesList = WareHousesList.Select<int, int?>(q => Convert.ToInt32(q)).ToList();
            var SaleList = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryListJDSelf(begin, end, WareHousesList);//线下无订单的销售出库数据
            if (project == 2)
            {
                RejectedList = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListJDSelf(begin, end);//京东自营退货
            }
            else
            {
                ReturnList = base.XMSaleReturnProductDetailsService.GetXMSaleReturnProductDetailsListByDate(begin, end, WarehousesList);
            }
            var InventoryList = base.XMInventoryInfoService.GetXMInventoryInfoListByWfIds(WareHousesList);//京东自营库存

            GetJDProductsPriceList(ref List, SaleList, RejectedList, ReturnList, InventoryList, WareHousesList);

            for (int i = 0; i < list.Count; i++)
            {
                OperatingCostData Info = list[i];
                if (SaleList.Count > 0)
                {
                    foreach (XMSaleDeliveryProductDetails info in SaleList)
                    {
                        if (Info.Date == ((DateTime)info.XM_SaleDelivery.BizDt).ToString(format))
                        {
                            decimal cost = GetCost(List, info.XM_SaleDelivery.WareHouseId, info.PlatformMerchantCode);
                            Info.CountMoneySum4 += cost * decimal.Parse(info.SaleCount.ToString());
                            Info.YYCBMonthMoney += cost * decimal.Parse(info.SaleCount.ToString());
                        }
                    }
                }
                if (RejectedList.Count > 0)
                {
                    foreach (XMJDSaleRejectedProductDetail info in RejectedList)
                    {
                        if (Info.Date == ((DateTime)info.XM_JDSaleRejected.BizDt).ToString(format))
                        {
                            decimal cost = GetCost(List, -1, info.PlatformMerchantCode);
                            Info.CountMoneySum4 -= cost * decimal.Parse(info.RejectionCount.ToString());
                            Info.YYCBMonthMoney -= cost * decimal.Parse(info.RejectionCount.ToString());
                        }
                    }
                }
                if (ReturnList.Count > 0)
                {
                    foreach (XMSaleReturnProductDetails info in ReturnList)
                    {
                        if (Info.Date == ((DateTime)info.XM_SaleReturn.BizDt).ToString(format))
                        {
                            string PlatformMerchantCode = "";
                            if (info.DeliveryProductsDetailID != null)
                            {
                                var ProductDetail = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsById(info.DeliveryProductsDetailID.Value);
                                if (ProductDetail != null)
                                {
                                    PlatformMerchantCode = ProductDetail.PlatformMerchantCode;
                                }
                            }
                            decimal cost = GetCost(List, (int)info.XM_SaleReturn.WarehouseId, PlatformMerchantCode);
                            Info.CountMoneySum4 -= cost * decimal.Parse(info.RejectionProdcutsCount.ToString());
                            Info.YYCBMonthMoney -= cost * decimal.Parse(info.RejectionProdcutsCount.ToString());
                        }
                    }
                }
            }
            return list;
        }

        public decimal GetCost(List<JDSelfModel> List, int WareHouseId, string PlatformMerchantCode)
        {
            decimal cost = 0;
            var list = List.Where(x => (WareHouseId == -1 || x.WareHousesID == WareHouseId) && x.PlatformMerchantCode == PlatformMerchantCode).ToList();
            if (list != null && list.Count > 0)
            {
                cost = list[0].CostPrice;
            }

            return cost;
        }

        public void GetJDProductsPriceList(ref List<JDSelfModel> List, List<XMSaleDeliveryProductDetails> SaleList, List<XMJDSaleRejectedProductDetail> RejectedList
            , List<XMSaleReturnProductDetails> ReturnList, List<XMInventoryInfo> InventoryList, List<int> WareHousesList)
        {
            var StorageProductList = base.XMStorageProductDetailsService.GetXMStorageProductDetailsListByWareHousesList(WareHousesList);

            foreach (var sale in SaleList)
            {
                var exist = List.Where(x => x.WareHousesID == sale.XM_SaleDelivery.WareHouseId && x.PlatformMerchantCode == sale.PlatformMerchantCode).ToList();
                if (exist != null && exist.Count > 0)
                {
                    exist[0].SaleCount += (int)sale.SaleCount;
                }
                else
                {
                    JDSelfModel one = new JDSelfModel();
                    one.WareHousesID = sale.XM_SaleDelivery.WareHouseId;
                    one.PlatformMerchantCode = sale.PlatformMerchantCode;
                    one.SaleCount = (int)sale.SaleCount;
                    one.CostPrice = one.RejectedCount = one.InventoryCount = 0;
                    List.Add(one);
                }
            }
            foreach (var rejected in RejectedList)
            {
                var exist = List.Where(x => x.PlatformMerchantCode == rejected.PlatformMerchantCode).ToList();
                if (exist != null && exist.Count > 0)
                {
                    exist[0].RejectedCount += (int)rejected.RejectionCount;
                }
                else
                {
                    JDSelfModel one = new JDSelfModel();
                    one.WareHousesID = -1;
                    one.PlatformMerchantCode = rejected.PlatformMerchantCode;
                    one.RejectedCount = (int)rejected.RejectionCount;
                    one.CostPrice = one.SaleCount = one.InventoryCount = 0;
                    List.Add(one);
                }
            }
            foreach (var rejected in ReturnList)
            {
                string PlatformMerchantCode = "";
                if (rejected.DeliveryProductsDetailID != null)
                {
                    var ProductDetail = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsById(rejected.DeliveryProductsDetailID.Value);
                    if (ProductDetail != null)
                    {
                        PlatformMerchantCode = ProductDetail.PlatformMerchantCode;
                    }
                }

                if (PlatformMerchantCode != "")
                {
                    var exist = List.Where(x => x.PlatformMerchantCode == PlatformMerchantCode && x.WareHousesID == rejected.XM_SaleReturn.WarehouseId).ToList();
                    if (exist != null && exist.Count > 0)
                    {
                        exist[0].RejectedCount += (int)rejected.RejectionProdcutsCount;
                    }
                    else
                    {
                        JDSelfModel one = new JDSelfModel();
                        one.WareHousesID = (int)rejected.XM_SaleReturn.WarehouseId; ;
                        one.PlatformMerchantCode = PlatformMerchantCode;
                        one.RejectedCount = (int)rejected.RejectionProdcutsCount;
                        one.CostPrice = one.SaleCount = one.InventoryCount = 0;
                        List.Add(one);
                    }
                }
            }
            foreach (var inventory in InventoryList)
            {
                var exist = List.Where(x => x.WareHousesID == inventory.WfId && x.PlatformMerchantCode == inventory.PlatformMerchantCode).ToList();
                if (exist != null && exist.Count > 0)
                {
                    exist[0].InventoryCount += (int)inventory.StockNumber;
                }
            }

            foreach (var Info in List)
            {
                if (Info.WareHousesID != -1)
                {
                    var exist = StorageProductList.Where(x => x.PlatformMerchantCode == Info.PlatformMerchantCode && x.XM_Storage.WareHouseId == Info.WareHousesID).ToList();
                    if (exist != null && exist.Count > 0)
                    {
                        decimal TotalMoney = 0;
                        int InventoryRejectedCount = Info.InventoryCount + Info.RejectedCount;
                        int SaleCount = Info.SaleCount;
                        foreach (var StorageProduct in exist)
                        {
                            if (InventoryRejectedCount >= StorageProduct.ProductsCount)
                            {
                                InventoryRejectedCount -= StorageProduct.ProductsCount;
                            }
                            else
                            {
                                int difference = StorageProduct.ProductsCount - InventoryRejectedCount;
                                InventoryRejectedCount = 0;
                                if (SaleCount > difference)
                                {
                                    SaleCount -= difference;
                                    TotalMoney += difference * StorageProduct.ProductsPrice;
                                }
                                else
                                {
                                    TotalMoney += SaleCount * StorageProduct.ProductsPrice;
                                    break;
                                }
                            }
                        }
                        Info.CostPrice = Math.Round(TotalMoney / decimal.Parse(Info.SaleCount.ToString()), 2);
                    }
                }
                else//销售出库中不存在的商品
                {
                    var exist = StorageProductList.Where(x => x.PlatformMerchantCode == Info.PlatformMerchantCode).ToList();
                    if (exist != null && exist.Count > 0)
                    {
                        Info.CostPrice = exist[0].ProductsPrice;
                    }
                    else
                    {
                        Info.CostPrice = 0;
                    }
                }
            }
        }

        private List<OperatingCostData> GetDayTotal(string DateType, string PageType, string ProjectID, DateTime begin, DateTime end, List<OperatingCostData> list)
        {
            #region 条件查询

            //平台类型
            string PlatformTypeId = "-1";
            var min = begin;
            var max = end;

            //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
            var cbOrderStatusId = PageType;

            //项目类型： 自运营、代运营
            string cbXMProjectTypeId = "-1";

            //项目名称
            string cbXMProject = ProjectID;

            //店铺名称
            string cbNick = "-1";

            //店铺集合
            List<int> nickIdList = new List<int>();

            #region 店铺条件查询集合 处理

            //选择某项目  
            if (cbXMProject != "-1")
            {
                if (cbNick == "-1")//项目下的所有店铺
                {
                    var nickList = IoC.Resolve<IXMNickService>().GetXMNickListByProjectId(Convert.ToInt32(ProjectID), Convert.ToInt32(cbXMProjectTypeId));
                    if (nickList.Count > 0)
                    {
                        nickIdList = nickList.Select(p => p.nick_id).ToList();
                    }
                }
            }
            else
            {
                if (cbNick == "-1")
                {
                    var NickList = IoC.Resolve<IXMNickService>().GetXMNickListByProjectId(Convert.ToInt32(ProjectID), Convert.ToInt32(cbXMProjectTypeId));
                    nickIdList = NickList.Select(a => a.nick_id).ToList();
                }
            }
            #endregion

            #endregion

            string format = "";
            if (DateType != "year")
            {
                format = "MM/dd";
            }
            else
            {
                format = "yyyy/MM";
            }

            #region 利润数据

            //营业收入
            List<OrderInfoSalesDetails> CWProfitList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId), "");
            if (CWProfitList.Count > 0)
            {
                //CountMoneySum1 = CWProfitList.Sum(a => a.PayPrice == null ? 0 : a.PayPrice.Value);
                foreach (OperatingCostData Info in list)
                {
                    foreach (OrderInfoSalesDetails info in CWProfitList)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum1 = Info.CountMoneySum1 + (info.PayPrice == null ? 0 : info.PayPrice.Value);
                        }
                    }
                }
            }

            //退款金额
            List<int?> NickIdList = new List<int?>();
            foreach (int nick in nickIdList)
            {
                NickIdList.Add(nick);
            }
            List<XMApplication> xmConsultation = IoC.Resolve<IXMApplicationService>().GetXMConsultationListByData(Convert.ToInt32(PlatformTypeId), NickIdList, "", (DateTime?)min, (DateTime?)max, Convert.ToInt32(cbOrderStatusId));
            if (xmConsultation.Count > 0)
            {
                //CountReturnMoneySum = xmConsultation.Sum(a => a.Amount == null ? 0 : a.Amount.Value);
                foreach (OperatingCostData Info in list)
                {
                    foreach (XMApplication info in xmConsultation)
                    {
                        if (Info.Date == ((DateTime)info.FinishTime).ToString(format))
                        {
                            Info.CountReturnMoneySum = Info.CountReturnMoneySum + (info.Amount == null ? 0 : info.Amount.Value);

                            //退货成本
                            var ReturnList = IoC.Resolve<IXMApplicationExchangeService>().GetXMApplicationExchangeByAppID(info.ID, 0, 1, 2);
                            if (ReturnList != null && ReturnList.Count > 0)
                            {
                                foreach (XMApplicationExchange item in ReturnList)
                                {
                                    if (item.IsApplication == 2)
                                    {
                                        //CountReturnCostSum += item.FactoryPrice == null ? 0 : item.FactoryPrice.Value;
                                        Info.CountReturnCostSum += (item.FactoryPrice == null ? 0 : item.FactoryPrice.Value);
                                    }
                                    else if (item.IsApplication == 1)
                                    {
                                        //CountReturnCostSum -= item.FactoryPrice == null ? 0 : item.FactoryPrice.Value;
                                        Info.CountReturnCostSum -= (item.FactoryPrice == null ? 0 : item.FactoryPrice.Value);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //进货成本
            List<OrderInfoSalesDetails> CWJinList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetOrderInfoSalesDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
            if (CWJinList.Count > 0)
            {
                //CountMoneySum4 = CWJinList.Sum(a => a.FactoryPrice == null ? 0 : a.FactoryPrice.Value);
                foreach (OperatingCostData Info in list)
                {
                    foreach (OrderInfoSalesDetails info in CWJinList)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum4 = Info.CountMoneySum4 + (info.FactoryPrice == null ? 0 : info.FactoryPrice.Value);
                        }
                    }
                }
            }

            //赠品成本
            List<OrderInfoSalesDetails> CWZengList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoAndPremiumsDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
            if (CWZengList.Count > 0)
            {
                //CountMoneySum24 = CWZengList.Sum(a => a.FactoryPrice == null ? 0 : a.FactoryPrice.Value);
                foreach (OperatingCostData Info in list)
                {
                    foreach (OrderInfoSalesDetails info in CWZengList)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum24 = Info.CountMoneySum24 + (info.FactoryPrice == null ? 0 : info.FactoryPrice.Value);
                        }
                    }
                }
            }

            //刷拍成本
            List<OrderInfoSalesDetails> CWShuaList = IoC.Resolve<IXMScalpingService>().GetXMScalpingDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
            if (CWShuaList.Count > 0)
            {
                //刷拍佣金Fee 刷拍成本=刷拍佣金+扣点金额
                //CountMoneySum7 = Math.Round(CWShuaList.Sum(a => a.OrderPrice == null ? 0 : a.OrderPrice.Value), 2);
                foreach (OperatingCostData Info in list)
                {
                    foreach (OrderInfoSalesDetails info in CWShuaList)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum7 = Info.CountMoneySum7 + (info.OrderPrice == null ? 0 : info.OrderPrice.Value);
                        }
                    }
                }
            }

            //返现成本
            List<OrderInfoSalesDetails> CWFanList = IoC.Resolve<IXMCashBackApplicationService>().GetXMCashBackApplicationDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(StatusEnum.AlreadyCashBack), Convert.ToInt32(cbOrderStatusId));
            if (CWFanList.Count > 0)
            {
                //CountMoneySum8 = CWFanList.Sum(a => a.CashBackMoney == null ? 0 : a.CashBackMoney.Value);
                foreach (OperatingCostData Info in list)
                {
                    foreach (OrderInfoSalesDetails info in CWFanList)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum8 = Info.CountMoneySum8 + (info.CashBackMoney == null ? 0 : info.CashBackMoney.Value);
                        }
                    }
                }
            }
            //广告费用
            //List<XMAdvertisingFee> CWFeeList = IoC.Resolve<IXMAdvertisingFeeService>().GetXMXMAdvertisingFeeByDetails(nickIdList, min, max);
            List<XMFinancialCapitalFlow> FeeList = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTable(min.ToString(), max.ToString(), -1, int.Parse(ProjectID), 148);
            if (FeeList.Count > 0)
            {
                //CountMoneySumFEE = CWFeeList.Sum(a => a.Fee == null ? 0 : a.Fee.Value);
                foreach (OperatingCostData Info in list)
                {
                    foreach (XMFinancialCapitalFlow info in FeeList)
                    {
                        if (Info.Date == ((DateTime)info.Date).ToString(format))
                        {
                            Info.CountMoneySumFEE = Info.CountMoneySumFEE + (info.Amount == null ? 0 : info.Amount.Value);
                        }
                    }
                }
            }

            #endregion

            #region 平台费用

            List<OrderInfoSalesDetails> CWPlatformSpendingList = IoC.Resolve<IXMOrderInfoService>().GetCWPlatformSpendingSearchListSSS(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));

            if (CWPlatformSpendingList.Count > 0)
            {
                //CountMoneySum5 = decimal.Round(CWPlatformSpendingList.Select(p => p.PayPrice.Value).Sum(), 2);
                foreach (OperatingCostData Info in list)
                {
                    foreach (OrderInfoSalesDetails info in CWPlatformSpendingList)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum5 = Info.CountMoneySum5 + (info.PayPrice == null ? 0 : info.PayPrice.Value);
                        }
                    }
                }
            }

            #endregion

            AddOfflineData(ref list, begin, end, format, int.Parse(ProjectID));

            #region 运费
            if (cbXMProject != "-1")
            {
                //根据店铺项目 查询运费比例 
                var xmproject = IoC.Resolve<IXMProjectService>().GetXMProjectById(Convert.ToInt32(cbXMProject));
                if (xmproject != null)
                {
                    if (xmproject.ShipmentProportion != null)
                    {
                        decimal ShipmentProportion = xmproject.ShipmentProportion.Value / 100;

                        //CountMoneySum6 = Math.Round((CountMoneySum1 - CountReturnMoneySum) * ShipmentProportion, 2);
                        foreach (OperatingCostData Info in list)
                        {
                            Info.CountMoneySum6 = (Info.CountMoneySum1 - Info.CountReturnMoneySum) * ShipmentProportion;
                        }
                    }
                }
            }

            if (DateType == "year")
            {
                if (cbXMProject != "-1" || cbXMProject != "0")
                {
                    foreach (OperatingCostData Info in list)
                    {
                        string[] date = (Info.Date.Replace("/0", "/")).Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                        var staffspending = base.CWStaffSpendingService.GetCWStaffSpendingInfo(cbXMProject, -1, date[0], date[1], 108, 505);//108-》运费，505-》大家居事业部
                        if (staffspending != null)
                        {
                            Info.CountMoneySum6 = decimal.Parse(staffspending.CountMoney.ToString());
                        }
                    }
                }
            }

            //营业成本=进货成本+赠品成本+平台成本费用+运费+刷拍成本+返现成本
            //decimal YYCBMonthMoney = Convert.ToDecimal(CountMoneySum4 - CountReturnCostSum) + Convert.ToDecimal(CountMoneySum24) + CountMoneySum5 + CountMoneySum6 + Convert.ToDecimal(CountMoneySum7) + Convert.ToDecimal(CountMoneySum8);
            foreach (OperatingCostData Info in list)
            {
                Info.YYCBMonthMoney = Info.CountMoneySum4 - Info.CountReturnCostSum + Info.CountMoneySum24 + Info.CountMoneySum5 + Info.CountMoneySum6 + Info.CountMoneySum7 + Info.CountMoneySum8;
            }

            foreach (OperatingCostData Info in list)
            {
                Info.CountMoneySum1 = Math.Round(Info.CountMoneySum1, 2);
                Info.CountReturnMoneySum = Math.Round(Info.CountReturnMoneySum, 2);
                Info.CountMoneySum4 = Math.Round(Info.CountMoneySum4, 2);
                Info.CountReturnCostSum = Math.Round(Info.CountReturnCostSum, 2);
                Info.CountMoneySum24 = Math.Round(Info.CountMoneySum24, 2);
                Info.CountMoneySum7 = Math.Round(Info.CountMoneySum7, 2);
                Info.CountMoneySum8 = Math.Round(Info.CountMoneySum8, 2);
                Info.CountMoneySumFEE = Math.Round(Info.CountMoneySumFEE, 2);
                Info.CountMoneySum6 = Math.Round(Info.CountMoneySum6, 2);
                Info.YYCBMonthMoney = Math.Round(Info.YYCBMonthMoney, 2);
                Info.CountMoneySum5 = Math.Round(Info.CountMoneySum5, 2);
            }

            #endregion

            return list;
        }

        public int PageType
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
        }

        #endregion
    }
}