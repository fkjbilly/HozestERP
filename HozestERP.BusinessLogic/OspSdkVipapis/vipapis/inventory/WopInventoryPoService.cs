using System;
using System.Collections.Generic;

namespace vipapis.inventory{
	
	
	public interface WopInventoryPoService {
		
		
		com.vip.domain.inventory.OpPoResponse cancelPo( string vendor_id_,   string systemPoNo_ );
		
		com.vip.domain.inventory.OpPoResponse cleanPoDetail( string vendor_id_,   string systemPoNo_ );
		
		com.vip.domain.inventory.CreatePoResponse createPo( string vendor_id_,   com.vip.domain.inventory.CreatePoRequest poReq_ );
		
		com.vip.domain.inventory.OpPoResponse editPO( string vendor_id_,   com.vip.domain.inventory.EditPoRequest poReq_ );
		
		com.vip.domain.inventory.GetPoItemResponse getPoDetailList( string vendor_id_,   string systemPoNo_,   int pageNum_,   int pageSize_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.domain.inventory.OpPoResponse importPoDetail( string vendor_id_,   string systemPoNo_,   List<com.vip.domain.inventory.PoSku> impSkuList_ );
		
		com.vip.domain.inventory.SearchPoResponse searchPoList( string vendor_id_,   int pageNum_,   int pageSize_,   com.vip.domain.inventory.SearchPoRequest searchRequest_ );
		
		com.vip.domain.inventory.OpPoResponse submitPo( string vendor_id_,   string systemPoNo_ );
		
	}
	
}