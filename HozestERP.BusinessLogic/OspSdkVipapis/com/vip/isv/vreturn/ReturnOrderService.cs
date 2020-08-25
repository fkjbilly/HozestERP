using System;
using System.Collections.Generic;

namespace com.vip.isv.vreturn{
	
	
	public interface ReturnOrderService {
		
		
		List<string> addDefectiveGoods( List<com.vip.isv.vreturn.DefectiveGoods> request_ );
		
		void doMatch();
		
		com.vip.isv.vreturn.GetReturnDeliveryGoodsResponse getReturnDeliveryGoods( com.vip.isv.vreturn.GetReturnDeliveryGoodsRequest request_ );
		
		com.vip.isv.vreturn.GetReturnOrderResponse getReturnOrder( com.vip.isv.vreturn.GetReturnOrderRequest request_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}