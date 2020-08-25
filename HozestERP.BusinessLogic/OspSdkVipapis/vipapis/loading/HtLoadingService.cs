using System;
using System.Collections.Generic;

namespace vipapis.loading{
	
	
	public interface HtLoadingService {
		
		
		com.vip.haitao.loading.osp.service.OutRLHandleResult getOutRLHandleResult( string userId_,   string listNo_,   List<string> orders_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.haitao.loading.osp.service.CommonResponse receiveInLRInfo( string customsCode_,   string userId_,   string loadingId_,   string carLicense_,   string loadingNumber_,   string customsReleaseNo_,   List<string> orders_ );
		
		com.vip.haitao.loading.osp.service.PostResponse receiveOutLRInfo( com.vip.haitao.loading.osp.service.HtReceiveOutLoadingReleaseParam param_ );
		
		void sendLoadingDeclare( string instanceCode_,   string nodeCode_ );
		
	}
	
}