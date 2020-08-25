using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using HozestERP.BusinessLogic.Customers;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public class CompanyTool : System.Web.UI.Page
    {
        public List<OperatingCostData> OperatingCostDataList;
        public List<HighChart> managementFeeList;

        public List<HighChart> GetPieGraphData(List<HighChart> list, string type)
        {
            List<HighChart> List = new List<HighChart>();
            foreach (HighChart obj in list)
            {
                bool exist = false;
                for (int i = 0; i < List.Count; i++)
                {
                    HighChart Info = List[i];
                    if (type == "Group")
                    {
                        if (Info.Name == obj.Name && Info.Group == obj.Group)
                        {
                            Info.Group = obj.Group;
                            Info.Value = Info.Value + obj.Value;
                            List[i] = Info;
                            exist = true;
                            break;
                        }
                    }
                    else if (type == "Name")
                    {
                        if (Info.Name == obj.Name)
                        {
                            Info.Value = Info.Value + obj.Value;
                            List[i] = Info;
                            exist = true;
                            break;
                        }
                    }
                }
                if (!exist && obj.Value != 0)
                {
                    HighChart hc = new HighChart();
                    hc.Name = obj.Name;
                    hc.Value = obj.Value;
                    hc.Group = obj.Group;
                    List.Add(hc);
                }
            }
            return List;
        }

        public List<HighChart> GetOneValue(List<HighChart> List, string Name, string Group, string StrType)
        {
            List<HighChart> ValueList = new List<HighChart>();
            if (StrType == "Name")
            {
                foreach (HighChart obj in List)
                {
                    if (obj.Name == Name)
                    {
                        HighChart hc = new HighChart();
                        hc.Name = obj.Name;
                        hc.Value = obj.Value;
                        hc.Group = obj.Group;
                        ValueList.Add(hc);
                    }
                }
            }
            else if (StrType == "GroupName")
            {
                foreach (HighChart obj in List)
                {
                    if (obj.Name == Name && obj.Group == Group)
                    {
                        HighChart hc = new HighChart();
                        hc.Name = obj.Name;
                        hc.Value = obj.Value;
                        hc.Group = obj.Group;
                        ValueList.Add(hc);
                    }
                }
            }
            else if (StrType == "Group")
            {
                foreach (HighChart obj in List)
                {
                    if (obj.Group == Group)
                    {
                        HighChart hc = new HighChart();
                        hc.Name = obj.Name;
                        hc.Value = obj.Value;
                        hc.Group = obj.Group;
                        ValueList.Add(hc);
                    }
                }
            }
            return ValueList;
        }

        public decimal GetItemValue(List<HighChart> list, string Name)
        {
            List<HighChart> List = GetPieGraphData(list, "Name");
            List<HighChart> ValueList = GetOneValue(List, Name, "", "Name");
            if (ValueList.Count == 0)
            {
                return 0;
            }
            else
            {
                decimal total = 0;
                foreach (HighChart obj in ValueList)
                {
                    total = total + obj.Value;
                }
                return total;
            }
        }

        public List<List<HighChart>> AddB2BC(List<List<HighChart>> AllDataList, string DateType, DateTime begin, DateTime end, string format, string ProjectId, string NickId)
        {
            List<HighChart> HighChartList = new List<HighChart>();
            List<HighChart> ManagementFeeNewList = new List<HighChart>();
            //List<XMBusinessDataAll> list = new List<XMBusinessDataAll>();
            List<XMFinancialCapitalFlow> list = new List<XMFinancialCapitalFlow>();
            List<OperatingCostData> CountMoneySum1B2BCList = new List<OperatingCostData>();
            foreach (OperatingCostData info in OperatingCostDataList)
            {
                OperatingCostData a = new OperatingCostData();
                a.Date = info.Date;
                a.CountMoneySum1 = 0;
                CountMoneySum1B2BCList.Add(a);
            }

            string[] arr = { "B2B", "B2C" };
            foreach (string ProjectID in arr)
            {
                if ((ProjectId == "-1" && NickId == "-1") || ProjectId == ProjectID)
                {
                    if (ProjectID == "B2C")
                    {
                        //list = IoC.Resolve<IXMBusinessDataDetailService>().GetXMBusinessDataDetailListByDepID(63, begin, end);
                        list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTableB2BCByReceivablesType(begin.ToString(), end.ToString(), 197, 645);//B2C服务收入
                    }
                    else
                    {
                        //list = IoC.Resolve<IXMBusinessDataDetailService>().GetXMBusinessDataDetailListByDepID(297, begin, end);
                        list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTableB2BCByReceivablesType(begin.ToString(), end.ToString(), 6, -1);
                        List<int?> BudgetTypeList = new List<int?> { 93, 94, 95, 96, 97, 99, 101, 100, 103, 105 };//营业费用FinancialFieldID
                        var budgetTypeList = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTableB2BCByBudgetType(begin.ToString(), end.ToString(), 6, BudgetTypeList);
                        list.AddRange(budgetTypeList);
                    }

                    if (ProjectId == ProjectID && (DateType == "year" || DateType == "custom_year"))
                    {
                        #region 营业费用

                        foreach (OperatingCostData Info in OperatingCostDataList)
                        {
                            string[] date = Info.Date.Replace("/0", "/").Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                            Info.ManagementFee = GetValue(ProjectId, 70, date[0], date[1]);
                            HighChart one = new HighChart();
                            one.Name = ProjectID;
                            one.Value = Info.ManagementFee;
                            one.Group = Info.Date;
                            ManagementFeeNewList.Add(one);
                        }
                        #endregion
                    }

                    foreach (XMFinancialCapitalFlow info in list)
                    {
                        HighChart one = new HighChart();
                        one.Name = ProjectID;
                        one.Group = ((DateTime)info.Date).ToString(format);

                        HighChart exist = HighChartList.Find((x) => { return x.Group == one.Group; });
                        if (exist != null)
                        {
                            if (info.IsIncome == false)//支出
                            {
                                exist.Value -= (decimal)info.Amount;
                            }
                            else if (info.IsIncome == true)//收入
                            {
                                exist.Value += (decimal)info.Amount;
                            }
                        }
                        else
                        {
                            if (info.IsIncome == false)//支出
                            {
                                one.Value = -(decimal)info.Amount;
                            }
                            else if (info.IsIncome == true)//收入
                            {
                                one.Value = (decimal)info.Amount;
                            }
                            else
                            {
                                continue;
                            }
                            HighChartList.Add(one);
                        }
                    }

                    HighChartList = GetPieGraphData(HighChartList, "Group");

                    #region 营业成本,营业收入

                    foreach (XMFinancialCapitalFlow info in list)
                    {
                        for (int i = 0; i < OperatingCostDataList.Count; i++)
                        {
                            OperatingCostData item = OperatingCostDataList[i];
                            if (((DateTime)info.Date).ToString(format) == item.Date)
                            {
                                if (info.IsIncome == false)//支出
                                {
                                    item.YYCBMonthMoney = item.YYCBMonthMoney + (decimal)info.Amount;//营业成本

                                    HighChart one = new HighChart();
                                    one.Name = ProjectID;
                                    one.Group = item.Date;
                                    one.Value = (decimal)info.Amount;
                                    if (AllDataList != null)
                                    {
                                        AllDataList[2].Add(one);
                                    }
                                }
                                else if (info.IsIncome == true)//收入
                                {
                                    item.CountMoneySum1 = item.CountMoneySum1 + (decimal)info.Amount;//营业收入
                                    CountMoneySum1B2BCList[i].CountMoneySum1 = CountMoneySum1B2BCList[i].CountMoneySum1 + (decimal)info.Amount;//营业收入

                                    HighChart one = new HighChart();
                                    one.Name = ProjectID;
                                    one.Group = item.Date;
                                    one.Value = (decimal)info.Amount;
                                    if (AllDataList != null)
                                    {
                                        AllDataList[1].Add(one);
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region 增值税,毛利,//税前利润

                    foreach (HighChart info in HighChartList)
                    {
                        for (int i = 0; i < OperatingCostDataList.Count; i++)
                        {
                            OperatingCostData item = OperatingCostDataList[i];
                            if (info.Group == item.Date)
                            {
                                decimal ZZSMonthMoney = Math.Round((info.Value / (decimal)1.06) * (decimal)0.06, 2);//增值税
                                item.ZZSMonthMoney += ZZSMonthMoney;//增值税
                                decimal MLMonthMoney = Math.Round((info.Value - ZZSMonthMoney), 2); //毛利
                                item.MLMonthMoney += MLMonthMoney; //毛利
                                decimal ManagementFee = GetOneValue(ManagementFeeNewList, info.Name, info.Group, "GroupName").Sum(x => x.Value);
                                decimal YYSJMonthMoney = Math.Round(ZZSMonthMoney * (decimal)0.12 + CountMoneySum1B2BCList[i].CountMoneySum1 / (decimal)1.17 * (decimal)0.001, 2);//营业税金及附加
                                item.YYSJMonthMoney += YYSJMonthMoney;//营业税金及附加
                                item.SQLRMonthMoney += Math.Round((MLMonthMoney - ManagementFee - YYSJMonthMoney), 2); //税前利润

                                HighChart one = new HighChart();
                                one.Name = ProjectID;
                                one.Group = item.Date;
                                one.Value = ZZSMonthMoney;
                                if (AllDataList != null)
                                {
                                    AllDataList[4].Add(one);
                                }

                                HighChart two = new HighChart();
                                two.Name = ProjectID;
                                two.Group = item.Date;
                                two.Value = MLMonthMoney;
                                if (AllDataList != null)
                                {
                                    AllDataList[5].Add(two);
                                }
                            }
                        }
                    }
                    #endregion
                }
            }
            if (AllDataList != null)
            {
                AllDataList[3] = GetPieGraphData(AllDataList[3], "Name");
                AllDataList[2] = GetPieGraphData(AllDataList[2], "Name");
                AllDataList[1] = GetPieGraphData(AllDataList[1], "Name");
                AllDataList[4] = GetPieGraphData(AllDataList[4], "Name");
                AllDataList[5] = GetPieGraphData(AllDataList[5], "Name");
            }

            return AllDataList;
        }

        public List<List<HighChart>> AddOfflineData(List<List<HighChart>> CacheList, DateTime begin, DateTime end, string format, List<int> nickIdList, bool IsProject, List<OperatingCostData> list)
        {
            string name = "线下无订单数据";

            List<JDSelfModel> List = new List<JDSelfModel>();
            List<XMJDSaleRejectedProductDetail> RejectedList = new List<XMJDSaleRejectedProductDetail>();
            List<XMSaleReturnProductDetails> ReturnList = new List<XMSaleReturnProductDetails>();

            var wareHousesList = IoC.Resolve<IXMWareHousesService>().GetXMWarehouseListByNickIds(nickIdList);
            List<int> WareHousesList = wareHousesList.Select(x => x.Id).ToList();
            List<int?> WarehousesList = WareHousesList.Select<int, int?>(q => Convert.ToInt32(q)).ToList();
            var SaleList = IoC.Resolve<IXMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryListJDSelf(begin, end, WareHousesList);//线下无订单的销售出库数据
            if (nickIdList.Contains(29))
            {
                RejectedList = IoC.Resolve<IXMJDSaleRejectedProductDetailService>().GetXMJDSaleRejectedProductDetailListJDSelf(begin, end);//京东自营退货
            }
            if ((nickIdList.Contains(29) && nickIdList.Count > 1) || !nickIdList.Contains(29))
            {
                ReturnList = IoC.Resolve<IXMSaleReturnProductDetailsService>().GetXMSaleReturnProductDetailsListByDate(begin, end, WarehousesList);
            }
            var InventoryList = IoC.Resolve<IXMInventoryInfoService>().GetXMInventoryInfoListByWfIds(WareHousesList);

            for (int i = 0; i < list.Count; i++)
            {
                OperatingCostData Info = list[i];
                if (SaleList.Count > 0)
                {
                    foreach (XMSaleDeliveryProductDetails info in SaleList)
                    {
                        if (Info.Date == ((DateTime)info.XM_SaleDelivery.BizDt).ToString(format))
                        {
                            Info.CountMoneySum1 += (decimal)(info.ProductMoney == null ? 0 : info.ProductMoney);

                            HighChart one = new HighChart();
                            one.Name = name;
                            one.Group = Info.Date;
                            one.Value = (decimal)(info.ProductMoney == null ? 0 : info.ProductMoney);
                            if (CacheList != null && CacheList.Count > 0)
                            {
                                CacheList[0].Add(one);
                            }
                        }
                    }
                }
                if (RejectedList.Count > 0)
                {
                    foreach (XMJDSaleRejectedProductDetail info in RejectedList)
                    {
                        if (Info.Date == ((DateTime)info.XM_JDSaleRejected.BizDt).ToString(format))
                        {
                            Info.CountMoneySum1 -= (decimal)(info.RejectionMoney == null ? 0 : info.RejectionMoney);

                            HighChart one = new HighChart();
                            one.Name = name;
                            one.Group = Info.Date;
                            one.Value = -(decimal)(info.RejectionMoney == null ? 0 : info.RejectionMoney);
                            if (CacheList != null && CacheList.Count > 0)
                            {
                                CacheList[0].Add(one);
                            }
                        }
                    }
                }
                if (ReturnList.Count > 0)
                {
                    foreach (XMSaleReturnProductDetails info in ReturnList)
                    {
                        if (Info.Date == ((DateTime)info.XM_SaleReturn.BizDt).ToString(format))
                        {
                            Info.CountMoneySum1 -= (decimal)(info.RejectionsaleMoney == null ? 0 : info.RejectionsaleMoney);

                            HighChart one = new HighChart();
                            one.Name = name;
                            one.Group = Info.Date;
                            one.Value = -(decimal)(info.RejectionsaleMoney == null ? 0 : info.RejectionsaleMoney);
                            if (CacheList != null && CacheList.Count > 0)
                            {
                                CacheList[0].Add(one);
                            }
                        }
                    }
                }
            }

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

                            HighChart one = new HighChart();
                            one.Name = name;
                            one.Group = Info.Date;
                            one.Value = cost * decimal.Parse(info.SaleCount.ToString());
                            if (CacheList != null && CacheList.Count > 0)
                            {
                                CacheList[1].Add(one);
                            }
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

                            HighChart one = new HighChart();
                            one.Name = name;
                            one.Group = Info.Date;
                            one.Value = -cost * decimal.Parse(info.RejectionCount.ToString());
                            if (CacheList != null && CacheList.Count > 0)
                            {
                                CacheList[1].Add(one);
                            }
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
                                var ProductDetail = IoC.Resolve<IXMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryProductDetailsById(info.DeliveryProductsDetailID.Value);
                                if (ProductDetail != null)
                                {
                                    PlatformMerchantCode = ProductDetail.PlatformMerchantCode;
                                }
                            }
                            decimal cost = GetCost(List, (int)info.XM_SaleReturn.WarehouseId, PlatformMerchantCode);
                            Info.CountMoneySum4 -= cost * decimal.Parse(info.RejectionProdcutsCount.ToString());

                            HighChart one = new HighChart();
                            one.Name = name;
                            one.Group = Info.Date;
                            one.Value = -cost * decimal.Parse(info.RejectionProdcutsCount.ToString());
                            if (CacheList != null && CacheList.Count > 0)
                            {
                                CacheList[1].Add(one);
                            }
                        }
                    }
                }
            }

            OperatingCostDataList = list;
            return CacheList;
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
            var StorageProductList = IoC.Resolve<IXMStorageProductDetailsService>().GetXMStorageProductDetailsListByWareHousesList(WareHousesList);

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
                    var ProductDetail = IoC.Resolve<IXMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryProductDetailsById(rejected.DeliveryProductsDetailID.Value);
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
                        if (Info.SaleCount == 0) 
                        {
                            Info.CostPrice = 0;
                        }
                        else
                        {
                            Info.CostPrice = Math.Round(TotalMoney / decimal.Parse(Info.SaleCount.ToString()), 2);
                        }
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

        public void GetDayTotal(string DateType, string PageType, DateTime begin, DateTime end, List<OperatingCostData> list, string format, string Year, string ProjectId, string NickId, string from = "picture")
        {
            List<List<HighChart>> AllDataList = new List<List<HighChart>>();
            List<HighChart> CountMoneySum1List = new List<HighChart>();  //营业收入
            List<HighChart> CountReturnMoneySumList = new List<HighChart>();  //退款金额
            List<HighChart> CountMoneySum4List = new List<HighChart>();  //进货成本
            List<HighChart> CountReturnCostSumList = new List<HighChart>();  //退货成本
            List<HighChart> CountMoneySum24List = new List<HighChart>();  //赠品成本
            List<HighChart> CountMoneySum7List = new List<HighChart>();  //刷拍成本
            List<HighChart> CountMoneySum8List = new List<HighChart>();  //返现成本
            List<HighChart> CountMoneySumFEEList = new List<HighChart>();  //广告费用
            List<HighChart> CountMoneySum6List = new List<HighChart>();  //运费    
            List<HighChart> YYCBMonthMoneyList = new List<HighChart>();  //营业成本
            List<HighChart> CountMoneySum5List = new List<HighChart>();  //平台成本
            List<HighChart> MLMonthMoneyList = new List<HighChart>();  //毛利    
            List<HighChart> ZZSMonthMoneyList = new List<HighChart>();  //增值税  
            List<HighChart> ManagementFeeList = new List<HighChart>();  //营业费用
            List<HighChart> CountMoneySum55List = new List<HighChart>();  //平台成本
            List<HighChart> CountMoneySum21List = new List<HighChart>();  //广告费补
            List<HighChart> YYSJMonthMoneyList = new List<HighChart>();  //营业税金
            List<HighChart> SQLRMonthMoneyList = new List<HighChart>();  //税前利润
            List<HighChart> ZJRGMonthMoneyList = new List<HighChart>();  //直接人工
            List<HighChart> TargetSumList = new List<HighChart>();  //目标

            bool IsProject = false;//有具体项目，无具体店铺
            if (ProjectId != "-1" && NickId == "-1")
            {
                IsProject = true;
            }

            List<HighChart> ProjectList = new List<HighChart>();
            if (IsProject)
            {
                var Nick = IoC.Resolve<IXMNickService>().GetXMNickListByProjectId(int.Parse(ProjectId));
                if (Nick.Count > 0)
                {
                    foreach (XMNick info in Nick)
                    {
                        HighChart one = new HighChart();
                        one.Name = info.nick;
                        one.Group = info.nick_id.ToString();
                        ProjectList.Add(one);
                    }
                }
            }
            else
            {
                var Project = IoC.Resolve<IXMProjectService>().GetXMProjectList();
                if (Project.Count > 0)
                {
                    foreach (XMProject info in Project)
                    {
                        HighChart one = new HighChart();
                        one.Name = info.ProjectName;
                        one.Group = info.Id.ToString();
                        ProjectList.Add(one);
                    }
                }
            }

            #region 条件查询

            //平台类型
            string PlatformTypeId = "-1";

            //开始日期
            var min = begin;

            //结束日期
            var max = end;

            //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
            var cbOrderStatusId = PageType;

            //项目类型： 自运营、代运营
            string cbXMProjectTypeId = "362";//自运营

            //项目名称
            string cbXMProject = ProjectId;

            //店铺集合
            List<int> nickIdList = new List<int>();

            #region 店铺条件查询集合
            //选择某项目
            if (cbXMProject != "B2B" && cbXMProject != "B2C")
            {
                if (cbXMProject != "-1")
                {
                    if (NickId == "-1")//项目下的所有店铺
                    {
                        var nickList = IoC.Resolve<IXMNickService>().GetXMNickListByProjectId(Convert.ToInt32(cbXMProject), Convert.ToInt32(cbXMProjectTypeId));
                        if (nickList.Count > 0)
                        {
                            nickIdList = nickList.Select(p => p.nick_id).ToList();
                        }
                    }
                    else
                    {
                        nickIdList.Add(Convert.ToInt32(NickId));
                    }
                }
                else
                {
                    if (NickId == "-1")
                    {
                        var NickList = IoC.Resolve<IXMNickService>().GetXMNickListByProjectId(Convert.ToInt32(cbXMProject), Convert.ToInt32(cbXMProjectTypeId));
                        nickIdList = NickList.Select(a => a.nick_id).ToList();
                    }
                    else
                    {
                        nickIdList.Add(Convert.ToInt32(NickId));
                    }

                }
            }
            #endregion

            #endregion

            #region 目标

            if (DateType != "week")
            {
                if (NickId == "-1")
                {
                    if (DateType.IndexOf("year") != -1)
                    {
                        TargetSumList = GetProjectTarget(Year, "-1", ProjectId);
                    }
                    else if (DateType.IndexOf("month") != -1)
                    {
                        string Month = begin.Month.ToString();
                        TargetSumList = GetProjectTarget(Year, Month, ProjectId);
                    }
                }
                else
                {
                    var NickTargetList = IoC.Resolve<IXMNickMonthlyTargetService>().GetXMNickMonthlyTargetListByAudit(begin, end);
                    if (NickTargetList.Count > 0)
                    {
                        foreach (XMNickMonthlyTarget info in NickTargetList)
                        {
                            if (nickIdList.IndexOf(info.NickId) != -1)
                            {
                                HighChart one = new HighChart();
                                one.Name = info.NickName;
                                one.Value = info.TurnoverAmount;
                                TargetSumList.Add(one);
                            }
                        }
                    }
                    var OtherTargetList = IoC.Resolve<IXMOtherMonthlyTargetService>().GetXMOtherMonthlyTargetListByAudit(begin, end);
                    if (OtherTargetList.Count > 0)
                    {
                        foreach (XMOtherMonthlyTarget info in OtherTargetList)
                        {
                            HighChart one = new HighChart();
                            one.Value = info.Income;
                            if (info.DepartmentID == 297 && ((ProjectId == "-1" && NickId == "-1") || ProjectId == "B2B"))
                            {
                                one.Name = "B2B";
                                TargetSumList.Add(one);
                            }
                            else if (info.DepartmentID == 63 && ((ProjectId == "-1" && NickId == "-1") || ProjectId == "B2C"))
                            {
                                one.Name = "B2C";
                                TargetSumList.Add(one);
                            }
                        }
                    }
                    TargetSumList = GetPieGraphData(TargetSumList, "Name");
                }
            }

            #endregion

            if (ProjectId == "B2B" || ProjectId == "B2C")
            {
                AllDataList.Add(TargetSumList);
                AllDataList.Add(CountMoneySum1List);
                AllDataList.Add(YYCBMonthMoneyList);
                AllDataList.Add(ManagementFeeList);
                AllDataList.Add(ZZSMonthMoneyList);
                AllDataList.Add(MLMonthMoneyList);

                OperatingCostDataList = list;
                System.Web.HttpContext.Current.Session["HightChartsLine"] = OperatingCostDataList;

                AllDataList = AddB2BC(AllDataList, DateType, begin, end, format, ProjectId, NickId);
                System.Web.HttpContext.Current.Session["HightChartsPie"] = AllDataList;

                if (from == "Table")
                {
                    System.Web.HttpContext.Current.Session["Mark"] = DateType + "," + cbXMProject + "," + NickId;
                    System.Web.HttpContext.Current.Session["HightChartsLineYear"] = OperatingCostDataList;
                    System.Web.HttpContext.Current.Session["HightChartsPieYear"] = AllDataList;
                }

                return;
            }

            #region 营业收入

            List<OrderInfoSalesDetails> CWProfitList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId), "");
            if (CWProfitList.Count > 0)
            {
                //decimal CountMoneySum1 = CWProfitList.Sum(a => a.PayPrice == null ? 0 : a.PayPrice.Value);
                foreach (OrderInfoSalesDetails info in CWProfitList)
                {
                    foreach (OperatingCostData Info in list)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum1 = Info.CountMoneySum1 + (info.PayPrice == null ? 0 : info.PayPrice.Value);

                            HighChart one = new HighChart();
                            if (IsProject)
                            {
                                one.Name = info.NickName;
                            }
                            else
                            {
                                one.Name = info.ProjectName;
                            }
                            one.Group = Info.Date;
                            one.Value = (decimal)(info.PayPrice == null ? 0 : info.PayPrice.Value);
                            CountMoneySum1List.Add(one);
                        }
                    }
                }
            }

            #endregion

            #region 退款金额,退货成本

            List<int?> NickIdList = new List<int?>();
            foreach (int nick in nickIdList)
            {
                NickIdList.Add(nick);
            }
            List<XMApplication> xmConsultation = IoC.Resolve<IXMApplicationService>().GetXMConsultationListByData(Convert.ToInt32(PlatformTypeId), NickIdList, "", (DateTime?)min, (DateTime?)max, Convert.ToInt32(cbOrderStatusId));
            if (xmConsultation.Count > 0)
            {
                List<object> ObjList1 = new List<object>();
                //CountReturnMoneySum = xmConsultation.Sum(a => a.Amount == null ? 0 : a.Amount.Value);
                foreach (XMApplication info in xmConsultation)
                {
                    foreach (OperatingCostData Info in list)
                    {

                        if (Info.Date == ((DateTime)info.FinishTime).ToString(format))
                        {
                            Info.CountReturnMoneySum = Info.CountReturnMoneySum + (info.Amount == null ? 0 : info.Amount.Value);

                            HighChart one = new HighChart();
                            if (IsProject)
                            {
                                one.Name = info.NickName;
                            }
                            else
                            {
                                one.Name = info.ProjectName;
                            }
                            one.Group = Info.Date;
                            one.Value = (decimal)(info.Amount == null ? 0 : info.Amount.Value);
                            CountReturnMoneySumList.Add(one);

                            //退货成本
                            var ReturnList = IoC.Resolve<IXMApplicationExchangeService>().GetXMApplicationExchangeByAppID(info.ID, 0, 1, 2);
                            if (ReturnList != null && ReturnList.Count > 0)
                            {
                                foreach (XMApplicationExchange item in ReturnList)
                                {
                                    HighChart two = new HighChart();
                                    if (IsProject)
                                    {
                                        two.Name = info.NickName;
                                    }
                                    else
                                    {
                                        two.Name = info.ProjectName;
                                    }
                                    two.Group = Info.Date;

                                    if (item.IsApplication == 2)
                                    {
                                        //CountReturnCostSum += item.FactoryPrice == null ? 0 : item.FactoryPrice.Value;
                                        Info.CountReturnCostSum += (item.FactoryPrice == null ? 0 : item.FactoryPrice.Value);
                                        two.Value = (decimal)(item.FactoryPrice == null ? 0 : item.FactoryPrice.Value);
                                    }
                                    else if (item.IsApplication == 1)
                                    {
                                        //CountReturnCostSum -= item.FactoryPrice == null ? 0 : item.FactoryPrice.Value;
                                        Info.CountReturnCostSum -= (item.FactoryPrice == null ? 0 : item.FactoryPrice.Value);
                                        two.Value = -(decimal)(item.FactoryPrice == null ? 0 : item.FactoryPrice.Value);
                                    }
                                    CountReturnCostSumList.Add(two);
                                }
                            }
                        }
                    }
                }
            }

            CountReturnCostSumList = GetPieGraphData(CountReturnCostSumList, "Name");

            #endregion

            #region 进货成本

            List<OrderInfoSalesDetails> CWJinList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetOrderInfoSalesDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
            if (CWJinList.Count > 0)
            {
                //CountMoneySum4 = CWJinList.Sum(a => a.FactoryPrice == null ? 0 : a.FactoryPrice.Value);
                foreach (OrderInfoSalesDetails info in CWJinList)
                {
                    foreach (OperatingCostData Info in list)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum4 = Info.CountMoneySum4 + (info.FactoryPrice == null ? 0 : info.FactoryPrice.Value);
                            HighChart one = new HighChart();
                            if (IsProject)
                            {
                                one.Name = info.NickName;
                            }
                            else
                            {
                                one.Name = info.ProjectName;
                            }
                            one.Group = Info.Date;
                            one.Value = (decimal)(info.FactoryPrice == null ? 0 : info.FactoryPrice.Value);
                            CountMoneySum4List.Add(one);
                        }
                    }
                }
            }

            CountMoneySum4List = GetPieGraphData(CountMoneySum4List, "Name");

            #endregion

            #region 赠品成本

            List<OrderInfoSalesDetails> CWZengList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoAndPremiumsDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
            if (CWZengList.Count > 0)
            {
                //CountMoneySum24 = CWZengList.Sum(a => a.FactoryPrice == null ? 0 : a.FactoryPrice.Value);
                foreach (OrderInfoSalesDetails info in CWZengList)
                {
                    foreach (OperatingCostData Info in list)
                    {

                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum24 = Info.CountMoneySum24 + (info.FactoryPrice == null ? 0 : info.FactoryPrice.Value);

                            HighChart one = new HighChart();
                            if (IsProject)
                            {
                                one.Name = info.NickName;
                            }
                            else
                            {
                                one.Name = info.ProjectName;
                            }
                            one.Group = Info.Date;
                            one.Value = (decimal)(info.FactoryPrice == null ? 0 : info.FactoryPrice.Value);
                            CountMoneySum24List.Add(one);
                        }
                    }
                }
            }

            CountMoneySum24List = GetPieGraphData(CountMoneySum24List, "Name");

            #endregion

            #region 刷拍成本

            List<OrderInfoSalesDetails> CWShuaList = IoC.Resolve<IXMScalpingService>().GetXMScalpingDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
            if (CWShuaList.Count > 0)
            {
                //刷拍佣金Fee 刷拍成本=刷拍佣金+扣点金额
                //CountMoneySum7 = Math.Round(CWShuaList.Sum(a => a.OrderPrice == null ? 0 : a.OrderPrice.Value), 2);
                foreach (OrderInfoSalesDetails info in CWShuaList)
                {
                    foreach (OperatingCostData Info in list)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum7 = Info.CountMoneySum7 + (info.OrderPrice == null ? 0 : info.OrderPrice.Value);

                            HighChart one = new HighChart();
                            if (IsProject)
                            {
                                one.Name = info.NickName;
                            }
                            else
                            {
                                one.Name = info.ProjectName;
                            }
                            one.Group = Info.Date;
                            one.Value = (decimal)(info.OrderPrice == null ? 0 : info.OrderPrice.Value);
                            CountMoneySum7List.Add(one);
                        }
                    }
                }
            }

            CountMoneySum7List = GetPieGraphData(CountMoneySum7List, "Name");

            #endregion

            #region 返现成本

            List<OrderInfoSalesDetails> CWFanList = IoC.Resolve<IXMCashBackApplicationService>().GetXMCashBackApplicationDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(StatusEnum.AlreadyCashBack), Convert.ToInt32(cbOrderStatusId));
            if (CWFanList.Count > 0)
            {
                //CountMoneySum8 = CWFanList.Sum(a => a.CashBackMoney == null ? 0 : a.CashBackMoney.Value);
                foreach (OrderInfoSalesDetails info in CWFanList)
                {
                    foreach (OperatingCostData Info in list)
                    {

                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum8 = Info.CountMoneySum8 + (info.CashBackMoney == null ? 0 : info.CashBackMoney.Value);

                            HighChart one = new HighChart();
                            if (IsProject)
                            {
                                one.Name = info.NickName;
                            }
                            else
                            {
                                one.Name = info.ProjectName;
                            }
                            one.Group = Info.Date;
                            one.Value = (decimal)(info.CashBackMoney == null ? 0 : info.CashBackMoney.Value);
                            CountMoneySum8List.Add(one);
                        }
                    }
                }
            }

            CountMoneySum8List = GetPieGraphData(CountMoneySum8List, "Name");

            #endregion

            #region 广告费用

            //List<XMAdvertisingFee> CWFeeList = IoC.Resolve<IXMAdvertisingFeeService>().GetXMXMAdvertisingFeeByDetails(nickIdList, min, max);
            List<XMFinancialCapitalFlow> FeeList = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTable(min.ToString(), max.ToString(), -1, int.Parse(ProjectId), 148);
            if (FeeList.Count > 0 && IsProject)
            {
                //CountMoneySumFEE = CWFeeList.Sum(a => a.Fee == null ? 0 : a.Fee.Value);
                foreach (XMFinancialCapitalFlow info in FeeList)
                {
                    foreach (OperatingCostData Info in list)
                    {
                        if (Info.Date == ((DateTime)info.Date).ToString(format))
                        {
                            Info.CountMoneySumFEE = Info.CountMoneySumFEE + (info.Amount == null ? 0 : info.Amount.Value);

                            HighChart one = new HighChart();
                            if (IsProject)
                            {
                                continue;
                                one.Name = "";// info.NickName;
                            }
                            else
                            {
                                one.Name = info.ProjectName;
                            }
                            one.Group = Info.Date;
                            one.Value = (decimal)(info.Amount == null ? 0 : info.Amount.Value);
                            CountMoneySumFEEList.Add(one);
                        }
                    }
                }
            }

            CountMoneySumFEEList = GetPieGraphData(CountMoneySumFEEList, "Name");

            #endregion

            #region 平台费用

            List<OrderInfoSalesDetails> CWPlatformSpendingList = IoC.Resolve<IXMOrderInfoService>().GetCWPlatformSpendingSearchListSSS(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));

            if (CWPlatformSpendingList.Count > 0)
            {
                //CountMoneySum5 = decimal.Round(CWPlatformSpendingList.Select(p => p.PayPrice.Value).Sum(), 2);
                foreach (OrderInfoSalesDetails info in CWPlatformSpendingList)
                {
                    foreach (OperatingCostData Info in list)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum5 = Info.CountMoneySum5 + (info.PayPrice == null ? 0 : info.PayPrice.Value);

                            HighChart one = new HighChart();
                            if (IsProject)
                            {
                                one.Name = info.NickName;
                            }
                            else
                            {
                                one.Name = info.ProjectName;
                            }
                            one.Group = Info.Date;
                            one.Value = (decimal)(info.PayPrice == null ? 0 : info.PayPrice.Value);
                            CountMoneySum5List.Add(one);
                        }
                    }
                }
            }

            CountMoneySum5List = GetPieGraphData(CountMoneySum5List, "Name");

            #endregion

            List<List<HighChart>> CacheList = new List<List<HighChart>>();
            CacheList.Add(CountMoneySum1List);
            CacheList.Add(CountMoneySum4List);
            CacheList = AddOfflineData(CacheList, begin, end, format, nickIdList, IsProject, list);
            CountMoneySum1List = CacheList[0];
            CountMoneySum4List = CacheList[1];
            CountMoneySum1List = GetPieGraphData(CountMoneySum1List, "Name");
            CountMoneySum4List = GetPieGraphData(CountMoneySum4List, "Name");
            list = OperatingCostDataList;
            OperatingCostDataList = new List<OperatingCostData>();

            #region 运费

            CountMoneySum1List = GetPieGraphData(CountMoneySum1List, "Group");
            CountReturnMoneySumList = GetPieGraphData(CountReturnMoneySumList, "Group");
            List<HighChart> ReturnMoneySumList = new List<HighChart>();

            if (IsProject)
            {
                decimal ShipmentProportion = 0;
                var xmproject = IoC.Resolve<IXMProjectService>().GetXMProjectById(int.Parse(cbXMProject));
                if (xmproject != null)
                {
                    ShipmentProportion = (decimal)(xmproject.ShipmentProportion == null ? 0 : xmproject.ShipmentProportion) / 100;
                }
                foreach (HighChart obj in CountMoneySum1List)
                {
                    decimal value = 0;
                    HighChart one = new HighChart();
                    one.Name = obj.Name;
                    one.Group = obj.Group;
                    List<HighChart> OneValue = GetOneValue(CountReturnMoneySumList, one.Name, one.Group, "GroupName");
                    if (OneValue != null && OneValue.Count > 0)
                    {
                        value = OneValue[0].Value;
                        ReturnMoneySumList.Add(OneValue[0]);
                    }
                    one.Value = (obj.Value - value) * ShipmentProportion;
                    CountMoneySum6List.Add(one);
                }
            }
            else
            {
                foreach (HighChart obj in CountMoneySum1List)
                {
                    var xmproject = IoC.Resolve<IXMProjectService>().GetXMProjectByName(obj.Name.Trim());
                    if (xmproject != null)
                    {
                        decimal ShipmentProportion = (decimal)(xmproject.ShipmentProportion == null ? 0 : xmproject.ShipmentProportion) / 100;

                        decimal value = 0;
                        HighChart one = new HighChart();
                        one.Name = obj.Name;
                        one.Group = obj.Group;
                        List<HighChart> OneValue = GetOneValue(CountReturnMoneySumList, one.Name, one.Group, "GroupName");
                        if (OneValue != null && OneValue.Count > 0)
                        {
                            value = OneValue[0].Value;
                            ReturnMoneySumList.Add(OneValue[0]);
                        }
                        one.Value = (obj.Value - value) * ShipmentProportion;
                        CountMoneySum6List.Add(one);
                    }
                }
            }

            if (ReturnMoneySumList.Count < CountReturnMoneySumList.Count)
            {
                for (int i = 0; i < CountReturnMoneySumList.Count; i++)
                {
                    bool have = false;
                    for (int j = 0; j < ReturnMoneySumList.Count; j++)
                    {
                        HighChart obj = CountReturnMoneySumList[i];
                        HighChart OBJ = ReturnMoneySumList[j];
                        if (obj.Name == OBJ.Name && obj.Group == OBJ.Group && obj.Value == OBJ.Value)
                        {
                            have = true;
                            break;
                        }
                    }
                    if (!have)
                    {
                        decimal ShipmentProportion = 0;
                        HighChart obj = CountReturnMoneySumList[i];
                        if (IsProject)
                        {
                            var xmproject = IoC.Resolve<IXMProjectService>().GetXMProjectById(int.Parse(cbXMProject));
                            ShipmentProportion = (decimal)(xmproject.ShipmentProportion == null ? 0 : xmproject.ShipmentProportion) / 100;
                        }
                        else
                        {
                            var xmproject = IoC.Resolve<IXMProjectService>().GetXMProjectByName(obj.Name.Trim());
                            ShipmentProportion = (decimal)(xmproject.ShipmentProportion == null ? 0 : xmproject.ShipmentProportion) / 100;
                        }
                        if (ShipmentProportion != 0)
                        {
                            HighChart one = new HighChart();
                            one.Name = obj.Name;
                            one.Group = obj.Group;
                            one.Value = (0 - obj.Value) * ShipmentProportion;
                            CountMoneySum6List.Add(one);
                        }
                    }
                }
            }

            if ((DateType == "year" || DateType == "custom_year"))
            {
                foreach (OperatingCostData Info in list)
                {
                    decimal Value = 0;
                    string[] date = (Info.Date.Replace("/0", "/")).Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    if (cbXMProject != "-1" && NickId == "-1")
                    {
                        var staffspending = IoC.Resolve<ICWStaffSpendingService>().GetCWStaffSpendingInfo(cbXMProject, -1, date[0], date[1], 108, 505);//108-》运费，505-》大家居事业部
                        if (staffspending != null)
                        {
                            Value = decimal.Parse(staffspending.CountMoney.ToString());
                            Info.CountMoneySum6 = Value;
                        }
                    }

                    if (Value != 0)
                    {
                        List<string> NickName = GetPieGraphData(CountMoneySum1List, "Name").Select(x => x.Name).ToList();
                        for (int i = 0; i < NickName.Count; i++)
                        {
                            decimal value = 0;
                            if (IsProject)
                            {
                                decimal NickCountMoneySum1 = CountMoneySum1List.Where(x => x.Group == Info.Date).Where(x => x.Name == NickName[i]).Sum(x => x.Value);
                                value = Math.Round(Value * NickCountMoneySum1 / Info.CountMoneySum1, 2);
                            }
                            else
                            {
                                value = Value;
                            }
                            foreach (HighChart item in CountMoneySum6List)
                            {
                                if (item.Name == NickName[i] && item.Group == Info.Date)
                                {
                                    item.Value = value;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        decimal ShipmentProportion = 0;
                        var xmproject = IoC.Resolve<IXMProjectService>().GetXMProjectById(int.Parse(cbXMProject));
                        if (xmproject != null)
                        {
                            ShipmentProportion = (decimal)(xmproject.ShipmentProportion == null ? 0 : xmproject.ShipmentProportion) / 100;
                        }
                        Info.CountMoneySum6 = ShipmentProportion * (Info.CountMoneySum1 - Info.CountReturnMoneySum);
                    }
                }
            }

            CountMoneySum1List = GetPieGraphData(CountMoneySum1List, "Name");
            CountReturnMoneySumList = GetPieGraphData(CountReturnMoneySumList, "Name");

            //foreach (OperatingCostData Info in list)
            //{
            //    List<HighChart> OneValue = GetOneValue(CountMoneySum6List, "", Info.Date, "Group");
            //    if (OneValue != null && OneValue.Count > 0)
            //    {
            //        decimal total = 0;
            //        foreach (HighChart obj in OneValue)
            //        {
            //            total = total + obj.Value;
            //        }
            //        Info.CountMoneySum6 = total;
            //    }
            //}

            CountMoneySum6List = GetPieGraphData(CountMoneySum6List, "Name");

            #endregion

            #region 增值税,营业税金及附加

            //decimal ZZSMonthMoney = Math.Round((CountMoneySum1 - CountReturnMoneySum - (CountMoneySum4 - CountReturnCostSum)) / (decimal)1.17 * (decimal)0.17 - CountMoneySum6 / (decimal)1.06 * (decimal)0.06, 2);
            foreach (OperatingCostData Info in list)
            {
                //增值税
                Info.ZZSMonthMoney = Math.Round((Info.CountMoneySum1 - Info.CountReturnMoneySum - (Info.CountMoneySum4 - Info.CountReturnCostSum)) / (decimal)1.17 * (decimal)0.17 - Info.CountMoneySum6 / (decimal)1.06 * (decimal)0.06, 2);

                //营业税金及附加=增值税*0.12+营业收入/1.17*0.001
                Info.YYSJMonthMoney = Math.Round(Info.ZZSMonthMoney * (decimal)0.12 + Info.CountMoneySum1 / (decimal)1.17 * (decimal)0.001, 2);
            }
            foreach (HighChart Info in ProjectList)
            {
                HighChart one = new HighChart();
                one.Name = Info.Name;
                one.Value = Math.Round((GetItemValue(CountMoneySum1List, one.Name) - GetItemValue(CountReturnMoneySumList, one.Name) - (GetItemValue(CountMoneySum4List, one.Name) - GetItemValue(CountReturnCostSumList, one.Name))) / (decimal)1.17 * (decimal)0.17 - GetItemValue(CountMoneySum6List, one.Name) / (decimal)1.06 * (decimal)0.06, 2);
                ZZSMonthMoneyList.Add(one);
            }

            ZZSMonthMoneyList = GetPieGraphData(ZZSMonthMoneyList, "Name");

            #endregion

            //营业成本=进货成本+赠品成本+平台成本费用+运费+刷拍成本+返现成本
            //decimal YYCBMonthMoney = Convert.ToDecimal(CountMoneySum4 - CountReturnCostSum) + Convert.ToDecimal(CountMoneySum24) + CountMoneySum5 + CountMoneySum6 + Convert.ToDecimal(CountMoneySum7) + Convert.ToDecimal(CountMoneySum8);
            foreach (OperatingCostData Info in list)
            {
                Info.YYCBMonthMoney = Info.CountMoneySum4 - Info.CountReturnCostSum + Info.CountMoneySum24 + Info.CountMoneySum5 + Info.CountMoneySum6 + Info.CountMoneySum7 + Info.CountMoneySum8;
            }
            foreach (HighChart Info in ProjectList)
            {
                HighChart one = new HighChart();
                one.Name = Info.Name;
                one.Value = GetItemValue(CountMoneySum4List, one.Name) - GetItemValue(CountReturnCostSumList, one.Name) + GetItemValue(CountMoneySum24List, one.Name) + GetItemValue(CountMoneySum5List, one.Name) + GetItemValue(CountMoneySum6List, one.Name) + GetItemValue(CountMoneySum7List, one.Name) + GetItemValue(CountMoneySum8List, one.Name);
                YYCBMonthMoneyList.Add(one);
            }

            YYCBMonthMoneyList = GetPieGraphData(YYCBMonthMoneyList, "Name");

            //毛利=营业收入-增值税-营业成本-广告费
            //decimal MLMonthMoney = Math.Round(CountMoneySum1 - CountReturnMoneySum - Convert.ToDecimal(this.lblZZSMonthMoney.Text) - Convert.ToDecimal(this.lblYYCBMonthMoney.Text) - Convert.ToDecimal(this.lblFEEMoney.Text), 2);
            foreach (OperatingCostData Info in list)
            {
                Info.MLMonthMoney = Math.Round(Info.CountMoneySum1 - Info.CountReturnMoneySum - Info.ZZSMonthMoney - Info.YYCBMonthMoney - Info.CountMoneySumFEE, 2);
            }
            foreach (HighChart Info in ProjectList)
            {
                HighChart one = new HighChart();
                one.Name = Info.Name;
                one.Value = Math.Round(GetItemValue(CountMoneySum1List, one.Name) - GetItemValue(CountReturnMoneySumList, one.Name) - GetItemValue(ZZSMonthMoneyList, one.Name) - GetItemValue(YYCBMonthMoneyList, one.Name) - GetItemValue(CountMoneySumFEEList, one.Name), 2);
                MLMonthMoneyList.Add(one);
            }

            MLMonthMoneyList = GetPieGraphData(MLMonthMoneyList, "Name");

            #region 营业费用
            if ((DateType == "year" || DateType == "custom_year") && NickId == "-1")
            {
                foreach (OperatingCostData Info in list)
                {
                    string[] date = Info.Date.Replace("/0", "/").Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                    //广告费补贴
                    Info.ManagementFee = GetValue(ProjectId, 70, date[0], date[1]);
                    if (ManagementFeeList.Count == 0)
                    {
                        ManagementFeeList = managementFeeList;
                    }
                    else
                    {
                        foreach (HighChart Item in ManagementFeeList)
                        {
                            foreach (HighChart item in managementFeeList)
                            {
                                if (Item.Name == item.Name)
                                {
                                    Item.Value += item.Value;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else if ((DateType == "month" || DateType == "custom_month") && NickId == "-1")
            {
                string Month = begin.Month.ToString();
                //广告费补贴
                decimal ManagementFee = GetValue(ProjectId, 70, Year, Month);
                if (ManagementFeeList.Count == 0)
                {
                    ManagementFeeList = managementFeeList;
                }
                else
                {
                    foreach (HighChart Item in ManagementFeeList)
                    {
                        foreach (HighChart item in managementFeeList)
                        {
                            if (Item.Name == item.Name)
                            {
                                Item.Value += item.Value;
                                break;
                            }
                        }
                    }
                }
            }

            #endregion

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

            #region 平台成本费用,广告费补贴,直接人工
            if ((DateType == "year" || DateType == "custom_year") && NickId == "-1")
            {
                foreach (OperatingCostData Info in list)
                {
                    string[] date = Info.Date.Replace("/0", "/").Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                    //广告费补贴
                    Info.CountMoneySum21 = GetValue(ProjectId, 71, date[0], date[1]);

                    //直接人工
                    decimal Value = 0;

                    for (int i = 0; i < 12; i++)
                    {
                        int SalaryYear = int.Parse(date[0]);
                        int SalaryMonth = int.Parse(date[1]);

                        if (DateTime.Parse(SalaryYear.ToString() + "/" + SalaryMonth.ToString() + "/01") >= DateTime.Now)
                        {
                            break;
                        }

                        if (SalaryMonth - i <= 0)
                        {
                            SalaryMonth = SalaryMonth + 12 - i;
                            SalaryYear--;
                        }
                        else
                        {
                            SalaryMonth = SalaryMonth - i;
                        }

                        Value = GetValue(ProjectId, 69, SalaryYear.ToString(), SalaryMonth.ToString());
                        if (Value != 0)
                        {
                            Info.ZJRGMonthMoney = Value;
                            break;
                        }
                    }
                }
            }
            #endregion

            #region 税前利润

            //税前利润=毛利-直接人工-营业费用-营业税金及附加-广告费补贴-平台其他费用
            foreach (OperatingCostData Info in list)
            {
                Info.SQLRMonthMoney = Math.Round(Info.MLMonthMoney - Info.ZJRGMonthMoney - Info.ManagementFee - Info.YYSJMonthMoney - Info.CountMoneySum21 - Info.CountMoneySum55, 2);
            }

            AllDataList.Add(TargetSumList);
            AllDataList.Add(CountMoneySum1List);
            AllDataList.Add(YYCBMonthMoneyList);
            AllDataList.Add(ManagementFeeList);
            AllDataList.Add(ZZSMonthMoneyList);
            AllDataList.Add(MLMonthMoneyList);

            OperatingCostDataList = list;
            AllDataList = AddB2BC(AllDataList, DateType, begin, end, format, ProjectId, NickId);

            System.Web.HttpContext.Current.Session["HightChartsLine"] = OperatingCostDataList;
            System.Web.HttpContext.Current.Session["HightChartsPie"] = AllDataList;

            if (from == "Table")
            {
                System.Web.HttpContext.Current.Session["Mark"] = DateType + "," + cbXMProject + "," + NickId;
                System.Web.HttpContext.Current.Session["HightChartsLineYear"] = OperatingCostDataList;
                System.Web.HttpContext.Current.Session["HightChartsPieYear"] = AllDataList;
            }

            #endregion

            //return AllDataList;
        }

        public void GetTableDayTotal(string DateType, string PageType, DateTime begin, DateTime end, List<OperatingCostData> list, string format, string Year, string ProjectId, string NickId)
        {
            #region 条件查询

            //平台类型
            string PlatformTypeId = "-1";

            //开始日期
            var min = begin;

            //结束日期
            var max = end;

            //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
            var cbOrderStatusId = PageType;

            //项目类型： 自运营、代运营
            string cbXMProjectTypeId = "362";//自运营

            //项目名称
            string cbXMProject = ProjectId;

            //店铺集合
            List<int> nickIdList = new List<int>();

            List<int> CountMoneySum6NickIdList = new List<int>();
            int cbXMProjectInt = 0;
            if (int.TryParse(cbXMProject, out cbXMProjectInt))
            {
                var countMoneySum6NickIdList = IoC.Resolve<IXMNickService>().GetXMNickListByProjectId(Convert.ToInt32(cbXMProject), Convert.ToInt32(cbXMProjectTypeId));
                CountMoneySum6NickIdList = countMoneySum6NickIdList.Select(a => a.nick_id).ToList();
            }

            if (cbXMProject == "B2B" || cbXMProject == "B2C")
            {
                OperatingCostDataList = list;
                AddB2BC(null, DateType, begin, end, format, ProjectId, NickId);
                System.Web.HttpContext.Current.Session["HightChartsLine"] = OperatingCostDataList;

                return;
            }

            #region 店铺条件查询集合
            //选择某项目
            if (cbXMProject != "B2B" && cbXMProject != "B2C")
            {
                if (cbXMProject != "-1")
                {
                    if (NickId == "-1")//项目下的所有店铺
                    {
                        var nickList = IoC.Resolve<IXMNickService>().GetXMNickListByProjectId(Convert.ToInt32(cbXMProject), Convert.ToInt32(cbXMProjectTypeId));
                        if (nickList.Count > 0)
                        {
                            nickIdList = nickList.Select(p => p.nick_id).ToList();
                        }
                    }
                    else
                    {
                        nickIdList.Add(Convert.ToInt32(NickId));
                    }
                }
                else
                {
                    if (NickId == "-1")
                    {
                        var NickList = IoC.Resolve<IXMNickService>().GetXMNickListByProjectId(Convert.ToInt32(cbXMProject), Convert.ToInt32(cbXMProjectTypeId));
                        nickIdList = NickList.Select(a => a.nick_id).ToList();
                    }
                    else
                    {
                        nickIdList.Add(Convert.ToInt32(NickId));
                    }

                }
            }
            #endregion

            #endregion

            #region 营业收入

            List<OrderInfoSalesDetails> CWProfitList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId), "");
            if (CWProfitList.Count > 0)
            {
                //decimal CountMoneySum1 = CWProfitList.Sum(a => a.PayPrice == null ? 0 : a.PayPrice.Value);
                foreach (OrderInfoSalesDetails info in CWProfitList)
                {
                    foreach (OperatingCostData Info in list)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum1 = Info.CountMoneySum1 + (info.PayPrice == null ? 0 : info.PayPrice.Value);
                        }
                    }
                }
            }
            #endregion

            #region 退款金额,退货成本

            List<int?> NickIdList = new List<int?>();
            foreach (int nick in nickIdList)
            {
                NickIdList.Add(nick);
            }
            List<XMApplication> xmConsultation = IoC.Resolve<IXMApplicationService>().GetXMConsultationListByData(Convert.ToInt32(PlatformTypeId), NickIdList, "", (DateTime?)min, (DateTime?)max, Convert.ToInt32(cbOrderStatusId));
            if (xmConsultation.Count > 0)
            {
                List<object> ObjList1 = new List<object>();
                //CountReturnMoneySum = xmConsultation.Sum(a => a.Amount == null ? 0 : a.Amount.Value);
                foreach (XMApplication info in xmConsultation)
                {
                    foreach (OperatingCostData Info in list)
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

            #endregion

            #region 进货成本

            List<OrderInfoSalesDetails> CWJinList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetOrderInfoSalesDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
            if (CWJinList.Count > 0)
            {
                //CountMoneySum4 = CWJinList.Sum(a => a.FactoryPrice == null ? 0 : a.FactoryPrice.Value);
                foreach (OrderInfoSalesDetails info in CWJinList)
                {
                    foreach (OperatingCostData Info in list)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum4 = Info.CountMoneySum4 + (info.FactoryPrice == null ? 0 : info.FactoryPrice.Value);
                        }
                    }
                }
            }

            #endregion

            #region 赠品成本

            List<OrderInfoSalesDetails> CWZengList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoAndPremiumsDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
            if (CWZengList.Count > 0)
            {
                //CountMoneySum24 = CWZengList.Sum(a => a.FactoryPrice == null ? 0 : a.FactoryPrice.Value);
                foreach (OrderInfoSalesDetails info in CWZengList)
                {
                    foreach (OperatingCostData Info in list)
                    {

                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum24 = Info.CountMoneySum24 + (info.FactoryPrice == null ? 0 : info.FactoryPrice.Value);
                        }
                    }
                }
            }

            #endregion

            #region 刷拍成本

            List<OrderInfoSalesDetails> CWShuaList = IoC.Resolve<IXMScalpingService>().GetXMScalpingDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
            if (CWShuaList.Count > 0)
            {
                //刷拍佣金Fee 刷拍成本=刷拍佣金+扣点金额
                //CountMoneySum7 = Math.Round(CWShuaList.Sum(a => a.OrderPrice == null ? 0 : a.OrderPrice.Value), 2);
                foreach (OrderInfoSalesDetails info in CWShuaList)
                {
                    foreach (OperatingCostData Info in list)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum7 = Info.CountMoneySum7 + (info.OrderPrice == null ? 0 : info.OrderPrice.Value);
                        }
                    }
                }
            }

            #endregion

            #region 返现成本

            List<OrderInfoSalesDetails> CWFanList = IoC.Resolve<IXMCashBackApplicationService>().GetXMCashBackApplicationDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(StatusEnum.AlreadyCashBack), Convert.ToInt32(cbOrderStatusId));
            if (CWFanList.Count > 0)
            {
                //CountMoneySum8 = CWFanList.Sum(a => a.CashBackMoney == null ? 0 : a.CashBackMoney.Value);
                foreach (OrderInfoSalesDetails info in CWFanList)
                {
                    foreach (OperatingCostData Info in list)
                    {

                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum8 = Info.CountMoneySum8 + (info.CashBackMoney == null ? 0 : info.CashBackMoney.Value);
                        }
                    }
                }
            }

            #endregion

            #region 广告费用

            //List<XMAdvertisingFee> CWFeeList = IoC.Resolve<IXMAdvertisingFeeService>().GetXMXMAdvertisingFeeByDetails(nickIdList, min, max);
            List<XMFinancialCapitalFlow> FeeList = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTable(min.ToString(), max.ToString(), -1, int.Parse(ProjectId), 148);
            if (FeeList.Count > 0 && NickId == "-1")
            {
                //CountMoneySumFEE = CWFeeList.Sum(a => a.Fee == null ? 0 : a.Fee.Value);
                foreach (XMFinancialCapitalFlow info in FeeList)
                {
                    foreach (OperatingCostData Info in list)
                    {
                        if (Info.Date == ((DateTime)info.Date).ToString(format))
                        {
                            if (NickId == "-1")
                            {
                                Info.CountMoneySumFEE = Info.CountMoneySumFEE + (info.Amount == null ? 0 : info.Amount.Value);
                            }
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
                foreach (OrderInfoSalesDetails info in CWPlatformSpendingList)
                {
                    foreach (OperatingCostData Info in list)
                    {
                        if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
                        {
                            Info.CountMoneySum5 = Info.CountMoneySum5 + (info.PayPrice == null ? 0 : info.PayPrice.Value);
                        }
                    }
                }
            }

            #endregion

            List<List<HighChart>> CacheList = new List<List<HighChart>>();
            AddOfflineData(CacheList, begin, end, format, nickIdList, false, list);
            list = OperatingCostDataList;
            OperatingCostDataList = new List<OperatingCostData>();

            #region 运费

            foreach (OperatingCostData Info in list)
            {
                decimal value = 0;
                if (DateType == "year" || DateType == "custom_year")
                {
                    string[] date = (Info.Date.Replace("/0", "/")).Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    if (cbXMProject != "-1")
                    {
                        var staffspending = IoC.Resolve<ICWStaffSpendingService>().GetCWStaffSpendingInfo(cbXMProject, -1, date[0], date[1], 108, 505);//108-》运费，505-》大家居事业部
                        if (staffspending != null)
                        {
                            if (NickId == "-1")
                            {
                                value = decimal.Parse(staffspending.CountMoney.ToString());
                                Info.CountMoneySum6 = value;
                            }
                            else
                            {
                                decimal ProjectValue = 1;
                                DateTime Begin = DateTime.Parse(Info.Date + "/01");
                                DateTime End = Begin.AddMonths(1);
                                List<OrderInfoSalesDetails> cWProfitList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoList(Convert.ToInt32(PlatformTypeId), CountMoneySum6NickIdList, Begin, End, Convert.ToInt32(cbOrderStatusId), "");
                                if (cWProfitList.Count > 0)
                                {
                                    ProjectValue = cWProfitList.Sum(a => a.PayPrice == null ? 0 : a.PayPrice.Value);
                                }

                                value = decimal.Parse(staffspending.CountMoney.ToString()) * Info.CountMoneySum1 / ProjectValue;
                                Info.CountMoneySum6 = value;
                            }
                        }
                    }
                }

                if (value == 0)
                {
                    if (ProjectId != "-1")
                    {
                        var xmproject = IoC.Resolve<IXMProjectService>().GetXMProjectById(int.Parse(ProjectId));
                        if (xmproject != null)
                        {
                            decimal ShipmentProportion = (decimal)(xmproject.ShipmentProportion == null ? 0 : xmproject.ShipmentProportion) / 100;
                            value = (Info.CountMoneySum1 - Info.CountReturnMoneySum) * ShipmentProportion;
                            Info.CountMoneySum6 = value;
                        }
                    }
                }
            }
            #endregion

            #region 增值税,营业税金及附加

            //decimal ZZSMonthMoney = Math.Round((CountMoneySum1 - CountReturnMoneySum - (CountMoneySum4 - CountReturnCostSum)) / (decimal)1.17 * (decimal)0.17 - CountMoneySum6 / (decimal)1.06 * (decimal)0.06, 2);
            foreach (OperatingCostData Info in list)
            {
                //增值税
                Info.ZZSMonthMoney = Math.Round((Info.CountMoneySum1 - Info.CountReturnMoneySum - (Info.CountMoneySum4 - Info.CountReturnCostSum)) / (decimal)1.17 * (decimal)0.17 - Info.CountMoneySum6 / (decimal)1.06 * (decimal)0.06, 2);

                //营业税金及附加=增值税*0.12+营业收入/1.17*0.001
                Info.YYSJMonthMoney = Math.Round(Info.ZZSMonthMoney * (decimal)0.12 + Info.CountMoneySum1 / (decimal)1.17 * (decimal)0.001, 2);
            }

            #endregion

            //营业成本=进货成本+赠品成本+平台成本费用+运费+刷拍成本+返现成本
            //decimal YYCBMonthMoney = Convert.ToDecimal(CountMoneySum4 - CountReturnCostSum) + Convert.ToDecimal(CountMoneySum24) + CountMoneySum5 + CountMoneySum6 + Convert.ToDecimal(CountMoneySum7) + Convert.ToDecimal(CountMoneySum8);
            foreach (OperatingCostData Info in list)
            {
                Info.YYCBMonthMoney = Info.CountMoneySum4 - Info.CountReturnCostSum + Info.CountMoneySum24 + Info.CountMoneySum5 + Info.CountMoneySum6 + Info.CountMoneySum7 + Info.CountMoneySum8;
            }

            //毛利=营业收入-增值税-营业成本-广告费
            //decimal MLMonthMoney = Math.Round(CountMoneySum1 - CountReturnMoneySum - Convert.ToDecimal(this.lblZZSMonthMoney.Text) - Convert.ToDecimal(this.lblYYCBMonthMoney.Text) - Convert.ToDecimal(this.lblFEEMoney.Text), 2);
            foreach (OperatingCostData Info in list)
            {
                Info.MLMonthMoney = Math.Round(Info.CountMoneySum1 - Info.CountReturnMoneySum - Info.ZZSMonthMoney - Info.YYCBMonthMoney - Info.CountMoneySumFEE, 2);
            }

            #region 营业费用
            if (NickId == "-1")
            {
                foreach (OperatingCostData Info in list)
                {
                    string[] date = Info.Date.Replace("/0", "/").Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                    //广告费补贴
                    Info.ManagementFee = GetValue(ProjectId, 70, date[0], date[1]);
                }
            }

            #endregion

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

            #region 广告费补贴,直接人工

            if (NickId == "-1")
            {
                foreach (OperatingCostData Info in list)
                {
                    string[] date = Info.Date.Replace("/0", "/").Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                    //广告费补贴
                    Info.CountMoneySum21 = GetValue(ProjectId, 71, date[0], date[1]);

                    //直接人工
                    decimal Value = 0;

                    for (int i = 0; i < 12; i++)
                    {
                        int SalaryYear = int.Parse(date[0]);
                        int SalaryMonth = int.Parse(date[1]);

                        if (DateTime.Parse(SalaryYear.ToString() + "/" + SalaryMonth.ToString() + "/01") >= DateTime.Now)
                        {
                            break;
                        }

                        if (SalaryMonth - i <= 0)
                        {
                            SalaryMonth = SalaryMonth + 12 - i;
                            SalaryYear--;
                        }
                        else
                        {
                            SalaryMonth = SalaryMonth - i;
                        }

                        Value = GetValue(ProjectId, 69, SalaryYear.ToString(), SalaryMonth.ToString());
                        if (Value != 0)
                        {
                            Info.ZJRGMonthMoney = Value;
                            break;
                        }
                    }
                }
            }
            #endregion

            #region 税前利润

            //税前利润=毛利-直接人工-营业费用-营业税金及附加-广告费补贴-平台其他费用
            foreach (OperatingCostData Info in list)
            {
                Info.SQLRMonthMoney = Math.Round(Info.MLMonthMoney - Info.ZJRGMonthMoney - Info.ManagementFee - Info.YYSJMonthMoney - Info.CountMoneySum21 - Info.CountMoneySum55, 2);
            }

            OperatingCostDataList = list;
            AddB2BC(null, DateType, begin, end, format, ProjectId, NickId);

            System.Web.HttpContext.Current.Session["HightChartsLine"] = OperatingCostDataList;

            #endregion
        }

        public decimal GetValue(string ProjectId, int FinancialFieldId, string Year, string Month)
        {
            decimal Value = 0;
            List<int> list = new List<int>();
            managementFeeList = new List<HighChart>();
            if (ProjectId == "-1")
            {
                List<string> ProjectIdList = GetProjectIdList();
                foreach (string Id in ProjectIdList)
                {
                    decimal value = GetProjectValue(Id, FinancialFieldId, Year, Month);
                    Value += value;
                    if (FinancialFieldId == 70)
                    {
                        HighChart one = new HighChart();
                        if (Id != "B2B" && Id != "B2C")
                        {
                            var Info = IoC.Resolve<IXMProjectService>().GetXMProjectById(int.Parse(Id));
                            one.Name = Info.ProjectName;
                        }
                        else
                        {
                            one.Name = Id;
                        }
                        one.Value = value;
                        managementFeeList.Add(one);
                    }
                }
            }
            else
            {
                decimal value = GetProjectValue(ProjectId, FinancialFieldId, Year, Month);
                Value += value;
                if (FinancialFieldId == 70)
                {
                    HighChart one = new HighChart();
                    if (ProjectId != "B2B" && ProjectId != "B2C")
                    {
                        var Info = IoC.Resolve<IXMProjectService>().GetXMProjectById(int.Parse(ProjectId));
                        one.Name = Info.ProjectName;
                    }
                    else
                    {
                        one.Name = ProjectId;
                    }
                    one.Value = value;
                    managementFeeList.Add(one);
                }
            }

            return Value;
        }

        public decimal GetProjectValue(string ProjectId, int FinancialFieldId, string Year, string Month)
        {
            int DepartmentId = -1;
            if (ProjectId == "B2B")
            {
                DepartmentId = 297;
                ProjectId = "-1";
            }
            else if (ProjectId == "B2C")
            {
                DepartmentId = 63;
                ProjectId = "-1";
            }

            decimal Value = GetFinancialFieldValue(ProjectId, DepartmentId, FinancialFieldId, Year, Month);
            return Value;
        }

        public decimal GetFinancialFieldValue(string ProjectId, int DepartmentId, int FinancialFieldId, string Year, string Month)
        {
            decimal Value = 0;
            int DepartmentType = -1;
            if (DepartmentId == 63)
            {
                DepartmentType = 197;
            }
            else if (DepartmentId == 297)
            {
                DepartmentType = 6;
            }
            List<int> List = GetProjectFinancialFieldList(int.Parse(ProjectId), DepartmentId, FinancialFieldId);
            foreach (int Id in List)
            {
                var Info = IoC.Resolve<ICWStaffSpendingService>().GetCWStaffSpendingInfo(ProjectId, -1, Year, Month, Id, DepartmentType);
                if (Info != null)
                {
                    Value += (decimal)Info.CountMoney;
                }
                else if (FinancialFieldId == 70)
                {
                    string Begin = Year + "-" + Month + "-01";
                    string End = DateTime.Parse(Year + "-" + Month + "-01").AddMonths(1).ToString();
                    var list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTable(Begin, End, DepartmentType, int.Parse(ProjectId), Id);
                    if (list.Count > 0)
                    {
                        Value += (decimal)list.Sum(x => x.Amount);
                    }
                }
            }
            return Value;
        }

        public List<int> GetFinancialFieldList(int FinancialFieldId)
        {
            List<int> List = new List<int>();
            var list = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldByParentID(FinancialFieldId);
            if (list.Count > 0)
            {
                List = list.Select(x => x.Id).ToList();
            }
            else
            {
                var info = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldById(FinancialFieldId);
                if (info != null)
                {
                    List.Add(info.Id);
                }
            }
            return List;
        }

        public List<int> GetProjectFinancialFieldList(int ProjectId, int DepartmentId, int FinancialFieldId)
        {
            XMIncludeFields Info = new XMIncludeFields();
            List<int> list = new List<int>();
            List<int> List = GetFinancialFieldList(FinancialFieldId);
            if (ProjectId != -1)
            {
                Info = IoC.Resolve<IXMIncludeFieldsService>().GetXMIncludeFieldsListByProjectID(ProjectId);
            }
            else
            {
                Info = IoC.Resolve<IXMIncludeFieldsService>().GetXMIncludeFieldsListByDepartmentID(DepartmentId);
            }
            if (Info != null)
            {
                string[] arr = Info.Fields.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string Item in arr)
                {
                    foreach (int item in List)
                    {
                        if (Item == item.ToString())
                        {
                            list.Add(item);
                            break;
                        }
                    }
                }
            }

            return list;
        }

        public List<string> GetProjectIdList()
        {
            List<string> list = new List<string>();
            List<int> List = new List<int>();
            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                var projectList = IoC.Resolve<IXMProjectService>().GetXMProjectList().Where(c => c.ProjectTypeId == 362);
                List = projectList.Select(x => x.Id).ToList();
            }
            else
            {
                var projectList = IoC.Resolve<IXMProjectService>().GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                List = projectList.Select(x => x.Id).ToList();
            }
            foreach (int info in List)
            {
                list.Add(info.ToString());
            }
            list.Add("B2B");
            list.Add("B2C");
            return list;
        }

        public List<HighChart> GetProjectTarget(string year, string month, string ProjectId)
        {
            List<HighChart> List = new List<HighChart>();
            if (ProjectId == "-1")
            {
                List<string> ProjectIdList = GetProjectIdList();
                foreach (string Id in ProjectIdList)
                {
                    decimal value = GetTarget(year, month, Id);
                    HighChart one = new HighChart();
                    if (Id != "B2B" && Id != "B2C")
                    {
                        var Info = IoC.Resolve<IXMProjectService>().GetXMProjectById(int.Parse(Id));
                        one.Name = Info.ProjectName;
                    }
                    else
                    {
                        one.Name = Id;
                    }
                    one.Group = year;
                    one.Value = value;
                    List.Add(one);
                }
            }
            else
            {
                decimal value = GetTarget(year, month, ProjectId);
                HighChart one = new HighChart();
                if (ProjectId != "B2B" && ProjectId != "B2C")
                {
                    var Info = IoC.Resolve<IXMProjectService>().GetXMProjectById(int.Parse(ProjectId));
                    one.Name = Info.ProjectName;
                }
                else
                {
                    one.Name = ProjectId;
                }
                one.Group = year;
                one.Value = value;
                List.Add(one);
            }
            return List;
        }

        public decimal GetTarget(string year, string month, string projectId)
        {
            decimal? Value = 0;
            bool Till = false;
            int FinancialFieldId = -1;
            int ProjectId = -1;
            int DepartmentType = -1;

            if (month == "-1")
            {
                Till = true;
            }

            if (projectId == "B2B")
            {
                FinancialFieldId = 63;
                DepartmentType = 6;
            }
            else if (projectId == "B2C")
            {
                FinancialFieldId = 63;
                DepartmentType = 197;
            }
            else
            {
                FinancialFieldId = 64;
                ProjectId = int.Parse(projectId);
                DepartmentType = 505;
            }

            CWStaffSpendingMapping info = new CWStaffSpendingMapping();
            info.YearStr = year;
            info.MonthStr = month;
            info.MonthTotal = 0;
            info.YearTotal = 0;
            info.MonthTarget = 0;
            info.YearTarget = 0;
            info.FinancialFieldId = FinancialFieldId;
            if (DepartmentType != 505)
            {
                int departmentID = -1;
                if (DepartmentType == 197)
                {
                    departmentID = 63;
                }
                else if (DepartmentType == 6)
                {
                    departmentID = 297;
                }
                else if (DepartmentType == 507)
                {
                    departmentID = 507;
                }

                var otherTarget = IoC.Resolve<IXMOtherCostDetailService>().GetXMOtherCostDataAudit(FinancialFieldId, departmentID, int.Parse(year));
                if (otherTarget.Count > 0)
                {
                    foreach (XMOtherCostDetail item in otherTarget)
                    {
                        Value += GetMonthData(item, null, month, Till);
                    }
                }
            }
            else
            {
                var target = IoC.Resolve<IXMProjectCostDetailService>().GetXMProjectCostByData(ProjectId, int.Parse(year), FinancialFieldId);
                if (target.Count > 0)
                {
                    foreach (XMProjectCostDetail item in target)
                    {
                        Value += GetMonthData(null, item, month, Till);
                    }
                }
            }
            return (decimal)Value;
        }

        public decimal GetMonthData(XMOtherCostDetail OtherCostDetail, XMProjectCostDetail ProjectCostDetail, string Month, bool Till)
        {
            decimal value = 0;
            List<decimal?> ValueList = new List<decimal?>();
            int month = int.Parse(Month);

            if (OtherCostDetail != null)
            {
                ValueList.Add(OtherCostDetail.OneMonthCost);
                ValueList.Add(OtherCostDetail.TwoMonthCost);
                ValueList.Add(OtherCostDetail.ThreeMonthCost);
                ValueList.Add(OtherCostDetail.FourMonthCost);
                ValueList.Add(OtherCostDetail.FiveMonthCost);
                ValueList.Add(OtherCostDetail.SixMonthCost);
                ValueList.Add(OtherCostDetail.SevenMonthCost);
                ValueList.Add(OtherCostDetail.EightMonthCost);
                ValueList.Add(OtherCostDetail.NineMonthCost);
                ValueList.Add(OtherCostDetail.TenMonthCost);
                ValueList.Add(OtherCostDetail.ElevenMonthCost);
                ValueList.Add(OtherCostDetail.TwelMonthCost);
            }
            else
            {
                ValueList.Add(ProjectCostDetail.OneMonthCost);
                ValueList.Add(ProjectCostDetail.TwoMonthCost);
                ValueList.Add(ProjectCostDetail.ThreeMonthCost);
                ValueList.Add(ProjectCostDetail.FourMonthCost);
                ValueList.Add(ProjectCostDetail.FiveMonthCost);
                ValueList.Add(ProjectCostDetail.SixMonthCost);
                ValueList.Add(ProjectCostDetail.SevenMonthCost);
                ValueList.Add(ProjectCostDetail.EightMonthCost);
                ValueList.Add(ProjectCostDetail.NineMonthCost);
                ValueList.Add(ProjectCostDetail.TenMonthCost);
                ValueList.Add(ProjectCostDetail.ElevenMonthCost);
                ValueList.Add(ProjectCostDetail.TwelMonthCost);
            }

            if (Till)
            {
                value = (decimal)ValueList.Sum();
            }
            else if (Month == "1")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "2")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "3")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "4")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "5")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "6")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "7")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "8")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "9")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "10")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "11")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "12")
            {
                value = (decimal)ValueList[month - 1];
            }
            return value;
        }
    }
}
