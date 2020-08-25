using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRM.BusinessLogic.ManageContract;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{
    public partial class CWProfitListSS : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //base.CWProfitService.TimingGetCWProfit(); 
                //this.BindGrid(1, Master.PageSize); 
                //this.lblTitle.Text = this.ddlDateTime.Text + "数";
                //this.BindData();
                BindDate();
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            #region 平台类型绑定

            //平台类型动态数据绑定
            this.ddlPlatformTypeId.Items.Clear();
            var codeLists = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatformTypeId.DataSource = codeLists;
            this.ddlPlatformTypeId.DataTextField = "CodeName";
            this.ddlPlatformTypeId.DataValueField = "CodeID";
            this.ddlPlatformTypeId.DataBind();
            this.ddlPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));
            #endregion

            #region 项目类型绑定

            //项目类型绑定
            this.ddlXMProjectTypeId.Items.Clear();
            var codeProjectTypeLists = base.CodeService.GetCodeListInfoByCodeTypeID(189, false);
            var codenew = codeProjectTypeLists.Where(p => p.CodeID == 362);
            this.ddlXMProjectTypeId.DataSource = codenew;
            this.ddlXMProjectTypeId.DataTextField = "CodeName";
            this.ddlXMProjectTypeId.DataValueField = "CodeID";
            this.ddlXMProjectTypeId.DataBind();
            //this.ddlXMProjectTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));
            #endregion

            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 563)
            {
                this.ddlXMProjectNameId.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362);

                this.ddlXMProjectNameId.DataSource = projectList;
                this.ddlXMProjectNameId.DataTextField = "ProjectName";
                this.ddlXMProjectNameId.DataValueField = "Id";
                this.ddlXMProjectNameId.DataBind();
                this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                this.ddlXMProjectNameId.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                {
                    Id = p.Key.Id,
                    ProjectName = p.Key.ProjectName
                });

                this.ddlXMProjectNameId.DataSource = projectList;
                this.ddlXMProjectNameId.DataTextField = "ProjectName";
                this.ddlXMProjectNameId.DataValueField = "Id";
                this.ddlXMProjectNameId.DataBind();
                this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            #endregion

            #region 店铺名称绑定

            //店铺数据源 
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 563)
            {
                this.ddlNickList.Items.Clear();
                var NickList = base.XMNickService.GetXMNickList();
                var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                this.ddlNickList.DataSource = newNickList;
                this.ddlNickList.DataTextField = "nick";
                this.ddlNickList.DataValueField = "nick_id";
                this.ddlNickList.DataBind();
                this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                //其他
                //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362);

                if (xMNickList.Count > 0)
                {
                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = xMNickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
            }

            #endregion
        }


        public void BindGrid(int pageindex, int pagesize) { }

        public void BindDate()
        {
            //绑定数据源
            #region 条件查询

            var min = DateTime.Parse(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + "01");
            if (this.txtBeginDate.SelectedDate.HasValue)
            {
                min = this.txtBeginDate.SelectedDate.Value;
            }
            else
            {
                min = DateTime.Parse(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + "01");
            }

            var max = DateTime.Now;
            if (this.txtEndDate.SelectedDate.HasValue)
            {
                max = this.txtEndDate.SelectedDate.Value.AddDays(1).AddSeconds(-1);
            }
            else
            {
                max = DateTime.Now;
            }
            this.txtBeginDate.SelectedDate = min;
            this.txtEndDate.SelectedDate = max;

            #endregion
        }

        #endregion

        private void BindData()
        {
            #region 条件查询

            //平台类型
            string PlatformTypeId = "-1";
            if (this.ddlPlatformTypeId.SelectedValue != null)
            {
                PlatformTypeId = this.ddlPlatformTypeId.SelectedValue.ToString();
            }
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
            var min = DateTime.Parse(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + "01");
            if (this.txtBeginDate.SelectedDate.HasValue)
            {
                min = this.txtBeginDate.SelectedDate.Value;
            }
            else
            {
                min = DateTime.Parse(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + "01");
            }
            var max = DateTime.Now;
            if (this.txtEndDate.SelectedDate.HasValue)
            {
                max = this.txtEndDate.SelectedDate.Value.AddDays(1).AddSeconds(-1);
            }
            else
            {
                max = DateTime.Now;
            }
            this.txtBeginDate.SelectedDate = min;
            this.txtEndDate.SelectedDate = max;

            //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
            var cbOrderStatusId = this.ddlOrderStatus.SelectedValue;

            //项目类型： 自运营、代运营
            string cbXMProjectTypeId = "-1";
            if (this.ddlXMProjectTypeId.SelectedValue != null)
            {
                cbXMProjectTypeId = this.ddlXMProjectTypeId.SelectedValue.ToString();
            }

            //项目名称
            string cbXMProject = "-1";
            if (this.ddlXMProjectNameId.SelectedValue != null)
            {
                cbXMProject = this.ddlXMProjectNameId.SelectedValue.ToString();
            }

            //店铺名称
            string cbNick = "-1";
            if (this.ddlNickList.SelectedValue != null)
            {
                cbNick = this.ddlNickList.SelectedValue.ToString();
            }

            //店铺集合
            List<int> nickIdList = new List<int>();

            //合并新的list
            //List<CWProfitMapping> CWProfitMappingList = new List<CWProfitMapping>();

            #region 店铺条件查询集合 处理
            //选择某项目  
            if (cbXMProject != "-1")
            {
                if (cbNick == "-1")//项目下的所有店铺
                {
                    var nickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    if (nickList.Count > 0)
                    {
                        nickIdList = nickList.Select(p => p.nick_id).ToList();
                    }
                }
                else
                {
                    nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                }
            }
            else
            {
                if (cbNick == "-1")
                {
                    var NickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                    //var NickListNew = NickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    nickIdList = NickList.Select(a => a.nick_id).ToList();
                }
                else
                {
                    nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                }

            }
            #endregion

            // int ParentID = 0; //父级Id 
            #endregion

            #region 利润数据

            decimal CountMoneySum1 = 0;//营业收入
            decimal CountReturnMoneySum = 0;//退款金额
            decimal CountMoneySum4 = 0;//进货成本
            decimal CountMoneySum5 = 0;//平台成本费用
            decimal CountReturnCostSum = 0;//退货成本
            decimal CountMoneySum24 = 0;//赠品成本  
            decimal CountMoneySum7 = 0;//刷拍成本
            decimal InstallationCost = 0; //安装费
            decimal CountMoneySum8 = 0;//返现成本 
            decimal CountMoneySumFEE = 0;//广告费用
            List<XMApplicationExchange> AppExchangeList = new List<XMApplicationExchange>();

            List<int?> NickIdList = new List<int?>();
            foreach (int nick in nickIdList)
            {
                NickIdList.Add(nick);
            }

            //平台为京东自营则单独参加计算
            if (Convert.ToInt32(PlatformTypeId)==537)
            {
                #region 京东自营

                List<JDSelfModel> List = new List<JDSelfModel>();
                List<XMJDSaleRejectedProductDetail> RejectedList = new List<XMJDSaleRejectedProductDetail>();
                List<XMSaleReturnProductDetails> ReturnList = new List<XMSaleReturnProductDetails>();

                var wareHousesList = IoC.Resolve<IXMWareHousesService>().GetXMWarehouseListByNickIds(nickIdList);
                List<int> WareHousesList = wareHousesList.Select(x => x.Id).ToList();
                List<int?> WarehousesList = WareHousesList.Select<int, int?>(q => Convert.ToInt32(q)).ToList();
                var SaleList = IoC.Resolve<IXMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryListJDSelf(min, max, WareHousesList);//线下无订单的销售出库数据
                if (NickIdList.Contains(29))
                {
                    RejectedList = IoC.Resolve<IXMJDSaleRejectedProductDetailService>().GetXMJDSaleRejectedProductDetailListJDSelf(min, max);//京东自营退货
                }
                if ((NickIdList.Contains(29) && NickIdList.Count > 1) || !NickIdList.Contains(29))
                {
                    ReturnList = IoC.Resolve<IXMSaleReturnProductDetailsService>().GetXMSaleReturnProductDetailsListByDate(min, max, WarehousesList);
                }
                var InventoryList = IoC.Resolve<IXMInventoryInfoService>().GetXMInventoryInfoListByWfIds(WareHousesList);//京东自营库存
                if (SaleList != null)
                {
                    GetJDProductsPriceList(ref List, SaleList, RejectedList, ReturnList, InventoryList, WareHousesList);

                    if (SaleList.Count > 0)
                    {
                        foreach (XMSaleDeliveryProductDetails sale in SaleList)
                        {
                            CountMoneySum1 += (decimal)(sale.ProductMoney == null ? 0 : sale.ProductMoney);

                            decimal cost = GetCost(List, sale.XM_SaleDelivery.WareHouseId, sale.PlatformMerchantCode);
                            CountMoneySum4 += cost * decimal.Parse(sale.SaleCount.ToString());
                        }
                    }
                }
                if (RejectedList.Count > 0)
                {
                    foreach (XMJDSaleRejectedProductDetail rejected in RejectedList)
                    {
                        CountMoneySum1 -= (decimal)(rejected.RejectionMoney == null ? 0 : rejected.RejectionMoney);

                        decimal cost = GetCost(List, -1, rejected.PlatformMerchantCode);
                        CountMoneySum4 -= cost * decimal.Parse(rejected.RejectionCount.ToString());
                    }
                }
                if (ReturnList.Count > 0)
                {
                    foreach (XMSaleReturnProductDetails rejected in ReturnList)
                    {
                        CountMoneySum1 -= (decimal)(rejected.RejectionsaleMoney == null ? 0 : rejected.RejectionsaleMoney);

                        string PlatformMerchantCode = "";
                        if (rejected.DeliveryProductsDetailID != null)
                        {
                            var ProductDetail = IoC.Resolve<IXMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryProductDetailsById(rejected.DeliveryProductsDetailID.Value);
                            if (ProductDetail != null)
                            {
                                PlatformMerchantCode = ProductDetail.PlatformMerchantCode;
                            }
                        }
                        decimal cost = GetCost(List, (int)rejected.XM_SaleReturn.WarehouseId, PlatformMerchantCode);
                        CountMoneySum4 -= cost * decimal.Parse(rejected.RejectionProdcutsCount.ToString());
                    }
                }

                #endregion
            }
            else
            {
                //营业收入
                List<OrderInfoSalesDetails> CWProfitList = base.XMOrderInfoService.getXMOrderInfoList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId), "");
                if (CWProfitList.Count > 0)
                {
                    var PayPriceSum = CWProfitList.Sum(a => a.PayPrice == null ? 0 : a.PayPrice.Value);//客户支付金额
                    var PlatformPriceSum = CWProfitList.Sum(a => a.OrderPromotion == null ? 0 : a.OrderPromotion.Value);//客户支付金额
                    CountMoneySum1 = PayPriceSum + PlatformPriceSum;
                }

                //退款金额
                List<XMApplication> xmConsultation = base.XMApplicationService.GetXMConsultationListByData(Convert.ToInt32(PlatformTypeId), NickIdList, "", (DateTime?)min, (DateTime?)max, Convert.ToInt32(cbOrderStatusId));
                if (xmConsultation.Count > 0)
                {
                    CountReturnMoneySum = xmConsultation.Sum(a => a.Amount == null ? 0 : a.Amount.Value);
                }

                //进货成本
                List<OrderInfoSalesDetails> CWJinList = base.XMOrderInfoProductDetailsService.GetOrderInfoSalesDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
                if (CWJinList.Count > 0)
                {
                    CountMoneySum4 = CWJinList.Sum(a => a.FactoryPrice == null ? 0 : a.FactoryPrice.Value);
                }

                ////京东自营-销售额
                //List<XMNickAchieveValue> jDList = base.XMNickAchieveValueService.GetXMNickAchieveValueListByData(nickIdList, min, max);
                //if (jDList.Count > 0)
                //{
                //    CountMoneySum1 += jDList.Sum(a => a.SalePrice == null ? 0 : a.SalePrice);
                //}
                //京东自营-进货成本
                //List<XMNickAchieveValue> JDList = base.XMNickAchieveValueService.GetXMNickAchieveValueListByData(nickIdList, min, max);
                //if (JDList.Count > 0)
                //{
                //    CountMoneySum4 += JDList.Sum(a => a.Cost == null ? 0 : a.Cost);
                //}

                //退货成本(统计包括三个部分：1.先退货后退款（ApplicationType == 5） 2.先退款后退货（ApplicationType == 7）3.换货（ApplicationType == 6）)
                if (xmConsultation.Count > 0)
                {
                    //有退货的列表
                    //List<XMApplication> xmRetuenPorductCost = xmConsultation.Where(p => (p.ApplicationType == 5 || p.ApplicationType == 7 || p.ApplicationType == 6)).ToList();
                    foreach (XMApplication info in xmConsultation)
                    {
                        var list = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(info.ID, 0, 1, 2);
                        if (list != null && list.Count > 0)
                        {
                            foreach (XMApplicationExchange Info in list)
                            {
                                //CountReturnCostSum += Info.FactoryPrice.Value;
                                AppExchangeList.Add(Info);
                                if (Info.IsApplication == 2)
                                {
                                    CountReturnCostSum += Info.FactoryPrice == null ? 0 : Info.FactoryPrice.Value;
                                }
                                else if (Info.IsApplication == 1)
                                {
                                    CountReturnCostSum -= Info.FactoryPrice == null ? 0 : Info.FactoryPrice.Value;
                                }
                            }
                        }
                    }
                }

                //赠品成本
                //List<OrderInfoSalesDetails> CWZengList = base.XMOrderInfoService.getXMOrderInfoAndPremiumsDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
                //if (CWZengList.Count > 0)
                //{
                //    CountMoneySum24 = CWZengList.Sum(a => a.FactoryPrice == null ? 0 : a.FactoryPrice.Value);
                //}

                //赠品成本
                CountMoneySum24 = XMOrderInfoService.getPremiumsCost(Convert.ToInt32(PlatformTypeId), nickIdList, min, max);

                //刷拍成本
                //List<OrderInfoSalesDetails> CWShuaList = base.XMScalpingService.GetXMScalpingDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));
                //if (CWShuaList.Count > 0)
                //{
                //    //刷拍佣金Fee 刷拍成本=刷拍佣金+扣点金额
                //    CountMoneySum7 = Math.Round(CWShuaList.Sum(a => a.OrderPrice == null ? 0 : a.OrderPrice.Value), 2);
                //}

                //刷拍成本
                CountMoneySum7 = XMScalpingService.getScalpingCost(Convert.ToInt32(PlatformTypeId), nickIdList, min, max);

                //返现成本
                //List<OrderInfoSalesDetails> CWFanList = base.XMCashBackApplicationService.GetXMCashBackApplicationDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(StatusEnum.AlreadyCashBack), Convert.ToInt32(cbOrderStatusId));
                //if (CWFanList.Count > 0)
                //{
                //    CountMoneySum8 = CWFanList.Sum(a => a.CashBackMoney == null ? 0 : a.CashBackMoney.Value);
                //}

                //返现成本
                CountMoneySum8 = XMCashBackApplicationService.getCashBackCost(Convert.ToInt32(PlatformTypeId), nickIdList, min, max, Convert.ToInt32(StatusEnum.AlreadyCashBack));

                //安装费用
                InstallationCost = XMInstallationListService.InstallationCost(Convert.ToInt32(PlatformTypeId), nickIdList, min, max);

                //广告费用
                //List<XMAdvertisingFee> CWFeeList = base.XMAdvertisingFeeService.GetXMXMAdvertisingFeeByDetails(nickIdList, min, max);
                //List<XMFinancialCapitalFlow> FeeList = base.XMFinancialCapitalFlowService.GetListByDataToTable(min.ToString(), max.ToString(), -1, int.Parse(cbXMProject), 148);
                //if (FeeList.Count > 0 && cbNick == "-1")
                //{
                //    CountMoneySumFEE = FeeList.Sum(a => a.Amount == null ? 0 : a.Amount.Value);
                //}

                //广告费用
                CountMoneySumFEE = XMFinancialCapitalFlowService.getAdvertisingCost(min.ToString(), max.ToString(), -1, int.Parse(cbXMProject), 148);

                #region 平台费用      
                List<OrderInfoSalesDetails> CWPlatformSpendingList = base.XMOrderInfoService.GetCWPlatformSpendingSearchListSSS(Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue), nickIdList, min, max, Convert.ToInt32(cbOrderStatusId));

                if (CWPlatformSpendingList.Count > 0)
                {

                    CountMoneySum5 = decimal.Round(CWPlatformSpendingList.Select(p => p.PayPrice.Value).Sum(), 2);
                }

                #endregion
            }




            #endregion

            #region 人员开支费用

            decimal CountMoneySum6 = 0;//运费
            int CountMoneySum6Index = 0;//运费是否返回数据

            #endregion

            #region 营业收入
            this.lblYYSRMonthMoney.Text = CountMoneySum1.ToString();// 本月数
            //this.lblYYSRMonthProfit.Text = "0";//月度达成率
            lblYYSRMonthMoney.OnClientClick = "return ShowWindowDetail('订单明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/OrderInfoDetailsSS.aspx?PlatformTypeId=" + PlatformTypeId
            + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
            + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
            + "&NickId=" + this.ddlNickList.SelectedValue
            + "&OrderStatusId=" + this.ddlOrderStatus.SelectedValue
            + "&min=" + (this.txtBeginDate.SelectedDate == null ? min : this.txtBeginDate.SelectedDate)
            + "&max=" + (this.txtEndDate.SelectedDate == null ? max.AddDays(-1) : this.txtEndDate.SelectedDate)
            + "', 1200, 690, this, function(){});";
            #endregion

            #region 退款金额
            this.lblReturnMoney.Text = CountReturnMoneySum.ToString();
            lblReturnMoney.OnClientClick = "return ShowWindowDetail('退款金额明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/XMReturnMoneyList.aspx?"
            + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
            + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
            + "&OrderStatus=" + this.ddlOrderStatus.SelectedValue
            + "&PlatformTypeId=" + this.ddlPlatformTypeId.SelectedValue
            + "&NickId=" + this.ddlNickList.SelectedValue
            + "&min=" + (this.txtBeginDate.SelectedDate == null ? min : this.txtBeginDate.SelectedDate)
            + "&max=" + (this.txtEndDate.SelectedDate == null ? max.AddDays(-1) : this.txtEndDate.SelectedDate)
            + "', 1200, 690, this, function(){});";
            #endregion

            #region 营业成本

            #endregion

            #region  进货成本
            this.lblJHCBMonthMoney.Text = CountMoneySum4.ToString();// 本月数
            lblJHCBMonthMoney.OnClientClick = "return ShowWindowDetail('产品明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/OrderInfoProductDetailsSS.aspx?PlatformTypeId=" + PlatformTypeId
            + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
            + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
            + "&NickId=" + this.ddlNickList.SelectedValue
            + "&OrderStatusId=" + this.ddlOrderStatus.SelectedValue
            + "&min=" + (this.txtBeginDate.SelectedDate == null ? min : this.txtBeginDate.SelectedDate)
            + "&max=" + (this.txtEndDate.SelectedDate == null ? max.AddDays(-1) : this.txtEndDate.SelectedDate)
            + "', 1200, 700, this, function(){});";
            #endregion

            #region 退货成本
            this.lblReturnCost.Text = CountReturnCostSum.ToString();
            lblReturnCost.OnClientClick = "return ShowWindowDetail('退货成本明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/XMReturnCostList.aspx"
            + "', 700, 450, this, function(){});";

            Session["AppExchangeList"] = AppExchangeList;
            #endregion

            #region  赠品成本
            this.lblZPCBMonthMoney.Text = CountMoneySum24.ToString();// 本月数
            lblZPCBMonthMoney.OnClientClick = "return ShowWindowDetail('赠品明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/PremiumsDetailsSS.aspx?PlatformTypeId=" + PlatformTypeId
            + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
            + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
            + "&NickId=" + this.ddlNickList.SelectedValue
            + "&OrderStatusId=" + this.ddlOrderStatus.SelectedValue
            + "&min=" + (this.txtBeginDate.SelectedDate == null ? min : this.txtBeginDate.SelectedDate)
            + "&max=" + (this.txtEndDate.SelectedDate == null ? max.AddDays(-1) : this.txtEndDate.SelectedDate)
            + "', 1000, 500, this, function(){});";
            #endregion

            #region 平台成本费用
            this.lblPTCBFYMonthMoney.Text = CountMoneySum5.ToString();
            this.lblPTCBFYMonthMoney.OnClientClick = "return ShowWindowDetail('平台费用明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/CWPlatformSpendingDetailsSS.aspx?PlatformTypeId=" + PlatformTypeId
            + "&min=" + this.txtBeginDate.SelectedDate
            + "&max=" + this.txtEndDate.SelectedDate
            + "&NickId=" + this.ddlNickList.SelectedValue
            + "&OrderStatusId=" + this.ddlOrderStatus.SelectedValue
            + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
            + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
            + "', 1000, 620, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

            #endregion

            #region 安装费
            tbInstallation.Text = InstallationCost.ToString();
            #endregion

            #region 运费

            decimal freight = 0;
            var DeliveryList = base.XMDeliveryService.GetXMDeliveryListPrice(min, max, int.Parse(cbXMProject), int.Parse(cbNick), int.Parse(PlatformTypeId));
            if (DeliveryList != null && DeliveryList.Count > 0)
            {
                freight = (decimal)DeliveryList.Sum(x => x.Price);
            }

            if (freight == 0)
            {
                //this.lblYFMonthMoney.Text=CountMoneySum6.ToString();
                if (CountMoneySum6Index == 0 && this.ddlXMProjectNameId.SelectedValue != "-1")
                {
                    //根据店铺项目 查询运费比例 
                    var xmproject = base.XMProjectService.GetXMProjectById(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue));
                    if (xmproject != null)
                    {
                        if (xmproject.ShipmentProportion != null)
                        {
                            decimal ShipmentProportion = xmproject.ShipmentProportion.Value / 100;

                            CountMoneySum6 = Math.Round((CountMoneySum1 - CountReturnMoneySum) * ShipmentProportion, 2);
                        }
                    }
                    this.txtYFMonthMoney.Text = CountMoneySum6.ToString();
                    this.txtYFMonthMoney.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    this.txtYFMonthMoney.Text = CountMoneySum6.ToString();
                    this.txtYFMonthMoney.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                CountMoneySum6 = freight;
                this.txtYFMonthMoney.Text = CountMoneySum6.ToString();
                this.txtYFMonthMoney.ForeColor = System.Drawing.Color.Red;
            }

            var year = 0;
            var month = 0;
            //var begin = this.txtBeginDate.SelectedDate;
            ////var begin = txtEndDate.ctlDateTime.Text;
            //var end = this.txtEndDate.SelectedDate;
            if (min.Year == max.Year && min.Month == max.Month)
            {
                year = max.Year;
                month = max.Month;
                if (this.ddlXMProjectNameId.SelectedValue != "-1" || this.ddlXMProjectNameId.SelectedValue != "0")
                {
                    var Info = base.CWStaffSpendingService.GetCWStaffSpendingInfo(this.ddlXMProjectNameId.SelectedValue, -1, year.ToString(), month.ToString(), 108, 505);//108-》运费，505-》大家居事业部
                    if (Info != null)
                    {
                        CountMoneySum6 = decimal.Parse(Info.CountMoney.ToString());
                        this.txtYFMonthMoney.Text = CountMoneySum6.ToString();
                        this.txtYFMonthMoney.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }

            //营业成本=进货成本+赠品成本+平台成本费用+运费+刷拍成本+返现成本+安装费
            decimal YYCBMonthMoney = Convert.ToDecimal(CountMoneySum4 - CountReturnCostSum) + Convert.ToDecimal(CountMoneySum24) + CountMoneySum5 + CountMoneySum6 + Convert.ToDecimal(CountMoneySum7) + Convert.ToDecimal(CountMoneySum8)+ Convert.ToDecimal(InstallationCost);

            this.lblYYCBMonthMoney.Text = YYCBMonthMoney.ToString();
            if (month != 0 && year != 0 && this.ddlXMProjectNameId.SelectedValue != "-1")
            {
                string paramScript6 = "return ShowWindowDetail('运费','" + CommonHelper.GetStoreLocation()
                 + "ManageFinance/OpenProfitOtherDataInput.aspx?DepartmentType=505&ProjectId=" + this.ddlXMProjectNameId.SelectedValue
                 + "&NickId=-1&Month=" + month + "&Year=" + year + "&FinancialFieldId=108"
                 + "',440,225, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                this.txtYFMonthMoney.Attributes.Add("onclick", paramScript6);
            }
            else
            {
                this.txtYFMonthMoney.Attributes.Add("onclick", "");
            }

            #endregion

            #region 增值税
            decimal ZZSMonthMoney = Math.Round((CountMoneySum1 - CountReturnMoneySum - (CountMoneySum4 - CountReturnCostSum)) / (decimal)1.17 * (decimal)0.17 - CountMoneySum6 / (decimal)1.06 * (decimal)0.06, 2);
            this.lblZZSMonthMoney.Text = ZZSMonthMoney.ToString();
            #endregion

            #region  刷拍成本
            this.lblSPCBMonthMoney.Text = CountMoneySum7.ToString();// 本月数
            lblSPCBMonthMoney.OnClientClick = "return ShowWindowDetail('刷单明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/XMScalpingDetailsSS.aspx?PlatformTypeId=" + PlatformTypeId
            + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
            + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
            + "&NickId=" + this.ddlNickList.SelectedValue
            + "&OrderStatusId=" + this.ddlOrderStatus.SelectedValue
            + "&min=" + (this.txtBeginDate.SelectedDate == null ? min : this.txtBeginDate.SelectedDate)
            + "&max=" + (this.txtEndDate.SelectedDate == null ? max.AddDays(-1) : this.txtEndDate.SelectedDate)
            + "', 1000, 500, this, function(){});";
            #endregion

            #region  返现成本
            this.lblFXCBMonthMoney.Text = CountMoneySum8.ToString();// 本月数
            lblFXCBMonthMoney.OnClientClick = "return ShowWindowDetail('返现明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/XMCashBackApplicationDetailsSS.aspx?PlatformTypeId=" + PlatformTypeId
            + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
            + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
            + "&NickId=" + this.ddlNickList.SelectedValue
            + "&OrderStatusId=" + this.ddlOrderStatus.SelectedValue
            + "&min=" + (this.txtBeginDate.SelectedDate == null ? min : this.txtBeginDate.SelectedDate)
            + "&max=" + (this.txtEndDate.SelectedDate == null ? max.AddDays(-1) : this.txtEndDate.SelectedDate)
            + "', 1000, 500, this, function(){});";
            #endregion

            #region  广告费用
            this.lblFEEMoney.Text = Math.Round(CountMoneySumFEE, 2).ToString();
            lblFEEMoney.OnClientClick = "return ShowWindowDetail('广告费用','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/XWAdvertisingSS.aspx?ProjectId=" + this.ddlXMProjectNameId.SelectedValue
            + "&NickId=" + this.ddlNickList.SelectedValue
            + "&DateTimeMin=" + (this.txtBeginDate.SelectedDate == null ? min : this.txtBeginDate.SelectedDate)
            + "&DateTimeMax=" + (this.txtEndDate.SelectedDate == null ? max.AddDays(-1) : this.txtEndDate.SelectedDate)
            + "', 1000, 500, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            #endregion

            #region 毛利
            //毛利=营业收入-增值税-营业成本-广告费
            decimal MLMonthMoney = Math.Round(CountMoneySum1 - CountReturnMoneySum - Convert.ToDecimal(this.lblZZSMonthMoney.Text) - Convert.ToDecimal(this.lblYYCBMonthMoney.Text) - Convert.ToDecimal(this.lblFEEMoney.Text), 2);
            //毛利占比
            if (CountMoneySum1 == 0)
            {
                this.lblMLBL.Text = "0%";
            }
            else
            {
                this.lblMLBL.Text = Math.Round((MLMonthMoney / (CountMoneySum1 - CountReturnMoneySum) * 100), 2).ToString() + "%";
            }
            this.lblMLMonthMoney.Text = MLMonthMoney.ToString();

            #endregion
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOrderInfoSalesDetailsExport_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                string filePath = string.Format("{0}Upload\\OrderInfoSalesDetailsExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                #region 条件查询

                //平台类型
                string PlatformTypeId = "-1";
                if (this.ddlPlatformTypeId.SelectedValue != null)
                {
                    PlatformTypeId = this.ddlPlatformTypeId.SelectedValue.ToString();
                }
                //string OrderInfoModifiedStart = "";//开始时间
                //string OrderInfoModifiedEnd = "";//结束时间
                //if (this.txtBeginDate.SelectedDate.HasValue)
                //{
                //    OrderInfoModifiedStart = this.txtBeginDate.SelectedDate.ToString();//开始时间
                //}
                //if (this.txtEndDate.SelectedDate.HasValue)
                //{
                //    OrderInfoModifiedEnd = this.txtEndDate.SelectedDate.ToString();//结束时间
                //}

                var OrderInfoModifiedStart = DateTime.Parse(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + "01");
                if (this.txtBeginDate.SelectedDate.HasValue)
                {
                    OrderInfoModifiedStart = this.txtBeginDate.SelectedDate.Value;
                }
                else
                {
                    OrderInfoModifiedStart = DateTime.Parse(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + "01");
                }
                var OrderInfoModifiedEnd = DateTime.Now;
                if (this.txtEndDate.SelectedDate.HasValue)
                {
                    OrderInfoModifiedEnd = this.txtEndDate.SelectedDate.Value.AddDays(1).AddSeconds(-1);
                }
                else
                {
                    OrderInfoModifiedEnd = DateTime.Now;
                }
                this.txtBeginDate.SelectedDate = OrderInfoModifiedStart;
                this.txtEndDate.SelectedDate = OrderInfoModifiedEnd;

                DateTime dt1 = DateTime.Now;//当前时间 
                DateTime dt = Convert.ToDateTime(dt1.ToString("yyyy-MM-dd"));

                //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
                var cbOrderStatusId = this.ddlOrderStatus.SelectedValue;

                //项目类型： 自运营、代运营
                string cbXMProjectTypeId = "-1";

                if (this.ddlXMProjectTypeId.SelectedValue != null)
                {
                    cbXMProjectTypeId = this.ddlXMProjectTypeId.SelectedValue.ToString();
                }

                //项目名称
                string cbXMProject = "-1";
                if (this.ddlXMProjectNameId.SelectedValue != null)
                {
                    cbXMProject = this.ddlXMProjectNameId.SelectedValue.ToString();
                }
                string cbNick = "-1";

                if (this.ddlNickList.SelectedValue != null)
                {
                    cbNick = this.ddlNickList.SelectedValue.ToString();
                }

                //店铺集合
                List<int> nickIdList = new List<int>();

                //合并新的list
                //List<CWProfitMapping> CWProfitMappingList = new List<CWProfitMapping>();

                #region 店铺条件查询集合 处理
                //选择某项目  
                if (cbXMProject != "-1")
                {
                    if (cbNick == "-1")//项目下的所有店铺
                    {
                        var nickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                        //var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                        if (nickList.Count > 0)
                        {
                            nickIdList = nickList.Select(p => p.nick_id).ToList();
                        }
                    }
                    else
                    {

                        nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                    }
                }
                else
                {
                    if (cbNick == "-1")
                    {
                        var NickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                        NickList = NickList.Where(p => p.nick_id != 29).ToList();

                        nickIdList = NickList.Select(a => a.nick_id).ToList();
                    }
                    else
                    {
                        nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                    }

                }
                #endregion

                // int ParentID = 0; //父级Id 
                #endregion

                #region 订单明细
                var xmOrderInfoList = base.XMOrderInfoService.getXMOrderInfoListToExport(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId), "");

                #region 取京东数据 （销售额=应收金额+配送运费）
                var OrderInfoJdList = (from p in xmOrderInfoList
                                       where p.PlatformTypeId == 251
                                       && p.NickID != 29
                                       select new OrderInfoSalesDetails
                                       {
                                           ID = p.ID,
                                           PlatformTypeId = p.PlatformTypeId,
                                           NickID = p.NickID,
                                           OrderCode = p.OrderCode,
                                           WantID = p.WantID,
                                           OrderInfoCreateDate = p.OrderInfoCreateDate,
                                           PayDate = p.PayDate,
                                           DeliveryTime = p.DeliveryTime,
                                           CompletionTime = p.CompletionTime,
                                           FullName = p.FullName,
                                           Mobile = p.Mobile,
                                           Tel = p.Tel,
                                           DistributePrice = p.DistributePrice == null ? 0 : p.DistributePrice.Value,
                                           ReceivablePrice = p.ReceivablePrice == null ? 0 : p.ReceivablePrice.Value,
                                           PayPrice = p.PayPrice + p.DistributePrice,
                                           SalesPrice = 0,
                                           ProjectId = p.ProjectId,
                                           ProjectName = p.ProjectName,
                                           PlatformTypeName = p.PlatformTypeName,
                                           NickName = p.NickName
                                       }).ToList();
                #endregion

                #region 排除京东数据
                var OrderInfoNotJdList = (from p in xmOrderInfoList
                                          where p.PlatformTypeId != 251
                                          select new OrderInfoSalesDetails
                                          {
                                              ID = p.ID,
                                              PlatformTypeId = p.PlatformTypeId,
                                              NickID = p.NickID,
                                              OrderCode = p.OrderCode,
                                              WantID = p.WantID,
                                              OrderInfoCreateDate = p.OrderInfoCreateDate,
                                              PayDate = p.PayDate,
                                              DeliveryTime = p.DeliveryTime,
                                              CompletionTime = p.CompletionTime,
                                              FullName = p.FullName,
                                              Mobile = p.Mobile,
                                              Tel = p.Tel,
                                              DistributePrice = p.DistributePrice == null ? 0 : p.DistributePrice.Value,
                                              ReceivablePrice = p.ReceivablePrice == null ? 0 : p.ReceivablePrice.Value,
                                              PayPrice = p.PayPrice,
                                              SalesPrice = 0,
                                              ProjectId = p.ProjectId,
                                              ProjectName = p.ProjectName,
                                              PlatformTypeName = p.PlatformTypeName,
                                              NickName = p.NickName
                                          }).ToList();

                #endregion

                //合并数据源

                var OrderInfoListNew = OrderInfoJdList.Concat(OrderInfoNotJdList).OrderByDescending(p => p.OrderCode).ToList();
            
                #endregion

                #region 产品明细

                //原数据源
                var OrderInfoSalesDetailsList = base.XMOrderInfoProductDetailsService.GetOrderInfoSalesDetailsListToExport(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId));

                //去掉重复订单 数据源
                var OrderInfoSalesDetailsListNew = OrderInfoSalesDetailsList.GroupBy(p => p.OrderCode).Select(g => g.First()).ToList();

                // 取出重复订单
                var NotDate = (from a in OrderInfoSalesDetailsList
                               where !OrderInfoSalesDetailsListNew.Contains(a)
                               select new OrderInfoSalesDetails
                               {
                                   ID = a.ID,
                                   OrderCode = a.OrderCode,
                                   PlatformTypeId = a.PlatformTypeId,
                                   DeliveryTime = a.DeliveryTime,
                                   PayDate = a.PayDate,
                                   OrderInfoCreateDate = a.OrderInfoCreateDate,
                                   DetailsID = a.DetailsID,
                                   PlatformMerchantCode = a.PlatformMerchantCode,
                                   ProductName = a.ProductName,
                                   Specifications = a.Specifications,
                                   ProductNum = a.ProductNum,
                                   FactoryPrice = a.FactoryPrice,
                                   ReceivablePrice = a.ReceivablePrice,
                                   DistributePrice = a.DistributePrice,
                                   PayPrice = 0,
                                   OrderPrice = a.OrderPrice,
                                   SalesPrice = a.SalesPrice,
                                   NickID = a.NickID,
                                   PlatformTypeName = a.PlatformTypeName,
                                   ProjectId = a.ProjectId,
                                   ProjectName = a.ProjectName,
                                   NickName = a.NickName,
                                   ManufacturersCode = a.ManufacturersCode,
                                   ProductId = a.ProductId,
                                   MarkDate = a.MarkDate
                               }).ToList();

                var OrderInfoSalesDetailsListDealWithNew = OrderInfoSalesDetailsListNew.Concat(NotDate).OrderByDescending(p => p.OrderCode).ToList();

                #endregion

                #region 产品统计
                List<OrderInfoSalesDetails> ProductSalesDetailsList =
                              OrderInfoSalesDetailsList.GroupBy(g => new { g.ProductName }).
                              Select(group => new OrderInfoSalesDetails()
                              {
                                  ProductName = group.Key.ProductName,
                                  FactoryPrice = group.Sum(l => l.FactoryPrice),
                                  ProductNum = group.Sum(l => l.ProductNum),
                                  AvgFactoryPrice = Math.Round(group.Sum(l => l.FactoryPrice.Value) / Convert.ToDecimal(group.Sum(l => l.ProductNum)), 2)
                              }).ToList();

                #endregion

                #region 返现明细
                List<OrderInfoSalesDetails> XMCashBackApplicationDetailsList = base.XMCashBackApplicationService.GetXMCashBackApplicationDetailsList(
              Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(StatusEnum.AlreadyCashBack), Convert.ToInt32(cbOrderStatusId));

                #endregion

                #region 刷单记录明细

                //刷单记录明细
                List<OrderInfoSalesDetails> XMScalpingDetailsList = base.XMScalpingService.GetXMScalpingDetailsList
                   (Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId));

                #endregion

                #region 赠品明细

                //赠品明细
                var XMOrderInfoAndPremiumsDetailsList = base.XMOrderInfoService.getXMOrderInfoAndPremiumsDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId));

                #endregion

                //退款金额明细
                var XMApplication = base.XMApplicationService.GetXMApplicationExcelData(Convert.ToInt32(PlatformTypeId), nickIdList, "", OrderInfoModifiedStart, OrderInfoModifiedEnd, Convert.ToInt32(cbOrderStatusId));

                //退货明细
                var BackProductDetails = base.XMOrderInfoProductDetailsService.GetBackProductDetails(Convert.ToInt32(PlatformTypeId), nickIdList, "", OrderInfoModifiedStart, OrderInfoModifiedEnd, Convert.ToInt32(cbOrderStatusId));

                base.ExportManager.ExportOrderInfoSalesDetailsXls(filePath, OrderInfoListNew, OrderInfoSalesDetailsListDealWithNew, ProductSalesDetailsList, XMCashBackApplicationDetailsList, XMScalpingDetailsList, XMOrderInfoAndPremiumsDetailsList, XMApplication, BackProductDetails);

                CommonHelper.WriteResponseXls(filePath, fileName);
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }

        /// <summary>
        /// 项目类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlXMProjectTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue) > 0)
            {
                var ProjectTypeList = base.XMProjectService.GetXMProjectProjectTypeId(Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));
                this.ddlXMProjectNameId.Items.Clear();
                this.ddlXMProjectNameId.DataSource = ProjectTypeList;
                this.ddlXMProjectNameId.DataTextField = "ProjectName";
                this.ddlXMProjectNameId.DataValueField = "Id";
                this.ddlXMProjectNameId.DataBind();
                this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlXMProjectNameId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //店铺数据源 
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue));
                this.ddlNickList.Items.Clear();
                // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                this.ddlNickList.DataSource = nickList;
                this.ddlNickList.DataTextField = "nick";
                this.ddlNickList.DataValueField = "nick_id";
                this.ddlNickList.DataBind();
                this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                //其他
                //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), HozestERPContext.Current.User.CustomerID, 362);
                this.ddlNickList.Items.Clear();
                // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                this.ddlNickList.DataSource = nickList;
                this.ddlNickList.DataTextField = "nick";
                this.ddlNickList.DataValueField = "nick_id";
                this.ddlNickList.DataBind();
                this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
            }

            //this.BindData();
        }

        /// <summary>
        /// 平台类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPlatformTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.BindData();
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

        /// <summary>
        /// 查询销售出库单明细
        /// </summary>
        /// <param name="List"></param>
        /// <param name="SaleList"></param>
        /// <param name="RejectedList"></param>
        /// <param name="ReturnList"></param>
        /// <param name="InventoryList"></param>
        /// <param name="WareHousesList"></param>
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
                        if (Info.SaleCount > 0 && TotalMoney > 0)
                        {
                            Info.CostPrice = Math.Round(TotalMoney / decimal.Parse(Info.SaleCount.ToString()), 2);
                        }
                        else
                        {
                            Info.CostPrice = 0;
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
    }
}