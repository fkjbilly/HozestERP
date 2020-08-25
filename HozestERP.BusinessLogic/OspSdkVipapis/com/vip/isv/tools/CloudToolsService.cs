using System;
using System.Collections.Generic;

namespace com.vip.isv.tools{
	
	
	public interface CloudToolsService {
		
		
		List<com.vip.isv.tools.SkuSaleCountInfoDo> getSkuSaleCountInfos( com.vip.isv.tools.SkuSaleCountInfoQueryReq req_,   int? page_,   int? limit_ );
		
		int? getSkuSaleCountInfosCount( com.vip.isv.tools.SkuSaleCountInfoQueryReq req_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.isv.tools.InventoryApplyDetailRes inventoryApplyDetailPageQuery( com.vip.isv.tools.InventoryApplyDetailQueryReq req_,   int? page_,   int? limit_ );
		
		com.vip.isv.tools.CloudCooperationNoLogRes listCloudCooperationNoLog( com.vip.isv.tools.CloudCooperationNoLogReq req_,   int? page_,   int? limit_ );
		
		com.vip.isv.tools.InventoryRetryLogRes listInventoryRetryLog( com.vip.isv.tools.InventoryRetryLogQueryReq req_,   int? page_,   int? limit_ );
		
		com.vip.isv.tools.OccupiedOrderRes occupiedOrderPageQuery( com.vip.isv.tools.OccupiedOrderQueryReq req_,   int? page_,   int? limit_ );
		
		com.vip.isv.tools.ReturnSaleOrderRes returnSaleOrderPageQuery( com.vip.isv.tools.ReturnSaleOrderQueryReq req_,   int? page_,   int? limit_ );
		
		com.vip.isv.tools.SalesSkusRes salesSkusPageQuery( com.vip.isv.tools.SalesSkusQueryReq req_,   int? page_,   int? limit_ );
		
		com.vip.isv.tools.ScheduleSkusRes scheduleSkusPageQuery( com.vip.isv.tools.ScheduleSkusQueryReq req_,   int? page_,   int? limit_ );
		
		com.vip.isv.tools.SkuSaleCountInfoRes skuSaleInfoPageQuery( com.vip.isv.tools.SkuSaleCountInfoQueryReq req_,   int? page_,   int? limit_ );
		
		com.vip.isv.tools.VendorInventoryLogRes vendorInventoryLogPageQuery( com.vip.isv.tools.VendorInventoryLogQueryReq req_,   int? page_,   int? limit_ );
		
		com.vip.isv.tools.VendorSalesRes vendorSalesPageQuery( com.vip.isv.tools.VendorSalesQueryReq req_,   int? page_,   int? limit_ );
		
		void vendorScheduleDelete( List<long?> ids_ );
		
		com.vip.isv.tools.VendorScheduleRes vendorSchedulePageQuery( com.vip.isv.tools.VendorScheduleQueryReq req_,   int? page_,   int? limit_ );
		
		void vendorScheduleRevert( List<long?> ids_ );
		
	}
	
}