using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class VerifyStockAndGetPayableFlagResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 二次支付返回VO
		///</summary>
		
		private com.vip.order.biz.vo.VerifyStockAndGetPayableFlagVO verifyStockAndGetPayableFlagVO_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public com.vip.order.biz.vo.VerifyStockAndGetPayableFlagVO GetVerifyStockAndGetPayableFlagVO(){
			return this.verifyStockAndGetPayableFlagVO_;
		}
		
		public void SetVerifyStockAndGetPayableFlagVO(com.vip.order.biz.vo.VerifyStockAndGetPayableFlagVO value){
			this.verifyStockAndGetPayableFlagVO_ = value;
		}
		
	}
	
}