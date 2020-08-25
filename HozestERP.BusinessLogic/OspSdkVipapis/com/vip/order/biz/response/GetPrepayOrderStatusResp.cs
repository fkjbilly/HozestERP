using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetPrepayOrderStatusResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 状态Map
		///</summary>
		
		private Dictionary<string, com.vip.order.common.pojo.order.vo.PrepayOrderStatusVO> statusVOMap_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public Dictionary<string, com.vip.order.common.pojo.order.vo.PrepayOrderStatusVO> GetStatusVOMap(){
			return this.statusVOMap_;
		}
		
		public void SetStatusVOMap(Dictionary<string, com.vip.order.common.pojo.order.vo.PrepayOrderStatusVO> value){
			this.statusVOMap_ = value;
		}
		
	}
	
}