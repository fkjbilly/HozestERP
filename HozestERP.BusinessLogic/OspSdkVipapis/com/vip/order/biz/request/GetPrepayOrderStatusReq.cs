using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetPrepayOrderStatusReq {
		
		///<summary>
		/// 订单号列表
		///</summary>
		
		private List<string> orderSnList_;
		
		///<summary>
		/// 订单号类型
		///</summary>
		
		private string snType_;
		
		public List<string> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<string> value){
			this.orderSnList_ = value;
		}
		public string GetSnType(){
			return this.snType_;
		}
		
		public void SetSnType(string value){
			this.snType_ = value;
		}
		
	}
	
}