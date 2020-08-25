using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class Error {
		
		///<summary>
		/// 促销活动类型
		///</summary>
		
		private string promotion_type_;
		
		///<summary>
		/// 促销活动名称
		///</summary>
		
		private string promotion_name_;
		
		///<summary>
		/// 促销活动描述
		///</summary>
		
		private string promotion_description_;
		
		///<summary>
		/// 出错信息
		///</summary>
		
		private string error_msg_;
		
		public string GetPromotion_type(){
			return this.promotion_type_;
		}
		
		public void SetPromotion_type(string value){
			this.promotion_type_ = value;
		}
		public string GetPromotion_name(){
			return this.promotion_name_;
		}
		
		public void SetPromotion_name(string value){
			this.promotion_name_ = value;
		}
		public string GetPromotion_description(){
			return this.promotion_description_;
		}
		
		public void SetPromotion_description(string value){
			this.promotion_description_ = value;
		}
		public string GetError_msg(){
			return this.error_msg_;
		}
		
		public void SetError_msg(string value){
			this.error_msg_ = value;
		}
		
	}
	
}