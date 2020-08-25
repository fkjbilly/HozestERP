using System;
using System.Collections.Generic;

namespace vipapis.price{
	
	
	public interface JitPriceService {
		
		
		void confirmPriceApplication( vipapis.price.ConfirmPriceApplicationRequest request_ );
		
		string createPriceApplicationId( int vendor_id_ );
		
		vipapis.price.GetPriceApplicationResponse getPriceApplication( vipapis.price.GetPriceApplicationRequest request_ );
		
		List<vipapis.price.PriceApplicationStatus> getPriceApplicationStatus( vipapis.price.GetPriceApplicationStatusRequest request_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void submitPriceApplication( vipapis.price.SubmitPriceApplicationRequest request_ );
		
		void updatePriceApplication( vipapis.price.UpdatePriceApplicationRequest request_ );
		
	}
	
}