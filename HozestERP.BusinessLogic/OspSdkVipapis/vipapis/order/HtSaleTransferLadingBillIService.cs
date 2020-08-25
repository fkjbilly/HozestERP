using System;
using System.Collections.Generic;

namespace vipapis.order{
	
	
	public interface HtSaleTransferLadingBillIService {
		
		
		com.vip.haitao.orderservice.service.HtLadingBillNumberInfoResult getLadingBillInfo( string userId_,   string ladingBillNumber_ );
		
		com.vip.haitao.orderservice.service.HtSaleTransferLadingBillResult getSaleTransferLadingBillIBatchNoOrderList( string warehouse_,   string ladingBillNumber_,   string shipmentCountry_,   string arriveCountry_,   string customsClearanceMode_,   double? totalWeight_,   List<com.vip.haitao.orderservice.service.SubLadingBillNumberVo> subBillNumerList_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		List<string> matchLaddingNum( List<string> orders_ );
		
	}
	
}