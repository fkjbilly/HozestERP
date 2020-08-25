using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GroupByOrderAuditResp {
		
		///<summary>
		/// 返回结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 拼团触发审单结果明细
		///</summary>
		
		private List<com.vip.order.biz.response.GroupByOrderAuditResult> groupByOrderAuditResultSet_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.biz.response.GroupByOrderAuditResult> GetGroupByOrderAuditResultSet(){
			return this.groupByOrderAuditResultSet_;
		}
		
		public void SetGroupByOrderAuditResultSet(List<com.vip.order.biz.response.GroupByOrderAuditResult> value){
			this.groupByOrderAuditResultSet_ = value;
		}
		
	}
	
}