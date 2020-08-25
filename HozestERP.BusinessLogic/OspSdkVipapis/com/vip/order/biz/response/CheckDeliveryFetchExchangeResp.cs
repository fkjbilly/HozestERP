using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class CheckDeliveryFetchExchangeResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 是否支持上门揽换的标记，0-不支持，1-支持
		///</summary>
		
		private int? canExchangeOnsite_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public int? GetCanExchangeOnsite(){
			return this.canExchangeOnsite_;
		}
		
		public void SetCanExchangeOnsite(int? value){
			this.canExchangeOnsite_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}