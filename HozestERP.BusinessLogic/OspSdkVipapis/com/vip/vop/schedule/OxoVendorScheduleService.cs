using System;
using System.Collections.Generic;

namespace com.vip.vop.schedule{
	
	
	public interface OxoVendorScheduleService {
		
		
		List<com.vip.vop.schedule.VendorSchedule> getScheduleListByCooperationNo( long vendorId_,   long cooperationNo_,   string warehouse_ );
		
		com.vip.vop.schedule.VendorScheduleSku getSkuByScheduleIdAndBarcode( long scheduleId_,   string barcode_ );
		
		int? getSkuInventoryPushStatus( long vendorId_,   long cooperationNo_,   string warehouse_,   string barcode_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void setSkuInventoryPushStatusImported( long vendorId_,   long scheduleId_,   string barcode_ );
		
		void syncVendorScheduleSkus();
		
		void syncVendorScheduleSkusToCache();
		
		void syncVendorSchedules();
		
	}
	
}