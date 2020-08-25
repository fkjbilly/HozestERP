using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.vo{
	
	
	
	
	
	public class OrderPayInstalmentVO {
		
		///<summary>
		/// 支付类型
		///</summary>
		
		private int? payType_;
		
		///<summary>
		/// 分期数
		///</summary>
		
		private int? num_;
		
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		
	}
	
}