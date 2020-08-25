using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class ModifyPrepayOrderPayTypeReq {
		
		///<summary>
		/// 更新预付订单支付方式请求
		///</summary>
		
		private List<com.vip.order.biz.request.PrepayOrderInfoForReq> prepayOrderInfoForReqList_;
		
		public List<com.vip.order.biz.request.PrepayOrderInfoForReq> GetPrepayOrderInfoForReqList(){
			return this.prepayOrderInfoForReqList_;
		}
		
		public void SetPrepayOrderInfoForReqList(List<com.vip.order.biz.request.PrepayOrderInfoForReq> value){
			this.prepayOrderInfoForReqList_ = value;
		}
		
	}
	
}