using System;
using System.Collections.Generic;

namespace com.vip.vop.vcloud.product{
	
	
	public interface DieselProductSelfService {
		
		
		void deleteEmailConfig( long partnerId_,   string email_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void pushPriceToVdgByIdList( List<long?> idList_ );
		
		void pushProductToVdgBySkuIdList( List<long?> skuIdList_ );
		
		void pushProductToVdgBySpuIdList( List<long?> spuIdList_ );
		
		void saveEmailConfig( com.vip.vop.vcloud.product.EmailConfig config_ );
		
		void updateProductSku( long? skuId_,   Dictionary<string, string> map_ );
		
		void updateProductSkuAttr( long? skuId_,   Dictionary<string, string> map_ );
		
		void updateProductSkuStatus( com.vip.vop.vcloud.product.ProductSkuStatus criteria_,   com.vip.vop.vcloud.product.ProductSkuStatus skuStatus_ );
		
		void updateProductSpu( long? spuId_,   Dictionary<string, string> map_ );
		
		void updateProductSpuAttr( long? spuId_,   Dictionary<string, string> map_ );
		
		void updateSftpFileLog( List<long?> logIdList_,   byte? logType_,   byte? status_ );
		
	}
	
}