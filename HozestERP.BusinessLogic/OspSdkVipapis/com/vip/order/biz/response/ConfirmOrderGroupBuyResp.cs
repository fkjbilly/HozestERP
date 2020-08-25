using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class ConfirmOrderGroupBuyResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 状态List
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.ConfirmOrderGroupBuyVO> statusList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.ConfirmOrderGroupBuyVO> GetStatusList(){
			return this.statusList_;
		}
		
		public void SetStatusList(List<com.vip.order.common.pojo.order.vo.ConfirmOrderGroupBuyVO> value){
			this.statusList_ = value;
		}
		
	}
	
}