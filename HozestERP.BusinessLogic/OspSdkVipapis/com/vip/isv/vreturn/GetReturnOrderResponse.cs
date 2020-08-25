using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.vreturn{
	
	
	
	
	
	public class GetReturnOrderResponse {
		
		///<summary>
		/// 退供订单列表
		///</summary>
		
		private List<com.vip.isv.vreturn.ReturnOrder> return_orders_;
		
		///<summary>
		/// 记录总数
		///</summary>
		
		private int? total_;
		
		public List<com.vip.isv.vreturn.ReturnOrder> GetReturn_orders(){
			return this.return_orders_;
		}
		
		public void SetReturn_orders(List<com.vip.isv.vreturn.ReturnOrder> value){
			this.return_orders_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}