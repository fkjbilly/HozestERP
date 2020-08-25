using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class ReturnMoneyVO {
		
		///<summary>
		/// 退货商品金额
		///</summary>
		
		private string goodsMoney_;
		
		///<summary>
		/// 促销优惠
		///</summary>
		
		private string discount_;
		
		///<summary>
		/// 订购运费(原运费)
		///</summary>
		
		private string transportFee_;
		
		///<summary>
		/// 回寄运费补贴
		///</summary>
		
		private string returnFee_;
		
		public string GetGoodsMoney(){
			return this.goodsMoney_;
		}
		
		public void SetGoodsMoney(string value){
			this.goodsMoney_ = value;
		}
		public string GetDiscount(){
			return this.discount_;
		}
		
		public void SetDiscount(string value){
			this.discount_ = value;
		}
		public string GetTransportFee(){
			return this.transportFee_;
		}
		
		public void SetTransportFee(string value){
			this.transportFee_ = value;
		}
		public string GetReturnFee(){
			return this.returnFee_;
		}
		
		public void SetReturnFee(string value){
			this.returnFee_ = value;
		}
		
	}
	
}