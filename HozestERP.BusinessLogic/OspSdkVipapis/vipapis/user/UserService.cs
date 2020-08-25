using System;
using System.Collections.Generic;

namespace vipapis.user{
	
	
	public interface UserService {
		
		
		vipapis.user.GetGroupsResponse getGroups( vipapis.user.GetGroupsRequest request_ );
		
		vipapis.user.GetUsersByGroupCodeResponse getUsersByGroupCode( vipapis.user.GetUsersByGroupCodeRequest request_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}