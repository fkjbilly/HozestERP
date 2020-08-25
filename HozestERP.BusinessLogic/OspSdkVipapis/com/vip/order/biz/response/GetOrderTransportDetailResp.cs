using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderTransportDetailResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 物流操作列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.TransportVO> transportList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.TransportVO> GetTransportList(){
			return this.transportList_;
		}
		
		public void SetTransportList(List<com.vip.order.common.pojo.order.vo.TransportVO> value){
			this.transportList_ = value;
		}
		
	}
	
}