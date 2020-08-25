using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class ForwordToHtsOrderVo {
		
		///<summary>
		/// 国际运输发货批次
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 返回订单状态码
		///</summary>
		
		private string bizResponseCode_;
		
		///<summary>
		/// 返回订单信息
		///</summary>
		
		private string bizResponseMsg_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetBizResponseCode(){
			return this.bizResponseCode_;
		}
		
		public void SetBizResponseCode(string value){
			this.bizResponseCode_ = value;
		}
		public string GetBizResponseMsg(){
			return this.bizResponseMsg_;
		}
		
		public void SetBizResponseMsg(string value){
			this.bizResponseMsg_ = value;
		}
		
	}
	
}