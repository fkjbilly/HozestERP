using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetOrderListByPosNoReq {
		
		///<summary>
		/// posNo列表
		///</summary>
		
		private List<string> posNoList_;
		
		public List<string> GetPosNoList(){
			return this.posNoList_;
		}
		
		public void SetPosNoList(List<string> value){
			this.posNoList_ = value;
		}
		
	}
	
}