using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Audit;
using HozestERP.BusinessLogic.Audit.UsersOnline;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Customers;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ExportImport;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.ManageFile;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageProtal;
using HozestERP.BusinessLogic.ManageStock;
using HozestERP.BusinessLogic.ManageTableLog;
using HozestERP.BusinessLogic.Media;
using HozestERP.BusinessLogic.ModuleManagement;
using HozestERP.BusinessLogic.Notices;
using HozestERP.BusinessLogic.PlatOrderGrab;
using HozestERP.BusinessLogic.Security;
using HozestERP.BusinessLogic.ManageBulletin;
using HozestERP.BusinessLogic.ManageProductionOrder;

namespace HozestERP.Web
{
    public partial class BasePage : System.Web.UI.Page
    {

        public BasePage()
        {

        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            //theme
            if (!String.IsNullOrEmpty(HozestERPContext.Current.WorkingTheme))
            {
                this.Theme = HozestERPContext.Current.WorkingTheme;
            }
            this.Error += new EventHandler(BasePage_Error);
        }

        void BasePage_Error(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool GetRoles(int customerId)
        {

            bool retu = false;
            var customerroleList = IoC.Resolve<ICustomerService>().GetCustomerRolesByCustomerId(customerId);//用户权限表
            foreach (var s in customerroleList)
            {
                if (s.CustomerRoleID == 10000062)//客户查看
                {
                    retu = true;
                }
            }

            return retu;

        }

        /// <summary>
        /// Gets a value indicating whether this page is tracked by 'Online Customers' module
        /// </summary>
        public virtual bool TrackedByOnlineCustomersModule
        {
            get
            {
                return true;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            //online user tracking
            if (this.TrackedByOnlineCustomersModule)
            {
                this.OnlineUserService.TrackCurrentUser();
            }

            base.OnPreRender(e);
        }

        #region Services, managers

        public IOnlineUserService OnlineUserService
        {
            get { return IoC.Resolve<IOnlineUserService>(); }
        }

        public ISettingManager SettingManager
        {
            get { return IoC.Resolve<ISettingManager>(); }
        }

        public ILogService LogService
        {
            get { return IoC.Resolve<ILogService>(); }
        }

        public ICustomerService CustomerService
        {
            get { return IoC.Resolve<ICustomerService>(); }
        }

        public ICustomerInfoService CustomerInfoService
        {
            get { return IoC.Resolve<ICustomerInfoService>(); }
        }

        public IModuleService ModuleService
        {
            get { return IoC.Resolve<IModuleService>(); }
        }

        public IACLService ACLService
        {
            get { return IoC.Resolve<IACLService>(); }
        }

        public INoticeService NoticeService
        {
            get { return IoC.Resolve<INoticeService>(); }
        }

        public IEnterpriseService EnterpriseService
        {
            get { return IoC.Resolve<IEnterpriseService>(); }
        }

        public ICodeTypeService CodeTypeService
        {
            get { return IoC.Resolve<ICodeTypeService>(); }
        }

        public ICodeService CodeService
        {
            get { return IoC.Resolve<ICodeService>(); }
        }

        public IAreaCodeService AreaCodeService
        {
            get { return IoC.Resolve<IAreaCodeService>(); }
        }

        public IPictureService PictureService
        {
            get { return IoC.Resolve<IPictureService>(); }
        }

        public IPortalService PortalService
        {
            get { return IoC.Resolve<IPortalService>(); }
        }

        public IFileService FileService
        {
            get { return IoC.Resolve<IFileService>(); }
        }

        public ITableUpdateLogService TableUpdateLogService
        {
            get { return IoC.Resolve<ITableUpdateLogService>(); }
        }

        public IImportManager ImportManager
        {
            get { return IoC.Resolve<IImportManager>(); }
        }

        public IExportManager ExportManager
        {
            get { return IoC.Resolve<IExportManager>(); }
        }

        public IXMOrderInfoAppService XMOrderInfoAppService
        {
            get { return IoC.Resolve<IXMOrderInfoAppService>(); }
        }

        public IProjectService ProjectService
        {
            get { return IoC.Resolve<IProjectService>(); }
        }
        public IAdvanceApplicationService AdvanceApplicationService
        {
            get { return IoC.Resolve<IAdvanceApplicationService>(); }
        }
        public IXMNickService XMNickService
        {
            get { return IoC.Resolve<IXMNickService>(); }
        }
        public IXMNickCustomerMappingService XMNickCustomerMappingService
        {
            get { return IoC.Resolve<IXMNickCustomerMappingService>(); }
        }
        public IXMProjectService XMProjectService
        {
            get { return IoC.Resolve<IXMProjectService>(); }
        }
        public IAdvanceApplicationDetailService AdvanceApplicationDetailService
        {
            get { return IoC.Resolve<IAdvanceApplicationDetailService>(); }
        }
        public IXMProductService XMProductService
        {
            get { return IoC.Resolve<IXMProductService>(); }
        }
        public IXMProductDetailsService XMProductDetailsService
        {
            get { return IoC.Resolve<IXMProductDetailsService>(); }
        }

        public IKFChatLogService KFChatLogService
        {
            get { return IoC.Resolve<IKFChatLogService>(); }
        }

        public IXMOrderInfoService XMOrderInfoService
        {
            get { return IoC.Resolve<IXMOrderInfoService>(); }
        }

        public IXMOrderInfoProductDetailsService XMOrderInfoProductDetailsService
        {
            get { return IoC.Resolve<IXMOrderInfoProductDetailsService>(); }
        }

        public IXMOrderInfoOperatingRecordService XMOrderInfoOperatingRecordService
        {
            get { return IoC.Resolve<IXMOrderInfoOperatingRecordService>(); }
        }

        public IXMOrderInfoPlanRecordService XMOrderInfoPlanRecordService
        {
            get { return IoC.Resolve<IXMOrderInfoPlanRecordService>(); }
        }

        public IXMOrderInfoAPIService XMOrderInfoAPIService
        {
            get { return IoC.Resolve<IXMOrderInfoAPIService>(); }
        }

        public IXMScalpingApplicationService XMScalpingApplicationService
        {
            get { return IoC.Resolve<IXMScalpingApplicationService>(); }
        }

        public IXMScalpingApplicationDetailsService XMScalpingApplicationDetailsService
        {
            get { return IoC.Resolve<IXMScalpingApplicationDetailsService>(); }
        }
        public IXMScalpingService XMScalpingService
        {
            get { return IoC.Resolve<IXMScalpingService>(); }
        }

        public IXMCashBackApplicationService XMCashBackApplicationService
        {
            get { return IoC.Resolve<IXMCashBackApplicationService>(); }
        }

        public IXMCompanyCustomService XMCompanyCustomService
        {
            get { return IoC.Resolve<IXMCompanyCustomService>(); }
        }

        public IXMDeliveryService XMDeliveryService
        {
            get { return IoC.Resolve<IXMDeliveryService>(); }
        }

        public IXMDeliveryDetailsService XMDeliveryDetailsService
        {
            get { return IoC.Resolve<IXMDeliveryDetailsService>(); }
        }

        public IXMDeductionSetUpService XMDeductionSetUpService
        {
            get { return IoC.Resolve<IXMDeductionSetUpService>(); }
        }

        public IXMPremiumsService XMPremiumsService
        {
            get { return IoC.Resolve<IXMPremiumsService>(); }
        }
        public IXMPremiumsDetailsService XMPremiumsDetailsService
        {
            get { return IoC.Resolve<IXMPremiumsDetailsService>(); }
        }

        public IXMQuestionService XMQuestionService
        {
            get { return IoC.Resolve<IXMQuestionService>(); }
        }
        public IXMQuestionDetailService XMQuestionDetailService
        {
            get { return IoC.Resolve<IXMQuestionDetailService>(); }
        }

        public IXMQuestionCategoryService XMQuestionCategoryService
        {
            get { return IoC.Resolve<IXMQuestionCategoryService>(); }
        }

        public IXMCommunicationRecordService XMCommunicationRecordService
        {
            get { return IoC.Resolve<IXMCommunicationRecordService>(); }
        }

        public IXMCustomerServiceLevelService XMCustomerServiceLevelService
        {
            get { return IoC.Resolve<IXMCustomerServiceLevelService>(); }
        }

        public IXMDSRService XMDSRService
        {
            get { return IoC.Resolve<IXMDSRService>(); }
        }

        public IXMWangNoService XMWangNoService
        {
            get { return IoC.Resolve<IXMWangNoService>(); }
        }

        public IXMCustomerWangNoService XMCustomerWangNoService
        {
            get { return IoC.Resolve<IXMCustomerWangNoService>(); }
        }

        public IXMCustomerRankService XMCustomerRankService
        {
            get { return IoC.Resolve<IXMCustomerRankService>(); }
        }


        public ICWProjectService CWProjectService
        {
            get { return IoC.Resolve<ICWProjectService>(); }
        }
        public ICWProfitService CWProfitService
        {
            get { return IoC.Resolve<ICWProfitService>(); }
        }
        public ICWStaffSpendingService CWStaffSpendingService
        {
            get { return IoC.Resolve<ICWStaffSpendingService>(); }
        }

        public ICWPlatformSpendingService CWPlatformSpendingService
        {
            get { return IoC.Resolve<ICWPlatformSpendingService>(); }
        }

        public IXMCombinationService XMCombinationService
        {
            get { return IoC.Resolve<IXMCombinationService>(); }
        }

        public IXMCombinationDetailsService XMCombinationDetailsService
        {
            get { return IoC.Resolve<IXMCombinationDetailsService>(); }
        }

        public IXMProductCombinationService XMProductCombinationService
        {
            get { return IoC.Resolve<IXMProductCombinationService>(); }
        }

        //岗位
        public IXMPostService XMPostService
        {
            get { return IoC.Resolve<IXMPostService>(); }
        }

        //postshop
        public IPostshoplistService PostshoplistService
        {
            get { return IoC.Resolve<IPostshoplistService>(); }
        }

        //售后数据
        public IXMAfterSalesDataService XMAfterSalesDataService
        {
            get { return IoC.Resolve<IXMAfterSalesDataService>(); }
        }

        //广告费
        public IXMAdvertisingFeeService XMAdvertisingFeeService
        {
            get { return IoC.Resolve<IXMAdvertisingFeeService>(); }
        }
        //广告费字段管理
        public IXMAdvertingFieldService XMAdvertingFieldService
        {
            get { return IoC.Resolve<IXMAdvertingFieldService>(); }
        }
        //店铺广告费字段设置
        public IXMNickIncludeAdveringFieldService XMNickIncludeAdveringFieldService
        {
            get { return IoC.Resolve<IXMNickIncludeAdveringFieldService>(); }
        }
        //店铺广告费明细
        public IXMAdvertisingFeeDetailService XMAdvertisingFeeDetailService
        {
            get { return IoC.Resolve<IXMAdvertisingFeeDetailService>(); }
        }

        //咨询跟进
        public IXMConsultationService XMConsultationService
        {
            get { return IoC.Resolve<IXMConsultationService>(); }
        }

        //咨询跟进子
        public IXMConsultationDetailsService XMConsultationDetailsService
        {
            get { return IoC.Resolve<IXMConsultationDetailsService>(); }
        }

        //仓库
        public IXMWarehouseService XMWarehouseService
        {
            get { return IoC.Resolve<IXMWarehouseService>(); }
        }

        //退换货
        public IXMApplicationService XMApplicationService
        {
            get { return IoC.Resolve<IXMApplicationService>(); }
        }

        //退换货从表
        public IXMApplicationExchangeService XMApplicationExchangeService
        {
            get { return IoC.Resolve<IXMApplicationExchangeService>(); }
        }

        //赠品入库记录
        public IXMGiftStorageRecordService XMGiftStorageRecordService
        {
            get { return IoC.Resolve<IXMGiftStorageRecordService>(); }
        }

        //索赔单
        public IXMClaimFormService XMClaimFormService
        {
            get { return IoC.Resolve<IXMClaimFormService>(); }
        }

        public IXMClaimFormDetailService XMClaimFormDetailService
        {
            get { return IoC.Resolve<IXMClaimFormDetailService>(); }
        }

        //薪资管理
        public ICustomerSalaryService CustomerSalaryService
        {
            get { return IoC.Resolve<ICustomerSalaryService>(); }
        }

        //业务数据
        public IXMBusinessDataService XMBusinessDataService
        {
            get { return IoC.Resolve<IXMBusinessDataService>(); }
        }

        //业务数据详细
        public IXMBusinessDataDetailService XMBusinessDataDetailService
        {
            get { return IoC.Resolve<IXMBusinessDataDetailService>(); }
        }

        /// <summary>
        /// 店铺月度目标值数据
        /// </summary>
        public IXMNickMonthlyTargetService XMNickMonthlyTargetService
        {
            get { return IoC.Resolve<IXMNickMonthlyTargetService>(); }
        }

        /// <summary>
        /// 喜临门项目达成值数据
        /// </summary>
        public IXMNickAchieveValueService XMNickAchieveValueService
        {
            get { return IoC.Resolve<IXMNickAchieveValueService>(); }
        }

        /// <summary>
        /// 其他收入目标值数据
        /// </summary>
        public IXMOtherMonthlyTargetService XMOtherMonthlyTargetService
        {
            get { return IoC.Resolve<IXMOtherMonthlyTargetService>(); }
        }

        //业务数据其他
        public IXMBusinessDataOtherService XMBusinessDataOtherService
        {
            get { return IoC.Resolve<IXMBusinessDataOtherService>(); }
        }
        //财务预算字段管理
        public IXMFinancialFieldService XMFinancialFieldService
        {
            get { return IoC.Resolve<IXMFinancialFieldService>(); }
        }
        //项目，部门包括字段
        public IXMIncludeFieldsService XMIncludeFieldsService
        {
            get { return IoC.Resolve<IXMIncludeFieldsService>(); }
        }
        //项目预算明细
        public IXMProjectCostDetailService XMProjectCostDetailService
        {
            get { return IoC.Resolve<IXMProjectCostDetailService>(); }
        }
        //B2BB2C 预算明细
        public IXMOtherCostDetailService XMOtherCostDetailService
        {
            get { return IoC.Resolve<IXMOtherCostDetailService>(); }
        }

        //根据订单修改时间获取订单信息
        public IVipapis XMVipapis
        {
            get { return IoC.Resolve<Vipapis>(); }
        }

        //财务资金流水
        public IXMFinancialCapitalFlowService XMFinancialCapitalFlowService
        {
            get { return IoC.Resolve<IXMFinancialCapitalFlowService>(); }
        }

        //社保公积金
        public ISocialSecurityFundService SocialSecurityFundService
        {
            get { return IoC.Resolve<ISocialSecurityFundService>(); }
        }

        ////供应商管理
        public IXMSuppliersService XMSuppliersService
        {
            get { return IoC.Resolve<IXMSuppliersService>(); }
        }

        //////仓库管理
        public IXMWareHousesService XMWareHousesService
        {
            get { return IoC.Resolve<IXMWareHousesService>(); }
        }
        //物流跟踪信息
        public IXMLogisticsInfoService XMLogisticsInfoService
        {
            get { return IoC.Resolve<IXMLogisticsInfoService>(); }
        }

        //物流时效
        public ILogisticsAgingService LogisticsAgingService
        {
            get { return IoC.Resolve<ILogisticsAgingService>(); }
        }

        //采购订单
        public IXMPurchaseService XMPurchaseService
        {
            get { return IoC.Resolve<IXMPurchaseService>(); }
        }
        //采购单详情
        public IXMPurchaseProductDetailsService XMPurchaseProductDetailsService
        {
            get { return IoC.Resolve<IXMPurchaseProductDetailsService>(); }
        }
        //采购入库单
        public IXMStorageService XMStorageService
        {
            get { return IoC.Resolve<IXMStorageService>(); }
        }
        //采购入库产品明细表
        public IXMStorageProductDetailsService XMStorageProductDetailsService
        {
            get { return IoC.Resolve<IXMStorageProductDetailsService>(); }
        }
        //采购退货单
        public IXMPurchaseRejectedService XMPurchaseRejectedService
        {
            get { return IoC.Resolve<IXMPurchaseRejectedService>(); }
        }
        //采购退货产品明细表
        public IXMPurchaseRejectedProductDetailsService XMPurchaseRejectedProductDetailsService
        {
            get { return IoC.Resolve<IXMPurchaseRejectedProductDetailsService>(); }
        }
        // //库存表
        public IXMInventoryInfoService XMInventoryInfoService
        {
            get { return IoC.Resolve<IXMInventoryInfoService>(); }
        }
        //销售订单
        public IXMSaleInfoService XMSaleInfoService
        {
            get { return IoC.Resolve<IXMSaleInfoService>(); }
        }
        //销售订单产品明细表
        public IXMSaleInfoProductDetailsService XMSaleInfoProductDetailsService
        {
            get { return IoC.Resolve<IXMSaleInfoProductDetailsService>(); }
        }
        //销售出库单
        public IXMSaleDeliveryService XMSaleDeliveryService
        {
            get { return IoC.Resolve<IXMSaleDeliveryService>(); }
        }
        //销售出库产品明细表
        public IXMSaleDeliveryProductDetailsService XMSaleDeliveryProductDetailsService
        {
            get { return IoC.Resolve<IXMSaleDeliveryProductDetailsService>(); }
        }
        //销售退货入库单
        public IXMSaleReturnService XMSaleReturnService
        {
            get { return IoC.Resolve<IXMSaleReturnService>(); }
        }
        //销售退货产品明细表
        public IXMSaleReturnProductDetailsService XMSaleReturnProductDetailsService
        {
            get { return IoC.Resolve<IXMSaleReturnProductDetailsService>(); }
        }
        //调整单
        public IXMAdjustedInfoService XMAdjustedInfoService
        {
            get { return IoC.Resolve<IXMAdjustedInfoService>(); }
        }
        //调整单产品明细表
        public IXMAdjustedProductDetailService XMAdjustedProductDetailService
        {
            get { return IoC.Resolve<IXMAdjustedProductDetailService>(); }
        }
        //盘点单
        public IXMPdInfoService XMPdInfoService
        {
            get { return IoC.Resolve<IXMPdInfoService>(); }
        }
        //盘点单明细表
        public IXMPdInfoProductDetailsService XMPdInfoProductDetailsService
        {
            get { return IoC.Resolve<IXMPdInfoProductDetailsService>(); }
        }

        //库存总账单
        public IXMInventoryLedgerService XMInventoryLedgerService
        {
            get { return IoC.Resolve<IXMInventoryLedgerService>(); }
        }

        //库存总账明细表
        public IXMInventoryLedgerDetailService XMInventoryLedgerDetailService
        {
            get { return IoC.Resolve<IXMInventoryLedgerDetailService>(); }
        }

        //全国仓库设置
        public IProvinceWarehouseService ProvinceWarehouseService
        {
            get { return IoC.Resolve<IProvinceWarehouseService>(); }
        }

        //调拨单主表
        public IXMAllocateInfoService XMAllocateInfoService
        {
            get { return IoC.Resolve<IXMAllocateInfoService>(); }
        }
        /// <summary>
        /// 京东自营退货单
        /// </summary>
        public IXMJDSaleRejectedService XMJDSaleRejectedService
        {
            get { return IoC.Resolve<IXMJDSaleRejectedService>(); }
        }
        /// <summary>
        /// 京东自营退货单产品详情
        /// </summary>
        public IXMJDSaleRejectedProductDetailService XMJDSaleRejectedProductDetailService
        {
            get { return IoC.Resolve<IXMJDSaleRejectedProductDetailService>(); }
        }

        //调拨单产品明细从表
        public IXMAllocateProductDetailsService XMAllocateProductDetailsService
        {
            get { return IoC.Resolve<IXMAllocateProductDetailsService>(); }
        }

        //喜临门当日发货库存
        public IXMXLMInventoryService XMXLMInventoryService
        {
            get { return IoC.Resolve<IXMXLMInventoryService>(); }
        }

        //入库产品条形码明细表
        public IXMStorageProductBarCodeDetailService XMStorageProductBarCodeDetailService
        {
            get { return IoC.Resolve<IXMStorageProductBarCodeDetailService>(); }
        }

        //销售出库产品条形码明细表
        public IXMSaleDeliveryBarCodeDetailService XMSaleDeliveryBarCodeDetailService
        {
            get { return IoC.Resolve<IXMSaleDeliveryBarCodeDetailService>(); }
        }

        //销售退货产品条形码明细表
        public IXMSaleReturnBarCodeDetailService XMSaleReturnBarCodeDetailService
        {
            get { return IoC.Resolve<IXMSaleReturnBarCodeDetailService>(); }
        }

        //产品库存条形码明细表
        public IXMInventoryBarcodeDetailService XMInventoryBarcodeDetailService
        {
            get { return IoC.Resolve<IXMInventoryBarcodeDetailService>(); }
        }

        //调拨单产品条形码明细表
        public IXMAllocateProductBarCodeDetailService XMAllocateProductBarCodeDetailService
        {
            get { return IoC.Resolve<IXMAllocateProductBarCodeDetailService>(); }
        }

        /// <summary>
        /// 库存信息实时统计
        /// </summary>
        public IXMInventoryInfoStatisticsService XMInventoryInfoStatisticsService
        {
            get { return IoC.Resolve<IXMInventoryInfoStatisticsService>(); }
        }

        /// <summary>
        /// 付款申请单
        /// </summary>
        public IXMPaymentApplyService XMPaymentApplyService
        {
            get { return IoC.Resolve<IXMPaymentApplyService>(); }
        }

        //每日销量数据
        public IXMDailySaleInfoService XMDailySaleInfoService
        {
            get { return IoC.Resolve<IXMDailySaleInfoService>(); }
        }
        //活动
        public IXMActivityService XMActivityService
        {
            get { return IoC.Resolve<IXMActivityService>(); }
        }
        //活动类型
        public IXMActivityTypeService XMActivityTypeService
        {
            get { return IoC.Resolve<IXMActivityTypeService>(); }
        }

        //备用仓库
        public IProvinceWarehouseSpareService ProvinceWarehouseSpareService
        {
            get { return IoC.Resolve<IProvinceWarehouseSpareService>(); }
        }

        //备用地址
        public IXMSpareAddressService XMSpareAddressService
        {
            get { return IoC.Resolve<IXMSpareAddressService>(); }
        }

        public IXMClaimInfoService XMClaimInfoService
        {
            get { return IoC.Resolve<IXMClaimInfoService>(); }
        }

        public IXMClaimInfoDetailService XMClaimInfoDetailService
        {
            get { return IoC.Resolve<IXMClaimInfoDetailService>(); }
        }

        //发票管理主表
        public IXMInvoiceInfoService XMInvoiceInfoService
        {
            get { return IoC.Resolve<IXMInvoiceInfoService>(); }
        }

        //发票管理从表
        public IXMInvoiceInfoDetailService XMInvoiceInfoDetailService
        {
            get { return IoC.Resolve<IXMInvoiceInfoDetailService>(); }
        }

        //发出商品库存
        public IXMDeliveryProductInventoryService XMDeliveryProductInventoryService
        {
            get { return IoC.Resolve<IXMDeliveryProductInventoryService>(); }
        }

        //快递管理
        public IXMExpressManagementService XMExpressManagementService
        {
            get { return IoC.Resolve<IXMExpressManagementService>(); }
        }
        //快递账单管理
        public IXMExpressListManagementService XMExpressListManagementService
        {
            get { return IoC.Resolve<IXMExpressListManagementService>(); }
        }

        //公告管理
        public IBulletinService BulletinService
        {
            get { return IoC.Resolve<IBulletinService>(); }
        }

        //理赔产品明细表
        public IXMClaimInfoProductDetailsService XMClaimInfoProductDetailsService
        {
            get { return IoC.Resolve<IXMClaimInfoProductDetailsService>(); }
        }

        //理赔管理图片子表
        public IXMClaimInfoPictureService XMClaimInfoPictureService
        {
            get { return IoC.Resolve<IXMClaimInfoPictureService>(); }
        }

        public IXMJDZYSaleCoefficientsService XMJDZYSaleCoefficientsService
        {
            get { return IoC.Resolve<IXMJDZYSaleCoefficientsService>(); }
        }
        /// <summary>
        /// 京东自营实时库存管理（依据京东自营销售表格导入）
        /// </summary>
        public IXMJDRealTimeInventoryService XMJDRealTimeInventoryService
        {
            get { return IoC.Resolve<IXMJDRealTimeInventoryService>(); }
        }
        /// <summary>
        /// 生产单主表
        /// </summary>
        public IXMProductionOrderService XMProductionOrderService
        {
            get { return IoC.Resolve<IXMProductionOrderService>(); }
        }
        /// <summary>
        /// 生产单产品明细从表
        /// </summary>
        public IXMProductionOrderDetailsService XMProductionOrderDetailsService
        {
            get { return IoC.Resolve<IXMProductionOrderDetailsService>(); }
        }

        /// <summary>
        /// 安装单
        /// </summary>
        public IXMInstallationListService XMInstallationListService
        {
            get { return IoC.Resolve<IXMInstallationListService>(); }
        }

        /// <summary>
        /// 安装类型
        /// </summary>
        public IXMTypeTestService XMTypeTestService
        {
            get { return IoC.Resolve<IXMTypeTestService>(); }
        }

        /// <summary>
        /// 安装要求
        /// </summary>
        public IXMZMDemandService XMZMDemandService
        {
            get { return IoC.Resolve<IXMZMDemandService>(); }
        }

        /// <summary>
        /// 安装预约单
        /// </summary>
        public IXMZMReservationService XMZMReservationService
        {
            get { return IoC.Resolve<IXMZMReservationService>(); }
        }

        /// <summary>
        /// 账单管理
        /// </summary>
        public IXMBillsService XMBillsservice
        {
            get { return IoC.Resolve<IXMBillsService>(); }
        }


        public IXMLogisticsFeeMainService XMLogisticsFeeMainService
        {
            get { return IoC.Resolve<IXMLogisticsFeeMainService>(); }
        }

        public IXMLogisticsFeeBranchService XMLogisticsFeeBranchService
        {
            get { return IoC.Resolve<IXMLogisticsFeeBranchService>(); }
        }

        public IXMLogisticsFeeDetailService XMLogisticsFeeDetailService
        {
            get { return IoC.Resolve<IXMLogisticsFeeDetailService>(); }
        }

        public IXMWorkerInfoService XMWorkerInfoService
        {
            get { return IoC.Resolve<IXMWorkerInfoService>(); }
        }

        public IXMClaimReasonService XMClaimReasonService
        {
            get { return IoC.Resolve<IXMClaimReasonService>(); }
        }

        public IXMLogisticsCostService XMLogisticsCostService
        {
            get { return IoC.Resolve<IXMLogisticsCostService>(); }
        }
        #endregion
    }
}
