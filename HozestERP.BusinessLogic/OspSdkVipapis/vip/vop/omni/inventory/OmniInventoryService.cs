using System;
using System.Collections.Generic;

namespace vip.vop.omni.inventory{
	
	
	public interface OmniInventoryService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void updateStoreInventory( com.vip.vop.omni.inventory.InventoryUpdateRequest request_ );
		
	}
	
}