using System;
using System.Collections.Generic;

namespace vipapis.hts{
	
	
	public interface HtGoodRecordService {
		
		
		com.vip.haitao.base.osp.service.record.VipGoodRecordAttachResponse getRecordAttach( com.vip.haitao.base.osp.service.record.GoodRecordAttachParam goodRecordAttachParam_ );
		
		com.vip.haitao.base.osp.service.record.VipGoodRecordResponse getRecordGoodsList( com.vip.haitao.base.osp.service.record.GoodRecordParam goodRecordParam_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.haitao.base.osp.service.record.GoodRecordResponse receiveBatchResult( List<com.vip.haitao.base.osp.service.record.GoodResultParam> goodResultParamList_ );
		
		com.vip.haitao.base.osp.service.record.GoodRecordResponse receiveRecordResult( com.vip.haitao.base.osp.service.record.GoodResultParam goodResultParam_ );
		
	}
	
}