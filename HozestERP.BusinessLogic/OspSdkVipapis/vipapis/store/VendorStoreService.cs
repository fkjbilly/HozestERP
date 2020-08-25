using System;
using System.Collections.Generic;

namespace vipapis.store{
	
	
	public interface VendorStoreService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.store.StoreQueryResponse queryStores( vipapis.store.StoreQueryRequest storeQueryRequest_ );
		
	}
	
}