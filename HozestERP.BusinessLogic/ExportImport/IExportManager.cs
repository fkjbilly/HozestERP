using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using System.Data;

namespace HozestERP.BusinessLogic.ExportImport
{
    public interface IExportManager
    {
        /// <summary>
        /// 唯品会导出订单数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderInfos"></param>
        /// <param name="productInfos"></param>
        void ExportXMOrderInfoToXlsOfVPH(string filePath, List<XMOrderInfo> orderInfos, int projectID, bool IsAiPu, bool IsYingYi);

        /// <summary>
        /// 日日顺导出订单数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderInfos"></param>
        /// <param name="projectID"></param>
        void ExportRiRiShunXMOrderInfoToXls(string filePath, List<XMOrderInfo> orderInfos, int projectID);

        /// <summary>
        /// 理赔管理导出数据
        /// </summary>
        void ExportClaimInfoToXls(string filePath, List<XMClaimInfo> list);
        /// <summary>
        /// 财务数据导出
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        void ExportInvoiceInfoToXls(string filePath, List<XMInvoiceInfo> list);
        /// <summary>
        /// 电子发票数据导出
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        void ExportDzfpInfoToXls(string filePath, List<XMInvoiceInfo> list);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        void ExportAlipaymentDataToXls(string filePath, List<XMAlipaymentAccount> list);

        /// <summary>
        /// 唯品会物流导出
        /// </summary>
        void ExportVPHLogisticsToXls(string filePath, List<XMLogisticsInfo> list);
        /// <summary>
        /// 库存信息导出
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        void InventoryInfoToXls(string filePath, List<XMInventoryInfo> list);
        /// <summary>
        /// 导出刷单管理数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        void ExportScalpingInfoToXls(string filePath, List<XMScalping> list);

        /// <summary>
        /// 导出京东自营应采购量统计表
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        /// <param name="WareHouseNameList"></param>
        /// <param name="PlatformMerchantCodeList"></param>
        void ExportJDPurchaseProposalToXls(string filePath, List<PuchaseStrategyInfo> list, List<string> WareHouseNameList, List<string> PlatformMerchantCodeList);
        /// <summary>
        /// 月经销存库存实时统计信息导出
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        void MonthInventoryStatisticsInfoToXls(string filePath, List<XMInventoryInfoStatistics> list);
        /// <summary>
        /// 导出客服归属订单统计数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        void ExportCustomerSaleAnalysisToXls(string filePath, List<XMCustomerSaleAcountAnalysis> list);
        /// <summary>
        /// 采购入库单导出
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        void StorageInfoToXls(string filePath, List<XMStorage> list);
        /// <summary>
        /// 采购退货单产品数据导出
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        void ExportPurchaseRejectedDetail(string filePath, List<PurchaseRejectedDetail> list);
        /// <summary>
        /// Export XMOrderInfo to XLS(导出订单数据)
        /// </summary>
        /// <param name="filePath">File path to use</param>
        void ExportXMOrderInfoToXls(string filePath, List<XMOrderInfo> orderInfos, int projectID, bool IsAiPu, bool IsYingYi);

                /// <summary>
        /// 导出日销数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="XMDailySaleInfos"></param>
        void ExportDaliySaleToXls(string filePath, List<XMDailySaleInfo> XMDailySaleInfos);

        /// <summary>
        /// Export XMOrderInfo to XLS(导出曲美订单数据)
        /// </summary>
        /// <param name="filePath">File path to use</param>
        void ExportXMOrderInfoToXlsQM(string filePath, List<XMOrderInfo> orderInfos, int projectID, bool IsAiPu, bool IsYingYi);

        /// <summary>
        /// 导出发货清单excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        void ExportPostList(string filePath, List<XMDeliveryNew> orderLists);

        /// <summary>
        /// 导出发货清单excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        DataTable ExportPostList(List<XMDeliveryNew> orderLists);

