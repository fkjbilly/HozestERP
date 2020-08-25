using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vipcard{
	
	
	
	
	
	public class VipCardInfo {
		
		///<summary>
		/// 唯品卡卡号
		/// @sampleValue card_code 16090229100011
		///</summary>
		
		private string card_code_;
		
		///<summary>
		/// 金额
		/// @sampleValue face_money 200
		///</summary>
		
		private double? face_money_;
		
		///<summary>
		/// 卡余额
		/// @sampleValue valid_money 100
		///</summary>
		
		private double? valid_money_;
		
		///<summary>
		/// 已用金额
		/// @sampleValue used_money 100
		///</summary>
		
		private double? used_money_;
		
		///<summary>
		/// 作废金额
		/// @sampleValue frozen_money 0
		///</summary>
		
		private double? frozen_money_;
		
		///<summary>
		/// 过期金额
		/// @sampleValue expired_money 0
		///</summary>
		
		private double? expired_money_;
		
		///<summary>
		/// 使用有效期开始时间
		/// @sampleValue start_time 2016-01-01 00:00:00
		///</summary>
		
		private string start_time_;
		
		///<summary>
		/// 使用有效期结束时间
		/// @sampleValue stop_time 2017-12-31 23:59:59
		///</summary>
		
		private string stop_time_;
		
		///<summary>
		/// 是否已使用,0:否,1:是
		/// @sampleValue is_used 1
		///</summary>
		
		private int? is_used_;
		
		///<summary>
		/// 是否已作废,0:否,1:是
		/// @sampleValue is_frozen 0
		///</summary>
		
		private int? is_frozen_;
		
		///<summary>
		/// 是否已过期,0:否,1:是
		/// @sampleValue is_expired 0
		///</summary>
		
		private int? is_expired_;
		
		public string GetCard_code(){
			return this.card_code_;
		}
		
		public void SetCard_code(string value){
			this.card_code_ = value;
		}
		public double? GetFace_money(){
			return this.face_money_;
		}
		
		public void SetFace_money(double? value){
			this.face_money_ = value;
		}
		public double? GetValid_money(){
			return this.valid_money_;
		}
		
		public void SetValid_money(double? value){
			this.valid_money_ = value;
		}
		public double? GetUsed_money(){
			return this.used_money_;
		}
		
		public void SetUsed_money(double? value){
			this.used_money_ = value;
		}
		public double? GetFrozen_money(){
			return this.frozen_money_;
		}
		
		public void SetFrozen_money(double? value){
			this.frozen_money_ = value;
		}
		public double? GetExpired_money(){
			return this.expired_money_;
		}
		
		public void SetExpired_money(double? value){
			this.expired_money_ = value;
		}
		public string GetStart_time(){
			return this.start_time_;
		}
		
		public void SetStart_time(string value){
			this.start_time_ = value;
		}
		public string GetStop_time(){
			return this.stop_time_;
		}
		
		public void SetStop_time(string value){
			this.stop_time_ = value;
		}
		public int? GetIs_used(){
			return this.is_used_;
		}
		
		public void SetIs_used(int? value){
			this.is_used_ = value;
		}
		public int? GetIs_frozen(){
			return this.is_frozen_;
		}
		
		public void SetIs_frozen(int? value){
			this.is_frozen_ = value;
		}
		public int? GetIs_expired(){
			return this.is_expired_;
		}
		
		public void SetIs_expired(int? value){
			this.is_expired_ = value;
		}
		
	}
	
}