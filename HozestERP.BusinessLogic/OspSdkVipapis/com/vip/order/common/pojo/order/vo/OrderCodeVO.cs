using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderCodeVO {
		
		///<summary>
		/// 订单流水ID
		///</summary>
		
		private long? orderCodeId_;
		
		///<summary>
		/// 订单流水号
		///</summary>
		
		private string orderCode_;
		
		public long? GetOrderCodeId(){
			return this.orderCodeId_;
		}
		
		public void SetOrderCodeId(long? value){
			this.orderCodeId_ = value;
		}
		public string GetOrderCode(){
			return this.orderCode_;
		}
		
		public void SetOrderCode(string value){
			this.orderCode_ = value;
		}
		
	}
	
}