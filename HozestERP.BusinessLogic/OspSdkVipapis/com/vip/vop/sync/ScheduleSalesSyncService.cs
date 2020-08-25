using System;
using System.Collections.Generic;

namespace com.vip.vop.sync{
	
	
	public interface ScheduleSalesSyncService {
		
		
		void handleSellingJitSchedules();
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void releaseSalesStock();
		
		void syncInventoryTask();
		
		void syncLockSkusToCache();
		
		void syncMasterSalesSkus();
		
		void syncMasterSalesSkusBySharding( int shardingTotalCount_,   int? shardItem_ );
		
		void syncSalesToRedis();
		
		void syncScheduleSalesToRedis();
		
		void syncScheduleSkuByVendorId( long vendorId_ );
		
		void syncScheduleSkusToRedis();
		
		void syncSkuByVendorIdAndScheduleId( int vendorId_,   int scheduleId_ );
		
		void syncSpecialSales();
		
		void syncSpecialSalesSku();
		
		void syncVendorSchedule();
		
	}
	
}