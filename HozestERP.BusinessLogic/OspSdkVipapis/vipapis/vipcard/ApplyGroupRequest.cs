using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vipcard{
	
	
	
	
	
	public class ApplyGroupRequest {
		
		///<summary>
		/// 商家编码
		/// @sampleValue merchant_code VIPS
		///</summary>
		
		private string merchant_code_;
		
		///<summary>
		/// 活动标识
		/// @sampleValue activity_flag 1211
		///</summary>
		
		private string activity_flag_;
		
		///<summary>
		/// 活动名称
		/// @sampleValue activity_name 年青无极限户外
		///</summary>
		
		private string activity_name_;
		
		///<summary>
		/// 请求唯一标识码
		/// @sampleValue apply_key XXXX201601010021
		///</summary>
		
		private string apply_key_;
		
		///<summary>
		/// 唯品卡类型（1:实体唯品卡, 2:电子唯品卡）
		/// @sampleValue card_flag 2
		///</summary>
		
		private int? card_flag_;
		
		///<summary>
		/// 生成数量
		/// @sampleValue total 200
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 制卡面额
		/// @sampleValue face_money 100
		///</summary>
		
		private int? face_money_;
		
		///<summary>
		/// 使用绝对时间
		/// @sampleValue use_stop_time 2018-09-09
		///</summary>
		
		private string use_stop_time_;
		
		///<summary>
		/// 使用相对时间
		/// @sampleValue use_effect_day 0
		///</summary>
		
		private int? use_effect_day_;
		
		public string GetMerchant_code(){
			return this.merchant_code_;
		}
		
		public void SetMerchant_code(string value){
			this.merchant_code_ = value;
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
		public string GetApply_key(){
			return this.apply_key_;
		}
		
		public void SetApply_key(string value){
			this.apply_key_ = value;
		}
		public int? GetCard_flag(){
			return this.card_flag_;
		}
		
		public void SetCard_flag(int? value){
			this.card_flag_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public int? GetFace_money(){
			return this.face_money_;
		}
		
		public void SetFace_money(int? value){
			this.face_money_ = value;
		}
		public string GetUse_stop_time(){
			return this.use_stop_time_;
		}
		
		public void SetUse_stop_time(string value){
			this.use_stop_time_ = value;
		}
		public int? GetUse_effect_day(){
			return this.use_effect_day_;
		}
		
		public void SetUse_effect_day(int? value){
			this.use_effect_day_ = value;
		}
		
	}
	
}