using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.inventory.admin{
	
	
	
	
	
	public class ListInvRequestRetryRequestResult {
		
		///<summary>
		/// 库存重试请求列表
		///</summary>
		
		private List<vipapis.inventory.admin.InvUpdateRetryRequest> invUpdateRetryRequestList_;
		
		public List<vipapis.inventory.admin.InvUpdateRetryRequest> GetInvUpdateRetryRequestList(){
			return this.invUpdateRetryRequestList_;
		}
		
		public void SetInvUpdateRetryRequestList(List<vipapis.inventory.admin.InvUpdateRetryRequest> value){
			this.invUpdateRetryRequestList_ = value;
		}
		
	}
	
}