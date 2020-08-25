using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetAfterSaleOpTypeResp {
		
		///<summary>
		/// 返回结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 售后服务类型
		///</summary>
		
		private Dictionary<string, com.vip.order.common.pojo.order.vo.OrderAfterSaleOpTypeVO> opMap_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public Dictionary<string, com.vip.order.common.pojo.order.vo.OrderAfterSaleOpTypeVO> GetOpMap(){
			return this.opMap_;
		}
		
		public void SetOpMap(Dictionary<string, com.vip.order.common.pojo.order.vo.OrderAfterSaleOpTypeVO> value){
			this.opMap_ = value;
		}
		
	}
	
}