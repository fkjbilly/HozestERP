using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class BatchUpdateWmsFlagResp {
		
		///<summary>
		/// 返回结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// <p>成功的OrderSn、orderId列表，注意：返回值里是把请求参数里的OrderVO里的三个相关属性放到OrderSnAndIdVO里。如果OrderId和OrderSn都为空，则不会放到成功或者失败列表（这种情况也不可能更新成功）
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> successList_;
		
		///<summary>
		/// <p>失败的OrderSn、orderId列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> failList_;
		
		///<summary>
		/// <p>不符合条件的OrderSn、orderId列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> filterList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> GetSuccessList(){
			return this.successList_;
		}
		
		public void SetSuccessList(List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value){
			this.successList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> GetFailList(){
			return this.failList_;
		}
		
		public void SetFailList(List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value){
			this.failList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> GetFilterList(){
			return this.filterList_;
		}
		
		public void SetFilterList(List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value){
			this.filterList_ = value;
		}
		
	}
	
}