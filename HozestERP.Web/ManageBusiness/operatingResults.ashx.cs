using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageBusiness;
using System.Web.Script.Serialization;
using System.Text;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageBusiness
{
    /// <summary>
    /// operatingCost 的摘要说明
    /// </summary>
    public class operatingResults : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "operatingResults": //根据国家 获取省
                    try
                    {
                        List<HighChart> HighChartList = new List<HighChart>();
                        List<OperatingCostData> List = new List<OperatingCostData>();
                        string DateType = CommonHelper.QueryString("DateType");
                        string PageType = CommonHelper.QueryString("PageType");
                        string Year = CommonHelper.QueryString("Year");
                        string Month = CommonHelper.QueryString("Month");

                        var ProjectList = IoC.Resolve<IXMProjectService>().GetXMProjectList();
                        if (ProjectList.Count > 0)
                        {
                            foreach (XMProject item in ProjectList)
                            {
                                string ProjectID = item.Id.ToString();
                                var list = GetDataTotal(DateType, PageType, ProjectID, Year, Month);
                                if (list != null && list.Count > 0)
                                {
                                    List.AddRange(list);
                                }
                            }
                        }

                        string[] Other = { "B2B", "B2C" };
                        foreach (string info in Other)
                        {
                            string ProjectID = info;
                            var list = GetDataTotal(DateType, PageType, ProjectID, Year, Month);
                            if (list != null && list.Count > 0)
                            {
                                List.AddRange(list);
                            }
                        }

                        if (List != null && List.Count > 0)
                        {
                            foreach (OperatingCostData info in List)
                            {
                                string Group = "";
                                if (info.ProjectId == "B2B" || info.ProjectId == "B2C")
                                {
                                    Group = info.ProjectId;
                                }
                                else
                                {
                                    var project = IoC.Resolve<IXMProjectService>().GetXMProjectById(int.Parse(info.ProjectId));
                                    if (project != null)
                                    {
                                        Group = project.ProjectName;
                                    }
                                }
                                HighChart one = new HighChart();
                                one.Name = info.Date;
                                one.Group = Group;
                                one.Value = info.CountMoneySum1;
                                HighChartList.Add(one);
                            }
                        }

                        if (HighChartList != null && HighChartList.Count > 0)
                        {
                            HighChartList = HighChartList.OrderBy(x => x.Group).ThenBy(x => x.Name).ToList();
                        }

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(HighChartList, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;

            }
        }

        public List<OperatingCostData> B2BOrB2C(string DateType, string ProjectID, DateTime begin, DateTime end, List<OperatingCostData> List)
        {
            string format = "";
            if (DateType == "year" || DateType == "custom_year")
            {
                format = "yyyy/MM";
            }
            else
            {
                format = "MM/dd";
            }
            List<XMFinancialCapitalFlow> list = new List<XMFinancialCapitalFlow>();
            if (ProjectID == "B2C")
            {
                list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTableB2BCByReceivablesType(begin.ToString(), end.ToString(), 197, 645);//B2C服务收入
            }
            else
            {
                list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTableB2BCByReceivablesType(begin.ToString(), end.ToString(), 6, -1);
            }

            foreach (XMFinancialCapitalFlow info in list)
            {
                foreach (OperatingCostData item in List)
                {
                    if (((DateTime)info.Date).ToString(format) == item.Date)
                    {
                        item.CountMoneySum1 = item.CountMoneySum1 + (decimal)info.Amount;//营业收入
                    }
                }
            }

            foreach (OperatingCostData item in List)
            {
                item.ProjectId = ProjectID;
            }

            return List;
        }

        public void AddOfflineData(ref List<OperatingCostData> list, DateTime begin, DateTime end, string format, int project)
        {
            List<XMJDSaleRejected> RejectedList = new List<XMJDSaleRejected>();
            List<XMSaleReturn> ReturnList = new List<XMSaleReturn>();

            var wareHousesList = IoC.Resolve<IXMWareHousesService>().GetXMWarehouseListByProjectId(project);
            List<int> WareHousesList = wareHousesList.Select(x => x.Id).ToList();
            List<int?> WarehousesList = WareHousesList.Select<int, int?>(q => Convert.ToInt32(q)).ToList();
            var SaleList = IoC.Resolve<IXMSaleDeliveryService>().GetXMSaleDeliveryListOtherProject(begin, end, WareHousesList);
            if (project == 2)
            {
                RejectedList = IoC.Resolve<IXMJDSaleRejectedService>().GetXMJDSaleRejectedListOtherProject(begin, end);//京东自营退货
            }
            else
            {
                ReturnList = IoC.Resolve<IXMSaleReturnService>().GetXMSaleReturnListByDate(begin, end, WarehousesList);
            }

            for (int i = 0; i < list.Count; i++)
            {
                OperatingCostData Info = list[i];
                if (SaleList.Count > 0)
                {
                    foreach (XMSaleDelivery info in SaleList)
                    {
                        if (Info.Date == ((DateTime)info.BizDt).ToString(format))
                        {
                            Info.CountMoneySum1 += (decimal)(info.SaleMoney == null ? 0 : info.SaleMoney);
                        }
                    }
                }
                if (RejectedList.Count > 0)
                {
                    foreach (XMJDSaleRejected info in RejectedList)
                    {
                        if (Info.Date == ((DateTime)info.BizDt).ToString(format))
                        {
                            Info.CountMoneySum1 -= (decimal)(info.ReturnMoney == null ? 0 : info.ReturnMoney);
                        }
                    }
                }
                if (ReturnList.Count > 0)
                {
                    foreach (XMSaleReturn info in ReturnList)
                    {
                        if (Info.Date == ((DateTime)info.BizDt).ToString(format))
                        {
                            Info.CountMoneySum1 -= (decimal)(info.RejectionsaleMoney == null ? 0 : info.RejectionsaleMoney);
                        }
                    }
                }
            }
        }

        private List<OperatingCostData> GetDataTotal(string DateType, string PageType, string ProjectID, string Year, string Month)
        {
            List<OperatingCostData> list = new List<OperatingCostData>();
            List<OperatingCostData> List = new List<OperatingCostData>();
            string now = DateTime.Now.ToLongDateString();
            if (DateType == "week")
            {
                for (int i = 6; i >= 0; i--)
                {
                    OperatingCostData Item = new OperatingCostData();
                    if (DateTime.Now.Day < 7 && DateTime.Now.AddDays(-i).Day > 7)
                    {
                        Item.Date = (DateTime.Now.Month - 1).ToString().PadLeft(2, '0') + "/" + (DateTime.Now.AddDays(-i).Day).ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        Item.Date = DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + (DateTime.Now.AddDays(-i).Day).ToString().PadLeft(2, '0');
                    }
                    list.Add(Item);
                }
                DateTime begin = DateTime.Parse(now).AddDays(-6);
                DateTime end = DateTime.Parse(now).AddDays(1);
                if (ProjectID == "B2B" || ProjectID == "B2C")
                {
                    List = B2BOrB2C(DateType, ProjectID, begin, end, list);
                }
                else
                {
                    List = GetDayTotal(DateType, PageType, ProjectID, begin, end, list);
                }
            }
            else if (DateType == "month")
            {
                for (int i = DateTime.Now.Day - 1; i >= 0; i--)
                {
                    OperatingCostData Item = new OperatingCostData();
                    Item.Date = DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + (DateTime.Now.AddDays(-i).Day).ToString().PadLeft(2, '0');
                    list.Add(Item);
                }
                DateTime begin = DateTime.Parse(now).AddDays(-DateTime.Now.Day + 1);
                DateTime end = DateTime.Parse(now).AddDays(1).AddSeconds(-1);
                if (ProjectID == "B2B" || ProjectID == "B2C")
                {
                    List = B2BOrB2C(DateType, ProjectID, begin, end, list);
                }
                else
                {
                    List = GetDayTotal(DateType, PageType, ProjectID, begin, end, list);
                }
            }
            else if (DateType == "year")
            {
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
                    List = B2BOrB2C(DateType, ProjectID, begin, end, list);
                }
                else
                {
                    List = GetDayTotal(DateType, PageType, ProjectID, begin, end, list);
                }
            }
            else if (DateType == "custom_year")
            {
                for (int i = 1; i <= 12; i++)
                {
                    OperatingCostData Item = new OperatingCostData();
                    Item.Date = Year + "/" + i.ToString().PadLeft(2, '0');
                    list.Add(Item);
                }
                DateTime begin = DateTime.Parse(Year + "/01/01");
                DateTime end = DateTime.Parse(Year + "/12/31").AddDays(1);
                if (ProjectID == "B2B" || ProjectID == "B2C")
                {
                    List = B2BOrB2C(DateType, ProjectID, begin, end, list);
                }
                else
                {
                    List = GetDayTotal(DateType, PageType, ProjectID, begin, end, list);
                }
            }
            else if (DateType == "custom_month")
            {
                int Count = DateTime.DaysInMonth(int.Parse(Year), int.Parse(Month));
                for (int i = 1; i <= Count; i++)
                {
                    OperatingCostData Item = new OperatingCostData();
                    Item.Date = Month.PadLeft(2, '0') + "/" + i.ToString().PadLeft(2, '0');
                    list.Add(Item);
                }
                DateTime begin = DateTime.Parse(Year + "/" + Month + "/01");
                DateTime end = DateTime.Parse(Year + "/" + Month + "/" + Count.ToString()).AddDays(1);
                if (ProjectID == "B2B" || ProjectID == "B2C")
                {
                    List = B2BOrB2C(DateType, ProjectID, begin, end, list);
                }
                else
                {
                    List = GetDayTotal(DateType, PageType, ProjectID, begin, end, list);
                }
            }

            return list;
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
            if (DateType == "year" || DateType == "custom_year")
            {
                format = "yyyy/MM";
            }
            else
            {
                format = "MM/dd";
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
            #endregion

            #region
            ////退款金额
            //List<int?> NickIdList = new List<int?>();
            //foreach (int nick in nickIdList)
            //{
            //    NickIdList.Add(nick);
            //}
            //List<XMApplication> xmConsultation = IoC.Resolve<IXMApplicationService>().GetXMConsultationListByData(Convert.ToInt32(PlatformTypeId), NickIdList, "", (DateTime?)min, (DateTime?)max, Convert.ToInt32(cbOrderStatusId));
            //if (xmConsultation.Count > 0)
            //{
            //    //CountReturnMoneySum = xmConsultation.Sum(a => a.Amount == null ? 0 : a.Amount.Value);
            //    foreach (OperatingCostData Info in list)
            //    {
            //        foreach (XMApplication info in xmConsultation)
            //        {
            //            if (Info.Date == ((DateTime)info.FinishTime).ToString(format))
            //            {
            //                Info.CountReturnMoneySum = Info.CountReturnMoneySum + (info.Amount == null ? 0 : info.Amount.Value);

            //                //退货成本
            //                var ReturnList = IoC.Resolve<IXMApplicationExchangeService>().GetXMApplicationExchangeByAppID(info.ID, 0, 1, 2);
            //                if (ReturnList != null && ReturnList.Count > 0)
            //                {
            //                    foreach (XMApplicationExchange item in ReturnList)
            //                    {
            //                        if (item.IsApplication == 2)
            //                        {
            //                            //CountReturnCostSum += item.FactoryPrice == null ? 0 : item.FactoryPrice.Value;
            //                            Info.CountReturnCostSum += (item.FactoryPrice == null ? 0 : item.FactoryPrice.Value);
            //                        }
            //                        else if (item.IsApplication == 1)
            //                        {
            //                            //CountReturnCostSum -= item.FactoryPrice == null ? 0 : item.FactoryPrice.Value;
            //                            Info.CountReturnCostSum -= (item.FactoryPrice == null ? 0 : item.FactoryPrice.Value);
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            ////进货成本
            //List<OrderInfoSalesDetails> CWJinList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetOrderInfoSalesDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId), "");
            //if (CWJinList.Count > 0)
            //{
            //    //CountMoneySum4 = CWJinList.Sum(a => a.FactoryPrice == null ? 0 : a.FactoryPrice.Value);
            //    foreach (OperatingCostData Info in list)
            //    {
            //        foreach (OrderInfoSalesDetails info in CWJinList)
            //        {
            //            if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
            //            {
            //                Info.CountMoneySum4 = Info.CountMoneySum4 + (info.FactoryPrice == null ? 0 : info.FactoryPrice.Value);
            //            }
            //        }
            //    }
            //}

            ////赠品成本
            //List<OrderInfoSalesDetails> CWZengList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoAndPremiumsDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
            //if (CWZengList.Count > 0)
            //{
            //    //CountMoneySum24 = CWZengList.Sum(a => a.FactoryPrice == null ? 0 : a.FactoryPrice.Value);
            //    foreach (OperatingCostData Info in list)
            //    {
            //        foreach (OrderInfoSalesDetails info in CWZengList)
            //        {
            //            if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
            //            {
            //                Info.CountMoneySum24 = Info.CountMoneySum24 + (info.FactoryPrice == null ? 0 : info.FactoryPrice.Value);
            //            }
            //        }
            //    }
            //}

            ////刷拍成本
            //List<OrderInfoSalesDetails> CWShuaList = IoC.Resolve<IXMScalpingService>().GetXMScalpingDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
            //if (CWShuaList.Count > 0)
            //{
            //    //刷拍佣金Fee 刷拍成本=刷拍佣金+扣点金额
            //    //CountMoneySum7 = Math.Round(CWShuaList.Sum(a => a.OrderPrice == null ? 0 : a.OrderPrice.Value), 2);
            //    foreach (OperatingCostData Info in list)
            //    {
            //        foreach (OrderInfoSalesDetails info in CWShuaList)
            //        {
            //            if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
            //            {
            //                Info.CountMoneySum7 = Info.CountMoneySum7 + (info.OrderPrice == null ? 0 : info.OrderPrice.Value);
            //            }
            //        }
            //    }
            //}

            ////返现成本
            //List<OrderInfoSalesDetails> CWFanList = IoC.Resolve<IXMCashBackApplicationService>().GetXMCashBackApplicationDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(StatusEnum.AlreadyCashBack), Convert.ToInt32(cbOrderStatusId));
            //if (CWFanList.Count > 0)
            //{
            //    //CountMoneySum8 = CWFanList.Sum(a => a.CashBackMoney == null ? 0 : a.CashBackMoney.Value);
            //    foreach (OperatingCostData Info in list)
            //    {
            //        foreach (OrderInfoSalesDetails info in CWFanList)
            //        {
            //            if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
            //            {
            //                Info.CountMoneySum8 = Info.CountMoneySum8 + (info.CashBackMoney == null ? 0 : info.CashBackMoney.Value);
            //            }
            //        }
            //    }
            //}
            ////广告费用
            //List<XMAdvertisingFee> CWFeeList = IoC.Resolve<IXMAdvertisingFeeService>().GetXMXMAdvertisingFeeByDetails(nickIdList, min, max);
            //if (CWFeeList.Count > 0)
            //{
            //    //CountMoneySumFEE = CWFeeList.Sum(a => a.Fee == null ? 0 : a.Fee.Value);
            //    foreach (OperatingCostData Info in list)
            //    {
            //        foreach (XMAdvertisingFee info in CWFeeList)
            //        {
            //            if (Info.Date == ((DateTime)info.Feedate).ToString(format))
            //            {
            //                Info.CountMoneySumFEE = Info.CountMoneySumFEE + (info.Fee == null ? 0 : info.Fee.Value);
            //            }
            //        }
            //    }
            //}

            //#endregion

            //#region 平台费用

            //List<OrderInfoSalesDetails> CWPlatformSpendingList = IoC.Resolve<IXMOrderInfoService>().GetCWPlatformSpendingSearchListSSS(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));

            //if (CWPlatformSpendingList.Count > 0)
            //{
            //    //CountMoneySum5 = decimal.Round(CWPlatformSpendingList.Select(p => p.PayPrice.Value).Sum(), 2);
            //    foreach (OperatingCostData Info in list)
            //    {
            //        foreach (OrderInfoSalesDetails info in CWPlatformSpendingList)
            //        {
            //            if (Info.Date == ((DateTime)info.MarkDate).ToString(format))
            //            {
            //                Info.CountMoneySum5 = Info.CountMoneySum5 + (info.PayPrice == null ? 0 : info.PayPrice.Value);
            //            }
            //        }
            //    }
            //}

            //#endregion

            //#region 运费
            //if (cbXMProject != "-1")
            //{
            //    //根据店铺项目 查询运费比例 
            //    var xmproject = IoC.Resolve<IXMProjectService>().GetXMProjectById(Convert.ToInt32(cbXMProject));
            //    if (xmproject != null)
            //    {
            //        if (xmproject.ShipmentProportion != null)
            //        {
            //            decimal ShipmentProportion = xmproject.ShipmentProportion.Value / 100;

            //            //CountMoneySum6 = Math.Round((CountMoneySum1 - CountReturnMoneySum) * ShipmentProportion, 2);
            //            foreach (OperatingCostData Info in list)
            //            {
            //                Info.CountMoneySum6 = (Info.CountMoneySum1 - Info.CountReturnMoneySum) * ShipmentProportion;
            //            }
            //        }
            //    }
            //}

            //if (DateType == "year")
            //{
            //    if (cbXMProject != "-1" || cbXMProject != "0")
            //    {
            //        foreach (OperatingCostData Info in list)
            //        {
            //            string[] date = (Info.Date.Replace("/0", "/")).Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            //            List<CWStaffSpending> staffspendingList = IoC.Resolve<ICWStaffSpendingService>().GetCWStaffSpendingList(6, int.Parse(cbXMProject), date[0], date[1]);
            //            if (staffspendingList.Count > 0)
            //            {
            //                //CountMoneySum6 = decimal.Parse(staffspendingList[0].CountMoney.Value.ToString());
            //                Info.CountMoneySum6 = decimal.Parse(staffspendingList[0].CountMoney.Value.ToString());
            //            }
            //        }
            //    }
            //}

            //#endregion

            //#region 增值税

            ////decimal ZZSMonthMoney = Math.Round((CountMoneySum1 - CountReturnMoneySum - (CountMoneySum4 - CountReturnCostSum)) / (decimal)1.17 * (decimal)0.17 - CountMoneySum6 / (decimal)1.06 * (decimal)0.06, 2);
            //foreach (OperatingCostData Info in list)
            //{
            //    Info.ZZSMonthMoney = Math.Round((Info.CountMoneySum1 - Info.CountReturnMoneySum - (Info.CountMoneySum4 - Info.CountReturnCostSum)) / (decimal)1.17 * (decimal)0.17 - Info.CountMoneySum6 / (decimal)1.06 * (decimal)0.06, 2);
            //}

            //#endregion

            ////营业成本=进货成本+赠品成本+平台成本费用+运费+刷拍成本+返现成本
            ////decimal YYCBMonthMoney = Convert.ToDecimal(CountMoneySum4 - CountReturnCostSum) + Convert.ToDecimal(CountMoneySum24) + CountMoneySum5 + CountMoneySum6 + Convert.ToDecimal(CountMoneySum7) + Convert.ToDecimal(CountMoneySum8);
            //foreach (OperatingCostData Info in list)
            //{
            //    Info.YYCBMonthMoney = Info.CountMoneySum4 - Info.CountReturnCostSum + Info.CountMoneySum24 + Info.CountMoneySum5 + Info.CountMoneySum6 + Info.CountMoneySum7 + Info.CountMoneySum8;
            //}

            ////管理费用
            //var ManagementFeeList = IoC.Resolve<IXMBusinessDataOtherService>().GetXMBusinessDataOtherListByProjectID(ProjectID, DateType);
            //if (ManagementFeeList.Count > 0)
            //{
            //    foreach (OperatingCostData Info in list)
            //    {
            //        foreach (XMBusinessDataOther info in ManagementFeeList)
            //        {
            //            if (Info.Date == ((DateTime)info.SubmitDate).ToString(format))
            //            {
            //                Info.ManagementFee = Info.ManagementFee + (info.Amount == null ? 0 : info.Amount.Value);
            //            }
            //        }
            //    }
            //}

            ////毛利=营业收入-增值税-营业成本-广告费
            ////decimal MLMonthMoney = Math.Round(CountMoneySum1 - CountReturnMoneySum - Convert.ToDecimal(this.lblZZSMonthMoney.Text) - Convert.ToDecimal(this.lblYYCBMonthMoney.Text) - Convert.ToDecimal(this.lblFEEMoney.Text), 2);
            //foreach (OperatingCostData Info in list)
            //{
            //    Info.MLMonthMoney = Math.Round(Info.CountMoneySum1 - Info.CountReturnMoneySum - Info.ZZSMonthMoney - Info.YYCBMonthMoney - Info.CountMoneySumFEE, 2);
            //}
            #endregion

            AddOfflineData(ref list, begin, end, format, int.Parse(ProjectID));

            foreach (OperatingCostData Info in list)
            {
                Info.ProjectId = ProjectID;
                Info.CountMoneySum1 = Math.Round(Info.CountMoneySum1, 2);
            }

            return list;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}