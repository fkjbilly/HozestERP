using System;
using System.Collections.Generic;

namespace com.vip.vop.vendor{
	
	
	public interface VendorInfoService {
		
		
		long? getVendorIdByVendorCode( string vendorCode_ );
		
		com.vip.vop.vendor.VisVendorInfo getVisVendorById( int vendorId_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		List<com.vip.vop.vendor.VendorInfo> selectByVendorName( string vendorName_ );
		
		string selectCodeByVendorId( int vendorId_ );
		
		com.vip.vop.vendor.VendorInfo selectVendorInfoByDevId( int devId_ );
		
	}
	
}