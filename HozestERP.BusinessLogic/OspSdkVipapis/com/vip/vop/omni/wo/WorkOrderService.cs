using System;
using System.Collections.Generic;

namespace com.vip.vop.omni.wo{
	
	
	public interface WorkOrderService {
		
		
		List<com.vip.vop.omni.wo.WorkOrder> getNeedPushWorkOrders( long? vendorId_,   System.DateTime? startTime_,   long? lastId_,   int? size_ );
		
		com.vip.vop.omni.wo.OxoOrderCarrierInfo getOxoOrderCarrier( string orderSn_ );
		
		bool? handleWorkOrder( com.vip.vop.omni.wo.WorkOrder workOrder_ );
		
		bool? handleWorkOrderAttachment( com.vip.vop.omni.wo.WorkOrderAttach workOrderAttach_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		bool? pushWorkOrder( com.vip.vop.omni.wo.WorkOrder workOrder_ );
		
		bool? workOrderReply( com.vip.vop.omni.wo.WorkOrderReply reply_ );
		
	}
	
}