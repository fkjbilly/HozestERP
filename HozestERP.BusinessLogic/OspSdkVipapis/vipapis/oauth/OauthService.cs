using System;
using System.Collections.Generic;

namespace vipapis.oauth{
	
	
	public interface OauthService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.oauth.RefreshTokenResponse refreshToken( vipapis.oauth.RefreshTokenRequest request_ );
		
	}
	
}