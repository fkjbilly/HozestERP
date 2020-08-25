using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderCouponVO {
		
		///<summary>
		/// 券号
		///</summary>
		
		private string couponSn_;
		
		///<summary>
		/// 类型
		///</summary>
		
		private string couponType_;
		
		///<summary>
		/// 类型名称
		///</summary>
		
		private string couponTypename_;
		
		///<summary>
		/// 维度
		///</summary>
		
		private string couponField_;
		
		///<summary>
		/// 维度名称
		///</summary>
		
		private string couponFieldname_;
		
		///<summary>
		/// 描述
		///</summary>
		
		private string couponFavDesc_;
		
		public string GetCouponSn(){
			return this.couponSn_;
		}
		
		public void SetCouponSn(string value){
			this.couponSn_ = value;
		}
		public string GetCouponType(){
			return this.couponType_;
		}
		
		public void SetCouponType(string value){
			this.couponType_ = value;
		}
		public string GetCouponTypename(){
			return this.couponTypename_;
		}
		
		public void SetCouponTypename(string value){
			this.couponTypename_ = value;
		}
		public string GetCouponField(){
			return this.couponField_;
		}
		
		public void SetCouponField(string value){
			this.couponField_ = value;
		}
		public string GetCouponFieldname(){
			return this.couponFieldname_;
		}
		
		public void SetCouponFieldname(string value){
			this.couponFieldname_ = value;
		}
		public string GetCouponFavDesc(){
			return this.couponFavDesc_;
		}
		
		public void SetCouponFavDesc(string value){
			this.couponFavDesc_ = value;
		}
		
	}
	
}