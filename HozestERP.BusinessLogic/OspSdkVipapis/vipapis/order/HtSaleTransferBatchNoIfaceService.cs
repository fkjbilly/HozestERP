using System;
using System.Collections.Generic;

namespace vipapis.order{
	
	
	public interface HtSaleTransferBatchNoIfaceService {
		
		
		com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult getSaleTransferBatchNoOrderList( string warehouse_,   string batchNo_,   int? deliveryNum_,   string customsCode_,   string chinaFreightForwarding_,   string globalFreightForwarding_,   string customsClearanceMode_,   string creatTime_,   List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder> orders_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}