        /// <summary>
        /// 导出发货清单excel（迪士尼）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        void ExportPostListFromNSN(string filePath, List<XMDeliveryNew> orderLists);
        /// <summary>
        /// 导出发货清单excel（迪士尼）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        DataTable ExportPostListFromNSN(List<XMDeliveryNew> orderLists);

        void ExportPostListFromInstallation(string filePath, List<XMInstallationListNew> installationList);

        void ExportPostListFromZM(string filePath, List<XMDeliveryNew> orderLists);
        DataTable ExportPostListFromZM( List<XMDeliveryNew> orderLists);

        void ExportPostListFromQM(string filePath, List<XMDeliveryNew> list);
        DataTable ExportPostListFromQM(List<XMDeliveryNew> list);

        void ExportPostListFromLYS(string filePath, List<XMDeliveryNew> list);
        DataTable ExportPostListFromLYS(List<XMDeliveryNew> list);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ExpressList"></param>
        void ExportExpressList(string filePath, List<XMNewExpressListManage> ExpressList);

        /// <summary>
        /// 导出快递账单信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="expressListManage"></param>
        void ExpressListManage(string filePath, List<XMExpressListManagement> expressListManage);

        /// <summary>
        /// 手动发货导出
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        void DeliverExportList(string filePath, List<XMDeliveryNew> orderLists);

        /// <summary>
        /// 发出商品库存
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        void DeliveryProductInventoryExportList(string filePath, List<XMDeliveryProductInventory> list, string ProjectName);

        /// <summary>
        /// 导出采购明细表 excel     （进销存系统）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        void ExportPurchaseDetail(string filePath, List<PurchaseDetail> orderLists);

        /// <summary>
        /// 导出每月销量明细   （进销存系统）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="saleDelvieryList"></param>
        void ExportSaleDeliveryDetail(string filePath, List<XMSaleDelivery> saleDelvieryList);

        /// <summary>
        /// Export QuestionDetailed_Result to XLS(导出问题处理数据)
        /// </summary>
        /// <param name="filePath">File path to use</param>
        void ExportQuestionDetailToXls(string filePath, List<QuestionDetailed_Result> orderInfos);

        /// <summary>
        /// 资金流水导出
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="financialCapitalList"></param>
        void ExportFinancialCapitalFlowToXls(string filePath, List<XMFinancialCapitalFlow> financialCapitalList);

        //导出索赔单Word
        void ExportClaimFormDocx(string filePath, int ID);

        //导出理赔单Word
        void ExportClaimInfoDocx(string filePath, int id);

        /// <summary>
        /// 导出销售明细
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="xmOrderInfoList">订单明细</param>
        /// <param name="OrderInfoSalesDetailsList">根据订单号去掉重复订单集合</param>
        /// <param name="ProductSalesDetailsList">产品统计</param>
        /// <param name="XMCashBackApplicationDetailsList">返现集合</param>
        /// <param name="XMScalpingDetailsList">刷单记录集合</param>
        /// <param name="BackProductDetails">退货商品集合</param>
        void ExportOrderInfoSalesDetailsXls(string filePath, List<OrderInfoSalesDetails> xmOrderInfoList, List<OrderInfoSalesDetails> OrderInfoSalesDetailsList, List<OrderInfoSalesDetails> ProductSalesDetailsList, List<OrderInfoSalesDetails> XMCashBackApplicationDetailsList, List<OrderInfoSalesDetails> XMScalpingDetailsList, List<OrderInfoSalesDetails> XMOrderInfoAndPremiumsDetailsList, List<XMApplication> xmApplication, List<XMBackProductDetails> BackProductDetails);

        /// <summary>
        /// 导出售前客服薪酬明细
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ExportXMPreSalesSalaryList">售前客服薪酬明细</param>
        void ExportPreServiceSalaryXls(string filePath, List<XMPreSalesSalary> ExportXMPreSalesSalaryList);

        /// <summary>
        /// 导出售后客服薪酬明细
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ExportXMPreSalesSalaryList">售后客服薪酬明细</param>
        void ExportAfterSalesSalaryXls(string filePath, List<XMCustomerServiceKPI> ExportAfterSalesSalaryList);

