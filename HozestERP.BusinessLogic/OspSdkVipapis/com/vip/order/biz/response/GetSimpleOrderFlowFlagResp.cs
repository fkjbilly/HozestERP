using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetSimpleOrderFlowFlagResp {
		
		///<summary>
		/// 通用处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 物流详情列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.FlagVO> flagList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.FlagVO> GetFlagList(){
			return this.flagList_;
		}
		
		public void SetFlagList(List<com.vip.order.common.pojo.order.vo.FlagVO> value){
			this.flagList_ = value;
		}
		
	}
	
}