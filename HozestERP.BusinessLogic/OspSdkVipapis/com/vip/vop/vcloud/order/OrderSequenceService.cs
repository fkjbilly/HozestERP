using System;
using System.Collections.Generic;

namespace com.vip.vop.vcloud.order{
	
	
	public interface OrderSequenceService {
		
		
		com.vip.vop.vcloud.order.OrderSequence getLastUpdateTime( string name_ );
		
		com.vip.vop.vcloud.order.OrderSequence getNextId( string name_ );
		
		int? getNextPid( string name_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void insertDieselOrderRecents( List<com.vip.vop.vcloud.order.DieselOrderRecents> list_ );
		
		void updateLastUpdateTime( com.vip.vop.vcloud.order.OrderSequence sequence_ );
		
		void updateSequence( com.vip.vop.vcloud.order.OrderSequence sequence_ );
		
	}
	
}