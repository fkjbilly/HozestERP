
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
            //��Ӧ���˵�
            container.RegisterType<IXMBillsService, XMBillsService>(new UnityPerExecutionContextLifetimeManager());
            //Ԥ֧(��֧)����
            container.RegisterType<IAdvanceApplicationService, AdvanceApplicationService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IAdvanceApplicationDetailService, AdvanceApplicationDetailService>(new UnityPerExecutionContextLifetimeManager());
            //ˢ������
            container.RegisterType<IXMScalpingApplicationService, XMScalpingApplicationService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMScalpingApplicationDetailsService, XMScalpingApplicationDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //��Ʒ����
            container.RegisterType<IXMProductService, XMProductService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMProductDetailsService, XMProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMNickService, XMNickService>(new UnityPerExecutionContextLifetimeManager());//����
            container.RegisterType<IXMNickCustomerMappingService, XMNickCustomerMappingService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMProjectService, XMProjectService>(new UnityPerExecutionContextLifetimeManager());//��Ŀ
            container.RegisterType<IXMScalpingService, XMScalpingService>(new UnityPerExecutionContextLifetimeManager());//ˢ����
            container.RegisterType<IXMCashBackApplicationService, XMCashBackApplicationService>(new UnityPerExecutionContextLifetimeManager());//��������
            container.RegisterType<IXMCompanyCustomService, XMCompanyCustomService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMDeliveryService, XMDeliveryService>(new UnityPerExecutionContextLifetimeManager());//������
            container.RegisterType<IXMDeliveryDetailsService, XMDeliveryDetailsService>(new UnityPerExecutionContextLifetimeManager());//������ϸ
            container.RegisterType<IXMDeductionSetUpService, XMDeductionSetUpService>(new UnityPerExecutionContextLifetimeManager());//�۵�����
            container.RegisterType<IXMPremiumsService, XMPremiumsService>(new UnityPerExecutionContextLifetimeManager());//��Ʒ 
            container.RegisterType<IXMPremiumsDetailsService, XMPremiumsDetailsService>(new UnityPerExecutionContextLifetimeManager());//��Ʒ��ϸ
            container.RegisterType<IXMQuestionService, XMQuestionService>(new UnityPerExecutionContextLifetimeManager());//���⴦��
            container.RegisterType<IXMQuestionDetailService, XMQuestionDetailService>(new UnityPerExecutionContextLifetimeManager());//���⴦����ϸ
            container.RegisterType<IXMQuestionCategoryService, XMQuestionCategoryService>(new UnityPerExecutionContextLifetimeManager());    //���⴦������
            container.RegisterType<IXMCommunicationRecordService, XMCommunicationRecordService>(new UnityPerExecutionContextLifetimeManager());//��ͨ��¼
            //�ͷ��ȼ�����
            container.RegisterType<IXMCustomerServiceLevelService, XMCustomerServiceLevelService>(new UnityPerExecutionContextLifetimeManager());
            //DSR����
            container.RegisterType<IXMDSRService, XMDSRService>(new UnityPerExecutionContextLifetimeManager());
            //�����Ź���
            container.RegisterType<IXMWangNoService, XMWangNoService>(new UnityPerExecutionContextLifetimeManager());
            //�ͷ������Ź�ϵ
            container.RegisterType<IXMCustomerWangNoService, XMCustomerWangNoService>(new UnityPerExecutionContextLifetimeManager());
            //�ͷ������ϵ
            container.RegisterType<IXMCustomerRankService, XMCustomerRankService>(new UnityPerExecutionContextLifetimeManager());
            //��Ʒ��Ϲ����Ʒ
            container.RegisterType<IXMCombinationService, XMCombinationService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMCombinationDetailsService, XMCombinationDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //��Ʒ��Ϲ����ϵ
            container.RegisterType<IXMProductCombinationService, XMProductCombinationService>(new UnityPerExecutionContextLifetimeManager());
            //������Ŀ�� 
            container.RegisterType<ICWProjectService, CWProjectService>(new UnityPerExecutionContextLifetimeManager());
            //����� 
            container.RegisterType<ICWProfitService, CWProfitService>(new UnityPerExecutionContextLifetimeManager());
            //��Ա��֧����
            container.RegisterType<ICWStaffSpendingService, CWStaffSpendingService>(new UnityPerExecutionContextLifetimeManager());
            //ƽ̨����
            container.RegisterType<ICWPlatformSpendingService, CWPlatformSpendingService>(new UnityPerExecutionContextLifetimeManager());
            //��λ
            container.RegisterType<IXMPostService, XMPostService>(new UnityPerExecutionContextLifetimeManager());
            //postshop
            container.RegisterType<IPostshoplistService, PostshoplistService>(new UnityPerExecutionContextLifetimeManager());
            //�ۺ�����
            container.RegisterType<IXMAfterSalesDataService, XMAfterSalesDataService>(new UnityPerExecutionContextLifetimeManager());
            //����
            container.RegisterType<IXMAdvertisingFeeService, XMAdvertisingFeeService>(new UnityPerExecutionContextLifetimeManager());
            //����ֶι���
            container.RegisterType<IXMAdvertingFieldService, XMAdvertingFieldService>(new UnityPerExecutionContextLifetimeManager());
            //���̹���ֶ�����
            container.RegisterType<IXMNickIncludeAdveringFieldService, XMNickIncludeAdveringFieldService>(new UnityPerExecutionContextLifetimeManager());
            //���̹�����ϸ
            container.RegisterType<IXMAdvertisingFeeDetailService, XMAdvertisingFeeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //��ѯ����
            container.RegisterType<IXMConsultationService, XMConsultationService>(new UnityPerExecutionContextLifetimeManager());
            //��ѯ������ϸ
            container.RegisterType<IXMConsultationDetailsService, XMConsultationDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //�ֿ�
            container.RegisterType<IXMWarehouseService, XMWarehouseService>(new UnityPerExecutionContextLifetimeManager());
            //�˻���
            container.RegisterType<IXMApplicationService, XMApplicationService>(new UnityPerExecutionContextLifetimeManager());
            //�˻����ӱ�
            container.RegisterType<IXMApplicationExchangeService, XMApplicationExchangeService>(new UnityPerExecutionContextLifetimeManager());
            //��Ʒ����¼
            container.RegisterType<IXMGiftStorageRecordService, XMGiftStorageRecordService>(new UnityPerExecutionContextLifetimeManager());
            //���ⵥ��
            container.RegisterType<IXMClaimFormService, XMClaimFormService>(new UnityPerExecutionContextLifetimeManager());
            container.RegisterType<IXMClaimFormDetailService, XMClaimFormDetailService>(new UnityPerExecutionContextLifetimeManager());
            //н�ʹ���
            container.RegisterType<ICustomerSalaryService, CustomerSalaryService>(new UnityPerExecutionContextLifetimeManager());
            //ҵ�����ݱ�
            container.RegisterType<IXMBusinessDataService, XMBusinessDataService>(new UnityPerExecutionContextLifetimeManager());
            //ҵ��������ϸ��
            container.RegisterType<IXMBusinessDataDetailService, XMBusinessDataDetailService>(new UnityPerExecutionContextLifetimeManager());
            //ҵ����������
            container.RegisterType<IXMBusinessDataOtherService, XMBusinessDataOtherService>(new UnityPerExecutionContextLifetimeManager());
            //�����¶�Ŀ��ֵ���ݱ�
            container.RegisterType<IXMNickMonthlyTargetService, XMNickMonthlyTargetService>(new UnityPerExecutionContextLifetimeManager());
            //���������¶�Ŀ��ֵ���ݱ�
            container.RegisterType<IXMOtherMonthlyTargetService, XMOtherMonthlyTargetService>(new UnityPerExecutionContextLifetimeManager());
            //ϲ���ų��а�����̴��ֵ���ݱ�
            container.RegisterType<IXMNickAchieveValueService, XMNickAchieveValueService>(new UnityPerExecutionContextLifetimeManager());
            //�����ʽ���ˮ��
            container.RegisterType<IXMFinancialCapitalFlowService, XMFinancialCapitalFlowService>(new UnityPerExecutionContextLifetimeManager());
            //����Ԥ���ֶι���
            container.RegisterType<IXMFinancialFieldService, XMFinancialFieldService>(new UnityPerExecutionContextLifetimeManager());
            //���Ż���Ŀ�����ֶ�
            container.RegisterType<IXMIncludeFieldsService, XMIncludeFieldsService>(new UnityPerExecutionContextLifetimeManager());
            //��ĿԤ����ϸ
            container.RegisterType<IXMProjectCostDetailService, XMProjectCostDetailService>(new UnityPerExecutionContextLifetimeManager());
            //����B2B��B2CԤ����ϸ
            container.RegisterType<IXMOtherCostDetailService, XMOtherCostDetailService>(new UnityPerExecutionContextLifetimeManager());
            //�籣������
            container.RegisterType<ISocialSecurityFundService, SocialSecurityFundService>(new UnityPerExecutionContextLifetimeManager());
            //���������
            //��Ӧ�̹���
            container.RegisterType<IXMSuppliersService, XMSuppliersService>(new UnityPerExecutionContextLifetimeManager());
            ////�ֿ����
            container.RegisterType<IXMWareHousesService, XMWareHousesService>(new UnityPerExecutionContextLifetimeManager());
            //������Ϣ
            container.RegisterType<IXMLogisticsInfoService, XMLogisticsInfoService>(new UnityPerExecutionContextLifetimeManager());
            //����ʱЧ
            container.RegisterType<ILogisticsAgingService, LogisticsAgingService>(new UnityPerExecutionContextLifetimeManager());
            //�ɹ�����
            container.RegisterType<IXMPurchaseService, XMPurchaseService>(new UnityPerExecutionContextLifetimeManager());
            //�ɹ�������
            container.RegisterType<IXMPurchaseProductDetailsService, XMPurchaseProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //�ɹ��˻���
            container.RegisterType<IXMPurchaseRejectedService, XMPurchaseRejectedService>(new UnityPerExecutionContextLifetimeManager());
            //�ɹ���ⵥ
            container.RegisterType<IXMStorageService, XMStorageService>(new UnityPerExecutionContextLifetimeManager());
            //�ɹ�����Ʒ��ϸ��
            container.RegisterType<IXMStorageProductDetailsService, XMStorageProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //�ɹ��˻���
            container.RegisterType<IXMPurchaseRejectedService, XMPurchaseRejectedService>(new UnityPerExecutionContextLifetimeManager());
            //�ɹ��˻���Ʒ��ϸ��
            container.RegisterType<IXMPurchaseRejectedProductDetailsService, XMPurchaseRejectedProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //����
            container.RegisterType<IXMInventoryInfoService, XMInventoryInfoService>(new UnityPerExecutionContextLifetimeManager());
            //���۶���
            container.RegisterType<IXMSaleInfoService, XMSaleInfoService>(new UnityPerExecutionContextLifetimeManager());
            //���۶�����Ʒ��ϸ��
            container.RegisterType<IXMSaleInfoProductDetailsService, XMSaleInfoProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //���۳��ⵥ
            container.RegisterType<IXMSaleDeliveryService, XMSaleDeliveryService>(new UnityPerExecutionContextLifetimeManager());
            //���۳����Ʒ��ϸ��
            container.RegisterType<IXMSaleDeliveryProductDetailsService, XMSaleDeliveryProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //�����˻���ⵥ
            container.RegisterType<IXMSaleReturnService, XMSaleReturnService>(new UnityPerExecutionContextLifetimeManager());
            //�����˻���Ʒ��ϸ��
            container.RegisterType<IXMSaleReturnProductDetailsService, XMSaleReturnProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //������
            container.RegisterType<IXMAdjustedInfoService, XMAdjustedInfoService>(new UnityPerExecutionContextLifetimeManager());
            //��������Ʒ��ϸ��
            container.RegisterType<IXMAdjustedProductDetailService, XMAdjustedProductDetailService>(new UnityPerExecutionContextLifetimeManager());
            //�̵㵥
            container.RegisterType<IXMPdInfoService, XMPdInfoService>(new UnityPerExecutionContextLifetimeManager());
            //�̵㵥��ϸ��
            container.RegisterType<IXMPdInfoProductDetailsService, XMPdInfoProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //�����������
            container.RegisterType<IXMInventoryLedgerService, XMInventoryLedgerService>(new UnityPerExecutionContextLifetimeManager());
            //���������ϸ��
            container.RegisterType<IXMInventoryLedgerDetailService, XMInventoryLedgerDetailService>(new UnityPerExecutionContextLifetimeManager());
            //����������
            container.RegisterType<IXMAllocateInfoService, XMAllocateInfoService>(new UnityPerExecutionContextLifetimeManager());
            //��������Ʒ��ϸ��
            container.RegisterType<IXMAllocateProductDetailsService, XMAllocateProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //�����Ϣʵʱͳ��
            container.RegisterType<IXMInventoryInfoStatisticsService, XMInventoryInfoStatisticsService>(new UnityPerExecutionContextLifetimeManager());
            //ȫ���ֿ�����
            container.RegisterType<IProvinceWarehouseService, ProvinceWarehouseService>(new UnityPerExecutionContextLifetimeManager());
            //ϲ���ŵ��շ������
            container.RegisterType<IXMXLMInventoryService, XMXLMInventoryService>(new UnityPerExecutionContextLifetimeManager());
            //��ⵥ��Ʒ��������ϸ��
            container.RegisterType<IXMStorageProductBarCodeDetailService, XMStorageProductBarCodeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //���۳����Ʒ��������ϸ��
            container.RegisterType<IXMSaleDeliveryBarCodeDetailService, XMSaleDeliveryBarCodeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //�����˻���Ʒ��������ϸ��
            container.RegisterType<IXMSaleReturnBarCodeDetailService, XMSaleReturnBarCodeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //��Ʒ�����������ϸ��
            container.RegisterType<IXMInventoryBarcodeDetailService, XMInventoryBarcodeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //��������Ʒ��������ϸ��
            container.RegisterType<IXMAllocateProductBarCodeDetailService, XMAllocateProductBarCodeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //�������뵥
            container.RegisterType<IXMPaymentApplyService, XMPaymentApplyService>(new UnityPerExecutionContextLifetimeManager());
            //����������
            container.RegisterType<IXMDailySaleInfoService, XMDailySaleInfoService>(new UnityPerExecutionContextLifetimeManager());
            //�
            container.RegisterType<IXMActivityService, XMActivityService>(new UnityPerExecutionContextLifetimeManager());
            //�����
            container.RegisterType<IXMActivityTypeService, XMActivityTypeService>(new UnityPerExecutionContextLifetimeManager());
            //���òֿ�
            container.RegisterType<IProvinceWarehouseSpareService, ProvinceWarehouseSpareService>(new UnityPerExecutionContextLifetimeManager());
            //���õ�ַ
            container.RegisterType<IXMSpareAddressService, XMSpareAddressService>(new UnityPerExecutionContextLifetimeManager());
            //���ⵥ��Ϣ����
            container.RegisterType<IXMClaimInfoService, XMClaimInfoService>(new UnityPerExecutionContextLifetimeManager());
            //���ⵥ����ӱ�
            container.RegisterType<IXMClaimInfoDetailService, XMClaimInfoDetailService>(new UnityPerExecutionContextLifetimeManager());
            //������Ӫ�˻�������   ��������ϵͳ��
            container.RegisterType<IXMJDSaleRejectedService, XMJDSaleRejectedService>(new UnityPerExecutionContextLifetimeManager());
            //������Ӫ�˻�����Ʒ����ӱ�  (������ϵͳ)
            container.RegisterType<IXMJDSaleRejectedProductDetailService, XMJDSaleRejectedProductDetailService>(new UnityPerExecutionContextLifetimeManager());
            //��Ʊ��������
            container.RegisterType<IXMInvoiceInfoService, XMInvoiceInfoService>(new UnityPerExecutionContextLifetimeManager());
            //��Ʊ����ӱ�
            container.RegisterType<IXMInvoiceInfoDetailService, XMInvoiceInfoDetailService>(new UnityPerExecutionContextLifetimeManager());
            //������Ʒ���
            container.RegisterType<IXMDeliveryProductInventoryService, XMDeliveryProductInventoryService>(new UnityPerExecutionContextLifetimeManager());
            //��ݹ���
            container.RegisterType<IXMExpressManagementService, XMExpressManagementService>(new UnityPerExecutionContextLifetimeManager());
            //����˵�����
            container.RegisterType<IXMExpressListManagementService, XMExpressListManagementService>(new UnityPerExecutionContextLifetimeManager());
            //�������
            container.RegisterType<IBulletinService, BulletinService>(new UnityPerExecutionContextLifetimeManager());
            //�����Ʒ��ϸ��
            container.RegisterType<IXMClaimInfoProductDetailsService, XMClaimInfoProductDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //�������ͼƬ�ӱ�
            container.RegisterType<IXMClaimInfoPictureService, XMClaimInfoPictureService>(new UnityPerExecutionContextLifetimeManager());
            //������Ӫ����ϵ������
            container.RegisterType<IXMJDZYSaleCoefficientsService, XMJDZYSaleCoefficientsService>(new UnityPerExecutionContextLifetimeManager());
            //������Ӫʵʱ���������ݾ�����Ӫ���۱���룩
            container.RegisterType<IXMJDRealTimeInventoryService, XMJDRealTimeInventoryService>(new UnityPerExecutionContextLifetimeManager());
            //����������
            container.RegisterType<IXMProductionOrderService, XMProductionOrderService>(new UnityPerExecutionContextLifetimeManager());
            //��������Ʒ��ϸ��
            container.RegisterType<IXMProductionOrderDetailsService, XMProductionOrderDetailsService>(new UnityPerExecutionContextLifetimeManager());
            //��װ��
            container.RegisterType<IXMInstallationListService, XMInstallationListService>(new UnityPerExecutionContextLifetimeManager());
            //�����ӿ�
            //container.RegisterType<IJD, JD>(new UnityPerExecutionContextLifetimeManager());
            //�������ø���ά����
            container.RegisterType<IXMLogisticsFeeMainService, XMLogisticsFeeMainService>(new UnityPerExecutionContextLifetimeManager());
            //��������֧��ά����
            container.RegisterType<IXMLogisticsFeeBranchService, XMLogisticsFeeBranchService>(new UnityPerExecutionContextLifetimeManager());
            //����������ϸ��
            container.RegisterType<IXMLogisticsFeeDetailService, XMLogisticsFeeDetailService>(new UnityPerExecutionContextLifetimeManager());
            //��װʦ����Ϣ��
            container.RegisterType<IXMWorkerInfoService, XMWorkerInfoService>(new UnityPerExecutionContextLifetimeManager());
            //����ԭ����Ϣ��
            container.RegisterType<IXMClaimReasonService, XMClaimReasonService>(new UnityPerExecutionContextLifetimeManager());
            //�˷ѹ���
            container.RegisterType<IXMLogisticsCostService, XMLogisticsCostService>(new UnityPerExecutionContextLifetimeManager());

            //Object context
            //Connection string
            container.RegisterType<IXMTypeTestService, XMTypeTestService>(new UnityPerExecutionContextLifetimeManager());
            //��װ����
            container.RegisterType<IXMZMDemandService, XMZMDemandService>(new UnityPerExecutionContextLifetimeManager());
            //��װҪ��
            container.RegisterType<IXMZMReservationService, XMZMReservationService>(new UnityPerExecutionContextLifetimeManager());

            //��װ��ԤԼ
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

            //���ݶ����޸�ʱ���ȡ������Ϣ
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
