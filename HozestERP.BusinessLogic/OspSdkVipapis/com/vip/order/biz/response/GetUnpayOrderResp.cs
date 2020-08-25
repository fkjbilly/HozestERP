using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetUnpayOrderResp {
		
		///<summary>
		/// 通用结果头部
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单号列表，其中key是用户ID，value是用户的未支付订单列表
		///</summary>
		
		private Dictionary<long?, List<string>> unpayOrderSnMap_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public Dictionary<long?, List<string>> GetUnpayOrderSnMap(){
			return this.unpayOrderSnMap_;
		}
		
		public void SetUnpayOrderSnMap(Dictionary<long?, List<string>> value){
			this.unpayOrderSnMap_ = value;
		}
		
	}
	
}