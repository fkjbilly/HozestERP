using System;
using System.Collections.Generic;

namespace vipapis.inventory.admin{
	
	
	public interface InventoryAdminService {
		
		
		void delInvUpdateRetryRequest( int cooperationNo_,   string warehouse_,   string barcode_ );
		
		string getWhiInvUpdateHealth();
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.inventory.admin.ListInvRequestRetryRequestResult listInvUpdateRetryRequest( int startIndex_,   int endIndex_ );
		
		void saveInvUpdateRetryRequest( vipapis.inventory.admin.InvUpdateRetryRequest retryRequest_ );
		
		void saveWhiInvUpdateHealth( string health_ );
		
		void updateStockRetry( vipapis.inventory.admin.InvUpdateRetryRequest retryRequest_ );
		
	}
	
}