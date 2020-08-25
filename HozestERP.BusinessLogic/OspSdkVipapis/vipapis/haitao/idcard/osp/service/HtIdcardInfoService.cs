using System;
using System.Collections.Generic;

namespace vipapis.haitao.idcard.osp.service{
	
	
	public interface HtIdcardInfoService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.haitao.idcard.osp.service.HtIdCardInfoResponse queryIdcardPic( com.vip.haitao.idcard.osp.service.HtIdCardInfoRequest request_ );
		
	}
	
}