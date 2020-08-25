using System;
using System.Collections.Generic;

namespace vipapis.vipcard{
	
	
	public interface VipCardService {
		
		
		vipapis.vipcard.ApplyGroupResponse applyGroup( vipapis.vipcard.ApplyGroupRequest applyGroupRequest_ );
		
		vipapis.vipcard.CancelCardResponse cancelCard( int client_id_,   int type_,   List<string> card_code_,   int trans_id_,   string merchant_code_ );
		
		bool? cancelSoldCard( string shop_name_,   string shop_area_,   int client_id_,   int type_,   string card_code_,   int trans_id_,   int sale_trans_id_,   string merchant_code_ );
		
		List<vipapis.vipcard.ActivateCodeInfo> getActivateCode( List<string> card_code_,   string merchant_code_ );
		
		vipapis.vipcard.CardNumberList getCardNumberList( string merchant_code_,   int group_id_,   int status_filter_,   int? page_,   int? limit_ );
		
		List<vipapis.vipcard.VipCard> getCardStatus( string shop_name_,   string shop_area_,   int client_id_,   int type_,   List<string> card_code_,   string merchant_code_ );
		
		vipapis.vipcard.GroupInfo getGroupInfo( string merchant_code_,   int group_id_ );
		
		List<vipapis.vipcard.VipCardInfo> getUserVipCardInfo( int client_id_,   int type_,   List<string> card_code_,   string merchant_code_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		bool? sellCard( string shop_name_,   string shop_area_,   int client_id_,   int type_,   string card_code_,   int trans_id_,   string merchant_code_ );
		
		vipapis.vipcard.SellCardResponse sellVipCard( int client_id_,   int type_,   string card_code_,   int trans_id_,   string merchant_code_,   int? is_return_act_ );
		
	}
	
}