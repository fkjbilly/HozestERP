using System;
using System.Collections.Generic;

namespace vipapis.haitaoervice{
	
	
	public interface HtFeedbackMessageService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.haitao.feedback.osp.service.HtFeedbackMessageResponse sendFeedback( string sender_,   string messageType_,   List<com.vip.haitao.feedback.osp.service.HtFeedbackMessageModel> messageList_ );
		
	}
	
}