using System;
using System.Collections.Generic;

namespace vipapis.vis{
	
	
	public interface VendorStoreApiService {
		
		
		string addWarehouseInfo( com.vip.vms.common.CommonParam commonParam_,   List<com.vip.vms.store.service.StoreAddParam> storeAddParamList_ );
		
		string delWarehouseInfo( com.vip.vms.common.CommonParam commonParam_,   List<com.vip.vms.store.service.StoreDeleteParam> storeDeleteParamList_ );
		
		string getStoreByStoreCode( com.vip.vms.common.CommonParam commonParam_,   string storeCode_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		string getWarehouseInfo( com.vip.vms.common.CommonParam commonParam_,   List<com.vip.vms.store.service.StoreQueryParam> storeQueryParamList_ );
		
		string queryStoresByVendorCode( com.vip.vms.common.CommonParam commonParam_,   int vendorCode_ );
		
		string updateVendorWarehouseAndVIPWarehouseMap( com.vip.vms.common.CommonParam commonParam_,   List<com.vip.vms.store.service.StoreWarehouseRelUpdateParam> storeWarehouseRelUpdateParamList_ );
		
		string updateWarehouseInfo( com.vip.vms.common.CommonParam commonParam_,   List<com.vip.vms.store.service.StoreUpdateParam> storeUpdateParamList_ );
		
	}
	
}