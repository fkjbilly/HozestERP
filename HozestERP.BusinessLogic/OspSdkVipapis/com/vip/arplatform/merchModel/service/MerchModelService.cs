using System;
using System.Collections.Generic;

namespace com.vip.arplatform.merchModel.service{
	
	
	public interface MerchModelService {
		
		
		void batchBind( long materialId_,   List<com.vip.arplatform.merchModel.service.BindInfoModel> bindInfoModels_ );
		
		bool? bind( long materialId_,   com.vip.arplatform.merchModel.service.BindInfoModel bindInfoModel_ );
		
		List<string> createBatchMaterial( List<com.vip.arplatform.merchModel.service.MaterialModel> mdList_ );
		
		void createMaterial( com.vip.arplatform.merchModel.service.MaterialModel md_ );
		
		int? deleteMaterialByBarcode( int serviceType_,   string _from_,   string barcode_ );
		
		int? deleteMaterialByMid( int serviceType_,   string _from_,   string mid_ );
		
		com.vip.arplatform.merchModel.service.BindInfoModel getBindInfoBySku( long sku_ );
		
		Dictionary<long?, List<long?>> getBindRelationship( List<long?> materialIds_ );
		
		com.vip.arplatform.merchModel.service.MaterialModel getMaterialModelById( long id_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.arplatform.merchModel.service.PageableMaterialModel search( com.vip.arplatform.merchModel.service.SearchParams parameters_,   int page_,   int limit_,   string sortField_,   int? sort_ );
		
		bool? setStatus( long materialId_,   byte status_ );
		
		com.vip.arplatform.merchModel.service.Jd3dModelSyncResponse syncFromJD( List<com.vip.arplatform.merchModel.service.Jd3dModelData> syncDatum_ );
		
		bool? unbind( long materialId_,   com.vip.arplatform.merchModel.service.BindInfoModel bindInfoModel_ );
		
	}
	
}