using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.vo{
	
	
	
	
	
	public class OrderCoopVO {
		
		///<summary>
		/// 订单类型 
		///</summary>
		
		private string vipclub_;
		
		///<summary>
		/// 第三方订单号
		///</summary>
		
		private string exOrderSn_;
		
		public string GetVipclub(){
			return this.vipclub_;
		}
		
		public void SetVipclub(string value){
			this.vipclub_ = value;
		}
		public string GetExOrderSn(){
			return this.exOrderSn_;
		}
		
		public void SetExOrderSn(string value){
			this.exOrderSn_ = value;
		}
		
	}
	
}