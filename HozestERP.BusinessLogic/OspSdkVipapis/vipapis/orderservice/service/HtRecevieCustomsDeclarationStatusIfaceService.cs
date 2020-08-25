using System;
using System.Collections.Generic;

namespace vipapis.orderservice.service{
	
	
	public interface HtRecevieCustomsDeclarationStatusIfaceService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessage receiveCustomsDeclarationStatus( string customsCode_,   string userId_,   List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody> body_ );
		
	}
	
}