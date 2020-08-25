using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class ShipRequest {
		
		///<summary>
		/// 发货单,发货单个数不能超过50
		///</summary>
		
		private List<vipapis.marketplace.delivery.ShipInfo> ships_;
		
		public List<vipapis.marketplace.delivery.ShipInfo> GetShips(){
			return this.ships_;
		}
		
		public void SetShips(List<vipapis.marketplace.delivery.ShipInfo> value){
			this.ships_ = value;
		}
		
	}
	
}