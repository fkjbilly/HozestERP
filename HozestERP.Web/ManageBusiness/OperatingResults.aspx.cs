using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageBusiness
{
    public partial class OperatingResults : BaseAdministrationPage, ISearchPage
    {
        public string TableList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlYear.Items.Clear();
                List<string> YearList = new List<string>();
                for (int i = 0; i < 5; i++)
                {
                    int year = DateTime.Now.Year;
                    YearList.Add((year - i).ToString());
                }
                this.ddlYear.DataSource = YearList;
                this.ddlYear.DataBind();

                this.ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

                StringBuilder str = Total(DateTime.Now.Year.ToString());
                TableList = str.ToString();
            }
        }

        public StringBuilder Total(string Year)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<tr><th align='center' style='height:7%;'></th><th align='center' style='height:8%;'>1月</th><th align='center' style='height:8%;'>2月</th>"
                        + "<th align='center' style='height:8%;'>3月</th><th align='center' style='height:8%;'>4月</th><th align='center' style='height:8%;'>5月</th>"
                        + "<th align='center' style='height:8%;'>6月</th><th align='center' style='height:8%;'>7月</th><th align='center' style='height:8%;'>8月</th>"
                        + "<th align='center' style='height:8%;'>9月</th><th align='center' style='height:7%;'>10月</th><th align='center' style='height:7%;'>11月</th>"
                        + "<th align='center' style='height:7%;'>12月</th></tr>");

            var ProjectList = base.XMProjectService.GetXMProjectList();
            if (ProjectList.Count > 0)
            {
                foreach (XMProject item in ProjectList)
                {
                    var list = GetDataTotal(Year, PageType.ToString(), item.Id.ToString());
                    if (list != null && list.Count > 0)
                    {
                        list = list.OrderBy(x => x.Date).ToList();
                    }
                    str.Append("<tr><td align='center'>" + item.ProjectName + "</td>");
                    str.Append(MonthData(item.Id.ToString(), list, Year));
                    str.Append("</tr>");
                }
            }

            string[] Other = { "B2B", "B2C" };
            foreach (string info in Other)
            {
                var B2BList = GetDataTotal(Year, PageType.ToString(), info);
                if (B2BList != null && B2BList.Count > 0)
                {
                    B2BList = B2BList.OrderBy(x => x.Date).ToList();
                }
                str.Append("<tr><td align='center'>" + info + "</td>");
                str.Append(MonthData(info, B2BList, Year));
                str.Append("</tr>");
            }
            return str;
        }

        public StringBuilder MonthData(string ProjectId, List<OperatingCostData> List, string Year)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 1; i < 13; i++)
            {
                bool exist = false;
                foreach (OperatingCostData Info in List)
                {
                    string Date = Year + "/" + i.ToString().PadLeft(2, '0');
                    if (Info.ProjectId == ProjectId && Info.Date == Date)
                    {
                        a.Append("<td>" + Info.CountMoneySum1 + "</td>");
                        exist = true;
                    }
                }
                if (!exist)
                {
                    a.Append("<td>0.00</td>");
                }
            }
            return a;
        }

        private List<OperatingCostData> GetDataTotal(string Year, string PageType, string ProjectID)
        {
            List<OperatingCostData> list = new List<OperatingCostData>();
            int Month = 0;
            string Now = "";
            if (Year == DateTime.Now.Year.ToString())
            {
                Month = DateTime.Now.Month;
                Now = DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Day.ToString().PadLeft(2, '0');
            }
            else
            {
                Month = 12;
                Now = "12/31";
            }

            for (int i = 1; i <= Month; i++)
            {
                OperatingCostData Item = new OperatingCostData();
                Item.Date = Year + "/" + i.ToString().PadLeft(2, '0');
                list.Add(Item);
            }

            DateTime begin = DateTime.Parse(Year + "/01/01");
            DateTime end = DateTime.Parse(Year + "/" + Now).AddDays(1);
            if (ProjectID == "B2B" || ProjectID == "B2C")
            {
                list = B2BOrB2C(ProjectID, begin, end, list);
            }
            else
            {
                list = GetDayTotal(PageType, ProjectID, begin, end, list);
            }
            return list;
        }

        public List<OperatingCostData> B2BOrB2C(string ProjectID, DateTime begin, DateTime end, List<OperatingCostData> List)
        {
            string format = "yyyy/MM";
            List<XMFinancialCapitalFlow> list = new List<XMFinancialCapitalFlow>();
            if (ProjectID == "B2C")
            {
                //list = IoC.Resolve<IXMBusinessDataDetailService>().GetXMBusinessDataDetailListByDepID(63, begin, end);
                list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTableB2BCByReceivablesType(begin.ToString(), end.ToString(), 197, 645);//B2C服务收入
            }
            else
            {
                //list = IoC.Resolve<IXMBusinessDataDetailService>().GetXMBusinessDataDetailListByDepID(297, begin, end);
                list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTableB2BCByReceivablesType(begin.ToString(), end.ToString(), 6, -1);
            }
            ////管理费用
            //var ManagementFeeList = IoC.Resolve<IXMBusinessDataOtherService>().GetXMBusinessDataOtherResults(ProjectID, begin, end);
            //if (ManagementFeeList.Count > 0)
            //{
            //    foreach (OperatingCostData Info in List)
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

            foreach (XMFinancialCapitalFlow info in list)
            {
                foreach (OperatingCostData item in List)
                {
                    if (((DateTime)info.Date).ToString(format) == item.Date)
                    {
                        //if (info.AmountType == 567)//支出
                        //{
                        //    item.YYCBMonthMoney = item.YYCBMonthMoney + (decimal)info.Amount;//营业成本
                        //}
                        //if (info.AmountType == 568)//收入
                        //{
                        item.CountMoneySum1 = item.CountMoneySum1 + (decimal)info.Amount;//营业收入
                        //}
                    }
                }
            }

            foreach (OperatingCostData item in List)
            {
                item.ProjectId = ProjectID;
                //item.ZZSMonthMoney = Math.Round((item.CountMoneySum1 / (decimal)1.06) * (decimal)0.06, 2);//增值税    
                //item.MLMonthMoney = Math.Round((item.CountMoneySum1 - item.YYCBMonthMoney - item.ZZSMonthMoney), 2); //毛利
            }
            return List;
        }

        private List<OperatingCostData> GetDayTotal(string PageType, string ProjectID, DateTime begin, DateTime end, List<OperatingCostData> list)
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

            string format = "yyyy/MM";

            //营业收入
            List<OrderInfoSalesDetails> CWProfitList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId), "");
            if (CWProfitList.Count > 0)
            {
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

            //if (cbXMProject != "-1" || cbXMProject != "0")
            //{
            //    foreach (OperatingCostData Info in list)
            //    {
            //        string[] date = (Info.Date.Replace("/0", "/")).Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            //        List<CWStaffSpending> staffspendingList = IoC.Resolve<ICWStaffSpendingService>().GetCWStaffSpendingList(6, int.Parse(cbXMProject), date[0], date[1]);
            //        if (staffspendingList.Count > 0)
            //        {
            //            //CountMoneySum6 = decimal.Parse(staffspendingList[0].CountMoney.Value.ToString());
            //            Info.CountMoneySum6 = decimal.Parse(staffspendingList[0].CountMoney.Value.ToString());
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

            //#region 营业成本
            ////营业成本=进货成本+赠品成本+平台成本费用+运费+刷拍成本+返现成本
            ////decimal YYCBMonthMoney = Convert.ToDecimal(CountMoneySum4 - CountReturnCostSum) + Convert.ToDecimal(CountMoneySum24) + CountMoneySum5 + CountMoneySum6 + Convert.ToDecimal(CountMoneySum7) + Convert.ToDecimal(CountMoneySum8);
            //foreach (OperatingCostData Info in list)
            //{
            //    Info.YYCBMonthMoney = Info.CountMoneySum4 - Info.CountReturnCostSum + Info.CountMoneySum24 + Info.CountMoneySum5 + Info.CountMoneySum6 + Info.CountMoneySum7 + Info.CountMoneySum8;
            //}
            //#endregion

            //#region 管理费用
            ////管理费用
            //var ManagementFeeList = IoC.Resolve<IXMBusinessDataOtherService>().GetXMBusinessDataOtherResults(ProjectID, begin, end);
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
            //#endregion

            //#region 毛利
            ////毛利=营业收入-增值税-营业成本-广告费
            ////decimal MLMonthMoney = Math.Round(CountMoneySum1 - CountReturnMoneySum - Convert.ToDecimal(this.lblZZSMonthMoney.Text) - Convert.ToDecimal(this.lblYYCBMonthMoney.Text) - Convert.ToDecimal(this.lblFEEMoney.Text), 2);
            //foreach (OperatingCostData Info in list)
            //{
            //    Info.MLMonthMoney = Math.Round(Info.CountMoneySum1 - Info.CountReturnMoneySum - Info.ZZSMonthMoney - Info.YYCBMonthMoney - Info.CountMoneySumFEE, 2);
            //}
            //#endregion
            #endregion

            AddOfflineData(ref list, begin, end, format, int.Parse(ProjectID));//线下无订单的数据

            foreach (OperatingCostData Info in list)
            {
                Info.ProjectId = ProjectID;
                Info.CountMoneySum1 = Math.Round(Info.CountMoneySum1, 2);
            }

            return list;
        }

        public void AddOfflineData(ref List<OperatingCostData> list, DateTime begin, DateTime end, string format, int project)
        {
            List<XMJDSaleRejected> RejectedList = new List<XMJDSaleRejected>();
            List<XMSaleReturn> ReturnList = new List<XMSaleReturn>();

            var wareHousesList = base.XMWareHousesService.GetXMWarehouseListByProjectId(project);
            List<int> WareHousesList = wareHousesList.Select(x => x.Id).ToList();
            List<int?> WarehousesList = WareHousesList.Select<int, int?>(q => Convert.ToInt32(q)).ToList();
            var SaleList = base.XMSaleDeliveryService.GetXMSaleDeliveryListOtherProject(begin, end, WareHousesList);
            if (project == 2)
            {
                RejectedList = base.XMJDSaleRejectedService.GetXMJDSaleRejectedListOtherProject(begin, end);//京东自营退货
            }
            else
            {
                ReturnList = base.XMSaleReturnService.GetXMSaleReturnListByDate(begin, end, WarehousesList);
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

        public int PageType
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            StringBuilder str = Total(this.ddlYear.SelectedValue);
            TableList = str.ToString();

            string DateType = "";
            string Year = this.ddlYear.SelectedValue;
            string Month = this.ddlMonth.SelectedValue;
            if (Month == "-1")
            {
                if (Year == DateTime.Now.Year.ToString())
                {
                    DateType = "year";
                }
                else
                {
                    DateType = "custom_year";
                }
            }
            else
            {
                if (Year == DateTime.Now.Year.ToString() && Month == DateTime.Now.Month.ToString())
                {
                    DateType = "month";
                }
                else
                {
                    DateType = "custom_month";
                }
            }
            ScriptManager.RegisterStartupScript(this.btnSearch, this.Page.GetType(), "btnSearch", "dataBind('" + DateType + "')", true);
        }

        protected void btnWeek_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.btnWeek, this.Page.GetType(), "btnWeek", "dataBind('week')", true);

            this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            this.ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            StringBuilder str = Total(this.ddlYear.SelectedValue);
            TableList = str.ToString();
        }

        protected void btnMonth_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.btnMonth, this.Page.GetType(), "btnMonth", "dataBind('month')", true);

            this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            this.ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            StringBuilder str = Total(this.ddlYear.SelectedValue);
            TableList = str.ToString();
        }

        protected void btnYear_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.btnYear, this.Page.GetType(), "btnYear", "dataBind('year')", true);

            this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            this.ddlMonth.SelectedValue = "-1";
            StringBuilder str = Total(this.ddlYear.SelectedValue);
            TableList = str.ToString();
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