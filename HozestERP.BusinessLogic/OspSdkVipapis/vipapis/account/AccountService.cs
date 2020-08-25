using System;
using System.Collections.Generic;

namespace vipapis.account{
	
	
	public interface AccountService {
		
		
		vipapis.account.EnterpriseAccountResponse getEnterpriseAccounts( vipapis.account.EnterpriseAccountQueryRequest request_ );
		
		vipapis.account.EnterpriseOrderResponse getEnterpriseOrders( vipapis.account.EnterpriseOrderQueryRequest request_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		bool? updateEnterpriseAccount( vipapis.account.EnterpriseAccountUpdateRequest request_ );
		
		vipapis.account.EnterpriseAccountsApplyResponse updateEnterpriseAccounts( vipapis.account.EnterpriseAccountBatchUpdateRequest request_ );
		
	}
	
}