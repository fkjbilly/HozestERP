using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class BatchGetOrderTransportListReq {
		
		///<summary>
		/// 表Id主键查询范围
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam idRange_;
		
		///<summary>
		/// 物流Code查询范围
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam transportCodeRange_;
		
		public com.vip.order.common.pojo.order.request.RangeParam GetIdRange(){
			return this.idRange_;
		}
		
		public void SetIdRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.idRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetTransportCodeRange(){
			return this.transportCodeRange_;
		}
		
		public void SetTransportCodeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.transportCodeRange_ = value;
		}
		
	}
	
}