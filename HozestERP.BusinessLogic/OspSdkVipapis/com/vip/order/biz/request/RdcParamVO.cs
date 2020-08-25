using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class RdcParamVO {
		
		///<summary>
		/// orderSn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// userId
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 是否预付A单.(0:否，1:是，不传默认值为0)
		///</summary>
		
		private int? prepayFlag_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public int? GetPrepayFlag(){
			return this.prepayFlag_;
		}
		
		public void SetPrepayFlag(int? value){
			this.prepayFlag_ = value;
		}
		
	}
	
}