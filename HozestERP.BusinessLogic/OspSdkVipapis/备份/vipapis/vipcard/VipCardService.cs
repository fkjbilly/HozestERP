using System;
using System.Collections.Generic;

namespace vipapis.vipcard{
	
	
	public interface VipCardService {
		
		
		bool? cancelSoldCard( string shop_name_,   string shop_area_,   int client_id_,   int type_,   string card_code_,   int trans_id_,   int sale_trans_id_ );
		
		List<vipapis.vipcard.VipCard> getCardStatus( string shop_name_,   string shop_area_,   int client_id_,   int type_,   List<string> card_code_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		bool? sellCard( string shop_name_,   string shop_area_,   int client_id_,   int type_,   string card_code_,   int trans_id_ );
		
	}
	
}