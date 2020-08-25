using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetTransportListByCodesResp {
		
		///<summary>
		/// 通用处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 物流详情列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderTransportDetailVO> transportDetailList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderTransportDetailVO> GetTransportDetailList(){
			return this.transportDetailList_;
		}
		
		public void SetTransportDetailList(List<com.vip.order.common.pojo.order.vo.OrderTransportDetailVO> value){
			this.transportDetailList_ = value;
		}
		
	}
	
}