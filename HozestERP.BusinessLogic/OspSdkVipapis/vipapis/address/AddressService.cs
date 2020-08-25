using System;
using System.Collections.Generic;

namespace vipapis.address{
	
	
	public interface AddressService {
		
		
		vipapis.address.FullAddress getFullAddress( string area_code_,   vipapis.address.Is_Show_GAT? is_show_gat_,   bool? is_bind_ );
		
		List<vipapis.address.ProvinceWarehouse> getProvinceWarehouse( vipapis.address.Is_Show_GAT? is_show_gat_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}