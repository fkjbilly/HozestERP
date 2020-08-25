using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class ReleaseStockResp {
		
		///<summary>
		/// 返回结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 释放失败的订单商品ID
		///</summary>
		
		private List<long?> failSizeIds_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<long?> GetFailSizeIds(){
			return this.failSizeIds_;
		}
		
		public void SetFailSizeIds(List<long?> value){
			this.failSizeIds_ = value;
		}
		
	}
	
}