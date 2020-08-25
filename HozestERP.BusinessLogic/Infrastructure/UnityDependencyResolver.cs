
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.EntityClient;
using HozestERP.BusinessLogic.Audit;
using HozestERP.BusinessLogic.Audit.UsersOnline;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Configuration;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Customers;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ErrorLog;
using HozestERP.BusinessLogic.ExportImport;
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
using Microsoft.Practices.Unity;
using HozestERP.BusinessLogic.ManageBulletin;
using HozestERP.BusinessLogic.ManageProductionOrder;

namespace HozestERP.BusinessLogic.Infrastructure
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        #region Fields

        private readonly IUnityContainer _container;

        #endregion

        #region Ctor

        public UnityDependencyResolver()
            : this(new UnityContainer())
        {

        }

        public UnityDependencyResolver(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this._container = container;
            //configure container
            ConfigureContainer(this._container);
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Configure root container.Register types and life time managers for unity builder process
        /// </summary>
        /// <param name="container">Container to configure</param>
        protected virtual void ConfigureContainer(IUnityContainer container)
        {
            //Take into account that Types and Mappings registration could be also done using the UNITY XML configuration
            //But we prefer doing it here (C# code) because we'll catch errors at compiling time instead execution time, if any type has been written wrong.
            //Register repositories mappings
            //to be done
            //Register default cache manager            
            //container.RegisterType<ICacheManager, NopRequestCache>(new PerExecutionContextLifetimeManager());
            //Register managers(services) mappings
            //container.RegisterType<IUserNameService, UserNameService>(new UnityPerExecutionContextLifetimeManager());

            container.RegisterType<IOnlineUserService, OnlineUserService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ILogService, LogService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ISettingManager, SettingManager>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ICustomerService, CustomerService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ICustomerInfoService, CustomerInfoService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IACLService, ACLService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ICustomerActivityService, CustomerActivityService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IPictureService, PictureService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IEnterpriseService, EnterpriseService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ICodeTypeService, CodeTypeService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ICodeService, CodeService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IAreaCodeService, AreaCodeService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IModuleService, ModuleService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IEnterpriseService, EnterpriseService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IImportManager, ImportManager>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IExportManager, ExportManager>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<INoticeService, NoticeService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IPortalService, PortalService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IFileService, FileService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<ITableUpdateLogService, TableUpdateLogService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IProjectService, ProjectService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMOrderInfoAppService, XMOrderInfoAppService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IKFChatLogService, KFChatLogService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMOrderInfoService, XMOrderInfoService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMOrderInfoProductDetailsService, XMOrderInfoProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMOrderInfoOperatingRecordService, XMOrderInfoOperatingRecordService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMOrderInfoPlanRecordService, XMOrderInfoPlanRecordService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMOrderInfoAPIService, XMOrderInfoAPIService>(new UnityPerExecutionContextLifetimeManager());
            //供应商账单
            container.RegisterType<IXMBillsService, XMBillsService>(new UnityPerExecutionContextLifetimeManager());
            //预支(暂支)申请
            container.RegisterType<IAdvanceApplicationService, AdvanceApplicationService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IAdvanceApplicationDetailService, AdvanceApplicationDetailService>(new UnityPerExecutionContextLifetimeManager());
            //刷单申请
            container.RegisterType<IXMScalpingApplicationService, XMScalpingApplicationService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMScalpingApplicationDetailsService, XMScalpingApplicationDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //产品管理
            container.RegisterType<IXMProductService, XMProductService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMProductDetailsService, XMProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMNickService, XMNickService>(new UnityPerExecutionContextLifetimeManager());//店铺
            container.RegisterType<IXMNickCustomerMappingService, XMNickCustomerMappingService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMProjectService, XMProjectService>(new UnityPerExecutionContextLifetimeManager());//项目
            container.RegisterType<IXMScalpingService, XMScalpingService>(new UnityPerExecutionContextLifetimeManager());//刷单表
            container.RegisterType<IXMCashBackApplicationService, XMCashBackApplicationService>(new UnityPerExecutionContextLifetimeManager());//返现申请
            container.RegisterType<IXMCompanyCustomService, XMCompanyCustomService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMDeliveryService, XMDeliveryService>(new UnityPerExecutionContextLifetimeManager());//发货单
            container.RegisterType<IXMDeliveryDetailsService, XMDeliveryDetailsService>(new UnityPerExecutionContextLifetimeManager());//发货明细
            container.RegisterType<IXMDeductionSetUpService, XMDeductionSetUpService>(new UnityPerExecutionContextLifetimeManager());//扣点设置
            container.RegisterType<IXMPremiumsService, XMPremiumsService>(new UnityPerExecutionContextLifetimeManager());//赠品 
            container.RegisterType<IXMPremiumsDetailsService, XMPremiumsDetailsService>(new UnityPerExecutionContextLifetimeManager());//赠品明细
            container.RegisterType<IXMQuestionService, XMQuestionService>(new UnityPerExecutionContextLifetimeManager());//问题处理
            container.RegisterType<IXMQuestionDetailService, XMQuestionDetailService>(new UnityPerExecutionContextLifetimeManager());//问题处理明细
            container.RegisterType<IXMQuestionCategoryService, XMQuestionCategoryService>(new UnityPerExecutionContextLifetimeManager());    //问题处理类型
            container.RegisterType<IXMCommunicationRecordService, XMCommunicationRecordService>(new UnityPerExecutionContextLifetimeManager());//沟通记录
            //客服等级管理
            container.RegisterType<IXMCustomerServiceLevelService, XMCustomerServiceLevelService>(new UnityPerExecutionContextLifetimeManager());
            //DSR管理
            container.RegisterType<IXMDSRService, XMDSRService>(new UnityPerExecutionContextLifetimeManager());
            //旺旺号管理
            container.RegisterType<IXMWangNoService, XMWangNoService>(new UnityPerExecutionContextLifetimeManager());
            //客服旺旺号关系
            container.RegisterType<IXMCustomerWangNoService, XMCustomerWangNoService>(new UnityPerExecutionContextLifetimeManager());
            //客服级别关系
            container.RegisterType<IXMCustomerRankService, XMCustomerRankService>(new UnityPerExecutionContextLifetimeManager());
            //产品组合管理产品
            container.RegisterType<IXMCombinationService, XMCombinationService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMCombinationDetailsService, XMCombinationDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //产品组合管理关系
            container.RegisterType<IXMProductCombinationService, XMProductCombinationService>(new UnityPerExecutionContextLifetimeManager());
            //财务项目表 
            container.RegisterType<ICWProjectService, CWProjectService>(new UnityPerExecutionContextLifetimeManager());
            //利润表 
            container.RegisterType<ICWProfitService, CWProfitService>(new UnityPerExecutionContextLifetimeManager());
            //人员开支费用
            container.RegisterType<ICWStaffSpendingService, CWStaffSpendingService>(new UnityPerExecutionContextLifetimeManager());
            //平台费用
            container.RegisterType<ICWPlatformSpendingService, CWPlatformSpendingService>(new UnityPerExecutionContextLifetimeManager());
            //岗位
            container.RegisterType<IXMPostService, XMPostService>(new UnityPerExecutionContextLifetimeManager());
            //postshop
            container.RegisterType<IPostshoplistService, PostshoplistService>(new UnityPerExecutionContextLifetimeManager());
            //售后数据
            container.RegisterType<IXMAfterSalesDataService, XMAfterSalesDataService>(new UnityPerExecutionContextLifetimeManager());
            //广告费
            container.RegisterType<IXMAdvertisingFeeService, XMAdvertisingFeeService>(new UnityPerExecutionContextLifetimeManager());
            //广告字段管理
            container.RegisterType<IXMAdvertingFieldService, XMAdvertingFieldService>(new UnityPerExecutionContextLifetimeManager());
            //店铺广告字段设置
            container.RegisterType<IXMNickIncludeAdveringFieldService, XMNickIncludeAdveringFieldService>(new UnityPerExecutionContextLifetimeManager());
            //店铺广告费明细
            container.RegisterType<IXMAdvertisingFeeDetailService, XMAdvertisingFeeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //咨询跟进
            container.RegisterType<IXMConsultationService, XMConsultationService>(new UnityPerExecutionContextLifetimeManager());
            //咨询跟进详细
            container.RegisterType<IXMConsultationDetailsService, XMConsultationDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //仓库
            container.RegisterType<IXMWarehouseService, XMWarehouseService>(new UnityPerExecutionContextLifetimeManager());
            //退换货
            container.RegisterType<IXMApplicationService, XMApplicationService>(new UnityPerExecutionContextLifetimeManager());
            //退换货从表
            container.RegisterType<IXMApplicationExchangeService, XMApplicationExchangeService>(new UnityPerExecutionContextLifetimeManager());
            //赠品入库记录
            container.RegisterType<IXMGiftStorageRecordService, XMGiftStorageRecordService>(new UnityPerExecutionContextLifetimeManager());
            //索赔单表
            container.RegisterType<IXMClaimFormService, XMClaimFormService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMClaimFormDetailService, XMClaimFormDetailService>(new UnityPerExecutionContextLifetimeManager());
            //薪资管理
            container.RegisterType<ICustomerSalaryService, CustomerSalaryService>(new UnityPerExecutionContextLifetimeManager());
            //业务数据表
            container.RegisterType<IXMBusinessDataService, XMBusinessDataService>(new UnityPerExecutionContextLifetimeManager());
            //业务数据详细表
            container.RegisterType<IXMBusinessDataDetailService, XMBusinessDataDetailService>(new UnityPerExecutionContextLifetimeManager());
            //业务数据其他
            container.RegisterType<IXMBusinessDataOtherService, XMBusinessDataOtherService>(new UnityPerExecutionContextLifetimeManager());
            //店铺月度目标值数据表
            container.RegisterType<IXMNickMonthlyTargetService, XMNickMonthlyTargetService>(new UnityPerExecutionContextLifetimeManager());
            //其他收入月度目标值数据表
            container.RegisterType<IXMOtherMonthlyTargetService, XMOtherMonthlyTargetService>(new UnityPerExecutionContextLifetimeManager());
            //喜临门城市爱情店铺达成值数据表
            container.RegisterType<IXMNickAchieveValueService, XMNickAchieveValueService>(new UnityPerExecutionContextLifetimeManager());
            //财务资金流水表
            container.RegisterType<IXMFinancialCapitalFlowService, XMFinancialCapitalFlowService>(new UnityPerExecutionContextLifetimeManager());
            //财务预算字段管理
            container.RegisterType<IXMFinancialFieldService, XMFinancialFieldService>(new UnityPerExecutionContextLifetimeManager());
            //部门或项目包含字段
            container.RegisterType<IXMIncludeFieldsService, XMIncludeFieldsService>(new UnityPerExecutionContextLifetimeManager());
            //项目预算明细
            container.RegisterType<IXMProjectCostDetailService, XMProjectCostDetailService>(new UnityPerExecutionContextLifetimeManager());
            //部门B2B或B2C预算明细
            container.RegisterType<IXMOtherCostDetailService, XMOtherCostDetailService>(new UnityPerExecutionContextLifetimeManager());
            //社保公积金
            container.RegisterType<ISocialSecurityFundService, SocialSecurityFundService>(new UnityPerExecutionContextLifetimeManager());
            //进销存管理
            //供应商管理
            container.RegisterType<IXMSuppliersService, XMSuppliersService>(new UnityPerExecutionContextLifetimeManager());
            ////仓库管理
            container.RegisterType<IXMWareHousesService, XMWareHousesService>(new UnityPerExecutionContextLifetimeManager());
            //物流信息
            container.RegisterType<IXMLogisticsInfoService, XMLogisticsInfoService>(new UnityPerExecutionContextLifetimeManager());
            //物流时效
            container.RegisterType<ILogisticsAgingService, LogisticsAgingService>(new UnityPerExecutionContextLifetimeManager());
            //采购订单
            container.RegisterType<IXMPurchaseService, XMPurchaseService>(new UnityPerExecutionContextLifetimeManager());
            //采购单详情
            container.RegisterType<IXMPurchaseProductDetailsService, XMPurchaseProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //采购退货单
            container.RegisterType<IXMPurchaseRejectedService, XMPurchaseRejectedService>(new UnityPerExecutionContextLifetimeManager());
            //采购入库单
            container.RegisterType<IXMStorageService, XMStorageService>(new UnityPerExecutionContextLifetimeManager());
            //采购入库产品明细表
            container.RegisterType<IXMStorageProductDetailsService, XMStorageProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //采购退货单
            container.RegisterType<IXMPurchaseRejectedService, XMPurchaseRejectedService>(new UnityPerExecutionContextLifetimeManager());
            //采购退货产品明细表
            container.RegisterType<IXMPurchaseRejectedProductDetailsService, XMPurchaseRejectedProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //库存表
            container.RegisterType<IXMInventoryInfoService, XMInventoryInfoService>(new UnityPerExecutionContextLifetimeManager());
            //销售订单
            container.RegisterType<IXMSaleInfoService, XMSaleInfoService>(new UnityPerExecutionContextLifetimeManager());
            //销售订单产品明细表
            container.RegisterType<IXMSaleInfoProductDetailsService, XMSaleInfoProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //销售出库单
            container.RegisterType<IXMSaleDeliveryService, XMSaleDeliveryService>(new UnityPerExecutionContextLifetimeManager());
            //销售出库产品明细表
            container.RegisterType<IXMSaleDeliveryProductDetailsService, XMSaleDeliveryProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //销售退货入库单
            container.RegisterType<IXMSaleReturnService, XMSaleReturnService>(new UnityPerExecutionContextLifetimeManager());
            //销售退货产品明细表
            container.RegisterType<IXMSaleReturnProductDetailsService, XMSaleReturnProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //调整单
            container.RegisterType<IXMAdjustedInfoService, XMAdjustedInfoService>(new UnityPerExecutionContextLifetimeManager());
            //调整单产品明细表
            container.RegisterType<IXMAdjustedProductDetailService, XMAdjustedProductDetailService>(new UnityPerExecutionContextLifetimeManager());
            //盘点单
            container.RegisterType<IXMPdInfoService, XMPdInfoService>(new UnityPerExecutionContextLifetimeManager());
            //盘点单明细表
            container.RegisterType<IXMPdInfoProductDetailsService, XMPdInfoProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //库存总账主表
            container.RegisterType<IXMInventoryLedgerService, XMInventoryLedgerService>(new UnityPerExecutionContextLifetimeManager());
            //库存总账明细表
            container.RegisterType<IXMInventoryLedgerDetailService, XMInventoryLedgerDetailService>(new UnityPerExecutionContextLifetimeManager());
            //调拨单主表
            container.RegisterType<IXMAllocateInfoService, XMAllocateInfoService>(new UnityPerExecutionContextLifetimeManager());
            //调拨单产品明细表
            container.RegisterType<IXMAllocateProductDetailsService, XMAllocateProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //库存信息实时统计
            container.RegisterType<IXMInventoryInfoStatisticsService, XMInventoryInfoStatisticsService>(new UnityPerExecutionContextLifetimeManager());
            //全国仓库设置
            container.RegisterType<IProvinceWarehouseService, ProvinceWarehouseService>(new UnityPerExecutionContextLifetimeManager());
            //喜临门当日发货库存
            container.RegisterType<IXMXLMInventoryService, XMXLMInventoryService>(new UnityPerExecutionContextLifetimeManager());
            //入库单产品条形码明细表
            container.RegisterType<IXMStorageProductBarCodeDetailService, XMStorageProductBarCodeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //销售出库产品条形码明细表
            container.RegisterType<IXMSaleDeliveryBarCodeDetailService, XMSaleDeliveryBarCodeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //销售退货产品条形码明细表
            container.RegisterType<IXMSaleReturnBarCodeDetailService, XMSaleReturnBarCodeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //产品库存条形码明细表
            container.RegisterType<IXMInventoryBarcodeDetailService, XMInventoryBarcodeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //调拨单产品条形码明细表
            container.RegisterType<IXMAllocateProductBarCodeDetailService, XMAllocateProductBarCodeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //付款申请单
            container.RegisterType<IXMPaymentApplyService, XMPaymentApplyService>(new UnityPerExecutionContextLifetimeManager());
            //日销量数据
            container.RegisterType<IXMDailySaleInfoService, XMDailySaleInfoService>(new UnityPerExecutionContextLifetimeManager());
            //活动
            container.RegisterType<IXMActivityService, XMActivityService>(new UnityPerExecutionContextLifetimeManager());
            //活动类型
            container.RegisterType<IXMActivityTypeService, XMActivityTypeService>(new UnityPerExecutionContextLifetimeManager());
            //备用仓库
            container.RegisterType<IProvinceWarehouseSpareService, ProvinceWarehouseSpareService>(new UnityPerExecutionContextLifetimeManager());
            //备用地址
            container.RegisterType<IXMSpareAddressService, XMSpareAddressService>(new UnityPerExecutionContextLifetimeManager());
            //理赔单信息主表
            container.RegisterType<IXMClaimInfoService, XMClaimInfoService>(new UnityPerExecutionContextLifetimeManager());
            //理赔单详情从表
            container.RegisterType<IXMClaimInfoDetailService, XMClaimInfoDetailService>(new UnityPerExecutionContextLifetimeManager());
            //京东自营退货单主表   （进销存系统）
            container.RegisterType<IXMJDSaleRejectedService, XMJDSaleRejectedService>(new UnityPerExecutionContextLifetimeManager());
            //京东自营退货单产品详情从表  (进销存系统)
            container.RegisterType<IXMJDSaleRejectedProductDetailService, XMJDSaleRejectedProductDetailService>(new UnityPerExecutionContextLifetimeManager());
            //发票管理主表
            container.RegisterType<IXMInvoiceInfoService, XMInvoiceInfoService>(new UnityPerExecutionContextLifetimeManager());
            //发票管理从表
            container.RegisterType<IXMInvoiceInfoDetailService, XMInvoiceInfoDetailService>(new UnityPerExecutionContextLifetimeManager());
            //发出商品库存
            container.RegisterType<IXMDeliveryProductInventoryService, XMDeliveryProductInventoryService>(new UnityPerExecutionContextLifetimeManager());
            //快递管理
            container.RegisterType<IXMExpressManagementService, XMExpressManagementService>(new UnityPerExecutionContextLifetimeManager());
            //快递账单管理
            container.RegisterType<IXMExpressListManagementService, XMExpressListManagementService>(new UnityPerExecutionContextLifetimeManager());
            //公告管理
            container.RegisterType<IBulletinService, BulletinService>(new UnityPerExecutionContextLifetimeManager());
            //理赔产品明细表
            container.RegisterType<IXMClaimInfoProductDetailsService, XMClaimInfoProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //理赔管理图片子表
            container.RegisterType<IXMClaimInfoPictureService, XMClaimInfoPictureService>(new UnityPerExecutionContextLifetimeManager());
            //京东自营销售系数管理
            container.RegisterType<IXMJDZYSaleCoefficientsService, XMJDZYSaleCoefficientsService>(new UnityPerExecutionContextLifetimeManager());
            //京东自营实时库存管理（依据京东自营销售表格导入）
            container.RegisterType<IXMJDRealTimeInventoryService, XMJDRealTimeInventoryService>(new UnityPerExecutionContextLifetimeManager());
            //生产单主表
            container.RegisterType<IXMProductionOrderService, XMProductionOrderService>(new UnityPerExecutionContextLifetimeManager());
            //生产单产品明细表
            container.RegisterType<IXMProductionOrderDetailsService, XMProductionOrderDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //安装单
            container.RegisterType<IXMInstallationListService, XMInstallationListService>(new UnityPerExecutionContextLifetimeManager());
            //京东接口
            //container.RegisterType<IJD, JD>(new UnityPerExecutionContextLifetimeManager());
            //物流费用干线维护表
            container.RegisterType<IXMLogisticsFeeMainService, XMLogisticsFeeMainService>(new UnityPerExecutionContextLifetimeManager());
            //物流费用支线维护表
            container.RegisterType<IXMLogisticsFeeBranchService, XMLogisticsFeeBranchService>(new UnityPerExecutionContextLifetimeManager());
            //物流费用明细表
            container.RegisterType<IXMLogisticsFeeDetailService, XMLogisticsFeeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //安装师傅信息表
            container.RegisterType<IXMWorkerInfoService, XMWorkerInfoService>(new UnityPerExecutionContextLifetimeManager());
            //理赔原因信息表
            container.RegisterType<IXMClaimReasonService, XMClaimReasonService>(new UnityPerExecutionContextLifetimeManager());
            //运费管理
            container.RegisterType<IXMLogisticsCostService, XMLogisticsCostService>(new UnityPerExecutionContextLifetimeManager());

            //Object context
            //Connection string
            container.RegisterType<IXMTypeTestService, XMTypeTestService>(new UnityPerExecutionContextLifetimeManager());
            //安装类型
            container.RegisterType<IXMZMDemandService, XMZMDemandService>(new UnityPerExecutionContextLifetimeManager());
            //安装要求
            container.RegisterType<IXMZMReservationService, XMZMReservationService>(new UnityPerExecutionContextLifetimeManager());

            //安装单预约
            if (!string.IsNullOrEmpty(HozestERPConfig.ConnectionString))
            {
                var ecsbuilder = new EntityConnectionStringBuilder();
                ecsbuilder.Provider = "System.Data.SqlClient";
                ecsbuilder.ProviderConnectionString = HozestERPConfig.ConnectionString;
                ecsbuilder.Metadata = @"res://*/Data.HozestERPModel.csdl|res://*/Data.HozestERPModel.ssdl|res://*/Data.HozestERPModel.msl";
                string connectionString = ecsbuilder.ToString();
                InjectionConstructor connectionStringParam = new InjectionConstructor(connectionString);
                //Registering object context
                container.RegisterType<HozestERPObjectContext>(new UnityPerExecutionContextLifetimeManager(), connectionStringParam);
            }

            //根据订单修改时间获取订单信息
            container.RegisterType<IVipapis, Vipapis>(new UnityPerExecutionContextLifetimeManager());
        }


        #endregion

        #region Methods

        /// <summary>
        /// Register instance
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="instance">Instance</param>
        public void Register<T>(T instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            _container.RegisterInstance(instance);
        }

        /// <summary>
        /// Inject
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="existing">Type</param>
        public void Inject<T>(T existing)
        {
            if (existing == null)
                throw new ArgumentNullException("existing");

            _container.BuildUp(existing);
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="type">Type</param>
        /// <returns>Result</returns>
        public T Resolve<T>(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            return (T)_container.Resolve(type);
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="type">Type</param>
        /// <param name="name">Name</param>
        /// <returns>Result</returns>
        public T Resolve<T>(Type type, string name)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (name == null)
                throw new ArgumentNullException("name");

            return (T)_container.Resolve(type, name);
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Result</returns>
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="name">Name</param>
        /// <returns>Result</returns>
        public T Resolve<T>(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            return _container.Resolve<T>(name);
        }

        /// <summary>
        /// Resolve all
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Result</returns>
        public IEnumerable<T> ResolveAll<T>()
        {
            IEnumerable<T> namedInstances = _container.ResolveAll<T>();
            T unnamedInstance = default(T);

            try
            {
                unnamedInstance = _container.Resolve<T>();
            }
            catch (ResolutionFailedException)
            {
                //When default instance is missing
            }

            if (Equals(unnamedInstance, default(T)))
            {
                return namedInstances;
            }

            return new ReadOnlyCollection<T>(new List<T>(namedInstances) { unnamedInstance });
        }

        #endregion
    }
}
