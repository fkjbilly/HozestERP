using System;
using System.Collections.Generic;

namespace vipapis.finance{
	
	
	public interface FastService {
		
		
		vipapis.finance.GetBasicPickFinancialDataResponse getBasicPickFinancialData( int vendor_id_,   string po_no_,   string pick_no_,   int? page_,   int? limit_ );
		
		vipapis.finance.FinancialDetailResponse getDvdFinancialDetail( vipapis.finance.FinancialDetailRequest detailRequest_ );
		
		vipapis.finance.GetOrderFinancialDataResponse getOrderFinancialData( int vendor_id_,   List<string> order_ids_ );
		
		vipapis.finance.GetPoFinancialDetailResponse getPoFinancialDetail( vipapis.finance.GetPoFinancialDetailRequest request_ );
		
		vipapis.finance.GetSaleDetailResponse getSaleDetailData( int vendor_id_,   string po_no_,   long st_query_time_,   long et_query_time_,   int? limit_,   int? page_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}