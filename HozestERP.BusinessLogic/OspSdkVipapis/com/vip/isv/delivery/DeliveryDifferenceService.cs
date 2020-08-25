using System;
using System.Collections.Generic;

namespace com.vip.isv.delivery{
	
	
	public interface DeliveryDifferenceService {
		
		
		int? countByVisReceiptContainerId( long? id_ );
		
		List<com.vip.isv.delivery.DefectiveGood> getDefectiveGoodByReceiptNo( string receiptNo_ );
		
		List<com.vip.isv.delivery.ReceiptDetail> getDetailList( long? visReceiptContainerId_,   int size_ );
		
		List<com.vip.isv.delivery.ReceiptInfo> getList( int? vendorId_,   System.DateTime? time_,   int size_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		bool? updateReceiptContainer( long? id_ );
		
		bool? updateReceiptContainerDetail( List<long?> id_ );
		
	}
	
}