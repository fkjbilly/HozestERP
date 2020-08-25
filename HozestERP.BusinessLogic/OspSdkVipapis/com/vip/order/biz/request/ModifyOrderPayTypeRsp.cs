using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class ModifyOrderPayTypeRsp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 是否处理成功
		///</summary>
		
		private int? isSuccess_;
		
		///<summary>
		/// 更新订单支付方式返回值
		///</summary>
		
		private List<com.vip.order.biz.request.OrderInfo> ModifyPayTypeRsp_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public int? GetIsSuccess(){
			return this.isSuccess_;
		}
		
		public void SetIsSuccess(int? value){
			this.isSuccess_ = value;
		}
		public List<com.vip.order.biz.request.OrderInfo> GetModifyPayTypeRsp(){
			return this.ModifyPayTypeRsp_;
		}
		
		public void SetModifyPayTypeRsp(List<com.vip.order.biz.request.OrderInfo> value){
			this.ModifyPayTypeRsp_ = value;
		}
		
	}
	
}