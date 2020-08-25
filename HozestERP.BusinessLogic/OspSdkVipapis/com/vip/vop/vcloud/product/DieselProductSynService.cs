using System;
using System.Collections.Generic;

namespace com.vip.vop.vcloud.product{
	
	
	public interface DieselProductSynService {
		
		
		void dataMigration( string bucket_,   string key_ );
		
		void download();
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void processImageItem();
		
		void processMasterItem();
		
		void pushProductToVdg();
		
		void replyDiesel();
		
		void validateProduct();
		
		void validateProductByConfig();
		
	}
	
}