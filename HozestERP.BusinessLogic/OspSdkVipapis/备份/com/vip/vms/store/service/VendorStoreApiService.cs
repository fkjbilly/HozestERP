using System;
using System.Collections.Generic;

namespace com.vip.vms.store.service{
	
	
	public interface VendorStoreApiService {
		
		
		string addStores( com.vip.vms.common.CommonParam commonParam_,   List<com.vip.vms.store.service.StoreAddParam> storeAddParamList_ );
		
		string deleteStores( com.vip.vms.common.CommonParam commonParam_,   List<com.vip.vms.store.service.StoreDeleteParam> storeDeleteParamList_ );
		
		string getStoreByStoreCode( com.vip.vms.common.CommonParam commonParam_,   string storeCode_ );
		
		string queryStores( com.vip.vms.common.CommonParam commonParam_,   List<com.vip.vms.store.service.StoreQueryParam> storeQueryParamList_ );
		
		string queryStoresByVendorCode( com.vip.vms.common.CommonParam commonParam_,   int vendorCode_ );
		
		string updateStoreWarehouseRel( com.vip.vms.common.CommonParam commonParam_,   List<com.vip.vms.store.service.StoreWarehouseRelUpdateParam> storeWarehouseRelUpdateParamList_ );
		
		string updateStores( com.vip.vms.common.CommonParam commonParam_,   List<com.vip.vms.store.service.StoreUpdateParam> storeUpdateParamList_ );
		
	}
	
}