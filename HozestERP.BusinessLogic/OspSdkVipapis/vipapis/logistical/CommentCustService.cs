using System;
using System.Collections.Generic;

namespace vipapis.logistical{
	
	
	public interface CommentCustService {
		
		
		long? countOrderCommentsByCondition( long? custNo_,   string ordersn_,   long? startPostime_,   long? endPostime_ );
		
		List<com.vip.comment.api.admin.service.OrderCommentRecord> getCommentsByCustNo( long custNo_,   int curPage_,   int pageSize_,   long? startPostime_,   long? endPostime_ );
		
		List<com.vip.comment.api.admin.service.OrderCommentRecord> getOrderCommentsByCondition( long? custNo_,   string ordersn_,   int curPage_,   int pageSize_,   long? startPostime_,   long? endPostime_,   int? order_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}