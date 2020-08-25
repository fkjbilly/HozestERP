using System;
using System.Collections.Generic;

namespace com.vip.isv.vreceipt{
	
	
	public interface ReceiptContainerService {
		
		
		bool? addReceiptContainer( com.vip.isv.vreceipt.Revinfo revinfo_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}