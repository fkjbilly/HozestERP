using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class ConfirmOrderGroupBuyVO {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 状态,成功:true,失败:false
		///</summary>
		
		private bool? status_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public bool? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(bool? value){
			this.status_ = value;
		}
		
	}
	
}