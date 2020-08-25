using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class ShipResult {
		
		///<summary>
		/// 发货单信息
		///</summary>
		
		private vipapis.marketplace.delivery.ShipInfo ship_;
		
		///<summary>
		/// 结果描述
		///</summary>
		
		private string result_desc_;
		
		public vipapis.marketplace.delivery.ShipInfo GetShip(){
			return this.ship_;
		}
		
		public void SetShip(vipapis.marketplace.delivery.ShipInfo value){
			this.ship_ = value;
		}
		public string GetResult_desc(){
			return this.result_desc_;
		}
		
		public void SetResult_desc(string value){
			this.result_desc_ = value;
		}
		
	}
	
}