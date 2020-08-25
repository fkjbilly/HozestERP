using System;
using System.Collections.Generic;

namespace com.vip.vop.vendor{
	
	
	public interface VendorWhiteListService {
		
		
		List<com.vip.vop.vendor.CooperationNoConfigInfo> batchGetCooperationNoConfigInfo( int? page_,   int? limit_ );
		
		com.vip.vop.vendor.CooperationNoConfigInfo getCooperationNoConfigInfo( int vendorId_,   int cooperationNo_ );
		
		int? getInventoryUpdatePath( string vendorCode_,   int cooperationNo_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		int? isCooperationNoInWhiteList( string vendorCode_,   int cooperationNo_ );
		
		int? isScheduleInWhiteList( string vendorCode_,   int scheduleId_ );
		
		bool? isVopVendorByVendorCode( string vendorCode_ );
		
		bool? isVopVendorByVendorId( int vendorId_ );
		
	}
	
}