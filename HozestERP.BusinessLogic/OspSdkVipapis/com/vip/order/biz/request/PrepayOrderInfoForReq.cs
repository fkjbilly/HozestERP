using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class PrepayOrderInfoForReq {
		
		///<summary>
		/// 预付订单信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO prepayOrderExtend_;
		
		public com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO GetPrepayOrderExtend(){
			return this.prepayOrderExtend_;
		}
		
		public void SetPrepayOrderExtend(com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO value){
			this.prepayOrderExtend_ = value;
		}
		
	}
	
}