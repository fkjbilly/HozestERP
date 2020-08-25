using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class OfcEntranceGrayControlResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 处理结果,key:orderSn
		///</summary>
		
		private Dictionary<string, com.vip.order.biz.response.OrderIsAllowModel> orderIsAllowMap_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public Dictionary<string, com.vip.order.biz.response.OrderIsAllowModel> GetOrderIsAllowMap(){
			return this.orderIsAllowMap_;
		}
		
		public void SetOrderIsAllowMap(Dictionary<string, com.vip.order.biz.response.OrderIsAllowModel> value){
			this.orderIsAllowMap_ = value;
		}
		
	}
	
}