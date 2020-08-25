using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vipcard{
	
	
	
	
	
	public class GroupInfo {
		
		///<summary>
		/// 批次id
		/// @sampleValue id 920
		///</summary>
		
		private int? id_;
		
		///<summary>
		/// 活动标志
		/// @sampleValue activity_flag 1211
		///</summary>
		
		private string activity_flag_;
		
		///<summary>
		/// 活动名称
		/// @sampleValue activity_name xxxxxx
		///</summary>
		
		private string activity_name_;
		
		///<summary>
		/// 商家编码
		/// @sampleValue merchant_code VIPC
		///</summary>
		
		private string merchant_code_;
		
		///<summary>
		/// 生成数量
		/// @sampleValue total 200
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 面值
		/// @sampleValue money 100
		///</summary>
		
		private int? money_;
		
		///<summary>
		/// 到账状态
		/// @sampleValue finance_flag 1
		///</summary>
		
		private int? finance_flag_;
		
		///<summary>
		/// 生成卡状态，0未生成，1已生成
		/// @sampleValue number_flag 1
		///</summary>
		
		private int? number_flag_;
		
		///<summary>
		/// 作废状态
		/// @sampleValue cancel_flag 0
		///</summary>
		
		private int? cancel_flag_;
		
		public int? GetId(){
			return this.id_;
		}
		
		public void SetId(int? value){
			this.id_ = value;
		}
		public string GetActivity_flag(){
			return this.activity_flag_;
		}
		
		public void SetActivity_flag(string value){
			this.activity_flag_ = value;
		}
		public string GetActivity_name(){
			return this.activity_name_;
		}
		
		public void SetActivity_name(string value){
			this.activity_name_ = value;
		}
		public string GetMerchant_code(){
			return this.merchant_code_;
		}
		
		public void SetMerchant_code(string value){
			this.merchant_code_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public int? GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(int? value){
			this.money_ = value;
		}
		public int? GetFinance_flag(){
			return this.finance_flag_;
		}
		
		public void SetFinance_flag(int? value){
			this.finance_flag_ = value;
		}
		public int? GetNumber_flag(){
			return this.number_flag_;
		}
		
		public void SetNumber_flag(int? value){
			this.number_flag_ = value;
		}
		public int? GetCancel_flag(){
			return this.cancel_flag_;
		}
		
		public void SetCancel_flag(int? value){
			this.cancel_flag_ = value;
		}
		
	}
	
}