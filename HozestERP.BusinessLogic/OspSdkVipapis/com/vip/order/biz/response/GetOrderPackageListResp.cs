using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderPackageListResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单包裹列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderPackageVO> orderPackageList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderPackageVO> GetOrderPackageList(){
			return this.orderPackageList_;
		}
		
		public void SetOrderPackageList(List<com.vip.order.common.pojo.order.vo.OrderPackageVO> value){
			this.orderPackageList_ = value;
		}
		
	}
	
}