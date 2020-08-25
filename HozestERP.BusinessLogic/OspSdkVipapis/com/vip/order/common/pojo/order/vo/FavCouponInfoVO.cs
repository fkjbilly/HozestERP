using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class FavCouponInfoVO {
		
		///<summary>
		/// 优惠券号码
		///</summary>
		
		private string couponNo_;
		
		public string GetCouponNo(){
			return this.couponNo_;
		}
		
		public void SetCouponNo(string value){
			this.couponNo_ = value;
		}
		
	}
	
}