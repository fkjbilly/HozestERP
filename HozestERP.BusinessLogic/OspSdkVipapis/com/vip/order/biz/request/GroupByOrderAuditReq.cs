using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GroupByOrderAuditReq {
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private List<com.vip.order.biz.request.GroupByOrderAuditParam> groupByOrderAuditParamSet_;
		
		public List<com.vip.order.biz.request.GroupByOrderAuditParam> GetGroupByOrderAuditParamSet(){
			return this.groupByOrderAuditParamSet_;
		}
		
		public void SetGroupByOrderAuditParamSet(List<com.vip.order.biz.request.GroupByOrderAuditParam> value){
			this.groupByOrderAuditParamSet_ = value;
		}
		
	}
	
}