        /// <summary>
        /// 导出赠品明细
        /// </summary>
        /// <param name="filePath"></param>
        void ExportPremiumsXls(string filePath, List<XMPremiums> ExportXMPremiumsList);

        /// <summary>
        /// 导出咨询跟进
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ExportXMPreSalesSalaryList">导出咨询跟进</param>
        void ExportConsultationXls(string filePath, List<XMConsultation> ExportConsultationList);

        /// <summary>
        /// 导出销售数据分析
        /// </summary>
        void ExportDataAnalysisXls(string filePath, List<XMDataAnalysy> DataAnalysyAll, List<XMDataAnalysy> DataAnalysyTotal);

        /// <summary>
        /// 导出项目资金变动
        /// </summary>
        void ExportProjectCapitalChangesXls(string filePath, List<string> ExportList);

        /// <summary>
        /// 导出资金盘存
        /// </summary>
        void ExportCapitalInventoryXls(string filePath, List<string> ExportList);

        /// <summary>
        /// 导出未成交数据分析
        /// </summary>
        void ExportDataAnalysisXlsNoDeal(string filePath, List<XMDataAnalysy> DataAnalysyAll, List<XMDataAnalysy> DataAnalysyTotal);

        /// <summary>
        /// 导出问题数据分析-客服
        /// </summary>
        void ExportDataAnalysisXlsQuestion(string filePath, List<XMDataAnalysy> DataAnalysyAll, List<XMDataAnalysy> DataAnalysyTotal);

        /// <summary>
        /// 导出退换货数据分析-客服
        /// </summary>
        void ExportDataAnalysisXlsApplication(string filePath, List<XMDataAnalysy> DataAnalysyAll, List<XMDataAnalysy> DataAnalysyTotal);

        /// <summary>
        /// 导出问题数据分析-问题类型
        /// </summary>
        void ExportDataAnalysisXlsQuestionType(string filePath, List<XMDataAnalysy> DataAnalysyAll, List<XMDataAnalysy> DataAnalysyTotal, int nick_id);

        /// <summary>
        /// 导出退换货数据分析-退换货类型
        /// </summary>
        void ExportDataAnalysisXlsApplicationType(string filePath, List<XMDataAnalysy> DataAnalysyAll, List<XMDataAnalysy> DataAnalysyTotal);

        /// <summary>
        /// 导出产品销量统计
        /// </summary>
        void ExportProductSalesXls(string filePath, IEnumerable<ProductSalesData> ProductSalesList);

        /// <summary>
        /// 导出产品销量统计未发货
        /// </summary>
        void ExportProductSalesNotDeliXls(string filePath, IEnumerable<ProductSalesData> ProductSalesList);

        /// <summary>
        /// 根据项目ID 和部门ID  自动导出excel标准表格
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="depID"></param>
        void ExportFinancialFieldCostExcel(string filePath, int projectID, int depID);

        /// <summary>
        /// 导出京东自营退货单信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="data"></param>
        void ExportJDSaleRejectedExcel(string filePath, List<XMJDSaleRejectedExport> list);

        /// <summary>
        /// 导出带物流费用的订单信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name=""></param>
        void ExportOrderInfoWithLogisticsFeeExcel(string filePath, List<XMOrderInfo> list);

        /// <summary>
        /// 导出商品信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ProductName"></param>
        /// <param name="FactoryCode"></param>
        /// <param name="ProductCode"></param>
        /// <param name="BrandTypeId"></param>
        void ExportProductExcel(string filePath, List<XMProduct> list);

        /// <summary>
        /// 导出返现信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        void ExportCashBackExcel(string filePath, List<XMCashBackApplication> list);

        /// <summary>
        /// 导出物流对账明细
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        void ExportLogisticsStatistics(string filePath, List<XMLogisticsProject> list);
        /// <summary>
        /// 导出账单信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        void ExportXMBills(string filePath, List<XMBills> list);
    }
}
