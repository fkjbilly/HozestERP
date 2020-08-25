using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetEbsGoodsListReq {
		
		///<summary>
		/// 订单号列表 
		///</summary>
		
		private List<string> orderSnList_;
		
		public List<string> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<string> value){
			this.orderSnList_ = value;
		}
		
	}
	
}