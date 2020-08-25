using System;
using System.Collections.Generic;

namespace vipapis.product{
	
	
	public interface ProductService {
		
		
		vipapis.product.GetProductListResponse getProductList( vipapis.common.Warehouse? warehouse_,   string schedule_id_,   int? channel_id_,   int? category_id_,   string start_time_,   string end_time_,   string product_id_,   string product_name_,   int? sell_price_min_,   int? sell_price_max_,   double? discount_min_,   double? discount_max_,   vipapis.product.SortType? sort_type_,   vipapis.product.StockShowType? stock_show_type_,   int? page_,   int? limit_,   string cursorMark_ );
		
		vipapis.product.GetProductStockResponse getProductStock( vipapis.common.Warehouse? warehouse_,   string schedule_id_,   int? channel_id_,   int? category_id_,   string start_time_,   string end_time_,   string product_id_,   string product_name_,   int? sell_price_min_,   int? sell_price_max_,   double? discount_min_,   double? discount_max_,   vipapis.product.SortType? sort_type_,   vipapis.product.StockShowType? stock_show_type_,   int? page_,   int? limit_,   string cursorMark_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}