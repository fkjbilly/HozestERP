using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ExportImport
{
    public interface IImportManager
    {
        void ImportAmazonOrderDataFromXls(string filePath, ref string paramMessage, string sourceType);

        void ImportOrderFromXls(string filePath, DateTime weekDate, int PlatformTypeNameId, int NickId, string PlatformTypeName, string FileName, ref string paramMessage, string sourceType);

        void ImportOrderFromXlsTM(string filePath, string filePath2, DateTime weekDate, int PlatformTypeNameId, int NickId, string PlatformTypeName, string FileName, string FileName2, ref string paramMessage, string sourceType);

        void ImportLogisticsNumberDataFromXls(string filePath, DateTime weekDate, int DeliveryTypeId, string DeliveryTypeIdName, ref string paramMessage, int xMProjectID, int wareHousesID);

        void ImportImportDeliver(string filePath, ref string paramMessage);

        void ImportImportReconciliation(string filePath, ref string paramMessage);

        void ImportImportCustomerSalary(string filePath, ref string paramMessage);

        void ImportSocialSecurityFund(string filePath, ref string paramMessage);

        void ImportBusinessDataB2B(string filePath, ref string paramMessage);

        void ImportProductList(string filePath, ref string paramMessage);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        void ImportProductionNumberFromXls(string filePath, ref string paramMessage);
        /// <summary>
        /// 导入支付宝订单数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        /// <param name="PlatformTypeId"></param>
        void ImportAlipaymentData(string filePath, ref string paramMessage, int PlatformTypeId, string fieldName);

        void ImportXLMInventory(string filePath, ref string paramMessage);
        /// <summary>
        /// 导入京东实时库存（根据京东销售单导入数据）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        void ImportJDRealTimeInventory(string filePath, ref string paramMessage, int nickId);
        /// <summary>
        /// 导入物流费用
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        void ImportLogisticsCostData(string filePath, ref string paramMessage);

        void ImportReturnedLogisticsFee(string filePath, ref string paramMessage);

        void ImportPurchaseLogisticsFee(string filePath, ref string paramMessage);

        void ImportLogisticsCost(string filePath, ref string paramMessage);

        void ImportJdSaleLogisticsFee(string filePath, ref string paramMessage);
        /// <summary>
        /// 导入快递账单
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        /// <param name="expressID"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        void ImportExpressList(string filePath, ref string paramMessage, int expressID, int year, int month);

        /// <summary>
        /// 根据店铺获取仓库列表  导入各个仓库销量数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        /// <param name="NickId"></param>
        void ImportSaleDeliveryList(string filePath, ref string paramMessage, int NickId, string begin);
        /// <summary>
        /// 导入日销售表格
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        /// <param name="NickId"></param>
        void ImportDailySaleProductList(string filePath, ref string paramMessage, int NickId, string begin);

        //物流时效导入
        void ImportLogisticsAging(string filePath, ref string paramMessage);

        //运单承运商导入
        void ImportVPHLogistics(string filePath, ref string paramMessage);

        /// <summary>
        /// 导入预算字段数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        /// <param name="projectID"></param>
        /// <param name="depID"></param>
        void ImportFinancialCost(string filePath, ref string paramMessage, int projectID, int depID, int year);

        /// <summary>
        /// 导入订单记录
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="weekDate"></param>
        /// <param name="FileName"></param>
        /// <param name="paramMessage"></param>
        void ImportScalpingRecordXls(string filePath, DateTime weekDate, string FileName, ref string paramMessage);


        /// <summary>
        /// 导入客服旺旺号订单数据
        /// </summary>
        string ImportPreOrderFromXlsTM(string filePath, string NickName, string FileName, string type, int PlatformTypeNameId, int NickId);

        /// <summary>
        /// 9.9大礼包导入赠品
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        void ImportBigGiftPacksDataFromXls(string filePath, ref string paramMessage, string platNum);

        /// <summary>
        /// 导入赠品
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        void ImportPremiumsDataFromXls(string filePath, ref string paramMessage);

        /// <summary>
        /// 无订单赠品导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        void ImportNoOrderFromXls(string filePath, ref string paramMessage);
        /// <summary>
        /// 导入京东自营采购订单 根据千胜采购单格式导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        void ImportJDSelfPurchaseSupportFromXls(string filePath, ref string paramMessage);

        /// <summary>
        /// 导入京东自营采购入库单
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        void ImportJDSelfSupportFromXls(string filePath, ref string paramMessage);

        /// <summary>
        /// 订单归属客服导入
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="paramMessage">返回结果</param>
        void ImportOrderAscriptionFormXls(string filePath, ref string paramMessage);

        /// <summary>
        /// 物流干线费用导入
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="paramMessage">返回结果</param>
        void ImportLogisticsFeeMainXls(string filePath, ref string paramMessage);

        /// <summary>
        /// 理赔管路页面数据导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        void ImportClaimInfoXls(string filePath, ref string paramMessage);

        /// <summary>
        /// 导入产品出厂价
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        void ImportFactoryPriceXls(string filePath, ref string paramMessage);
        /// <summary>
        /// 导入供应商账单
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        void ImportBillsXls(string filePath,int SuppliersId, ref string paramMessage);
    }
}
